using Interop.QBFC13;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LabelConnector
{
    public class clsReportItems
    {
        string lstrItemName;
        string lstrFullName;
        string lstrParentFullName;
        string lstrSalesDescription;
        string lstrSalesPrice;
        string lstrQuantityonSalesorder;
        string lstrQuantityonOrder;
        string lstrQuantityonHand;
        decimal lstrPurchaseCost=0;
        string lstrItemweight;
        string lstrAverageCost;
        bool blnvarAvgCost = false;
        bool blnItemwithoutcategory = false;
        string lstrManufacturerPartNumber;
        string lstrUnitOfMeasureSetRef;
        string lstrPurchaseDesc;
        string lstrIncomeAccountRef;
        string lstrPrefVendorRef;
        string lstrBarCodeValue;
        string lstrCOGSAccountRef;
        string lstrAssetAccountRef;
        string lstrItemType;
        string lstrExpenseAccountRef;
        string lstrDescription;
        string _strPurchaseDate = string.Empty;
        string lstrSize;
        string _strLotNo = string.Empty;
        int lntid;
        string lstrMachineType = string.Empty;
        string lstrmachinesubcategory1 = string.Empty;
        string lstrmachinesubcategory2 = string.Empty;
        string lstrmachinesubcategory3 = string.Empty;
        string lstrmachinesubcategory4 = string.Empty;
        string _strPurchaseOrderLocation = string.Empty;
        string _strPurchaseOrderBin = string.Empty;
        string lstrReceiptptItemName = string.Empty;
        string lstrReceiptLineDesc = string.Empty;
        decimal _strReceiptCost =0;

        string _strTransID = string.Empty;
        string _strTxnLineID = string.Empty;
        string _strVendorRefFullName = string.Empty;
        string _strReceiptPurchaseDate = string.Empty;
        string _strReceiptSerialNumber = string.Empty;

        double dblReceiptQuantity = 0;
        decimal dclTotalCost = 0;

        public readonly IDictionary<string, string> CustomItem = new Dictionary<string, string>();

        public string this[string key]
        {
            // returns value if exists
            get { return CustomItem[key]; }

            // updates if exists, adds if doesn't exist
            set { CustomItem[key] = value; }
        }


        public string Name
        {
            get
            {
                return lstrItemName;
            }
            set
            {
                lstrItemName = value;
            }
        }


        public string ReceiptptItemName
        {
            get
            {
                return lstrReceiptptItemName;
            }
            set
            {
                lstrReceiptptItemName = value;
            }
        }

        public string ReceiptLineDesc
        {
            get
            {
                return lstrReceiptLineDesc;
            }
            set
            {
                lstrReceiptLineDesc = value;
            }
        }

        public double ReceiptQuantity
        {
            get
            {
                return dblReceiptQuantity;
            }
            set
            {
                dblReceiptQuantity = value;
            }
        }

        public decimal ReceiptCost
        {
            get
            {
                return _strReceiptCost;
            }
            set
            {
                _strReceiptCost = value;
            }
        }

        public string ReceiptSerialNumber
        {
            get
            {
                return _strReceiptSerialNumber;
            }
            set
            {
                _strReceiptSerialNumber = value;
            }
        }

        public string ReceiptPurchaseDate
        {
            get
            {
                return _strReceiptPurchaseDate;
            }
            set
            {
                _strReceiptPurchaseDate = value;
            }
        }
        public string PurchaseDate
        {
            get
            {
                return _strPurchaseDate;
            }
            set
            {
                _strPurchaseDate = value;
            }
        }
        public string VendorRefFullName
        {
            get
            {
                return _strVendorRefFullName;
            }
            set
            {
                _strVendorRefFullName = value;
            }
        }
        public string TxnLineID
        {
            get
            {
                return _strTxnLineID;
            }
            set
            {
                _strTxnLineID = value;
            }
        }
        public string TransID
        {
            get
            {
                return _strTransID;
            }
            set
            {
                _strTransID = value;
            }
        }

        public string LotNo
        {
            get { return _strLotNo; }
            set { _strLotNo = value; }
        }
        public int id
        {
            get
            {
                return lntid;
            }
            set
            {
                lntid = value;
            }

        }
        public string mpn
        {
            get
            {
                return lstrManufacturerPartNumber;
            }
            set
            {
                lstrManufacturerPartNumber = value;
            }

        }


        public string ExpenseAccountRef
        {
            get
            {
                return lstrExpenseAccountRef;
            }
            set
            {
                lstrExpenseAccountRef = value;
            }
        }
        public string unitofmeasuresetref
        {
            get
            {
                return lstrUnitOfMeasureSetRef;
            }
            set
            {
                lstrUnitOfMeasureSetRef = value;
            }
        }

        public string Size
        {
            get
            {
                return lstrSize;
            }
            set
            {
                lstrSize = value;
            }
        }

        public string incomeaccountref
        {
            get
            {
                return lstrIncomeAccountRef;
            }
            set
            {
                lstrIncomeAccountRef = value;
            }
        }
        public string assetaccountref
        {
            get
            {
                return lstrAssetAccountRef;
            }
            set
            {
                lstrAssetAccountRef = value;
            }


        }
        
        public decimal TotalCost
        {
            get
            {
                return dclTotalCost;
            }
            set
            {
                dclTotalCost = value;
            }


        }
        public string itemtype
        {
            get { return lstrItemType; }
            set { lstrItemType = value; }
        }

        public string prefvendorref
        {
            get
            {
                return lstrPrefVendorRef;
            }
            set
            {
                lstrPrefVendorRef = value;
            }
        }

        public string barcodevalue
        {
            get
            {
                return lstrBarCodeValue;
            }
            set
            {
                lstrBarCodeValue = value;
            }
        }
        public string cogsaccountref
        {
            get
            {
                return lstrCOGSAccountRef;
            }
            set
            {
                lstrCOGSAccountRef = value;
            }
        }

        public string FullName
        {
            get
            {
                return lstrFullName;
            }
            set
            {
                lstrFullName = value;
            }
        }
        public string itemname
        {
            get
            {
                return lstrItemName;
            }
            set
            {
                lstrItemName = value;
            }
        }
        public string ParentFullName
        {
            get
            {
                return lstrParentFullName;
            }
            set
            {
                lstrParentFullName = value;
            }
        }

        public string MachineType
        {
            get { return lstrMachineType; }
            set { lstrMachineType = value; }
        }
        public string MachineSubCategory1
        {
            get { return lstrmachinesubcategory1; }
            set { lstrmachinesubcategory1 = value; }
        }
        public string MachineSubCategory2
        {
            get { return lstrmachinesubcategory2; }
            set { lstrmachinesubcategory2 = value; }
        }
        public string MachineSubCategory3
        {
            get { return lstrmachinesubcategory3; }
            set { lstrmachinesubcategory3 = value; }
        }
        public string MachineSubCategory4
        {
            get { return lstrmachinesubcategory4; }
            set { lstrmachinesubcategory4 = value; }
        }
       


        public string SalesDescription
        {
            get
            {
                return lstrSalesDescription;
            }
            set
            {
                lstrSalesDescription = value;
            }
        }

        public string description
        {
            get { return lstrDescription; }
            set { lstrDescription = value; }

        }
        public bool blnAvgCostDisable
        {
            get
            {
                return blnvarAvgCost;
            }
            set
            {
                blnvarAvgCost = value;
            }
        }

        public bool blnCategoryItem
        {
            get { return blnItemwithoutcategory; }
            set { blnItemwithoutcategory = value; }

        }
        public string salesprice
        {
            get
            {
                return lstrSalesPrice;
            }
            set
            {
                lstrSalesPrice = value;
            }
        }

        public string quantityonsalesorder
        {
            get
            {
                return lstrQuantityonSalesorder;
            }
            set
            {
                lstrQuantityonSalesorder = value;
            }
        }

        public string quantityonorder
        {
            get
            {
                return lstrQuantityonOrder;
            }
            set
            {
                lstrQuantityonOrder = value;
            }
        }

        public string averagecost
        {
            get { return lstrAverageCost; }
            set { lstrAverageCost = value; }
        }
        public string quantityonhand
        {
            get
            {
                return lstrQuantityonHand;
            }
            set
            {
                lstrQuantityonHand = value;
            }
        }
        public decimal purchasecost
        {
            get
            {
                return lstrPurchaseCost;
            }
            set
            {
                lstrPurchaseCost = value;
            }
        }

        public string purchasedesc
        {
            get { return lstrPurchaseDesc; }
            set { lstrPurchaseDesc = value; }
        }

        public string ItemWeight
        {

            get
            {
                return lstrItemweight;
            }
            set
            {

                lstrItemweight = value;
            }
        }

        public string Site
        {
            get { return _strPurchaseOrderLocation; }
            set { _strPurchaseOrderLocation = value; }
        }

        public string Bin
        {
            get { return _strPurchaseOrderBin; }
            set { _strPurchaseOrderBin = value; }
        }

        //Functions

        //Get Inventory Items:Date 23-11-2015
        public List<clsReportItems> GetInventoryItemList()
        {
            

            clsReportItems lobjItemdetails = null;
            Dictionary<string, string> lobjInventoryItemExtensions = new Dictionary<string, string>();
            List<clsReportItems> lstInventoryItems = new List<clsReportItems>();
           // ArrayList lstItemlist = new ArrayList();


            string strInventoryCustomerFieldName = string.Empty;
            string strInventoryCustomerFieldValue = string.Empty;


            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                //for Inventory Item
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");

                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward


                //Add Non Inventory Item to List
                //IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                //ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                //ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);


            }
            catch (Exception Ex)
            {

                throw;
            }
            finally
            {
                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
            }
            try
            {


                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    // IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IResponseList responseList = lMsgResponse.ResponseList;
                    if (responseList == null)
                    {
                        
                        return null;
                    }

                    for (int i = 0; i < responseList.Count; i++)
                    {
                        IResponse loResponse = responseList.GetAt(i);
                        //check the status code of the response, 0=ok, >0 is warning
                        if (loResponse.StatusCode >= 0)
                        {
                            //the request-specific response is in the details, make sure we have some
                            if (loResponse.Detail != null)
                            {
                                //make sure the response is the type we're expecting
                                ENResponseType responseType = (ENResponseType)loResponse.Type.GetValue();

                                if (responseType == ENResponseType.rtItemInventoryQueryRs)
                                {
                                    IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;

                                    IItemInventoryRet loProduct = default(IItemInventoryRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsReportItems();
                                            loProduct = loList.GetAt(Index);

                                            if (loProduct.AssetAccountRef != null && loProduct.AssetAccountRef.FullName != null)
                                            {
                                                // lobjItemdetails.assetaccountref = clsStringExtension.SubstringAfter(Convert.ToString(loProduct.AssetAccountRef.FullName.GetValue()), ":");
                                                //Get Asset Acc Item only
                                                if (clsStringExtension.SubstringAfter(Convert.ToString(loProduct.AssetAccountRef.FullName.GetValue()), ":").ToLower().Trim() == "machine")
                                                {
                                                    //Get items having quantity on hand > 0
                                                    if (Convert.ToInt32(loProduct.QuantityOnHand.GetValue()) > 0)
                                                    {
                                                        if (loProduct.Name != null)
                                                            lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue());//Get child only
                                                        if (loProduct.FullName != null)
                                                        {
                                                            lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child 
                                                            //lstItemlist.Add(Convert.ToString(loProduct.FullName.GetValue()));
                                                        }
                                                        // lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue()); //Get child
                                                        if (loProduct.ParentRef != null)
                                                        {
                                                            if (loProduct.FullName != null)
                                                            {
                                                                lobjItemdetails.ParentFullName = Convert.ToString(loProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                                                string[] ItemType = lobjItemdetails.ParentFullName.Split(':');

                                                                for (int ctritem = 0; ctritem < ItemType.Length; ctritem++)
                                                                {
                                                                    switch (ctritem)
                                                                    {
                                                                        case 0:
                                                                            lobjItemdetails.MachineType = ItemType[ctritem];
                                                                            break;
                                                                        case 1:
                                                                            lobjItemdetails.MachineSubCategory1 = ItemType[ctritem];
                                                                            break;
                                                                        case 2:
                                                                            lobjItemdetails.MachineSubCategory2 = ItemType[ctritem];
                                                                            break;
                                                                        case 3:
                                                                            lobjItemdetails.MachineSubCategory3 = ItemType[ctritem];
                                                                            break;
                                                                        case 4:
                                                                            lobjItemdetails.MachineSubCategory4 = ItemType[ctritem];
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }

                                                                }
                                                                
                                                            }
                                                        }
                                                        if (loProduct.SalesDesc != null)
                                                        {
                                                            //lobjItemdetails.SalesDescription = Convert.ToString(loProduct.SalesDesc.GetValue());
                                                            lobjItemdetails.description = Convert.ToString(loProduct.SalesDesc.GetValue());
                                                        }

                                                        if (loProduct.SalesPrice != null)
                                                            lobjItemdetails.salesprice = Convert.ToString(loProduct.SalesPrice.GetValue());
                                                        if (loProduct.QuantityOnSalesOrder != null)
                                                            lobjItemdetails.quantityonsalesorder = Convert.ToString(loProduct.QuantityOnSalesOrder.GetValue());
                                                        if (loProduct.QuantityOnOrder != null)
                                                            lobjItemdetails.quantityonorder = Convert.ToString(loProduct.QuantityOnOrder.GetValue()); // Qty on purchase order
                                                        if (loProduct.QuantityOnHand != null)
                                                            lobjItemdetails.quantityonhand = Convert.ToString(loProduct.QuantityOnHand.GetValue());
                                                        //Get Avg cost and Qty on hand:Date 03-April-2017
                                                        if (loProduct.AverageCost != null)
                                                        {
                                                            lobjItemdetails.averagecost = Convert.ToString(loProduct.AverageCost.GetValue());
                                                        }
                                                        if (loProduct.UnitOfMeasureSetRef != null && loProduct.UnitOfMeasureSetRef.FullName != null)
                                                            lobjItemdetails.unitofmeasuresetref = Convert.ToString(loProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                                        if (loProduct.ManufacturerPartNumber != null)
                                                            lobjItemdetails.mpn = Convert.ToString(loProduct.ManufacturerPartNumber.GetValue());
                                                        if (loProduct.PurchaseDesc != null)
                                                            lobjItemdetails.purchasedesc = Convert.ToString(loProduct.PurchaseDesc.GetValue());
                                                        if (loProduct.PurchaseCost != null)
                                                            lobjItemdetails.purchasecost = Convert.ToDecimal(loProduct.PurchaseCost.GetValue());
                                                        if (loProduct.IncomeAccountRef != null)
                                                            lobjItemdetails.incomeaccountref = Convert.ToString(loProduct.IncomeAccountRef.FullName.GetValue());
                                                        if (loProduct.PrefVendorRef != null && loProduct.PrefVendorRef.FullName != null) //FullName not null check added
                                                            lobjItemdetails.prefvendorref = Convert.ToString(loProduct.PrefVendorRef.FullName.GetValue());
                                                        if (loProduct.BarCodeValue != null)
                                                            lobjItemdetails.barcodevalue = Convert.ToString(loProduct.BarCodeValue.GetValue());
                                                        if (loProduct.COGSAccountRef != null && loProduct.COGSAccountRef.FullName != null)
                                                            lobjItemdetails.cogsaccountref = Convert.ToString(loProduct.COGSAccountRef.FullName.GetValue());
                                                        //if (loProduct.AssetAccountRef != null && loProduct.AssetAccountRef.FullName != null)
                                                        lobjItemdetails.assetaccountref = Convert.ToString(loProduct.AssetAccountRef.FullName.GetValue());
                                                        //lobjItemdetails.itemtype = "Inventory Part";
                                                        //Calculate Total Cost #
                                                        // lobjItemdetails.TotalCost = Convert.ToDecimal(loProduct.QuantityOnHand.GetValiue()) * Convert.ToDecimal(loProduct.PurchaseCost.GetValue());
                                                        if (!string.IsNullOrWhiteSpace(lobjItemdetails.quantityonhand))
                                                        {
                                                            lobjItemdetails.TotalCost = Convert.ToDecimal(lobjItemdetails.quantityonhand) * lobjItemdetails.purchasecost;
                                                        }

                                                        //Get Custom Field for Inventory Item
                                                        if (loProduct.DataExtRetList != null)
                                                        {
                                                            for (int custcol = 0; custcol < loProduct.DataExtRetList.Count; custcol++)
                                                            {
                                                                IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(custcol);

                                                                strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                                strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                                lobjItemdetails.CustomItem.Add("_" + strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                            }
                                                        }

                                                        lstInventoryItems.Add(lobjItemdetails);
                                                    }
                                                }

                                            }

                                        } //for loop end
                                        
                                    }


                                }
                               

                                //else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                //{

                                //    IItemNonInventoryRetList ItemNonInventoryloList = (IItemNonInventoryRetList)loResponse.Detail;

                                //    IItemNonInventoryRet ItemNonInventoryProduct = default(IItemNonInventoryRet);

                                //    if (ItemNonInventoryloList != null)
                                //    {
                                //        for (int Index = 0; Index < ItemNonInventoryloList.Count; Index++)
                                //        {
                                //            lobjItemdetails = new clsItemDetails();
                                //            ItemNonInventoryProduct = ItemNonInventoryloList.GetAt(Index);

                                //            // if (ItemNonInventoryProduct.Name != null)
                                //            //      lobjItemdetails.Name = Convert.ToString(ItemNonInventoryProduct.Name.GetValue());//Get child only
                                //            if (ItemNonInventoryProduct.FullName != null)
                                //                //lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child - commented by srinivas on 28-Sep-2017
                                //                lobjItemdetails.itemname = Convert.ToString(ItemNonInventoryProduct.Name.GetValue()); //Get child
                                //            //  if (ItemNonInventoryProduct.ParentRef != null)
                                //            //   lobjItemdetails.ParentFullName = Convert.ToString(ItemNonInventoryProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc != null)
                                //                {
                                //                    //lobjItemdetails.SalesDescription = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                //                    lobjItemdetails.description = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice != null)
                                //                {
                                //                    lobjItemdetails.salesprice = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.UnitOfMeasureSetRef != null && ItemNonInventoryProduct.UnitOfMeasureSetRef.FullName != null)
                                //                lobjItemdetails.unitofmeasuresetref = Convert.ToString(ItemNonInventoryProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                //            if (ItemNonInventoryProduct.ManufacturerPartNumber != null)
                                //                lobjItemdetails.mpn = Convert.ToString(ItemNonInventoryProduct.ManufacturerPartNumber.GetValue());
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc != null)
                                //                {
                                //                    lobjItemdetails.purchasedesc = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost != null)
                                //                {
                                //                    lobjItemdetails.purchasecost = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName != null)
                                //                {
                                //                    lobjItemdetails.incomeaccountref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef.FullName != null) //Fullname not null check added
                                //                {
                                //                    lobjItemdetails.prefvendorref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef.FullName.GetValue());
                                //                }
                                //            }
                                //            if (ItemNonInventoryProduct.BarCodeValue != null)
                                //                lobjItemdetails.barcodevalue = Convert.ToString(ItemNonInventoryProduct.BarCodeValue.GetValue());
                                //            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                //            {
                                //                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName != null)
                                //                {
                                //                    lobjItemdetails.ExpenseAccountRef = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                //                }
                                //            }

                                //            lobjItemdetails.itemtype = "Non-Inventory Part";
                                //            //Get Custom Field for Assembly Item
                                //            if (ItemNonInventoryProduct.DataExtRetList != null)
                                //            {
                                //                for (int custcol = 0; custcol < ItemNonInventoryProduct.DataExtRetList.Count; custcol++)
                                //                {
                                //                    IDataExtRet DataExtRet = ItemNonInventoryProduct.DataExtRetList.GetAt(custcol);

                                //                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                //                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                //                    lobjItemdetails.CustomItem.Add("_" + strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                //                }
                                //            }

                                //        }
                                //    }

                                //}


                            }
                        }
                    }


                }
               
                return lstInventoryItems;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }



        }

        //Get Purchase Date,Site,Bin Info from Receipt using Item Name for Inventory Report:Date 27-Sept-2019
        public List<clsReportItems> GetReceiptsBillInfo()
        {
            

            List<clsReportItems> objclsreceiptdata = new List<clsReportItems>();
            

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            ArrayList lobjarr = new ArrayList();

            string lstrErrMsg = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;

            string strRefNumber = string.Empty;
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IBillQuery BillQuery = default(IBillQuery);


                BillQuery = lMsgRequest.AppendBillQueryRq();


                //BillQuery.OwnerIDList.Add("0"); //to show all fields
                // BillQuery.IncludeLinkedTxns.SetValue(true);
                BillQuery.IncludeLineItems.SetValue(true);

                //BillQuery.ORBillQuery.BillFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.DateMacro.SetValue(ENDateMacro.dmAll);
                BillQuery.ORBillQuery.BillFilter.AccountFilter.ORAccountFilter.FullNameWithChildren.SetValue("20100 · DUE TO PARENTS AND AFFILIATE:20101 · SHIMA SEIKI MFG:20102 · MACHINE");
                //BillQuery.ORBillQuery.BillFilter.AccountFilter.ORAccountFilter.FullNameList.Add("20102 · MACHINE");

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    IBillRetList loList = (IBillRetList)loResponse.Detail;
                    IBillRet loBillReceipt = default(IBillRet);


                    if (loList != null)
                    {

                        string ponumber = string.Empty;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loBillReceipt = loList.GetAt(Index);


                            if (loBillReceipt.ORItemLineRetList != null)
                            {

                                for (int Itemlist = 0; Itemlist < loBillReceipt.ORItemLineRetList.Count; Itemlist++)
                                {
                                    IORItemLineRet ORItemLineRet = loBillReceipt.ORItemLineRetList.GetAt(Itemlist);
                                    clsReportItems objPOLine = null; // new clsPurchaseOrderLine();
                                    if (ORItemLineRet.ItemLineRet != null)
                                    {


                                        if (ORItemLineRet.ItemLineRet.ItemRef != null)
                                        {
                                            if (ORItemLineRet.ItemLineRet.ItemRef.FullName != null)
                                            {
                                                objPOLine = new clsReportItems();
                                                //get both sub and main item and combine item 
                                                //objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());

                                                //objPOLine.SubItemOf = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                // objPOLine.purchaseordercombineItem = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());

                                                // objPOLine.BarCodeValue = GetItemsBarCode(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()));
                                                //  objPOLine.VendorRefFullName = loBillReceipt.VendorRef.FullName.GetValue().ToString();
                                                // objPOLine.TxnLineID = ORItemLineRet.ItemLineRet.TxnLineID.GetValue();

                                                //Get Item name receipt with bill
                                                // if (pstrItemName.ToLower().Trim() == Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()).ToLower().Trim())
                                                // {

                                                objPOLine.ReceiptptItemName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());

                                                if (ORItemLineRet.ItemLineRet.Quantity != null)
                                                {
                                                    objPOLine.ReceiptQuantity = Convert.ToDouble(ORItemLineRet.ItemLineRet.Quantity.GetValue());


                                                }
                                                if (ORItemLineRet.ItemLineRet.Cost != null)
                                                {
                                                    objPOLine.ReceiptCost = Convert.ToDecimal(ORItemLineRet.ItemLineRet.Cost.GetValue());


                                                }
                                                //Calculate Total Cost from receipt: Date 04/11/2019
                                               
                                                objPOLine.TotalCost = Convert.ToDecimal(objPOLine.ReceiptQuantity) * Convert.ToDecimal(objPOLine.ReceiptCost);

                                                if (ORItemLineRet.ItemLineRet.Desc != null)
                                                {
                                                    objPOLine.ReceiptLineDesc = Convert.ToString(ORItemLineRet.ItemLineRet.Desc.GetValue());

                                                }
                                                if (ORItemLineRet.ItemLineRet.InventorySiteRef != null)
                                                {
                                                    if (ORItemLineRet.ItemLineRet.InventorySiteRef.FullName != null)
                                                    {
                                                        objPOLine.Site = Convert.ToString(ORItemLineRet.ItemLineRet.InventorySiteRef.FullName.GetValue());
                                                    }

                                                }
                                                if (ORItemLineRet.ItemLineRet.InventorySiteLocationRef != null)
                                                {
                                                    if (ORItemLineRet.ItemLineRet.InventorySiteLocationRef.FullName != null)
                                                    {
                                                        objPOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(ORItemLineRet.ItemLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                    }

                                                }

                                                //LotNumber printing for receipt
                                                if (ORItemLineRet.ItemLineRet.ORSerialLotNumber != null)
                                                {

                                                    if (ORItemLineRet.ItemLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objPOLine.LotNo = Convert.ToString(ORItemLineRet.ItemLineRet.ORSerialLotNumber.LotNumber.GetValue());

                                                    }
                                                }

                                                //SerialNo printing for receipt
                                                if (ORItemLineRet.ItemLineRet.ORSerialLotNumber != null)
                                                {

                                                    if (ORItemLineRet.ItemLineRet.ORSerialLotNumber.SerialNumber != null)
                                                    {
                                                        objPOLine.ReceiptSerialNumber = Convert.ToString(ORItemLineRet.ItemLineRet.ORSerialLotNumber.SerialNumber.GetValue());

                                                    }
                                                }

                                                if (loBillReceipt.TimeCreated != null)
                                                {
                                                    objPOLine.ReceiptPurchaseDate = Convert.ToString(loBillReceipt.TxnDate.GetValue());


                                                }

                                                objPOLine.VendorRefFullName = loBillReceipt.VendorRef.FullName.GetValue().ToString();
                                                objPOLine.TxnLineID = ORItemLineRet.ItemLineRet.TxnLineID.GetValue();
                                               // objPOLine.TransID = loBillReceipt.TxnNumber.GetValue();
                                                objclsreceiptdata.Add(objPOLine);

                                                // } //end of item name compare


                                            }

                                        }


                                        //Custom fields for Item Receipt
                                        //if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                        //{
                                        //    for (int j = 0; j < ORItemLineRet.ItemLineRet.DataExtRetList.Count; j++)
                                        //    {
                                        //        IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(j);
                                        //        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                        //        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                        //        objreceiptcustomvalues.Add(new ReceiptItemCustomValues(objPOLine.TxnLineID, strdName, strdValue));

                                        //    }
                                        //}


                                    }
                                    //objclspurchaseorder.Add(objPOLine);


                                }

                            }


                        }
                    }


                }
                // pobjItemExtensions = objreceiptcustomvalues;
                return objclsreceiptdata;
            }
            catch (Exception Ex)
            {
                throw;
                return null;
            }
            finally
            {
                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }

            }
        }

        


    }

    public class InventoryMachineCategory
    {

        // public string lstrMachineParentType = string.Empty;
        // public string lstrParentSubCategory1 = string.Empty;
        //  public string lstrParentSubCategory2 = string.Empty;
        // int lntInventoryQuantity = 0;
        // int lntParentCategoryTotal = 0;


        public string ParentMachineType
        {
            get; set;
        }




        public string ParentSubCategory1
        {

            get;
            set;

        }
        public string ParentSubCategory2
        {

            get;
            set;

        }
        public int InventoryQuantityOnHand
        {
            get;
            set;

        }
        public decimal InventoryUnitcostTotal
        {
            get;
            set;

        }
        public decimal InventoryTotalCost
        {
            get;
            set;

        }
        public decimal InvTotalPurchaseCost
        {
            get;
            set;
        }
        public int ParentsCategoryTotal
        {
            get;
            set;
        }

        public InventoryMachineCategory(string pstrMachineParentType, string pstrParentSubCategory1, string pstrParentSubCategory2, int lntInventoryQuantity,decimal lntUnitCostTotal, decimal decTotalPurchaseCost,decimal lntInventoyTotalCost, int lntParentCategoryTotal)
        {
            ParentMachineType = pstrMachineParentType;
            ParentSubCategory1 = pstrParentSubCategory1;
            ParentSubCategory2 = pstrParentSubCategory2;
            InventoryQuantityOnHand = lntInventoryQuantity;
            InventoryUnitcostTotal = lntUnitCostTotal;
            InvTotalPurchaseCost = decTotalPurchaseCost;
            InventoryTotalCost = lntInventoyTotalCost;
            ParentsCategoryTotal = lntParentCategoryTotal;
        }



    }

    public class InventoryColumnsTotal
    {

        public int MachineCountStatusTotal { get; set; }
        public decimal LastUnitCostColumnTotal { get; set; }
        public decimal LastPurchaseCostColumnTotal { get; set; }
        public decimal LastTotalCostColumnTotal { get; set; }

        public InventoryColumnsTotal(int pintMachineCountStatusTotal, decimal pdecimalLastUnitCostColumnTotal, decimal pdecimalLastPurchaseCostColumnTotal,decimal pdecimalLastTotalCostColumnTotal)
        {
            MachineCountStatusTotal = pintMachineCountStatusTotal;
            LastUnitCostColumnTotal = pdecimalLastUnitCostColumnTotal;
            LastPurchaseCostColumnTotal = pdecimalLastPurchaseCostColumnTotal;
            LastTotalCostColumnTotal = pdecimalLastTotalCostColumnTotal;

        }
    }


}
