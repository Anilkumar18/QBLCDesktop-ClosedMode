using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBLC;
using System.Collections;
using System.Xml;
using System.Data.Odbc;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using BarTender;
using System.Drawing.Printing;
using System.IO;
using System.Globalization;

namespace LabelConnector
{
    public partial class FrmPrintbyItem : Form
    {
        AutoCompleteStringCollection lststringcollection = new AutoCompleteStringCollection();
        frmLabelConfig objfrmLabel = frmLabelConfig.GetInstance();
        List<clsItemBin> listBin = new List<clsItemBin>();
        public FrmPrintbyItem()
        {
            InitializeComponent();
            objfrmLabel.objdelOrderType += new delOrderType(this.fnSetPrinterType);
            this.Text = "Label Connector-Print by Item";

            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Label Connector-Print by Item";

        }
        // private Font printFont;
        //private StreamReader streamToPrint;
        static string filePath;
        string lstrimgfile = string.Empty;
        string lstrGetItemDesc = string.Empty;
        clsItemDetails lobjItemsData = new clsItemDetails();
        ArrayList lobjItemslist = new ArrayList();
        string lstrItemWeight = string.Empty;
        //Dictionary<string, string> lobjDataExtension;
        QBConfiguration lobjQBConfiguration;
        string lstrQBFileMode = string.Empty;
        string lstrFileName = string.Empty;
        string mstrLabelName = string.Empty;
        string SetValuesForTransType = string.Empty;
        string SetTemplatewidth = string.Empty;
        string SetTemplateheight = string.Empty;
        bool isgridhidden = false;
        ArrayList lstAllItemList = new ArrayList();
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
        public class HourGlass : IDisposable
        {
            public HourGlass()
            {
                Enabled = true;
            }
            public void Dispose()
            {
                Enabled = false;
            }
            public static bool Enabled
            {
                get { return System.Windows.Forms.Application.UseWaitCursor; }
                set
                {
                    if (value == System.Windows.Forms.Application.UseWaitCursor) return;
                    System.Windows.Forms.Application.UseWaitCursor = value;
                    Form f = Form.ActiveForm;
                    if (f != null && f.Handle != IntPtr.Zero)   // Send WM_SETCURSOR
                        SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
                }
            }
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        }
        private void ReadSyncItems(string strStartupPath)
        {
            long length = 0;
            XmlTextReader tr = new XmlTextReader(strStartupPath + "QuickBookItems.xml");

            length = new System.IO.FileInfo(strStartupPath + "QuickBookItems.xml").Length;
            if (length == 0)
            {
                MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int lntcount = 0;
            int lntCounterId = 1;
            clsItemDetails objItem = null;
            try
            {
                while (tr.Read())
                {

                    if (tr.IsStartElement())
                    {

                        if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "itemname")
                        {
                            if (lntcount > 0)
                            {
                                objItem.id = lntCounterId++;
                                lstAllItemList.Add(objItem);

                            }
                            objItem = new clsItemDetails();
                            objItem.CustomItem.Clear();
                            objItem.itemname = tr.ReadElementString();
                            lntcount++;
                            objItem.id = lntCounterId;

                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "description")
                        {

                            objItem.description = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "salesprice")
                        {

                            objItem.salesprice = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonsalesorder")
                        {

                            objItem.quantityonsalesorder = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonorder")
                        {

                            objItem.quantityonorder = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonhand")
                        {

                            objItem.quantityonhand = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "reorderpoint")
                        {

                            objItem.ReorderPoint = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "subitemof")
                        {

                            objItem.subitemof = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "max")
                        {

                            objItem.Max = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "averagecost")
                        {

                            objItem.averagecost = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "unitofmeasuresetref")
                        {

                            objItem.unitofmeasuresetref = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "mpn")
                        {

                            objItem.mpn = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "purchasedesc")
                        {

                            objItem.purchasedesc = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "purchasecost")
                        {

                            objItem.purchasecost = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "incomeaccountref")
                        {

                            objItem.incomeaccountref = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "prefvendorref")
                        {

                            objItem.prefvendorref = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "barcodevalue")
                        {
                            objItem.barcodevalue = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "cogsaccountref")
                        {

                            objItem.cogsaccountref = tr.ReadElementString();
                        }

                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "assetaccountref")
                        {

                            objItem.assetaccountref = tr.ReadElementString();
                        }
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "itemtype")
                        {

                            objItem.itemtype = tr.ReadElementString();
                        }
                        else
                        {
                            if (tr.MoveToContent() == XmlNodeType.Element && (tr.Name != "QuickBooks" && tr.Name != "Item" && tr.Name != "CustomItem" && tr.Name != "id"))
                            {
                                //string filtered = (tr.Name.StartsWith("_")) ? tr.Name.Substring(1) : tr.Name;

                                objItem.CustomItem.Add((tr.Name.StartsWith("_")) ? tr.Name.Substring(1) : tr.Name, tr.ReadElementString());
                            }

                            //if (tr.MoveToContent() == XmlNodeType.CDATA)
                            //{

                            //    objItem.CustomItem.Add(tr.Name, tr.Value);
                            //}

                        }


                    }

                } //end while
            }
            catch (XmlException ex)
            {

                isgridhidden = true;
                objItem = null;

            }
            tr.Close();
            if (objItem != null)
            {
                if (!string.IsNullOrEmpty(objItem.itemname))
                    lstAllItemList.Add(objItem);
                isgridhidden = false;
            }


        }
        public void AutoCompleteSarchText()
        {

            using (new HourGlass())
            {

                string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");

                if (!File.Exists(strStartupPath + "QuickBookItems.xml"))
                {
                    MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lststringcollection = new AutoCompleteStringCollection();

                ReadSyncItems(strStartupPath);


                List<string> liItemautocomplete = (from clsItemDetails objItemRecord in lstAllItemList
                                         orderby objItemRecord.Name
                                         select objItemRecord.Name).ToList();
               
                foreach (var searchitems in liItemautocomplete)
                {
                    lststringcollection.Add(searchitems.ToString());
                }

                txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;

                txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtItemName.AutoCompleteCustomSource = lststringcollection;
            }

        }
        private void txtLotNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQtyOnLabel.Focus();
            }
        }
        private void txtQtyOnLabel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantitytoprint.Focus();
            }
        }
        private void FrmPrintbyItem_Load(object sender, EventArgs e)
        {
            AutoCompleteSarchText();

            AddPrinters();
            //Set printer Setting
            if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") != "Screen")
            {
                //from setting common printer
                cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter");
                cmbLabelPrinter.Enabled = false;
                // cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("LabelName"); // 07/19
            }
            else
            {
                //from scren6
                //cmbLabelPrinter.SelectedIndex = 0;
                cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ItemScreenPrinter");
                cmbLabelPrinter.Enabled = true;

            }
            
            //load labels based on setting: 31-Jan-2018
            if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
            {
                fnGenerateLabelCB();
            }
            else
            {
                fnGetUDFLabels();
            }
            txtQuantitytoprint.Text = "1";

            // cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("LabelName"); // 07/19 
            ////if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "U")
            ////{                                                                                     //check if udf print label exist
            ////    if (clsUtil.IsUDFLabelExist() == false)
            ////    {
            ////        DialogResult dialoglblexist = new DialogResult();

            ////        dialoglblexist = MessageBox.Show("No Label designs have been created please proceed to the Label designer to create your first template.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ////        if (dialoglblexist == DialogResult.OK)
            ////        {
            ////            //System.Environment.Exit(1);
            ////        }
            ////    }
            ////}
            // Set cursor as default arrow
            string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath")));
            if (template == "")
            {
                lblTempName.Text = "";
            }
            else
            {
                lblTempName.Text = Path.GetFileName(template);
            }
            Cursor.Current = Cursors.Default;

        }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            // txtItemDescription.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = Cursors.WaitCursor;
                listBin = new List<clsItemBin>();
                cboBin.Items.Clear();
                //Get items details from quickbooks
                var itemsalesDescription = (from clsItemDetails item in lstAllItemList//lobjItemslist
                                            where item.Name == txtItemName.Text.ToString()
                                            select item).FirstOrDefault();
                

                if (itemsalesDescription != null)
                {
                    if (txtItemName.Text.ToString() != null)
                    {

                        if (string.IsNullOrWhiteSpace(itemsalesDescription.subitemof))
                        {
                            listBin = clsTemplateLabelXmlwork.GetItemBin(txtItemName.Text.ToString());
                        }
                        else
                        {
                            listBin = clsTemplateLabelXmlwork.GetItemBin(itemsalesDescription.subitemof + ":" + txtItemName.Text.ToString());
                        }

                        foreach (clsItemBin bin in listBin)
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Text = bin.Bin + " : " + bin.Site + " : " + bin.QtyOnHand;
                            item.Value = bin.SiteBinRefID;
                            cboBin.Items.Add(item);
                            cboBin.SelectedIndex = 0;
                        }

                    }

                    txtItemDescription.Text = !string.IsNullOrEmpty(itemsalesDescription.description) ? itemsalesDescription.description.ToString() : null;

                    NetItemWeight = !string.IsNullOrEmpty(itemsalesDescription.ItemWeight) ? itemsalesDescription.ItemWeight.ToString() : null;

                    txtLotNo.Focus();
                }
                else
                {
                    if (txtItemName.Text != "")
                    {
                        MessageBox.Show("Item not found in QuickBooks.", "Label Connector");
                        txtItemDescription.Text = "";
                        txtItemName.Focus();
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }
        //Handle enter key on print button
        //private void txtQuantitytoprint_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar.Equals(Convert.ToChar(13))) { btnPrintItemDetail_Click(sender, e); }

        //}
        private void btnPrintItemDetail_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            //List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
            //clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            //List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
            //List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();

            try
            {
                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //print Item based on searach
                using (new HourGlass())
                {
                    if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B") // print label based on setting for bartender or user defined label
                    {
                        PrintItemsBySearch();
                    }
                    else
                    {
                        //print user defined label

                        //  objfieldlist = lobjTemplatexml.GetFieldPropertiesList(cmbLabelName.Text.ToString(), string.Empty);
                        ////Get property fields list

                        // objheaderfield = lobjTemplatexml.GetTemplateHeaderInfo(cmbLabelName.Text.ToString());
                        // foreach (QuickBooksField itemfield in objheaderfield)
                        // {
                        //     if (itemfield.ItemFieldId == 1)
                        //     {
                        //         this.SetValuesForTransType = itemfield.ItemFieldName;
                        //     }
                        //     else if (itemfield.ItemFieldId == 2)
                        //     {
                        //         this.SetTemplatewidth = itemfield.ItemFieldName;
                        //     }
                        //     else if (itemfield.ItemFieldId == 3)
                        //     {
                        //         this.SetTemplateheight = itemfield.ItemFieldName;
                        //     }
                        // }

                        //  string strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";
                        // if (File.Exists(strTransTypeFilePath))
                        // {
                        //     Itemfieldlist = lobjTemplatexml.GetItemFieldListfromxml(strTransTypeFilePath); //Get Trans field list
                        // }

                        //   lobjTemplatexml.PrintTemplate(cmbLabelName.Text.ToString(), this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType, objfieldlist, Itemfieldlist);

                        PrintUDFItemBySearch();
                    }
                    Clear();

                    if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") == "Screen")
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text, "ItemScreenPrinter");
                    }
                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text, "LabelName");

                    System.Threading.Thread.Sleep(1000);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrintItemDetail.Enabled = false;
                btnclosed.Enabled = true;

            }
        }
        private void Clear()
        {
            txtItemName.Text = "";
            txtItemName.Focus();
            txtItemDescription.Text = "";
            txtLotNo.Text = "";
            txtQtyOnLabel.Text = "";
            txtQuantitytoprint.Text = "1";
            cboBin.Items.Clear();
            txtQtyOnHand.Text = "";
            listBin=new List<clsItemBin>();
        }
        private void PrintItemsBySearch()
        {
            lobjQBConfiguration = new QBConfiguration();

            int cntChk = 0;

            try
            {
                if (cmbLabelName.SelectedIndex > 0)
                {
                    btnPrintItemDetail.Enabled = false;

                    if (CheckMandetory())
                    {

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

                        OdbcConnection Cn = new OdbcConnection(ConfigurationManager.AppSettings["quickbookDSN"]);

                        string btNamedSubString = string.Empty;
                        string strProdLblPath = "";

                        string strProdPrinter = "";
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
                            if (Node.Name == "add")
                            {
                                if (Node.Attributes.GetNamedItem("key").Value == "LabelPath")
                                {
                                    strProdLblPath = Node.Attributes.GetNamedItem("value").Value;
                                }

                            }
                        }
                        string strLabelName = string.Empty;
                        string packperunitvalue = string.Empty;

                        strLabelName = cmbLabelName.Text;

                        strProdPrinter = cmbLabelPrinter.Text;
                        int intQuantity = 0;

                        string lstrPropertyValue = string.Empty;
                        BtApp = new BarTender.ApplicationClass();
                        BtFormat = new BarTender.Format();

                        if ((cmbLabelName.SelectedIndex != 0))
                        {
                            try
                            {

                                this.Cursor = Cursors.WaitCursor;
                                if (txtQuantitytoprint.Text == null)
                                {
                                    MessageBox.Show("Qty to Print cannot be Null", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnPrintItemDetail.Enabled = true;
                                    return;
                                }
                                //Allow -ve Qty to print : Date 21-sept-2017
                                if (txtQuantitytoprint.Text.ToString().StartsWith("-"))
                                {
                                    MessageBox.Show("Qty to print can not be negative", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnPrintItemDetail.Enabled = true;
                                    return;
                                }
                                intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(txtQuantitytoprint.Text.ToString().Trim())));
                                this.Cursor = Cursors.WaitCursor;
                                BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);


                                ArrayList alLineItem = null;

                                clsItemDetails objclsItemDetails = null;
                                Type objClsType;
                                object strPropertyValue = null;

                                objclsItemDetails = new clsItemDetails();


                                //Get Item details based on search
                                var liItemRecord = from clsItemDetails objItemRecord in lstAllItemList  //alLineItemSearch
                                                   where objItemRecord.itemname == Convert.ToString(txtItemName.Text.ToString().Trim())
                                                   select objItemRecord;


                                alLineItem = new ArrayList(liItemRecord.ToList());


                                objClsType = objclsItemDetails.GetType();

                                btNamedSubString = "";
                                int i = 1;
                                while (i <= BtFormat.NamedSubStrings.Count)
                                {

                                    BtSubString = BtFormat.NamedSubStrings.GetSubString(i);
                                    int y = 0;
                                    while (y <= alLineItem.Count - 1)
                                    {
                                        try
                                        {

                                            PropertyInfo objPropertyInfo = objClsType.GetProperty(BtSubString.Name.ToString().Replace(System.Environment.NewLine, string.Empty).Trim().ToLower());

                                            strPropertyValue = objPropertyInfo.GetValue((clsItemDetails)alLineItem[y], null);

                                        }
                                        catch (Exception ex)
                                        {
                                            try
                                            {
                                                string lstrPropertyValExt = string.Empty;

                                                foreach (clsItemDetails customfield in alLineItem)
                                                {

                                                    if (customfield.CustomItem.ContainsKey(BtSubString.Name.ToString().Trim().ToUpper()))
                                                    {
                                                        customfield.CustomItem.TryGetValue(BtSubString.Name.ToString().Trim().ToUpper(), out lstrPropertyValExt);
                                                        strPropertyValue = lstrPropertyValExt;
                                                    }
                                                    else
                                                    {
                                                        strPropertyValue = string.Empty;
                                                    }
                                                }
                                            }
                                            catch (Exception exExt)
                                            {
                                                strPropertyValue = string.Empty;
                                            }
                                            finally
                                            {
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + "  Value:-" + strPropertyValue);
                                            }
                                        }
                                        //Add LotNo to print
                                        if (BtSubString.Name.ToLower().Trim() == "lotno")
                                        {
                                            if (txtLotNo.Text != null)
                                            {
                                                strPropertyValue = Convert.ToString(txtLotNo.Text.ToString().Trim());
                                            }
                                        }
                                        //Add QtyOnHand to print
                                        if (BtSubString.Name.ToLower().Trim() == "qtyonlabel")
                                        {
                                            if (txtQtyOnLabel.Text != null)
                                            {
                                                strPropertyValue = Convert.ToString(txtQtyOnLabel.Text.ToString().Trim());
                                            }
                                        }

                                        lstrPropertyValue = Convert.ToString(strPropertyValue);

                                        btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrPropertyValue + '\r' + '\n';

                                        y += 1;
                                    }
                                    i += 1;

                                } //end of while

                                string strDelimiter = string.Concat('\r', '\n');

                                BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);


                                BtFormat.IdenticalCopiesOfLabel = intQuantity;

                                BtFormat.PrintOut(false, false);


                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Label Connector");
                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Label Printing is having some problem.:-" + ex.Message + ":" + ex.StackTrace);
                            }
                            finally
                            {
                                BtFormat.Close(BtSaveOptions.btDoNotSaveChanges);
                                BtApp.Quit(BtSaveOptions.btDoNotSaveChanges);
                                BtSubString = null;
                                BtFormat = null;
                                BtApp = null;
                                foreach (Process clsProcess in Process.GetProcesses())
                                {
                                    if (clsProcess.ProcessName.StartsWith("bartend"))
                                    {
                                        clsProcess.Kill();
                                        clsProcess.WaitForExit();
                                    }
                                }

                                if (Cn.State == ConnectionState.Open)
                                {
                                    Cn.Close();
                                    Cn.Dispose();
                                }
                                System.Threading.Thread.Sleep(1000);
                                this.Cursor = Cursors.Default;
                                //btnPrint.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Printing Error: " + "Please Select Label");
                        }
                        //save selected label :Date 23-Feb-2017
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "saveinvoicelabel");

                        //save printer name :Date 11-Feb-2017
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "invpackprinter");
                    }
                }
                else
                {
                    MessageBox.Show("Select Label", "Label Connector");
                }
                btnclosed.Enabled = true;
                btnPrintItemDetail.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                this.Cursor = Cursors.Default;
                btnPrintItemDetail.Enabled = false;
                btnclosed.Enabled = true;
            }
        }

        private void PrintUDFItemBySearch()
        {
            lobjQBConfiguration = new QBConfiguration();
            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
            //  List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
            string strProdPrinter = "";
            bool blnIsIncrementcounter = false;
            int cntChk = 0;

            try
            {
                if (cmbLabelName.SelectedIndex > 0)
                {
                    btnPrintItemDetail.Enabled = false;

                    if (CheckMandetory())
                    {

                        //Get Template details based on Template name.....

                        string strLabelName = string.Empty;
                        string packperunitvalue = string.Empty;

                        strLabelName = cmbLabelName.Text;

                        strProdPrinter = cmbLabelPrinter.Text;
                        int intQuantity = 0;

                        string lstrPropertyValue = string.Empty;

                        if ((cmbLabelName.SelectedIndex != 0))
                        {
                            try
                            {

                                this.Cursor = Cursors.WaitCursor;
                                if (txtQuantitytoprint.Text == null)
                                {
                                    MessageBox.Show("Qty to Print cannot be Null", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnPrintItemDetail.Enabled = true;
                                    return;
                                }
                                //Allow -ve Qty to print : Date 21-sept-2017
                                if (txtQuantitytoprint.Text.ToString().StartsWith("-"))
                                {
                                    MessageBox.Show("Qty to print can not be negative", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnPrintItemDetail.Enabled = true;
                                    return;
                                }
                                intQuantity = Convert.ToInt32(Math.Round(Convert.ToDouble(txtQuantitytoprint.Text)));
                                this.Cursor = Cursors.WaitCursor;


                                ArrayList alLineItem = null;

                                //clsItemDetails objclsItemDetails = null;
                                //Type objClsType;
                                //object strPropertyValue = null;

                                //objclsItemDetails = new clsItemDetails();


                                //Get Item details based on search
                                var liItemRecord = from clsItemDetails objItemRecord in lstAllItemList  //alLineItemSearch
                                                   where objItemRecord.itemname == Convert.ToString(txtItemName.Text.ToString().Trim()) && (Convert.ToString(objItemRecord.description) == null ? "" : objItemRecord.description.ToString()) == Convert.ToString(txtItemDescription.Text).ToString()
                                                   select objItemRecord;

                                var itemsalesDescription = (from clsItemBin item in listBin//lobjItemslist
                                                            where item.SiteBinRefID == ((LabelConnector.FrmPrintbyItem.ComboboxItem)cboBin.SelectedItem).Value.ToString()
                                                            select item).FirstOrDefault();


                                alLineItem = new ArrayList(liItemRecord.ToList());

                                //var sg = alLineItem.Cast<clsItemDetails>().ToArray();
                                if(itemsalesDescription != null)
                                {
                                    ((clsItemDetails)alLineItem[0]).bin = itemsalesDescription.Bin;
                                    ((clsItemDetails)alLineItem[0]).site = itemsalesDescription.Site;
                                    ((clsItemDetails)alLineItem[0]).qtyonhand = itemsalesDescription.QtyOnHand;
                                }                             

                                //objClsType = objclsItemDetails.GetType();
                                string lstitem = string.Empty;

                                objfieldlist = lobjTemplatexml.GetFieldPropertiesList(cmbLabelName.Text.ToString(), string.Empty);
                                //Get property fields list

                                objheaderfield = lobjTemplatexml.GetTemplateHeaderInfo(cmbLabelName.Text.ToString());
                                foreach (QuickBooksField itemfield in objheaderfield)
                                {
                                    if (itemfield.ItemFieldId == 1)
                                    {
                                        this.SetValuesForTransType = itemfield.ItemFieldName;
                                    }
                                    else if (itemfield.ItemFieldId == 2)
                                    {
                                        this.SetTemplatewidth = itemfield.ItemFieldName;
                                    }
                                    else if (itemfield.ItemFieldId == 3)
                                    {
                                        this.SetTemplateheight = itemfield.ItemFieldName;
                                    }
                                }
                                //Create Pdf & Print items
                                //foreach (var varintemincr in objfieldlist)
                                //{
                                //    if (varintemincr.datasourcetext.ToString().ToLower() == "itemincrement")
                                //    {
                                //        blnIsIncrementcounter = true;
                                //        break;
                                //    }
                                //}
                                //if (blnIsIncrementcounter == true)
                                //{
                                //    lobjTemplatexml.PrintTemplateForItemIncrementCounter(cmbLabelName.Text.ToString(), SetTemplatewidth, SetTemplateheight, SetValuesForTransType, txtLotNo.Text.ToString(), txtQtyOnLabel.Text.ToString(), Convert.ToInt32(txtQuantitytoprint.Text.ToString()),objfieldlist, alLineItem);
                                //    //print multiple images:10-APR-2019
                                //    filePath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\";
                                //    PrintMultipleImages(filePath);
                                //}
                                //else
                                //{
                                lobjTemplatexml.PrintTemplateForItems(cmbLabelName.Text.ToString(), this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType, txtLotNo.Text.ToString(), txtQtyOnLabel.Text.ToString(), Convert.ToInt32(Math.Round(Convert.ToDouble(txtQuantitytoprint.Text))), objfieldlist, alLineItem, cmbLabelPrinter.Text.ToString());

                                filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Tiff");
                                Print(filePath, intQuantity);
                                // }



                            }

                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Label Connector");
                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Label Printing is having some problem.:-" + ex.Message + ":" + ex.StackTrace);
                            }
                            finally
                            {

                                System.Threading.Thread.Sleep(1000);
                                this.Cursor = Cursors.Default;
                                //btnPrint.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Printing Error: " + "Please Select Label");
                        }
                        //save selected label :Date 23-Feb-2017
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "saveinvoicelabel");

                        //save printer name :Date 11-Feb-2017
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "invpackprinter");
                    }
                }
                else
                {
                    MessageBox.Show("Select Label", "Label Connector");
                }
                btnclosed.Enabled = true;
                btnPrintItemDetail.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                this.Cursor = Cursors.Default;
                btnPrintItemDetail.Enabled = false;
                btnclosed.Enabled = true;
            }
        }


        public void Print(string FileName, int pintprintqty)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));

            try
            {
                if (string.IsNullOrWhiteSpace(FileName)) return; // Prevents execution of below statements if filename is not selected.

                PrintDocument pd = new PrintDocument();

                //Disable the printing document pop-up dialog shown during printing.
                PrintController printController = new StandardPrintController();
                pd.PrintController = printController;

                //For testing only: Hardcoded set paper size to particular paper.
                //pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);
                //pd.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);
                pd.PrinterSettings.PrinterName = cmbLabelPrinter.Text.ToString();
                pd.PrinterSettings.Copies = Convert.ToInt16(pintprintqty);
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                //pd.DefaultPageSettings.Margins.Left = 0;
                //pd.DefaultPageSettings.Margins.Top = 0;
                //pd.DefaultPageSettings.Margins.Bottom = 0;
                //pd.DefaultPageSettings.Margins.Right = 0;

                pd.PrintPage += (sndr, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(FileName);

                    //Adjust the size of the image to the page to print the full image without loosing any part of the image.
                    System.Drawing.Rectangle m = args.MarginBounds;

                    //Logic below maintains Aspect Ratio.
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    //Calculating optimal orientation.
                    pd.DefaultPageSettings.Landscape = m.Width > m.Height;
                    //Putting image in center of page.
                    // m.Y = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Height - m.Height) / 2);
                    // m.X = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Width - m.Width) / 2);
                    args.Graphics.DrawImage(i, m);
                };
                pd.Print();
            }
            catch (Exception ex)
            {
                // log.ErrorFormat("Error : {0}\n By : {1}-{2}", ex.ToString(), this.GetType(), MethodBase.GetCurrentMethod().Name);
                QBHelper.WriteLog("ErrorCatch : {0}" + ex.ToString());
            }
            finally
            {
                logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));
                // log.Info(logMessage.ToString());
                QBHelper.WriteLog("ErrorFinally : {0}" + logMessage.ToString());
            }
        }

        //print multiple images:Date 10-APR-2019
        public void PrintMultipleImages(string pstrimagepath)
        {
            StringBuilder logMessage = new StringBuilder();
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));

            try
            {
                // if (string.IsNullOrWhiteSpace(pstrimagepath)) return; // Prevents execution of below statements if filename is not selected.               
                var imagefiles = Directory.GetFiles(pstrimagepath, "*.tiff");
                if (imagefiles != null)
                {
                    foreach (var imgpath in imagefiles)
                    {
                        PrintDocument pd = new PrintDocument();

                        //Disable the printing document pop-up dialog shown during printing.
                        PrintController printController = new StandardPrintController();
                        pd.PrintController = printController;


                        pd.PrinterSettings.PrinterName = cmbLabelPrinter.Text.ToString();
                        pd.PrinterSettings.Copies = 1;//Convert.ToInt16(pintprintqty);
                        pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        pd.PrintPage += (sndr, args) =>
                        {

                            System.Drawing.Image i = System.Drawing.Image.FromFile(imgpath.ToString());

                            //Adjust the size of the image to the page to print the full image without loosing any part of the image.
                            System.Drawing.Rectangle m = args.MarginBounds;

                            //Logic below maintains Aspect Ratio.
                            if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                            {
                                m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                            }
                            else
                            {
                                m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                            }
                            //Calculating optimal orientation.
                            pd.DefaultPageSettings.Landscape = m.Width > m.Height;
                            args.Graphics.DrawImage(i, m);

                        };

                        pd.Print();
                    }
                }

            }
            catch (Exception ex)
            {

                QBHelper.WriteLog("ErrorCatch : {0}" + ex.ToString());
            }
            finally
            {
                logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));

                QBHelper.WriteLog("ErrorFinally : {0}" + logMessage.ToString());
            }
        }

        //The Print Event handeler
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            // filePath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Jpeg";

            try
            {
                if (File.Exists(lstrimgfile))
                {
                    //foreach (string strfile in filePaths)
                    //{
                    //Load the image from the file
                    System.Drawing.Image img = System.Drawing.Image.FromFile(lstrimgfile);

                    //Adjust the size of the image to the page to print the full image without loosing any part of it
                    Rectangle m = e.MarginBounds;

                    if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                    }
                    e.Graphics.DrawImage(img, m);
                }
                //}
            }
            catch (Exception)
            {

            }
        }


        //public void Printing()
        //{
        //    try
        //    {
        //        filePath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Jpeg";
        //        streamToPrint = new StreamReader(filePath);
        //        try
        //        {
        //            printFont = new Font("Arial", 10);
        //            PrintDocument pd = new PrintDocument();
        //            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        //            pd.PrinterSettings.PrinterName = cmbLabelPrinter.Text;
        //            // Print the document.

        //            pd.Print();
        //        }
        //        finally
        //        {
        //            streamToPrint.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    float linesPerPage = 0;
        //    float yPos = 0;
        //    int count = 0;
        //    float leftMargin = ev.MarginBounds.Left;
        //    float topMargin = ev.MarginBounds.Top;
        //    String line = null;

        //    // Calculate the number of lines per page.
        //    linesPerPage = ev.MarginBounds.Height /
        //       printFont.GetHeight(ev.Graphics);

        //    // Iterate over the file, printing each line.
        //    while (count < linesPerPage &&
        //       ((line = streamToPrint.ReadLine()) != null))
        //    {
        //        yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
        //        ev.Graphics.DrawString(line, printFont, Brushes.Black,
        //           leftMargin, yPos, new StringFormat());
        //        count++;
        //    }

        //    // If more lines exist, print another page.
        //    if (line != null)
        //        ev.HasMorePages = true;
        //    else
        //        ev.HasMorePages = false;
        //}
        //private void printDoc_Print(object sender, PrintPageEventArgs e)
        //{

        //    var filename = System.Windows.Forms.Application.StartupPath + @"\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Jpeg";
        //    try
        //    {
        //        Image img = Image.FromFile(filename);

        //        //PointF pf = new PointF(0, 0);
        //        //ev.Graphics.DrawImage(img, pf);

        //        // Print in the upper left corner at its full size.
        //        e.Graphics.DrawImage(img,
        //            e.MarginBounds.X, e.MarginBounds.Y,
        //            img.Width, img.Height);

        //        // Print in the upper right corner,
        //        // sized to fit beside the other image.
        //        int left = e.MarginBounds.Left + img.Width;
        //        int width = e.MarginBounds.Width - img.Width;
        //        float scale = width / (float)img.Width;
        //        int height = (int)(img.Height * scale);
        //        e.Graphics.DrawImage(img,
        //            left, e.MarginBounds.Y, width, height);

        //        // Print the same size in the lower right corner.
        //        int top = e.MarginBounds.Bottom - height;
        //        e.Graphics.DrawImage(img,
        //            left, top, width, height);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        private void AddPrinters()
        {
            lobjQBConfiguration = new QBConfiguration();
            cmbLabelPrinter.Items.Add("Select Printer");
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbLabelPrinter.Items.Add(strPrinter);
            }
            PrintDocument lobjDocument = new PrintDocument();

            if (!string.IsNullOrEmpty(lobjQBConfiguration.GetLabelConfigSettings("PrinterName")))
            {
                cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("PrinterName");
            }
            else
            {
                cmbLabelPrinter.SelectedIndex = 0;
            }

            // cmbLabelPrinter.SelectedItem = lobjDocument.PrinterSettings.PrinterName;
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
            else if (cmbLabelName.SelectedIndex == 0 || lblTempName.Text=="")
            {
                MessageBox.Show("Please select label to be printed.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLabelName.Focus();
                return false;
            }

            else
            {
                return true;
            }

        }

        public void fnSetPrinterType()
        {
            //Set printer name from config file

            if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") != "Screen")
            {
                cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter");
                cmbLabelPrinter.Enabled = false;
            }
            else
            {
                cmbLabelPrinter.Enabled = true;
                cmbLabelPrinter.SelectedIndex = 0;
            }


        }


        public void fnGenerateLabelCB()
        {
            try
            {
                lobjQBConfiguration = new QBConfiguration();
                cmbLabelName.Items.Clear();
                cmbLabelName.Items.Add("Select Label");
                string Folderpath = "";
                //Folderpath = System.Configuration.ConfigurationManager.AppSettings("LabelPath").ToString()
                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                xmlDoc.Load(FileInfo.FullName);
                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;
                Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='LabelPath']/@value");
                if ((!object.ReferenceEquals(Node, "")))
                {
                    Folderpath = Node.InnerText;
                }

                if ((!string.IsNullOrEmpty(Folderpath)))
                {
                    if (!Directory.Exists(Folderpath))
                    {
                        MessageBox.Show("Please set the item label path", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbLabelName.SelectedIndex = 0;
                        return;
                    }

                    string[] filenames = Directory.GetFiles(Folderpath, "*.btw");
                    int i = 0;
                    string filename = null;
                    for (i = 0; i <= filenames.Length - 1; i++)
                    {
                        filename = Path.GetFileName(filenames[i]);
                        // This is much better than relying on substring to be accurate
                        cmbLabelName.Items.Add(filename);
                    }

                    //if (mstrLabelName != string.Empty)
                    //    cmbLabelName.SelectedItem = mstrLabelName;
                    //else
                    //    cmbLabelName.SelectedIndex = 0;

                    if (!string.IsNullOrEmpty(lobjQBConfiguration.GetLabelConfigSettings("LabelName")))
                    {
                        //cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("LabelName");
                        cmbLabelName.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbLabelName.SelectedIndex = 0;
                    }
                    clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                    string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath")));
                    if (template == "")
                    {
                        lblTempName.Text = "";
                    }
                    else
                    {
                        lblTempName.Text = Path.GetFileName(template);
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        public void fnGetUDFLabels()
        {

            try
            {
                lobjQBConfiguration = new QBConfiguration();
                string lstrUDFolderPath = string.Empty;
                lstrUDFolderPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\");
                cmbLabelName.Items.Clear();
                cmbLabelName.Items.Add("Select Label");

                if (Directory.Exists(lstrUDFolderPath))
                {
                    string[] filenames = Directory.GetFiles(lstrUDFolderPath, "*.pdf");
                    int i = 0;
                    string filename = null;
                    for (i = 0; i <= filenames.Length - 1; i++)
                    {
                        filename = Path.GetFileNameWithoutExtension(filenames[i].ToString());
                        // This is much better than relying on substring to be accurate
                        cmbLabelName.Items.Add(filename);
                    }

                    //if (mstrLabelName != string.Empty)
                    //    cmbLabelName.SelectedItem = mstrLabelName;
                    //else
                    cmbLabelName.SelectedIndex = 0;
                    lblTempName.Text = "";

                    //if (cmbLabelName.Items.Count > 1)
                    //{
                    //    lobjQBConfiguration.SaveLabelFilePathSettings(lstrUDFolderPath, "UdfLabelPath");

                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }

        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();
        }

        private void txtQuantitytoprint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar.Equals(Convert.ToChar(13))) { btnPrintItemDetail_Click(sender, e); }
        }

        private void FrmPrintbyItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();
        }

        private void rdoQtyPrint_CheckedChanged(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            //save qtytoprint in app.config
            lobjQBConfiguration.SaveLabelFilePathSettings("1", "PrintByItemQty");
        }

        private void rdoQtyOnHand_CheckedChanged(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            //save qtyonHand in app.config
            lobjQBConfiguration.SaveLabelFilePathSettings("0", "PrintByItemQty");
        }

        private void btngotoSyncItem_Click(object sender, EventArgs e)
        {
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmItemListSettingcs lobjItemSync = FrmItemListSettingcs.GetInstance();
            lobjItemSync.ShowDialog();
            AutoCompleteSarchText();
            txtItemName.Focus();
        }
        public string GetselectedtemplateOnApp(string filepath)
        {
            try
            {
                if(filepath=="")
                {
                    return "";
                }
                bool istemplateexist = false;
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                string targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\");
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);

                }
                if (File.Exists(targetDir + Path.GetFileName(filepath)))
                {
                    File.Delete(targetDir + Path.GetFileName(filepath));

                }
                File.Copy(filepath, Path.Combine(targetDir, Path.GetFileName(filepath)), true);
                filepath = targetDir + Path.GetFileName(filepath);
                lobjtemplatenames = new clsTemplateLabelXmlwork();
                var templatenodecount = lobjtemplatenames.CheckImportXmlFormat(Path.GetFileNameWithoutExtension(filepath));
                if (templatenodecount.Count != 4)
                {
                    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }

                printTempName = lobjtemplatenames.CreateTempFolder(Path.GetFileNameWithoutExtension(filepath));
                fnGetUDFLabels();
                cmbLabelName.SelectedItem = Path.GetFileNameWithoutExtension(filepath);

                if (printTempName.ToLower().ToString() != "Item list".ToLower())
                {
                    MessageBox.Show("You have selected an '" + printTempName + "' type label template. Please select a 'Item list'  type label template.", "Select Label", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
                return filepath;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                lblTempName.Text = "";
                string template = "";
                string templatepath = "";
                string selectedType = "";
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                selectedType = "itemSingtemppath";
                templatepath = string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemSingtemppath"));

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Browse xml Files";
                if (File.Exists(templatepath))
                {
                    openFileDialog1.InitialDirectory = templatepath.Replace(templatepath, Path.GetDirectoryName(templatepath));
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), selectedType);
                        template = GetselectedtemplateOnApp(openFileDialog1.FileName.ToString());
                        if (template == "")
                        {
                            lblTempName.Text = "";
                        }
                        else
                        {
                            lblTempName.Text = Path.GetFileName(template);
                        }
                        // UpdateFilePath(openFileDialog1.FileName.ToString());
                    }
                }

                else
                {

                    string Labelpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";

                    if (!Directory.Exists(Labelpath))
                        Directory.CreateDirectory(Labelpath);
                    openFileDialog1.InitialDirectory = Labelpath;
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), selectedType);
                        template = GetselectedtemplateOnApp(openFileDialog1.FileName.ToString());
                        if (template == "")
                        {
                            lblTempName.Text = "";
                        }
                        else
                        {
                            lblTempName.Text = Path.GetFileName(template);
                        }
                        // UpdateFilePath(openFileDialog1.FileName.ToString());
                    }

                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateFilePath(string filepath)
        {
            try
            {
                lblTempName.Text = "";
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                clsTemplateStatus tempstatus = new clsTemplateStatus();
                tempstatus.TemplatePath = Convert.ToString(filepath);
                tempstatus.TemplateSave = "0";
                tempstatus.TemplateMode = "Print";
                tempstatus.TemplateStatus = "0";
                tempstatus.TempTemplatePath = "";
                lobjTemplatexml.SaveTemplateStatus(tempstatus);
                bool result = GettemplateOnApp();
                if (!result)
                {
                    lobjTemplatexml.DeleteAppTemplate(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));
                    lobjTemplatexml.SaveTemplateStatus(tempstatus);
                    return;
                }
                lblTempName.Text = Path.GetFileName(filepath);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string printTempName = "";
        public bool GettemplateOnApp()
        {
            try
            {
                bool istemplateexist = false;
                clsTemplateStatus tempstatus = new clsTemplateStatus();
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                tempstatus = lobjtemplatenames.GetTemplateStatus();
                string targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\");
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);

                }
                if (File.Exists(targetDir + Path.GetFileName(tempstatus.TemplatePath)))
                {
                    File.Delete(targetDir + Path.GetFileName(tempstatus.TemplatePath));

                }
                File.Copy(tempstatus.TemplatePath, Path.Combine(targetDir, Path.GetFileName(tempstatus.TemplatePath)), true);
                tempstatus.TempTemplatePath = targetDir + Path.GetFileName(tempstatus.TemplatePath);
                lobjtemplatenames.SaveTemplateStatus(tempstatus);
                // lstrgettargetfile = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\" + openFileDialog1.FileName.ToString() + ".xml";
                lobjtemplatenames = new clsTemplateLabelXmlwork();
                var templatenodecount = lobjtemplatenames.CheckImportXmlFormat(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));
                //istemplateexist = lobjtemplatenames.IsTemplateFieldInXml(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));
                //if (!istemplateexist) //template name attr not exist
                //{
                //    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                if (templatenodecount.Count != 4)
                {
                    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                CreateTempFolder(Path.GetFileNameWithoutExtension(tempstatus.TemplatePath));
                fnGetUDFLabels();
                cmbLabelName.SelectedItem = Path.GetFileNameWithoutExtension(tempstatus.TemplatePath);
                string tempType = "";
                if (printTempName.ToLower().ToString() != "Item list".ToLower())
                {
                    MessageBox.Show("You have selected an '" + printTempName + "' type label template. Please select a 'Item List' type label template.", "Select Label", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void CreateTempFolder(string tempName)
        {
            try
            {
                string distranstype = String.Empty;
                string dispwidth = String.Empty;
                string dispheight = String.Empty;
                string strTransTypeFilePath = String.Empty;
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                List<QuickBooksField> objheaderfield = new List<QuickBooksField>();

                var headerfieldlist = lobjtemplatenames.GetTemplateHeaderInfo(tempName);

                foreach (QuickBooksField fields in headerfieldlist)
                {
                    if (fields.ItemFieldId == 1)
                    {
                        distranstype = fields.ItemFieldName;
                    }
                    else if (fields.ItemFieldId == 2)
                    {
                        dispwidth = fields.ItemFieldName;
                    }
                    else if (fields.ItemFieldId == 3)
                    {
                        dispheight = fields.ItemFieldName;
                    }

                }
                printTempName = distranstype;
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(tempName.ToString(), string.Empty);
                //Get property fields list
                List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                if (dirtransxml.Exists)
                {
                    strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + distranstype.ToString() + ".xml");
                }
                else
                {
                    strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + distranstype.ToString() + ".xml");
                }
                //strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text.ToString() + ".xml";
                if (File.Exists(strTransTypeFilePath))
                {
                    Itemfieldlist = lobjtemplatenames.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                }
                //create pdf from xml
                lobjtemplatenames.CreateUpdateTemplatePDF(tempName, dispwidth.ToString(), dispheight.ToString(), dispheight.ToString(), string.Empty, objfieldlist, Itemfieldlist);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemsalesDescription = (from clsItemBin item in listBin//lobjItemslist
                                        where item.SiteBinRefID == ((LabelConnector.FrmPrintbyItem.ComboboxItem)cboBin.SelectedItem).Value.ToString()
                                        select item).FirstOrDefault();
            txtQtyOnHand.Text = itemsalesDescription.QtyOnHand.ToString();
        }
    }
}
