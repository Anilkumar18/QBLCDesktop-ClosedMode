using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBLC;
using System.Drawing.Printing;
using System.Xml;
using System.Collections;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Diagnostics;
using System.Data.Odbc;
using System.Configuration;
using BarTender;
using System.Reflection;
using System.Xml.Linq;
using System.Net;
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;
//using NPOI;
//using NPOI.HSSF;
//using NPOI.SS;
//using NPOI.HPSF;
//using NPOI.HSSF.Model;
//using Microsoft.Office.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LabelConnector
{
    public partial class FrmPrintByItemSearch : Form
    {
        frmLabelConfig objfrmLabel = frmLabelConfig.GetInstance();
        QBConfiguration lobjQBConfiguration;
        clsItemDetails lobjItemsData = new clsItemDetails();
       // ArrayList lobjItemslist = new ArrayList();
        ArrayList alLineItemSearch = new ArrayList();
        ArrayList alLineItemSearchBySalesDec = new ArrayList();
        ArrayList alLineItemSearchByPurchaseDec = new ArrayList();
        ArrayList alLineItemSearchByVendor = new ArrayList();
        ArrayList alLineItemSearchBympn = new ArrayList();
        ArrayList alLineItemSearchByuom = new ArrayList();
        ArrayList alLineItemSearchByCustomField = new ArrayList();
        ArrayList alLineItemSearchBybarcodevalue = new ArrayList();
        FrmItemListSettingcs objfrmItemListScreenSetting = FrmItemListSettingcs.GetInstance();
        AutoCompleteStringCollection lststringcollection = new AutoCompleteStringCollection();
        List<clsItemDetails> lstItemarrayDetail = new List<clsItemDetails>();
        ArrayList lstAllItemList = new ArrayList();
        ArrayList lstAllItemNWNList = new ArrayList();
        bool isgridhidden = false;
        string lstrItemCustomFieldName = string.Empty;
        //int TotalRowCount = 0;

        //private int PgSize = 10000;
        //private int CurrentPageIndex = 1;
        //private int TotalPage = 0;

        private int mintTotalRecords = 0;
        private int mintPageSize = 0;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;
        string showItemflipvalue = string.Empty;
        int checkcount = 0;
        int uncheckcount = 0;
        public FrmPrintByItemSearch()
        {
            InitializeComponent();
            objfrmLabel.objdelOrderType += new delOrderType(this.fnSetPrinterType);
            objfrmItemListScreenSetting.objItemPrint += new ItemPrint(this.fnItemPrint);
            this.Text = "Label Connector-Item List Print";
            //lobjItemslist = lstItemlist;

            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Label Connector-Item List Print";

        }
        public void fnItemPrint()
        {
            if (lobjQBConfiguration.GetLabelConfigSettings("FlipItemQty") != "")
            {
                showItemflipvalue = lobjQBConfiguration.GetLabelConfigSettings("FlipItemQty").ToString();
                
            }
            if (string.IsNullOrWhiteSpace(txtItemSearch.Text.ToString()))
            {
                
               fillGrid();
                                
            }
            else
            {
                btnSearchItemDetails_Click(null, null);
            }

        }
        private void FrmPrintByItemSearch_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            showItemflipvalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FlipItemQty");

            //bind searchfield combox with item name field
            GetItemSearchField();
            panel1.Visible = false;
            pnlpaging.Visible = false;
            pnluppaging.Visible = false;
            btnBin.Visible = false;
            AutoCompleteSarchText();
        }

        private void ItemsBySearchFilter(ArrayList pobjSearchItem)
        {
            using (new HourGlass())
            {

                if (pobjSearchItem.Count > 0 &&  !string.IsNullOrWhiteSpace(txtItemSearch.Text))
                {

                    if (DataGVSearchItem.Rows.Count == 0)
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
                            cmbLabelPrinter.Enabled = true;
                            
                        }
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                        string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
                        if (template == "")
                        {
                            lblTempName.Text = "";
                        }
                        else
                        {
                            lblTempName.Text = Path.GetFileName(template);
                        }
                        if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                        {
                            fnGenerateLabelCB();
                        }
                        else
                        {
                            fnGetUDFLabels();
                        }

                    }

                    //set label as selected:03rd-July-2019
                    //cmbLabelName.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("saveinvoicelabelSingleMultiple");

                    lstrItemCustomFieldName = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField"));
                    DataGVSearchItem.Columns.Clear();
                   
                    //Define DataGrid Columns
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVSearchItem.Columns.Add(Column);


                    DataGVSearchItem.Columns["CheckBox"].Width = 45;
                    DataGVSearchItem.Columns["CheckBox"].ReadOnly = false;

                    DataGridViewCustomButtonColumn Itemcoledit = new DataGridViewCustomButtonColumn();
                    Itemcoledit.Width = 45;
                    Itemcoledit.Name = "Edit";
                    Itemcoledit.HeaderText = "Edit";
                    Itemcoledit.Text = "Edit";

                    Itemcoledit.UseColumnTextForButtonValue = true;
                    DataGVSearchItem.Columns.Add(Itemcoledit);

                    DataGVSearchItem.Columns.Add("itemname", "Name");
                    DataGVSearchItem.Columns["itemname"].Width = 160;

                    DataGVSearchItem.Columns.Add("SalesDesc", "Description");
                    DataGVSearchItem.Columns["SalesDesc"].Width = 210;

                    DataGridViewComboBoxColumn Itemcolbin = new DataGridViewComboBoxColumn();
                    Itemcolbin.Width = 100;
                    Itemcolbin.Name = "Bin";
                    Itemcolbin.HeaderText = "Bin";
                    DataGVSearchItem.Columns.Add(Itemcolbin);

                    DataGVSearchItem.Columns.Add("QuantityonHand", "Print Qty (On Hand)");
                    DataGVSearchItem.Columns["QuantityonHand"].Width = 65;

                    // DataGVSearchItem.Columns.Add("LotNo", "Lot No.");
                    DataGVSearchItem.Columns.Add("LotNo", lobjQBConfiguration.GetLabelConfigSettings("LotColumnName"));
                    DataGVSearchItem.Columns["LotNo"].Width = 70;


                    DataGVSearchItem.Columns.Add("QtyOnLabel", "Qty on Label");
                    DataGVSearchItem.Columns["QtyOnLabel"].Width = 70;
                    if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName)) //03rd july-2019
                    {
                        DataGVSearchItem.Columns.Add("CustQuantityField", lstrItemCustomFieldName);
                        DataGVSearchItem.Columns["CustQuantityField"].Width = 65;
                    }

                    DataGVSearchItem.Columns.Add("UnitOfMeasureSetRef", "U/M");
                    DataGVSearchItem.Columns["UnitOfMeasureSetRef"].Width = 100;
                    DataGVSearchItem.Columns.Add("BarCodeValue", "BarCode");
                    DataGVSearchItem.Columns["BarCodeValue"].Width = 100;

                    DataGVSearchItem.Columns.Add("ManufacturerPartNumber", "MPN");
                    DataGVSearchItem.Columns["ManufacturerPartNumber"].Width = 90;

                    DataGVSearchItem.Columns.Add("SalesPrice", "Price");
                    DataGVSearchItem.Columns["SalesPrice"].Width = 60;

                    DataGVSearchItem.Columns.Add("Type", "Type");
                    DataGVSearchItem.Columns["Type"].Width = 100;

                    DataGVSearchItem.Columns.Add("QuantityOnSalesOrder", "On Sales Order");
                    DataGVSearchItem.Columns["QuantityOnSalesOrder"].Width = 40;

                    DataGVSearchItem.Columns.Add("QuantityOnOrder", "Qty On Purchase Order");
                    DataGVSearchItem.Columns["QuantityOnOrder"].Width = 55;


                    //Display Items on the Grid
                 
                    DataGVSearchItem.Rows.Clear();
                    DataGVSearchItem.ReadOnly = false;


                    int lntsearchitemcount = 0;
                    foreach (clsItemDetails searchItems in pobjSearchItem)
                    {

                        DataGVSearchItem.Rows.Add();

                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].Value = searchItems.itemname;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].Value = searchItems.description;
    
                        if (showItemflipvalue == "Y")
                        {
                            DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = "1";
                        }
                        else
                        {
                            DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                        } 
                        //DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["LotNo"].Value = searchItems.LotNo;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QtyOnLabel"].Value = "1";
                        if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                        {
                            if (searchItems.CustomItem.Count > 0) //Esti
                            {
                                foreach (var item in searchItems.CustomItem)
                                {
                                   
                                    DataGVSearchItem.Rows[lntsearchitemcount].Cells["CustQuantityField"].Value = item.Key == lstrItemCustomFieldName.ToUpper() ? item.Value.ToString() : string.Empty;
                                }
                            }
                        }


                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].Value = searchItems.unitofmeasuresetref;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].Value = searchItems.barcodevalue;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].Value = searchItems.mpn;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].Value = searchItems.salesprice;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].Value = searchItems.itemtype;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].Value = searchItems.quantityonsalesorder;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].Value = searchItems.quantityonorder;

                        //make column readonly
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells[0].ReadOnly = false;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["Bin"].ReadOnly = false;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells[7].ReadOnly = true; //LotNo
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QtyOnLabel"].ReadOnly = true; //QtyOnLabel
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].ReadOnly = true;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].ReadOnly = true;

                        lntsearchitemcount++;

                    }
                    chkItemselect.Checked = true;
                    //show all checkboxes true by default
                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {

                        DataGVSearchItem.Rows[i].Cells[0].Value = "True";

                    }


                   // fnGenerateLabelCB();

                    panel1.Visible = true;
                  
                    gbOrderDetail.Visible = true;
                    chkItemselect.Visible = true;
                    btnBin.Visible = true;
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    panel1.Visible = false;
                    btnBin.Visible = false;
                    gbOrderDetail.Visible = false;
                    MessageBox.Show("There is no matching item found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }// hourglass end
        }

        ////paging for search filter
        //private void fillGrid1(ArrayList arrlist)
        //{
        //    lobjQBConfiguration = new QBConfiguration();
        //    // For Page view.
        //    //this.mintPageSize = int.Parse(this.tbPageSize.Text);
        //    this.mintPageSize = int.Parse(lobjQBConfiguration.GetLabelConfigSettings("PageSize"));
        //    this.mintTotalRecords = lstAllItemList.Count;
        //    this.mintPageCount = this.mintTotalRecords / this.mintPageSize;

        //    // Adjust page count if the last page contains partial page.
        //    if (this.mintTotalRecords % this.mintPageSize > 0)
        //        this.mintPageCount++;

        //    this.mintCurrentPage = 0;

        //    ItemsBySearchFilter1(arrlist);
        //}

        //private void ItemsBySearchFilter1(ArrayList pobjSearchItem)
        //{
        //    using (new HourGlass())
        //    {

        //        if (pobjSearchItem.Count > 0 && !string.IsNullOrWhiteSpace(txtItemSearch.Text))
        //        {

        //            if (DataGVSearchItem.Rows.Count == 0)
        //            {
        //                AddPrinters();
        //                //Set printer Setting
        //                if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") != "Screen")
        //                {

        //                    //from setting common printer
        //                    cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter");
        //                    cmbLabelPrinter.Enabled = false;

        //                }
        //                else
        //                {
        //                    //from setting screen

        //                    cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("ItemScreenPrinter");
        //                    cmbLabelPrinter.Enabled = true;
        //                }


        //                fnGenerateLabelCB();

        //            }

        //            DataGVSearchItem.Columns.Clear();

        //            //Define DataGrid Columns
        //            DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
        //            Column.Name = "CheckBox";
        //            Column.HeaderText = "";
        //            DataGVSearchItem.Columns.Add(Column);


        //            DataGVSearchItem.Columns["CheckBox"].Width = 45;
        //            DataGVSearchItem.Columns["CheckBox"].ReadOnly = false;

        //            DataGridViewCustomButtonColumn Itemcoledit = new DataGridViewCustomButtonColumn();
        //            Itemcoledit.Width = 45;
        //            Itemcoledit.Name = "Edit";
        //            Itemcoledit.HeaderText = "Edit";
        //            Itemcoledit.Text = "Edit";

        //            Itemcoledit.UseColumnTextForButtonValue = true;
        //            DataGVSearchItem.Columns.Add(Itemcoledit);

        //            DataGVSearchItem.Columns.Add("itemname", "Name");
        //            DataGVSearchItem.Columns["itemname"].Width = 160;

        //            DataGVSearchItem.Columns.Add("SalesDesc", "Description");
        //            DataGVSearchItem.Columns["SalesDesc"].Width = 210;

        //            DataGVSearchItem.Columns.Add("QuantityonHand", "Total Qty on hand");
        //            DataGVSearchItem.Columns["QuantityonHand"].Width = 65;

        //            DataGVSearchItem.Columns.Add("UnitOfMeasureSetRef", "U/M");
        //            DataGVSearchItem.Columns["UnitOfMeasureSetRef"].Width = 100;
        //            DataGVSearchItem.Columns.Add("BarCodeValue", "BarCode");
        //            DataGVSearchItem.Columns["BarCodeValue"].Width = 100;

        //            DataGVSearchItem.Columns.Add("ManufacturerPartNumber", "MPN");
        //            DataGVSearchItem.Columns["ManufacturerPartNumber"].Width = 90;

        //            DataGVSearchItem.Columns.Add("SalesPrice", "Price");
        //            DataGVSearchItem.Columns["SalesPrice"].Width = 60;

        //            DataGVSearchItem.Columns.Add("Type", "Type");
        //            DataGVSearchItem.Columns["Type"].Width = 100;

        //            DataGVSearchItem.Columns.Add("QuantityOnSalesOrder", "On Sales Order");
        //            DataGVSearchItem.Columns["QuantityOnSalesOrder"].Width = 40;

        //            DataGVSearchItem.Columns.Add("QuantityOnOrder", "Qty On Purchase Order");
        //            DataGVSearchItem.Columns["QuantityOnOrder"].Width = 55;


        //            //Display Items on the Grid

        //            DataGVSearchItem.Rows.Clear();

        //            int lntsearchitemcount = 0;
        //            foreach (clsItemDetails searchItems in pobjSearchItem)
        //            {

        //                DataGVSearchItem.Rows.Add();

        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].Value = searchItems.itemname;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].Value = searchItems.description;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].Value = searchItems.unitofmeasuresetref;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].Value = searchItems.barcodevalue;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].Value = searchItems.mpn;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].Value = searchItems.salesprice;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].Value = searchItems.itemtype;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].Value = searchItems.quantityonsalesorder;
        //                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].Value = searchItems.quantityonorder;
        //                lntsearchitemcount++;

        //            }
        //            chkItemselect.Checked = true;
        //            //show all checkboxes true by default
        //            for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
        //            {

        //                DataGVSearchItem.Rows[i].Cells[0].Value = "True";

        //            }


        //            // fnGenerateLabelCB();

        //            panel1.Visible = true;

        //            gbOrderDetail.Visible = true;
        //            chkItemselect.Visible = true;

        //            System.Threading.Thread.Sleep(1000);
        //        }
        //        else
        //        {
        //            panel1.Visible = false;

        //            gbOrderDetail.Visible = false;
        //            MessageBox.Show("There is no matching item found", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }

        //    }// hourglass end
        //}

        public void fnGetUDFLabels()
        {
            string mstrLabelName = string.Empty;
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
        private void ItemsShowAll(ArrayList pobjSearchItem)
        {
           // using (new HourGlass())
           // {


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
                        cmbLabelPrinter.Enabled = true;
                    }
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
            if (template == "")
            {
                lblTempName.Text = "";
            }
            else
            {
                lblTempName.Text = Path.GetFileName(template);
            }
            if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                    {
                        fnGenerateLabelCB();
                    }
                    else
                    {
                        fnGetUDFLabels();
                    }
                    

                    DataGVSearchItem.Columns.Clear();

                    //Define DataGrid Columns
                    DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
                    Column.Name = "CheckBox";
                    Column.HeaderText = "";
                    DataGVSearchItem.Columns.Add(Column);


                    DataGVSearchItem.Columns["CheckBox"].Width = 45;
                    DataGVSearchItem.Columns["CheckBox"].ReadOnly = false;

                    DataGridViewCustomButtonColumn Itemcoledit = new DataGridViewCustomButtonColumn();
                    Itemcoledit.Width = 45;
                    Itemcoledit.Name = "Edit";
                    Itemcoledit.HeaderText = "Edit";
                    Itemcoledit.Text = "Edit";

                    Itemcoledit.UseColumnTextForButtonValue = true;
                    DataGVSearchItem.Columns.Add(Itemcoledit);

                    DataGVSearchItem.Columns.Add("itemname", "Name");
                    DataGVSearchItem.Columns["itemname"].Width = 160;

                    DataGVSearchItem.Columns.Add("SalesDesc", "Description");
                    DataGVSearchItem.Columns["SalesDesc"].Width = 210;

                    DataGVSearchItem.Columns.Add("QuantityonHand", "Print Qty (On Hand)");
                    DataGVSearchItem.Columns["QuantityonHand"].Width = 65;

                    DataGVSearchItem.Columns.Add("LotNo", "Lot No.");
                    DataGVSearchItem.Columns["LotNo"].Width = 70;

                    DataGVSearchItem.Columns.Add("QtyOnLabel", "Qty on Label");
                    DataGVSearchItem.Columns["QtyOnLabel"].Width = 70;

                    DataGVSearchItem.Columns.Add("UnitOfMeasureSetRef", "U/M");
                    DataGVSearchItem.Columns["UnitOfMeasureSetRef"].Width = 100;
                    DataGVSearchItem.Columns.Add("BarCodeValue", "BarCode");
                    DataGVSearchItem.Columns["BarCodeValue"].Width = 100;

                    DataGVSearchItem.Columns.Add("ManufacturerPartNumber", "MPN");
                    DataGVSearchItem.Columns["ManufacturerPartNumber"].Width = 90;

                    DataGVSearchItem.Columns.Add("SalesPrice", "Price");
                    DataGVSearchItem.Columns["SalesPrice"].Width = 60;

                    DataGVSearchItem.Columns.Add("Type", "Type");
                    DataGVSearchItem.Columns["Type"].Width = 100;

                    DataGVSearchItem.Columns.Add("QuantityOnSalesOrder", "On Sales Order");
                    DataGVSearchItem.Columns["QuantityOnSalesOrder"].Width = 40;

                    DataGVSearchItem.Columns.Add("QuantityOnOrder", "Qty On Purchase Order");
                    DataGVSearchItem.Columns["QuantityOnOrder"].Width = 55;


                    //Display Items on the Grid
                    
                    DataGVSearchItem.Rows.Clear();

                    int lntsearchitemcount = 0;
                    foreach (clsItemDetails searchItems in pobjSearchItem)
                    {

                        DataGVSearchItem.Rows.Add();

                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].Value = searchItems.itemname;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].Value = searchItems.description;
                if (showItemflipvalue == "Y")
                {
                    DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = "1";
                }
                else
                {
                    DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                }
                //DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["LotNo"].Value = searchItems.LotNo; //LotNo
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QtyOnLabel"].Value = "1"; //QtyOnLabel
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].Value = searchItems.unitofmeasuresetref;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].Value = searchItems.barcodevalue;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].Value = searchItems.mpn;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].Value = searchItems.salesprice;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].Value = searchItems.itemtype;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].Value = searchItems.quantityonsalesorder;
                        DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].Value = searchItems.quantityonorder;
                        lntsearchitemcount++;

                    }
                    chkItemselect.Checked = true;
                    //show all checkboxes true by default
                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {

                        DataGVSearchItem.Rows[i].Cells[0].Value = "True";

                    }

                    if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                    {

                        fnGenerateLabelCB();
                    }
                    else
                    {
                        fnGetUDFLabels();
                    }

                    panel1.Visible = true;
                    //btnclosed.Visible = true;
                    gbOrderDetail.Visible = true;
                    chkItemselect.Visible = true;

                   // System.Threading.Thread.Sleep(1000);
               

           // }// hourglass end
        }

        private void GetItemSearchField()
        {
           
            var lobjItemSearch = new Dictionary<string, string>();
            lobjItemSearch["0"] = "All fields";
            lobjItemSearch["1"] = "Item Name";
            lobjItemSearch["2"] = "Description(Sales)";
            lobjItemSearch["3"] = "Purchase Description";
            lobjItemSearch["4"] = "Preferred Vendor";
            lobjItemSearch["5"] = "Man. Part Number";
            lobjItemSearch["6"] = "U/M";
            lobjItemSearch["7"] = "Custom fields";
            cmbserach.DataSource = new BindingSource(lobjItemSearch, null);
            cmbserach.DisplayMember = "Value";
            cmbserach.ValueMember = "Key"; 



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

        private void FrmPrintByItemSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();

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
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
            if (template == "")
            {
                lblTempName.Text = "";
            }
            else
            {
                lblTempName.Text = Path.GetFileName(template);
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
                System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex,
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
                    System.Drawing.Rectangle buttonArea = cellBounds;
                    System.Drawing.Rectangle buttonAdjustment =
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

                    cellStyle.Font = new System.Drawing.Font("Verdana", 9);
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        elementState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }

        private void chkItemselect_Click(object sender, EventArgs e)
        {
            
            int lintRowsSelected = 0;

            if (DataGVSearchItem.Rows.Count > 0)
            {

                lintRowsSelected = DataGVSearchItem.Rows.Count;

                if (chkItemselect.Checked == true)
                {
                    btnPrint.Enabled = true;
                    for (int i = 0; i < lintRowsSelected; i++)
                    {

                        DataGVSearchItem.Rows[i].Cells[0].Value = "True";

                    }
                }
                else
                {

                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {
                        DataGVSearchItem.Rows[i].Cells[0].Value = "False";
                    }
              
                    checkcount = 0;
                    btnPrint.Enabled = false;


                }


            }

        }
        private void Editquantitytoprint(DataGridView grid)
        {
            bool blnvar = false;
            if (grid.Enabled == false) { grid.Enabled = true; }
            if (grid.ReadOnly == true) { grid.ReadOnly = false; }
            int lntcurrrowndx = 0;
            int lntselrowndx = 0;

            lntselrowndx = grid.CurrentCell.RowIndex;


            blnvar = Convert.ToBoolean(grid.Rows[grid.CurrentCell.RowIndex].Cells[0].Value);
            if (!blnvar)
            {
                MessageBox.Show("Please select checkbox to edit Total Quantity", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            using (new HourGlass())
            {
            foreach (DataGridViewRow Row in DataGVSearchItem.Rows)
            {
                lntcurrrowndx = Row.Index;

                    if (lntcurrrowndx == lntselrowndx)
                    {

                        grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].ReadOnly = false;

                        grid.Rows[lntcurrrowndx].Cells[2].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[3].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[6].ReadOnly = false;
                        grid.Rows[lntcurrrowndx].Cells[7].ReadOnly = false;
                        //3rd-July-2019
                        if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                        {
                            // grid.Rows[lntcurrrowndx].Cells["CustQuantityField"].ReadOnly = false;
                            grid.Rows[lntcurrrowndx].Cells[8].ReadOnly = false;
                        }
                        else
                        {
                            if (grid.Rows[lntcurrrowndx].Cells[8].ReadOnly == false)
                            {
                                grid.Rows[lntcurrrowndx].Cells[8].ReadOnly = true;
                            }
                           
                        }

                       // grid.Rows[lntcurrrowndx].Cells[7].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[9].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[10].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[11].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[12].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[13].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[14].ReadOnly = true;

                        grid.CurrentCell = grid.Rows[lntcurrrowndx].Cells["QuantityonHand"];

                        grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Bold);
                        //grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].Style.BackColor = Color.Gainsboro;
                        grid.Rows[lntcurrrowndx].Cells[6].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Bold);
                        grid.Rows[lntcurrrowndx].Cells[7].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Bold);
                        //3rd-July-2019
                        if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                        {
                            grid.Rows[lntcurrrowndx].Cells["CustQuantityField"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Bold);
                        }

                        grid.BeginEdit(true);
                    }
                    else
                    {

                        grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].ReadOnly = true;

                        grid.Rows[lntcurrrowndx].Cells[2].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[3].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[6].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[7].ReadOnly = true;
                        //3rd-July-2019
                        if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                        {
                            // grid.Rows[lntcurrrowndx].Cells["CustQuantityField"].ReadOnly = true;
                            grid.Rows[lntcurrrowndx].Cells[8].ReadOnly = true;
                        }
                        else
                        {
                            if(grid.Rows[lntcurrrowndx].Cells[8].ReadOnly==false)
                            {
                                grid.Rows[lntcurrrowndx].Cells[8].ReadOnly = true;
                            }
                        }
                        
                        //grid.Rows[lntcurrrowndx].Cells[7].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[9].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[10].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[11].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[12].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[13].ReadOnly = true;
                        grid.Rows[lntcurrrowndx].Cells[14].ReadOnly = true;
                        // 3rd-july-2019
                        //grid.Rows[lntcurrrowndx].Cells[14].ReadOnly = true;

                        // grid.Rows[grid.CurrentCell.RowIndex].Cells["SalesOrderLineQuantityToPrint"].Style.ForeColor = Color.Red;
                        grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                        grid.Rows[lntcurrrowndx].Cells["QuantityonHand"].Style.BackColor = Color.White;

                        grid.Rows[lntcurrrowndx].Cells[6].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                        grid.Rows[lntcurrrowndx].Cells[6].Style.BackColor = Color.White;

                        grid.Rows[lntcurrrowndx].Cells[7].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                        grid.Rows[lntcurrrowndx].Cells[7].Style.BackColor = Color.White;
                        //3rd-July-2019
                        if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                        { 
                        grid.Rows[lntcurrrowndx].Cells["CustQuantityField"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                        grid.Rows[lntcurrrowndx].Cells["CustQuantityField"].Style.BackColor = Color.White;
                       }


                    }

            }
        }


        }

        private void DataGVSearchItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uncheckcount = 0;
            checkcount = 0;

            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                
                //Edit Qty on Hand
                Editquantitytoprint(DataGVSearchItem);
                return;

            }
            
            if (e.ColumnIndex != -1)
            {
                if (DataGVSearchItem.CurrentRow != null)
                {
                   
                    if (DataGVSearchItem.CurrentRow.Cells[e.ColumnIndex].Value == null)
                    {
                        return;
                    }
                }
            }


            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                if (Convert.ToString(DataGVSearchItem.CurrentRow.Cells[0].Value) == "True")
                {
                    DataGVSearchItem.CurrentRow.Cells[0].Value = "False";
                    //Reset edited 

                    DataGVSearchItem.CurrentRow.Cells["QuantityonHand"].ReadOnly = true;

                    DataGVSearchItem.CurrentRow.Cells["QuantityonHand"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);

                    DataGVSearchItem.CurrentRow.Cells[6].ReadOnly = true;

                    DataGVSearchItem.CurrentRow.Cells[6].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);

                    DataGVSearchItem.CurrentRow.Cells["QtyOnLabel"].ReadOnly = true;

                    DataGVSearchItem.CurrentRow.Cells["QtyOnLabel"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                    //03rd-July-2019
                    if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                    {
                        DataGVSearchItem.CurrentRow.Cells["CustQuantityField"].ReadOnly = true;
                        DataGVSearchItem.CurrentRow.Cells["CustQuantityField"].Style.Font = new System.Drawing.Font("Verdana", 8, FontStyle.Regular);
                    }


                    chkItemselect.Checked = false;

                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {
                        if (Convert.ToString(DataGVSearchItem.Rows[i].Cells[0].Value) == "False")
                        {

                            uncheckcount++;

                        }
                    }

                    if (uncheckcount == DataGVSearchItem.Rows.Count)
                    {
                        btnPrint.Enabled = false;
                        //chkItemselect.Checked = false;
                    }
                    else
                    {
                        btnPrint.Enabled = true;
                        //chkItemselect.Checked = false;
                    }


                }
                else
                {

                    DataGVSearchItem.CurrentRow.Cells[0].Value = "True";

                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {
                        if (Convert.ToString(DataGVSearchItem.Rows[i].Cells[0].Value) == "True")
                        {

                            checkcount++;

                        }
                    }
                    if (checkcount == DataGVSearchItem.Rows.Count)
                    {
                        chkItemselect.Checked = true;
                        //btnPrint.Enabled = true;
                    }
                    else
                    {
                        chkItemselect.Checked = false;
                        //btnPrint.Enabled = false;
                    }

                    if (checkcount > 0)
                        btnPrint.Enabled = true;
                    else
                        btnPrint.Enabled = false;




                }
            }//
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
            {
               
               DataGVSearchItem.Rows[i].Cells["CheckBox"].Value = "False";
                
            }

            chkItemselect.Checked = false;
            uncheckcount = 0;
            checkcount = 0;
            cmbLabelName.SelectedIndex = 0;
            cmbLabelPrinter.SelectedIndex = 0;
            //txtQtyOnLabel.Text = "";
            //txtQtyToPrint.Text = "";

        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            parentForm.GridPanel = true;
            ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            this.Hide();
            this.Close();
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();

            try
            {
               
                //print Item based on searach
                using (new HourGlass())
                {
                    if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "U") // print label based on setting for bartender or user defined label
                    {
                        PrintUDFItemAllBySearch();
                    }
                    else
                    {
                        PrintItemsBySearch();
                    }
                

                if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") == "Screen")
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text, "ItemScreenPrinter");
                }
                lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text, "LabelName");

                System.Threading.Thread.Sleep(1000);
                }


             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                System.Threading.Thread.Sleep(500);
                btnPrint.Enabled = false;
                btnClear.Enabled = true;
            
            }
        }


        private void PrintItemsBySearch()
        {


            lobjQBConfiguration = new QBConfiguration();

            int cntChk = 0;

            try
            {

                if (cmbLabelName.SelectedIndex > 0)
                {
                    btnPrint.Enabled = false;
                  
                        if (CheckMandetory())
                        {

                            if (DataGVSearchItem.Rows.Count > 0)
                            {
                                for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                                {
                                    if (DataGVSearchItem.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "False")
                                    {
                                        cntChk = cntChk + 1;
                                    }

                                    
                                }
                                if (cntChk == DataGVSearchItem.Rows.Count)
                                {
                                    MessageBox.Show("Please Check At Least One Record To Print", "Label Connector");
                                    return;
                                }

                                for (int j = 0; j < DataGVSearchItem.Rows.Count; j++)
                                {


                                    if (DataGVSearchItem.Rows[j].Cells["CheckBox"].Value.ToString().Trim() == "True")
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
                                                if (DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value == null)
                                                {
                                                    MessageBox.Show("Qty on Hand/ Print Qty is Null, Please use edit function to add a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    btnPrint.Enabled = true;
                                                    return;
                                                }
                                                
                                            //Allow -ve Qty to print : Date 21-sept-2017
                                            if (DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value.ToString().StartsWith("-"))
                                                {
                                                    MessageBox.Show("Qty to print can not be negative, Please use edit function to edit a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    btnPrint.Enabled = true;
                                                    return;
                                                }
                                                intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value.ToString().Trim())));
                                             //Avoid Qty on hand zero to be print :Date 21-May-2018
                                             if(intQuantity==0)
                                                {
                                                    MessageBox.Show("Qty on Hand/ Print Qty is zero, Please use edit function to add a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    btnPrint.Enabled = true;
                                                    return;
                                                }
                                            this.Cursor = Cursors.WaitCursor;
                                                BtFormat = BtApp.Formats.Open(strProdLblPath + "\\" + strLabelName, true, strProdPrinter);

                                                                                            
                                                ArrayList alLineItem = null;

                                                clsItemDetails objclsItemDetails = null;
                                                Type objClsType;
                                                object strPropertyValue = null;

                                                objclsItemDetails = new clsItemDetails();

                                                
                                                //Get Item details based on search
                                                var liItemRecord = from clsItemDetails objItemRecord in lstAllItemList  //alLineItemSearch
                                                                   where objItemRecord.itemname == Convert.ToString(DataGVSearchItem.Rows[j].Cells["itemname"].Value.ToString().Trim())
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
                                                                if (DataGVSearchItem.Rows[j].Cells[6].Value != null)
                                                                {
                                                                    strPropertyValue = Convert.ToString(DataGVSearchItem.Rows[j].Cells[6].Value.ToString().Trim());
                                                                }
                                                            }
                                                            //Add QtyOnHand to print
                                                            if (BtSubString.Name.ToLower().Trim() == "qtyonlabel")
                                                            {
                                                                if (DataGVSearchItem.Rows[j].Cells[7].Value != null)
                                                                {
                                                                    strPropertyValue = Convert.ToString(DataGVSearchItem.Rows[j].Cells[7].Value.ToString().Trim());
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
                                lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "saveinvoicelabel");

                                //save printer name :Date 11-Feb-2017
                                lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "invpackprinter");


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

        private void PrintUDFItemAllBySearch()
        {
            int cntChk = 0;
            ArrayList arrList = null;
            string lstrlotno = string.Empty;
            string lotnocolumnname = string.Empty;
            string lstrqtyonlable = string.Empty;
            string lstrcustomfieldcolvalue = string.Empty;
            string lstrconfigcustomfieldvalue = string.Empty;
            string fileName = string.Empty;
            string filePath = string.Empty;
            string SetValuesForTransType = string.Empty;
            bool blnIsIncrementcounter = false;
            string SetTemplatewidth = string.Empty;
            string SetTemplateheight = string.Empty;
            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> objheaderfield = new List<QuickBooksField>();

            try
            {
                using (new HourGlass())
                {

                    lobjQBConfiguration = new QBConfiguration();

                    if (cmbLabelPrinter.SelectedIndex == 0) //check printer selection
                    {
                        MessageBox.Show("Select Printer", "Label Connector");
                        return;

                    }


                    //btnPrint.Enabled = false;
                    if (CheckMandetory())
                    {
                        if (cmbLabelName.SelectedIndex > 0)
                        {
                            if (DataGVSearchItem.Rows.Count > 0)
                            {

                                for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                                {
                                    if (DataGVSearchItem.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "False")
                                    {
                                        cntChk = cntChk + 1;
                                    }
                                }
                                if (cntChk == DataGVSearchItem.Rows.Count)
                                {
                                    MessageBox.Show("Please Check At Least One Record To Print", "Label Connector");
                                    return;
                                }
                                //clsInvoiceLine objclsInvoiceLine1 = new clsInvoiceLine();

                                // string snoindex = string.Empty;
                                // string strProdLblPath = string.Empty;
                                string strProdPrinter = string.Empty;

                                // char[] snsplit = new char[] { ',' };
                                // int qtyvalue = 0;
                                // bool isNumericQuantity = false;
                                for (int j = 0; j < DataGVSearchItem.Rows.Count; j++)
                                {

                                    if (DataGVSearchItem.Rows[j].Cells["CheckBox"].Value.ToString().Trim() == "True")
                                    {
                                        string strLabelName = string.Empty;

                                        strLabelName = Convert.ToString(cmbLabelName.Text);

                                        strProdPrinter = cmbLabelPrinter.Text;
                                        int intQuantity = 0;

                                        string lstrPropertyValue = string.Empty;

                                        if ((cmbLabelName.SelectedIndex != 0))
                                        {

                                            //  intQuantity = Convert.ToInt32(DataGVSearchItem.Rows[j].Cells["Quantity"].Value);

                                            if (DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value == null)
                                            {
                                                MessageBox.Show("Qty on Hand/ Print Qty is Null, Please use edit function to add a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                btnPrint.Enabled = true;
                                                return;
                                            }

                                            //Allow -ve Qty to print : Date 21-sept-2017
                                            if (DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value.ToString().StartsWith("-"))
                                            {
                                                MessageBox.Show("Qty to print can not be negative, Please use edit function to edit a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                btnPrint.Enabled = true;
                                                return;
                                            }
                                            intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value)));
                                            //Avoid Qty on hand zero to be print :Date 21-May-2018
                                            if (intQuantity == 0)
                                            {
                                                MessageBox.Show("Qty on Hand/ Print Qty is zero, Please use edit function to add a qty.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                btnPrint.Enabled = true;
                                                return;
                                            }


                                            //  ArrayList alLineItem = null;

                                            // clsItemDetails objclsItemdetailsLine = null;

                                            // Type objClsType;

                                            // string flipPoQtyvalue = string.Empty;

                                            //objclsItemdetailsLine = new clsItemDetails();


                                            // alLineItem = objclsItemdetailsLine.GetINVLine(Convert.ToString(DataGVSearchItem.Rows[j].Cells["InvoiceLineQuantityOnLabel"].Value), Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineItemRefFullName"].Value), alData, alInvoiceLineItems, txtOrderNumber.Text, Convert.ToString(DataGVItems.Rows[j].Cells["InvoiceLineTxnLineID"].Value), Convert.ToDateTime(DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[0].Value), (string)DataGVOrders.Rows[DataGVOrders.CurrentRow.Index].Cells[2].Value, out lobjDataExtension, AutoManualPath, lobjQBConfiguration.GetLabelConfigSettings("AutoManualCheck"));

                                            // objClsType = objclsItemdetailsLine.GetType();
                                            ArrayList alLineItem = null;

                                            clsItemDetails objclsItemDetails = null;
                                            Type objClsType;
                                            object strPropertyValue = null;

                                            objclsItemDetails = new clsItemDetails();


                                            //Get Item details based on search

                                            var liItemRecord = from clsItemDetails objItemRecord in lstAllItemList  //alLineItemSearch
                                                               where ((objItemRecord.itemname).ToString() == Convert.ToString(DataGVSearchItem.Rows[j].Cells["itemname"].Value)) && ((Convert.ToString(objItemRecord.description) == null ? "" : objItemRecord.description.ToString()) == (Convert.ToString(DataGVSearchItem.Rows[j].Cells["SalesDesc"].Value)))
                                                               select objItemRecord;

                                            alLineItem = new ArrayList(liItemRecord.ToList());

                                            foreach(clsItemDetails Binvalue in alLineItem)
                                            {
                                                if (DataGVSearchItem.Rows[j].Cells["Bin"].Selected)
                                                {
                                                    Binvalue.bin = DataGVSearchItem.Rows[j].Cells["Bin"].Value.ToString().Trim();
                                                }
                                            }
                                            
                                            objClsType = objclsItemDetails.GetType();


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


                                            intQuantity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble((DataGVSearchItem.Rows[j].Cells["QuantityonHand"].Value)))); 
                                           
                                            //New column added:Date 05-APR-2019
                                             lstrlotno = DataGVSearchItem.Rows[j].Cells["LotNo"].Value != null ? Convert.ToString(DataGVSearchItem.Rows[j].Cells["LotNo"].Value.ToString().Trim()) : "";
                                             lstrqtyonlable = DataGVSearchItem.Rows[j].Cells["QtyOnLabel"].Value != null ? Convert.ToString(DataGVSearchItem.Rows[j].Cells["QtyOnLabel"].Value.ToString().Trim()) : "";
                                            //allow custom field value to print set in item setting screen:03-July-2019
                                            lstrconfigcustomfieldvalue = !string.IsNullOrWhiteSpace(Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField"))) ? Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField")).ToLower() : "";

                                             if(!string.IsNullOrWhiteSpace(lstrconfigcustomfieldvalue))
                                             {
                                                    lstrcustomfieldcolvalue = DataGVSearchItem.Rows[j].Cells["CustQuantityField"].Value != null ? Convert.ToString(DataGVSearchItem.Rows[j].Cells["CustQuantityField"].Value.ToString().Trim()) : "";
                                             }
                                            //get lotno column name
                                            lotnocolumnname = DataGVSearchItem.Columns["LotNo"].Name.ToString().ToLower();

                                            //print here...

                                            //create pdf and  image
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
                                            //    lobjTemplatexml.PrintTemplateForMultipleItemsIncrementCounter(strLabelName, SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lstrlotno, lstrqtyonlable, objfieldlist, alLineItem);
                                            //    //print multiple images:10-APR-2019
                                            //    filePath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\";
                                            //    PrintMultipleImages(filePath);
                                            //}
                                            //else
                                            //{
                                            lobjTemplatexml.PrintTemplateForMultipleItems(strLabelName, SetTemplatewidth, SetTemplateheight, SetValuesForTransType, intQuantity, lstrlotno, lotnocolumnname, lstrqtyonlable, lstrcustomfieldcolvalue, lstrconfigcustomfieldvalue, objfieldlist, alLineItem, cmbLabelPrinter.Text.ToString());
                                                //print image
                                                filePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfPrintImagesList" + "\\" + cmbLabelName.Text.ToString() + "\\" + cmbLabelName.Text.ToString() + ".Tiff");
                                                Print(filePath, intQuantity);
                                            //}



                                        }//end Auto



                                    }//end checkbox true

                                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "invprinter");

                                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelName.Text.ToString(), "saveinvoicelabelSingleMultiple");


                                }//end DataGVItemRowscount
                            }//end CheckMandetory






                        }//end of checkauto

                    }// end hourglass

                }
            }
            catch (Exception ex)
            {


            }


        }

        public void Print(string FileName, int pintprintqty)
        {
            StringBuilder logMessage = new StringBuilder();
            
            try
            {
                if (string.IsNullOrWhiteSpace(FileName)) return; 
                PrintDocument pd = new PrintDocument();


                PrintController printController = new StandardPrintController();
                pd.PrintController = printController;

                
                pd.DefaultPageSettings.PrinterSettings.PrinterName = cmbLabelPrinter.Text.ToString();
                pd.PrinterSettings.Copies = Convert.ToInt16(pintprintqty);
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);


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
                    
                    args.Graphics.DrawImage(i, m);
                };
                pd.Print();
            }
            catch (Exception ex)
            {

                QBHelper.WriteLog("ErrorCatch : {0}" + ex.ToString());
            }
            finally
            {
                logMessage.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));

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

        private bool CheckMandetory()
        {

            //if (txtItemName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter item to print.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtItemName.Focus();
            //    return false;
            //}
            //else if (txtQuantitytoprint.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter quantity to print.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtQuantitytoprint.Focus();
            //    return false;
            //}
            if (cmbLabelPrinter.SelectedIndex == 0)
            {
                MessageBox.Show("Please select printer.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLabelPrinter.Focus();
                return false;
            }
            else if (cmbLabelName.SelectedIndex == 0 || lblTempName.Text == "")
            {
                MessageBox.Show("Please select label to be printed.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblTempName.Text = "";
                btnSelect.Focus();
                return false;
            }

            else
            {
                return true;
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
        private void findItemsInAllFields()
        {
            int FirstChr;
            alLineItemSearch.Clear();
            alLineItemSearchByCustomField.Clear();
          //search in item name field
            var liItembyname = from clsItemDetails objItemRecord in lstAllItemList
                               where objItemRecord.itemname.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim())
                               select objItemRecord;
            if (liItembyname !=null && liItembyname.Count() > 0 )
            {
                alLineItemSearch = new ArrayList(liItembyname.ToList());
                
            }

            //search in sales desc

            var liItembysalesdesc = from clsItemDetails objItemRecord in lstAllItemList
                                    where (objItemRecord.description != null && objItemRecord.description.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                    select objItemRecord;
            if (liItembysalesdesc != null && liItembysalesdesc.Count() > 0)
            {
                alLineItemSearchBySalesDec = new ArrayList(liItembysalesdesc.ToList());
                alLineItemSearch.AddRange(alLineItemSearchBySalesDec);
            }

            //search in purchase desc

            var liItembypurchasedesc = from clsItemDetails objItemRecord in lstAllItemList
                                       where (objItemRecord.purchasedesc != null && objItemRecord.purchasedesc.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                       select objItemRecord;
            if (liItembypurchasedesc != null && liItembypurchasedesc.Count() > 0)
            {
                alLineItemSearchByPurchaseDec = new ArrayList(liItembypurchasedesc.ToList());
                alLineItemSearch.AddRange(alLineItemSearchByPurchaseDec);
            }

            //search in Vendor name
            var liItembyvendor = from clsItemDetails objItemRecord in lstAllItemList
                                 where (objItemRecord.prefvendorref != null && objItemRecord.prefvendorref.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                 select objItemRecord;
            if (liItembyvendor != null && liItembyvendor.Count() > 0)
            {
                alLineItemSearchByVendor = new ArrayList(liItembyvendor.ToList());
                alLineItemSearch.AddRange(alLineItemSearchByVendor);
            }

            //search in man. part number
            var liItembympn = from clsItemDetails objItemRecord in lstAllItemList
                              where (objItemRecord.mpn != null && objItemRecord.mpn.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                              select objItemRecord;
            if (liItembympn != null && liItembympn.Count() > 0)
            {
                alLineItemSearchBympn = new ArrayList(liItembympn.ToList());
                alLineItemSearch.AddRange(alLineItemSearchBympn);
            }

            //search in  UOM
            var liItembyuom = from clsItemDetails objItemRecord in lstAllItemList
                              where (objItemRecord.unitofmeasuresetref != null && objItemRecord.unitofmeasuresetref.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                              select objItemRecord;
            if (liItembyuom != null && liItembyuom.Count() > 0)
            {
                alLineItemSearchByuom = new ArrayList(liItembyuom.ToList());
                alLineItemSearch.AddRange(alLineItemSearchByuom);
            }

            //search in BarCodevalue           
            var liItembybarcode = from clsItemDetails objItemRecord in lstAllItemList
                               where( objItemRecord.barcodevalue !=null && objItemRecord.barcodevalue.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                               select objItemRecord;
            if (liItembybarcode != null && liItembybarcode.Count() > 0)
            {
                alLineItemSearchBybarcodevalue = new ArrayList(liItembybarcode.ToList());
                alLineItemSearch.AddRange(alLineItemSearchBybarcodevalue);

            }


            //search in custom field

            foreach (clsItemDetails itemcustomfield in lstAllItemList)
            {

                if (itemcustomfield.CustomItem.Count > 0)
                {
                    foreach (KeyValuePair<string, string> dictcustomitem in itemcustomfield.CustomItem)
                    {
                        FirstChr = dictcustomitem.Value.ToUpper().IndexOf(txtItemSearch.Text.ToString().ToUpper());
                        if (FirstChr != -1)
                        {
                            alLineItemSearchByCustomField.Add(itemcustomfield);
                            break;

                        }

                    }

                }

            }
            if (alLineItemSearchByCustomField.Count > 0)
            {

                alLineItemSearch.AddRange(alLineItemSearchByCustomField);
            }

            ItemsBySearchFilter(RemoveDuplicate(alLineItemSearch));
        
        }


        private static ArrayList RemoveDuplicate(ArrayList sourceList)
        {
            ArrayList list = new ArrayList();
            foreach (clsItemDetails item in sourceList)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            } return list;
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
                
                ReadSyncItems(strStartupPath);
                
                var liItemautocomplete = from clsItemDetails objItemRecord in lstAllItemList
                                         orderby objItemRecord.Name
                                         select objItemRecord.Name;

                foreach (var searchitems in liItemautocomplete)
                {
                    lststringcollection.Add(searchitems.ToString());
                }

                txtItemSearch.AutoCompleteMode = AutoCompleteMode.Suggest;

                txtItemSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtItemSearch.AutoCompleteCustomSource = lststringcollection;
            }

        }  
       
        private void btnSearchItemDetails_Click(object sender, EventArgs e)
        {
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            pnlpaging.Visible = false;
            pnluppaging.Visible = false;
            DataGVSearchItem.ReadOnly = true;
           
            string lstrItemxmlstring=string.Empty;
            if (string.IsNullOrWhiteSpace(txtItemSearch.Text.ToString()))
            {

                MessageBox.Show("Please enter item search text", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemSearch.Focus();
                return;
            }
            else
            {
               
                    lstAllItemList.Clear();

                    using (new HourGlass())
                    {
                                       
                    string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");
               
                    if (!File.Exists(strStartupPath + "QuickBookItems.xml"))
                    {
                        MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    ReadSyncItems(strStartupPath);
                    if (isgridhidden == true) //16-Jan-2019
                    {
                        panel1.Visible = false;
                        pnlpaging.Visible = false;
                        pnluppaging.Visible = false;
                        gbOrderDetail.Visible = false;
                        btnBin.Visible = false;
                        lstAllItemList.Clear();
                      
                        return;
                       
                    }
                }
                    
            
            }
            switch (Convert.ToInt32(cmbserach.SelectedValue))
            { 
            
                case 0: //  All fields search
                    using (new HourGlass())
                    {
                        findItemsInAllFields();
                    }
                    break;
                case 1:
                    //Get Item details based on field item name
                    var liItembyname = from clsItemDetails objItemRecord in lstAllItemList
                                       where objItemRecord.itemname.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim())
                                       select objItemRecord;

                    alLineItemSearch = new ArrayList(liItembyname.ToList());
                    ItemsBySearchFilter(alLineItemSearch);
                    
                    break;
                case 2:
                    //Get Item details based on field sales description
                    var liItembysalesdesc = from clsItemDetails objItemRecord in lstAllItemList
                                       where (objItemRecord.description != null && objItemRecord.description.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                       select objItemRecord;

                    alLineItemSearch = new ArrayList(liItembysalesdesc.ToList());
                    ItemsBySearchFilter(alLineItemSearch);
                    
                    break;
                case 3:
                    //Get Item details based on field purchase description
                    var liItembypurchasedesc = from clsItemDetails objItemRecord in lstAllItemList
                                               where (objItemRecord.purchasedesc != null && objItemRecord.purchasedesc.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                            select objItemRecord;

                    alLineItemSearch = new ArrayList(liItembypurchasedesc.ToList());
                    ItemsBySearchFilter(alLineItemSearch);
                    
                    break;
                case 4:
                    //Get Item details based on field vendor
                    var liItembyvendor = from clsItemDetails objItemRecord in lstAllItemList
                                         where (objItemRecord.prefvendorref !=null && objItemRecord.prefvendorref.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                            select objItemRecord;

                     alLineItemSearch = new ArrayList(liItembyvendor.ToList());
                     ItemsBySearchFilter(alLineItemSearch);
                    
                    break;
                case 5:
                    //Get Item details based on man. part number
                    var liItembympn = from clsItemDetails objItemRecord in lstAllItemList
                                         where (objItemRecord.mpn !=null && objItemRecord.mpn.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                         select objItemRecord;

                    alLineItemSearch = new ArrayList(liItembympn.ToList());
                    ItemsBySearchFilter(alLineItemSearch);
                    
                    break;
                case 6:
                    //Get Item details based on UOM
                    var liItembyuom = from clsItemDetails objItemRecord in lstAllItemList
                                      where (objItemRecord.unitofmeasuresetref !=null &&  objItemRecord.unitofmeasuresetref.ToLower().Contains(txtItemSearch.Text.ToString().ToLower().Trim()))
                                      select objItemRecord;

                    alLineItemSearch = new ArrayList(liItembyuom.ToList());
                    ItemsBySearchFilter(alLineItemSearch);
                   
                    break;
                case 7:
                    //Get Item details based on Custom fields
                     int FirstChr;
                     ArrayList arrCustomField = new ArrayList();
                     foreach (clsItemDetails itemcustomfield in lstAllItemList)
                    {
                       
                        if (itemcustomfield.CustomItem.Count > 0)
                        {
                            foreach (KeyValuePair<string, string> dictcustomitem in itemcustomfield.CustomItem)
                            {
                                FirstChr = dictcustomitem.Value.ToUpper().IndexOf(txtItemSearch.Text.ToString().ToUpper()); 
                                if(FirstChr != -1)
                                {
                                     arrCustomField.Add(itemcustomfield);
                                     break;
                                
                                }
                               
                            }
                        
                        }

                    }

                        ItemsBySearchFilter(arrCustomField);
                        //need to call LoadItemPage1
                    
                    break;
                    
                default:
                    break;
                    
            }
            string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
            if (template == "")
            {
                lblTempName.Text = "";
            }
            else
            {
                lblTempName.Text = Path.GetFileName(template);
            }

        }

        private void btnSearchReset_Click(object sender, EventArgs e)
        {

            gbOrderDetail.Visible = false;
            panel1.Visible = false;
            pnlpaging.Visible = false;
            pnluppaging.Visible = false;
            btnBin.Visible = false;
           // btnclosed.Visible = false;
            txtItemSearch.Text = "";
            cmbserach.SelectedIndex = 0;
            chkItemselect.Visible = false;
            if (DataGVSearchItem.Rows.Count > 0)
            {
                if (btnShowAll.Text.ToString().ToLower() == "hide all")
                {
                    btnShowAll.Text = "Show all";
                }
                
            }
            txtItemSearch.Focus();
           
        }

        private void DataGVSearchItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (DataGVSearchItem.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
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

        private void txtItemSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13))) { btnSearchItemDetails_Click(sender, e); }
        }

       
        private void goFirst()
        {
            this.mintCurrentPage = 0;

            LoadItemPage();
        }

        private void goPrevious()
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            LoadItemPage();
        }

        private void goNext()
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            LoadItemPage();
        }

        private void goLast()
        {
            this.mintCurrentPage = this.mintPageCount - 1;

            LoadItemPage();
        }

       
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            
            txtItemSearch.Text = "";
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (btnShowAll.Text.ToString().ToLower() == "show all")
            {

             

                //Refresh Item list every time
                using (new HourGlass())
                {
                    lstAllItemList.Clear();
                    string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");

                    if (!File.Exists(strStartupPath + "QuickBookItems.xml"))
                    {
                        MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ReadSyncItems(strStartupPath);
                    if (!isgridhidden)
                    {
                        fillGrid();
                     
                    }
                    else
                    {
                        MessageBox.Show("Unsupported characters in item custom field", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    btnShowAll.Text = "Hide all";

                    string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
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

                btnShowAll.Text = "Show all";
                chkItemselect.Visible = false;
                gbOrderDetail.Visible = false;
                panel1.Visible = false;
                btnBin.Visible = false;
                pnlpaging.Visible = false;
                pnluppaging.Visible = false;
                
            }

        }

        private void checkspecialcharinxml(string strStartupPath)
        {

            long length = 0;

            XmlTextReader treader = new XmlTextReader(strStartupPath + "QuickBookItems.xml");

            length = new System.IO.FileInfo(strStartupPath + "QuickBookItems.xml").Length;
            if (length == 0)
            {
                MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                while (treader.Read())
                {

                    if (treader.IsStartElement())
                    {

                          if (treader.MoveToContent() == XmlNodeType.Element && (treader.Name != "QuickBooks" && treader.Name != "Item" && treader.Name != "CustomItem" && treader.Name != "id"))
                            {
                            //string filtered = (tr.Name.StartsWith("_")) ? tr.Name.Substring(1) : tr.Name;

                            // objItem.CustomItem.Add((tr.Name.StartsWith("_")) ? tr.Name.Substring(1) : tr.Name, tr.ReadElementString());

                            if (System.Text.RegularExpressions.Regex.IsMatch(treader.Name.ToString(), "^[a-zA-Z0_^0-9]+$"))
                            {
                                // Good-to-go
                            }
                        }


                    }
                }

            } //end while
            catch (XmlException ex)
            {

              
            }
            treader.Close();
            //if (objItem != null)
            //{
            //    if (!string.IsNullOrEmpty(objItem.itemname))
            //    {
            //        lstAllItemList.Add(objItem);
            //        isgridhidden = false;
            //    }
            //}

        }

        private void ReadSyncItems(string strStartupPath)
        {          
            long length=0;
            
              XmlTextReader tr = new XmlTextReader(strStartupPath + "QuickBookItems.xml");

                     length = new System.IO.FileInfo(strStartupPath + "QuickBookItems.xml").Length;
                     if (length == 0)
                     {
                         MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                     }
                     //tr.WhitespaceHandling = WhitespaceHandling.None;
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
                        else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonhand")
                        {

                            objItem.quantityonhand = tr.ReadElementString();
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

                        }


                    }
                }
               
            } //end while
            catch (XmlException ex)
            {
                
                isgridhidden = true;
                objItem = null;
                               
            }
            tr.Close();
            if (objItem != null)
            {
                if (!string.IsNullOrEmpty(objItem.itemname))
                {
                    lstAllItemList.Add(objItem);
                    isgridhidden = false;
                }
            }
                                             
            
        }

        //Read Items detais for NWN  :28-Feb-2018
        private void ReadSyncItemsForNWN(string strStartupPath)
        {
            long length = 0;
            lstAllItemNWNList.Clear();
            XmlTextReader tr = new XmlTextReader(strStartupPath + "QuickBookItemsNwn.xml");

            length = new System.IO.FileInfo(strStartupPath +"QuickBookItemsNwn.xml").Length;
            if (length == 0)
            {
                MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int lntcount = 0;
            int lntCounterId = 1;
            clsItemDetails objItem = null;
           // string[] Categoriescompare = Enum.GetNames(typeof(clsItemDetails.PlantCategories));
            while (tr.Read())
            {


                if (tr.IsStartElement())
                {

                    if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "itemname")
                    {
                        if (lntcount > 0)
                        {
                            objItem.id = lntCounterId++;
                            lstAllItemNWNList.Add(objItem);

                        }
                        objItem = new clsItemDetails();
                        objItem.CustomItem.Clear();
                        objItem.itemname = tr.ReadElementString();
                        //check item that are not in category group
                        //foreach (var categoryname in Categoriescompare)
                        //{
                        //    if (objItem.itemname.ToUpper().Trim().StartsWith(categoryname.ToUpper().Trim()))
                        //    {
                        //        objItem.blnCategoryItem = true;
                        //    }
                        //}


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

                    else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonhand")
                    {

                        objItem.quantityonhand = tr.ReadElementString();
                    }
                    else if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "quantityonsalesorder") //05-oct-2018
                    {

                        objItem.quantityonsalesorder = tr.ReadElementString();
                    }

                    else
                    {
                        //for custom field
                        if (tr.MoveToContent() == XmlNodeType.Element && (tr.Name != "QuickBooks" && tr.Name != "Item" && tr.Name != "CustomItem" && tr.Name != "id"))
                        {


                            objItem.CustomItem.Add((tr.Name.StartsWith("_")) ? tr.Name.Substring(1) : tr.Name, tr.ReadElementString());
                        }
                    }


                }

            } //end while
            tr.Close();
            if (!string.IsNullOrEmpty(objItem.itemname))
                lstAllItemNWNList.Add(objItem);


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
            //Refresh grid to get updates from quickbooks : Date 10-oct-2017

            using (new HourGlass())
            {

                if (string.IsNullOrWhiteSpace(txtItemSearch.Text.ToString()))
                {
                    if (DataGVSearchItem.Rows.Count > 0 && DataGVSearchItem.Visible == true)
                    {
                        lstAllItemList.Clear();
                        string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");

                        if (!File.Exists(strStartupPath + "QuickBookItems.xml"))
                        {
                            MessageBox.Show("Please Sync QuickBook Items", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ReadSyncItems(strStartupPath);
                        if (isgridhidden == true) //16-Jan-2019
                        {
                            panel1.Visible = false;
                            pnlpaging.Visible = false;
                            pnluppaging.Visible = false;
                            gbOrderDetail.Visible = false;
                            btnBin.Visible = false;
                            lstAllItemList.Clear();
                        }
                        else
                        {
                            panel1.Visible = true;
                            pnlpaging.Visible = true;
                            pnluppaging.Visible = true;
                            gbOrderDetail.Visible = true;
                            btnBin.Visible = true;

                            fillGrid();
                        }
                    }
                }

            }
        }

        private void LoadItemPage()
        {
           lstrItemCustomFieldName = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField"));
            int intSkip = 0;
            //List<clsItemDetails> TopItemList = new List<clsItemDetails>();

           // List<clsItemDetails> TopItemFilterList = new List<clsItemDetails>();
            List<clsItemDetails> listItemobj = new List<clsItemDetails>();

            intSkip = (this.mintCurrentPage * this.mintPageSize);


            listItemobj = (from clsItemDetails Itemcount in lstAllItemList
                                 select Itemcount).Skip(intSkip).Take(this.mintPageSize).ToList();
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            if (DataGVSearchItem.Rows.Count == 0)
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
                    cmbLabelPrinter.Enabled = true;
                }
                string template = GetselectedtemplateOnApp(string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")));
                        if (template == "")
                        {
                        lblTempName.Text = "";
                        }
                        else
                        {
                        lblTempName.Text = Path.GetFileName(template);
                        }
                if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                {
                    fnGenerateLabelCB();
                }
                else
                {
                    fnGetUDFLabels();
                }
            }
            //DataGVSearchItem.ReadOnly = false; //
            
            DataGVSearchItem.Columns.Clear();
            pnlpaging.Visible = true;
            pnluppaging.Visible = true;
            //Define DataGrid Columns
            DataGridViewCheckBoxColumn Column = new DataGridViewCheckBoxColumn();
            Column.Name = "CheckBox";
            Column.HeaderText = "";
            DataGVSearchItem.Columns.Add(Column);


            DataGVSearchItem.Columns["CheckBox"].Width = 45;
            DataGVSearchItem.Columns["CheckBox"].ReadOnly = false;

            DataGridViewCustomButtonColumn Itemcoledit = new DataGridViewCustomButtonColumn();
            Itemcoledit.Width = 45;
            Itemcoledit.Name = "Edit";
            Itemcoledit.HeaderText = "Edit";
            Itemcoledit.Text = "Edit";

            Itemcoledit.UseColumnTextForButtonValue = true;
            DataGVSearchItem.Columns.Add(Itemcoledit);

            DataGVSearchItem.Columns.Add("itemname", "Name");
            DataGVSearchItem.Columns["itemname"].Width = 160;

            DataGVSearchItem.Columns.Add("SalesDesc", "Description");
            DataGVSearchItem.Columns["SalesDesc"].Width = 210;

            DataGridViewComboBoxColumn Itemcolsbin = new DataGridViewComboBoxColumn();
            Itemcolsbin.Width = 100;
            Itemcolsbin.HeaderText = "Bin";
            Itemcolsbin.Name = "Bin";
            DataGVSearchItem.Columns.Add(Itemcolsbin);

            DataGVSearchItem.Columns.Add("QuantityonHand", "Print Qty (On Hand)");
            DataGVSearchItem.Columns["QuantityonHand"].Width = 65;

            // DataGVSearchItem.Columns.Add("LotNo", "Lot No.");
            DataGVSearchItem.Columns.Add("LotNo",lobjQBConfiguration.GetLabelConfigSettings("LotColumnName")); //configure column name text : 28-Aug-2018
            DataGVSearchItem.Columns["LotNo"].Width = 70;

            DataGVSearchItem.Columns.Add("QtyOnLabel", "Qty on Label");
            DataGVSearchItem.Columns["QtyOnLabel"].Width = 70;

            if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName)) //03rd july-2019
            {
                DataGVSearchItem.Columns.Add("CustQuantityField", lstrItemCustomFieldName);
                DataGVSearchItem.Columns["CustQuantityField"].Width = 65;
            }

            DataGVSearchItem.Columns.Add("UnitOfMeasureSetRef", "U/M");
            DataGVSearchItem.Columns["UnitOfMeasureSetRef"].Width = 100;
            DataGVSearchItem.Columns.Add("BarCodeValue", "BarCode");
            DataGVSearchItem.Columns["BarCodeValue"].Width = 100;

            DataGVSearchItem.Columns.Add("ManufacturerPartNumber", "MPN");
            DataGVSearchItem.Columns["ManufacturerPartNumber"].Width = 90;

            DataGVSearchItem.Columns.Add("SalesPrice", "Price");
            DataGVSearchItem.Columns["SalesPrice"].Width = 60;

            DataGVSearchItem.Columns.Add("Type", "Type");
            DataGVSearchItem.Columns["Type"].Width = 100;

            DataGVSearchItem.Columns.Add("QuantityOnSalesOrder", "On Sales Order");
            DataGVSearchItem.Columns["QuantityOnSalesOrder"].Width = 40;

            DataGVSearchItem.Columns.Add("QuantityOnOrder", "Qty On Purchase Order");
            DataGVSearchItem.Columns["QuantityOnOrder"].Width = 55;

           
            //Display Items on the Grid

            DataGVSearchItem.Rows.Clear();
            DataGVSearchItem.ReadOnly = false;
          
            int lntsearchitemcount = 0;
            foreach (clsItemDetails searchItems in listItemobj)
            {
               
                DataGVSearchItem.Rows.Add();

                DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].Value = searchItems.itemname;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].Value = searchItems.description;
                if (showItemflipvalue == "Y")
                {
                    DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = "1";
                }
                else
                {
                    DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                }
                //DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].Value = searchItems.quantityonhand;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["LotNo"].Value = searchItems.LotNo; //LotNo
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QtyOnLabel"].Value = "1"; //Qty On Hand
                if (!string.IsNullOrWhiteSpace(lstrItemCustomFieldName))
                {
                    if (searchItems.CustomItem.Count > 0) //Esti
                    {
                        foreach (var item in searchItems.CustomItem)
                        {
                            //string test1 = item.Key;
                            // string test2 = item.Value;
                          
                           DataGVSearchItem.Rows[lntsearchitemcount].Cells["CustQuantityField"].Value = item.Key == lstrItemCustomFieldName.ToUpper() ? item.Value.ToString() : string.Empty;
                        }
                    }
                }
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].Value = searchItems.unitofmeasuresetref;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].Value = searchItems.barcodevalue;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].Value = searchItems.mpn;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].Value = searchItems.salesprice;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].Value = searchItems.itemtype;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].Value = searchItems.quantityonsalesorder;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].Value = searchItems.quantityonorder;

                //make column readonly
                DataGVSearchItem.Rows[lntsearchitemcount].Cells[0].ReadOnly = false;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["itemname"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesDesc"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityonHand"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["Bin"].ReadOnly = false;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells[7].ReadOnly = true; //LotNo
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QtyOnLabel"].ReadOnly = true; //QtyOnLabel
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["UnitOfMeasureSetRef"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["BarCodeValue"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["ManufacturerPartNumber"].ReadOnly= true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["SalesPrice"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["Type"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnSalesOrder"].ReadOnly = true;
                DataGVSearchItem.Rows[lntsearchitemcount].Cells["QuantityOnOrder"].ReadOnly = true;

               
                lntsearchitemcount++;

            }
            chkItemselect.Checked = false; //added
            //LotNo
            for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
            {

                DataGVSearchItem.Rows[i].Cells[0].Value = "False";

            }

            //below code commented to show check all default unchecked : 15-sept-2017
            //int pagecheckcount=this.mintCurrentPage + 1;
            //if (pagecheckcount == 1)
            //{

            //    chkItemselect.Checked = true;
            //    //show all checkboxes true by default
            //    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
            //    {

            //        DataGVSearchItem.Rows[i].Cells[0].Value = "True";

            //    }
            //    btnPrint.Enabled = true;
            //}
            //else //added on  15-sept
            //{
            //    if (chkItemselect.Checked == false)
            //    {
            //        chkItemselect.Checked = false;
            //        chkItemselect_Click(null, null);
            //    }
            //    else
            //    {
            //        chkItemselect.Checked = true;
            //        //show all checkboxes true by default
            //        for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
            //        {

            //            DataGVSearchItem.Rows[i].Cells[0].Value = "True";

            //        }

            //    }
            //}



            //fnGenerateLabelCB();

            panel1.Visible = true;
            //btnclosed.Visible = true;
            gbOrderDetail.Visible = true;
            btnBin.Visible = true;
            chkItemselect.Visible = true;
            
            
            // Show Status
            this.lblStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();

            this.lblupstatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            
            
        }
        private void fillGrid()
        {
            lobjQBConfiguration = new QBConfiguration();
            // For Page view.
            //this.mintPageSize = int.Parse(this.tbPageSize.Text);
            this.mintPageSize = int.Parse(lobjQBConfiguration.GetLabelConfigSettings("PageSize"));
            this.mintTotalRecords = lstAllItemList.Count;
            this.mintPageCount = this.mintTotalRecords / this.mintPageSize;

            // Adjust page count if the last page contains partial page.
            if (this.mintTotalRecords % this.mintPageSize > 0)
                this.mintPageCount++;

            this.mintCurrentPage = 0;

            LoadItemPage();
        }

       
        private void btnFirst_Click(object sender, EventArgs e)
        {
          
            this.goFirst();
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
            this.goNext();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
           
            this.goPrevious(); 

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
          
            this.goLast();

        }

        private void btnupfirst_Click(object sender, EventArgs e)
        {
            
            this.goFirst();
        }

        private void btnupprev_Click(object sender, EventArgs e)
        {
           
            this.goPrevious(); 
        }

        private void btnupnext_Click(object sender, EventArgs e)
        {
           
            this.goNext();
        }

        private void btnuplast_Click(object sender, EventArgs e)
        {
            
            this.goLast();

        }
        private bool WriteItemsForNWN(string pstrAppPath)
        {
            bool blnsuccess=false;

            //Get updated items from QB and write to XML
            string lstrProductDownCount = string.Empty;
            clsItemDetails lobjconnection = new clsItemDetails();
            using (new HourGlass())
            {

                if (lobjconnection.CheckQuickBooksConnection() == true)
                {
                    lstrProductDownCount = lobjItemsData.WriteQuickBookNwnItemToXml(pstrAppPath + "QuickBookItemsNwn.xml");
                    blnsuccess = true;
                }

                else
                {

                    MessageBox.Show("Please Open QuickBooks Company file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnsuccess = false;
                   
                }

            }
            return blnsuccess;

        }
        //so that we dont leave any memory leaks  
        //private static void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}

        //code to write Excel using Microsoft Office dll
        //private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        //private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        //private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        //private static Microsoft.Office.Interop.Excel.Application oXL;



        //  [DllImport("user32.dll")]
        // static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        //Process GetExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
        //{
        //    int id;
        //    GetWindowThreadProcessId(excelApp.Hwnd, out id);
        //    return Process.GetProcessById(id);
        //}

        //void TerminateExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
        //{
        //    var process = GetExcelProcess(excelApp);
        //    if (process != null)
        //    {
        //        process.Kill();
        //    }
        //}

        //private void CreateNWNExcel(string strStartupPath, string[] Categories, List<clsItemDetails> withoutcategoyRecord , ArrayList lstAllItemNWNList)
        //{
        //    int colposition=0;
        //    string lstrSize = string.Empty;
        //    oXL = new Microsoft.Office.Interop.Excel.Application();
        //    if (oXL == null)
        //    {
        //        MessageBox.Show("Excel is not properly installed!!");
        //        return;
        //    }

        //    oXL.DisplayAlerts = false;
        //    mWorkBook = oXL.Workbooks.Open(strStartupPath + @"\NWN_Files\NWN-AvailabilityList.xls", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //    //Get all the sheets in the workbook
        //    mWorkSheets = mWorkBook.Worksheets;
        //    //Get the allready exists sheet
        //    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
        //    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;

        //    //Write entries to the excel file
        //    //Get Plant Categories
        //   // string[] Categories = Enum.GetNames(typeof(clsItemDetails.PlantCategories));
        //    colposition = 15;

        //    //without category items
        //    //var withoutcategoyRecord = (lstAllItemNWNList.Cast<clsItemDetails>().Where(z =>
        //    //       !Categories.Any(x => z.itemname.ToLower().Trim().StartsWith(x.ToLower().Trim()))).OrderBy(z => z.description).ToList());


        //    string desc = string.Empty;

        //    string qtyonhand = string.Empty;
        //    string dsalesprice = string.Empty;

        //    if (withoutcategoyRecord.Count > 0)
        //    {

        //        var data = new object[withoutcategoyRecord.Count, 4];
        //        for (var row = 1; row <= withoutcategoyRecord.Count; row++)
        //        {
        //            if (row < withoutcategoyRecord.Count)
        //            {
        //                desc = withoutcategoyRecord[row].description;
        //                withoutcategoyRecord[row].CustomItem.TryGetValue("SIZE", out lstrSize);
        //                qtyonhand = withoutcategoyRecord[row].quantityonhand;
        //                dsalesprice = withoutcategoyRecord[row].salesprice;

        //                for (var column = 1; column <= 4; column++)
        //                {
        //                    if (column == 1)
        //                        data[row - 1, column - 1] = desc;
        //                    if (column == 2)
        //                        data[row - 1, column - 1] = Convert.ToString(lstrSize);
        //                    if (column == 3)
        //                        data[row - 1, column - 1] = Convert.ToInt32(qtyonhand);
        //                    if (column == 4)
        //                        data[row - 1, column - 1] = Convert.ToDecimal(dsalesprice).ToString("C");
        //                }
        //                colposition++;
        //            }
        //        }
        //        Excel.Range value_range = mWSheet1.get_Range("A" + 15, "D" + colposition);
        //        value_range.Value2 = data;

        //    }

        //    foreach (string categoryname in Categories)
        //    {

        //        //filter item list with given categories
        //        var liItemRecord = (from clsItemDetails objItemRecord in lstAllItemNWNList
        //                            where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
        //                            select objItemRecord).OrderBy(p => p.description).ToList();

        //        if (liItemRecord.Count > 0)
        //        {
        //            string strheading = string.Empty;
        //            switch (categoryname.ToUpper())
        //            {
        //                case "BAMB":
        //                    strheading = "Bamboo";
        //                    break;
        //                case "FERN":
        //                    strheading = "Fern";
        //                    break;
        //                case "FRUIT":
        //                    strheading = "Fruit";
        //                    break;
        //                case "GRASS":
        //                    strheading = "Grasses";
        //                    break;
        //                case "HEATH":
        //                    strheading = "Heath and Heathers";
        //                    break;
        //                default:
        //                    break;
        //            }


        //            object[,] headername = { { strheading } };
        //            Excel.Range value_rangerecordheader = mWSheet1.get_Range("A" + colposition, "A" + colposition);
        //            value_rangerecordheader.Value2 = headername;
        //            mWSheet1.Range["A" + colposition].Font.Bold = true;


        //            for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
        //            {
        //                colposition++;

        //                liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);
        //                object[,] values =
        //                                {
        //                                        {  "".PadLeft(7) + liItemRecord[rec].description,Convert.ToString(lstrSize), Convert.ToInt32(liItemRecord[rec].quantityonhand), Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C")}

        //                                    };
        //                Excel.Range value_rangerecord = mWSheet1.get_Range("A" + colposition, "D" + colposition);
        //                value_rangerecord.Value2 = values;
        //                mWSheet1.Range["A" + colposition].Font.Bold = false;

        //            }

        //            colposition++;
        //        }

        //    }


        //    mWorkBook.SaveAs(strStartupPath + @"\NWN_Files\NWN-AvailabilityList.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
        //    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
        //    Missing.Value, Missing.Value, Missing.Value,
        //    Missing.Value, Missing.Value);
        //    mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
        //    mWSheet1 = null;
        //    mWorkBook = null;
        //    oXL.Quit();
        //    TerminateExcelProcess(oXL);
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();

        //}


        private void CreateNWNPOIExcelBrOrdertest(string strStartupPath, string[] Categories, ArrayList lstAllItemNWNList)
        {
            int colposition = 0;
            string desc = string.Empty;
            string qtyonhand = string.Empty;
            string qtyonsalesorder = string.Empty;
            string lstrSize = string.Empty;
            string dsalesprice = string.Empty;
            string strheading = string.Empty;
            string fileuploadDate = string.Empty;
            bool IsGroupItem = false;
            string pathSource = strStartupPath + @"\NWN_Files\NWN-AvailabilityList.xls";
            colposition = 14;
            bool blngroupItemfound = false;

            string lstrGroupItem = string.Empty;
            List<clsItemDetails> categoyRecords = (lstAllItemNWNList.Cast<clsItemDetails>().OrderBy(z => z.itemname).ToList());



            HSSFWorkbook hssfwb;
            IRow row;
            ISheet sheet;
            ICell cell;
            //Align Text
            ICellStyle styleLeft;
            ICellStyle styleRight;


            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
                file.Close();
            }

            sheet = hssfwb.GetSheetAt(0);

            //Alignment Style
            styleLeft = hssfwb.CreateCellStyle();
            styleRight = hssfwb.CreateCellStyle();
            styleLeft.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            styleRight.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;

            //write Date : 17-Apr-2018
            DateTime dt = DateTime.Now;
            fileuploadDate = dt.ToString("MMMMM dd, " + ' ' + "yyyy");

            IRow dataRow = sheet.GetRow(10) ?? sheet.CreateRow(10);
            ICell datecell = dataRow.GetCell(1) ?? dataRow.CreateCell(1);
            datecell.SetCellValue(fileuploadDate);
            var datefont = hssfwb.CreateFont();
            datefont.FontHeightInPoints = 10;
            datefont.FontName = "Arial";
            datefont.Boldweight = (short)FontBoldWeight.Bold;
            datecell.RichStringCellValue.ApplyFont(datefont);

            //row = sheet.GetRow(10);
            //cell = row.CreateCell(1);

            //cell.SetCellValue(fileuploadDate);
            //var datefont = hssfwb.CreateFont();
            //datefont.FontHeightInPoints = 10;
            //datefont.FontName = "Arial";
            //datefont.Boldweight = (short)FontBoldWeight.Bold;
            //cell.RichStringCellValue.ApplyFont(datefont);


            if (categoyRecords.Count > 0)
            {

                for (int cnt = 1; cnt <= categoyRecords.Count; cnt++)
                {
                    if (cnt < categoyRecords.Count)
                    {
                        
                        //if (lstrGroupItem != string.Empty)
                        //{
                        //    if (Convert.ToString(categoyRecords[cnt].itemname).ToLower().StartsWith(lstrGroupItem.ToLower()))
                        //    {
                        //        lstrGroupItem = string.Empty;
                        //        blngroupItemfound = true;
                        //        continue;
                        //    }
                        //}
                        IsGroupItem = false;
                      
                        sheet.CreateRow(colposition);



                        //check item is start with group category,write description for all group item
                        if (categoyRecords[cnt].LotNo == "")
                        {
                            foreach (string categoryname in Categories)
                            {


                                if (Convert.ToString(categoyRecords[cnt].itemname).ToLower().StartsWith(categoryname.ToLower()))
                                {

                                    lstrGroupItem = categoryname;


                                    //filter item list with given categories
                                    var liItemRecord = (from clsItemDetails objItemRecord in categoyRecords
                                                        where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                                                        select objItemRecord).OrderBy(p => p.description).ToList();

                                    switch (categoryname.ToUpper())
                                    {
                                        case "BAMB":
                                            strheading = "Bamboo";
                                            break;
                                        case "FERN":
                                            strheading = "Fern";
                                            break;
                                        case "FRUIT":
                                            strheading = "Fruit";
                                            break;
                                        case "GRASS":
                                            strheading = "Grasses";
                                            break;
                                        case "HEATH":
                                            strheading = "Heath and Heathers";
                                            break;
                                        default:
                                            break;
                                    }

                                    row = sheet.GetRow(colposition);
                                    cell = row.CreateCell(0);


                                    cell.SetCellValue(Convert.ToString(strheading));

                                    //Make Plant Header Category Font Bold and display
                                    var font = hssfwb.CreateFont();
                                    font.FontHeightInPoints = 10;
                                    font.FontName = "Arial";
                                    font.Boldweight = (short)FontBoldWeight.Bold;
                                    cell.RichStringCellValue.ApplyFont(font);

                                    //Add plant category group items details
                                    for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                                    {
                                        colposition++;
                                        liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);
                                        liItemRecord[rec].LotNo = "withcat";
                                        cnt++;
                                        //categoyRecords[cnt]++;
                                        // row = sheet.GetRow(colposition);
                                        sheet.CreateRow(colposition);
                                        for (var column = 0; column < 4; column++)
                                        {
                                            //cell = row.CreateCell(column);
                                            row = sheet.GetRow(colposition);
                                            cell = row.CreateCell(column);
                                            if (column == 0)
                                            {
                                                cell.SetCellValue("".PadLeft(7) + liItemRecord[rec].description);

                                            }
                                            if (column == 1)
                                            {
                                                cell.SetCellValue(Convert.ToString(lstrSize));
                                                cell.CellStyle = styleLeft;
                                            }
                                            if (column == 2)
                                            {
                                                cell.SetCellValue(Convert.ToDouble(liItemRecord[rec].quantityonhand) - Convert.ToDouble(liItemRecord[rec].quantityonsalesorder) > 0 ? Convert.ToDouble(liItemRecord[rec].quantityonhand) - Convert.ToDouble(liItemRecord[rec].quantityonsalesorder) : 0);
                                                //cell.SetCellValue(Convert.ToDouble(liItemRecord[rec].quantityonhand)); //05-Oct-2018
                                                cell.CellStyle = styleRight;
                                            }
                                            if (column == 3)
                                            {
                                                cell.SetCellValue(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"));
                                                cell.CellStyle = styleRight;
                                            }
                                        }

                                    }

                                    colposition++;
                                    IsGroupItem = true;

                                    break;

                                }
                            }
                        }

                        //if non group item exist
                        if (IsGroupItem == false)
                        {
                            //if(categoyRecords[cnt].description == "Shibatea kumasaca")
                            //{
                            //   // MessageBox.Show("300");
                            //}
                            desc = categoyRecords[cnt].description;
                            categoyRecords[cnt].CustomItem.TryGetValue("SIZE", out lstrSize);
                            qtyonhand = categoyRecords[cnt].quantityonhand;
                            qtyonsalesorder= categoyRecords[cnt].quantityonsalesorder;
                            dsalesprice = categoyRecords[cnt].salesprice;

                            for (var column = 0; column < 4; column++)
                            {
                                row = sheet.GetRow(colposition);
                                cell = row.CreateCell(column);
                                if (column == 0)
                                {
                                    cell.SetCellValue(desc);
                                   // cell.CellStyle = styleLeft;
                                }
                                if (column == 1)
                                {
                                    cell.SetCellValue(Convert.ToString(lstrSize));
                                    cell.CellStyle = styleLeft;
                                }
                                if (column == 2)
                                {
                                    var QtyCalc = (Convert.ToDouble(qtyonhand) - Convert.ToDouble(qtyonsalesorder) > 0 ? Convert.ToDouble(qtyonhand) - Convert.ToDouble(qtyonsalesorder) : 0);
                                    cell.SetCellValue(Convert.ToDouble(QtyCalc));
                                    // cell.SetCellValue(Convert.ToDouble(qtyonhand)); //05-Oct-2018
                                    cell.CellStyle = styleRight;
                                }
                                if (column == 3)
                                {
                                    cell.SetCellValue(Convert.ToDecimal(dsalesprice).ToString("C"));
                                    cell.CellStyle = styleRight;
                                }
                            }
                            colposition++;

                        }



                    }
                }
            }

            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Write))
            {
                hssfwb.Write(file);
                file.Close();
            }

        }

        private void CreateNWNPOIExcelBrOrder(string strStartupPath, string[] Categories, ArrayList lstAllItemNWNList)
        {
            int colposition = 0;
            string desc = string.Empty;
            string qtyonhand = string.Empty;
            string lstrSize = string.Empty;
            string dsalesprice = string.Empty;
            string strheading = string.Empty;
            bool IsGroupItem = false; 
            string pathSource = strStartupPath + @"\NWN_Files\NWN-AvailabilityList.xls";
            colposition = 14;
            bool blngroupItemfound = false;
           
            string lstrGroupItem = string.Empty;
            List<clsItemDetails> categoyRecords = (lstAllItemNWNList.Cast<clsItemDetails>().OrderBy(z => z.itemname).ToList());



            HSSFWorkbook hssfwb;
            IRow row;
            ISheet sheet;
            ICell cell;
            //Align Text
            ICellStyle styleLeft;
            ICellStyle styleRight;


            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
                file.Close();
            }

            sheet = hssfwb.GetSheetAt(0);

            //Alignment Style
            styleLeft = hssfwb.CreateCellStyle();
            styleRight = hssfwb.CreateCellStyle();
            styleLeft.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            styleRight.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;

            if (categoyRecords.Count > 0)
            {

                for (int cnt = 1; cnt <= categoyRecords.Count; cnt++)
                {
                    if (cnt < categoyRecords.Count)
                    {
                        if (lstrGroupItem != string.Empty)
                        {
                            if (Convert.ToString(categoyRecords[cnt].itemname).ToLower().StartsWith(lstrGroupItem.ToLower()))
                            {
                                lstrGroupItem = string.Empty;
                                blngroupItemfound = true;
                                continue;
                            }
                        }

                        IsGroupItem = false;
                        row = sheet.GetRow(colposition);
                        sheet.CreateRow(colposition);

                       
                        //check item is start with group category,write description for all group item

                        foreach (string categoryname in Categories)
                        {

                            if (Convert.ToString(categoyRecords[cnt].itemname).ToLower().StartsWith(categoryname.ToLower()) && blngroupItemfound==false)
                            {
                                
                                lstrGroupItem = categoryname;


                                //filter item list with given categories
                                var liItemRecord = (from clsItemDetails objItemRecord in categoyRecords
                                                    where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                                                    select objItemRecord).OrderBy(p => p.description).ToList();

                                switch (categoryname.ToUpper())
                                {
                                    case "BAMB":
                                        strheading = "Bamboo";
                                        break;
                                    case "FERN":
                                        strheading = "Fern";
                                        break;
                                    case "FRUIT":
                                        strheading = "Fruit";
                                        break;
                                    case "GRASS":
                                        strheading = "Grasses";
                                        break;
                                    case "HEATH":
                                        strheading = "Heath and Heathers";
                                        break;
                                    default:
                                        break;
                                }


                                cell = row.CreateCell(0);


                                cell.SetCellValue(Convert.ToString(strheading));

                                //Make Plant Header Category Font Bold and display
                                var font = hssfwb.CreateFont();
                                font.FontHeightInPoints = 10;
                                font.FontName = "Arial";
                                font.Boldweight = (short)FontBoldWeight.Bold;
                                cell.RichStringCellValue.ApplyFont(font);

                                //Add plant category group items details
                                for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                                {
                                    colposition++;
                                    liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);

                                    row = sheet.GetRow(colposition);
                                    sheet.CreateRow(colposition);
                                    for (var column = 0; column < 4; column++)
                                    {
                                        cell = row.CreateCell(column);
                                        if (column == 0)
                                        {
                                            cell.SetCellValue("".PadLeft(7) + liItemRecord[rec].description);
                                           
                                        }
                                        if (column == 1)
                                        {
                                            cell.SetCellValue(Convert.ToString(lstrSize));
                                            cell.CellStyle = styleLeft;
                                        }
                                        if (column == 2)
                                        {
                                           
                                            cell.SetCellValue(Convert.ToDouble(liItemRecord[rec].quantityonhand));
                                            cell.CellStyle = styleRight;
                                        }
                                        if (column == 3)
                                        {
                                            cell.SetCellValue(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"));
                                            cell.CellStyle = styleRight;
                                        }
                                    }

                                }
                                //categoyRecords.RemoveAll(c=>c.itemname.StartsWith(categoryname));
                               
                                 colposition++;
                                IsGroupItem = true;

                                break;

                            }
                        }

                        //if non group item exist
                        if (IsGroupItem == false)
                        {

                            desc = categoyRecords[cnt].description;
                            categoyRecords[cnt].CustomItem.TryGetValue("SIZE", out lstrSize);
                            qtyonhand = categoyRecords[cnt].quantityonhand;
                            dsalesprice = categoyRecords[cnt].salesprice;

                            for (var column = 0; column < 4; column++)
                            {
                                cell = row.CreateCell(column);
                                if (column == 0)
                                {
                                    cell.SetCellValue(desc);
                                    cell.CellStyle = styleLeft;
                                }
                                if (column == 1)
                                {
                                    cell.SetCellValue(Convert.ToString(lstrSize));
                                    cell.CellStyle = styleLeft;
                                }
                                if (column == 2)
                                {

                                    cell.SetCellValue(Convert.ToDouble(qtyonhand)); //23-Mar-2018
                                    cell.CellStyle = styleRight;
                                }
                                if (column == 3)
                                {
                                    cell.SetCellValue(Convert.ToDecimal(dsalesprice).ToString("C"));
                                    cell.CellStyle = styleRight;
                                }
                            }
                            colposition++;

                        }



                    }
                }
            }

            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Write))
            {
                hssfwb.Write(file);
                file.Close();
            }

        }
        private void CreateNWNPOIExcel(string strStartupPath, string[] Categories, List<clsItemDetails> withoutcategoyRecord, ArrayList lstAllItemNWNList)
        {
            // Open Template
            int colposition = 0;
            string desc = string.Empty;
            string qtyonhand = string.Empty;
            string lstrSize = string.Empty;
            string dsalesprice = string.Empty;
            string pathSource = strStartupPath + @"\NWN_Files\NWN-AvailabilityList.xls";
            //Write entries to the excel file
            //Get Plant Categories
           // string[] PlantCategories = Enum.GetNames(typeof(clsItemDetails.PlantCategories));
            colposition = 14;

            //Get without category items
            //var withoutcategoyRecords = (lstAllItemNWNList.Cast<clsItemDetails>().Where(z =>
            //       !Categories.Any(x => z.itemname.ToLower().Trim().StartsWith(x.ToLower().Trim()))).OrderBy(z => z.description).ToList());
            

            HSSFWorkbook hssfwb;
            IRow row;
            ISheet sheet;
            ICell cell;
            //Align Text
            ICellStyle styleLeft;
            ICellStyle styleRight;
          

            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
                file.Close();
            }

            sheet = hssfwb.GetSheetAt(0);

            //Alignment Style
            styleLeft = hssfwb.CreateCellStyle();
            styleRight = hssfwb.CreateCellStyle();
            styleLeft.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            styleRight.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;

            if (withoutcategoyRecord.Count > 0)
            {

                for (int cnt = 1; cnt <= withoutcategoyRecord.Count; cnt++)
                {
                   
                   if(cnt < withoutcategoyRecord.Count)
                    { 
                   
                    sheet.CreateRow(colposition);
                    //row = sheet.GetRow(colposition);

                    desc = withoutcategoyRecord[cnt].description;
                    withoutcategoyRecord[cnt].CustomItem.TryGetValue("SIZE", out lstrSize);
                    qtyonhand = withoutcategoyRecord[cnt].quantityonhand;
                    dsalesprice = withoutcategoyRecord[cnt].salesprice;

                    for (var column = 0; column < 4; column++)
                    {
                            row = sheet.GetRow(colposition);
                            cell = row.CreateCell(column);
                            if (column == 0)
                            {
                                cell.SetCellValue(desc);
                                cell.CellStyle = styleLeft;
                            }
                            if (column == 1)
                            {
                                cell.SetCellValue(Convert.ToString(lstrSize));
                                cell.CellStyle = styleLeft;
                            }
                            if (column == 2)
                            {
                                // cell.SetCellValue(Convert.ToInt32(qtyonhand));
                                cell.SetCellValue(Convert.ToDouble(qtyonhand)); //23-Mar-2018
                                cell.CellStyle = styleRight;
                            }
                            if (column == 3)
                            {
                                cell.SetCellValue(Convert.ToDecimal(dsalesprice).ToString("C"));
                                cell.CellStyle = styleRight;
                            }
                    }
                    colposition++;
                        
                    }
                }
            }

            //Filter Items with Categories

            foreach (string categoryname in Categories)
            {

                //filter item list with given categories
                var liItemRecord = (from clsItemDetails objItemRecord in lstAllItemNWNList
                                    where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                                    select objItemRecord).OrderBy(p => p.description).ToList();

                if (liItemRecord.Count > 0)
                {
                    string strheading = string.Empty;
                    switch (categoryname.ToUpper())
                    {
                        case "BAMB":
                            strheading = "Bamboo";
                            break;
                        case "FERN":
                            strheading = "Fern";
                            break;
                        case "FRUIT":
                            strheading = "Fruit";
                            break;
                        case "GRASS":
                            strheading = "Grasses";
                            break;
                        case "HEATH":
                            strheading = "Heath and Heathers";
                            break;
                        default:
                            break;
                    }
                    //Add plan categories header row
                    
                    sheet.CreateRow(colposition);
                    row = sheet.GetRow(colposition);
                    cell = row.CreateCell(0);

                   
                    cell.SetCellValue(Convert.ToString(strheading));

                    //Make Plant Header Category Font Bold
                    var font = hssfwb.CreateFont();
                    font.FontHeightInPoints = 10;
                    font.FontName = "Arial";
                    font.Boldweight = (short)FontBoldWeight.Bold;
                    cell.RichStringCellValue.ApplyFont(font);


                    for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                    {
                        colposition++;
                        liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);

                       
                        sheet.CreateRow(colposition);
                        for (var column = 0; column < 4; column++)
                        {
                            row = sheet.GetRow(colposition);
                            cell = row.CreateCell(column);
                            if (column == 0)
                            {
                                cell.SetCellValue("".PadLeft(7) + liItemRecord[rec].description);
                                //cell.CellStyle = styleLeft;
                            }
                            if (column == 1)
                            {
                                cell.SetCellValue(Convert.ToString(lstrSize));
                                cell.CellStyle = styleLeft;
                            }
                            if (column == 2)
                            {
                                // cell.SetCellValue(Convert.ToInt32(liItemRecord[rec].quantityonhand)); 23-Mar-2018
                                cell.SetCellValue(Convert.ToDouble(liItemRecord[rec].quantityonhand));
                                cell.CellStyle = styleRight;
                            }
                            if (column == 3)
                            {
                                cell.SetCellValue(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"));
                                cell.CellStyle = styleRight;
                            }
                        }
                        
                    }

                    colposition++;
                }

            }


            using (FileStream file = new FileStream(pathSource, FileMode.Open, FileAccess.Write))
            {
                hssfwb.Write(file);
                file.Close();
            }


        }

        private void CreateNWNPdf(string strStartupPath, string[] Categories, List<clsItemDetails> withoutcategoyRecord, ArrayList lstAllItemNWNList)
        {


            string lstrSize = string.Empty;
            string desc = string.Empty;
            string qtyonhand = string.Empty;
            string salesprice = string.Empty;
            Document doc = new Document(PageSize.A4, 55f, 80f, 50f, 10f);
            var textheader = FontFactory.GetFont("Arial", 14, 3);
            var textline1 = FontFactory.GetFont("Arial", 10, 0);
            var headerfont = FontFactory.GetFont("Arial", 10, 1);

            string lstrimgpath = AppDomain.CurrentDomain.BaseDirectory + "nwn.png";

            try
            {
               
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strStartupPath + @"\NWN_Files\NWN-AvailabilityList.pdf", FileMode.Create));
                doc.Open();

                 
                //Add NWN Image 
                iTextSharp.text.Image objlogo = iTextSharp.text.Image.GetInstance(lstrimgpath);

                //Resize image depend upon your need
                 objlogo.ScaleToFit(400f, 170f);
                //Give space before image
                objlogo.SpacingBefore = 10f;
                //Give some space after the image
                objlogo.SpacingAfter = 10f;
                objlogo.Alignment = Element.ALIGN_LEFT;
                doc.Add(objlogo);
                doc.Add(Chunk.NEWLINE);

                //creating header text object
                PdfPTable tableheader = new PdfPTable(1);
                tableheader.SpacingBefore = 20f;
                tableheader.SpacingAfter = 20f;
                PdfPCell cell = new PdfPCell(new Phrase(" " .PadLeft(30) + "Inventory Availability", textheader));
                tableheader.HorizontalAlignment = 1;
                cell.BorderWidth = 0;
                tableheader.AddCell(cell);
                doc.Add(tableheader);

                //create line1 text
                PdfPTable tableheader1 = new PdfPTable(2);
                PdfPCell cell1 = new PdfPCell(new Phrase("Availability data is current as of:", textline1));
                tableheader1.HorizontalAlignment = 0;
               
                cell1.BorderWidth = 0;
                cell1.PaddingLeft = 0;
                tableheader1.AddCell(cell1);
                PdfPCell datecell = new PdfPCell(new Phrase("  ".PadRight(15) + DateTime.Now.ToString("MMMMM dd," + ' ' + "yyyy"), headerfont));
                datecell.BorderWidth = 0;
                tableheader1.AddCell(datecell);          
                doc.Add(tableheader1);

                //create line2 text
                PdfPTable tableheader2 = new PdfPTable(1);
                tableheader2.HorizontalAlignment = 0;
                              
                PdfPCell cell3 = new PdfPCell(new Phrase("Availability data is subject to change without notice.", textline1));
                cell3.BorderWidth = 0;
                cell3.PaddingLeft = 0;
                tableheader2.AddCell(cell3);
                doc.Add(tableheader2);


                //Create Item details
                PdfPTable Itemtable = new PdfPTable(4);
                //column header row
                Itemtable.HorizontalAlignment = 0;
                Itemtable.WidthPercentage = 100f;
               
                //set column widths
                int[] firstTablecellwidth = { 50, 20, 15, 15 };
                Itemtable.SetWidths(firstTablecellwidth);

                Itemtable.SpacingBefore = 10f;
                Itemtable.SpacingAfter = 10f;

                
                PdfPCell cellhedername = new PdfPCell(new Phrase("Name", headerfont));
                cellhedername.BorderWidth = 0;
                cellhedername.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedername);

               
                PdfPCell cellhedersize = new PdfPCell(new Phrase("Size", headerfont));
                cellhedersize.BorderWidth = 0;
                cellhedersize.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedersize);

               
                PdfPCell cellhederquantity = new PdfPCell(new Phrase("Quantity", headerfont));
                cellhederquantity.BorderWidth = 0;
                cellhederquantity.HorizontalAlignment = 2;
                Itemtable.AddCell(cellhederquantity);

                PdfPCell cellhedersaleprice = new PdfPCell(new Phrase("Price", headerfont));
                cellhedersaleprice.BorderWidth = 0;
                cellhedersaleprice.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedersaleprice);
                
                //Add rows
                for (var row = 1; row <= withoutcategoyRecord.Count; row++)
                {
                    if (row < withoutcategoyRecord.Count)
                    {
                        desc = withoutcategoyRecord[row].description;
                        PdfPCell Itemcolumn1 = new PdfPCell(new Phrase(desc, textline1));
                        Itemcolumn1.BorderWidth = 0;
                        Itemtable.AddCell(Itemcolumn1);

                        withoutcategoyRecord[row].CustomItem.TryGetValue("SIZE", out lstrSize);
                        PdfPCell Itemcolumn2 = new PdfPCell(new Phrase(lstrSize, textline1));
                        Itemcolumn2.BorderWidth = 0;
                        Itemtable.AddCell(Itemcolumn2);

                        qtyonhand = withoutcategoyRecord[row].quantityonhand;
                        PdfPCell Itemcolumn3 = new PdfPCell(new Phrase(qtyonhand, textline1));
                        Itemcolumn3.BorderWidth = 0;
                        Itemcolumn3.HorizontalAlignment = 2;
                        Itemtable.AddCell(Itemcolumn3);

                        salesprice = withoutcategoyRecord[row].salesprice;
                        PdfPCell Itemcolumn4 = new PdfPCell(new Phrase(Convert.ToDecimal(salesprice).ToString("C"), textline1));
                        Itemcolumn4.BorderWidth = 0;
                        Itemcolumn4.HorizontalAlignment = 2;
                        Itemtable.AddCell(Itemcolumn4);
                    }
                }
                //Add  group by items categories
                
                foreach (string categoryname in Categories)
                {

                    //filter item list with given categories
                    var liItemRecord = (from clsItemDetails objItemRecord in lstAllItemNWNList
                                        where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                                        select objItemRecord).OrderBy(p => p.description).ToList();


                    if (liItemRecord.Count > 0)
                    {
                        string strheading = string.Empty;
                        switch (categoryname.ToUpper())
                        {
                            case "BAMB":
                                strheading = "Bamboo";
                                break;
                            case "FERN":
                                strheading = "Fern";
                                break;
                            case "FRUIT":
                                strheading = "Fruit";
                                break;
                            case "GRASS":
                                strheading = "Grasses";
                                break;
                            case "HEATH":
                                strheading = "Heath and Heathers";
                                break;
                            default:
                                break;
                        }

                        
                        PdfPCell Itemnamecolumn = new PdfPCell(new Phrase(strheading, headerfont));
                        Itemnamecolumn.BorderWidth = 0;
                        Itemtable.AddCell(Itemnamecolumn);
                        PdfPCell Itemnamecolumn1 = new PdfPCell(new Phrase(""));
                        Itemnamecolumn1.BorderWidth = 0;
                        Itemtable.AddCell(Itemnamecolumn1);
                        PdfPCell Itemnamecolumn2 = new PdfPCell(new Phrase(""));
                        Itemnamecolumn2.BorderWidth = 0;
                        Itemtable.AddCell(Itemnamecolumn2);
                        PdfPCell Itemnamecolumn3 = new PdfPCell(new Phrase(""));
                        Itemnamecolumn3.BorderWidth = 0;
                        Itemtable.AddCell(Itemnamecolumn3);


                        for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                        {
                          
                            liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);
                           
                            PdfPCell Itemcolumndesc = new PdfPCell(new Phrase("".PadLeft(7) + liItemRecord[rec].description, textline1));
                            Itemcolumndesc.BorderWidth = 0;
                            Itemcolumndesc.HorizontalAlignment = 0;
                            Itemtable.AddCell(Itemcolumndesc);

                            PdfPCell Itemcolumnsize = new PdfPCell(new Phrase(lstrSize, textline1));
                            Itemcolumnsize.BorderWidth = 0;
                            Itemcolumnsize.HorizontalAlignment = 0;
                            Itemtable.AddCell(Itemcolumnsize);

                            PdfPCell Itemcolumnqtyonhand = new PdfPCell(new Phrase(Convert.ToString(liItemRecord[rec].quantityonhand), textline1));
                            Itemcolumnqtyonhand.BorderWidth = 0;
                            Itemcolumnqtyonhand.HorizontalAlignment = 2;
                            Itemtable.AddCell(Itemcolumnqtyonhand);

                            PdfPCell Itemcolumnprice = new PdfPCell(new Phrase(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"), textline1));
                            Itemcolumnprice.BorderWidth = 0;
                            Itemcolumnprice.HorizontalAlignment = 2;
                            Itemtable.AddCell(Itemcolumnprice);
                            
                        }
                        
                    }
                }

                

                doc.Add(Itemtable);
                

            }
            catch (DocumentException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            finally
            {
                doc.Close();
            }
           

            
        }

        private void CreateNWNPdftest(string strStartupPath, string[] Categories, ArrayList lstAllItemNWNList)
        {
            string lstrSize = string.Empty;
            string desc = string.Empty;
            string qtyonhand = string.Empty;
            string qtyonsalesorder = string.Empty;
            string strheading = string.Empty;
            string salesprice = string.Empty;
            Document doc = new Document(PageSize.A4, 55f, 80f, 50f, 10f);
            var textheader = FontFactory.GetFont("Arial", 14, 3);
            var textline1 = FontFactory.GetFont("Arial", 10, 0);
            var headerfont = FontFactory.GetFont("Arial", 10, 1);
            bool IsGroupItem = false;

            string lstrimgpath = AppDomain.CurrentDomain.BaseDirectory + "nwn.png";

            string lstrGroupItem = string.Empty;
            List<clsItemDetails> categoyRecords = (lstAllItemNWNList.Cast<clsItemDetails>().OrderBy(z => z.itemname).ToList());
            for (int i = 0; i < categoyRecords.Count; i++)
            {
                categoyRecords[i].LotNo = "";
            }

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strStartupPath + @"\NWN_Files\NWN-AvailabilityList.pdf", FileMode.Create));
                doc.Open();


                //Add NWN Image 
                iTextSharp.text.Image objlogo = iTextSharp.text.Image.GetInstance(lstrimgpath);

                //Resize image depend upon your need
                objlogo.ScaleToFit(400f, 170f);
                //Give space before image
                objlogo.SpacingBefore = 10f;
                //Give some space after the image
                objlogo.SpacingAfter = 10f;
                objlogo.Alignment = Element.ALIGN_LEFT;
                doc.Add(objlogo);
                doc.Add(Chunk.NEWLINE);

                //creating header text object
                PdfPTable tableheader = new PdfPTable(1);
                tableheader.SpacingBefore = 20f;
                tableheader.SpacingAfter = 20f;
                PdfPCell cell = new PdfPCell(new Phrase(" ".PadLeft(30) + "Inventory Availability", textheader));
                tableheader.HorizontalAlignment = 1;
                cell.BorderWidth = 0;
                tableheader.AddCell(cell);
                doc.Add(tableheader);

                //create line1 text
                PdfPTable tableheader1 = new PdfPTable(2);
                PdfPCell cell1 = new PdfPCell(new Phrase("Availability data is current as of:", textline1));
                tableheader1.HorizontalAlignment = 0;

                cell1.BorderWidth = 0;
                cell1.PaddingLeft = 0;
                tableheader1.AddCell(cell1);
                PdfPCell datecell = new PdfPCell(new Phrase("  ".PadRight(15) + DateTime.Now.ToString("MMMMM dd," + ' ' + "yyyy"), headerfont));
                datecell.BorderWidth = 0;
                tableheader1.AddCell(datecell);
                doc.Add(tableheader1);

                //create line2 text
                PdfPTable tableheader2 = new PdfPTable(1);
                tableheader2.HorizontalAlignment = 0;

                PdfPCell cell3 = new PdfPCell(new Phrase("Availability data is subject to change without notice.", textline1));
                cell3.BorderWidth = 0;
                cell3.PaddingLeft = 0;
                tableheader2.AddCell(cell3);
                doc.Add(tableheader2);


                //Create Item details
                PdfPTable Itemtable = new PdfPTable(4);
                //column header row
                Itemtable.HorizontalAlignment = 0;
                Itemtable.WidthPercentage = 100f;

                //set column widths
                int[] firstTablecellwidth = { 50, 20, 15, 15 };
                Itemtable.SetWidths(firstTablecellwidth);

                Itemtable.SpacingBefore = 10f;
                Itemtable.SpacingAfter = 10f;


                PdfPCell cellhedername = new PdfPCell(new Phrase("Name", headerfont));
                cellhedername.BorderWidth = 0;
                cellhedername.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedername);


                PdfPCell cellhedersize = new PdfPCell(new Phrase("Size", headerfont));
                cellhedersize.BorderWidth = 0;
                cellhedersize.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedersize);


                PdfPCell cellhederquantity = new PdfPCell(new Phrase("Quantity", headerfont));
                cellhederquantity.BorderWidth = 0;
                cellhederquantity.HorizontalAlignment = 2;
                Itemtable.AddCell(cellhederquantity);

                PdfPCell cellhedersaleprice = new PdfPCell(new Phrase("Price", headerfont));
                cellhedersaleprice.BorderWidth = 0;
                cellhedersaleprice.HorizontalAlignment = 1;
                Itemtable.AddCell(cellhedersaleprice);




                if (categoyRecords.Count > 0)
                {

                    for (int cnt = 1; cnt <= categoyRecords.Count; cnt++)
                    {
                        if (cnt < categoyRecords.Count)
                        {
                           
                            IsGroupItem = false;
                            //check item is start with group category,write description for all group item
                            if (categoyRecords[cnt].LotNo == "")
                            {
                                
                                foreach (string categoryname in Categories)
                                {


                                    if (Convert.ToString(categoyRecords[cnt].itemname).ToLower().StartsWith(categoryname.ToLower()))
                                    {

                                        lstrGroupItem = categoryname;


                                        //filter item list with given categories
                                        var liItemRecord = (from clsItemDetails objItemRecord in categoyRecords
                                                            where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                                                            select objItemRecord).OrderBy(p => p.description).ToList();

                                        switch (categoryname.ToUpper())
                                        {
                                            case "BAMB":
                                                strheading = "Bamboo";
                                                break;
                                            case "FERN":
                                                strheading = "Fern";
                                                break;
                                            case "FRUIT":
                                                strheading = "Fruit";
                                                break;
                                            case "GRASS":
                                                strheading = "Grasses";
                                                break;
                                            case "HEATH":
                                                strheading = "Heath and Heathers";
                                                break;
                                            default:
                                                break;
                                        }

                                        PdfPCell Itemnamecolumn = new PdfPCell(new Phrase(strheading, headerfont));
                                        Itemnamecolumn.BorderWidth = 0;
                                        Itemtable.AddCell(Itemnamecolumn);
                                        PdfPCell Itemnamecolumn1 = new PdfPCell(new Phrase(""));
                                        Itemnamecolumn1.BorderWidth = 0;
                                        Itemtable.AddCell(Itemnamecolumn1);
                                        PdfPCell Itemnamecolumn2 = new PdfPCell(new Phrase(""));
                                        Itemnamecolumn2.BorderWidth = 0;
                                        Itemtable.AddCell(Itemnamecolumn2);
                                        PdfPCell Itemnamecolumn3 = new PdfPCell(new Phrase(""));
                                        Itemnamecolumn3.BorderWidth = 0;
                                        Itemtable.AddCell(Itemnamecolumn3);

                                        //Add plant category group items details
                                        for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                                        {
                                            //colposition++;
                                            liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);
                                            liItemRecord[rec].LotNo = "withcat";
                                            cnt++;
                                          
                                          
                                            for (var column = 0; column < 4; column++)
                                            {
                                               
                                              
                                                if (column == 0)
                                                {
                                                  
                                                    PdfPCell Itemcolumndesc = new PdfPCell(new Phrase("".PadLeft(7) + liItemRecord[rec].description, textline1));
                                                    Itemcolumndesc.BorderWidth = 0;
                                                    Itemcolumndesc.HorizontalAlignment = 0;
                                                    Itemtable.AddCell(Itemcolumndesc);



                                                }
                                                if (column == 1)
                                                {
                                                 
                                                    PdfPCell Itemcolumnsize = new PdfPCell(new Phrase(lstrSize, textline1));
                                                    Itemcolumnsize.BorderWidth = 0;
                                                    Itemcolumnsize.HorizontalAlignment = 0;
                                                    Itemtable.AddCell(Itemcolumnsize);

                                                }
                                                if (column == 2)
                                                {
                                                    var pdfgroupqtyval= Convert.ToDouble(liItemRecord[rec].quantityonhand) - Convert.ToDouble(liItemRecord[rec].quantityonsalesorder) > 0 ? Convert.ToDouble(liItemRecord[rec].quantityonhand) - Convert.ToDouble(liItemRecord[rec].quantityonsalesorder) : 0;

                                                    PdfPCell Itemcolumnqtyonhand = new PdfPCell(new Phrase(Convert.ToString(pdfgroupqtyval), textline1));
                                                    // PdfPCell Itemcolumnqtyonhand = new PdfPCell(new Phrase(Convert.ToString(liItemRecord[rec].quantityonhand), textline1)); //05-Oct-2018
                                                    Itemcolumnqtyonhand.BorderWidth = 0;
                                                    Itemcolumnqtyonhand.HorizontalAlignment = 2;
                                                    Itemtable.AddCell(Itemcolumnqtyonhand);

                                                }
                                                if (column == 3)
                                                {
                                                    //double ItemSalesPrice = Convert.ToDouble(liItemRecord[rec].salesprice);
                                                   // PdfPCell Itemcolumnsalesprice = new PdfPCell(new Phrase(ItemSalesPrice.ToString("C", System.Globalization.CultureInfo.CurrentCulture), textline1));
                                                    PdfPCell Itemcolumnsalesprice = new PdfPCell(new Phrase(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"), textline1));
                                                    Itemcolumnsalesprice.BorderWidth = 0;
                                                    Itemcolumnsalesprice.HorizontalAlignment = 2;
                                                    Itemtable.AddCell(Itemcolumnsalesprice);

                                                }
                                            }

                                        }

                                       // colposition++;
                                        IsGroupItem = true;

                                        break;

                                    }
                                }
                            }


                            //if non group item exist
                            if (IsGroupItem == false)
                            {
                               
                                desc = categoyRecords[cnt].description;
                                categoyRecords[cnt].CustomItem.TryGetValue("SIZE", out lstrSize);
                                qtyonhand = categoyRecords[cnt].quantityonhand;
                                qtyonsalesorder= categoyRecords[cnt].quantityonsalesorder;
                                salesprice = categoyRecords[cnt].salesprice;

                                for (var column = 0; column < 4; column++)
                                {
                                    //row = sheet.GetRow(colposition);
                                   // cell = row.CreateCell(column);
                                    if (column == 0)
                                    {
                                        // cell.SetCellValue(desc);
                                       // desc = categoyRecords[row].description;
                                        PdfPCell Itemcolumn1 = new PdfPCell(new Phrase(desc, textline1));
                                        Itemcolumn1.BorderWidth = 0;
                                        Itemtable.AddCell(Itemcolumn1);

                                    }
                                    if (column == 1)
                                    {
                                       // categoyRecords[row].CustomItem.TryGetValue("SIZE", out lstrSize);
                                        PdfPCell Itemcolumn2 = new PdfPCell(new Phrase(lstrSize, textline1));
                                        Itemcolumn2.BorderWidth = 0;
                                        Itemtable.AddCell(Itemcolumn2);
                                    }
                                    if (column == 2)
                                    {

                                        //cell.SetCellValue(Convert.ToDouble(qtyonhand)); //23-Mar-2018
                                        //cell.CellStyle = styleRight;
                                       // qtyonhand = categoyRecords[row].quantityonhand;
                                       var withoutgroupqtyvalue= (Convert.ToDouble(qtyonhand) - Convert.ToDouble(qtyonsalesorder) > 0 ? Convert.ToDouble(qtyonhand) - Convert.ToDouble(qtyonsalesorder) : 0);
                                        PdfPCell Itemcolumn3 = new PdfPCell(new Phrase(Convert.ToString(withoutgroupqtyvalue), textline1));
                                        //PdfPCell Itemcolumn3 = new PdfPCell(new Phrase(qtyonhand, textline1));
                                        Itemcolumn3.BorderWidth = 0;
                                        Itemcolumn3.HorizontalAlignment = 2;
                                        Itemtable.AddCell(Itemcolumn3);
                                    }
                                    if (column == 3)
                                    {
                                        //cell.SetCellValue(Convert.ToDecimal(dsalesprice).ToString("C"));
                                        //cell.CellStyle = styleRight;
                                        //salesprice = categoyRecords[row].salesprice;
                                        PdfPCell Itemcolumn4 = new PdfPCell(new Phrase(Convert.ToDecimal(salesprice).ToString("C"), textline1));
                                        Itemcolumn4.BorderWidth = 0;
                                        Itemcolumn4.HorizontalAlignment = 2;
                                        Itemtable.AddCell(Itemcolumn4);

                                    }
                                }
                                //colposition++;

                            }


                        }
                    }
                }

                            //Add distinct rows --for now loop coment
                            //for (var row = 1; row <= categoyRecords.Count; row++)
                            //{
                            //    if (row < categoyRecords.Count)
                            //    {
                            //        IsGroupItem = false;

                            //        desc = categoyRecords[row].description;
                            //        PdfPCell Itemcolumn1 = new PdfPCell(new Phrase(desc, textline1));
                            //        Itemcolumn1.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemcolumn1);

                            //        categoyRecords[row].CustomItem.TryGetValue("SIZE", out lstrSize);
                            //        PdfPCell Itemcolumn2 = new PdfPCell(new Phrase(lstrSize, textline1));
                            //        Itemcolumn2.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemcolumn2);

                            //        qtyonhand = categoyRecords[row].quantityonhand;
                            //        PdfPCell Itemcolumn3 = new PdfPCell(new Phrase(qtyonhand, textline1));
                            //        Itemcolumn3.BorderWidth = 0;
                            //        Itemcolumn3.HorizontalAlignment = 2;
                            //        Itemtable.AddCell(Itemcolumn3);

                            //        salesprice = categoyRecords[row].salesprice;
                            //        PdfPCell Itemcolumn4 = new PdfPCell(new Phrase(Convert.ToDecimal(salesprice).ToString("C"), textline1));
                            //        Itemcolumn4.BorderWidth = 0;
                            //        Itemcolumn4.HorizontalAlignment = 2;
                            //        Itemtable.AddCell(Itemcolumn4);
                            //    }
                            //}

                            //Add  group by items categories --for now commented

                            //foreach (string categoryname in Categories)
                            //{

                            //    //filter item list with given categories
                            //    var liItemRecord = (from clsItemDetails objItemRecord in lstAllItemNWNList
                            //                        where objItemRecord.itemname.Trim().ToLower().StartsWith(categoryname.Trim().ToLower())
                            //                        select objItemRecord).OrderBy(p => p.description).ToList();


                            //    if (liItemRecord.Count > 0)
                            //    {
                            //        string strheading = string.Empty;
                            //        switch (categoryname.ToUpper())
                            //        {
                            //            case "BAMB":
                            //                strheading = "Bamboo";
                            //                break;
                            //            case "FERN":
                            //                strheading = "Fern";
                            //                break;
                            //            case "FRUIT":
                            //                strheading = "Fruit";
                            //                break;
                            //            case "GRASS":
                            //                strheading = "Grasses";
                            //                break;
                            //            case "HEATH":
                            //                strheading = "Heath and Heathers";
                            //                break;
                            //            default:
                            //                break;
                            //        }


                            //        PdfPCell Itemnamecolumn = new PdfPCell(new Phrase(strheading, headerfont));
                            //        Itemnamecolumn.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemnamecolumn);
                            //        PdfPCell Itemnamecolumn1 = new PdfPCell(new Phrase(""));
                            //        Itemnamecolumn1.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemnamecolumn1);
                            //        PdfPCell Itemnamecolumn2 = new PdfPCell(new Phrase(""));
                            //        Itemnamecolumn2.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemnamecolumn2);
                            //        PdfPCell Itemnamecolumn3 = new PdfPCell(new Phrase(""));
                            //        Itemnamecolumn3.BorderWidth = 0;
                            //        Itemtable.AddCell(Itemnamecolumn3);


                            //        for (int rec = 0; rec < liItemRecord.Count; rec++) // Loop through List with for
                            //        {

                            //            liItemRecord[rec].CustomItem.TryGetValue("SIZE", out lstrSize);

                            //            PdfPCell Itemcolumndesc = new PdfPCell(new Phrase("".PadLeft(7) + liItemRecord[rec].description, textline1));
                            //            Itemcolumndesc.BorderWidth = 0;
                            //            Itemcolumndesc.HorizontalAlignment = 0;
                            //            Itemtable.AddCell(Itemcolumndesc);

                            //            PdfPCell Itemcolumnsize = new PdfPCell(new Phrase(lstrSize, textline1));
                            //            Itemcolumnsize.BorderWidth = 0;
                            //            Itemcolumnsize.HorizontalAlignment = 0;
                            //            Itemtable.AddCell(Itemcolumnsize);

                            //            PdfPCell Itemcolumnqtyonhand = new PdfPCell(new Phrase(Convert.ToString(liItemRecord[rec].quantityonhand), textline1));
                            //            Itemcolumnqtyonhand.BorderWidth = 0;
                            //            Itemcolumnqtyonhand.HorizontalAlignment = 2;
                            //            Itemtable.AddCell(Itemcolumnqtyonhand);

                            //            PdfPCell Itemcolumnprice = new PdfPCell(new Phrase(Convert.ToDecimal(liItemRecord[rec].salesprice).ToString("C"), textline1));
                            //            Itemcolumnprice.BorderWidth = 0;
                            //            Itemcolumnprice.HorizontalAlignment = 2;
                            //            Itemtable.AddCell(Itemcolumnprice);

                            //        }

                            //    }
                            //}



                            doc.Add(Itemtable);


            }
            catch (DocumentException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            finally
            {
                doc.Close();
            }



        }

        protected virtual bool IsFileinUse(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
        //BackgroundWorker bgw = new BackgroundWorker();
        
        //void bgw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var watch = new System.Diagnostics.Stopwatch();
        //   double currtime;
        //    int percents;
        //   // watch.Start();
        //    // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))) ==0 ? 1 : Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //1
        //    // currtime = watch.Elapsed.Seconds;
        //    currtime = 80;
        //    //System.Threading.Thread.Sleep(100);
        //    //percents = (1 * 100) / Convert.ToInt32(currtime);
        //    //bgw.ReportProgress(percents, 1);

        //    //Get sync Items from XML file
        //    string strStartupPath = System.Windows.Forms.Application.StartupPath;

        //    if (Directory.Exists(Path.Combine(strStartupPath, @"NWN_Files")))
        //    {
        //        string[] files = Directory.GetFiles(Path.Combine(strStartupPath, @"NWN_Files"));

        //        if (files.Length > 0)
        //        {
        //            foreach (string filetype in files)
        //            {
        //                //check if file is in use
        //                FileInfo fInfo = new FileInfo(filetype);

        //                if (IsFileinUse(fInfo))
        //                {
        //                    MessageBox.Show("File is already open.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;
        //                }

        //            }
        //        }
        //    }


        //    // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //2
        //   // currtime = watch.Elapsed.Seconds;
        //    System.Threading.Thread.Sleep(100);
        //    percents = (2 * 100) / Convert.ToInt32(currtime);
        //    bgw.ReportProgress(percents, 2);

        //    //Get updated items from QB and write to XML
        //    if (WriteItemsForNWN(strStartupPath) == true)
        //    {
        //        //  currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //3
        //        //currtime = watch.Elapsed.Seconds;
        //        System.Threading.Thread.Sleep(100);
        //        percents = (3 * 100) / Convert.ToInt32(currtime);
        //        bgw.ReportProgress(percents, 3);

        //        //using (new HourGlass())
        //       // {

        //            ReadSyncItemsForNWN(strStartupPath);
        //            //Create Excel File with Items Details
        //            string[] Categories = Enum.GetNames(typeof(clsItemDetails.PlantCategories));//Get plantCategories
        //                                                                                        //without category items details
        //            List<clsItemDetails> lstwithoutcategoyRecord = (lstAllItemNWNList.Cast<clsItemDetails>().Where(z =>
        //                             !Categories.Any(x => z.itemname.ToLower().Trim().StartsWith(x.ToLower().Trim()))).OrderBy(z => z.description).ToList());

        //        // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //4
        //       // currtime = watch.Elapsed.Seconds;
        //        System.Threading.Thread.Sleep(100);
        //            percents = (4 * 100) / Convert.ToInt32(currtime);
        //            bgw.ReportProgress(percents, 4);

        //            CreateNWNExcel(strStartupPath, Categories, lstwithoutcategoyRecord, lstAllItemNWNList);

        //        // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //5
        //       // currtime = watch.Elapsed.Seconds;
        //        System.Threading.Thread.Sleep(100);
        //            percents = (5 * 100) / Convert.ToInt32(currtime);
        //            bgw.ReportProgress(percents, 5);

        //            //Create Pdf File with Item Details
        //            CreateNWNPdf(strStartupPath, Categories, lstwithoutcategoyRecord, lstAllItemNWNList);

        //           // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //6
        //            System.Threading.Thread.Sleep(100);
        //            percents = (6 * 100) / Convert.ToInt32(currtime);
        //            bgw.ReportProgress(percents, 6);

        //            //Upload Excel & Pdf to FTP

        //            string sourcefilepath = string.Empty;
        //            List<string> lstFilePath = new List<string>();

        //            sourcefilepath = Path.Combine(strStartupPath, @"NWN_Files");
        //            if (string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("FTPServerPath")) || string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("LoginID")) || string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Password")))
        //            {
        //                MessageBox.Show("FTP server information does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                //reading files from //NWN_Files
        //                if (Directory.Exists(sourcefilepath))
        //                {
        //                    if (Directory.GetFiles(sourcefilepath, "*.*").Length > 0)
        //                    {
        //                        foreach (string file in Directory.EnumerateFiles(sourcefilepath, "*.*"))
        //                        {
        //                            lstFilePath.Add(file);
        //                        }
        //                        foreach (var filename in lstFilePath)
        //                        {
        //                            ftpUpload(filename);
        //                        }
        //                       // currtime = Math.Round(ConvertMillisecondsToSeconds(Convert.ToDouble(watch.ElapsedMilliseconds))); //7
        //                        System.Threading.Thread.Sleep(100);
        //                        percents = (7 * 100) / Convert.ToInt32(currtime);
        //                        bgw.ReportProgress(percents, 7);
        //                        MessageBox.Show("Files uploaded to FTP server successfully ", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    }
        //                    else
        //                    {
        //                        //msg files not found
        //                    }
        //                }
        //                else
        //                {
        //                    //msg folder not found
        //                }
        //            }
        //      //  } //hourGlass end


        //    }
        // //   watch.Stop();

        //}
        //void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar1.Value = e.ProgressPercentage;
        //    label2.Text = String.Format("Progress: {0} %", e.ProgressPercentage);
        //  //  label2.Text = String.Format("Total items transfered: {0}", e.UserState);
        //}

        //void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //do the code when bgv completes its work
        //}
        private void btnUpdateWebPrices_Click(object sender, EventArgs e)
        {
            bool blnfileupload = false;
            ////Get sync Items from XML file
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector");

            if (Directory.Exists(Path.Combine(strStartupPath, @"NWN_Files")))
            {
                string[] files = Directory.GetFiles(Path.Combine(strStartupPath, @"NWN_Files"));

                if (files.Length > 0)
                {
                    foreach (string filetype in files)
                    {
                        //check if file is in use
                        FileInfo fInfo = new FileInfo(filetype);

                        if (IsFileinUse(fInfo))
                        {
                            MessageBox.Show("File is already open.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }
            }


            btnUpdateWebPrices.Enabled = false;


            // bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            // bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            // bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            // bgw.WorkerReportsProgress = true;
            // bgw.RunWorkerAsync();
            

            //Get updated items from QB and write to XML
            if (WriteItemsForNWN(strStartupPath) == true)
            {
                using (new HourGlass())
                {

                    ReadSyncItemsForNWN(strStartupPath);
                    //Create Excel File with Items Details
                    string[] Categories = Enum.GetNames(typeof(clsItemDetails.PlantCategories));//Get plantCategories
                                                                                                //without category items details
                    List<clsItemDetails> lstwithoutcategoyRecord = (lstAllItemNWNList.Cast<clsItemDetails>().Where(z =>
                                     !Categories.Any(x => z.itemname.ToLower().Trim().StartsWith(x.ToLower().Trim()))).OrderBy(z => z.description).ToList());



                     // CreateNWNPOIExcel(strStartupPath, Categories, lstwithoutcategoyRecord, lstAllItemNWNList); // currently running 
                    // CreateNWNPOIExcelBrOrder(strStartupPath, Categories,lstAllItemNWNList);
                    CreateNWNPOIExcelBrOrdertest(strStartupPath, Categories, lstAllItemNWNList);

                    
                    //Create Pdf File with Item Details
                    // CreateNWNPdf(strStartupPath, Categories, lstwithoutcategoyRecord, lstAllItemNWNList);
                    
                    CreateNWNPdftest(strStartupPath, Categories,lstAllItemNWNList);

                    //Upload Excel & Pdf to FTP

                    string sourcefilepath = string.Empty;
                    List<string> lstFilePath = new List<string>();

                    sourcefilepath = Path.Combine(strStartupPath, @"NWN_Files");
                    if (string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("FTPServerPath")) || string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("LoginID")) || string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Password")))
                    {
                        MessageBox.Show("FTP server information does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //reading files from //NWN_Files
                        if (Directory.Exists(sourcefilepath))
                        {
                            if (Directory.GetFiles(sourcefilepath, "*.*").Length > 0)
                            {
                                foreach (string file in Directory.EnumerateFiles(sourcefilepath, "*.*"))
                                {
                                    lstFilePath.Add(file);
                                }
                                foreach (var filename in lstFilePath)
                                {
                                  blnfileupload=ftpUpload(filename);
                                    if (blnfileupload == false)
                                        break;
                                }
                                if (blnfileupload == true)
                                {
                                    MessageBox.Show("Files uploaded to FTP server successfully ", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                //msg files not found
                            }
                        }
                        else
                        {
                            //msg folder not found
                        }
                    }
                } //hourGlass end


            }

            btnUpdateWebPrices.Enabled = true;

        }

        private bool ftpUpload(string fileNamepath)
        {
            lobjQBConfiguration = new QBConfiguration();
            string errorstring=string.Empty;
            bool blnupload = false;
          

            string ftpurl = lobjQBConfiguration.GetLabelConfigSettings("FTPServerPath");//@"ftp://192.168.0.7//accuware//"; //get this from settings file
            string ftpusername = lobjQBConfiguration.GetLabelConfigSettings("LoginID");//@"Administrator"; //get this from settings file
            string ftppassword = lobjQBConfiguration.GetLabelConfigSettings("Password");//@"$imcindia2006$"; //get this from settings file

            try
            {
                string filename = Path.GetFileName(fileNamepath);
                string ftpfullpath = Path.Combine(ftpurl, filename);
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Timeout = 600000;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(fileNamepath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
                blnupload = true;
                
            }
            catch (Exception ex)
            {
                blnupload = false;
               
                    if (ex.Message.ToString().Contains("Not logged in"))
                    {
                        MessageBox.Show("Invalid FTP LoginID/Password", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (ex.Message.ToString().Contains("Invalid URI"))
                    {
                        MessageBox.Show("FTP URL not in correct Format" + Environment.NewLine + "Format should be :ftp://192.168.0.7//accuware//", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                
                //throw ex;
            }
            return blnupload;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                lblTempName.Text = "";
                string template = "";
                string templatepath = "";
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();               
                templatepath = string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath")) ? "" : Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("itemtemppath"));

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
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), "itemtemppath");
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
                        lobjQBConfiguration.SaveLabelFilePathSettings(openFileDialog1.FileName.ToString(), "itemtemppath");
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

        private void btnBin_Click(object sender, EventArgs e)
        {
            int cntChk = 0;
            using (new HourGlass())
            {

                if (DataGVSearchItem.Rows.Count > 0)
                {

                    for (int i = 0; i < DataGVSearchItem.Rows.Count; i++)
                    {
                        if (DataGVSearchItem.Rows[i].Cells["CheckBox"].Value.ToString().Trim() == "False")
                        {
                            cntChk = cntChk + 1;
                        }
                    }
                    if (cntChk == DataGVSearchItem.Rows.Count)
                    {
                        MessageBox.Show("Please Check At Least One Record To Bind Bin Values", "Label Connector");
                        return;
                    }
                    try
                    {

                        for (int j = 0; j < DataGVSearchItem.Rows.Count; j++)
                        {
                            if (DataGVSearchItem.Rows[j].Cells["CheckBox"].Value.ToString().Trim() == "True")
                            {
                                DataGridViewComboBoxCell Itemcolbin = (DataGridViewComboBoxCell)DataGVSearchItem.Rows[j].Cells["Bin"];
                                Itemcolbin.Items.Clear();
                                var ItemName = DataGVSearchItem.Rows[j].Cells["itemname"].Value.ToString().Trim();
                                ArrayList listBin = new ArrayList();
                                var itemsalesDescription = (from clsItemDetails item in lstAllItemList
                                                            where item.Name == ItemName
                                                            select item).FirstOrDefault();

                                if (itemsalesDescription != null)
                                {
                                    if (string.IsNullOrWhiteSpace(itemsalesDescription.subitemof))
                                    {
                                        listBin = clsTemplateLabelXmlwork.GetItemBinMultiList(ItemName);
                                    }
                                    else
                                    {
                                        listBin = clsTemplateLabelXmlwork.GetItemBinMultiList(itemsalesDescription.subitemof + ":" + ItemName);
                                    }
                                    bool isload = true;
                                    if (listBin.Count > 0)
                                    {
                                        foreach (string bin in listBin)
                                        {
                                            Itemcolbin.Items.Add(bin);
                                            if (isload)
                                            {
                                                Itemcolbin.Value = bin;
                                            }
                                            isload = false;

                                        }

                                    }
                                }
                            }


                        }

                    }

                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }

        }

        private void DataGVSearchItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = DataGVSearchItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)DataGVSearchItem.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)DataGVSearchItem.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }


    }
}
