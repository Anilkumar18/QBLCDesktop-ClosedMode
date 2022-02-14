using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Printing;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace LabelConnector
{
    public partial class FrmPrintByItemTouchScreen : Form
    {
        public FrmPrintByItemTouchScreen()
        {
            InitializeComponent();
        }

        string lstrGetItemDesc = string.Empty;
        clsItemDetails lobjItemsData = new clsItemDetails();
        ArrayList lobjItemslist = new ArrayList();
        string lstrItemWeight = string.Empty;
        Dictionary<string, string> lobjDataExtension;
        QBConfiguration lobjQBConfiguration;
        string lstrQBFileMode = string.Empty;
        string lstrFileName = string.Empty;

        Interop.QBFC13.IQBSessionManager lQBSessionManager = default(Interop.QBFC13.IQBSessionManager);
        LabelConnector.QuickBooksAccount moQuickBooksAccountConfig = null;
        LabelConnector.Serializer loSerializer = new LabelConnector.Serializer();
        public string NetItemWeight
        {
            get
            {
                return lstrItemWeight;
            }
            set
            {
                lstrItemWeight = value;
            }
        }

        private void FrmPrintByItemTouchScreen_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            lstrQBFileMode = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode");
            if (lstrQBFileMode == "Close")
            {

                lstrFileName = loSerializer.GetQuickBooksAccountConfigFile();
                if (File.Exists(lstrFileName))
                {
                    moQuickBooksAccountConfig = loSerializer.ReadQuickBooksAccountConfig(lstrFileName);
                    if (moQuickBooksAccountConfig != null)
                    {
                        lQBSessionManager = LabelConnector.QBHelper.OpenQBConnection(moQuickBooksAccountConfig.CompanyFile, moQuickBooksAccountConfig.FileOpenMode);

                    }
                }
            }



            AddPrinters();
            AutoFillItems();
        }
        private void AutoFillItems()
        {
            //ArrayList lobjItemslist = new ArrayList();
            //clsItemDetails lobjItemsData = new clsItemDetails();



            txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection lststringcollection = new AutoCompleteStringCollection();
            //Get items from quickbooks
            if (lstrQBFileMode == "Close")
            {
                lobjItemslist = lobjItemsData.GetInventoryItemsDetail(lQBSessionManager, moQuickBooksAccountConfig);

            }
            else
            {
                lobjItemslist = lobjItemsData.GetInventoryItemsDetail();
            }


            //Get Customer company name
            foreach (clsItemDetails litem in lobjItemslist)
            {
                //Add Item:SubItem list
                if (litem.FullName != null)
                {

                    lststringcollection.Add(litem.FullName);



                }
            }


            txtItemName.AutoCompleteCustomSource = lststringcollection;



        }

        private void AddPrinters()
        {
            cmbLabelPrinter.Items.Add("Select Printer");
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbLabelPrinter.Items.Add(strPrinter);
            }
            PrintDocument lobjDocument = new PrintDocument();
            cmbLabelPrinter.SelectedItem = lobjDocument.PrinterSettings.PrinterName;
            //cmbLabelPrinter.SelectedIndex = 0;
        }
        private bool CheckMandetory()
        {

            if (txtItemName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter item to print.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return false;
            }
            else if (txtQuantitytoprint.Text.Trim() == "")
            {
                MessageBox.Show("Please enter quantity to print.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantitytoprint.Focus();
                return false;
            }
            else if (cmbLabelPrinter.SelectedIndex == 0)
            {
                MessageBox.Show("Please select printer.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLabelPrinter.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnPrintItemDetail_Click(object sender, EventArgs e)
        {
            try
            {



                btnPrintItemDetail.Enabled = false;
                #region Printing Code Using BarTender

                if (CheckMandetory())
                {
                    if (Convert.ToInt32(txtQuantitytoprint.Text) <= 0)
                    {
                        MessageBox.Show("Quantity to print should be greater than zero.", "Label Connector");
                        txtQuantitytoprint.Focus();
                        return;
                    }
                    foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (clsProcess.ProcessName.StartsWith("bartend"))
                        {
                            clsProcess.Kill();
                            clsProcess.WaitForExit();
                        }
                    }


                    BarTender.Application BtApp = default(BarTender.Application);
                    BarTender.Format BtFormat = default(BarTender.Format);
                    BarTender.SubString BtSubString = default(BarTender.SubString);

                 

                    string btNamedSubString = "";
                    string strProdLblPath = "";
                    string strProdPrinter = "";
                    string strItemLabel = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }
                    xmlDoc.Load(FileInfo.FullName);
                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");

                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == "LabelPath")
                            {
                                strProdLblPath = Node.Attributes.GetNamedItem("value").Value;
                            }
                            //weateher label code commented on 01/13/2015
                            if (Node.Attributes.GetNamedItem("key").Value == "ItemLabelPath")
                            {
                                strItemLabel = Node.Attributes.GetNamedItem("value").Value;
                            }
                        }
                    }
                    // string strLabelName = cmbLabelName.Text;
                    strProdPrinter = cmbLabelPrinter.Text;
                    // int intQuantity = 0;
                    string lstrPropertyValue = string.Empty;
                    string QuantityToPrintOnLabel = string.Empty;

                    BtApp = new BarTender.ApplicationClass();

                    BtFormat = new BarTender.Format();
                    // ----------- Code Start Printing Item Label -----------------
                    //Printing Item label

                    if ((txtItemName.Text.ToString() != string.Empty || txtItemDescription.Text.ToString() != string.Empty) || (!string.IsNullOrEmpty(NetItemWeight)))
                    {
                        int k = 1;
                        BtFormat = BtApp.Formats.Open(strItemLabel, true, strProdPrinter);
                        while (k <= BtFormat.NamedSubStrings.Count)
                        {
                            BtSubString = BtFormat.NamedSubStrings.GetSubString(k);

                            if (BtSubString.Name.ToLower().Trim() == "description") btNamedSubString += BtSubString.Name + '\r' + '\n' + txtItemDescription.Text.ToString() + '\r' + '\n';
                            if (BtSubString.Name.ToLower().Trim() == "itemname") btNamedSubString += BtSubString.Name + '\r' + '\n' + txtItemName.Text.ToString() + '\r' + '\n';
                            if (BtSubString.Name.ToLower().Trim() == "weight") btNamedSubString += BtSubString.Name + '\r' + '\n' + NetItemWeight + '\r' + '\n';

                            k++;
                        }
                        if (btNamedSubString != string.Empty)
                        {
                            string strDelimiter = string.Concat('\r', '\n');
                            BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);
                            BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(txtQuantitytoprint.Text);
                            BtFormat.PrintOut(false, false);

                        }
                    }

                    btNamedSubString = "";

                    //------------Code End for Printing Item Label---------------




                }



                #endregion


                // btnClear.Enabled = true;

                btnPrintItemDetail.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrintItemDetail.Enabled = false;
                //  btnClear.Enabled = true;
            }
        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantitytoprint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            txtItemDescription.Text = "";
            if (e.KeyCode == Keys.Enter)
            {

                //Get items details from quickbooks
                var itemsalesDescription = (from clsItemDetails item in lobjItemslist
                                            where item.FullName == txtItemName.Text.ToString()
                                            select item).FirstOrDefault();
                txtItemDescription.Text = !string.IsNullOrEmpty(itemsalesDescription.SalesDescription) ? itemsalesDescription.SalesDescription.ToString() : null;

                NetItemWeight = !string.IsNullOrEmpty(itemsalesDescription.ItemWeight) ? itemsalesDescription.ItemWeight.ToString() : null;

                //foreach (clsItemDetails item in lobjItemslist)
                //{
                //    if (item.FullName == txtItemName.Text.ToString())
                //    {
                //        if (item.SalesDescription != null)
                //        {
                //            txtItemDescription.Text = item.SalesDescription.ToString();
                //        }
                //    }


                //}



            }
        }
       
    }
}
