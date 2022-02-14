using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using BarTender;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.Threading;
using System.Collections;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Linq;
using System.Data.Linq;
using QBLC;
using System;

namespace LabelConnector
{
    public partial class FrmReceiptList : Form
    {
        frmLabelConfig objfrmLabel = frmLabelConfig.GetInstance();
        string printTempName = "";
        public FrmReceiptList()
        {
            InitializeComponent();
            this.AcceptButton = this.btnSearchReceipts;
            objfrmLabel.objdelOrderType += new delOrderType(this.fnSetPrinterType);
            this.Text = "Label Connector-Receipt";

            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Label Connector-Receipt";
            dateTimePicker1.Value = DateTime.Now.AddDays(-5);
            dateTimePicker2.Value = DateTime.Now.AddDays(0);
        }

        clsPurchaseOrderLine lobjvendorlist = new clsPurchaseOrderLine();
        clsTemplateLabelXmlwork lobjporeceiptTemplatexml = new clsTemplateLabelXmlwork();
        ArrayList arrReceiptCustomItems = new ArrayList();
        QBConfiguration lobjQBConfiguration;
        clsPurchaseOrderLine objPurchaseOrderLine;
        clsPurchaseOrder objPurchaseOrder;
        Dictionary<string, string> lobjDataExtension;
        string filePath = "";
        int uncheckcount = 0;
        int checkcount = 0;
        int receiptpagingindex = 0;
        long transID = 0;
        string strStartupPath = string.Empty;
        int dateindex = 0;
        DateTime dtfrom = new DateTime();
        DateTime dtto = new DateTime();
        List<long> distinctrecord = new List<long>();
        List<long> lntRecCount = new List<long>();
        int cntnextrecord = 0;
        int cntnextrecord1 = 0;
        ArrayList alData;
        List<clsPurchaseOrderLine> lobjclsReceiptdata = new List<clsPurchaseOrderLine>();

        List<clsPurchaseOrderLine> lobjclsPurchaseOrderLine = new List<clsPurchaseOrderLine>();
        List<QBLC.clsPurchaseOrder.FilterReceiptTransDate> txndatelist = new List<QBLC.clsPurchaseOrder.FilterReceiptTransDate>();
        List<QBLC.clsPurchaseOrderLine.ReceiptItemCustomValues> lobjReceiptDataExtension = new List<QBLC.clsPurchaseOrderLine.ReceiptItemCustomValues>();
        List<QBLC.clsPurchaseOrderLine.ReceiptItemCustomValues> lobjReceiptDataExtensioncopy = new List<QBLC.clsPurchaseOrderLine.ReceiptItemCustomValues>();
        string poErrormessage;
        private void FrmReceiptList_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();
        }

        private void FrmReceiptList_Load(object sender, EventArgs e)
        {

            lobjQBConfiguration = new QBConfiguration();
            //objPurchaseOrderLine = new clsPurchaseOrderLine();
            DataGVItems.Visible = false;
            gbnavigation.Visible = false;
            //chkreceiptall.Visible = false;
            chkSelectAll.Visible = false;
            lblprintheader.Visible = false;
            gbOrderDetail.Visible = false;
            // lblreceiptheader.Visible = false;
            using (new HourGlass())
            {

                //Load Vendors from xml

                strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");

                if (!File.Exists(strStartupPath + "QuickBookVendors.xml"))
                {
                    MessageBox.Show("Please Sync Vendors", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ReadSyncVendors(strStartupPath);

                //var objvendorlist = lobjvendorlist.GetVendorList();

                //cmbvendor.Items.Add("-------Select Vendor-------");

                //if (objvendorlist != null)
                //{
                //    for (int ndxvendor = 0; ndxvendor < objvendorlist.Count; ndxvendor++)
                //    {
                //        cmbvendor.Items.Add(objvendorlist[ndxvendor].ToString());

                //    }

                //}

                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("VendorName")))
                {

                    cmbvendor.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("VendorName");

                }
                else
                {
                    cmbvendor.SelectedIndex = 0;

                }
            }
        }

        private void txtponumber_TextChanged(object sender, EventArgs e)
        {
            DataGVItems.Visible = false;
            chkSelectAll.Visible = false;
            lblprintheader.Visible = false;
            gbOrderDetail.Visible = false;
            gbnavigation.Visible = false;

            if (txtponumber.Text.Length > 0)
            {
                if (!string.IsNullOrWhiteSpace(txtponumber.Text.ToString()))
                {
                    cmbvendor.Enabled = false;
                    // lobjclsPurchaseOrderLine.Clear(); //receipt
                    //lntRecCount.Clear();

                }
                else
                {
                    cmbvendor.Enabled = true;
                }
            }
            else
            {

                cmbvendor.Enabled = true;
            }


        }

        private void cmbvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbvendor.SelectedIndex > 0)
            {
                txtponumber.Enabled = false;

            }
            else
            {
                txtponumber.Enabled = true;
            }

            DataGVItems.Visible = false;
            chkSelectAll.Visible = false;
            lblprintheader.Visible = false;
            gbOrderDetail.Visible = false;
            gbnavigation.Visible = false;

            //btnNext.Enabled = false;
            //btnPrevious.Enabled = false;
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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }

        }

        private void btnSearchReceipts_Click(object sender, EventArgs e)
        {
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lobjQBConfiguration = new QBConfiguration();
            receiptpagingindex = 0;
            cntnextrecord = 0;
            lntRecCount.Clear();
            // lobjclsPurchaseOrderLine.Clear();
            lobjclsReceiptdata.Clear();
            distinctrecord.Clear();
            lobjReceiptDataExtensioncopy.Clear();

            if (string.IsNullOrWhiteSpace(txtponumber.Text.ToString()) && cmbvendor.SelectedIndex == 0)
            {

                MessageBox.Show("Please enter po number or select vendor", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtponumber.Focus();
                return;
            }


            if (DataGVItems.Rows.Count == 0)
            {
                AddPrinters();
                //Set printer Setting
                if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") != "Screen")
                {

                    //from setting common printer
                    cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter");
                    cmbLabelPrinter.Enabled = false;

                }
                else
                {
                    //from setting screen

                    cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ItemScreenPrinter");
                    //if (string.IsNullOrWhiteSpace(txtponumber.Text.ToString()))
                    //{
                    //    cmbvendor.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("VendorName"); //set vendor as selected
                    //}
                    //cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel"); //set Label as selected

                    cmbLabelPrinter.Enabled = true;
                }

                //fnGenerateLabelCB();
                //Get print mode type for barcode or user defined label
                if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                {
                    fnGenerateLabelCB();
                }
                else
                {
                    fnGetUDFLabels();
                }



            }

            objPurchaseOrder = new clsPurchaseOrder();
            objPurchaseOrderLine = new clsPurchaseOrderLine();
            alData = new ArrayList();


            //search receipt by DateRange
            string lstrSearchText = string.Empty;
            //**new code**//
            try
            {
                using (new HourGlass())
                {
                    //Get Item Reciept within DateRange selected
                    //Get All Item Receipts
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = System.Windows.Forms.Application.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = System.Windows.Forms.Application.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    lobjclsPurchaseOrderLine = objPurchaseOrderLine.GetReceiptsByDateRange(dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString(), out lobjReceiptDataExtension); //31-oct-2017
                                                                                                                                                                                            //lobjclsPurchaseOrderLine = objPurchaseOrderLine.GetReceiptsByDateRangeNew(dateTimePicker1.Text.ToString(), dateTimePicker2.Text.ToString(), out lobjReceiptDataExtension); //31-oct-2017
                    if (lobjclsPurchaseOrderLine.Count > 0)
                    {
                        lobjReceiptDataExtensioncopy = lobjReceiptDataExtension; //fill receipt custom data //31-oct-2017

                        //filter ItemReceipt Vendor
                        if (cmbvendor.SelectedIndex > 0)
                        {
                            lstrSearchText = cmbvendor.SelectedItem.ToString(); //search text
                        }
                        else
                        {
                            lstrSearchText = txtponumber.Text.ToString();
                        }

                        lobjclsReceiptdata = (from receiveItems in lobjclsPurchaseOrderLine
                                              where receiveItems.VendorRefFullName == lstrSearchText || receiveItems.RefNumber == lstrSearchText
                                              orderby receiveItems.POReceivedItemCreatedTime descending
                                              select receiveItems).ToList();
                        if (lobjclsReceiptdata.Count > 0)
                        {

                            var MaxTxnID = (from d in lobjclsReceiptdata select d.TransID).Max();

                            var objTopreceiveItem = (from receiveItems in lobjclsPurchaseOrderLine
                                                     where receiveItems.TransID == MaxTxnID && receiveItems.RecQty > 0 //codition added to remove zero qty from receipts (&& receiveItems.RecQty > 0)
                                                     orderby receiveItems.POReceivedItemCreatedTime descending
                                                     select receiveItems).ToList();

                            foreach (var item in lobjclsReceiptdata)
                            {
                                lntRecCount.Add(item.TransID);
                            }


                            //distinctrecord = lntRecCount.Distinct().Reverse().ToList();
                            distinctrecord = lntRecCount.Distinct().ToList();
                            cntnextrecord1 = distinctrecord.Count();


                            btnNext.Enabled = true; //receipt
                            btnPrevious.Enabled = false; //receipt

                            DataGVItems.Visible = true;
                            chkSelectAll.Visible = true;
                            lblprintheader.Visible = true;
                            DataGVItems.Rows.Clear();
                            DataGVItems.Columns.Clear();
                            InitGrid();


                            FillPOReceiptItemsGrid(objTopreceiveItem);
                            if (cntnextrecord1 > 1)
                            {
                                gbnavigation.Visible = true;

                                btnNext.Enabled = true;
                            }
                            else
                            {
                                gbnavigation.Visible = false;
                            }


                            if (DataGVItems.Rows.Count > 0)
                            {
                                DataGVItems.Rows[0].Selected = true;


                                chkSelectAll.Checked = true;

                                chkSelectAll_Click(null, null);
                                gbOrderDetail.Visible = true;

                                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel"))) // 27-Oct-2017
                                {

                                    //cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel");
                                    cmbLabelName.SelectedIndex = 0;
                                }
                                else
                                {
                                    cmbLabelName.SelectedIndex = 0;

                                }
                                string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath")));
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
                        else
                        {
                            DataGVItems.Visible = false;
                            gbOrderDetail.Visible = false;
                            chkSelectAll.Visible = false;
                            lblprintheader.Visible = false;
                            MessageBox.Show("Item receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtponumber.Focus();


                        }


                    }
                    else
                    {

                        DataGVItems.Visible = false;
                        gbOrderDetail.Visible = false;
                        chkSelectAll.Visible = false;
                        lblprintheader.Visible = false;
                        MessageBox.Show("Item receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtponumber.Focus();


                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return;
            }

            //code commented before adding daterange search
            //if (cmbvendor.SelectedIndex > 0) //Search receipt by vendor
            //{
            //    using (new HourGlass())
            //    {
            //        //Get All Item Receipts

            //        lobjclsPurchaseOrderLine = objPurchaseOrderLine.GetAllItemReceipts(cmbvendor.SelectedItem.ToString(), out lobjReceiptDataExtension);

            //        if (lobjclsPurchaseOrderLine.Count > 0)
            //        {
            //            lobjReceiptDataExtensioncopy = lobjReceiptDataExtension;
            //            btnPrevious.Enabled = true; //receipt
            //            btnNext.Enabled = true;// receipt

            //            DataGVItems.Visible = true;
            //            chkSelectAll.Visible = true;
            //            lblprintheader.Visible = true;
            //            DataGVItems.Rows.Clear();
            //            DataGVItems.Columns.Clear();
            //            InitGrid();

            //            var objreceiveItemsbyvendor = (from receiveItems in lobjclsPurchaseOrderLine
            //                                           orderby receiveItems.POReceivedItemCreatedTime descending
            //                                           select receiveItems).ToList();



            //            var MaxTxnID = (from d in objreceiveItemsbyvendor select d.TransID).Max();






            //            var objTopreceiveItem = (from receiveItems in lobjclsPurchaseOrderLine
            //                                     where receiveItems.TransID == MaxTxnID
            //                                     orderby receiveItems.POReceivedItemCreatedTime descending
            //                                     select receiveItems).ToList();



            //            foreach (var item in lobjclsPurchaseOrderLine)
            //            {
            //                lntRecCount.Add(item.TransID);
            //            }


            //            distinctrecord = lntRecCount.Distinct().Reverse().ToList();

            //            cntnextrecord = distinctrecord.Count();


            //            FillPOReceiptItemsGrid(objTopreceiveItem);

            //            if (cntnextrecord > 1)
            //            {
            //                gbnavigation.Visible = true;
            //                btnPrevious.Enabled = false;
            //            }
            //            else
            //            {
            //                gbnavigation.Visible = false;
            //            }

            //            if (DataGVItems.Rows.Count > 0)
            //            {
            //                DataGVItems.Rows[0].Selected = true;


            //                chkSelectAll.Checked = true;

            //                chkSelectAll_Click(null, null);
            //                gbOrderDetail.Visible = true;

            //                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel"))) // 27-Oct-2017
            //                {

            //                    cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel");

            //                }
            //                else
            //                {
            //                    cmbLabelName.SelectedIndex = 0;

            //                }


            //            }


            //            return;
            //        }
            //        else
            //        {

            //            DataGVItems.Visible = false;
            //            gbnavigation.Visible = false;
            //            gbOrderDetail.Visible = false;
            //            chkSelectAll.Visible = false;
            //            lblprintheader.Visible = false;
            //            MessageBox.Show("Item receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtponumber.Focus();
            //            return;

            //        }



            //    }

            //}

            //using (new HourGlass()) //search receipt by po number
            //{
            //    alData = objPurchaseOrder.GetMulitiplePO(txtponumber.Text.ToString().Trim(), out txndatelist);

            //    if (txndatelist.Count > 0)
            //    {
            //       // gbnavigation.Visible = true;
            //       // btnPrevious.Enabled = false; //receipt
            //       // btnNext.Enabled = true;// receipt

            //        //DataGVItems.Visible = true;
            //        //chkSelectAll.Visible = true;
            //        //lblprintheader.Visible = true;
            //        //DataGVItems.Rows.Clear();
            //        //DataGVItems.Columns.Clear();

            //        //InitGrid();

            //        var MinDate = (from d in txndatelist select d.ReceiptTrasnDate).Min();

            //        //Retrieve Maximum Date
            //        var MaxDate = (from d in txndatelist select d.ReceiptTrasnDate).Max();


            //        lobjclsPurchaseOrderLine = objPurchaseOrderLine.GetItemReceiptDetailsByPO(txtponumber.Text.ToString().Trim(), MinDate, MaxDate, out poErrormessage, out lobjReceiptDataExtension);


            //        if (lobjclsPurchaseOrderLine.Count > 0)
            //        {
            //            lobjReceiptDataExtensioncopy = lobjReceiptDataExtension;

            //            DataGVItems.Visible = true;
            //            chkSelectAll.Visible = true;
            //            lblprintheader.Visible = true;
            //            DataGVItems.Rows.Clear();
            //            DataGVItems.Columns.Clear();

            //            InitGrid();

            //            var objreceiveItems = (from receiveItems in lobjclsPurchaseOrderLine
            //                                   orderby receiveItems.POReceivedItemCreatedTime descending
            //                                   select receiveItems).ToList();


            //            var MaxTxnID = (from d in objreceiveItems select d.TransID).Max();

            //            var objTopreceiveItem = (from receiveItems in lobjclsPurchaseOrderLine
            //                                     where receiveItems.TransID == MaxTxnID
            //                                     orderby receiveItems.POReceivedItemCreatedTime descending
            //                                     select receiveItems).ToList();




            //            foreach (var item in lobjclsPurchaseOrderLine)
            //            {
            //                lntRecCount.Add(item.TransID);
            //            }


            //            distinctrecord = lntRecCount.Distinct().Reverse().ToList();

            //            cntnextrecord = distinctrecord.Count();


            //            FillPOReceiptItemsGrid(objTopreceiveItem);
            //            if (cntnextrecord > 1)
            //            {
            //                btnNext.Enabled = true;
            //                btnPrevious.Enabled = false;
            //                gbnavigation.Visible = true;
            //               // lntRecCount.Clear();
            //            }
            //            else
            //            {
            //                gbnavigation.Visible = false;

            //            }

            //        }

            //        if (DataGVItems.Rows.Count > 0)
            //        {
            //            DataGVItems.Rows[0].Selected = true;


            //            chkSelectAll.Checked = true;

            //            chkSelectAll_Click(null, null);
            //            gbOrderDetail.Visible = true;

            //            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel")))
            //            {

            //                cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel");

            //            }
            //            else
            //            {
            //                cmbLabelName.SelectedIndex = 0;

            //            }


            //        }
            //    }
            //    else
            //    {
            //        DataGVItems.Visible = false;
            //        gbOrderDetail.Visible = false;
            //        chkSelectAll.Visible = false;
            //        lblprintheader.Visible = false;
            //        MessageBox.Show("Item receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtponumber.Focus();
            //        return;
            //    }
            //}

        }


        private void InitGrid()
        {
            chkSelectAll.Visible = true;
            //chkreceiptall.Visible = true;
            lblprintheader.Visible = true;
            //lblreceiptheader.Visible = true;

            DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
            Column.Name = "CheckBox";
            Column.HeaderText = "";
            DataGVItems.Columns.Add(Column);

            DataGVItems.Columns["CheckBox"].Width = 40;
            DataGVItems.Columns["CheckBox"].ReadOnly = false;


            // DataGridViewCheckBoxColumn Columnpoitem = new DataGridViewCheckBoxColumn();
            // Columnpoitem.Name = "CheckBoxPOItemreceipt";
            // Columnpoitem.HeaderText = "";
            // DataGVItems.Columns.Add(Columnpoitem);

            //DataGVItems.Columns["CheckBoxPOItemreceipt"].Width = 40;
            // DataGVItems.Columns["CheckBoxPOItemreceipt"].ReadOnly = false;



            DataGridViewCustomButtonColumn colIncrease = new DataGridViewCustomButtonColumn();

            colIncrease.Width = 25;
            colIncrease.Name = "Decrease";
            colIncrease.HeaderText = "";
            colIncrease.CellTemplate.Style.Font = new Font("Verdana", 28);

            colIncrease.Text = "<<";
            DataGVItems.Columns.Add(colIncrease);

            colIncrease.UseColumnTextForButtonValue = true;
            colIncrease.Visible = false;


            DataGridViewCustomButtonColumn colDecrease = new DataGridViewCustomButtonColumn();

            colDecrease.Name = "Increase";
            colDecrease.HeaderText = "";
            colDecrease.Width = 25;
            colDecrease.CellTemplate.Style.Font = new Font("Verdana", 20);
            colDecrease.Text = ">>";
            DataGVItems.Columns.Add(colDecrease);

            colDecrease.UseColumnTextForButtonValue = true;
            colDecrease.Visible = false;


            DataGVItems.Columns.Add("PurchaseOrderLineItemRefFullName", "Item");
            DataGVItems.Columns["PurchaseOrderLineItemRefFullName"].Width = 150;

            DataGVItems.Columns.Add("SubItemOf", "SubItemOf");
            DataGVItems.Columns["SubItemOf"].Width = 150;

            DataGVItems.Columns.Add("PurchaseOrderLineDesc", "Description");
            DataGVItems.Columns["PurchaseOrderLineDesc"].Width = 250;

            DataGVItems.Columns.Add("PurchaseOrderLineQuantity", "Qty on Lbl"); //"Qty on Lbl"
            DataGVItems.Columns["PurchaseOrderLineQuantity"].Width = 40;

            DataGVItems.Columns.Add("PurchaseOrderLineQuantityToPrint", "Print Qty"); //"Print Lbl Qty"
            DataGVItems.Columns["PurchaseOrderLineQuantityToPrint"].Width = 80;


            //exchange column position expdate and SN
            // DataGVItems.Columns.Add("PurchaseOrderLineExpDate", Convert.ToString(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("PoExpDateHeader")));
            //DataGVItems.Columns["PurchaseOrderLineExpDate"].Width = 100;

            // DataGVItems.Columns.Add("PurchaseOrderLineSN", Convert.ToString(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("PoSNHeader")));
            // DataGVItems.Columns["PurchaseOrderLineSN"].Width = 70;


            DataGVItems.Columns.Add("PurchaseOrderLineBin", "Loc / Bin");
            DataGVItems.Columns["PurchaseOrderLineBin"].Width = 100;


            DataGVItems.Columns.Add("PurchaseOrderLineBarCode", "BarCode");
            DataGVItems.Columns["PurchaseOrderLineBarCode"].Visible = false;

            DataGVItems.Columns.Add("PurchaseOrderLinePONumber", "PONumber");
            DataGVItems.Columns["PurchaseOrderLinePONumber"].Visible = false;


            DataGVItems.Columns.Add("PurchaseOrderLineRecCount", "ItemRecount");
            DataGVItems.Columns["PurchaseOrderLineRecCount"].Visible = false;

            DataGVItems.Columns.Add("purchaseordercombineItem", "POfullItemname");
            DataGVItems.Columns["purchaseordercombineItem"].Visible = false;
            //SerialNo:
            DataGVItems.Columns.Add("SerialNo", "SerialNo");
            DataGVItems.Columns["SerialNo"].Visible = false;
            //Lot Nunber
            DataGVItems.Columns.Add("LotNo", "LotNo");
            DataGVItems.Columns["LotNo"].Width = 100;
            DataGVItems.Columns["LotNo"].Visible = true;
            DataGVItems.Columns.Add("TxnLineID", "TxnLineID");
            DataGVItems.Columns["TxnLineID"].Visible = false;
            //Added by TamilRk on 10/10/2020
            DataGVItems.Columns.Add("TxnDate", "TxnDate");
            DataGVItems.Columns["TxnDate"].Visible = false;
            //Added by TamilRk on 11/05/2020
            DataGVItems.Columns.Add("VendorRefFullName", "VendorRefFullName");
            DataGVItems.Columns["VendorRefFullName"].Visible = false;
        }

        private void FillPOReceiptItemsGrid(List<clsPurchaseOrderLine> alLineItems)
        {

            int i = 0;
            string locbinvalue = string.Empty;
            DataGVItems.ReadOnly = false;
            DataGVItems.Rows.Clear();

            foreach (clsPurchaseOrderLine objPOLine in alLineItems)
            {
                if (!string.IsNullOrWhiteSpace(objPOLine.Site) && !string.IsNullOrWhiteSpace(objPOLine.Bin))
                {
                    locbinvalue = objPOLine.Site + " / " + objPOLine.Bin;

                }
                else if (!string.IsNullOrWhiteSpace(objPOLine.Site))
                {
                    locbinvalue = objPOLine.Site;

                }
                else
                {
                    locbinvalue = objPOLine.Bin;
                }
                DataGVItems.Rows.Add();
                DataGVItems.Rows[i].Cells["PurchaseOrderLineItemRefFullName"].Value = objPOLine.PurchaseOrderLineItemRefFullName;
                DataGVItems.Rows[i].Cells["PurchaseOrderLineItemRefFullName"].ReadOnly = true;
                DataGVItems.Rows[i].Cells["SubItemOf"].Value = objPOLine.SubItemOf != null ? objPOLine.SubItemOf : null;
                DataGVItems.Rows[i].Cells["SubItemOf"].ReadOnly = true;
                DataGVItems.Rows[i].Cells["PurchaseOrderLineDesc"].Value = objPOLine.PurchaseOrderLineDesc != null ? objPOLine.PurchaseOrderLineDesc : string.Empty;
                DataGVItems.Rows[i].Cells["PurchaseOrderLineDesc"].ReadOnly = true;

                DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantity"].Value = objPOLine.RecQty;
                // if (!string.IsNullOrWhiteSpace(objPOLine.ReceiptSerialNumber)) //05-Sept-2019
                // {
                //    DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantityToPrint"].Value = 1;
                // }
                // else
                // {
                DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantityToPrint"].Value = objPOLine.RecQty;
                // }

                DataGVItems.Rows[i].Cells["PurchaseOrderLineBin"].Value = locbinvalue;
                DataGVItems.Rows[i].Cells["PurchaseOrderLineBin"].ReadOnly = true;

                DataGVItems.Rows[i].Cells["PurchaseOrderLineBarCode"].Value = objPOLine.BarCodeValue;
                DataGVItems.Rows[i].Cells["PurchaseOrderLinePONumber"].Value = objPOLine.RefNumber;
                //serialNo
                DataGVItems.Rows[i].Cells["SerialNo"].Value = objPOLine.ReceiptSerialNumber;
                DataGVItems.Rows[i].Cells["LotNo"].Value = objPOLine.LotNo;

                DataGVItems.Rows[i].Cells["TxnLineID"].Value = objPOLine.TxnLineID; //31-oct-2017


                //make value with bold font
                DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantity"].Style.Font = new Font("Verdana", 8, FontStyle.Bold);
                DataGVItems.Rows[i].Cells["PurchaseOrderLineQuantityToPrint"].Style.Font = new Font("Verdana", 8, FontStyle.Bold);

                DataGVItems.Rows[i].Cells["purchaseordercombineItem"].Value = objPOLine.purchaseordercombineItem;

                DataGVItems.Rows[i].Cells["TxnDate"].Value = objPOLine.TxnDate;

                DataGVItems.Rows[i].Cells["VendorRefFullName"].Value = objPOLine.VendorRefFullName;

                i++;

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
                //cmbLabelPrinter.SelectedIndex = 0;
            }


        }
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

                    if (!string.IsNullOrEmpty(lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel")))
                    {
                        //cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ReceiptLabel");
                        cmbLabelName.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbLabelName.SelectedIndex = 0;
                    }
                    string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath")));
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


        public class DataGridViewCustomButtonColumn : DataGridViewButtonColumn
        {
            public DataGridViewCustomButtonColumn()
            {
                this.CellTemplate = new DataGridViewCustomButtonCell();
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
                cell.Enabled = this.Enabled;
                return cell;
            }

            // By default, enable the button cell. 
            public DataGridViewCustomButtonCell()
            {
                this.enabledValue = true;
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
                    Rectangle buttonAdjustment =
                        this.BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    // Draw the disabled button.                
                    ButtonRenderer.DrawButton(graphics, buttonArea,
                        PushButtonState.Disabled);

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

                    cellStyle.Font = new Font("Verdana", 9);
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        elementState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
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

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            int lintRowsSelected = 0;

            if (DataGVItems.Rows.Count > 0)
            {

                lintRowsSelected = DataGVItems.Rows.Count;

                if (chkSelectAll.Checked == true)
                {
                    btnPrint.Enabled = true;

                    for (int i = 0; i < lintRowsSelected; i++)
                    {

                        DataGVItems.Rows[i].Cells[0].Value = "True";

                    }
                }
                else
                {

                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                    {
                        DataGVItems.Rows[i].Cells[0].Value = "False";


                    }

                    checkcount = 0;
                    btnPrint.Enabled = false;


                }


            }
        }

        private void DataGVItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uncheckcount = 0;
            checkcount = 0;


            if (e.ColumnIndex != -1)
            {
                if (DataGVItems.CurrentRow != null)
                {

                    if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value == null)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }


            if (e.ColumnIndex != 0)
            {

                string locbin = string.Empty;
                if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "<<")
                {

                    var groupItemList = lobjclsPurchaseOrderLine.Where(p => p.PurchaseOrderLineItemRefFullName == Convert.ToString(DataGVItems.CurrentRow.Cells["PurchaseOrderLineItemRefFullName"].Value)).OrderByDescending(p => p.Reccount).ToList();

                    int pn = 0;
                    int cnt = 0;

                    foreach (var gvitem in groupItemList)
                    {

                        if (Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value) > 0)
                        {
                            cnt = Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value);
                            cnt--;
                            pn = cnt;


                        }
                        else
                        {
                            cnt = gvitem.Reccount;
                            cnt--;
                            pn = cnt;

                        }
                        if (pn > 0)
                        {
                            var groupItemList1 = lobjclsPurchaseOrderLine.Where(p => p.Reccount == pn && p.PurchaseOrderLineItemRefFullName == Convert.ToString(DataGVItems.CurrentRow.Cells["PurchaseOrderLineItemRefFullName"].Value)).ToList();

                            foreach (var gvbindItem in groupItemList1)
                            {
                                if (!string.IsNullOrWhiteSpace(gvbindItem.Site) && !string.IsNullOrWhiteSpace(gvbindItem.Bin))
                                {
                                    locbin = gvbindItem.Site + " / " + gvbindItem.Bin;

                                }
                                else if (!string.IsNullOrWhiteSpace(gvbindItem.Site))
                                {
                                    locbin = gvbindItem.Site;

                                }
                                else
                                {
                                    locbin = gvbindItem.Bin;
                                }
                                DataGVItems.CurrentRow.Cells["PurchaseOrderLineQuantity"].Value = gvbindItem.RecQty;
                                // DataGVItems.CurrentRow.Cells["PurchaseOrderLineQuantityToPrint"].Value = gvbindItem.PurchaseOrderLineQtytoPrint == 0 ? 1 : gvbindItem.PurchaseOrderLineQtytoPrint;
                                DataGVItems.CurrentRow.Cells["PurchaseOrderLineDesc"].Value = gvbindItem.PurchaseOrderLineDesc;
                                DataGVItems.CurrentRow.Cells["PurchaseOrderLineBin"].Value = locbin;
                                DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value = pn;
                                //SerianNo
                                if (DataGVItems.Columns.Contains("SerialNo"))
                                {
                                    DataGVItems.CurrentRow.Cells["SerialNo"].Value = gvbindItem.ReceiptSerialNumber;
                                }

                            }
                        }
                        else
                        {

                            MessageBox.Show("No more receipt item quantity available.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                        break;
                    }


                }


                if (DataGVItems.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == ">>")
                {

                    var groupItemList = lobjclsPurchaseOrderLine.Where(p => p.PurchaseOrderLineItemRefFullName == Convert.ToString(DataGVItems.CurrentRow.Cells["PurchaseOrderLineItemRefFullName"].Value)).ToList();

                    int pn = 0;
                    int cnt = 1;


                    foreach (var gvitem in groupItemList)
                    {

                        if (Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value) > 0)
                        {
                            if (Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value) < groupItemList.Count)
                            {
                                if (Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value) == 1)
                                {
                                    cnt++;
                                    pn = cnt;
                                }
                                else
                                {

                                    cnt = Convert.ToInt32(DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value);
                                    cnt++;
                                    pn = cnt;

                                }

                                var groupItemList1 = lobjclsPurchaseOrderLine.Where(p => p.Reccount == pn && p.PurchaseOrderLineItemRefFullName == Convert.ToString(DataGVItems.CurrentRow.Cells["PurchaseOrderLineItemRefFullName"].Value)).ToList();

                                foreach (var gvbindItem in groupItemList1)
                                {
                                    if (!string.IsNullOrWhiteSpace(gvbindItem.Site) && !string.IsNullOrWhiteSpace(gvbindItem.Bin))
                                    {
                                        locbin = gvbindItem.Site + " / " + gvbindItem.Bin;

                                    }
                                    else if (!string.IsNullOrWhiteSpace(gvbindItem.Site))
                                    {
                                        locbin = gvbindItem.Site;

                                    }
                                    else
                                    {
                                        locbin = gvbindItem.Bin;
                                    }
                                    DataGVItems.CurrentRow.Cells["PurchaseOrderLineQuantity"].Value = gvbindItem.RecQty;
                                    // DataGVItems.CurrentRow.Cells["PurchaseOrderLineQuantityToPrint"].Value = gvbindItem.PurchaseOrderLineQtytoPrint == 0 ? 1 : gvbindItem.PurchaseOrderLineQtytoPrint;
                                    DataGVItems.CurrentRow.Cells["PurchaseOrderLineDesc"].Value = gvbindItem.PurchaseOrderLineDesc;
                                    DataGVItems.CurrentRow.Cells["PurchaseOrderLineBin"].Value = locbin;
                                    DataGVItems.CurrentRow.Cells["PurchaseOrderLineRecCount"].Value = pn;
                                    //SerianNo
                                    if (DataGVItems.Columns.Contains("SerialNo"))
                                    {
                                        DataGVItems.CurrentRow.Cells["SerialNo"].Value = gvbindItem.ReceiptSerialNumber;
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("No more receipt item quantity available.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("No more receipt item quantity available.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        break;
                    }



                }

            }

            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {


                if (Convert.ToString(DataGVItems.CurrentRow.Cells[0].Value) == "True")
                {
                    DataGVItems.CurrentRow.Cells[0].Value = "False";
                    //Reset edited 

                    // DataGVItems.CurrentRow.Cells["QuantityonHand"].ReadOnly = true;

                    // DataGVItems.CurrentRow.Cells["QuantityonHand"].Style.Font = new Font("Verdana", 8, FontStyle.Regular);
                    chkSelectAll.Checked = false;


                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                    {
                        if (Convert.ToString(DataGVItems.Rows[i].Cells[0].Value) == "False")
                        {

                            uncheckcount++;

                        }
                    }

                    if (uncheckcount == DataGVItems.Rows.Count)
                    {
                        btnPrint.Enabled = false;

                    }
                    else
                    {
                        btnPrint.Enabled = true;

                    }


                }
                else
                {

                    DataGVItems.CurrentRow.Cells[0].Value = "True";

                    for (int i = 0; i < DataGVItems.Rows.Count; i++)
                    {
                        if (Convert.ToString(DataGVItems.Rows[i].Cells[0].Value) == "True")
                        {

                            checkcount++;

                        }
                    }
                    if (checkcount == DataGVItems.Rows.Count)
                    {
                        chkSelectAll.Checked = true;

                    }
                    else
                    {
                        chkSelectAll.Checked = false;

                    }

                    if (checkcount > 0)
                        btnPrint.Enabled = true;
                    else
                        btnPrint.Enabled = false;




                }
            }
        }

        private void btnSearchReset_Click(object sender, EventArgs e)
        {
            txtponumber.Enabled = true;
            txtponumber.Text = "";
            // cntlastpointer = 0; //receipt
            lobjclsPurchaseOrderLine.Clear(); //receipt
            lntRecCount.Clear(); //receipt
            btnNext.Enabled = false;
            btnPrevious.Enabled = true;
            cmbvendor.Enabled = true;
            if (cmbvendor.SelectedIndex != -1)
            {
                cmbvendor.SelectedIndex = 0;
            }

            DataGVItems.Visible = false;
            gbOrderDetail.Visible = false;
            gbnavigation.Visible = false;
            chkSelectAll.Visible = false;
            lblprintheader.Visible = false;
            dateTimePicker1.Value = DateTime.Now.AddDays(-5);
            dateTimePicker2.Value = DateTime.Now.AddDays(0);
            txtponumber.Focus();
        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();
        }

        private void PrintReceiptItemBySearch()
        {


            lobjQBConfiguration = new QBConfiguration();
            ArrayList alPoItems = new ArrayList();
            string binlocation = string.Empty;
            char[] delim = new char[] { '/' };
            string[] parts;

            int cntChk = 0;


            ArrayList alLineItem = null;
            //clsPurchaseOrderLine objPurchaseOrderLine = null;
            Type objClsType = null;
            object strPropertyValue = null;

            try
            {
                //if (Convert.ToInt32(txtQtyToPrint.Text) <= 0)
                //{
                //    MessageBox.Show("Quantity to print should be greater than zero.", "Label Connector");
                //    txtQtyToPrint.Focus();
                //    return;
                //}

                if (cmbLabelName.SelectedIndex > 0)
                {
                    btnPrint.Enabled = false;

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
                                            //if (DataGVItems.Rows[j].Cells["QuantityonHand"].Value == null)
                                            //{
                                            //    MessageBox.Show("Qty on Hand/ Print Qty is Null, Please use edit function to add a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            //    btnPrint.Enabled = true;
                                            //    return;
                                            //}
                                            ////Allow -ve Qty to print : Date 21-sept-2017
                                            //if (DataGVItems.Rows[j].Cells["QuantityonHand"].Value.ToString().StartsWith("-"))
                                            //{
                                            //    MessageBox.Show("Qty to print can not be negative, Please use edit function to edit a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            //    btnPrint.Enabled = true;
                                            //    return;
                                            //}
                                            intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value)));
                                            this.Cursor = Cursors.WaitCursor;
                                            BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);


                                            // ArrayList alLineItem = null;
                                            // Type objClsType;
                                            // object strPropertyValue = null;
                                            // objPurchaseOrderLine = new clsPurchaseOrderLine();


                                            objPurchaseOrderLine = new clsPurchaseOrderLine();




                                            //Get Item details based on search
                                            //var liItemRecord = from clsItemDetails objItemRecord in lstAllItemList  //alLineItemSearch
                                            //                 where objItemRecord.itemname == Convert.ToString(DataGVSearchItem.Rows[j].Cells["itemname"].Value.ToString().Trim())
                                            //                 select objItemRecord;


                                            // alLineItem = new ArrayList(liItemRecord.ToList());

                                            objPurchaseOrderLine.PurchaseOrderLineItemRefFullName = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineItemRefFullName"].Value);
                                            objPurchaseOrderLine.SubItemOf = Convert.ToString(DataGVItems.Rows[j].Cells["purchaseordercombineItem"].Value);
                                            objPurchaseOrderLine.PurchaseOrderLineDesc = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineDesc"].Value);
                                            objPurchaseOrderLine.RecQty = Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value);
                                            objPurchaseOrderLine.PurchaseOrderLineQtytoPrint = Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value);
                                            // objPurchaseOrderLine.Entry2 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineSN"].Value);

                                            // objPurchaseOrderLine.Entry1 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineExpDate"].Value);
                                            parts = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineBin"].Value).Split(delim, StringSplitOptions.RemoveEmptyEntries);
                                            if (parts.Length > 1)
                                            {
                                                objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                                                objPurchaseOrderLine.Bin = parts[1] != null ? parts[1].ToString() : null;
                                            }
                                            else if (parts.Length == 1)
                                            {
                                                objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                                            }
                                            objPurchaseOrderLine.BarCodeValue = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineBarCode"].Value);
                                            objPurchaseOrderLine.RefNumber = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLinePONumber"].Value);
                                            objPurchaseOrderLine.LotNo = Convert.ToString(DataGVItems.Rows[j].Cells["LotNo"].Value);
                                            //objPurchaseOrderLine.ReceiptSerialNumber = Convert.ToString(DataGVItems.Rows[j].Cells["ReceiptSerialNumber"].Value);

                                            //Get custom item field for receipt
                                            arrReceiptCustomItems = objPurchaseOrderLine.PoItemDetails(Convert.ToString(DataGVItems.Rows[j].Cells["purchaseordercombineItem"].Value), out lobjDataExtension);

                                            //Get CustomItem field for selected Item

                                            var ItemInfo = (from d in lobjReceiptDataExtensioncopy where d.ReceiptItemID == Convert.ToString(DataGVItems.Rows[j].Cells["TxnLineID"].Value) select d).ToList();


                                            if (arrReceiptCustomItems.Count > 0 && arrReceiptCustomItems != null)
                                            {
                                                foreach (clsPurchaseOrderLine receiptitem in arrReceiptCustomItems)
                                                {
                                                    objPurchaseOrderLine.SalesPrice = receiptitem.SalesPrice;
                                                    objPurchaseOrderLine.BarCodeValue = receiptitem.BarCodeValue;
                                                    objPurchaseOrderLine.MPN = receiptitem.MPN;
                                                    objPurchaseOrderLine.AverageCost = receiptitem.AverageCost;
                                                    objPurchaseOrderLine.QuantityOnHand = receiptitem.QuantityOnHand;
                                                }
                                            }

                                            alPoItems.Add(objPurchaseOrderLine);

                                            alLineItem = alPoItems;


                                            objClsType = objPurchaseOrderLine.GetType();

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

                                                        PropertyInfo objPropertyInfo = objClsType.GetProperty(BtSubString.Name.ToString().Replace(System.Environment.NewLine, string.Empty).Trim());

                                                        strPropertyValue = objPropertyInfo.GetValue((clsPurchaseOrderLine)alLineItem[y], null);

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        //31-0ct-2017
                                                        try
                                                        {
                                                            string lstrPropertyValExt = string.Empty;

                                                            if (lobjDataExtension.ContainsKey(BtSubString.Name.ToString().Trim().ToUpper()))
                                                            {
                                                                lobjDataExtension.TryGetValue(BtSubString.Name.ToString().Trim().ToUpper(), out lstrPropertyValExt);
                                                                strPropertyValue = lstrPropertyValExt;
                                                            }
                                                            else
                                                            {
                                                                strPropertyValue = string.Empty;
                                                            }

                                                            // Receipts custom fields logic

                                                            //var receiptcustomfieldvalue = (from d in ItemInfo where d.ReceiptCustomFieldkey.ToUpper() == BtSubString.Name.ToString().Trim().ToUpper() select d.ReceiptCustomFieldValue).FirstOrDefault();
                                                            //if (receiptcustomfieldvalue != null)
                                                            //{
                                                            //    strPropertyValue = receiptcustomfieldvalue;
                                                            //}
                                                            //else
                                                            //{
                                                            //    strPropertyValue = string.Empty; //11-30-2017
                                                            //}
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
                                }


                            }
                            //save selected label :Date 23-Feb-2017
                            //lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "saveinvoicelabel");

                            //save printer name :Date 11-Feb-2017
                            // lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "invpackprinter");


                        }
                    }


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
                this.Cursor = Cursors.Default;
                btnPrint.Enabled = false;
                btnClear.Enabled = true;
            }
        }

        //print UDF Label for printing

        private void PrintUDFReceiptItemBySearch()
        {
            int intQuantity = 0;
            int cntChk = 0;
            string checkAuto = string.Empty;
            string SetValuesForTransType = string.Empty;
            string SetTemplatewidth = string.Empty;
            string SetTemplateheight = string.Empty;
            bool blnIsIncrementcounter = false;
            int lntpoquantity = 0;
            int increment = 1;
            int serialnocount = 0;
            string snoindex = string.Empty;
            string[] SerialNoParts;
            char[] snsplit = new char[] { ',' };
            int qtyvalue = 0;
            bool isNumericQuantity = false;

            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
            try
            {
                using (new HourGlass())
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
                            }
                            if (cntChk == DataGVItems.Rows.Count)
                            {
                                MessageBox.Show("Please Check At Least One Record To Print", "Label Connector");
                                return;
                            }

                            ArrayList alLineItem = null;
                            clsPurchaseOrderLine objclsPurchaseOrderLine = null;

                            Type objClsType;
                            object strPropertyValue = null;
                            string flipPoQtyvalue = string.Empty;
                            for (int j = 0; j < DataGVItems.Rows.Count; j++)
                            {

                                if (DataGVItems.Rows[j].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                {
                                    //skip po qty having count zero
                                    isNumericQuantity = int.TryParse(Convert.ToString(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))), out qtyvalue);
                                    if (!isNumericQuantity)
                                    {
                                        continue;
                                    }
                                    //skip items having print lbl qty is 0
                                    else if (Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))) == 0)
                                    {
                                        continue;
                                    }

                                    if ((cmbLabelName.SelectedIndex != 0) || (checkAuto == "Auto"))
                                    {

                                        //if (rdbPO.Checked == true)
                                        //{
                                        //    intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value);
                                        //}


                                        objclsPurchaseOrderLine = new clsPurchaseOrderLine();


                                        intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value)));
                                        lntpoquantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value)));


                                        objfieldlist = lobjTemplatexml.GetFieldPropertiesList(cmbLabelName.Text.ToString(), string.Empty);
                                        //Get property fields list

                                        objheaderfield = lobjTemplatexml.GetTemplateHeaderInfo(cmbLabelName.Text.ToString());
                                        foreach (QuickBooksField itemfield in objheaderfield)
                                        {
                                            if (itemfield.ItemFieldId == 1)
                                            {
                                                SetValuesForTransType = itemfield.ItemFieldName;
                                            }
                                            else if (itemfield.ItemFieldId == 2)
                                            {
                                                SetTemplatewidth = itemfield.ItemFieldName;
                                            }
                                            else if (itemfield.ItemFieldId == 3)
                                            {
                                                SetTemplateheight = itemfield.ItemFieldName;
                                            }
                                        }
                                        //print item with serial numbers
                                        if (DataGVItems.Columns.Contains("SerialNo"))
                                        {
                                            if (!string.IsNullOrWhiteSpace(Convert.ToString(DataGVItems.Rows[j].Cells["SerialNo"].Value)))
                                            {
                                                SerialNoParts = Convert.ToString(DataGVItems.Rows[j].Cells["SerialNo"].Value).Split(snsplit, StringSplitOptions.RemoveEmptyEntries);


                                                //intQuantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value.ToString().Trim());
                                                //lntpoquantity = Convert.ToInt32(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantity"].Value.ToString().Trim());


                                                //objfieldlist = lobjTemplatexml.GetFieldPropertiesList(cmbLabelName.Text.ToString(), string.Empty);
                                                ////Get property fields list

                                                //objheaderfield = lobjTemplatexml.GetTemplateHeaderInfo(cmbLabelName.Text.ToString());
                                                //foreach (QuickBooksField itemfield in objheaderfield)
                                                //{
                                                //    if (itemfield.ItemFieldId == 1)
                                                //    {
                                                //        SetValuesForTransType = itemfield.ItemFieldName;
                                                //    }
                                                //    else if (itemfield.ItemFieldId == 2)
                                                //    {
                                                //        SetTemplatewidth = itemfield.ItemFieldName;
                                                //    }
                                                //    else if (itemfield.ItemFieldId == 3)
                                                //    {
                                                //        SetTemplateheight = itemfield.ItemFieldName;
                                                //    }
                                                //}

                                                //If receiptqty less than or equal to serial numbers
                                                if (Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))) <= Convert.ToInt32(SerialNoParts.Length))
                                                {

                                                    for (int k = 0; k < SerialNoParts.Length; k++)
                                                    {

                                                        if (k < Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))))
                                                        {


                                                            PrintReceiptwithSerialNoUDF(j, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))), SerialNoParts[k].ToString(), cmbLabelName.Text.ToString(), SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lntpoquantity, blnIsIncrementcounter, objfieldlist, lobjDataExtension);
                                                        }

                                                    }

                                                }
                                                //If receiptqty grater than  to serial number
                                                else if (Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))) >= Convert.ToInt32(SerialNoParts.Length))
                                                {


                                                    while (increment <= Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))))
                                                    {
                                                        if (SerialNoParts.ElementAtOrDefault(serialnocount) != null)
                                                        {
                                                            snoindex = SerialNoParts[serialnocount].ToString();
                                                        }
                                                        else
                                                        {
                                                            snoindex = string.Empty;
                                                        }


                                                        PrintReceiptwithSerialNoUDF(j, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))), snoindex, cmbLabelName.Text.ToString(), SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lntpoquantity, blnIsIncrementcounter, objfieldlist, lobjDataExtension);
                                                        increment++;
                                                        serialnocount++;

                                                    }

                                                }


                                            }
                                            else
                                            {
                                                //if no serial no exist then print default receive quantity

                                                PrintReceiptwithOutSerialNoUDF(j, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))), string.Empty, cmbLabelName.Text.ToString(), SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lntpoquantity, blnIsIncrementcounter, objfieldlist, lobjDataExtension);


                                            }
                                        }
                                        else
                                        {
                                            //if no serial no exist then print default receive quantity

                                            PrintReceiptwithOutSerialNoUDF(j, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVItems.Rows[j].Cells["PurchaseOrderLineQuantityToPrint"].Value))), string.Empty, cmbLabelName.Text.ToString(), SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lntpoquantity, blnIsIncrementcounter, objfieldlist, lobjDataExtension);


                                        }



                                        // objClsType = objclsPurchaseOrderLine.GetType();



                                    } //end skip po
                                    else
                                    {
                                        MessageBox.Show("Select Label", "Label Connector");

                                    }
                                    btnClear.Enabled = true;
                                    btnPrint.Enabled = true;


                                } //end check
                            } //end for

                            //save labe path for multiple po Dat3e 03-12-2017
                            //if (rdbPO.Checked == true && rdbA.Checked == true)
                            //{
                            //    if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("ShowPo") == "0") //for receipt
                            //    {
                            //        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "savereceiptlabel");
                            //    }
                            //    else //for regular po
                            //    {

                            //        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "savepomultiplelabel");
                            //    }
                            //}
                            ////save printer name :Date 11-Feb-2017
                            //if (rdbPO.Checked == true)
                            //{
                            //    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "poprinter");
                            //}


                        }
                    }



                }// end hourglass
            } //end try
            catch (Exception ex)
            {

            }
        }

        private void PrintReceiptwithSerialNoUDF(int pintItemIncrement, int pintQuantitytoPrint, string snpartno, string pstrLabelName, string pstrTemplateWidth, string pstrTemplateHeight, string pstrTemplateTransType, int pintquantity, int pintpoquantity, bool isIncrementcounter, List<clsTemplateLabelXmlwork> objfieldlist, Dictionary<string, string> lobjDataExtension)
        {

            ArrayList alPoItems = new ArrayList();
            string binlocation = string.Empty;
            char[] delim = new char[] { '/' };
            string[] parts;

            lobjQBConfiguration = new QBConfiguration();

            try
            {

                lobjDataExtension = null;



                string btNamedSubString = string.Empty;
                string strProdLblPath = "";

                string strProdPrinter = "";

                string strLabelName = string.Empty;

                strLabelName = cmbLabelName.Text;

                strProdPrinter = cmbLabelPrinter.Text;

                string lstrPropertyValue = string.Empty;

                if ((cmbLabelName.SelectedIndex != 0))
                {
                    try
                    {

                        // this.Cursor = Cursors.WaitCursor;


                        int i = 1;
                        int boxqtynumerator = 1;

                        ArrayList alLineItem = null;

                        clsPurchaseOrderLine objclsPurchaseOrderLine = null;

                        objclsPurchaseOrderLine = new clsPurchaseOrderLine();


                        // logic for printing serialNo

                        //objclsPurchaseOrderLine.PurchaseOrderLineItemRefFullName = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineItemRefFullName"].Value);

                        //objclsPurchaseOrderLine.SubItemOf = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value);

                        //objclsPurchaseOrderLine.PurchaseOrderLineDesc = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineDesc"].Value);
                        //objclsPurchaseOrderLine.RecQty = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantity"].Value);
                        //objclsPurchaseOrderLine.PurchaseOrderLineQtytoPrint = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantityToPrint"].Value);
                        //objclsPurchaseOrderLine.Entry2 = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineSN"].Value);

                        //objclsPurchaseOrderLine.Entry1 = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineExpDate"].Value);
                        //objclsPurchaseOrderLine.ReceiptSerialNumber = snpartno; //SerailNo

                        //parts = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBin"].Value).Split(delim, StringSplitOptions.RemoveEmptyEntries);
                        //if (parts.Length > 1)
                        //{
                        //    objclsPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        //    objclsPurchaseOrderLine.Bin = parts[1] != null ? parts[1].ToString() : null;
                        //}
                        //else if (parts.Length == 1)
                        //{
                        //    objclsPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        //}

                        //objclsPurchaseOrderLine.BarCodeValue = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBarCode"].Value);
                        //objclsPurchaseOrderLine.RefNumber = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLinePONumber"].Value);
                        //alPoItems.Add(objclsPurchaseOrderLine);
                        //alLineItem = alPoItems;

                        objPurchaseOrderLine.PurchaseOrderLineItemRefFullName = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineItemRefFullName"].Value);
                        objPurchaseOrderLine.SubItemOf = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value);
                        objPurchaseOrderLine.PurchaseOrderLineDesc = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineDesc"].Value);
                        objPurchaseOrderLine.RecQty = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantity"].Value);
                        objPurchaseOrderLine.PurchaseOrderLineQtytoPrint = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantityToPrint"].Value);
                        objPurchaseOrderLine.ReceiptSerialNumber = snpartno; //SerailNo
                        // objPurchaseOrderLine.Entry2 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineSN"].Value);

                        // objPurchaseOrderLine.Entry1 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineExpDate"].Value);
                        parts = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBin"].Value).Split(delim, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 1)
                        {
                            objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                            objPurchaseOrderLine.Bin = parts[1] != null ? parts[1].ToString() : null;
                        }
                        else if (parts.Length == 1)
                        {
                            objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        }
                        objPurchaseOrderLine.BarCodeValue = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBarCode"].Value);
                        objPurchaseOrderLine.RefNumber = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLinePONumber"].Value);
                        objPurchaseOrderLine.LotNo = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["LotNo"].Value);
                        //objPurchaseOrderLine.ReceiptSerialNumber = Convert.ToString(DataGVItems.Rows[j].Cells["ReceiptSerialNumber"].Value);

                        //Get custom item field for receipt
                        arrReceiptCustomItems = objPurchaseOrderLine.PoItemDetails(Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value), out lobjDataExtension);

                        //Get CustomItem field for selected Item

                        //var ItemInfo = (from d in lobjReceiptDataExtensioncopy where d.ReceiptItemID == Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["TxnLineID"].Value) select d).ToList();


                        if (arrReceiptCustomItems.Count > 0 && arrReceiptCustomItems != null)
                        {
                            foreach (clsPurchaseOrderLine receiptitem in arrReceiptCustomItems)
                            {
                                objPurchaseOrderLine.SalesPrice = receiptitem.SalesPrice;
                                objPurchaseOrderLine.BarCodeValue = receiptitem.BarCodeValue;
                                objPurchaseOrderLine.MPN = receiptitem.MPN;
                                objPurchaseOrderLine.AverageCost = receiptitem.AverageCost;
                                objPurchaseOrderLine.QuantityOnHand = receiptitem.QuantityOnHand;
                            }
                        }

                        alPoItems.Add(objPurchaseOrderLine);

                        alLineItem = alPoItems;
                        //put create pdf, image function

                        foreach (var varintemincr in objfieldlist)
                        {
                            if (varintemincr.datasourcetext != null)
                            {

                                if (!string.IsNullOrWhiteSpace(varintemincr.delimiter))
                                {
                                    char charArr = varintemincr.delimiter.ToCharArray()[0];

                                    string[] incrementfieldlist = varintemincr.datasourcetext.ToString().Split(charArr);

                                    for (int h = 0; h < incrementfieldlist.Length; h++) //loop
                                    {
                                        if (incrementfieldlist[h].ToString().ToLower().Trim() == "itemincrement")
                                        {
                                            isIncrementcounter = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (varintemincr.datasourcetext.ToString().ToLower() == "itemincrement")
                                    {
                                        isIncrementcounter = true;
                                        break;
                                    }

                                }
                            }
                        }
                        if (isIncrementcounter == true)
                        {

                            lobjporeceiptTemplatexml.PrintTemplateForPOIncrementCounter(pstrLabelName, pstrTemplateWidth, pstrTemplateHeight, pstrTemplateTransType, pintquantity, pintpoquantity, objfieldlist, alLineItem, lobjDataExtension, null, cmbLabelPrinter.Text.ToString());
                            //print multiple images:10-APR-2019
                            filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\");
                            PrintMultipleImages(filePath);
                        }
                        else
                        {
                            lobjporeceiptTemplatexml.PrintTemplateForPOMultiple(pstrLabelName, pstrTemplateWidth, pstrTemplateHeight, pstrTemplateTransType, pintquantity, objfieldlist, alLineItem, lobjDataExtension, null, cmbLabelPrinter.Text.ToString());

                            filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Tiff");

                            // Print(filePath, pintquantity);
                            PrintWithSerialNo(filePath, 1);
                        }

                        boxqtynumerator += 1;


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
                        btnPrint.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Printing Error: " + "Please Select Label");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrint.Enabled = false;
                btnClear.Enabled = true;
            }
        }
        //if serial no does not exist,print default receipt quantity
        private void PrintReceiptwithOutSerialNoUDF(int pintItemIncrement, int pintQuantitytoPrint, string snpartno, string pstrLabelName, string pstrTemplateWidth, string pstrTemplateHeight, string pstrTemplateTransType, int pintquantity, int pintpoquantity, bool isIncrementcounter, List<clsTemplateLabelXmlwork> objfieldlist, Dictionary<string, string> lobjDataExtension)
        {

            ArrayList alPoItems = new ArrayList();
            string binlocation = string.Empty;
            char[] delim = new char[] { '/' };
            string[] parts;

            lobjQBConfiguration = new QBConfiguration();

            try
            {

                lobjDataExtension = null;



                string btNamedSubString = string.Empty;
                string strProdLblPath = "";

                string strProdPrinter = "";

                string strLabelName = string.Empty;

                strLabelName = cmbLabelName.Text;

                strProdPrinter = cmbLabelPrinter.Text;

                string lstrPropertyValue = string.Empty;

                if ((cmbLabelName.SelectedIndex != 0))
                {
                    try
                    {

                        // this.Cursor = Cursors.WaitCursor;


                        int i = 1;
                        int boxqtynumerator = 1;

                        ArrayList alLineItem = null;

                        clsPurchaseOrderLine objclsPurchaseOrderLine = null;

                        objclsPurchaseOrderLine = new clsPurchaseOrderLine();


                        // logic for printing serialNo

                        //objclsPurchaseOrderLine.PurchaseOrderLineItemRefFullName = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineItemRefFullName"].Value);

                        //objclsPurchaseOrderLine.SubItemOf = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value);

                        //objclsPurchaseOrderLine.PurchaseOrderLineDesc = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineDesc"].Value);
                        //objclsPurchaseOrderLine.RecQty = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantity"].Value);
                        //objclsPurchaseOrderLine.PurchaseOrderLineQtytoPrint = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantityToPrint"].Value);
                        //objclsPurchaseOrderLine.Entry2 = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineSN"].Value);

                        //objclsPurchaseOrderLine.Entry1 = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineExpDate"].Value);
                        //objclsPurchaseOrderLine.ReceiptSerialNumber = snpartno; //SerailNo

                        //parts = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBin"].Value).Split(delim, StringSplitOptions.RemoveEmptyEntries);
                        //if (parts.Length > 1)
                        //{
                        //    objclsPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        //    objclsPurchaseOrderLine.Bin = parts[1] != null ? parts[1].ToString() : null;
                        //}
                        //else if (parts.Length == 1)
                        //{
                        //    objclsPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        //}

                        //objclsPurchaseOrderLine.BarCodeValue = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBarCode"].Value);
                        //objclsPurchaseOrderLine.RefNumber = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLinePONumber"].Value);
                        //alPoItems.Add(objclsPurchaseOrderLine);
                        //alLineItem = alPoItems;

                        objPurchaseOrderLine.PurchaseOrderLineItemRefFullName = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineItemRefFullName"].Value);
                        objPurchaseOrderLine.SubItemOf = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value);
                        objPurchaseOrderLine.PurchaseOrderLineDesc = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineDesc"].Value);
                        objPurchaseOrderLine.RecQty = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantity"].Value);
                        objPurchaseOrderLine.PurchaseOrderLineQtytoPrint = Convert.ToDouble(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineQuantityToPrint"].Value);
                        objPurchaseOrderLine.ReceiptSerialNumber = snpartno; //SerailNo
                        // objPurchaseOrderLine.Entry2 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineSN"].Value);

                        // objPurchaseOrderLine.Entry1 = Convert.ToString(DataGVItems.Rows[j].Cells["PurchaseOrderLineExpDate"].Value);
                        parts = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBin"].Value).Split(delim, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 1)
                        {
                            objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                            objPurchaseOrderLine.Bin = parts[1] != null ? parts[1].ToString() : null;
                        }
                        else if (parts.Length == 1)
                        {
                            objPurchaseOrderLine.Site = parts[0] != null ? parts[0].ToString() : null;
                        }
                        objPurchaseOrderLine.BarCodeValue = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLineBarCode"].Value);
                        objPurchaseOrderLine.RefNumber = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["PurchaseOrderLinePONumber"].Value);
                        objPurchaseOrderLine.LotNo = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["LotNo"].Value);

                        objPurchaseOrderLine.VendorRefFullName = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["VendorRefFullName"].Value);
                        objPurchaseOrderLine.TxnDate = Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["TxnDate"].Value);

                        //objPurchaseOrderLine.ReceiptSerialNumber = Convert.ToString(DataGVItems.Rows[j].Cells["ReceiptSerialNumber"].Value);

                        //Get custom item field for receipt
                        arrReceiptCustomItems = objPurchaseOrderLine.PoItemDetails(Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["purchaseordercombineItem"].Value), out lobjDataExtension);

                        //Get CustomItem field for selected Item

                        //var ItemInfo = (from d in lobjReceiptDataExtensioncopy where d.ReceiptItemID == Convert.ToString(DataGVItems.Rows[pintItemIncrement].Cells["TxnLineID"].Value) select d).ToList();


                        if (arrReceiptCustomItems.Count > 0 && arrReceiptCustomItems != null)
                        {
                            foreach (clsPurchaseOrderLine receiptitem in arrReceiptCustomItems)
                            {
                                objPurchaseOrderLine.SalesPrice = receiptitem.SalesPrice;
                                objPurchaseOrderLine.BarCodeValue = receiptitem.BarCodeValue;
                                objPurchaseOrderLine.MPN = receiptitem.MPN;
                                objPurchaseOrderLine.AverageCost = receiptitem.AverageCost;
                                objPurchaseOrderLine.QuantityOnHand = receiptitem.QuantityOnHand;
                                objPurchaseOrderLine.PurchaseOrderLineUnitOfMeasure = receiptitem.PurchaseOrderLineUnitOfMeasure;                                                             
                            }
                        }

                        alPoItems.Add(objPurchaseOrderLine);

                        alLineItem = alPoItems;
                        //put create pdf, image function

                        foreach (var varintemincr in objfieldlist)
                        {
                            if (varintemincr.datasourcetext != null)
                            {

                                if (!string.IsNullOrWhiteSpace(varintemincr.delimiter))
                                {
                                    char charArr = varintemincr.delimiter.ToCharArray()[0];

                                    string[] incrementfieldlist = varintemincr.datasourcetext.ToString().Split(charArr);

                                    for (int h = 0; h < incrementfieldlist.Length; h++) //loop
                                    {
                                        if (incrementfieldlist[h].ToString().ToLower().Trim() == "itemincrement")
                                        {
                                            isIncrementcounter = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (varintemincr.datasourcetext.ToString().ToLower() == "itemincrement")
                                    {
                                        isIncrementcounter = true;
                                        break;
                                    }

                                }
                            }
                        }
                        if (isIncrementcounter == true)
                        {

                            lobjporeceiptTemplatexml.PrintTemplateForPOIncrementCounter(pstrLabelName, pstrTemplateWidth, pstrTemplateHeight, pstrTemplateTransType, pintquantity, pintpoquantity, objfieldlist, alLineItem, lobjDataExtension, null, cmbLabelPrinter.Text.ToString());
                            //print multiple images:10-APR-2019
                            filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\");
                            PrintMultipleImages(filePath);
                        }
                        else
                        {
                            lobjporeceiptTemplatexml.PrintTemplateForPOMultiple(pstrLabelName, pstrTemplateWidth, pstrTemplateHeight, pstrTemplateTransType, pintquantity, objfieldlist, alLineItem, lobjDataExtension, null, cmbLabelPrinter.Text.ToString());

                            filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Tiff");

                            Print(filePath, pintquantity);

                        }

                        boxqtynumerator += 1;


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
                        btnPrint.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Printing Error: " + "Please Select Label");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrint.Enabled = false;
                btnClear.Enabled = true;
            }
        }

        public void PrintMultipleImages(string pstrimagepath)
        {
            //StringBuilder logMessage = new StringBuilder();
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
                // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));

                // QBHelper.WriteLog("ErrorFinally : {0}" + logMessage.ToString());
            }
        }

        public void Print(string FileName, int pintprintqty)
        {
            // StringBuilder logMessage = new StringBuilder();
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));

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
                //pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("custom",0,0);
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

                // for (short page = 0; page < pd.PrinterSettings.Copies; page++)
                // {
                pd.Print();
                //}

            }
            catch (Exception ex)
            {

                QBHelper.WriteLog("ErrorCatch : {0}" + ex.ToString());
            }
            finally
            {
                //logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));

                // QBHelper.WriteLog("ErrorFinally : {0}" + logMessage.ToString());
            }
        }

        public void PrintWithSerialNo(string FileName, int pintprintqty)
        {
            // StringBuilder logMessage = new StringBuilder();
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            // logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));

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
                //pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("custom",0,0);
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

                // for (short page = 0; page < pd.PrinterSettings.Copies; page++)
                // {
                pd.Print();
                //}

            }
            catch (Exception ex)
            {

                QBHelper.WriteLog("ErrorCatch : {0}" + ex.ToString());
            }
            finally
            {
                //logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));

                // QBHelper.WriteLog("ErrorFinally : {0}" + logMessage.ToString());
            }
        }
        private bool CheckMandetory()
        {

            if (cmbLabelPrinter.SelectedIndex == 0)
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
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))

            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != '-'))
            {

                e.Handled = true;

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();

            try
            {
                //print Item receipt based on searach by vendor number on po number
                using (new HourGlass())
                {
                    //check if bartender label or  UDF label  option is selected
                    if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                    {
                        PrintReceiptItemBySearch();
                    }
                    else
                    {
                        PrintUDFReceiptItemBySearch();

                    }


                    if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") == "Screen")
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text, "ItemScreenPrinter");
                    }
                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text, "ReceiptLabel");
                    if (cmbvendor.SelectedIndex > 0)
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbvendor.Text, "VendorName");
                    }

                    System.Threading.Thread.Sleep(1000);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrint.Enabled = false;
                btnClear.Enabled = true;

            }
        }

        private void DataGVItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (DataGVItems.CurrentCell.ColumnIndex == 6 || DataGVItems.CurrentCell.ColumnIndex == 7) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGVItems.Rows.Count; i++)
            {

                DataGVItems.Rows[i].Cells["CheckBox"].Value = "False";

            }

            chkSelectAll.Checked = false;
            uncheckcount = 0;
            checkcount = 0;
            cmbLabelName.SelectedIndex = 0;
            lblTempName.Text = "";           
            cmbLabelPrinter.SelectedIndex = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            lobjQBConfiguration = new QBConfiguration();
            objPurchaseOrder = new clsPurchaseOrder();
            objPurchaseOrderLine = new clsPurchaseOrderLine();
            alData = new ArrayList();

            using (new HourGlass())
            {

                // if (lobjclsPurchaseOrderLine.Count > 0) // commented for daterange change
                if (lobjclsReceiptdata.Count > 0)
                {


                    DataGVItems.Visible = true;
                    chkSelectAll.Visible = true;
                    lblprintheader.Visible = true;
                    DataGVItems.Rows.Clear();
                    DataGVItems.Columns.Clear();
                    InitGrid();

                    if (receiptpagingindex < cntnextrecord1 - 1)
                    {
                        if (receiptpagingindex == 0) //enable after first record
                        {
                            btnPrevious.Enabled = true;
                        }
                        receiptpagingindex += 1;

                        transID = distinctrecord[receiptpagingindex];

                        var objvendorreceiptdata = (from receiveItems in lobjclsReceiptdata  //for date range chagne// lobjclsPurchaseOrderLine
                                                    where receiveItems.TransID == transID
                                                    select receiveItems).ToList();


                        FillPOReceiptItemsGrid(objvendorreceiptdata);

                        if (receiptpagingindex == cntnextrecord1 - 1)
                        {
                            btnPrevious.Enabled = true;
                            btnNext.Enabled = false;
                            // MessageBox.Show("no more receipt found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }


                    if (DataGVItems.Rows.Count > 0)
                    {
                        DataGVItems.Rows[0].Selected = true;


                        chkSelectAll.Checked = true;

                        chkSelectAll_Click(null, null);
                        gbOrderDetail.Visible = true;


                    }


                    return;
                }
                else
                {

                    DataGVItems.Visible = false;
                    gbOrderDetail.Visible = false;
                    chkSelectAll.Visible = false;
                    lblprintheader.Visible = false;
                    MessageBox.Show("Receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtponumber.Focus();
                    return;

                }



            } //HourGlass


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            lobjQBConfiguration = new QBConfiguration();
            objPurchaseOrder = new clsPurchaseOrder();
            objPurchaseOrderLine = new clsPurchaseOrderLine();
            alData = new ArrayList();

            //navigate receipt based on the po number: 27-Oct-2017


            //Naviagate receipts by vendor
            using (new HourGlass())
            {
                // if (lobjclsPurchaseOrderLine.Count > 0) //for date range chagne
                if (lobjclsReceiptdata.Count > 0)
                {

                    DataGVItems.Visible = true;
                    chkSelectAll.Visible = true;
                    lblprintheader.Visible = true;
                    DataGVItems.Rows.Clear();
                    DataGVItems.Columns.Clear();
                    InitGrid();




                    if (receiptpagingindex > 0)
                    {
                        if (receiptpagingindex == distinctrecord.Count - 1) //enable after first record
                        {
                            btnPrevious.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        receiptpagingindex -= 1;

                        transID = distinctrecord[receiptpagingindex];

                        var objvendorreceiptdata = (from receiveItems in lobjclsReceiptdata //for date range change //lobjclsPurchaseOrderLine
                                                    where receiveItems.TransID == transID
                                                    select receiveItems).ToList();


                        FillPOReceiptItemsGrid(objvendorreceiptdata);

                        if (receiptpagingindex == 0)
                        {
                            btnNext.Enabled = true;
                            btnPrevious.Enabled = false;
                            // MessageBox.Show("no more receipt found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                    if (DataGVItems.Rows.Count > 0)
                    {
                        DataGVItems.Rows[0].Selected = true;


                        chkSelectAll.Checked = true;

                        chkSelectAll_Click(null, null);
                        gbOrderDetail.Visible = true;


                    }


                    return;
                }
                else
                {

                    DataGVItems.Visible = false;
                    gbOrderDetail.Visible = false;
                    chkSelectAll.Visible = false;
                    lblprintheader.Visible = false;
                    MessageBox.Show("Receipt not found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtponumber.Focus();
                    return;

                }



            } //HourGlass


        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            dateindex = 0;

            dtfrom = dateTimePicker1.Value;
            dtto = dateTimePicker2.Value;
            dateindex -= 5;
            dtfrom = dtfrom.AddDays(dateindex);
            dtto = dtto.AddDays(dateindex);
            dateTimePicker1.Value = dtfrom;
            dateTimePicker2.Value = dtto;
        }

        private void btnRemoveDays_Click(object sender, EventArgs e)
        {
            dateindex = 0;
            dtfrom = dateTimePicker1.Value;
            dtto = dateTimePicker2.Value;
            dateindex += 5;
            dtfrom = dtfrom.AddDays(dateindex);
            dtto = dtto.AddDays(dateindex);
            dateTimePicker1.Value = dtfrom;
            dateTimePicker2.Value = dtto;
        }

        private void ReadSyncVendors(string strStartupPath)
        {
            cmbvendor.Items.Clear();
            long length = 0;
            XmlTextReader tr = new XmlTextReader(strStartupPath + "QuickBookVendors.xml");

            length = new System.IO.FileInfo(strStartupPath + "QuickBookVendors.xml").Length;
            if (length == 0)
            {
                MessageBox.Show("Please Sync QuickBook Vendors", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //clsPurchaseOrderLine objvendor = null;
            cmbvendor.Items.Add("-------Select Vendor-------");
            while (tr.Read())
            {


                if (tr.IsStartElement())
                {

                    if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "vendorname")
                    {

                        cmbvendor.Items.Add(tr.ReadElementString().ToString());

                    }


                }

            } //end while
            tr.Close(); //close open file
            cmbvendor.SelectedIndex = 0;

        }
        private void btnVendorSync_Click(object sender, EventArgs e)
        {
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsItemDetails lobjconnection = new clsItemDetails();
            objPurchaseOrderLine = new clsPurchaseOrderLine();
            lobjQBConfiguration = new QBConfiguration();
            strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\"+"QuickBookVendors.xml");
            string lstrProductDownCount = string.Empty;
            //Download Vendors from QuickBooks

            using (new HourGlass())
            {
                this.btnVendorSync.Enabled = false;
                if (lobjconnection.CheckQuickBooksConnection() == true)
                {
                    lstrProductDownCount = objPurchaseOrderLine.WriteVendorToXml(strStartupPath);
                }

                else
                {
                    btnVendorSync.Enabled = true;
                    MessageBox.Show("Please Open QuickBooks Company file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }



            if (Convert.ToInt32(lstrProductDownCount) > 0)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings(DateTime.Now.ToShortDateString(), "VendorSyncDate");
                MessageBox.Show("Vendor Sync Count is " + lstrProductDownCount, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadSyncVendors(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\"));
                this.btnVendorSync.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vedor not found in QuickBooks", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnVendorSync.Enabled = true;

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
                templatepath = string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("Receipttemppath"));

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
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), "Receipttemppath");
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
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), "Receipttemppath");
                        template = GetselectedtemplateOnApp(openFileDialog1.FileName.ToString());
                        if (template == "")
                        {
                            lblTempName.Text = "";
                        }
                        else
                        {
                            lblTempName.Text = Path.GetFileName(template);
                        }
                        //UpdateFilePath(openFileDialog1.FileName.ToString());
                    }

                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Eorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string GetselectedtemplateOnApp(string filepath)
        {
            try
            {
                if (filepath == "")
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

                if (printTempName.ToLower().ToString() != "Receipts".ToLower())
                {
                    MessageBox.Show("You have selected an '" + printTempName + "' type label template. Please select a 'Receipts'  type label template.", "Select Label", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        
    }
}
