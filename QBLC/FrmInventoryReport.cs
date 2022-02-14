using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using QBLC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;


namespace LabelConnector
{
    public partial class FrmInventoryReport : Form
    {
        string lstrFirstSubCategoryInLoop = string.Empty;
        string lstrFirstSubCategoryOutLoop = string.Empty;
       
        decimal lntTotalAllParentCategory = 0;
        decimal lntTotalItemsBySubCat1 = 0;
        decimal lntTotalItemsBySubCat2 = 0;
        decimal lntTotalItemsBySubCat2Print = 0;
        ArrayList arrSubCatItem = new ArrayList();
        ArrayList arrParentCatItem = new ArrayList();
        clsReportItems objclsReportItems = new clsReportItems();
        clsPurchaseOrderLine objBillReceiptData = new clsPurchaseOrderLine();

        public FrmInventoryReport()
        {
            InitializeComponent();
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);
        public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            
            ArrayList arrsearchItemlist = new ArrayList();
            ArrayList arrParentMachine = new ArrayList();
           
            List<clsReportItems> FilterInvItemlist = null;
            string fileuploadDate = string.Empty;
            string lstrGuage = string.Empty;
            string lstrreportheader1 = "Shima Seiki U.S.A. Inc.\n";
            string lstrreportheader2 = "Inventory Status Report-Machines\n";
            string lstrreportheader3 = "As Of";
            string pathSource = string.Empty;
            int colposition = 0;
            string strStartupPath = System.Windows.Forms.Application.StartupPath;


            // string pathSource = strStartupPath + @"\Inventory_Report\Inventory-Status-Report-Machines.xls";
             string pathSourcenew = System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\" + "Inventory-Status-Report-Machines.xls";
            // string pathSource = strStartupPath + @"\Inventory-Status-Report-Machines.xls";
            pathSource = System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\";
            //Delete existing files from Transxml folder
            System.IO.DirectoryInfo di = new DirectoryInfo(pathSource);
            if (di.Exists)
            {
                if (di.GetFiles().Length > 0)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
            if (!Directory.Exists(pathSource))
            {
                Directory.CreateDirectory(pathSource);
            }
            File.Copy(System.Windows.Forms.Application.StartupPath + @"\" + "Inventory-Status-Report-Machines.xls", pathSource + "Inventory-Status-Report-Machines.xls", true);


            //if (Directory.Exists(Path.Combine(strStartupPath, @"Inventory_Report")))
            //{
            //    string[] files = Directory.GetFiles(Path.Combine(strStartupPath, @"Inventory_Report"));

            //    if (files.Length > 0)
            //    {
            //        foreach (string filetype in files)
            //        {
            //            //check if file is in use
            //            FileInfo fInfo = new FileInfo(filetype);

            //            if (IsFileinUse(fInfo))
            //            {
            //                MessageBox.Show("File is already open.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }

            //        }
            //    }
            //}

            using (new HourGlass())
            {
                //Create Excel Inventory Report
                //CreateInventoryReport();
                //Get all inventory Items filter by Asset account 'Machine'
                List<clsReportItems> InvItemlist = objclsReportItems.GetInventoryItemList().OrderBy(x => x.ParentFullName).ToList();
               
                //Get all Bill Receipt Data
                List<clsReportItems> BillReceiptItemlist = objclsReportItems.GetReceiptsBillInfo();

                //Filter Bill Receipt Data using Item Name
                foreach (var Invitem in InvItemlist)
                {
                    FilterInvItemlist = new List<clsReportItems>();
                    FilterInvItemlist = BillReceiptItemlist.Where(p => p.ReceiptptItemName.ToString().ToLower().Trim().Replace(" ","") == Convert.ToString(Invitem.itemname).ToLower().Trim().Replace(" ", "")).ToList();
                        //Add receipt data to InventoryItemlist
                        foreach (var filteritem in FilterInvItemlist)
                        {
                            Invitem.PurchaseDate = filteritem.ReceiptPurchaseDate;
                            Invitem.Site = filteritem.Site;
                            Invitem.Bin = filteritem.Bin;
                            Invitem.purchasecost = Convert.ToDecimal(filteritem.ReceiptCost); // cost from receipt
                            Invitem.TotalCost= Convert.ToDecimal(filteritem.TotalCost);
                           //Invitem.ReceiptCost = Convert.ToDecimal(filteritem.ReceiptCost); #1

                    }
                       
                
                }


                //Write Inventory Item to Excels
                //show purchase cost from item
                HSSFWorkbook hssfwb;
                IRow row;
                ISheet sheet;
                ICell cell;
                //Align Text
                ICellStyle styleLeft;
                ICellStyle styleRight;
                ICellStyle styleCenter;
                ICellStyle styleBorder;
               // ICellStyle styleLastBorder;


                using (FileStream file = new FileStream(pathSourcenew, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                    file.Close();
                }

                sheet = hssfwb.GetSheetAt(0);
                styleLeft = hssfwb.CreateCellStyle();
                styleRight = hssfwb.CreateCellStyle();
                styleCenter= hssfwb.CreateCellStyle();
                styleBorder = hssfwb.CreateCellStyle();
               // styleLastBorder = hssfwb.CreateCellStyle();

                styleLeft.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
                styleRight.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
                styleCenter.Alignment= NPOI.SS.UserModel.HorizontalAlignment.Center;
                styleBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
               // styleBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                styleBorder.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
               // styleLastBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

                //write Date : 17-Apr-2018
                DateTime dt = DateTime.Now;
                fileuploadDate = dt.ToString("MMMMM dd, " + ' ' + "yyyy");

                //IRow dataRow = sheet.GetRow(5) ?? sheet.CreateRow(5);
                //ICell datecell = dataRow.GetCell(3) ?? dataRow.CreateCell(3);
                //datecell.SetCellValue(fileuploadDate);
                //var datefont = hssfwb.CreateFont();
                //datefont.FontHeightInPoints = 13;
                //datefont.FontName = "Arial";
                //datefont.Boldweight = (short)FontBoldWeight.Bold;
                //datecell.RichStringCellValue.ApplyFont(datefont);
                arrParentMachine.Clear();


                string reportheadertext = lstrreportheader1.PadLeft(30) + lstrreportheader2 + lstrreportheader3.PadLeft(10) +  " " + fileuploadDate;
                //HSSFRichTextString reportheadertext = new HSSFRichTextString("Shima Seiki U.S.A. Inc.\nInventory Status Report - Machines\nAs Of" + fileuploadDate);
                //Write Top Header #1
                IRow dataRow = sheet.GetRow(0) ?? sheet.CreateRow(0);
                ICell Headercell = dataRow.GetCell(2) ?? dataRow.CreateCell(2);
                Headercell.CellStyle.WrapText = true;
                Headercell.CellStyle.VerticalAlignment = VerticalAlignment.Top;

                Headercell.SetCellValue(reportheadertext);

                Headercell.Row.HeightInPoints = (short)75;
                var headerfont = hssfwb.CreateFont();
                headerfont.FontHeightInPoints = 14;
                headerfont.FontName = "Arial";
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                Headercell.RichStringCellValue.ApplyFont(headerfont);

                //Normal Font for row items
                var DetailRowfont = hssfwb.CreateFont();
                DetailRowfont.FontHeightInPoints = 10;
                DetailRowfont.FontName = "Arial";
                DetailRowfont.Boldweight = (short)FontBoldWeight.Normal;

                //column font bold
                var colfont = hssfwb.CreateFont();
                colfont.FontHeightInPoints = 10;
                colfont.FontName = "Arial";
                colfont.Boldweight = (short)FontBoldWeight.Bold;
                //int lntcounter = 0;
                List<InventoryMachineCategory> lstInventoryMachineCategory = new List<InventoryMachineCategory>();
                List<InventoryColumnsTotal> lstInventoryColumnsTotal = new List<InventoryColumnsTotal>();

                sheet.SetColumnWidth(0, 5000);
                sheet.SetColumnWidth(1, 3000);
                sheet.SetColumnWidth(2, 12000);
                sheet.SetColumnWidth(3, 5000);
                sheet.SetColumnWidth(4, 5000);
                sheet.SetColumnWidth(5, 2000);
                sheet.SetColumnWidth(6, 5000);
               // sheet.SetColumnWidth(7, 5000);
                sheet.SetColumnWidth(7, 5000);
                sheet.SetColumnWidth(8, 7000);
                sheet.SetColumnWidth(9, 8000);

                IRow ColumnNameRow = sheet.GetRow(2) ?? sheet.CreateRow(2);
                ICell ColumnNamecell = null;


                for (int col = 0; col < 11; col++) //Write Column Names
                {

                    switch (col)
                    {
                        case 0:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        case 1:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Date");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        case 2:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Model & MFG#");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        case 3:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Guage");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        case 4:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Mfg#");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        case 5:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Quantity");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;
                        case 6:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Unit Cost");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;
                        //case 7:
                        //    ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                        //    ColumnNamecell.SetCellValue("Purchase Cost");
                        //    ColumnNamecell.CellStyle = styleCenter;
                        //    ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                        //    break; #1

                        case 7:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Total Cost");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;
                        case 8:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Location");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;
                        case 9:
                            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                            ColumnNamecell.SetCellValue("Site");
                            ColumnNamecell.CellStyle = styleCenter;
                            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                            break;

                        default:
                            break;



                    }



                }
                // colposition++;
                int lntColumnStatusTotal = 0;
                decimal decColumnLastUnitCostColumn = 0;
                decimal decTotalCostColumn = 0;
                //decimal decTotalPurchaseCostColumn = 0;

                //for Last Total Row
                int lntLastMachineTotal = 0;
                decimal decLastUnitCostColTotal = 0;
                decimal decLastTotalCostColTotal = 0;
               // decimal decLastTotalPurchaseCostColTotal = 0;



                colposition = 3;
                if (InvItemlist.Count > 0)
                {

                    for (int cnt = 0; cnt <= InvItemlist.Count; cnt++) //change cnt 1 to 0
                    {
                        if (cnt < InvItemlist.Count)
                        {

                           
                               var  firstsubcategorygroup = (from InventoryMachineCategory objItemRecord in lstInventoryMachineCategory
                                                             where objItemRecord.ParentMachineType.Trim().ToLower().Trim() == Convert.ToString(InvItemlist[cnt].MachineType.ToString().ToLower().Trim()) && objItemRecord.ParentSubCategory1.Trim().ToLower().Trim() == Convert.ToString(InvItemlist[cnt].MachineSubCategory1.ToString().ToLower().Trim())
                                                             select objItemRecord).OrderBy(p => p.ParentMachineType).ToList();
                            
                       

                            ////////// Add Column  and subcategory1 Totals s001,s002....
                            if (firstsubcategorygroup.Count == 0)
                            {

                                if (lstInventoryMachineCategory.Count > 0)
                                {
                                    IRow ColumnSubCatgoryTotalRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                    ICell ColumnSubCatgoryTotalcell = null;
                                    var SubCatTotals =
                                    from invcategory in lstInventoryMachineCategory
                                    group invcategory by new { invcategory.ParentMachineType, invcategory.ParentSubCategory1 } into InvcatGroup
                                    select new
                                    {
                                        Team = InvcatGroup.Key,
                                        SubCategory1Total = InvcatGroup.Sum(x => Convert.ToUInt32(x.InventoryQuantityOnHand)),
                                        UnitCostTotal = InvcatGroup.Sum(x => Convert.ToDecimal(x.InventoryUnitcostTotal)),
                                        InvTotalCost= InvcatGroup.Sum(x => Convert.ToDecimal(x.InventoryTotalCost)),
                                      // InvTotalPurchaseCost = InvcatGroup.Sum(x => Convert.ToDecimal(x.InvTotalPurchaseCost)), #1

                                    };


                                    foreach (var item in SubCatTotals)
                                    {

                                        //write machine count status,unit cost,Total cost column total
                                        
                                        for (int subcolsum = 0; subcolsum < 11; subcolsum++)
                                        {
                                            switch(subcolsum)
                                            {
                                                case 0:
                                                   ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                   ColumnSubCatgoryTotalcell.SetCellValue("");
                                                   ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                   ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                                case 1:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("Machine Count-Status");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                 break;
                                                case 2:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToString(item.SubCategory1Total));
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                    // ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                    lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(Convert.ToInt32(item.SubCategory1Total), 0, 0, 0));
                                                    break;
                                                case 3:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                    break;
                                                case 4:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                    break;
                                                case 5:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                    break;
                                                case 6:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToDecimal(item.UnitCostTotal).ToString("C"));
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                    // ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                    lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, Convert.ToDecimal(item.UnitCostTotal), 0, 0));
                                                    break;
                                                //case 7: //#1
                                                //    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                //    ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToDecimal(item.InvTotalPurchaseCost).ToString("C"));
                                                //    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                //    //ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                //    ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                //    lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, 0, Convert.ToDecimal(item.InvTotalPurchaseCost),0));
                                                //    break;
                                                case 7:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToDecimal(item.InvTotalCost).ToString("C"));
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                    //ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                    lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, 0, 0, Convert.ToDecimal(item.InvTotalCost)));
                                                    break;
                                                case 8:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                    break;
                                                case 9:
                                                    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                    ColumnSubCatgoryTotalcell.SetCellValue("");
                                                    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                    break;
                                                default:
                                                    break;


                                            }
                                            
                                        }
                                    }
                                    colposition++;
                                    //Add Empty Rows
                                    ColumnSubCatgoryTotalRow = sheet.CreateRow(colposition);
                                    ColumnSubCatgoryTotalRow.CreateCell(0).SetCellValue("");
                                    colposition++;

                                }
                                lstInventoryMachineCategory.Clear();
                            }
                            //write Columns Total for MC010,MC020,MC030...
                            if (arrParentMachine.Count > 0)
                            {
                                if (!arrParentMachine.Contains(Convert.ToString(InvItemlist[cnt].MachineType.ToString().ToLower().Trim())))
                                {

                                   lntColumnStatusTotal = 0;
                                   decColumnLastUnitCostColumn = 0;
                                   decTotalCostColumn = 0;
                                   //decTotalPurchaseCostColumn = 0;


                                    if (lstInventoryColumnsTotal.Count > 0) //Last Cols Totals
                                    {
                                        foreach (var LastColTotal in lstInventoryColumnsTotal.ToList())
                                        {
                                            lntColumnStatusTotal += LastColTotal.MachineCountStatusTotal;
                                            decColumnLastUnitCostColumn += LastColTotal.LastUnitCostColumnTotal;
                                           // decTotalPurchaseCostColumn += LastColTotal.LastPurchaseCostColumnTotal;
                                            decTotalCostColumn += LastColTotal.LastTotalCostColumnTotal;
                                        }
                                    }
                                    //for Last Row Total
                                    lntLastMachineTotal += lntColumnStatusTotal;
                                    decLastUnitCostColTotal += decColumnLastUnitCostColumn;
                                    decLastTotalCostColTotal += decTotalCostColumn;
                                   // decLastTotalPurchaseCostColTotal += decTotalCostColumn;#1

                                    IRow ParentGroupTotalRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                    ICell ParentGroupTotalcell = null;
                                    ParentGroupTotalcell = ParentGroupTotalRow.GetCell(2) ?? ParentGroupTotalRow.CreateCell(2);
                                    ParentGroupTotalcell.SetCellValue(lntColumnStatusTotal.ToString());
                                    ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                                    // ParentGroupTotalcell.CellStyle = styleRight;
                                    ParentGroupTotalcell.CellStyle = styleBorder;
                                    //UnitCost Column Total
                                    ParentGroupTotalcell = ParentGroupTotalRow.GetCell(5) ?? ParentGroupTotalRow.CreateCell(5);
                                    ParentGroupTotalcell.SetCellValue("Division Total:");
                                    // ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                                    ParentGroupTotalcell.CellStyle = styleLeft;

                                    ParentGroupTotalcell = ParentGroupTotalRow.GetCell(6) ?? ParentGroupTotalRow.CreateCell(6);
                                    ParentGroupTotalcell.SetCellValue(Convert.ToDecimal(decColumnLastUnitCostColumn).ToString("C"));
                                    ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                                    // ParentGroupTotalcell.CellStyle = styleRight;
                                    ParentGroupTotalcell.CellStyle = styleBorder;

                                    //ParentGroupTotalcell = ParentGroupTotalRow.GetCell(7) ?? ParentGroupTotalRow.CreateCell(7);
                                    //ParentGroupTotalcell.SetCellValue(Convert.ToDecimal(decTotalPurchaseCostColumn).ToString("C"));
                                    //ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                                    //// ParentGroupTotalcell.CellStyle = styleRight;
                                    //ParentGroupTotalcell.CellStyle = styleBorder; #1

                                    ParentGroupTotalcell = ParentGroupTotalRow.GetCell(7) ?? ParentGroupTotalRow.CreateCell(7);
                                    ParentGroupTotalcell.SetCellValue(Convert.ToDecimal(decTotalCostColumn).ToString("C"));
                                    ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                                    //ParentGroupTotalcell.CellStyle = styleRight;
                                    ParentGroupTotalcell.CellStyle = styleBorder;

                                    colposition++;
                                    lstInventoryColumnsTotal.Clear();



                                }
                            }
                            
                            //Write Parent Machine Category MC010,MC020...
                            if (!arrParentMachine.Contains(Convert.ToString(InvItemlist[cnt].MachineType.ToString().ToLower().Trim()))) //check Parent Machine Type Exist in array
                            {
                                IRow ParentMachineCategroyRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                ICell ParentMachineCategroycell = ParentMachineCategroyRow.GetCell(0) ?? ParentMachineCategroyRow.CreateCell(0);

                                ParentMachineCategroycell.SetCellValue(InvItemlist[cnt].MachineType != null ? Convert.ToString(InvItemlist[cnt].MachineType.ToString()) : string.Empty);
                                arrParentMachine.Add(InvItemlist[cnt].MachineType != null ? Convert.ToString(InvItemlist[cnt].MachineType.ToString().ToLower().Trim()) : string.Empty);

                                //Make  Font Bold and display
                                var font = hssfwb.CreateFont();
                                font.FontHeightInPoints = 10;
                                font.FontName = "Arial";
                                font.Boldweight = (short)FontBoldWeight.Bold;
                                ParentMachineCategroycell.RichStringCellValue.ApplyFont(font);

                                colposition++;


                                //IRow ColumnNameRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                //ICell ColumnNamecell = null;


                                //for (int col = 0; col < 11; col++) //Write Column Names
                                //{

                                //     switch(col)
                                //      {
                                //           case 0:
                                //           ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //           ColumnNamecell.SetCellValue("SubCategory");
                                //           ColumnNamecell.CellStyle = styleCenter;
                                //           ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //           break;

                                //            case 1:
                                //            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //            ColumnNamecell.SetCellValue("Date");
                                //            ColumnNamecell.CellStyle = styleCenter;
                                //            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //            break;

                                //            case 2:
                                //            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //            ColumnNamecell.SetCellValue("Model & MFG#");
                                //            ColumnNamecell.CellStyle = styleCenter;
                                //            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //            break;

                                //            case 3:
                                //            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //            ColumnNamecell.SetCellValue("Guage");
                                //            ColumnNamecell.CellStyle = styleCenter;
                                //            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //            break;

                                //            case 4:
                                //            ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //            ColumnNamecell.SetCellValue("Mfg#");
                                //            ColumnNamecell.CellStyle = styleCenter;
                                //            ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //            break;

                                //            case 5:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Quantity");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;
                                //            case 6:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Unit Cost");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;
                                //            case 7:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Purchase Cost");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;

                                //            case 8:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Total Cost");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;
                                //            case 9:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Location");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;
                                //            case 10:
                                //                ColumnNamecell = ColumnNameRow.GetCell(col) ?? ColumnNameRow.CreateCell(col);
                                //                ColumnNamecell.SetCellValue("Site");
                                //                ColumnNamecell.CellStyle = styleCenter;
                                //                ColumnNamecell.RichStringCellValue.ApplyFont(colfont);
                                //                break;

                                //            default:
                                //                break;



                                //        }



                                //    }
                                //colposition++;
                            }
                            ///////
                            //Add sub categeory record

                            IRow ColumnSubCatgoryRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                            ICell ColumnSubCatgorycell = null;

                            for (int subcatrow = 0; subcatrow < 11; subcatrow++) //loop in columns
                            {
                               
                                switch(subcatrow)
                                {
                                    case 0:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].MachineSubCategory1 !=null ? Convert.ToString(InvItemlist[cnt].MachineSubCategory1.ToString()) : string.Empty); //First SubCategory Item
                                        if (InvItemlist[cnt].MachineSubCategory1 != null)
                                        {
                                           
                                            lstInventoryMachineCategory.Add(new InventoryMachineCategory(Convert.ToString(InvItemlist[cnt].MachineType.ToString()), Convert.ToString(InvItemlist[cnt].MachineSubCategory1.ToString()), Convert.ToString(InvItemlist[cnt].MachineSubCategory2.ToString()), Convert.ToInt32(InvItemlist[cnt].quantityonhand),Convert.ToDecimal(InvItemlist[cnt].purchasecost), Convert.ToDecimal(InvItemlist[cnt].ReceiptCost), Convert.ToDecimal(InvItemlist[cnt].TotalCost),0));
                                            
                                        }
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;

                                        break;
                                    case 1:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue((InvItemlist[cnt].PurchaseDate !=null && InvItemlist[cnt].PurchaseDate !="")  ? Convert.ToDateTime(InvItemlist[cnt].PurchaseDate.ToString()).ToString("MM/dd/yyyy") : string.Empty); //Purchase Date
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleRight;
                                        break;
                                    case 2:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].description !=null ? Convert.ToString(InvItemlist[cnt].description.ToString()) : string.Empty); //Model & MFG#
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    case 3:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        InvItemlist[cnt].CustomItem.TryGetValue("_GUAGE", out lstrGuage);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].CustomItem !=null ? Convert.ToString(lstrGuage) : string.Empty); //Guage
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    case 4:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].mpn !=null ?  Convert.ToString(InvItemlist[cnt].mpn.ToString()) : string.Empty); //mfg#
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    case 5:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].quantityonhand != null ? Convert.ToString(InvItemlist[cnt].quantityonhand.ToString()) : string.Empty); //Quantity On Hand
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    case 6:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].purchasecost != 0 ? Convert.ToString(InvItemlist[cnt].purchasecost.ToString("#,##0.00")) : string.Empty); //Item Cost
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleRight;
                                        break;
                                    //case 7: #1
                                    //    ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                    //    ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].ReceiptCost != 0 ? Convert.ToString(InvItemlist[cnt].ReceiptCost.ToString("#,##0.00")) : string.Empty); //Purchase Cost from Receipt
                                    //    ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                    //    ColumnSubCatgorycell.CellStyle = styleRight;
                                    //    break;
                                    case 7:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].TotalCost != 0 ? Convert.ToString(InvItemlist[cnt].TotalCost.ToString("#,##0.00")) : string.Empty); //Total Cost
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleRight;
                                        break;
                                    case 8:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].Bin != null ? Convert.ToString(InvItemlist[cnt].Bin) : string.Empty); //Location
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    case 9:
                                        ColumnSubCatgorycell = ColumnSubCatgoryRow.GetCell(subcatrow) ?? ColumnSubCatgoryRow.CreateCell(subcatrow);
                                        ColumnSubCatgorycell.SetCellValue(InvItemlist[cnt].Site != null ? Convert.ToString(InvItemlist[cnt].Site) : string.Empty); //Site i.e WareHouse
                                        ColumnSubCatgorycell.RichStringCellValue.ApplyFont(DetailRowfont);
                                        ColumnSubCatgorycell.CellStyle = styleLeft;
                                        break;
                                    default:
                                        break;

                                       
                                }
                            }
                            colposition++;
                           // break;



                        }
                        else
                        {
                            //for last row column total
                            if (lstInventoryMachineCategory.Count > 0)
                            {
                                IRow ColumnSubCatgoryTotalRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                ICell ColumnSubCatgoryTotalcell = null;
                                var SubCatTotals =
                                from invcategory in lstInventoryMachineCategory
                                group invcategory by new { invcategory.ParentMachineType, invcategory.ParentSubCategory1 } into InvcatGroup
                                select new
                                {
                                    Team = InvcatGroup.Key,
                                    SubCategory1Total = InvcatGroup.Sum(x => Convert.ToUInt32(x.InventoryQuantityOnHand)),
                                    UnitCostTotal = InvcatGroup.Sum(x => Convert.ToDecimal(x.InventoryUnitcostTotal)),
                                    InvTotalCost = InvcatGroup.Sum(x => Convert.ToDecimal(x.InventoryTotalCost)),
                                   // InvTotalPurchaseCost= InvcatGroup.Sum(x => Convert.ToDecimal(x.InvTotalPurchaseCost)),
                                };
                               

                                foreach (var item in SubCatTotals)
                                {

                                    //write machine count status,unit cost,Total cost column total
                                    // var ls = item.Team;
                                    // IRow ColumnNameTotalsRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                                    // ICell ColumnNameTotalscell = ColumnNameTotalsRow.GetCell(1) ?? ColumnNameTotalsRow.CreateCell(1);
                                    // var columnsTotal = item.SubCategory1Total;


                                    for (int subcolsum = 0; subcolsum < 11; subcolsum++)
                                    {
                                        switch (subcolsum)
                                        {
                                            case 0:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 1:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("Machine Count-Status");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 2:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToString(item.SubCategory1Total));
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                // ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(Convert.ToInt32(item.SubCategory1Total), 0, 0, 0));
                                                break;
                                            case 3:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 4:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 5:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 6:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToDecimal(item.UnitCostTotal).ToString("C"));
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                // ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, Convert.ToDecimal(item.UnitCostTotal), 0,0));
                                                break;
                                            //case 7: #1
                                            //    ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                            //    ColumnSubCatgoryTotalcell.SetCellValue("");
                                            //    ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                            //    ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                            //    lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, 0, Convert.ToDecimal(item.InvTotalPurchaseCost), 0));
                                            //    break;
                                            case 7:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue(Convert.ToDecimal(item.InvTotalCost).ToString("C"));
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(colfont);
                                                // ColumnSubCatgoryTotalcell.CellStyle = styleRight;
                                                ColumnSubCatgoryTotalcell.CellStyle = styleBorder;
                                                lstInventoryColumnsTotal.Add(new InventoryColumnsTotal(0, 0,0, Convert.ToDecimal(item.InvTotalCost)));
                                                break;
                                            case 8:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            case 9:
                                                ColumnSubCatgoryTotalcell = ColumnSubCatgoryTotalRow.GetCell(subcolsum) ?? ColumnSubCatgoryTotalRow.CreateCell(subcolsum);
                                                ColumnSubCatgoryTotalcell.SetCellValue("");
                                                ColumnSubCatgoryTotalcell.RichStringCellValue.ApplyFont(DetailRowfont);
                                                ColumnSubCatgoryTotalcell.CellStyle = styleLeft;
                                                break;
                                            default:
                                                break;


                                        }

                                    }
                                }
                                colposition++;
                                //Add Empty Rows
                                ColumnSubCatgoryTotalRow = sheet.CreateRow(colposition);
                                ColumnSubCatgoryTotalRow.CreateCell(0).SetCellValue("");
                                colposition++;

                            }
                            lstInventoryMachineCategory.Clear();

                            //Last Row MC010,MC020,MC030  Column Total

                            lntColumnStatusTotal = 0;
                            decColumnLastUnitCostColumn = 0;
                            decTotalCostColumn = 0;
                            //decTotalPurchaseCostColumn = 0;


                            if (lstInventoryColumnsTotal.Count > 0) //Last Cols Totals
                            {
                                foreach (var LastColTotal in lstInventoryColumnsTotal.ToList())
                                {
                                    lntColumnStatusTotal += LastColTotal.MachineCountStatusTotal;
                                    decColumnLastUnitCostColumn += LastColTotal.LastUnitCostColumnTotal;
                                    //decTotalPurchaseCostColumn += LastColTotal.LastPurchaseCostColumnTotal; #1
                                    decTotalCostColumn += LastColTotal.LastTotalCostColumnTotal;
                                   
                                }
                            }

                            //for Last Row Total
                            lntLastMachineTotal += lntColumnStatusTotal;
                            decLastUnitCostColTotal += decColumnLastUnitCostColumn;
                            decLastTotalCostColTotal += decTotalCostColumn;
                           // decLastTotalPurchaseCostColTotal += decTotalCostColumn; #1

                            IRow ParentGroupLastTotalRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                            ICell ParentGroupLastTotalcell = null;
                            ParentGroupLastTotalcell = ParentGroupLastTotalRow.GetCell(2) ?? ParentGroupLastTotalRow.CreateCell(2);
                            ParentGroupLastTotalcell.SetCellValue(lntColumnStatusTotal.ToString());
                            ParentGroupLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            ParentGroupLastTotalcell.CellStyle = styleRight;
                            //UnitCost Column Total

                            ParentGroupLastTotalcell = ParentGroupLastTotalRow.GetCell(5) ?? ParentGroupLastTotalRow.CreateCell(5);
                            ParentGroupLastTotalcell.SetCellValue("Division Total:");
                            // ParentGroupTotalcell.RichStringCellValue.ApplyFont(colfont);
                            ParentGroupLastTotalcell.CellStyle = styleLeft;

                            ParentGroupLastTotalcell = ParentGroupLastTotalRow.GetCell(6) ?? ParentGroupLastTotalRow.CreateCell(6);
                            ParentGroupLastTotalcell.SetCellValue(Convert.ToDecimal(decColumnLastUnitCostColumn).ToString("C"));
                            ParentGroupLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            // ParentGroupLastTotalcell.CellStyle = styleRight;
                            ParentGroupLastTotalcell.CellStyle = styleBorder;


                            //PurchaseCost Column Total

                            //ParentGroupLastTotalcell = ParentGroupLastTotalRow.GetCell(7) ?? ParentGroupLastTotalRow.CreateCell(7);
                            //ParentGroupLastTotalcell.SetCellValue(Convert.ToDecimal(decTotalPurchaseCostColumn).ToString("C"));
                            //ParentGroupLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            //// ParentGroupLastTotalcell.CellStyle = styleRight;
                            //ParentGroupLastTotalcell.CellStyle = styleBorder; #1

                            //TotalCost Column Total
                            ParentGroupLastTotalcell = ParentGroupLastTotalRow.GetCell(7) ?? ParentGroupLastTotalRow.CreateCell(7);
                            ParentGroupLastTotalcell.SetCellValue(Convert.ToDecimal(decTotalCostColumn).ToString("C"));
                            ParentGroupLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            // ParentGroupLastTotalcell.CellStyle = styleRight;
                            ParentGroupLastTotalcell.CellStyle = styleBorder;

                            //All Machine Qty Totals and Category Totals
                            colposition++;
                            IRow AllMachineLastTotalRow = sheet.GetRow(colposition) ?? sheet.CreateRow(colposition);
                            ICell AllMachineLastTotalcell = null;
                            AllMachineLastTotalcell = AllMachineLastTotalRow.GetCell(1) ?? AllMachineLastTotalRow.CreateCell(1);
                            AllMachineLastTotalcell.SetCellValue("Grand Total");
                           // AllMachineLastTotalcell.RichStringCellValue.ApplyFont(pare);
                            AllMachineLastTotalcell.CellStyle = styleLeft;

                            AllMachineLastTotalcell = AllMachineLastTotalRow.GetCell(2) ?? AllMachineLastTotalRow.CreateCell(2);
                            AllMachineLastTotalcell.SetCellValue(lntLastMachineTotal.ToString());
                            AllMachineLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                           // AllMachineLastTotalcell.CellStyle = styleRight;
                            AllMachineLastTotalcell.CellStyle = styleBorder;

                            AllMachineLastTotalcell = AllMachineLastTotalRow.GetCell(6) ?? AllMachineLastTotalRow.CreateCell(6);
                            AllMachineLastTotalcell.SetCellValue(Convert.ToDecimal(decLastUnitCostColTotal).ToString("C"));
                            AllMachineLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            // AllMachineLastTotalcell.CellStyle = styleRight;
                            AllMachineLastTotalcell.CellStyle = styleBorder;

                            AllMachineLastTotalcell = AllMachineLastTotalRow.GetCell(7) ?? AllMachineLastTotalRow.CreateCell(7);
                            AllMachineLastTotalcell.SetCellValue(Convert.ToDecimal(decLastTotalCostColTotal).ToString("C"));
                            AllMachineLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            // AllMachineLastTotalcell.CellStyle = styleRight;
                            AllMachineLastTotalcell.CellStyle = styleBorder;

                            //AllMachineLastTotalcell = AllMachineLastTotalRow.GetCell(8) ?? AllMachineLastTotalRow.CreateCell(8);
                            //AllMachineLastTotalcell.SetCellValue(Convert.ToDecimal(decLastTotalPurchaseCostColTotal).ToString("C"));
                            //AllMachineLastTotalcell.RichStringCellValue.ApplyFont(colfont);
                            //// AllMachineLastTotalcell.CellStyle = styleRight;
                            //AllMachineLastTotalcell.CellStyle = styleBorder; #1

                            lstInventoryColumnsTotal.Clear();
                            MessageBox.Show("Inventory status report created successfully.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReport.Visible = true;

                        }
                    }
                }



                using (FileStream file = new FileStream(pathSourcenew, FileMode.Open, FileAccess.Write))
                {
                    hssfwb.Write(file);

                    file.Close();

                }


                //save report file to download folder
                string excelfileapppath = System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\" + "Inventory-Status-Report-Machines.xls";

                string downloads;
                SHGetKnownFolderPath(Downloads, 0, IntPtr.Zero, out downloads);
                if (File.Exists(excelfileapppath))
                {
                    File.Copy(excelfileapppath, downloads + "\\" + "Inventory-Status-Report-Machines.xls", true); //copy report to download folders
                }


                //var resultmultiplekey = from stu in InvItemlist
                //                        group stu by new { stu.MachineType, stu.MachineSubCategory1, stu.MachineSubCategory2 }
                //                       into egroup
                //                        orderby egroup.Key.MachineType, egroup.Key.MachineSubCategory1, egroup.Key.MachineSubCategory2
                //                        select egroup;


                //foreach (var group in resultmultiplekey)
                //{
                //    if (group.Key.MachineType != "")
                //    {
                //        Console.WriteLine(group.Key.MachineType, group.Key.MachineSubCategory1, group.Key.MachineSubCategory2, group.Count());
                //        lntTotalItemsBySubCat2Print = 0;

                //        //Print Total for SubItemCat1 S00,S001,S002
                //        if (!arrSubCatItem.Contains(group.Key.MachineSubCategory1.ToString().ToUpper().Trim()) && arrSubCatItem.Count != 0)
                //        {
                //            //print here Total for ItemSubCategory1...S00,S001,S002....
                //            var svalue = lntTotalItemsBySubCat1; //Print Total of SubCatItem S00,S01,S02...
                //            lntTotalAllParentCategory += Convert.ToDecimal(svalue); // ie. Print Total of MC010,MC020,MC030

                //        }


                //        //Items Total from MachineSubcategory2 i.e. M123,M153..
                //        // lntTotalItemsBySubCat2 = group.Count();

                //        lntTotalItemsBySubCat2 = 0;
                //        foreach (var _childitem in group)
                //        {

                //            Console.WriteLine(_childitem.itemname, _childitem.description, _childitem.MachineType, _childitem.MachineSubCategory1, _childitem.MachineSubCategory2, _childitem.quantityonhand);
                //            lntTotalItemsBySubCat2 += Convert.ToDecimal(_childitem.quantityonhand);
                //            lntTotalItemsBySubCat2Print += Convert.ToDecimal(_childitem.quantityonhand);
                //        }
                //        //print MachineSubcategory2 count here i.e. M123,M153..

                //        var ItemSubCat2 = lntTotalItemsBySubCat2Print;

                //        //Item Total for MachineSubCategory1
                //        if (!arrSubCatItem.Contains(group.Key.MachineSubCategory1.ToString().ToUpper().Trim()))
                //        {
                //            arrSubCatItem.Clear();
                //            lntTotalItemsBySubCat1 = 0;
                //            arrSubCatItem.Add(group.Key.MachineSubCategory1.ToString().ToUpper().Trim()); //i.e. S001,S002
                //            lntTotalItemsBySubCat1 += lntTotalItemsBySubCat2;
                //        }
                //        else
                //        {
                //            lntTotalItemsBySubCat1 += lntTotalItemsBySubCat2;
                //        }


                //    }

                //}



            }
        }

       public void GetExcelInfo(string pstrfilepath)
        {
         
           // string pathSourceInfo = pstrfilepath + @"\Inventory_Report\Inventory-Status-Report-Machines.xls";
            HSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(pstrfilepath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }

            ISheet sheet = hssfwb.GetSheet("Sheet1");
            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    if (sheet.GetRow(row).GetCell(2) != null)
                    {
                      
                       // MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(2).StringCellValue));
                        if(sheet.GetRow(row).GetCell(2).StringCellValue.ToUpper().Trim()== "MODEL & MFG#")
                        {
                            btnReport.Visible = true;
                        }
                    }
                }
                
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

        private void FrmInventoryReport_Load(object sender, EventArgs e)
        {
            btnReport.Visible = false;
            string strStartupPathInfo = System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\" + "Inventory-Status-Report-Machines.xls";
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\"))
            {
                if (File.Exists(strStartupPathInfo))
                {
                    GetExcelInfo(strStartupPathInfo);
                }
            }
            else
            {
                btnReport.Visible = false;
            }

            //btnReport.Visible = false;
            //string strStartupPath = System.Windows.Forms.Application.StartupPath;
            //string pathSource = strStartupPath + @"\Inventory_Report\Inventory-Status-Report-Machines.xls";

            //if (Directory.Exists(Path.Combine(strStartupPath, @"Inventory_Report")))
            //{
            //    string[] filescount = Directory.GetFiles(Path.Combine(strStartupPath, @"Inventory_Report"));

            //    if (filescount.Length > 0)
            //    {
            //        btnReport.Visible = true;
            //    }
            //}
      }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            //frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            //parentForm.GridPanel = true;
            //((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            //this.Hide();
            //this.Close();
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Are you sure you want to exit?", "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
           

        }


        private void FrmInventoryReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
            //parentForm.GridPanel = true;
            //((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
            //this.Hide();
            //this.Close();
            //DialogResult dialog = new DialogResult();

            //dialog = MessageBox.Show("Are you sure you want to exit?", "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (dialog == DialogResult.Yes)
            //{
            //    System.Environment.Exit(1);
            //}
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            //string strStartupPath = System.Windows.Forms.Application.StartupPath;
            //string excelpathSource = System.Windows.Forms.Application.StartupPath + @"\" + "Inventory_Report" + "\\" + "Inventory-Status-Report-Machines.xls";

            string downloads;
            SHGetKnownFolderPath(Downloads, 0, IntPtr.Zero, out downloads);
            //if (File.Exists(excelpathSource))
            //{
            //    File.Copy(excelpathSource, downloads + "\\" + "Inventory-Status-Report-Machines.xls", true); //copy report to download folders
            //}

            // OpenMicrosoftExcel(excelpathSource);
            //open download foloder for report file
            //string lstrdownloadfolderpath = string.Empty;

           // lstrdownloadfolderpath = downloads;  //+ "\\" + "Inventory-Status-Report-Machines.xls";
            Process.Start(downloads);
        }
        static void OpenMicrosoftExcel(string file)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = file;
            try
            {
                Process.Start(startInfo);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                
            }
        }


    }
}
