using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using LabelConnector;
using LabelConnector.net.wxbug.api;
using System.Drawing.Printing;
using QBLC;
using System.Collections;
using System.Xml;
using System.Diagnostics;

namespace LabelConnector
{
    public partial class FrmPrintWeatherOnlyTouchScreen : Form
    {
        LabelConnector.net.wxbug.api.WeatherBugWebServices mobjServices = null;

        ArrayList alData = null; //for printing shipaddress
        int lblfile1 = 0;
        clsDBWork objDBWork;
        double dblInvoiceToQuantity = 0;
        clsPurchaseOrder objPurchaseOrder;
        clsSalesOrder objSalesOrder;
        clsInvoice objInvoice;
        clsPurchaseOrderLine objPurchaseOrderLine;
        clsSalesOrderLine objSalesOrderLine;
        clsInvoiceLine objInvoiceLine;
        frmLabelConfig objfrmLabel = frmLabelConfig.GetInstance();
        Dictionary<string, string> lobjDataExtension;
        private Font verdana10Font;
        private StreamReader reader;
        bool flag = false;
        string FileToCopy = "";
        string NewCopy = "";
        string FilePath = "";
        string lstrFileName = string.Empty;
        ArrayList objlastscanItem = new ArrayList();
        string mstrLabelName = string.Empty;
        //for custom field label value check
        string lstrFilterDisplay = string.Empty;
        string lstrTxnLineId = string.Empty;
        private int cellindex = 0;

        QBConfiguration lobjQBConfiguration;
        string lstrQBFileMode = string.Empty;

        int intGridRowCount1 = 0;
        int intGridRowCount2 = 0;

        string lblStoreNameValue = string.Empty;
        string lblInvoiceNumberValue = string.Empty;
        string lblLowTempValue = string.Empty;
        string lblHighTempValue = string.Empty;
        int lstrWeatherOnlyOption = 0;
        public int WeatherOnlyOption
        {
            get { return lstrWeatherOnlyOption; }
            set { lstrWeatherOnlyOption = value; }

        }

        public FrmPrintWeatherOnlyTouchScreen()
        {
            InitializeComponent();
        }
        [DllImport("Winspool.drv")]
        private static extern bool SetDefaultPrinter(string printerName);

        Interop.QBFC13.IQBSessionManager lQBSessionManager = default(Interop.QBFC13.IQBSessionManager);
        LabelConnector.QuickBooksAccount moQuickBooksAccountConfig = null;
        LabelConnector.Serializer loSerializer = new LabelConnector.Serializer();

        private void FrmPrintWeatherOnlyTouchScreen_Load(object sender, EventArgs e)
        {
            txtOrderNumber.Focus();
            lobjQBConfiguration = new QBConfiguration();
            lstrFilterDisplay = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FilterDisplay");


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
            InitDataGrid();
            //fnGenerateLabelCB();
            AddPrinters();
            // btnfilterlabel.Visible = false;
            lblOrderNo.Text = "";
            if (WeatherOnlyOption == 1)
            {
                lblOrderNo.Text = "Scan Invoice No :";
            }
            else if (WeatherOnlyOption == 2)
            {
                lblOrderNo.Text = "Scan SO No :";
               
            }


        }


        private ArrayList GetDataSource()
        {
            string strCriteria = "";
            ArrayList alData = null;
            lobjQBConfiguration = new QBConfiguration();
            lstrQBFileMode = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode");
            try
            {
                if (txtOrderNumber.Text.Trim() != "")
                {
                    strCriteria = txtOrderNumber.Text.Trim();
                }
                else
                {
                    strCriteria = "1=1";
                }

                if (WeatherOnlyOption == 2)
                {
                    objSalesOrder = new clsSalesOrder();
                    if (lstrQBFileMode == "Close")
                    {
                        alData = objSalesOrder.GetSOList(strCriteria, lQBSessionManager, moQuickBooksAccountConfig);
                    }
                    else
                    {
                        alData = objSalesOrder.GetSOList(strCriteria);
                    }
                }
                else if (WeatherOnlyOption == 1)
                {

                    objInvoice = new clsInvoice();
                    if (lstrQBFileMode == "Close")
                    {
                        alData = objInvoice.GetInvoiceList(strCriteria, lQBSessionManager, moQuickBooksAccountConfig);
                    }
                    else
                    {
                        alData = objInvoice.GetInvoiceList(strCriteria);
                    }
                }

                return alData;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                throw;
                return null;
            }
            finally
            {

            }
        }

        private void InitDataGrid()
        {

            DataGVOrders.Columns.Clear();

            if (WeatherOnlyOption == 1)
            {
            DataGVOrders.Columns.Add("TxnDate", "Invoice Created Date");
            DataGVOrders.Columns["TxnDate"].Width = 200;
            DataGVOrders.Columns.Add("RefNumber", "Invoice Number");
            DataGVOrders.Columns["RefNumber"].Width = 170;
            DataGVOrders.Columns.Add("ShipAddressAddr1", "Ship Address");
            DataGVOrders.Columns["ShipAddressAddr1"].Width = 280;
            }

            else if (WeatherOnlyOption == 2)
            {
                DataGVOrders.Columns.Add("TxnDate", "Sales Order Created Date");
                DataGVOrders.Columns["TxnDate"].Width = 200;
                DataGVOrders.Columns.Add("RefNumber", "SO Number");
                DataGVOrders.Columns["RefNumber"].Width = 170;
                DataGVOrders.Columns.Add("ShipAddressAddr1", "Ship Address");
                DataGVOrders.Columns["ShipAddressAddr1"].Width = 280;
            
            }




        }

        private void FillOrderGrid(ArrayList alOrder)
        {
            DataGVOrders.Rows.Clear();
            int i = 0;
            if (WeatherOnlyOption == 1)
            {
                foreach (clsInvoice objInvoice in alOrder)
                {
                    DataGVOrders.Rows.Add();
                    DataGVOrders.Rows[i].Cells[0].Value = objInvoice.TxnDate.ToShortDateString();
                    DataGVOrders.Rows[i].Cells[1].Value = objInvoice.RefNumber;
                    DataGVOrders.Rows[i].Cells[2].Value = FormatShipAddress(objInvoice);
                    i++;
                }
            }

            else if (WeatherOnlyOption == 2)
            {

                foreach (clsSalesOrder objSalesOrder in alOrder)
                {
                    DataGVOrders.Rows.Add();
                    DataGVOrders.Rows[i].Cells[0].Value = objSalesOrder.TxnDate.ToShortDateString();
                    DataGVOrders.Rows[i].Cells[1].Value = objSalesOrder.RefNumber;
                    DataGVOrders.Rows[i].Cells[2].Value = FormatShipAddressforSalesOrder(objSalesOrder);
                    i++;
                }

            }

        }

        private string FormatShipAddress(clsInvoice objInvoice)
        {
            StringBuilder lstrbuilder = new StringBuilder();



            if (objInvoice.ShipAddressAddr1 != null)
            {
                lstrbuilder.Append(objInvoice.ShipAddressAddr1);
                lstrbuilder.Append(",");
            }
            //if (objInvoice.ShipAddressAddr2 != null)
            //{
            //    lstrbuilder.Append(objInvoice.ShipAddressAddr2);
            //    lstrbuilder.Append(",");
            //}
            //if (objInvoice.ShipAddressAddr3 != null)
            //{
            //    lstrbuilder.Append(objInvoice.ShipAddressAddr3);
            //    lstrbuilder.Append(",");
            //}
            //if (objInvoice.ShipAddressAddr4 != null)
            //{
            //    lstrbuilder.Append(objInvoice.ShipAddressAddr4);
            //    lstrbuilder.Append(",");
            //}
            //if (objInvoice.ShipAddressAddr5 != null)
            //{
            //    lstrbuilder.Append(objInvoice.ShipAddressAddr5);
            //    lstrbuilder.Append(",");
            //}

            if (objInvoice.ShipAddressCity != null)
            {
                lstrbuilder.Append(objInvoice.ShipAddressCity);
                lstrbuilder.Append(",");
            }

            if (objInvoice.ShipAddressState != null)
            {
                lstrbuilder.Append(objInvoice.ShipAddressState);
                lstrbuilder.Append(",");
            }

            if (objInvoice.ShipAddressPostalCode != null)
            {
                lstrbuilder.Append(objInvoice.ShipAddressPostalCode);
                lstrbuilder.Append(",");
            }


            return lstrbuilder.ToString();

        }

        private string FormatShipAddressforSalesOrder(clsSalesOrder objSalesOrder)
        {
            StringBuilder lstrbuilder = new StringBuilder();

            if (objSalesOrder.ShipAddressAddr1 != null)
            {
                lstrbuilder.Append(objSalesOrder.ShipAddressAddr1);
                lstrbuilder.Append(",");
            }

            if (objSalesOrder.ShipAddressCity != null)
            {
                lstrbuilder.Append(objSalesOrder.ShipAddressCity);
                lstrbuilder.Append(",");
            }

            if (objSalesOrder.ShipAddressState != null)
            {
                lstrbuilder.Append(objSalesOrder.ShipAddressState);
                lstrbuilder.Append(",");
            }

            if (objSalesOrder.ShipAddressPostalCode != null)
            {
                lstrbuilder.Append(objSalesOrder.ShipAddressPostalCode);
                lstrbuilder.Append(",");
            }


            return lstrbuilder.ToString();

        }


        private void PrintWeatherInfo(string lstrStoreNameValue, string lstrInvoiceNumberValue, string lstrLowTempValue, string lstrHighTempValue)
        {
            string lstrPrintername = string.Empty;
            lobjQBConfiguration = new QBConfiguration();
            //lstrPrintername = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("WeatherLabelPrinterName");


            if (cmbLabelPrinter.SelectedIndex > 0)
            {
                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Printing Started...");

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

                string strProdPrinter = "";
                string strWeatherLabel = "";

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
                        if (Node.Attributes.GetNamedItem("key").Value == "WeatherLabelPath")
                        {
                            strWeatherLabel = Node.Attributes.GetNamedItem("value").Value;
                        }
                    }
                }
                strProdPrinter = cmbLabelPrinter.Text;
                //save printer path
                lobjQBConfiguration.SaveLabelFilePathSettings(strProdPrinter, "WeatherLabelPrinterName");
                int intQuantity = 0;
                string lstrPropertyValue = string.Empty;
                string QuantityToPrintOnLabel = string.Empty;

                BtApp = new BarTender.ApplicationClass();
                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Batrender Object is Created...");
                BtFormat = new BarTender.Format();
                // ----------- Code Start Printing Weather Label -----------------


                int k = 1;
                BtFormat = BtApp.Formats.Open(strWeatherLabel, true, strProdPrinter);
                while (k <= BtFormat.NamedSubStrings.Count)
                {
                    BtSubString = BtFormat.NamedSubStrings.GetSubString(k);

                    if (BtSubString.Name == "ShipAddressAddr1") btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrStoreNameValue + '\r' + '\n';
                    if (BtSubString.Name == "RefNumber") btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrInvoiceNumberValue + '\r' + '\n';
                    if (BtSubString.Name == "LowTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrLowTempValue + '\r' + '\n';
                    if (BtSubString.Name == "HighTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrHighTempValue + '\r' + '\n';
                    k++;
                }
                if (btNamedSubString != string.Empty)
                {
                    string strDelimiter = string.Concat('\r', '\n');
                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " String to be Printed:-" + btNamedSubString);
                    BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);
                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " No Of copies to be printed:-" + intQuantity.ToString());
                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Printer Name:-" + strProdPrinter.ToString());
                    BtFormat.IdenticalCopiesOfLabel = 1;//Convert.ToInt32(intQuantity);
                    BtFormat.PrintOut(false, false);
                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Substring values are send to Bartender for printing...");
                }


                btNamedSubString = "";
                BtFormat.Close();
                BtApp.Quit();
                txtOrderNumber.Text = "";
                txtOrderNumber.Focus();

                //------------Code End for Printing Weather Label---------------

            }

            else
            {
                MessageBox.Show("Select Printer to Print the label", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void AddPrinters()
        {
            lobjQBConfiguration = new QBConfiguration();
            string lstrPrintername = string.Empty;
            cmbLabelPrinter.Items.Add("Select Printer");

            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbLabelPrinter.Items.Add(strPrinter);
            }
            PrintDocument lobjDocument = new PrintDocument();

            lstrPrintername = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("WeatherLabelPrinterName");
            if (!string.IsNullOrEmpty(lstrPrintername))
                cmbLabelPrinter.SelectedItem = lstrPrintername;
            else
                //cmbLabelPrinter.SelectedItem = lobjDocument.PrinterSettings.PrinterName;
                cmbLabelPrinter.SelectedIndex = 0;
        }

        //commented on 30-oct-2017 to run solutions as Debug mode
        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {



            //try
            //{
            //    // fnGenerateLabelCB();
            //    if (e.KeyChar.Equals(Convert.ToChar(13)))
            //        if (txtOrderNumber.Text != "")
            //        {

            //            this.Cursor = Cursors.WaitCursor;
            //            if (cmbLabelPrinter.SelectedIndex > 0)
            //            {
            //                alData = GetDataSource();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Select Printer to Print the label", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //            if (WeatherOnlyOption == 1)
            //            {
            //                if (alData != null && alData.Count > 0)
            //                {

            //                    string strSaipaddPC = "";
            //                    foreach (clsInvoice objInvoice in alData)
            //                    {
            //                        if (objInvoice != null)
            //                        {
            //                            FillOrderGrid(alData);

            //                            //--------Code start to get weather information----------------
            //                            try
            //                            {
            //                                if (objInvoice.ShipAddressPostalCode != null)
            //                                {

            //                                    if (objInvoice.ShipAddressPostalCode.Length > 5)
            //                                    {
            //                                        strSaipaddPC = objInvoice.ShipAddressPostalCode.Remove(5).ToString();
            //                                    }
            //                                    else
            //                                    {
            //                                        strSaipaddPC = objInvoice.ShipAddressPostalCode.ToString();
            //                                    }

            //                                    //mobjServices = new WeatherBugWebServices();
            //                                    //ApiForecastData[] lobjData = mobjServices.GetForecastByUSZipCode(strSaipaddPC, UnitType.English, "A5574994714");
            //                                    //ApiForecastIssueData lobjForecastData = mobjServices.GetForecastIssueDetailsByUSZipCode(strSaipaddPC, "A5574994714");
            //                                    //DataTable ldtData = new DataTable("WeatherInformation");
            //                                    if (objInvoice.ShipAddressAddr1 != null) lblStoreNameValue = objInvoice.ShipAddressAddr1.ToString();
            //                                    if (objInvoice.RefNumber != null) lblInvoiceNumberValue = objInvoice.RefNumber.ToString();
            //                                    //lblLowTempValue = lobjData[0].TempLow.ToString();
            //                                    //lblHighTempValue = lobjData[1].TempHigh.ToString();
            //                                    string clientID = string.Empty;
            //                                    string consumerSecret = string.Empty;
            //                                    GetCustomerConsumerDetails.GetConsumerDetails(ref clientID, ref consumerSecret);
            //                                    QBLCWeatherService.QBLCService qCl = new QBLCWeatherService.QBLCService();
            //                                    Dictionary<string, string> arr = qCl.GetData(strSaipaddPC, clientID, consumerSecret);
            //                                    lblLowTempValue = Convert.ToString(arr["minTemp"]);
            //                                    lblHighTempValue = Convert.ToString(arr["maxTemp"]);

            //                                    //printing logic
            //                                    PrintWeatherInfo(lblStoreNameValue, lblInvoiceNumberValue, lblLowTempValue, lblHighTempValue);

            //                                }
            //                                else
            //                                {
            //                                    MessageBox.Show("No ZIP code for Order No. : " + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                                }
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                MessageBox.Show("Weather information not found for Zip Code : " + objInvoice.ShipAddressPostalCode.ToString(), "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                            }

            //                            //--------Code End to get weather information----------------


            //                        }
            //                        else
            //                        {
            //                            MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                    }




            //                }
            //            }
            //            else if (WeatherOnlyOption == 2)
            //            {
                            
            //                if (alData != null && alData.Count > 0)
            //                {

            //                    string strSaipaddPC = "";
            //                    foreach (clsSalesOrder objSalesOrder in alData)
            //                    {
            //                        if (objSalesOrder != null)
            //                        {

            //                            FillOrderGrid(alData);

            //                            //--------Code start to get weather information----------------
            //                            try
            //                            {
            //                                if (objSalesOrder.ShipAddressPostalCode != null)
            //                                {

            //                                    if (objSalesOrder.ShipAddressPostalCode.Length > 5)
            //                                    {
            //                                        strSaipaddPC = objSalesOrder.ShipAddressPostalCode.Remove(5).ToString();
            //                                    }
            //                                    else
            //                                    {
            //                                        strSaipaddPC = objSalesOrder.ShipAddressPostalCode.ToString();
            //                                    }


            //                                    if (objSalesOrder.ShipAddressAddr1 != null) lblStoreNameValue = objSalesOrder.ShipAddressAddr1.ToString();
            //                                    if (objSalesOrder.RefNumber != null) lblInvoiceNumberValue = objSalesOrder.RefNumber.ToString();


            //                                    string clientID = string.Empty;
            //                                    string consumerSecret = string.Empty;
            //                                    GetCustomerConsumerDetails.GetConsumerDetails(ref clientID, ref consumerSecret);
            //                                    QBLCWeatherService.QBLCService qCl = new QBLCWeatherService.QBLCService();
            //                                    Dictionary<string, string> arr = qCl.GetData(strSaipaddPC, clientID, consumerSecret);
            //                                    lblLowTempValue = Convert.ToString(arr["minTemp"]);
            //                                    lblHighTempValue = Convert.ToString(arr["maxTemp"]);

            //                                    //printing logic
            //                                    PrintWeatherInfo(lblStoreNameValue, lblInvoiceNumberValue, lblLowTempValue, lblHighTempValue);

            //                                }
            //                                else
            //                                {
            //                                    MessageBox.Show("No ZIP code for Order No. : " + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                                }
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                MessageBox.Show("Weather information not found for Zip Code : " + objInvoice.ShipAddressPostalCode.ToString(), "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                            }

            //                            //--------Code End to get weather information----------------


            //                        }
            //                        else
            //                        {
            //                            MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                    }




            //                }
                        
            //            }

            //            else
            //            {
            //                MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                txtOrderNumber.Focus();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please enter Order No.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtOrderNumber.Focus();
            //        }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Label Connector");
            //    DataGVOrders.Rows.Clear();

            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}

        }

        private void cmbLabelPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrderNumber.Focus();
        }

        private void FrmPrintWeatherOnlyTouchScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrintLabelTuchScreen parentForm = (frmPrintLabelTuchScreen)this.MdiParent;
            parentForm.GridPanel = true;
            this.Hide();
            this.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            frmPrintLabelTuchScreen parentForm = (frmPrintLabelTuchScreen)this.MdiParent;
            parentForm.GridPanel = true;
            this.Hide();
            this.Close();
        }
    }
}
