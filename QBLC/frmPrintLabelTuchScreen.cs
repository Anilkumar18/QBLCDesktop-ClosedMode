using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QBLC;
using System.Collections;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Data.Odbc;
using System.Xml;
using System.Reflection;
using BarTender;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using LabelConnector.net.wxbug.api;

namespace LabelConnector
{
    public partial class frmPrintLabelTuchScreen : Form
    {

        LabelConnector.net.wxbug.api.WeatherBugWebServices mobjServices = null;

        public bool GridPanel
        {
            set { this.pnlhead.Visible = value; }
            get { return this.pnlhead.Visible; }
        }

        public frmPrintLabelTuchScreen(bool trial) // Added "bool trial" by srinivas on 27-Nov-2017
        {
            InitializeComponent();
            objfrmLabel.objdelLabel += new delLabel(this.fnGenerateLabelCB);
            this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;
        }
        ArrayList alData = null; //for printing shipaddress
        ArrayList arrtxnnolist = new ArrayList();
        int lblfile1 = 0;
        clsDBWork objDBWork;
        double dblInvoiceToQuantity = 0;
        clsPurchaseOrder objPurchaseOrder;
        clsSalesOrder objSalesOrder;
        clsInvoice objInvoice;
        clsPurchaseOrderLine objPurchaseOrderLine;
        clsSalesOrderLine objSalesOrderLine;
        clsInvoiceLine objInvoiceLine;
        frmLabelConfigTuchScreen objfrmLabel = frmLabelConfigTuchScreen.GetInstance();
        Dictionary<string, string> lobjDataExtension;
        private Font verdana10Font;
        private StreamReader reader;
        bool flag = false;
        string FileToCopy = "";
        string NewCopy = "";
        string FilePath = "";
        ArrayList objlastscanItem = new ArrayList();
        string lstrFileName = string.Empty;
        ArrayList alInvoiceLineItems = new ArrayList();
        string InvoiceCustomerName = "";
        int intGridRowCount1 = 0;
        int intGridRowCount2 = 0;


        private bool flCloseConfirm = true;

        Interop.QBFC13.IQBSessionManager lQBSessionManager = default(Interop.QBFC13.IQBSessionManager);
        LabelConnector.QuickBooksAccount moQuickBooksAccountConfig = null;
        LabelConnector.Serializer loSerializer = new LabelConnector.Serializer();
        string mstrLabelName = string.Empty;

        //for custom field label value check
        string lstrFilterDisplay = string.Empty;
        string lstrTxnLineId = string.Empty;
        private int cellindex = 0;

        QBConfiguration lobjQBConfiguration;
        string lstrQBFileMode = string.Empty;

        public void SetConfirm(bool confirm)
        {
            flCloseConfirm = confirm;
        }

        public void SetTextLicenseMenuItem(bool trial)
        {
            if (trial)
            {
                activToolStripMenuItem.Text = "Activate";
            }
            else
            {
                activToolStripMenuItem.Text = "Activated";
            }
        }


        [DllImport("Winspool.drv")]
        private static extern bool SetDefaultPrinter(string printerName);

        private void frmPrintLabel_Load(object sender, EventArgs e)
        {
           
            toolStripMenuItem1.Visible = false;
            foreach (Control ctl in this.Controls)
            {
                try
                {

                    MdiClient client = ctl as MdiClient;
                    if (!(client == null))
                    {
                        client.BackColor = this.BackColor;
                        break;
                    }

                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
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
            fnGenerateLabelCB();
            AddPrinters();
            btnfilterlabel.Visible = true;
            //if (lstrFilterDisplay != "")
            //{
            //    MessageBox.Show("FilterValue : " + lstrFilterDisplay, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("FilterValue is Blank. Please set the Filter value", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            grpWeartherInfo.Visible = false;
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
        }
        private ArrayList GetDataSource()
        {
            string strCriteria="";
            ArrayList alData=null;
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

                if (rdbPO.Checked == true)
                {
                    objPurchaseOrder = new clsPurchaseOrder();
                    if (lstrQBFileMode == "Close")
                    {
                        //alData = objPurchaseOrder.GetPOList(strCriteria, lQBSessionManager, moQuickBooksAccountConfig);
                    }
                    else
                    {
                        alData = objPurchaseOrder.GetPOList(strCriteria);
                    }
                }
                else if (rdbSO.Checked == true)
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
                else
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
        
        private void DataGVOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex !=-1)
            {
                if (Convert.ToString(DataGVOrders.CurrentRow.Cells[0].Value) == "")
                {
                    DataGVItems.DataSource = null;
                    gbOrderDetail.Visible = false;
                }
                else
                {
                    if (rdbPO.Checked == true)
                    {
                        objPurchaseOrderLine = new clsPurchaseOrderLine();
                        if (lstrQBFileMode == "Close")
                        {
                            ArrayList alPOLineItems = objPurchaseOrderLine.GetPOLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value), lQBSessionManager, moQuickBooksAccountConfig);
                            FillItemsGrid(alPOLineItems);
                        }
                        else
                        {
                            ArrayList alPOLineItems = objPurchaseOrderLine.GetPOLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value));
                            FillItemsGrid(alPOLineItems);
                        }

                        gbOrderDetail.Visible = true;
                    }
                    else if (rdbSO.Checked == true)
                    {
                        objSalesOrderLine = new clsSalesOrderLine();
                        if (lstrQBFileMode == "Close")
                        {
                            ArrayList alSOLineItems = objSalesOrderLine.GetSOLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value), lQBSessionManager, moQuickBooksAccountConfig);
                            FillItemsGrid(alSOLineItems);
                        }
                        else
                        {
                            ArrayList alSOLineItems = objSalesOrderLine.GetSOLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value),string.Empty);
                            FillItemsGrid(alSOLineItems);
                        }

                        gbOrderDetail.Visible = true;

                    }
                    else if (rdbInvoice.Checked == true)
                    {
                        objInvoiceLine = new clsInvoiceLine();
                        if (lstrQBFileMode == "Close")
                        {
                            ArrayList alINVLineItems = objInvoiceLine.GetINVLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value), lQBSessionManager, moQuickBooksAccountConfig);
                            FillItemsGrid(alINVLineItems);
                        }
                        else
                        {
                            ArrayList alINVLineItems = objInvoiceLine.GetINVLine(Convert.ToString(DataGVOrders.CurrentRow.Cells[1].Value),string.Empty,string.Empty);
                            FillItemsGrid(alINVLineItems);
                        }

                        gbOrderDetail.Visible = true;
                    }
                }
            }
        }

        private void rdbPO_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbB.Checked = true;
            rdbC.Enabled = false;
        }
        
        private void Clear()
        {
            try
            {
                grpWeartherInfo.Visible = false;
                DataGVOrders.Rows.Clear();
                DataGVItems.Rows.Clear();
                InitDataGrid();
                gbOrderDetail.Visible = false;
                //below line to make groupbox visible false
                gbInvoiceDetail.Visible = false;
                // txtOrderNumber.Text = ""; //commented to not clear textbox
                if (cmbLabelName.Items.Count > 1)
                {
                    mstrLabelName = cmbLabelName.SelectedItem.ToString();
                    cmbLabelName.Items.Clear();
                }
                txtOrderNumber.Focus();
                lblfile1 = 0;
                if (rdbPO.Checked == true || rdbInvoice.Checked == true)
                    rdbd.Enabled = false;
                else
                    rdbd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbSO_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbC.Enabled = false;
            rdbB.Checked = true;
        }

        private void btnGetOrder_Click(object sender, EventArgs e)
        {
            try
            {
                fnGenerateLabelCB();
                if (txtOrderNumber.Text != "")
                {
                    DataGVItems.ForeColor = Color.Black;//change grid fore color
                    DataGVItems.ReadOnly = true;//make items grid readonly
                    //if (chkSelectAll.Enabled == false) { chkSelectAll.Enabled = true; }
                    InvoiceCustomerName = "";
                    this.Cursor = Cursors.WaitCursor;
                    //To add shipAddress
                    //ArrayList  alData = GetDataSource();
                    alData = GetDataSource();
                    if (alData!=null && alData.Count > 0)
                    {
                        if (rdbPO.Checked == true)
                        {
                            foreach (clsPurchaseOrder objPurchaseOrder in alData)
                            {
                                if (objPurchaseOrder != null)
                                {
                                    FillOrderGrid(alData);

                                    objPurchaseOrderLine = new clsPurchaseOrderLine();
                                    if (lstrQBFileMode == "Close")
                                    {
                                        ArrayList alPOLineItems = objPurchaseOrderLine.GetPOLine(objPurchaseOrder.RefNumber, lQBSessionManager, moQuickBooksAccountConfig);
                                        FillItemsGrid(alPOLineItems);
                                    }
                                    else
                                    {
                                        ArrayList alPOLineItems = objPurchaseOrderLine.GetPOLine(objPurchaseOrder.RefNumber);
                                        FillItemsGrid(alPOLineItems);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else if (rdbSO.Checked == true)
                        {
                            string strshippostcode = string.Empty;
                            lobjDataExtension = null;
                            foreach (clsSalesOrder objSalesOrder in alData)
                            {
                                if (objSalesOrder != null)
                                {
                                    FillOrderGrid(alData);

                                   
                                    //Date:11/11/2014 --------Code start to get weather information----------------test
                                    //code commented for weather label Date 01/13/2015
                                    // if (ckbWeatherLabel.Checked == false) ckbWeatherLabel.Checked = true;
                                    //try
                                    //{
                                    //    if (objSalesOrder.ShipAddressPostalCode != null)
                                    //    {

                                    //        if (objSalesOrder.ShipAddressPostalCode.Length > 5)
                                    //        {
                                    //            strshippostcode = objSalesOrder.ShipAddressPostalCode.Remove(5).ToString();
                                    //        }
                                    //        else
                                    //        {
                                    //            strshippostcode = objSalesOrder.ShipAddressPostalCode.ToString();
                                    //        }


                                    //        if (objSalesOrder.ShipAddressAddr1 != null)
                                    //        {
                                    //            lblStoreNameValue.Text = objSalesOrder.ShipAddressAddr1.ToString();
                                    //            //lblStoreName.Text = "Customer Name :";
                                    //        }
                                    //        if (objSalesOrder.RefNumber != null)
                                    //        {
                                    //            lblInvoiceNumberValue.Text = objSalesOrder.RefNumber.ToString();
                                    //            lblInvoiceNumber.Text = "SO Number :".PadLeft(18);
                                    //        }


                                    //        string clientID = string.Empty;
                                    //        string consumerSecret = string.Empty;
                                    //        GetCustomerConsumerDetails.GetConsumerDetails(ref clientID, ref consumerSecret);
                                    //        QBLCWeatherService.QBLCService qCl = new QBLCWeatherService.QBLCService();
                                    //        Dictionary<string, string> arr = qCl.GetData(strshippostcode, clientID, consumerSecret);

                                    //        lblLowTempValue.Text = Convert.ToString(arr["minTemp"]);
                                    //        lblHighTempValue.Text = Convert.ToString(arr["maxTemp"]);

                                    //        grpWeartherInfo.Visible = true;
                                    //    }

                                    //    else
                                    //    {
                                    //        MessageBox.Show("No ZIP code for Order No. : " + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //        grpWeartherInfo.Visible = false;
                                    //        lblLowTempValue.Text = "";
                                    //        lblHighTempValue.Text = "";
                                    //    }

                                    //}
                                    //catch (Exception ex)
                                    //{

                                    //    MessageBox.Show(ex.Message);
                                    //    MessageBox.Show("Weather information not found for Zip Code : " + objSalesOrder.ShipAddressPostalCode.ToString(), "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //    grpWeartherInfo.Visible = false;
                                    //    lblLowTempValue.Text = "";
                                    //    lblHighTempValue.Text = "";
                                    //}


                                    //--------Code End to get weather information----------------




                                    objSalesOrderLine = new clsSalesOrderLine();
                                    if (lstrQBFileMode == "Close")
                                    {
                                        ArrayList alSOLineItems = objSalesOrderLine.GetSOLine(objSalesOrder.RefNumber, lQBSessionManager, moQuickBooksAccountConfig);
                                        FillItemsGrid(alSOLineItems);
                                    }
                                    else
                                    {
                                        ArrayList alSOLineItems = objSalesOrderLine.GetSOLine(objSalesOrder.RefNumber,string.Empty);
                                        FillItemsGrid(alSOLineItems);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            lblInvoiceNumber.Text = "Invoice Number :".PadLeft(15);
                           // string strSaipaddPC = "";
                            foreach (clsInvoice objInvoice in alData)
                            {
                                if (objInvoice != null)
                                {
                                    FillOrderGrid(alData);
                                    //code commented for weather label Date :01/13/2015
                                    //if (ckbWeatherLabel.Checked == false) ckbWeatherLabel.Checked = true;
                                    //try
                                    //{
                                    //    //--------Code start to get weather information----------------
                                    //    if (objInvoice.ShipAddressPostalCode != null)
                                    //    {
                                    //        if (objInvoice.ShipAddressPostalCode.Length > 5)
                                    //        {
                                    //            strSaipaddPC = objInvoice.ShipAddressPostalCode.Remove(5).ToString();
                                    //        }
                                    //        else
                                    //        {
                                    //            strSaipaddPC = objInvoice.ShipAddressPostalCode.ToString();
                                    //        }

                                            
                                    //        //mobjServices = new WeatherBugWebServices();
                                    //        //ApiForecastData[] lobjData = mobjServices.GetForecastByUSZipCode(strSaipaddPC, UnitType.English, "A5574994714");
                                    //        //ApiForecastIssueData lobjForecastData = mobjServices.GetForecastIssueDetailsByUSZipCode(strSaipaddPC, "A5574994714");
                                    //        //DataTable ldtData = new DataTable("WeatherInformation");
                                    //        if (objInvoice.ShipAddressAddr1 != null) lblStoreNameValue.Text = objInvoice.ShipAddressAddr1.ToString();
                                    //        if (objInvoice.RefNumber != null) lblInvoiceNumberValue.Text = objInvoice.RefNumber.ToString();
                                    //        //lblLowTempValue.Text = lobjData[0].TempLow.ToString();
                                    //        //lblHighTempValue.Text = lobjData[1].TempHigh.ToString();

                                    //        string clientID = string.Empty;
                                    //        string consumerSecret = string.Empty;
                                    //        GetCustomerConsumerDetails.GetConsumerDetails(ref clientID, ref consumerSecret);
                                    //        QBLCWeatherService.QBLCService qCl = new QBLCWeatherService.QBLCService();
                                    //        Dictionary<string, string> arr = qCl.GetData(strSaipaddPC, clientID, consumerSecret);
                                    //        lblLowTempValue.Text = Convert.ToString(arr["minTemp"]);
                                    //        lblHighTempValue.Text = Convert.ToString(arr["maxTemp"]);

                                    //        grpWeartherInfo.Visible = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        MessageBox.Show("No ZIP code for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //        grpWeartherInfo.Visible = false;
                                    //        lblLowTempValue.Text = "";
                                    //        lblHighTempValue.Text = "";
                                    //    }
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    MessageBox.Show("Weather information not found for Zip Code : " + objInvoice.ShipAddressPostalCode.ToString(), "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //    grpWeartherInfo.Visible = false;
                                    //    lblLowTempValue.Text = "";
                                    //    lblHighTempValue.Text = "";
                                    //}
                                    //--------Code End to get weather information----------------


                                    objInvoiceLine = new clsInvoiceLine();
                                    if (lstrQBFileMode == "Close")
                                    {
                                         alInvoiceLineItems = objInvoiceLine.GetINVLine(objInvoice.RefNumber, lQBSessionManager, moQuickBooksAccountConfig);
                                        FillItemsGrid(alInvoiceLineItems);
                                    }
                                    else
                                    {
                                         alInvoiceLineItems = objInvoiceLine.GetINVLine(objInvoice.RefNumber,string.Empty,string.Empty);
                                        FillItemsGrid(alInvoiceLineItems);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                        ////gbOrderDetail.Visible = true;//commented by khushal
                        //below function to show and hide groupbox
                         ShowhideControls();
                        //below rdbd checkbox condtion added
                         if (rdbC.Checked == true || rdbd.Checked == true || rdbA.Checked==true)
                        {
                            if (DataGVItems.Rows.Count > 0)
                            {
                                DataGVItems.Rows[0].Selected = true;

                                if (rdbA.Checked == true)
                                {
                                    txtQtyOnLabel.Enabled = false;
                                    txtQtyToPrint.Enabled = false;
                                    txtQtyOnLabel.Visible = false;
                                    txtQtyToPrint.Visible = false;
                                    lblQtyOnLabel.Visible = false;
                                    lblQtyToPrint.Visible = false;
                                    chkSelectAll.Checked = true;
                                }
                                else
                                {
                                    txtQtyOnLabel.Enabled = false;
                                    txtQtyToPrint.Enabled = true;

                                    txtQtyOnLabel.Visible = false;
                                    txtQtyToPrint.Visible = true;
                                    lblQtyOnLabel.Visible = false;
                                    lblQtyToPrint.Visible = true;
                                    chkSelectAll.Checked = false;
                                    grpWeartherInfo.Visible = false;
                                }
                                if (rdbd.Checked == true) { txtcurrentscanitem.Focus(); }
                                chkSelectAll_Click(null, null);
                            }
                        }
                        else
                        {
                            if (DataGVItems.Rows.Count > 0)
                            {
                                DataGVItems.Rows[0].Selected = true;
                                txtQtyToPrint.Text = DataGVItems.Rows[0].Cells[0].Value.ToString(); //Srinivas changes on 26-Feb-2015 
                                txtQtyOnLabel.Text = DataGVItems.Rows[0].Cells[0].Value.ToString();
                                txtQtyOnLabel.Visible = true;
                                txtQtyToPrint.Visible = true;
                                txtQtyOnLabel.Enabled = true;
                                txtQtyToPrint.Enabled = true;
                                lblQtyOnLabel.Visible = true;
                                lblQtyToPrint.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found for Order No. :" + txtOrderNumber.Text, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtOrderNumber.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Order No.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrderNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                DataGVOrders.Rows.Clear();
                txtQtyOnLabel.Text="";
                txtQtyToPrint.Text = "";
            }
            finally 
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
        }

        private void FillOrderGrid(ArrayList alOrder)
        {
            DataGVOrders.Rows.Clear();
            DataGVItems.Rows.Clear();
            int i=0;
            if (rdbPO.Checked == true)
            {
                foreach (clsPurchaseOrder objclsPO  in alOrder)
                {
                    DataGVOrders.Rows.Add();
                    DataGVOrders.Rows[i].Cells[0].Value = objclsPO.TxnDate.ToShortDateString();
                    DataGVOrders.Rows[i].Cells[1].Value = objclsPO.RefNumber;
                    DataGVOrders.Rows[i].Cells[2].Value = objclsPO.RefFullName;
                    i++;
                }
            }
            else if (rdbSO.Checked == true)
            {
                foreach (clsSalesOrder objSO in alOrder )
                {
                    DataGVOrders.Rows.Add();
                    DataGVOrders.Rows[i].Cells[0].Value = objSO.TxnDate.ToShortDateString();
                    DataGVOrders.Rows[i].Cells[1].Value = objSO.RefNumber;
                    DataGVOrders.Rows[i].Cells[2].Value = objSO.CustomerRefFullName;
                    i++;
                }
            }
            else
            {
                foreach (clsInvoice objInvoice in alOrder)
                {
                    DataGVOrders.Rows.Add();
                    DataGVOrders.Rows[i].Cells[0].Value = objInvoice.TxnDate.ToShortDateString();
                    DataGVOrders.Rows[i].Cells[1].Value = objInvoice.RefNumber;
                    DataGVOrders.Rows[i].Cells[2].Value = objInvoice.BillAddressAddr1;
                    InvoiceCustomerName = objInvoice.CustomerRefFullName;
                    i++;
                }
            }
        }

        private void FillItemsGrid(ArrayList alLineItems)
        {
            int i = 0;
            DataGVItems.Rows.Clear();
            if (rdbPO.Checked == true)
            {
                if (rdbB.Checked == true)
                {
                    foreach (clsPurchaseOrderLine objPOLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();
                        //DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        //DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        //DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        //DataGVItems.Rows[i].Cells["Decrease"].Value = "-";
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantity"].Value = objPOLine.PurchaseOrderQty;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineUnitOfMeasure"].Value = objPOLine.PurchaseOrderLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineItemRefFullName"].Value = objPOLine.PurchaseOrderLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineDesc"].Value = objPOLine.PurchaseOrderLineDesc;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineTxnLineID"].Value = objPOLine.PurchaseOrderLineTxnLineID;
                        i++;
                    }
                }
                else
                {
                    foreach (clsPurchaseOrderLine objPOLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();
                        //DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        //DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        //DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        //DataGVItems.Rows[i].Cells["Decrease"].Value = "-";

                        DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantity"].Value = objPOLine.PurchaseOrderQty;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineUnitOfMeasure"].Value = objPOLine.PurchaseOrderLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineItemRefFullName"].Value = objPOLine.PurchaseOrderLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineDesc"].Value = objPOLine.PurchaseOrderLineDesc;
                        DataGVItems.Rows[i].Cells["PurchaseOrderLineTxnLineID"].Value = objPOLine.PurchaseOrderLineTxnLineID;
                        i++;
                    }
                }
            }
            else if (rdbSO.Checked == true)
            {
                if (rdbB.Checked == true)
                {
                    foreach (clsSalesOrderLine objSOLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();
                        //DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        //DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        //DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        //DataGVItems.Rows[i].Cells["Decrease"].Value = "-";

                        DataGVItems.Rows[i].Cells["SalesOrderLineQuantity"].Value = objSOLine.SalesOrderLineQuantity;
                        DataGVItems.Rows[i].Cells["SalesOrderLineUnitOfMeasure"].Value = objSOLine.SalesOrderLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["SalesOrderLineItemRefFullName"].Value = objSOLine.SalesOrderLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["SalesOrderLineDesc"].Value = objSOLine.SalesOrderLineDesc;
                        DataGVItems.Rows[i].Cells["SalesOrderLineTxnLineID"].Value = objSOLine.SalesOrderLineTxnLineID;
                        i++;
                    }
                }
                else
                {
                    //below condition to check if create invoice is check to fill items.
                    if (rdbd.Checked == true)
                    {
                        //DataGVItems.Enabled = false;
                        //DataGVItems.DefaultCellStyle.BackColor = Color.LightGray;
                        //DisableGrid(DataGVItems);
                        foreach (clsSalesOrderLine objSOLine in alLineItems)
                        {
                            //preinvoice and Toinvoice column is added
                            DataGVItems.Rows.Add();
                            DataGVItems.Rows[i].Cells[1].Value = objSOLine.SalesOrderLineQuantity;
                            //DataGVItems.Rows[i].Cells[2].Value = objSOLine.SalesOrderLinePreInvoice;//prev.Invoice column commented
                           // if(Convert.ToDouble(objSOLine.SalesOrderLineQuantity - objSOLine.SalesOrderLinePreInvoice)>=0)
                              //  dblInvoiceToQuantity=Convert.ToDouble(objSOLine.SalesOrderLineQuantity - objSOLine.SalesOrderLinePreInvoice);
                              //  else
                               dblInvoiceToQuantity=0.00;
                               DataGVItems.Rows[i].Cells[2].Value = dblInvoiceToQuantity;
                            DataGVItems.Rows[i].Cells[3].Value =objSOLine.SalesOrderLineUnitOfMeasure;
                            DataGVItems.Rows[i].Cells[4].Value = objSOLine.SalesOrderLineItemRefFullName;
                            DataGVItems.Rows[i].Cells[5].Value = objSOLine.SalesOrderLineDesc;

                            i++;
                        }
                    }
                    else
                    {
                       // DataGVItems.Enabled = true;
                       // DataGVItems.DefaultCellStyle.BackColor = Color.White;
                        foreach (clsSalesOrderLine objSOLine in alLineItems)
                        {

                            DataGVItems.Rows.Add();

                            //Quantity Adjustment added for multiple sales order : Date 12/01/2014

                            DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                            DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                            DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                            DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                            DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                            DataGVItems.Rows[i].Cells["Decrease"].Value = "-";

                            DataGVItems.Rows[i].Cells["SalesOrderLineQuantity"].Value = objSOLine.SalesOrderLineQuantity;
                            DataGVItems.Rows[i].Cells["SalesOrderLineQuantityToPrint"].Value = objSOLine.SalesOrderLineQuantity;

                            if (objSOLine.SalesOrderLineQuantity == 0 || objSOLine.SalesOrderLineQuantity == 0)
                                DataGVItems.Rows[i].Cells["SalesOrderLineQuantityOnLabel"].Value = 0;
                            else
                                DataGVItems.Rows[i].Cells["SalesOrderLineQuantityOnLabel"].Value = objSOLine.SalesOrderLineQuantity / objSOLine.SalesOrderLineQuantity;

                            DataGVItems.Rows[i].Cells["SalesOrderLineQuantity"].Value = objSOLine.SalesOrderLineQuantity;
                            DataGVItems.Rows[i].Cells["SalesOrderLineUnitOfMeasure"].Value = objSOLine.SalesOrderLineUnitOfMeasure;
                            DataGVItems.Rows[i].Cells["SalesOrderLineItemRefFullName"].Value = objSOLine.SalesOrderLineItemRefFullName;
                            DataGVItems.Rows[i].Cells["SalesOrderLineDesc"].Value = objSOLine.SalesOrderLineDesc;
                            DataGVItems.Rows[i].Cells["SalesOrderLineTxnLineID"].Value = objSOLine.SalesOrderLineTxnLineID;

                            i++;
                        }
                    }
                }
            }

            else
            {
                if (rdbB.Checked == true)
                {
                    foreach (clsInvoiceLine objINVLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();
                        //DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        //DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        //DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        //DataGVItems.Rows[i].Cells["Decrease"].Value = "-";
                        DataGVItems.Rows[i].Cells["InvoiceLineQuantity"].Value = objINVLine.InvoiceLineQuantity;
                        DataGVItems.Rows[i].Cells["InvoiceLineUnitOfMeasure"].Value = objINVLine.InvoiceLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["InvoiceLineItemRefFullName"].Value = objINVLine.InvoiceLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["InvoiceLineDesc"].Value = objINVLine.InvoiceLineDesc;
                        DataGVItems.Rows[i].Cells["InvoiceLineTxnLineID"].Value = objINVLine.InvoiceLineTxnLineID;
                        i++;
                    }
                }
                else if (rdbC.Checked == true)
                {
                    foreach (clsInvoiceLine objINVLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();
                        //DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        //DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        //DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        //DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        //DataGVItems.Rows[i].Cells["Decrease"].Value = "-";
                        DataGVItems.Rows[i].Cells["PrintedStatus"].Value = "N";
                        DataGVItems.Rows[i].Cells["InvoiceLineQuantity"].Value = objINVLine.InvoiceLineQuantity;
                        DataGVItems.Rows[i].Cells["InvoiceLineUnitOfMeasure"].Value = objINVLine.InvoiceLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["InvoiceLineItemRefFullName"].Value = objINVLine.InvoiceLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["InvoiceLineDesc"].Value = objINVLine.InvoiceLineDesc;
                        DataGVItems.Rows[i].Cells["InvoiceLineTxnLineID"].Value = objINVLine.InvoiceLineTxnLineID;
                        i++;
                    }
                }
                else if (rdbA.Checked == true)
                {
                    foreach (clsInvoiceLine objINVLine in alLineItems)
                    {
                        DataGVItems.Rows.Add();

                        DataGridViewCustomButtonCell objCellIncrease = new DataGridViewCustomButtonCell();
                        DataGVItems.Rows[i].Cells["Increase"] = objCellIncrease;
                        DataGVItems.Rows[i].Cells["Increase"].Value = "+";
                        DataGridViewCustomButtonCell objCellDecrease = new DataGridViewCustomButtonCell();
                        DataGVItems.Rows[i].Cells["Decrease"] = objCellDecrease;
                        DataGVItems.Rows[i].Cells["Decrease"].Value = "-";
                        DataGVItems.Rows[i].Cells["InvoiceLineQuantity"].Value = objINVLine.InvoiceLineQuantity;
                        DataGVItems.Rows[i].Cells["InvoiceLineQuantityToPrint"].Value = objINVLine.InvoiceLineQuantity;
                        
                        if (objINVLine.InvoiceLineQuantity == 0 || objINVLine.InvoiceLineQuantity == 0)
                            DataGVItems.Rows[i].Cells["InvoiceLineQuantityOnLabel"].Value = 0;
                        else
                            DataGVItems.Rows[i].Cells["InvoiceLineQuantityOnLabel"].Value = objINVLine.InvoiceLineQuantity / objINVLine.InvoiceLineQuantity;

                        DataGVItems.Rows[i].Cells["InvoiceLineUnitOfMeasure"].Value = objINVLine.InvoiceLineUnitOfMeasure;
                        DataGVItems.Rows[i].Cells["InvoiceLineItemRefFullName"].Value = objINVLine.InvoiceLineItemRefFullName;
                        DataGVItems.Rows[i].Cells["InvoiceLineDesc"].Value = objINVLine.InvoiceLineDesc;
                        DataGVItems.Rows[i].Cells["InvoiceLineTxnLineID"].Value = objINVLine.InvoiceLineTxnLineID;
                        i++;
                    }
                }
            }
        }

        private void InitDataGrid()
        {
            //make filter button visible true
            btnfilterlabel.Visible = true;
            DataGVOrders.Columns.Clear();
            DataGVItems.Columns.Clear();
            if (rdbPO.Checked == true)
            {
                DataGVOrders.Columns.Add("TxnDate", "PO Created Date");
                DataGVOrders.Columns["TxnDate"].Width = 120;
                DataGVOrders.Columns.Add("RefNumber", "PO Number");
                DataGVOrders.Columns["RefNumber"].Width = 90;
                DataGVOrders.Columns.Add("VendorRefFullName", "Vendor name");
                DataGVOrders.Columns["VendorRefFullName"].Width = 280;
                
                if (rdbB.Checked == true)
                {
                    //DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    //DataGVItems.Columns.Add("Increase","+");
                    //colIncrease.HeaderText = "+";
                    //colIncrease.Text = "+";
                    //colIncrease.UseColumnTextForButtonValue = true;
                    //DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();
                    
                    //DataGVItems.Columns.Add("Decrease","-");
                    //colDecrease.HeaderText = "-";
                    //colDecrease.Text = "-";
                    //colDecrease.UseColumnTextForButtonValue = true;

                    chkSelectAll.Visible = false;
                    DataGVItems.Columns.Add("PurchaseOrderLineQuantity", "PO Qty");
                    DataGVItems.Columns["PurchaseOrderLineQuantity"].Width = 100;
                    DataGVItems.Columns.Add("PurchaseOrderLineUnitOfMeasure", "PO UoM");
                    DataGVItems.Columns["PurchaseOrderLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("PurchaseOrderLineItemRefFullName", "PO Item");
                    DataGVItems.Columns["PurchaseOrderLineItemRefFullName"].Width = 150;
                    DataGVItems.Columns.Add("PurchaseOrderLineDesc", "PO Item Desc");
                    DataGVItems.Columns["PurchaseOrderLineDesc"].Width = 261;

                    DataGVItems.Columns.Add("PurchaseOrderLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["PurchaseOrderLineTxnLineID"].Visible = false;
                }
                else
                {
                    chkSelectAll.Visible = true;
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVItems.Columns.Add(Column);

                    DataGVItems.Columns["CheckBox"].Width = 50;
                    DataGVItems.Columns["CheckBox"].ReadOnly = false;


                    //DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    //DataGVItems.Columns.Add("Increase", "+");
                    //colIncrease.HeaderText = "+";
                    //colIncrease.Text = "+";
                    //colIncrease.UseColumnTextForButtonValue = true;
                    //DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();

                    //DataGVItems.Columns.Add("Decrease", "-");
                    //colDecrease.HeaderText = "-";
                    //colDecrease.Text = "-";
                    //colDecrease.UseColumnTextForButtonValue = true;

                   
                    DataGVItems.Columns.Add("PurchaseOrderLineQuantity", "PO Qty");
                    DataGVItems.Columns["PurchaseOrderLineQuantity"].Width = 100;
                    DataGVItems.Columns.Add("PurchaseOrderLineUnitOfMeasure", "PO UoM");
                    DataGVItems.Columns["PurchaseOrderLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("PurchaseOrderLineItemRefFullName", "PO Item");
                    DataGVItems.Columns["PurchaseOrderLineItemRefFullName"].Width = 100;
                    DataGVItems.Columns.Add("PurchaseOrderLineDesc", "PO Item Desc");
                    DataGVItems.Columns["PurchaseOrderLineDesc"].Width = 230;

                    DataGVItems.Columns.Add("PurchaseOrderLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["PurchaseOrderLineTxnLineID"].Visible = false;
                }
            }
            else if (rdbSO.Checked == true)
            {
                DataGVOrders.Columns.Add("TxnDate", "SO Created Date");
                DataGVOrders.Columns["TxnDate"].Width = 120;
                DataGVOrders.Columns.Add("RefNumber", "SO Number");
                DataGVOrders.Columns["RefNumber"].Width = 150;
                DataGVOrders.Columns.Add("CustomerRefFullName", "Customer name");
                DataGVOrders.Columns["CustomerRefFullName"].Width = 300;

               if (rdbB.Checked == true)
       
                {
                    chkSelectAll.Visible = false;

                    //DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    //DataGVItems.Columns.Add("Increase", "+");
                    //colIncrease.HeaderText = "+";
                    //colIncrease.Text = "+";
                    //colIncrease.UseColumnTextForButtonValue = true;
                    //DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();

                    //DataGVItems.Columns.Add("Decrease", "-");
                    //colDecrease.HeaderText = "-";
                    //colDecrease.Text = "-";
                    //colDecrease.UseColumnTextForButtonValue = true;

                    DataGVItems.Columns.Add("SalesOrderLineQuantity", "SO Qty");
                    DataGVItems.Columns["SalesOrderLineQuantity"].Width = 100;
                    DataGVItems.Columns.Add("SalesOrderLineUnitOfMeasure", "SO UoM ");
                    DataGVItems.Columns["SalesOrderLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("SalesOrderLineItemRefFullName", "SO Item ");
                    DataGVItems.Columns["SalesOrderLineItemRefFullName"].Width = 150;
                    DataGVItems.Columns.Add("SalesOrderLineDesc", "So Item Desc");
                    DataGVItems.Columns["SalesOrderLineDesc"].Width = 230;

                    DataGVItems.Columns.Add("SalesOrderLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["SalesOrderLineTxnLineID"].Visible = false;
                }
                //below code to add new column preInvoice and ToInvoice
               else if (rdbd.Checked == true)
                {
                    chkSelectAll.Visible = false;
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVItems.Columns.Add(Column);
                    DataGVItems.Columns["CheckBox"].Width = 50;
                    DataGVItems.Columns["CheckBox"].ReadOnly = false;
                    DataGVItems.Columns.Add("SalesOrderLineQuantity", "SO Qty");
                  

                   //This column is commented
                   // DataGVItems.Columns.Add("SalesOrderLinePreInvoice", "Prev.Invoiced");
                   // DataGVItems.Columns[1].Width = 100;
   
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "SalesOrderLineToInvoice";
                    col.DataPropertyName = "SalesOrderLineToInvoice";
                    col.HeaderText = "ToInvoice";
                    col.ValueType = typeof(double);
                   // col.Frozen = true;
                    DataGVItems.Columns.Add(col);
                    DataGVItems.Columns["SalesOrderLineToInvoice"].Width = 100;
                                     
                    
                    DataGVItems.Columns.Add("SalesOrderLineUoM", "SO UoM ");
                    DataGVItems.Columns["SalesOrderLineUoM"].Width = 100;
                    
                    DataGVItems.Columns.Add("SalesOrderLineItemRefName", "SO Item ");
                    DataGVItems.Columns["SalesOrderLineItemRefName"].Width = 150;
                    
                    DataGVItems.Columns.Add("SalesOrderLineDescription", "So Item Desc");
                    DataGVItems.Columns["SalesOrderLineDescription"].Width = 300;
                }
                else
                {
                    chkSelectAll.Visible = true;
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVItems.Columns.Add(Column);
                    DataGVItems.Columns["CheckBox"].Width = 50;
                    DataGVItems.Columns["CheckBox"].ReadOnly = false;

                    //Add Quantity Adjustment in multilple sales order Date 12/01/2014

                    DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    colIncrease.Width = 65;
                    colIncrease.Name = "Increase";
                    colIncrease.HeaderText = "+";
                    colIncrease.CellTemplate.Style.Font = new Font("Verdana", 28);


                    colIncrease.HeaderText = "+";
                    colIncrease.Text = "+";
                    DataGVItems.Columns.Add(colIncrease);

                    colIncrease.UseColumnTextForButtonValue = true;
                    DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();
                    colDecrease.Name = "Decrease";
                    colDecrease.Width = 65;

                    colDecrease.HeaderText = "-";
                    colDecrease.CellTemplate.Style.Font = new Font("Verdana", 28);
                    colDecrease.Text = "-";

                    DataGVItems.Columns.Add(colDecrease);

                    colDecrease.UseColumnTextForButtonValue = true;

                    DataGVItems.Columns.Add("SalesOrderLineQuantity", "SO Qty");
                    DataGVItems.Columns["SalesOrderLineQuantity"].Width = 40;

                    DataGVItems.Columns.Add("SalesOrderLineQuantityToPrint", "Print Lbl Qty");
                    DataGVItems.Columns["SalesOrderLineQuantityToPrint"].Width = 40;

                    DataGVItems.Columns.Add("SalesOrderLineQuantityOnLabel", "Qty On Lbl");
                    DataGVItems.Columns["SalesOrderLineQuantityOnLabel"].Width = 40;
                    DataGVItems.Columns.Add("SalesOrderLineUnitOfMeasure", "SO UoM ");
                    DataGVItems.Columns["SalesOrderLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("SalesOrderLineItemRefFullName", "SO Item ");
                    DataGVItems.Columns["SalesOrderLineItemRefFullName"].Width = 150;
                    DataGVItems.Columns.Add("SalesOrderLineDesc", "So Item Desc");
                    DataGVItems.Columns["SalesOrderLineDesc"].Width = 250;

                    DataGVItems.Columns.Add("SalesOrderLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["SalesOrderLineTxnLineID"].Visible = false;
                }

            }
            else
            {
                DataGVOrders.Columns.Add("TxnDate", "Inv.Created Date");
                DataGVOrders.Columns["TxnDate"].Width = 120;
                DataGVOrders.Columns.Add("RefNumber", "Inv. Number");
                DataGVOrders.Columns["RefNumber"].Width = 90;
                DataGVOrders.Columns.Add("BillAddressAddr1", "Bill Address");
                DataGVOrders.Columns["BillAddressAddr1"].Width = 280;

                if (rdbB.Checked == true)
                {
                    //make filter button visible true
                    btnfilterlabel.Visible = true;
                    chkSelectAll.Visible = false;
                    //DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    //DataGVItems.Columns.Add("Increase", "+");
                    //colIncrease.HeaderText = "+";
                    //colIncrease.Text = "+";
                    //colIncrease.UseColumnTextForButtonValue = true;
                    //DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();

                    //DataGVItems.Columns.Add("Decrease", "-");
                    //colDecrease.HeaderText = "-";
                    //colDecrease.Text = "-";
                    //colDecrease.UseColumnTextForButtonValue = true;
                    DataGVItems.Columns.Add("InvoiceLineQuantity", "Inv. Qty");
                    DataGVItems.Columns["InvoiceLineQuantity"].Width = 100;
                    DataGVItems.Columns.Add("InvoiceLineUnitOfMeasure", "Inv. UoM ");
                    DataGVItems.Columns["InvoiceLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("InvoiceLineItemRefFullName", "Inv. Item ");
                    DataGVItems.Columns["InvoiceLineItemRefFullName"].Width = 150;
                    DataGVItems.Columns.Add("InvoiceLineDesc", "Inv. Item Desc");
                    DataGVItems.Columns["InvoiceLineDesc"].Width = 230;

                    DataGVItems.Columns.Add("InvoiceLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["InvoiceLineTxnLineID"].Visible = false;
                }
                else if (rdbC.Checked == true)
                {
                    //make filter button visible false
                    btnfilterlabel.Visible = false;
                    chkSelectAll.Visible = true;
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVItems.Columns.Add(Column);
                    DataGVItems.Columns["CheckBox"].Width = 50;
                    DataGVItems.Columns["CheckBox"].ReadOnly = false;
                    //DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    //DataGVItems.Columns.Add("Increase", "+");
                    //colIncrease.HeaderText = "+";
                    //colIncrease.Text = "+";
                    //colIncrease.UseColumnTextForButtonValue = true;
                    //DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();

                    //DataGVItems.Columns.Add("Decrease", "-");
                    //colDecrease.HeaderText = "-";
                    //colDecrease.Text = "-";
                    //colDecrease.UseColumnTextForButtonValue = true;

                    DataGVItems.Columns.Add("PrintedStatus", "Print Status");
                    DataGVItems.Columns["PrintedStatus"].Width = 90;
                    DataGVItems.Columns.Add("InvoiceLineQuantity", "Inv. Qty");
                    DataGVItems.Columns["InvoiceLineQuantity"].Width = 100;
                    DataGVItems.Columns.Add("InvoiceLineUnitOfMeasure", "Inv. UoM ");
                    DataGVItems.Columns["InvoiceLineUnitOfMeasure"].Width = 100;
                    DataGVItems.Columns.Add("InvoiceLineItemRefFullName", "Inv. Item ");
                    DataGVItems.Columns["InvoiceLineItemRefFullName"].Width = 100;
                    DataGVItems.Columns.Add("InvoiceLineDesc", "Inv. Item Desc");
                    DataGVItems.Columns["InvoiceLineDesc"].Width = 230;

                    DataGVItems.Columns.Add("InvoiceLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["InvoiceLineTxnLineID"].Visible = false;
                    rdbd.Enabled = false;
                }
                else
                {
                    //make filter button visible true
                    btnfilterlabel.Visible = true;
                    chkSelectAll.Visible = true;
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVItems.Columns.Add(Column);
                    DataGVItems.Columns["CheckBox"].Width = 50;
                    DataGVItems.Columns["CheckBox"].ReadOnly = false;


                    DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();
                    colIncrease.Width = 65;
                    colIncrease.HeaderText = "+";
                    colIncrease.Name = "Increase";
                    colIncrease.Text = "+";
                    colIncrease.CellTemplate.Style.Font = new Font("Verdana", 28);
                    DataGVItems.Columns.Add(colIncrease);
                    colIncrease.UseColumnTextForButtonValue = true;
                    


                    DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();
                    colDecrease.Width = 65;
                    colDecrease.Name = "Decrease";
                    colDecrease.HeaderText = "-";
                    colDecrease.Text = "-";
                    colDecrease.CellTemplate.Style.Font = new Font("Verdana", 28);
                    DataGVItems.Columns.Add(colDecrease);
                    colDecrease.UseColumnTextForButtonValue = true;

                    DataGVItems.Columns.Add("InvoiceLineQuantity", "Inv. Qty");
                    DataGVItems.Columns["InvoiceLineQuantity"].Width = 40;

                    DataGVItems.Columns.Add("InvoiceLineQuantityToPrint", "Print Lbl Qty");
                    DataGVItems.Columns["InvoiceLineQuantityToPrint"].Width = 40;

                    DataGVItems.Columns.Add("InvoiceLineQuantityOnLabel", "Qty On Lbl");
                    DataGVItems.Columns["InvoiceLineQuantityOnLabel"].Width = 40;

                    DataGVItems.Columns.Add("InvoiceLineUnitOfMeasure", "Inv. UoM ");
                    DataGVItems.Columns["InvoiceLineUnitOfMeasure"].Width = 60;
                    DataGVItems.Columns.Add("InvoiceLineItemRefFullName", "Inv. Item ");
                    DataGVItems.Columns["InvoiceLineItemRefFullName"].Width = 90;
                    DataGVItems.Columns.Add("InvoiceLineDesc", "Inv. Item Desc");
                    DataGVItems.Columns["InvoiceLineDesc"].Width = 250;

                    DataGVItems.Columns.Add("InvoiceLineTxnLineID", "Txn No.");
                    DataGVItems.Columns["InvoiceLineTxnLineID"].Visible = false;
                }
              
            }
        }


        private void ShowhideControls()
        {
            if (rdbd.Checked)
            {
                gbOrderDetail.Visible = false;
                gbInvoiceDetail.Visible = true;
                
            }

            else
            {
                gbInvoiceDetail.Visible = false;
                gbOrderDetail.Visible = true;
                
            }
        
        }


        private void frmPrintLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               e.Cancel = false;
            }
            else
            {
                e.Cancel=true;
            }
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //int BtMsg1 = 0;
            int cntChk = 0;
            
            try
            {
                if (txtQtyToPrint.Visible==true && Convert.ToInt32(txtQtyToPrint.Text) <= 0)
                {
                    MessageBox.Show("Quantity to print should be greater than zero.", "Label Connector");
                    txtQtyToPrint.Focus();
                    return;
                }
                if (cmbLabelName.SelectedIndex > 0)
                {
                    btnPrint.Enabled = false;
                    #region Printing Code Using BarTender
                    if (rdbB.Checked == true)
                    {
                        if (CheckMandetory())
                        {
                            foreach (Process clsProcess in Process.GetProcesses())
                            {
                                if (clsProcess.ProcessName.StartsWith("bartender"))
                                {
                                    clsProcess.Kill();
                                    clsProcess.WaitForExit();
                                }
                            }


                            BarTender.Application BtApp = default(BarTender.Application);
                            BarTender.Format BtFormat = default(BarTender.Format);
                            BarTender.SubString BtSubString = default(BarTender.SubString);
                            //BarTender.Messages BtMsg = default(BarTender.Messages);


                            OdbcCommand printCmd = default(OdbcCommand);
                            OdbcDataReader printReader = default(OdbcDataReader);
                            OdbcConnection Cn = new OdbcConnection(ConfigurationManager.AppSettings["quickbookDSN"]);

                            string btNamedSubString = "";
                            string strPrintQuery = "";
                            //Dim strProdLblPath As String = System.Configuration.ConfigurationManager.AppSettings("LabelPath").ToString()
                            string strProdLblPath = "";
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
                                    if (Node.Attributes.GetNamedItem("key").Value == "LabelPath")
                                    {
                                        strProdLblPath = Node.Attributes.GetNamedItem("value").Value;
                                    }
                                    if (Node.Attributes.GetNamedItem("key").Value == "WeatherLabelPath")
                                    {
                                        strWeatherLabel = Node.Attributes.GetNamedItem("value").Value;
                                    }
                                }
                            }
                            string strLabelName = cmbLabelName.Text;
                            strProdPrinter = cmbLabelPrinter.Text;
                            int intQuantity = 0;
                            string lstrPropertyValue = string.Empty;

                            BtApp = new BarTender.ApplicationClass();
                            QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Batrender Object is Created...");
                            BtFormat = new BarTender.Format();
                            // ----------- Code Start Printing Weather Label -----------------
                            //code commented for printing weather label Date:01/13/2015
                            //if ((ckbWeatherLabel.Checked == true) && (lblLowTempValue.Text.ToString() != string.Empty || lblHighTempValue.Text.ToString() != string.Empty))
                            //{
                            //    int k = 1;
                            //    BtFormat = BtApp.Formats.Open(strWeatherLabel, true, strProdPrinter);
                            //    while (k <= BtFormat.NamedSubStrings.Count)
                            //    {
                            //        BtSubString = BtFormat.NamedSubStrings.GetSubString(k);

                            //        if (BtSubString.Name == "ShipAddressAddr1") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblStoreNameValue.Text.ToString() + '\r' + '\n';
                            //        if (BtSubString.Name == "RefNumber") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblInvoiceNumberValue.Text.ToString() + '\r' + '\n';
                            //        if (BtSubString.Name == "LowTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblLowTempValue.Text.ToString() + '\r' + '\n';
                            //        if (BtSubString.Name == "HighTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblHighTempValue.Text.ToString() + '\r' + '\n';
                            //        k++;
                            //    }
                            //    if (btNamedSubString != string.Empty)
                            //    {
                            //        string strDelimiter = string.Concat('\r', '\n');
                            //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " String to be Printed:-" + btNamedSubString);
                            //        BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);
                            //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " No Of copies to be printed:-" + intQuantity.ToString());
                            //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Printer Name:-" + strProdPrinter.ToString());
                            //        BtFormat.IdenticalCopiesOfLabel = 1;//Convert.ToInt32(intQuantity);
                            //        BtFormat.PrintOut(false, false);
                            //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Substring values are send to Bartender for printing...");
                            //    }
                            //}

                            //btNamedSubString = "";

                            //------------Code End for Printing Weather Label---------------



                            if ((cmbLabelName.SelectedIndex != 0))
                            {
                                try
                                {
                                    lobjDataExtension = null;
                                    this.Cursor = Cursors.WaitCursor;
                                    intQuantity = Convert.ToInt32(txtQtyToPrint.Text);
                                    if (intQuantity > 30)
                                    {
                                        intQuantity = 30;
                                    }
                                   

                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender(.btw) file is opened...");
                                    BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);
                                    int i = 1;
                                    ArrayList alLineItem = null;
                                    clsPurchaseOrderLine objclsPurchaseOrderLine = null;
                                    clsSalesOrderLine objclsSalesOrderLine = null;
                                    clsInvoiceLine objclsInvoiceLine = null;
                                    Type objClsType;
                                    object strPropertyValue = null;

                                    if (rdbPO.Checked == true)
                                    {
                                        objclsPurchaseOrderLine = new clsPurchaseOrderLine();
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Purchase Order Line Item object is Created...");
                                        if (lstrQBFileMode == "Close")
                                        {
                                            alLineItem = objclsPurchaseOrderLine.GetPOLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value,  lQBSessionManager, moQuickBooksAccountConfig);
                                        }
                                        else
                                        {
                                            alLineItem = objclsPurchaseOrderLine.GetPOLine(string.Empty,txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                                        }
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Purchase Order Line Item object is filled with data, fetched from QuickBooks...");
                                        objClsType = objclsPurchaseOrderLine.GetType();
                                    }
                                    else if (rdbSO.Checked == true)
                                    {
                                        objclsSalesOrderLine = new clsSalesOrderLine();
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Sales Order Line Item object is Created...");
                                        objClsType = objclsSalesOrderLine.GetType();
                                        //add out parameter to print custom field in sales order:added by khushal:date:01/24/2013
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Sales Order Line Item object is filled with data, fetched from QuickBooks...");
                                        if (lstrQBFileMode == "Close")
                                        {
                                            alLineItem = objclsSalesOrderLine.GetSOLine(txtQtyOnLabel.Text.ToString(), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                        }
                                        else
                                        {
                                            alLineItem = objclsSalesOrderLine.GetSOLine(txtQtyOnLabel.Text.ToString(), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value,string.Empty, out lobjDataExtension);
                                        }
                                    }
                                    else
                                    {
                                        objclsInvoiceLine = new clsInvoiceLine();
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Invoice Line Item object is Created...");
                                        if (lstrQBFileMode == "Close")
                                        {
                                            //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                            alLineItem = objclsInvoiceLine.GetINVLine(string.Empty,Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineItemRefFullName"].Value), alInvoiceLineItems, alData, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                        }
                                        else
                                        {
                                            //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                                            alLineItem = objclsInvoiceLine.GetINVLine(string.Empty, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineItemRefFullName"].Value), alData, alInvoiceLineItems, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, InvoiceCustomerName, out lobjDataExtension, string.Empty, string.Empty);
                                        }
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Invoce Line Item object is filled with data, fetched from QuickBooks...");
                                        objClsType = objclsInvoiceLine.GetType();
                                    }

                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender File is opened to get Label Names...");
                                    i = 1;
                                    while (i <= BtFormat.NamedSubStrings.Count)
                                    {
                                        BtSubString = BtFormat.NamedSubStrings.GetSubString(i);
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Substring Name:-" + BtSubString.Name);
                                        int y = 0;
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Getting Values for Label:-" + BtSubString.Name);
                                        while (y <= alLineItem.Count - 1)
                                        {
                                            try
                                            {
                                                PropertyInfo objPropertyInfo = objClsType.GetProperty(BtSubString.Name);

                                                if (rdbPO.Checked == true)
                                                {
                                                    strPropertyValue = objPropertyInfo.GetValue((clsPurchaseOrderLine)alLineItem[y], null);
                                                }
                                                else if (rdbSO.Checked == true)
                                                {
                                                    //strPropertyValue = objPropertyInfo.GetValue((clsSalesOrderLine)alLineItem[y], null);
                                                    //strPropertyValue = objPropertyInfo.GetValue((clsInvoiceLine)alLineItem[y], null);
                                                    if (BtSubString.Name == "RefNumber")
                                                    {
                                                        strPropertyValue = txtOrderNumber.Text;
                                                    }
                                                    else
                                                    {
                                                        strPropertyValue = objPropertyInfo.GetValue((clsInvoiceLine)alLineItem[y], null);
                                                    }
                                                }
                                                else
                                                {
                                                    strPropertyValue = objPropertyInfo.GetValue((clsInvoiceLine)alLineItem[y], null);
                                                }
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + "  Value:-" + strPropertyValue);
                                            }
                                            catch (Exception ex)
                                            {
                                                try
                                                {
                                                    string lstrPropertyValExt = string.Empty;
                                                    if (lobjDataExtension.ContainsKey(BtSubString.Name))
                                                    {
                                                        lobjDataExtension.TryGetValue(BtSubString.Name, out lstrPropertyValExt);
                                                        strPropertyValue = lstrPropertyValExt;
                                                    }
                                                    else
                                                    {
                                                        strPropertyValue = string.Empty;
                                                    }
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Label:-" + BtSubString.Name + "  Value:-" + strPropertyValue);
                                                }
                                                catch (Exception exExt)
                                                {
                                                    strPropertyValue = string.Empty;
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Label:-" + BtSubString.Name + "  Value:-" + strPropertyValue);
                                                }
                                                finally
                                                {

                                                }
                                            }
                                           

                                            lstrPropertyValue = Convert.ToString(strPropertyValue);
                                          
                                                if (lstrPropertyValue.IndexOf(":") > 0)
                                                {
                                                    lstrPropertyValue = lstrPropertyValue.Substring(0, lstrPropertyValue.IndexOf(':'));
                                                }
                                                if (BtSubString.Name.ToLower() == "purchaseordercustomer")
                                                {
                                                    lstrPropertyValue = string.Empty;

                                                }
                                            
                                            //lstrPropertyValue = lstrPropertyValue.Substring(lstrPropertyValue.LastIndexOf(':') + 1);

                                            //if ((BtSubString.Name.ToUpper() == "LQTY"))
                                            //{
                                            //    btNamedSubString += BtSubString.Name + '\r' + '\n' + txtQtyOnLabel.Text.Trim() + '\r' + '\n';
                                            //}
                                            //else 
                                            if (!BtSubString.Name.ToUpper().Contains("LQTY"))
                                            {

                                                btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrPropertyValue + '\r' + '\n';
                                                //QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label :- " + BtSubString.Name + " Value:-" + lstrPropertyValue);
                                            }
                                            else
                                            {
                                                btNamedSubString += BtSubString.Name + '\r' + '\n' + Convert.ToString(txtQtyOnLabel.Text) + '\r' + '\n';
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + " Value:-" + txtQtyOnLabel.Text);
                                            }
                                            y += 1;
                                        }
                                        i += 1;
                                    }

                                    if (btNamedSubString != string.Empty)
                                    {
                                        string strDelimiter = string.Concat('\r', '\n');
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " String to be Printed:-" + btNamedSubString);
                                        BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " No Of copies to be printed:-" + intQuantity.ToString());
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Printer Name:-" + strProdPrinter.ToString());
                                        BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                        BtFormat.PrintOut(false, false);
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Substring values are send to Bartender for printing...");
                                    }
                                }
                                catch (System.Exception ex)
                                {

                                    MessageBox.Show(ex.Message, "Label Connector");
                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label Printing is having some problem.:-" + ex.Message + ":" + ex.StackTrace);

                                }
                                finally
                                {
                                    BtFormat.Close(BtSaveOptions.btDoNotSaveChanges);
                                    BtApp.Quit(BtSaveOptions.btDoNotSaveChanges);
                                    BtSubString = null;
                                    BtFormat = null;
                                    BtApp = null;
                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender is closed.");
                                    QBHelper.WriteLog("--------------------------------------------------------------------------");
                                    foreach (Process clsProcess in Process.GetProcesses())
                                    {
                                        if (clsProcess.ProcessName.StartsWith("bartender"))
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
                                    btnPrint.Enabled = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Printing Error: " + "Please Select Label");
                            }
                        }
                    }
                    else if (rdbA.Checked == true)
                    {
                        int WL = 1;
                        if (CheckMandetory())
                        {
                            if (DataGVItems.Rows.Count > 0)
                            {
                                for (int i = 0; i < DataGVItems.Rows.Count; i++)
                                {
                                    if (DataGVItems.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "False")
                                    {
                                        cntChk = cntChk + 1;
                                    }
                                }
                                if (cntChk == DataGVItems.Rows.Count)
                                {
                                    MessageBox.Show("Please Check At Least One Record To Print", "Label Connector");
                                    return;
                                }

                                for (int j = 0; j < DataGVItems.Rows.Count; j++)
                                {
                                    if (DataGVItems.Rows[j].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                    {
                                        foreach (Process clsProcess in Process.GetProcesses())
                                        {
                                            if (clsProcess.ProcessName.StartsWith("bartender"))
                                            {
                                                clsProcess.Kill();
                                                clsProcess.WaitForExit();
                                            }
                                        }

                                        BarTender.Application BtApp = default(BarTender.Application);
                                        BarTender.Format BtFormat = default(BarTender.Format);
                                        BarTender.SubString BtSubString = default(BarTender.SubString);

                                        OdbcCommand printCmd = default(OdbcCommand);
                                        OdbcDataReader printReader = default(OdbcDataReader);
                                        OdbcConnection Cn = new OdbcConnection(ConfigurationManager.AppSettings["quickbookDSN"]);

                                        string btNamedSubString = "";
                                        string strPrintQuery = "";
                                        //Dim strProdLblPath As String = System.Configuration.ConfigurationManager.AppSettings("LabelPath").ToString()
                                        string strProdLblPath = "";
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
                                            if (Node.Name == "add")
                                            {
                                                if (Node.Attributes.GetNamedItem("key").Value == "LabelPath")
                                                {
                                                    strProdLblPath = Node.Attributes.GetNamedItem("value").Value;
                                                }
                                                if (Node.Attributes.GetNamedItem("key").Value == "WeatherLabelPath")
                                                {
                                                    strWeatherLabel = Node.Attributes.GetNamedItem("value").Value;
                                                }
                                            }
                                        }
                                        string strLabelName = cmbLabelName.Text;
                                        strProdPrinter = cmbLabelPrinter.Text;
                                        int intQuantity = 0;
                                        int intQuantityToPrintOnLabel = 0;
                                        string lstrPropertyValue = string.Empty;
                                        BtApp = new BarTender.ApplicationClass();
                                        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Batrender Object is Created...");
                                        BtFormat = new BarTender.Format();
                                        // ----------- Code Start Printing Weather Label -----------------
                                        //code commented for printing weather label Date 01/13/2015
                                        //if ((ckbWeatherLabel.Checked == true) && (WL == 1) && (lblLowTempValue.Text.ToString() != string.Empty || lblHighTempValue.Text.ToString() != string.Empty))
                                        //   // (ckbWeatherLabel.Checked == true && WL == 1)
                                        //{
                                            
                                        //    int k = 1;
                                        //    BtFormat = BtApp.Formats.Open(strWeatherLabel, true, strProdPrinter);
                                        //    while (k <= BtFormat.NamedSubStrings.Count)
                                        //    {
                                        //        BtSubString = BtFormat.NamedSubStrings.GetSubString(k);

                                        //        if (BtSubString.Name == "ShipAddressAddr1") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblStoreNameValue.Text.ToString() + '\r' + '\n';
                                        //        if (BtSubString.Name == "RefNumber") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblInvoiceNumberValue.Text.ToString() + '\r' + '\n';
                                        //        if (BtSubString.Name == "LowTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblLowTempValue.Text.ToString() + '\r' + '\n';
                                        //        if (BtSubString.Name == "HighTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblHighTempValue.Text.ToString() + '\r' + '\n';
                                        //        k++;
                                        //    }
                                        //    if (btNamedSubString != string.Empty)
                                        //    {
                                        //        string strDelimiter = string.Concat('\r', '\n');
                                        //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " String to be Printed:-" + btNamedSubString);
                                        //        BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);
                                        //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " No Of copies to be printed:-" + intQuantity.ToString());
                                        //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Printer Name:-" + strProdPrinter.ToString());
                                        //        BtFormat.IdenticalCopiesOfLabel = 1;//Convert.ToInt32(intQuantity);
                                        //        BtFormat.PrintOut(false, false);
                                        //        WL = 2;
                                        //        QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Substring values are send to Bartender for printing...");
                                        //    }
                                        //}

                                        //btNamedSubString = "";

                                        //------------Code End for Printing Weather Label---------------

                                        if ((cmbLabelName.SelectedIndex != 0))
                                        {
                                            try
                                            {
                                                this.Cursor = Cursors.WaitCursor;
                                                lobjDataExtension = null;
                                                if (rdbPO.Checked == true)
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value.ToString().Trim());
                                                }
                                                else if (rdbSO.Checked == true)
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["SalesOrderLineQuantity"].Value.ToString().Trim());
                                                }
                                                else
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["InvoiceLineQuantity"].Value.ToString().Trim());
                                                }

                                                //if (intQuantity > 30)
                                                //{
                                                //    intQuantity = 30;
                                                //}
                                                BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender(.btw) file is opened...");
                                                int i = 1;

                                                ArrayList alLineItem = null;
                                                clsPurchaseOrderLine objclsPurchaseOrderLine = null;
                                                clsSalesOrderLine objclsSalesOrderLine = null;
                                                clsInvoiceLine objclsInvoiceLine = null;
                                                Type objClsType;
                                                object strPropertyValue = null;

                                                if (rdbPO.Checked == true)
                                                {
                                                    objclsPurchaseOrderLine = new clsPurchaseOrderLine();
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Purchase Order Line Item object is Created...");
                                                    if (lstrQBFileMode == "Close")
                                                    {
                                                        alLineItem = objclsPurchaseOrderLine.GetPOLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value,  lQBSessionManager, moQuickBooksAccountConfig);
                                                    }
                                                    else
                                                    {
                                                        alLineItem = objclsPurchaseOrderLine.GetPOLine(string.Empty,txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                                                    }
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Purchase Order Line Item object is filled with data, fetched from QuickBooks...");
                                                    objClsType = objclsPurchaseOrderLine.GetType();
                                                }
                                                else if (rdbSO.Checked == true)
                                                {
                                                    objclsSalesOrderLine = new clsSalesOrderLine();
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Sales Order Line Item object is Created...");
                                                    objClsType = objclsSalesOrderLine.GetType();
                                                    //out parameter added by khushal:date:01/24/13
                                                    if (lstrQBFileMode == "Close")
                                                    {
                                                        alLineItem = objclsSalesOrderLine.GetSOLine(Convert.ToString(DataGVItems.Rows[DataGVOrders.CurrentRow.Index].Cells["SalesOrderLineQuantityonLabel"].Value), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                                    }
                                                    else
                                                    {
                                                        alLineItem = objclsSalesOrderLine.GetSOLine(Convert.ToString(DataGVItems.Rows[DataGVOrders.CurrentRow.Index].Cells["SalesOrderLineQuantityonLabel"].Value), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value,string.Empty, out lobjDataExtension);
                                                    }
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Sales Order Line Item object is filled with data, fetched from QuickBooks...");
                                                }
                                                else
                                                {
                                                    objclsInvoiceLine = new clsInvoiceLine();
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Invoice Line Item object is Created...");
                                                    if (lstrQBFileMode == "Close")
                                                    {
                                                        //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                                        alLineItem = objclsInvoiceLine.GetINVLine(string.Empty,Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineItemRefFullName"].Value), alInvoiceLineItems, alData, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                                                    }
                                                    else
                                                    {
                                                        //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                                                        alLineItem = objclsInvoiceLine.GetINVLine(string.Empty, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineItemRefFullName"].Value), alData, alInvoiceLineItems, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, InvoiceCustomerName, out lobjDataExtension, string.Empty, string.Empty);
                                                    }
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Invoice Line Item object is filled with data, fetched from QuickBooks...");
                                                    objClsType = objclsInvoiceLine.GetType();
                                                }
                                                i = 1;

                                                while (i <= BtFormat.NamedSubStrings.Count)
                                                {

                                                    BtSubString = BtFormat.NamedSubStrings.GetSubString(i);
                                                    int y = 0;
                                                    QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender File is opened to get Label Names...");
                                                    while (y <= alLineItem.Count - 1)
                                                    {
                                                        try
                                                        {
                                                            PropertyInfo objPropertyInfo = objClsType.GetProperty(BtSubString.Name);
                                                            QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Substring Name:-" + BtSubString.Name);

                                                            if (rdbPO.Checked == true)
                                                            {
                                                                if (BtSubString.Name.ToLower() == "purchaseorderlinequantity") //set qty on label to 1 for multiple po
                                                                {
                                                                    strPropertyValue = 1;
                                                                }
                                                                else
                                                                {
                                                                    strPropertyValue = objPropertyInfo.GetValue((clsPurchaseOrderLine)alLineItem[y], null);
                                                                }
                                                            }
                                                            else if (rdbSO.Checked == true)
                                                            {
                                                                strPropertyValue = objPropertyInfo.GetValue((clsSalesOrderLine)alLineItem[y], null);
                                                            }
                                                            else
                                                            {
                                                                strPropertyValue = objPropertyInfo.GetValue((clsInvoiceLine)alLineItem[y], null);
                                                            }
                                                            QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + "  Value:-" + strPropertyValue);

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            try
                                                            {
                                                                string lstrPropertyValExt = string.Empty;
                                                                if (lobjDataExtension.ContainsKey(BtSubString.Name))
                                                                {
                                                                    lobjDataExtension.TryGetValue(BtSubString.Name, out lstrPropertyValExt);
                                                                    strPropertyValue = lstrPropertyValExt;
                                                                }
                                                                else
                                                                {
                                                                    strPropertyValue = string.Empty;
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
                                                        lstrPropertyValue = Convert.ToString(strPropertyValue);
                                                        if (BtSubString.Name.ToLower() != "purchaseordercustomer")
                                                        {

                                                            lstrPropertyValue = lstrPropertyValue.Substring(lstrPropertyValue.LastIndexOf(':') + 1);
                                                        }

                                                        if (BtSubString.Name == "InvoiceLineQuantity")
                                                        {
                                                            intQuantityToPrintOnLabel = Convert.ToInt32(DataGVItems.Rows[j].Cells["InvoiceLineQuantity"].Value.ToString().Trim()) / Convert.ToInt32(DataGVItems.Rows[j].Cells["InvoiceLineQuantityToPrint"].Value.ToString().Trim());
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + intQuantityToPrintOnLabel.ToString() + '\r' + '\n';
                                                        }
                                                        //beolow condition added to divide quanity for sales order :Date 12/01/2014
                                                        else if (BtSubString.Name == "SalesOrderLineQuantity")
                                                        {
                                                            intQuantityToPrintOnLabel = Convert.ToInt32(DataGVItems.Rows[j].Cells["SalesOrderLineQuantity"].Value.ToString().Trim()) / Convert.ToInt32(DataGVItems.Rows[j].Cells["SalesOrderLineQuantityToPrint"].Value.ToString().Trim());
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + intQuantityToPrintOnLabel.ToString() + '\r' + '\n';
                                                        }
                                                        else if (BtSubString.Name.ToUpper() == "LQTY")
                                                        {
                                                            QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + "  Value:-" + DataGVItems.Rows[j].Cells["InvoiceLineQuantityOnLabel"].Value.ToString().Trim());
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + DataGVItems.Rows[j].Cells["InvoiceLineQuantityOnLabel"].Value.ToString().Trim() + '\r' + '\n';
                                                        }
                                                        else
                                                        {
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + lstrPropertyValue + '\r' + '\n';
                                                            //QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Label:-" + BtSubString.Name + " Value:-" + lstrPropertyValue);
                                                        }
                                                        y += 1;
                                                    }
                                                    i += 1;
                                                }
                                                //if (BtSubString.Name.ToUpper() == "LQTY")
                                                //{

                                                //    btNamedSubString += BtSubString.Name + '\r' + '\n' + DataGVItems.Rows[j].Cells["InvoiceLineQuantityOnLabel"].Value.ToString().Trim() + '\r' + '\n';
                                                //}
                                                string strDelimiter = string.Concat('\r', '\n');
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " String to be Printed:-" + btNamedSubString);
                                                BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);

                                                if (rdbInvoice.Checked == true)
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["InvoiceLineQuantityToPrint"].Value.ToString().Trim());
                                                }
                                                //quantity division for sales order Date :12/01/2014
                                                else if (rdbSO.Checked == true)
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["SalesOrderLineQuantityToPrint"].Value.ToString().Trim());
                                                    BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                                }
                                                if (rdbA.Checked == true && rdbPO.Checked == true) //for multiple po change qty to print
                                                {
                                                    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value.ToString().Trim());
                                                    BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                                }
                                                else if (rdbInvoice.Checked == false) 
                                                {
                                                    BtFormat.IdenticalCopiesOfLabel = 1;// Convert.ToInt32(intQuantity);
                                                }
                                                else
                                                {
                                                    BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                                }
                                                //else
                                                //{
                                                //    BtFormat.IdenticalCopiesOfLabel = 1;
                                                //}

                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  No Of copies to be printed:-" + intQuantity.ToString());
                                                BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Printer Name:-" + strProdPrinter.ToString());
                                                BtFormat.PrintOut(false, false);
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + "  Substring values are send to Bartender for printing...");
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
                                                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Bartender is closed.");
                                                QBHelper.WriteLog("--------------------------------------------------------------------------");
                                                foreach (Process clsProcess in Process.GetProcesses())
                                                {
                                                    if (clsProcess.ProcessName.StartsWith("bartender"))
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
                                                btnPrint.Enabled = true;
                                                
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Printing Error: " + "Please Select Label");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (rdbC.Checked == true)
                    {
                        BarTender.Application BtApp = null;
                        BarTender.Format BtFormat = null;
                        BarTender.SubString BtSubString = null;
                        string btNamedSubString = "";
                        int lintPrintedItemCount = 0;
                        try
                        {
                            if (CheckMandetory())
                            {
                                if (DataGVItems.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                                    {
                                        if (DataGVItems.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "False")
                                        {
                                            cntChk = cntChk + 1;
                                        }


                                        if (DataGVItems.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "True" && DataGVItems.Rows[i].Cells[1].Value.ToString().Trim() == "Y")
                                        {
                                            lintPrintedItemCount++;
                                        }
                                    }

                                    if (cntChk == DataGVItems.Rows.Count)
                                    {
                                        MessageBox.Show("Please Check At Least One Record To Print", "Label Connector");
                                        return;
                                    }

                                    DialogResult lobjDialogResult = DialogResult.Yes;
                                    if (lintPrintedItemCount > 0)
                                    {
                                        lobjDialogResult = MessageBox.Show("Item(s) selected for printing are already printed. Do you want to Re-Print?", "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                    if (lobjDialogResult == DialogResult.Yes)
                                    {
                                        int k = 1;
                                        foreach (Process clsProcess in Process.GetProcesses())
                                        {
                                            if (clsProcess.ProcessName.StartsWith("bartender"))
                                            {
                                                clsProcess.Kill();
                                                clsProcess.WaitForExit();
                                            }
                                        }
                                        BtApp = default(BarTender.ApplicationClass);
                                        BtFormat = default(BarTender.Format);
                                        BtSubString = default(BarTender.SubString);
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

                                        #region New Code

                                        foreach (XmlNode Node_loopVariable in appsettingNodes)
                                        {
                                            Node = Node_loopVariable;
                                            if (Node.Name == "add")
                                            {
                                                if (Node.Attributes.GetNamedItem("key").Value == "LabelPath")
                                                {
                                                    strProdLblPath = Node.Attributes.GetNamedItem("value").Value;
                                                }
                                                if (Node.Attributes.GetNamedItem("key").Value == "PrinterName")
                                                {
                                                    strProdPrinter = Node.Attributes.GetNamedItem("value").Value;
                                                }
                                            }
                                        }
                                        string strLabelName = cmbLabelName.Text;
                                        int intQuantity = 0;

                                        BtApp = new BarTender.ApplicationClass();
                                        BtFormat = new BarTender.Format();
                                        int j = 0;
                                        string strPropertyValue = string.Empty;

                                        this.Cursor = Cursors.WaitCursor;
                                        BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);

                                        int lintLastItemIndex = 0;
                                        int lintRowCount = DataGVItems.Rows.Count - 1;
                                        int[] lintarrSubstringIndex = new int[13];

                                        try
                                        {

                                            for (int lintSubstringIndex = 1; lintSubstringIndex <= 6; lintSubstringIndex++)
                                            {
                                                BtSubString = BtFormat.NamedSubStrings.GetSubString(lintSubstringIndex);
                                                if (lintLastItemIndex <= lintRowCount)
                                                {
                                                    for (int lintItemIndex = lintLastItemIndex; lintItemIndex <= lintRowCount; lintItemIndex++)
                                                    {
                                                        if (DataGVItems.Rows[lintItemIndex].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                                        {
                                                            strPropertyValue = GetPropertyValue(lintItemIndex, "InvoiceLineDesc");
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                            lintLastItemIndex = lintItemIndex + 1;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            strPropertyValue = " ";
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    strPropertyValue = " ";
                                                    btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                }
                                            }
                                            lintLastItemIndex = 0;
                                            for (int lintSubstringIndex = 7; lintSubstringIndex <= 12; lintSubstringIndex++)
                                            {
                                                BtSubString = BtFormat.NamedSubStrings.GetSubString(lintSubstringIndex);
                                                if (lintLastItemIndex <= lintRowCount)
                                                {
                                                    for (int lintItemIndex = lintLastItemIndex; lintItemIndex <= lintRowCount; lintItemIndex++)
                                                    {
                                                        if (DataGVItems.Rows[lintItemIndex].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                                        {
                                                            strPropertyValue = GetPropertyValue(lintItemIndex, "InvoiceLineItemRefFullName");
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                            lintLastItemIndex = lintItemIndex + 1;
                                                            //DataGVItems.Rows[lintItemIndex].Cells["PrintedStatus"].Value = "Y";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            strPropertyValue = string.Empty;
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    strPropertyValue = string.Empty;
                                                    btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                }
                                            }

                                            BtSubString = BtFormat.NamedSubStrings.GetSubString(13);
                                            strPropertyValue = Convert.ToString(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value);
                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';

                                            BtSubString = BtFormat.NamedSubStrings.GetSubString(14);
                                            strPropertyValue = string.Empty;
                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';

                                            BtSubString = BtFormat.NamedSubStrings.GetSubString(15);
                                            strPropertyValue = string.Empty;
                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';


                                            lintLastItemIndex = 0;
                                            for (int lintSubstringIndex = 16; lintSubstringIndex <= 21; lintSubstringIndex++)
                                            {
                                                BtSubString = BtFormat.NamedSubStrings.GetSubString(lintSubstringIndex);
                                                if (lintLastItemIndex <= lintRowCount)
                                                {
                                                    for (int lintItemIndex = lintLastItemIndex; lintItemIndex <= lintRowCount; lintItemIndex++)
                                                    {
                                                        if (DataGVItems.Rows[lintItemIndex].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                                        {
                                                            strPropertyValue = GetPropertyValue(lintItemIndex, "InvoiceLineQuantity");
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                            lintLastItemIndex = lintItemIndex + 1;
                                                            DataGVItems.Rows[lintItemIndex].Cells["PrintedStatus"].Value = "Y";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            strPropertyValue = string.Empty;
                                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    strPropertyValue = string.Empty;
                                                    btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';
                                                }
                                            }

                                            BtSubString = BtFormat.NamedSubStrings.GetSubString(22);
                                            strPropertyValue = Convert.ToString(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[1].Value);
                                            btNamedSubString += BtSubString.Name + '\r' + '\n' + strPropertyValue + '\r' + '\n';

                                            string strDelimiter = string.Concat('\r', '\n');

                                            BtFormat.NamedSubStrings.SetAll(btNamedSubString, strDelimiter);

                                            intQuantity = Convert.ToInt32(txtQtyToPrint.Text.Trim());
                                            if (intQuantity > 30)
                                            {
                                                intQuantity = 30;
                                            }

                                            BtFormat.IdenticalCopiesOfLabel = Convert.ToInt32(intQuantity);
                                            BtFormat.PrintOut(false, false);
                                        #endregion new code
                                        }
                                        catch (System.Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Label Connector");
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
                                                if (clsProcess.ProcessName.StartsWith("bartender"))
                                                {
                                                    clsProcess.Kill();
                                                    clsProcess.WaitForExit();
                                                }
                                            }
                                            System.Threading.Thread.Sleep(1000);
                                            this.Cursor = Cursors.Default;
                                        }
                                    }
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Label Connector");
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Select Label", "Label Connector");
                }
                btnClear.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrint.Enabled = false;
                btnClear.Enabled = true;
            }
        }
        
        private string GetPropertyValue(int pintItemIndex, string pstrSubStringName)
        {
            ArrayList alLineItem = null;
            clsPurchaseOrderLine objclsPurchaseOrderLine = null;
            clsSalesOrderLine objclsSalesOrderLine = null;
            clsInvoiceLine objclsInvoiceLine = null;
            Type objClsType;
            object strPropertyValue = null;

            if (rdbPO.Checked == true)
            {
                objclsPurchaseOrderLine = new clsPurchaseOrderLine();
                if (lstrQBFileMode == "Close")
                {
                    alLineItem = objclsPurchaseOrderLine.GetPOLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value,  lQBSessionManager, moQuickBooksAccountConfig);
                }
                else
                {
                    alLineItem = objclsPurchaseOrderLine.GetPOLine(string.Empty,txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["PurchaseOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                }
                objClsType = objclsPurchaseOrderLine.GetType();
            }
            else if (rdbSO.Checked == true)
            {
                objclsSalesOrderLine = new clsSalesOrderLine();
                objClsType = objclsSalesOrderLine.GetType();
                //out parameter added by khushal:date:01/24/13
                if (lstrQBFileMode == "Close")
                {
                    alLineItem = objclsSalesOrderLine.GetSOLine(Convert.ToString(DataGVItems.Rows[DataGVOrders.CurrentRow.Index].Cells["SalesOrderLineQuantityonLabel"].Value), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                }
                else
                {
                    alLineItem = objclsSalesOrderLine.GetSOLine(Convert.ToString(DataGVItems.Rows[DataGVOrders.CurrentRow.Index].Cells["SalesOrderLineQuantityonLabel"].Value), txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["SalesOrderLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells["CompanyName"].Value,string.Empty, out lobjDataExtension);
                }
            }
            else
            {
                objclsInvoiceLine = new clsInvoiceLine();
                if (lstrQBFileMode == "Close")
                {
                    //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                    alLineItem = objclsInvoiceLine.GetINVLine(string.Empty,Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineItemRefFullName"].Value), alData, alInvoiceLineItems, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value,  out lobjDataExtension, lQBSessionManager, moQuickBooksAccountConfig);
                }
                else
                {
                    //alLineItem = objclsInvoiceLine.GetINVLine(txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension);
                    alLineItem = objclsInvoiceLine.GetINVLine(string.Empty, Convert.ToString(DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells["InvoiceLineItemRefFullName"].Value), alData, alInvoiceLineItems, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[pintItemIndex].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value,InvoiceCustomerName, out lobjDataExtension, string.Empty, string.Empty);
                }
                objClsType = objclsInvoiceLine.GetType();
            }
            PropertyInfo objPropertyInfo = objClsType.GetProperty(pstrSubStringName);

            if (rdbPO.Checked == true)
            {
                strPropertyValue = objPropertyInfo.GetValue((clsPurchaseOrderLine)alLineItem[0], null);
            }
            else if (rdbSO.Checked == true)
            {
                strPropertyValue = objPropertyInfo.GetValue((clsSalesOrderLine)alLineItem[0], null);
            }
            else
            {
                strPropertyValue = objPropertyInfo.GetValue((clsInvoiceLine)alLineItem[0], null);
            }
            return strPropertyValue.ToString();
        }
        
        void pd_PrintPage(object sender, PrintPageEventArgs ppeArgs)
        {
            //Get the Graphics object
            Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            //Read margins from PrintPageEventArgs
            float leftMargin = 0;// ppeArgs.MarginBounds.Left;
            float topMargin = 0; //ppeArgs.MarginBounds.Top;
            string line = null;
            //Calculate the lines per page on the basis of the height of the page and the height of the font
            linesPerPage = ppeArgs.MarginBounds.Height /
            verdana10Font.GetHeight(g);
            //Now read lines one by one, using StreamReader
            while (count < linesPerPage &&
            ((line = reader.ReadLine()) != null))
            {
                //Calculate the starting position
                yPos = topMargin + (count *
                verdana10Font.GetHeight(g));
                //Draw text
                g.DrawString(line, verdana10Font, Brushes.Black,
                leftMargin, yPos, new StringFormat());
                //Move to next line
                count++;
            }
            //If PrintPageEventArgs has more pages to print
            if (line != null)
            {
                ppeArgs.HasMorePages = true;
            }
            else
            {
                ppeArgs.HasMorePages = false;
            }
        }

        string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
               // MessageBox.Show(settings.PrinterName);
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }       

        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();            
        }

        private int GetNextLabelQtyToPrint(int pintQuantity, ref int pintNumberOfLabelsToPrint)
        {
            int lintReminder=0;
            int lintQtyToPrintOnLabel = 0;
            try
            {
                for (int lintCounter = pintNumberOfLabelsToPrint - 1; lintCounter >= 1; lintCounter--)
                {
                    lintQtyToPrintOnLabel = Math.DivRem(pintQuantity, lintCounter, out lintReminder);
                    if (lintReminder == 0)
                    {
                        pintNumberOfLabelsToPrint = lintCounter;
                        return lintQtyToPrintOnLabel;
                    }
                }
                pintNumberOfLabelsToPrint = 1;
                return pintQuantity;
            }
            catch (Exception ex)
            {
                pintNumberOfLabelsToPrint =-1;
                return -1;
            }
        }

        private int GetPreviousLabelQtyToPrint(int pintQuantity, ref int pintNumberOfLabelsToPrint)
        {
            int lintReminder = 0;
            int lintQtyToPrintOnLabel = 0;
            try
            {
                for (int lintCounter = pintNumberOfLabelsToPrint + 1; lintCounter <= pintQuantity; lintCounter++)
                {
                    lintQtyToPrintOnLabel = Math.DivRem(pintQuantity, lintCounter, out lintReminder);
                    if (lintReminder == 0)
                    {
                        pintNumberOfLabelsToPrint = lintCounter;
                        return lintQtyToPrintOnLabel;
                    }
                }

                pintNumberOfLabelsToPrint = pintQuantity;
                return 1;
            }
            catch (Exception ex)
            {
                pintNumberOfLabelsToPrint = -1;
                return -1;
            }
        }

        int cnt = 0;
        private void DataGVItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int lintAllowedSelectedRows = 0;
            //below condition to check the checkbox status
            int intPrintQuantity = 0;
            int intInvoiceQty = 0;
            if (e.ColumnIndex == 0 && rdbd.Checked == true)
            {
                 CheckBoxStatusChecked();
                 EnableGridManually(DataGVItems);
                 checkboxcount(DataGVItems);
                    return;
                   
            }
              if (e.RowIndex != -1 && e.ColumnIndex!=-1)
              {
                  if (e.ColumnIndex != 0)
                  {
                      if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "+")
                      {
                          //Quantity adjustment for multiple sales order : Date : 12/01/2014
                          if (rdbSO.Checked == true && rdbA.Checked == true) //Adjustement for sales order
                          {
                              intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityToPrint"].Value);
                              intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantity"].Value);
                              txtQtyOnLabel.Text = GetPreviousLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantity"].Value), ref intPrintQuantity).ToString();
                              DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                              if (intInvoiceQty == 0 || intPrintQuantity == 0)
                                  DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityOnLabel"].Value = 0;
                              else
                                  DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                              txtQtyToPrint.Text = intPrintQuantity.ToString();

                          }
                          else //for invoice
                          {
                              intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value);
                              intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value);
                              txtQtyOnLabel.Text = GetPreviousLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value), ref intPrintQuantity).ToString();
                              DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                              if (intInvoiceQty == 0 || intPrintQuantity == 0)
                                  DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = 0;
                              else
                                  DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                              txtQtyToPrint.Text = intPrintQuantity.ToString();
                          }
                      }

                      if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "-")
                      {

                           //Quantity adjustment for multiple sales order : Date : 12/01/2014
                          if (rdbSO.Checked == true && rdbA.Checked == true) //Adjustement for sales order
                          {
                              intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityToPrint"].Value);
                              intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantity"].Value);
                              txtQtyOnLabel.Text = GetNextLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["SalesOrderLineQuantity"].Value), ref intPrintQuantity).ToString();
                              DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                              if (intInvoiceQty == 0 || intPrintQuantity == 0)
                                  DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityOnLabel"].Value = 0;
                              else
                                  DataGVItems.CurrentRow.Cells["SalesOrderLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                              txtQtyToPrint.Text = intPrintQuantity.ToString();

                          }
                          else //Adjustement for invoice
                          {

                              intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value);
                              intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value);
                              txtQtyOnLabel.Text = GetNextLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value), ref intPrintQuantity).ToString();
                              DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                              if (intInvoiceQty == 0 || intPrintQuantity == 0)
                                  DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = 0;
                              else
                                  DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                              txtQtyToPrint.Text = intPrintQuantity.ToString();
                          }
                      }
                      
                  }
                      //below condition added to check rdbd condtion
                      if (rdbA.Checked == true || rdbC.Checked == true || rdbd.Checked == true)
                      {
                          if (e.ColumnIndex == 0)
                          {
                              if (rdbC.Checked == true)
                                  lintAllowedSelectedRows = 6 > DataGVItems.Rows.Count ? DataGVItems.Rows.Count : 6;
                              else
                                  lintAllowedSelectedRows = DataGVItems.Rows.Count;

                              if (Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value) == "True")
                              {
                                  DataGVItems.CurrentRow.Cells[0].Value = "False";
                                  chkSelectAll.Checked = false;
                                  cnt--;
                                  if (cnt == 0)
                                  {
                                      btnPrint.Enabled = false;
                                  }
                              }
                              else
                              {
                                  DataGVItems.CurrentRow.Cells[0].Value = "True";
                                  cnt = 0;
                                  for (int i = 0; i < DataGVItems.Rows.Count; i++)
                                  {
                                      if (Convert.ToString(DataGVItems.Rows[i].Cells[0].Value) == "True")
                                      {
                                          btnPrint.Enabled = true;
                                          cnt = cnt + 1;
                                          if (cnt > lintAllowedSelectedRows)
                                          {
                                              DataGVItems.CurrentRow.Cells[0].Value = "False";
                                              MessageBox.Show("Only six lineitems selection is allowed in packaging option.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                              return;
                                          }
                                      }
                                  }
                                  if (cnt == lintAllowedSelectedRows)
                                  {
                                      chkSelectAll.Checked = true;
                                  }
                                  else
                                  {
                                      chkSelectAll.Checked = false;
                                  }
                              }
                          }

                          else
                          {
                              if (rdbC.Checked == false && rdbA.Checked == false)
                              {
                                  if (Convert.ToString(DataGVItems.CurrentRow.Cells[1].Value) == "")
                                  {
                                      txtQtyOnLabel.Text = "";
                                  }
                                  else
                                  {

                                      txtQtyOnLabel.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[1].Value);
                                  }
                              }
                              else if (rdbA.Checked == false)
                              {
                                  if (Convert.ToString(DataGVItems.CurrentRow.Cells[2].Value) == "")
                                  {
                                      txtQtyOnLabel.Text = "";
                                  }
                                  else
                                  {
                                      txtQtyOnLabel.Text = "1";
                                  }
                              }
                          }
                          // if (e.ColumnIndex == 3)
                          // { DataGVItems.ReadOnly = false; MessageBox.Show(Convert.ToString(DataGVItems.CurrentRow.Cells[3].Value)); }
                      }
                      else
                      {
                          //txtQtyOnLabel.Text = "1";//Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                          //txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                          txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value); //Srinivas changes on 26-Feb-2015 
                         txtQtyOnLabel.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                      }
              }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            lblfile1 = 0;
            frmLabelConfigTuchScreen objLable = frmLabelConfigTuchScreen.GetInstance();
            objLable.ShowDialog();
        }

        private bool CheckMandetory()
        {
            if (rdbB.Checked == true)
            {
                if (txtQtyOnLabel.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter quantity on label.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQtyOnLabel.Focus();
                    return false;
                }
                else if (txtQtyToPrint.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter quantity to print.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQtyToPrint.Focus();
                    return false;
                }
                else if (cmbLabelName.SelectedIndex == 0)
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
            else
            {
                if (cmbLabelName.SelectedIndex == 0)
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
        }

        public void fnGenerateLabelCB()
        {
            try
            {
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
                    string[] filenames = Directory.GetFiles(Folderpath, "*.btw");
                    int i = 0;
                    string filename = null;
                    for (i = 0; i <= filenames.Length - 1; i++)
                    {
                        filename = Path.GetFileName(filenames[i]);
                        // This is much better than relying on substring to be accurate
                        cmbLabelName.Items.Add(filename);
                        
                    }
                      if (mstrLabelName != string.Empty)
                        cmbLabelName.SelectedItem= mstrLabelName;
                    else
                        cmbLabelName.SelectedIndex = 0;
                }
                //if (lblfile1 == 0)
                //    cmbLabelName.SelectedIndex = 0;
                //else
                //{
                //    cmbLabelName.SelectedIndex = lblfile1;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        private void rdbInvoice_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbC.Enabled = true;
            rdbB.Checked = true;
        }

        private void cmbLabelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLabelName.SelectedIndex > 0)
            {
                btnPrint.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    Clear();
        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    Clear();
        //}

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
            //if (DataGVItems.Rows.Count > 0)
            //{
            //    if (chkSelectAll.Checked == true)
            //    {
            //        for (int i = 0; i < DataGVItems.Rows.Count; i++)
            //        {
            //            if (DataGVItems.Rows[i].Cells[1].Value != null)
            //            {
            //                DataGVItems.Rows[i].Cells[0].Value = "True";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < DataGVItems.Rows.Count; i++)
            //        {
            //            if (DataGVItems.Rows[i].Cells[1].Value.ToString().Trim() != "")
            //            {
            //                DataGVItems.Rows[i].Cells[0].Value = "False";
            //            }
            //        }
            //    }
            //}
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            int lintRowsSelected = 0;

            if (DataGVItems.Rows.Count > 0)
            {
                if (rdbC.Checked == true)
                    lintRowsSelected = DataGVItems.Rows.Count >= 6 ? 6 : DataGVItems.Rows.Count;
                else
                    lintRowsSelected = DataGVItems.Rows.Count;

                if (chkSelectAll.Checked == true)
                {
                    btnPrint.Enabled = true;
                    for (int i = 0; i < lintRowsSelected; i++)
                    {
                        //below condition added for checkbox rdbd
                        if (rdbA.Checked == true || rdbd.Checked==true)
                        {
                            DataGVItems.Rows[i].Cells[0].Value = "True";
                        }
                        else if (rdbC.Checked == true)
                        {
                            if (rdbInvoice.Checked == true)
                            {
                                if (DataGVItems.Rows[i].Cells[2].Value != null && DataGVItems.Rows[i].Cells[0].Value != null && DataGVItems.Rows[i].Cells[0].Value.ToString() == "False")
                                {
                                    if (cnt == 6)
                                        return;
                                    else
                                    {
                                        DataGVItems.Rows[i].Cells[0].Value = "True";
                                        cnt++;
                                    }
                                }
                                else
                                {
                                    DataGVItems.Rows[i].Cells[0].Value = "True";
                                }
                            }
                            else
                            {
                                if (DataGVItems.Rows[i].Cells[1].Value != null && DataGVItems.Rows[i].Cells[0].Value != null && DataGVItems.Rows[i].Cells[0].Value.ToString() == "False")
                                {
                                    if (cnt == 6)
                                        return;
                                    else
                                    {
                                        DataGVItems.Rows[i].Cells[0].Value = "True";
                                        cnt++;
                                    }
                                }
                                else
                                {
                                    DataGVItems.Rows[i].Cells[0].Value = "True";
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                    {
                        DataGVItems.Rows[i].Cells[0].Value = "False";
                    }
                    cnt = 0;
                    btnPrint.Enabled = false;
                }
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout lobjFrmAbout = new frmAbout();
            lobjFrmAbout.ShowDialog();
        }

        private void txtQtyToPrint_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyToPrint.Text!=string.Empty && Convert.ToInt32(txtQtyToPrint.Text) < 1)
            {
                MessageBox.Show("Quantity to print should be greater than zero.", "Label Connector");
                e.Cancel = true;
            }
            else
            {
                e.Cancel= false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout objfrmAbout = new frmAbout();
            objfrmAbout.ShowDialog();
        }

        //private void rdbC_CheckedChanged(object sender, EventArgs e)
        //{
        //    Clear();
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGVItems.Rows.Count; i++)
            {
                if (rdbA.Checked == true)
                {
                    DataGVItems.Rows[i].Cells["CheckBox"].Value = "False";
                }
                else if (rdbC.Checked == true)
                {
                    DataGVItems.Rows[i].Cells["CheckBox"].Value = "False";
                    DataGVItems.Rows[i].Cells["PrintedStatus"].Value = "N";
                }
            }
            chkSelectAll.Checked = false;
            cnt = 0;
            cmbLabelName.SelectedIndex = 0;
        }

        private void rdbA_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }

        private void rdbB_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }

        private void rdbC_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }

        private void rdbd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbd.Checked == true)
            {
                rdbSO.Checked = true;
                Clear();

            }

            
        }
        //if scan item is enter 
        private void txtcurrentscanitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                FillGridForSelectedRows();
                txtlastscanitem.Text = txtcurrentscanitem.Text;
                txtcurrentscanitem.Text = "";
                checkboxcount(DataGVItems);
                        
            }    

        }
        //Fill the rows for selected checkbox
        private void FillGridForSelectedRows()
        {
            string  strscanId="";
            DataGVItems.Rows[0].Selected = false;
            
            foreach (DataGridViewRow dgvr in DataGVItems.Rows)
            {
                strscanId = (Convert.ToString(dgvr.Cells[4].Value).Substring((Convert.ToString(dgvr.Cells[4].Value)).IndexOf(":") + 1));
                if (txtcurrentscanitem.Text.ToString().ToLower() == strscanId.ToLower())
                {
                    dgvr.Cells[0].Value = true;
                    dgvr.DefaultCellStyle.ForeColor = Color.Black;//selected row backcolor/forecolor
                    EnableGrid(DataGVItems);
                    chkSelectAll.Enabled = true;
                  
                   
                    break;
                
                }

                
            } 
        
        }
        //Disable grid record initially
        private void DisableGrid(DataGridView grid)
        {
            if (grid.Enabled == true) { grid.Enabled = false; }
            chkSelectAll.Enabled = false;
            grid.ForeColor = Color.Gray;
            foreach (DataGridViewColumn col in grid.Rows)
            {
                col.HeaderCell.Style.ForeColor = Color.Gray;
                
            }
        }
        //Toggle the checkbox status
        private void CheckBoxStatusChecked()
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)DataGVItems.Rows[DataGVItems.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;


            }
        
        
        }
        //Enable grid records when scan item is enter in textbox and press enter
        private void EnableGrid(DataGridView grid)
        {
           
            if (grid.Enabled == false) { grid.Enabled = true; }
            if (grid.ReadOnly == true) { grid.ReadOnly = false; }
               
            foreach (DataGridViewRow dgvr in DataGVItems.Rows)
            {
                 
                if (Convert.ToBoolean(dgvr.Cells[0].Value) == true)
                {
                   
                    grid[2, dgvr.Index].ReadOnly = false;

                    dgvr.DefaultCellStyle.ForeColor = Color.Black;
                    DataGVItems.CurrentCell = DataGVItems.Rows[dgvr.Index].Cells[2];
                    DataGVItems.BeginEdit(true);
                    
                    dgvr.Cells[2].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                     //break;
                    

                }
                else
                {
                    grid[2, dgvr.Index].ReadOnly = true;

                }
                                
            }
            
        }
        //This is to enable ToInvoice column to enter quantity
        private void DataGVItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 2 && e.ColumnIndex !=0 && e.ColumnIndex !=1)
            {
                e.Cancel = true;
            }
        }

        //To create inovoice for selected Items
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            
            bool blnInvoiceQty = false;
            lobjDataExtension = null;
            objInvoice = new clsInvoice();
            DialogResult result = new DialogResult();
            Hashtable objlastscanItem = new Hashtable();
            ArrayList alSOLineItems = new ArrayList();
            objlastscanItem.Clear();
            objSalesOrderLine = new clsSalesOrderLine();
            bool blnMessageShown =false;
            if (DataGVItems.Enabled == true)
            {

                foreach (DataGridViewRow dgvr in DataGVItems.Rows)
                {
                    if (Convert.ToBoolean(dgvr.Cells[0].Value) == true)
                    {
                        if (Convert.ToDouble(dgvr.Cells[1].Value) < Convert.ToDouble(dgvr.Cells[2].Value) && !blnMessageShown)
                        {
                            result = MessageBox.Show("To Invoice Quantity is greater than Sales Order Quantity.", "Label Connector", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            blnMessageShown = true;

                            if (result == DialogResult.OK)
                            {
                                blnInvoiceQty = true;
                                objlastscanItem.Add(dgvr.Cells[4].Value.ToString().Trim(), Convert.ToDouble(dgvr.Cells[2].Value));
                            }
                        }
                        else 
                        {
                            blnInvoiceQty = true;
                            objlastscanItem.Add(dgvr.Cells[4].Value.ToString().Trim(), Convert.ToDouble(dgvr.Cells[2].Value));                        
                        }
                    }
                }

                if (blnInvoiceQty)
                {
                        if (objlastscanItem.Count > 0)
                        {
                            if (lstrQBFileMode == "Close")
                            {
                                alSOLineItems = objSalesOrderLine.GetSOLine(objSalesOrder.RefNumber, lQBSessionManager, moQuickBooksAccountConfig);
                                objInvoice.CreateSalesInvoice(alSOLineItems, objlastscanItem, lQBSessionManager, moQuickBooksAccountConfig);
                            }
                            else
                            {
                                alSOLineItems = objSalesOrderLine.GetSOLine(objSalesOrder.RefNumber,string.Empty);
                                objInvoice.CreateSalesInvoice(alSOLineItems, objlastscanItem);
                            }
                        }
                        else
                            MessageBox.Show("Please select the Invoice Item.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
       }
        //Enable Grid record manually by checking the checkbox 
        private void EnableGridManually(DataGridView grid)
        {
            
            bool blnvar = false;
            if (grid.Enabled == false) { grid.Enabled = true; }
            if (grid.ReadOnly == true) { grid.ReadOnly = false; }

           
            foreach (DataGridViewRow Row in DataGVItems.Rows)
            {
               
                    blnvar = Convert.ToBoolean(DataGVItems[0, Row.Index].Value);

                    if (blnvar)
                    {
                        grid[2, Row.Index].ReadOnly = false;

                        Row.DefaultCellStyle.ForeColor = Color.Black;

                        DataGVItems.CurrentCell = DataGVItems.Rows[Row.Index].Cells[2];
                        DataGVItems.BeginEdit(true);
                        Row.Cells[2].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                       

                    }
                    else
                    {                       
                        grid[2, Row.Index].ReadOnly = true;
                        Row.Cells[2].Style.Font = new Font("Times New Roman", 12, FontStyle.Regular);                                                            
                    }
                 
            }
           

        }
        //clear the selected check boxes and  lastscanitem
        private void btnitemclear_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow Row in DataGVItems.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[0].Value) == true)
                {
                    Row.Cells[0].Value= false;
                    Row.Cells[2].Style.Font = new Font("Times New Roman", 9, FontStyle.Regular);
                }
            }
            if (txtlastscanitem.Text != null || txtlastscanitem.Text != "") { txtlastscanitem.Text = ""; }
        }
        //To ensure ToInvoice cell conatain valid numeric value.
        private void DataGVItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewTextBoxCell cell = DataGVItems[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
            if (e.ColumnIndex == 2)
            {
                if (cell != null && rdbd.Checked==true)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("Please enter digits only", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }
        //Handle enter key on GetOrder button
        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13))) { btnGetOrder_Click(sender, e); } 

        }


        private void checkboxcount(DataGridView dgv)
        {
            int chkcount=0;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells[0].Value) == true)
                {
                    chkcount +=1;
                }
             }
             if (dgv.Rows.Count == chkcount)
                 chkSelectAll.Checked = true;
        }
        
        private void quickBooksSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelConnector.LabelConnectorSettingsTuchScreen lobjLabelConnectorSettings = new LabelConnector.LabelConnectorSettingsTuchScreen();
            lobjLabelConnectorSettings.ShowDialog();
        }

        private void cmbLabelPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbLabelPrinter.SelectedItem.ToString()!="Select Printer")
                SetDefaultPrinter(cmbLabelPrinter.SelectedItem.ToString());
        }

        private void selectPCScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            lobjQBConfiguration.SaveScreenSettings(true);
        }

        private void selectTouchScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            lobjQBConfiguration.SaveScreenSettings(false);
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLabelConfigTuchScreen objLable = frmLabelConfigTuchScreen.GetInstance();
            objLable.ShowDialog();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Clear();
            txtOrderNumber.Text = string.Empty;
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataAccessSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelConnector.QBDataAccessSetting lobjQBDataAccessSettings = new LabelConnector.QBDataAccessSetting();
            lobjQBDataAccessSettings.ShowDialog();
        }

        private void DataGVItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int lintAllowedSelectedRows = 0;
            //below condition to check the checkbox status
            int intPrintQuantity = 0;
            int intInvoiceQty = 0;
            if (e.ColumnIndex == 0 && rdbd.Checked == true)
            {
                CheckBoxStatusChecked();
                EnableGridManually(DataGVItems);
                checkboxcount(DataGVItems);
                return;

            }
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex != 0)
                {
                    if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "+")
                    {
                        intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value);
                        intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value);
                        txtQtyOnLabel.Text = GetPreviousLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value), ref intPrintQuantity).ToString();
                        DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                        if (intInvoiceQty == 0 || intPrintQuantity == 0)
                            DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = 0;
                        else
                            DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                        txtQtyToPrint.Text = intPrintQuantity.ToString();
                    }

                    if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "-")
                    {
                        intPrintQuantity = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value);
                        intInvoiceQty = Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value);
                        txtQtyOnLabel.Text = GetNextLabelQtyToPrint(Convert.ToInt32(DataGVItems.CurrentRow.Cells["InvoiceLineQuantity"].Value), ref intPrintQuantity).ToString();
                        DataGVItems.CurrentRow.Cells["InvoiceLineQuantityToPrint"].Value = Convert.ToString(intPrintQuantity);

                        if (intInvoiceQty == 0 || intPrintQuantity == 0)
                            DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = 0;
                        else
                            DataGVItems.CurrentRow.Cells["InvoiceLineQuantityOnLabel"].Value = Convert.ToString(intInvoiceQty / intPrintQuantity);

                        txtQtyToPrint.Text = intPrintQuantity.ToString();
                    }

                }
                //below condition added to check rdbd condtion
                if (rdbA.Checked == true || rdbC.Checked == true || rdbd.Checked == true)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (rdbC.Checked == true)
                            lintAllowedSelectedRows = 6 > DataGVItems.Rows.Count ? DataGVItems.Rows.Count : 6;
                        else
                            lintAllowedSelectedRows = DataGVItems.Rows.Count;

                        if (Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value) == "True")
                        {
                            DataGVItems.CurrentRow.Cells[0].Value = "False";
                            chkSelectAll.Checked = false;
                            cnt--;
                            if (cnt == 0)
                            {
                                btnPrint.Enabled = false;
                            }
                        }
                        else
                        {
                            DataGVItems.CurrentRow.Cells[0].Value = "True";
                            cnt = 0;
                            for (int i = 0; i < DataGVItems.Rows.Count; i++)
                            {
                                if (Convert.ToString(DataGVItems.Rows[i].Cells[0].Value) == "True")
                                {
                                    btnPrint.Enabled = true;
                                    cnt = cnt + 1;
                                    if (cnt > lintAllowedSelectedRows)
                                    {
                                        DataGVItems.CurrentRow.Cells[0].Value = "False";
                                        MessageBox.Show("Only six lineitems selection is allowed in packaging option.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            if (cnt == lintAllowedSelectedRows)
                            {
                                chkSelectAll.Checked = true;
                            }
                            else
                            {
                                chkSelectAll.Checked = false;
                            }
                        }
                    }

                    else
                    {
                        if (rdbC.Checked == false && rdbA.Checked == false)
                        {
                            if (Convert.ToString(DataGVItems.CurrentRow.Cells[1].Value) == "")
                            {
                                txtQtyOnLabel.Text = "";
                            }
                            else
                            {

                                txtQtyOnLabel.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[1].Value);
                            }
                        }
                        else if (rdbA.Checked == false)
                        {
                            if (Convert.ToString(DataGVItems.CurrentRow.Cells[2].Value) == "")
                            {
                                txtQtyOnLabel.Text = "";
                            }
                            else
                            {
                                txtQtyOnLabel.Text = "1";
                            }
                        }
                    }
                    // if (e.ColumnIndex == 3)
                    // { DataGVItems.ReadOnly = false; MessageBox.Show(Convert.ToString(DataGVItems.CurrentRow.Cells[3].Value)); }
                }
                else
                {
                    //txtQtyOnLabel.Text = "1";//Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                    //txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                    txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value); //Srinivas changes on 26-Feb-2015 
                    txtQtyOnLabel.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                }
            }
            else
            {
                //txtQtyOnLabel.Text = "1";//Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                //txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
                txtQtyToPrint.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value); //Srinivas changes on 26-Feb-2015 
                txtQtyOnLabel.Text = Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value);
            }
        }

        private void btnfilterlabel_Click(object sender, EventArgs e)
        {

            int intError = 0;

            lobjQBConfiguration = new QBConfiguration();

            ArrayList lobjCustomFieldCheck = new ArrayList();
            //if (txtOrderNumber.Text != null || txtOrderNumber.Text != "")
            if (txtOrderNumber.Text.Trim() != "")
            {
                if (DataGVItems.Rows.Count > 0)
                {
                    if (rdbB.Checked == true)
                    {
                        cellindex = 4;
                    }
                    else
                    {
                        cellindex = 9;
                    }
                    lstrFilterDisplay = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FilterDisplay");
                    //find label cutsom field and match value to 'No'
                    //check condtion for open or close QuickBook Connection
                    if (lstrFilterDisplay != "")
                    {
                        //MessageBox.Show("FilterValue : " + lstrFilterDisplay, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstrQBFileMode = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode");
                        if (lstrQBFileMode == "Close")
                        {
                            lobjCustomFieldCheck = objInvoiceLine.FilterCustomField(txtOrderNumber.Text, lstrFilterDisplay, lQBSessionManager, moQuickBooksAccountConfig);
                        }
                        else
                        {
                            lobjCustomFieldCheck = objInvoiceLine.FilterCustomField(txtOrderNumber.Text, lstrFilterDisplay);
                        }

                        if (lobjCustomFieldCheck != null && lobjCustomFieldCheck.Count > 0)
                        {
                            intGridRowCount1 = Convert.ToInt32(DataGVItems.Rows.Count);
                            foreach (clsInvoiceLine objInvItem in lobjCustomFieldCheck)
                            {
                                if (objInvItem.IsValueFound)
                                {
                                    lstrTxnLineId = objInvItem.InvoiceLineTxnLineID.ToString();
                                    //Delete record from DataGrid base on InvoiceLineTxnLineID
                                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                                    {
                                        if (Convert.ToString(DataGVItems.Rows[i].Cells[cellindex].Value) == lstrTxnLineId.Trim())
                                        {
                                            DataGVItems.Rows.RemoveAt(i);

                                        }
                                    }

                                }
                            }
                            intGridRowCount2 = Convert.ToInt32(DataGVItems.Rows.Count);
                        }
                        if (intGridRowCount1 == intGridRowCount2)
                        {
                            intError = 3;
                        }
                        else
                        {
                            intError = 4;
                        }
                    }
                    if (intError == 0)
                        intError = 2;
                }
                if (intError == 0)
                    intError = 1;
            }
            if (intError == 0)
                intError = 1;
            if (intError == 1)
            {
                MessageBox.Show("Please Get Invoice data and then filter", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (intError == 2)
            {
                MessageBox.Show("Filter Value in App Config file is Blank. Please set filter value", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (intError == 3)
            {
                MessageBox.Show("Filter value in settings not found in QuickBooks", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (intError == 4)
            {
                //MessageBox.Show("No. of Item filtered: " & intGridRowCount1 - intGridRowCount2, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrintWL_Click(object sender, EventArgs e)
        {
            if (cmbLabelPrinter.SelectedIndex > 0)
            {
                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Printing Started...");
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.StartsWith("bartender"))
                    {
                        clsProcess.Kill();
                        clsProcess.WaitForExit();
                    }
                }
                BarTender.Application BtApp = default(BarTender.Application);
                BarTender.Format BtFormat = default(BarTender.Format);
                BarTender.SubString BtSubString = default(BarTender.SubString);
                
                string btNamedSubString = "";
                string strPrintQuery = "";
                //Dim strProdLblPath As String = System.Configuration.ConfigurationManager.AppSettings("LabelPath").ToString()
                string strProdLblPath = "";
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
                int intQuantity = 0;
                string lstrPropertyValue = string.Empty;
                string QuantityToPrintOnLabel = string.Empty;

                BtApp = new BarTender.ApplicationClass();
                QBHelper.WriteLog("LabelConnector:Time:-" + DateTime.Now.ToString() + " Batrender Object is Created...");
                BtFormat = new BarTender.Format();
                // ----------- Code Start Printing Weather Label -----------------

                if (ckbWeatherLabel.Checked == true)
                {
                    int k = 1;
                    BtFormat = BtApp.Formats.Open(strWeatherLabel, true, strProdPrinter);
                    while (k <= BtFormat.NamedSubStrings.Count)
                    {
                        BtSubString = BtFormat.NamedSubStrings.GetSubString(k);

                        if (BtSubString.Name == "ShipAddressAddr1") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblStoreNameValue.Text.ToString() + '\r' + '\n';
                        if (BtSubString.Name == "RefNumber") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblInvoiceNumberValue.Text.ToString() + '\r' + '\n';
                        if (BtSubString.Name == "LowTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblLowTempValue.Text.ToString() + '\r' + '\n';
                        if (BtSubString.Name == "HighTemp") btNamedSubString += BtSubString.Name + '\r' + '\n' + lblHighTempValue.Text.ToString() + '\r' + '\n';
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
                }

                btNamedSubString = "";
                BtFormat.Close();
                BtApp.Quit();

                //------------Code End for Printing Weather Label---------------

            }

            else
            {
                MessageBox.Show("Select Printer to Print the label", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }
            

        }

        private void ckbWeatherLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWeatherLabel.Checked == true)
            {
                btnPrintWL.Enabled = true;
            }
            else
            {
                btnPrintWL.Enabled = false;
            }
        }

        private void weatherOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (System.Windows.Forms.Application.OpenForms["FrmPrintWeatherOnlyTouchScreen"] == null)
            {
                LabelConnector.FrmPrintWeatherOnlyTouchScreen lobjLabelConnectorSettings = new LabelConnector.FrmPrintWeatherOnlyTouchScreen();
                pnlhead.Visible = false;
                lobjLabelConnectorSettings.Text = "Invoice Weather Only";
                lobjLabelConnectorSettings.WeatherOnlyOption = 1;
                lobjLabelConnectorSettings.MdiParent = this;
                lobjLabelConnectorSettings.Dock = DockStyle.Fill;
                lobjLabelConnectorSettings.Show();
            }

        }

        private void chkSelectAll_Click_1(object sender, EventArgs e)
        {
            int lintRowsSelected = 0;

            if (DataGVItems.Rows.Count > 0)
            {
                if (rdbC.Checked == true)
                    lintRowsSelected = DataGVItems.Rows.Count >= 6 ? 6 : DataGVItems.Rows.Count;
                else
                    lintRowsSelected = DataGVItems.Rows.Count;

                if (chkSelectAll.Checked == true)
                {
                    btnPrint.Enabled = true;
                    for (int i = 0; i < lintRowsSelected; i++)
                    {
                        //below condition added for checkbox rdbd
                        if (rdbA.Checked == true || rdbd.Checked == true)
                        {
                            DataGVItems.Rows[i].Cells[0].Value = "True";
                        }
                        else if (rdbC.Checked == true)
                        {
                            if (rdbInvoice.Checked == true)
                            {
                                if (DataGVItems.Rows[i].Cells[2].Value != null && DataGVItems.Rows[i].Cells[0].Value != null && DataGVItems.Rows[i].Cells[0].Value.ToString() == "False")
                                {
                                    if (cnt == 6)
                                        return;
                                    else
                                    {
                                        DataGVItems.Rows[i].Cells[0].Value = "True";
                                        cnt++;
                                    }
                                }
                                else
                                {
                                    DataGVItems.Rows[i].Cells[0].Value = "True";
                                }
                            }
                            else
                            {
                                if (DataGVItems.Rows[i].Cells[1].Value != null && DataGVItems.Rows[i].Cells[0].Value != null && DataGVItems.Rows[i].Cells[0].Value.ToString() == "False")
                                {
                                    if (cnt == 6)
                                        return;
                                    else
                                    {
                                        DataGVItems.Rows[i].Cells[0].Value = "True";
                                        cnt++;
                                    }
                                }
                                else
                                {
                                    DataGVItems.Rows[i].Cells[0].Value = "True";
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                    {
                        DataGVItems.Rows[i].Cells[0].Value = "False";
                    }
                    cnt = 0;
                    btnPrint.Enabled = false;
                }
            }

        }
        public void DisposeAllButThis()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Close();
                }
            }


        }
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeAllButThis();
        }

        private void salesOrderWeatherOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (System.Windows.Forms.Application.OpenForms["FrmPrintWeatherOnlyTouchScreen"] == null)
            {
                LabelConnector.FrmPrintWeatherOnlyTouchScreen lobjLabelConnectorSettings = new LabelConnector.FrmPrintWeatherOnlyTouchScreen();
                pnlhead.Visible = false;
                lobjLabelConnectorSettings.WeatherOnlyOption = 2;
                lobjLabelConnectorSettings.Text = "Sales Order Weather Only";
                lobjLabelConnectorSettings.MdiParent = this;
                lobjLabelConnectorSettings.Dock = DockStyle.Fill;
                lobjLabelConnectorSettings.Show();
            }
            
        }

        private void activToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsLicenseChecker.IsRun())
            {
                license_state licenseState = license_state.LICENSE_UNKNOW;
                try
                {
                    licenseState = clsLicenseChecker.checkLicense(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                switch (licenseState)
                {
                    case license_state.LICENSE_ERROR_MAIN:
                        MessageBox.Show("The license is not confirmed. The program will be closed.", "Error of lnsMain.dll", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetConfirm(false);
                        this.Close();
                        break;
                    case license_state.LICENSE_ERROR:
                        MessageBox.Show("The license is not confirmed. The program will be closed.", "Error of lns.dll", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetConfirm(false);
                        this.Close();
                        break;
                    case license_state.LICENSE_EXPIRED:
                        MessageBox.Show("The license has expired. The program will be closed.", "License expired!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetConfirm(false);
                        this.Close();
                        break;
                    case license_state.LICENSE_OK:
                        this.SetTextLicenseMenuItem(false);
                        break;
                    case license_state.LICENSE_TRIAL:
                        this.SetTextLicenseMenuItem(true);
                        break;
                    case license_state.LICENSE_FREE:
                        MessageBox.Show("The license has been successfully undocked. The next application run with the same license key will attach this license to another computer, on which the program will be launched.", "License status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetConfirm(false);
                        this.Close();
                        break;
                    case license_state.LICENSE_UNKNOW:
                        MessageBox.Show("Failed license status determination.", "License status unknown", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetConfirm(false);
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("The license verification process is invaluable now. Please, try later.", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }

    public class DataGridViewCustomButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewCustomButtonColumn()
        {
            this.CellTemplate = new DataGridViewCustomButtonCell();
            this.Width = 20;
        }
    }

    public class DataGridViewCustomButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied. 
        public override object Clone()
        {
            DataGridViewCustomButtonCell cell =
                (DataGridViewCustomButtonCell)base.Clone();
            cell.Style.Font = new Font("Verdana", 28);
            cell.Enabled = this.Enabled;
            return cell;
        }
        
        // By default, enable the button cell. 
        public DataGridViewCustomButtonCell()
        {
            this.enabledValue = true;
            this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,   
            // background, and disabled button for the cell. 
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified. 
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified. 
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;
                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,PushButtonState.Disabled);

                // Draw the disabled button text.  
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class  
                //handle the painting. 
                cellStyle.Font = new Font("Verdana", 28);
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}