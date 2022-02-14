using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LabelConnector
{
    class clsItemDetails
    {

        string lstrItemName;
        string lstrFullName;
        string lstrSubItemOf;
        string lstrSalesDescription;
        string lstrSalesPrice;
        string lstrQuantityonSalesorder;
        string lstrQuantityonOrder;
        string lstrQuantityonHand;
        string lstrPurchaseCost;
        string lstrItemweight;
        string lstrAverageCost;
        bool blnvarAvgCost = false;
        bool blnItemwithoutcategory = false;
        string lstrManufacturerPartNumber;
        string reorderpoint;
        string max;
        string lstrUnitOfMeasureSetRef;
        string lstrPurchaseDesc;
        string  lstrIncomeAccountRef;
        string lstrPrefVendorRef;
        string lstrBarCodeValue;
        string lstrCOGSAccountRef;
        string lstrAssetAccountRef;
        string lstrItemType;
        string lstrExpenseAccountRef;
        string lstrsite;
        string lstrbin;
        string lstrqtyonhand;
        string lstrDescription;
        string lstrSize;
        string _strLotNo = string.Empty;
        string _strqtyonlable;
        int lntid;

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
        public string LotNo
        {
            get { return _strLotNo; }
            set { _strLotNo = value; }
        }
        public string qtyonlabel
        {
            get { return _strqtyonlable; }
            set { _strqtyonlable = value; }
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
        public string ReorderPoint
        {
            get
            {
                return reorderpoint;
            }
            set
            {
                reorderpoint = value;
            }

        }


        public string expenseaccountref
        {
            get
            {
                return lstrExpenseAccountRef;
            }
            set {
                lstrExpenseAccountRef = value;
            }
        }
        public string site
        {
            get
            {
                return lstrsite;
            }
            set
            {
                lstrsite = value;
            }
        }
        public string bin
        {
            get
            {
                return lstrbin;
            }
            set
            {
                lstrbin = value;
            }
        }
        public string qtyonhand
        {
            get
            {
                return lstrqtyonhand;
            }
            set
            {
                lstrqtyonhand = value;
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
        public string subitemof
        {
            get
            {
                return lstrSubItemOf;
            }
            set
            {
                lstrSubItemOf = value;
            }
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
            set {lstrDescription=value;}
        
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
        public string Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
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
        public string purchasecost
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

            get {
                return lstrItemweight;
            }
            set{

                lstrItemweight = value;
            }
        }

        public ArrayList GetInventoryItemsDetail()
        {

            ArrayList alProduct = new ArrayList();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US",  Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                //  IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
               // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0

                //for Assembly Item
                IItemInventoryAssemblyQuery AssemblyItemInventoryQueryRq = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
                AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward

                //for Group Item

                IItemGroupQuery GroupItemQueryRq = lMsgRequest.AppendItemGroupQueryRq();
                GroupItemQueryRq.OwnerIDList.Add("0");
                GroupItemQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                
             

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
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);
                                            if (loProduct.Name != null)
                                                lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue());//Get child only
                                            if (loProduct.FullName != null)
                                                lobjItemdetails.FullName = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child
                                            if (loProduct.ParentRef != null)
                                                lobjItemdetails.subitemof = Convert.ToString(loProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (loProduct.SalesDesc != null)
                                                lobjItemdetails.SalesDescription = Convert.ToString(loProduct.SalesDesc.GetValue());
                                            if (loProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(loProduct.SalesPrice.GetValue());
                                            if (loProduct.QuantityOnSalesOrder != null)
                                                lobjItemdetails.quantityonsalesorder = Convert.ToString(loProduct.QuantityOnSalesOrder.GetValue());
                                            if (loProduct.QuantityOnOrder != null)
                                                lobjItemdetails.quantityonorder = Convert.ToString(loProduct.QuantityOnOrder.GetValue());
                                            if (loProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(loProduct.QuantityOnHand.GetValue());
                                            //Get Avg cost and Qty on hand:Date 03-April-2017
                                            if (loProduct.AverageCost != null)
                                            {
                                                lobjItemdetails.averagecost = Convert.ToString(loProduct.AverageCost.GetValue());
                                            }
                                            if (loProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(loProduct.PurchaseCost.GetValue());
                                            //Get Custom Field for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < loProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(custcol);

                                                    switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
                                                    {

                                                        case "weight":
                                                            lobjItemdetails.ItemWeight = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                    ////Get value of OwnerID
                                                    //if (DataExtRet.OwnerID != null)
                                                    //{
                                                    //    string OwnerID211 = (string)DataExtRet.OwnerID.GetValue();
                                                    //}
                                                    ////Get value of DataExtName
                                                    //string DataExtName212 = (string)DataExtRet.DataExtName.GetValue();
                                                    ////Get value of DataExtType
                                                    //ENDataExtType DataExtType213 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    ////Get value of DataExtValue
                                                    //string DataExtValue214 = (string)DataExtRet.DataExtValue.GetValue();
                                                }
                                            }


                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }


                                }
                                else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs) //Supoort of assembly item Date:04-20-2017
                                {

                                    IItemInventoryAssemblyRetList AssemblyloList = (IItemInventoryAssemblyRetList)loResponse.Detail;

                                    IItemInventoryAssemblyRet AssemblyloProduct = default(IItemInventoryAssemblyRet);

                                    if (AssemblyloList != null)
                                    {
                                        for (int Index = 0; Index < AssemblyloList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            AssemblyloProduct = AssemblyloList.GetAt(Index);
                                            if (AssemblyloProduct.Name != null)
                                                lobjItemdetails.Name = Convert.ToString(AssemblyloProduct.Name.GetValue());//Get child only
                                            if (AssemblyloProduct.FullName != null)
                                                lobjItemdetails.FullName = Convert.ToString(AssemblyloProduct.FullName.GetValue()); //Get Parent : child
                                            if (AssemblyloProduct.ParentRef != null)
                                                lobjItemdetails.subitemof = Convert.ToString(AssemblyloProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (AssemblyloProduct.SalesDesc != null)
                                                lobjItemdetails.SalesDescription = Convert.ToString(AssemblyloProduct.SalesDesc.GetValue());
                                            if (AssemblyloProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(AssemblyloProduct.SalesPrice.GetValue());
                                            if (AssemblyloProduct.QuantityOnSalesOrder != null)
                                                lobjItemdetails.quantityonsalesorder = Convert.ToString(AssemblyloProduct.QuantityOnSalesOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnOrder != null)
                                                lobjItemdetails.quantityonorder = Convert.ToString(AssemblyloProduct.QuantityOnOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(AssemblyloProduct.QuantityOnHand.GetValue());
                                            //Get Avg cost and Qty on hand:Date 03-April-2017
                                            if (AssemblyloProduct.AverageCost != null)
                                            {
                                                lobjItemdetails.averagecost = Convert.ToString(AssemblyloProduct.AverageCost.GetValue());
                                            }
                                            if (AssemblyloProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(AssemblyloProduct.PurchaseCost.GetValue());
                                            //Get Custom Field for Inventory Item
                                            if (AssemblyloProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < AssemblyloProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = AssemblyloProduct.DataExtRetList.GetAt(custcol);

                                                    switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
                                                    {

                                                        case "weight":
                                                            lobjItemdetails.ItemWeight = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                            break;

                                                        default:
                                                            break;
                                                    }

                                                }
                                            }


                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }

                                }
                                else if (responseType == ENResponseType.rtItemGroupQueryRs) //support group item :date 06-22-2017
                                {
                                    
                                    IItemGroupRetList GrouploList = (IItemGroupRetList)loResponse.Detail;

                                    IItemGroupRet  GrouploProduct = default(IItemGroupRet);

                                    if (GrouploList != null)
                                    {
                                        for (int Index = 0; Index < GrouploList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            GrouploProduct = GrouploList.GetAt(Index);
                                            if (GrouploProduct.Name != null)
                                            {
                                                lobjItemdetails.Name = Convert.ToString(GrouploProduct.Name.GetValue());
                                                lobjItemdetails.FullName = Convert.ToString(GrouploProduct.Name.GetValue());
                                            }
                                            if (GrouploProduct.ItemDesc != null)
                                                lobjItemdetails.SalesDescription = Convert.ToString(GrouploProduct.ItemDesc.GetValue());

                                              lobjItemdetails.blnAvgCostDisable = true;

                                              //Get Custom Field for Group Item
                                            //if (GrouploProduct.DataExtRetList != null)
                                            //{
                                            //    for (int custcol = 0; custcol < GrouploProduct.DataExtRetList.Count; custcol++)
                                            //    {
                                            //        IDataExtRet DataExtRet = GrouploProduct.DataExtRetList.GetAt(custcol);

                                            //        switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
                                            //        {

                                            //            case "":
                                            //                lobjItemdetails.ItemWeight = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                            //                break;

                                            //            default:
                                            //                break;
                                            //        }

                                            //    }
                                            //}


                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }



                                }


                            }
                        }
                    }



                }
                return alProduct;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }

        }



        public bool CheckQuickBooksConnection()
        {

            bool blnconn = false;
           
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                //lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                 ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asAll); //for qb dll 11.0 onward
                // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0


                lQBSessionManager.OpenConnection("", "Label Connector");
               
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);


            }
            catch (Exception Ex)
            {
                //Could not start QuickBooks
                if (Ex.Message == "Could not start QuickBooks.")
                {
                    MessageBox.Show("Could not start QuickBooks.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Could not start QuickBooks and Unable to check the Access Permissions.\n\nPlease Open the Company file from the QuickBooks Application, then press the 'OK' button to check again, else it will skip continuing.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //blnconn = false;
                    //try
                    //{
                    //    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    //    IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                    //    //lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    //    IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                    //    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asAll); //for qb dll 11.0 onward
                    //                                                                                                                         // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0


                    //    lQBSessionManager.OpenConnection("", "Label Connector");

                    //    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                    //    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                        blnconn = false;
                    //}
                    //catch (Exception)
                    //{
                    //}
                }
                
                //throw;
            }
            finally
            {
                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
            }
            
                if (lMsgResponse != null)
                {
                //if we sent only one request, there is only one response, we'll walk the list for this sample
                //for (int i = 0; i < lMsgResponse.ResponseList.Count; i++)
                //{
                //    IResponse response = lMsgResponse.ResponseList.GetAt(i);
                //    //check the status code of the response, 0=ok, >0 is warning
                //    if (response.StatusCode >= 0)
                //    {

                //    }
                //}

                    if ((lMsgResponse.ResponseList.Count > 0))
                    {
                        blnconn = true;

                    }
                }
                else
                {

                    blnconn = false;
                }
                return blnconn;
            
            
        }

        public string CheckQuickBooksOpenConnection()
        {
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asAll); 
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                if (Ex.Message == "Could not start QuickBooks.")
                {
                    return Ex.Message.ToString();
                }
            }
            finally
            {
                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
            }

            if (lMsgResponse != null)
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    return "Success";
                }
            }
            else
            {
                return "Connection failed";
            }
            return "Connection failed";


        }


        public ArrayList GetInventoryItemsDetail(IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {

            ArrayList alProduct = new ArrayList();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
               // lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                //  IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0

               // lQBSessionManager.OpenConnection("", "Label Connector");
                //lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {
                //if ((lQBSessionManager != null))
                //{
                //    lQBSessionManager.EndSession();
                //    lQBSessionManager.CloseConnection();
                //}
            }
            try
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    // IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IResponseList responseList = lMsgResponse.ResponseList;
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);
                                            if (loProduct.Name != null)
                                                lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue());//Get child only
                                            if (loProduct.FullName != null)
                                                lobjItemdetails.FullName = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child
                                            if (loProduct.ParentRef != null)
                                                lobjItemdetails.subitemof = Convert.ToString(loProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (loProduct.SalesDesc != null)
                                                lobjItemdetails.SalesDescription = Convert.ToString(loProduct.SalesDesc.GetValue());
                                            if (loProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(loProduct.SalesPrice.GetValue());
                                            if (loProduct.QuantityOnSalesOrder != null)
                                                lobjItemdetails.quantityonsalesorder = Convert.ToString(loProduct.QuantityOnSalesOrder.GetValue());
                                            if (loProduct.QuantityOnOrder != null)
                                                lobjItemdetails.quantityonorder = Convert.ToString(loProduct.QuantityOnOrder.GetValue());
                                            if (loProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(loProduct.QuantityOnHand.GetValue());
                                            if (loProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(loProduct.PurchaseCost.GetValue());
                                            //Get Custom Field for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < loProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(custcol);

                                                    switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
                                                    {

                                                        case "weight":
                                                            lobjItemdetails.ItemWeight = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                    ////Get value of OwnerID
                                                    //if (DataExtRet.OwnerID != null)
                                                    //{
                                                    //    string OwnerID211 = (string)DataExtRet.OwnerID.GetValue();
                                                    //}
                                                    ////Get value of DataExtName
                                                    //string DataExtName212 = (string)DataExtRet.DataExtName.GetValue();
                                                    ////Get value of DataExtType
                                                    //ENDataExtType DataExtType213 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    ////Get value of DataExtValue
                                                    //string DataExtValue214 = (string)DataExtRet.DataExtValue.GetValue();
                                                }
                                            }


                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }


                                }


                            }
                        }
                    }



                }
                return alProduct;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }

        }

        //for open mode
        public Dictionary<string,string> GetItemCustomFields(string pstrItemName)
        {
           
           // ArrayList alProduct = new ArrayList();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
              //  IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", 8, 0);
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                    
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
               // ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);



                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                //Set field value for ToName
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);

                

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
                   if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            if (loProduct.FullName != null)
                                                lobjItemdetails.FullName = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child
                                        
                                            
                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);
                                                   
                                                    //Get value of DataExtName
                                                    string InvCustomItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                                  
                                                    //Get value of DataExtValue
                                                    string InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(InvCustomItemName))
                                                        lobjItemExtensions.Add(InvCustomItemName, InvCustomItemValue);
                                                }
                                            }


                                           
                                        }
                                    }


                                }


                            }
                        }
                    }


                }
               
                return lobjItemExtensions;
            }
            catch (Exception ex)
            {
                throw;
               // return null;
            }

        }

        //Is Item Custom field is exist in QuickBooks.Date 13-Dec-2018
        public ArrayList GetAllItemCustomFields()
        {

             ArrayList alProductCustomFields = new ArrayList();
            string CustomNonInvItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string CustomGroupItemName = string.Empty;
            //Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
              
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                //Inventory Items
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                //Non Inventory Items
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                
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
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);
                                            
                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                                     
                                                    if(!alProductCustomFields.Contains(InvCustomItemName))
                                                    {
                                                        alProductCustomFields.Add(InvCustomItemName);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }
                                else if(responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                {
                                    IItemNonInventoryRetList loList = (IItemNonInventoryRetList)loResponse.Detail;

                                    IItemNonInventoryRet loProduct = default(IItemNonInventoryRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);
                                                                                      
                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                     CustomNonInvItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                                    
                                                    if (!alProductCustomFields.Contains(CustomNonInvItemName))
                                                    {
                                                        alProductCustomFields.Add(CustomNonInvItemName);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }
                                else if (responseType == ENResponseType.rtItemGroupQueryRs)
                                {
                                    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                                    IItemGroupRet loProduct = default(IItemGroupRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    CustomGroupItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                                    if (!alProductCustomFields.Contains(CustomGroupItemName))
                                                    {
                                                        alProductCustomFields.Add(CustomGroupItemName);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }

                            }
                        }
                    }


                }

                return alProductCustomFields;
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }

        //Get Item Custom Field for QtyperCase for PO:11-Jan-2019
        public ArrayList GetItemCustomFieldsforPO()
        {

            ArrayList alProductCustomFields = new ArrayList();
            string CustomNonInvItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string CustomGroupItemName = string.Empty;
            //Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                //Inventory Items
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ////Non Inventory Items
                //IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                //ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                //ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

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
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();


                                                    if (!alProductCustomFields.Contains(InvCustomItemName))
                                                    {
                                                        alProductCustomFields.Add(InvCustomItemName);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }
                                //else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                //{
                                //    IItemNonInventoryRetList loList = (IItemNonInventoryRetList)loResponse.Detail;

                                //    IItemNonInventoryRet loProduct = default(IItemNonInventoryRet);

                                //    if (loList != null)
                                //    {
                                //        for (int Index = 0; Index < loList.Count; Index++)
                                //        {
                                //            lobjItemdetails = new clsItemDetails();
                                //            loProduct = loList.GetAt(Index);

                                //            //Get Custom Fields for Inventory Item
                                //            if (loProduct.DataExtRetList != null)
                                //            {
                                //                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                //                {
                                //                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                //                    //Get value of DataExtName
                                //                    CustomNonInvItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                //                    if (!alProductCustomFields.Contains(CustomNonInvItemName))
                                //                    {
                                //                        alProductCustomFields.Add(CustomNonInvItemName);
                                //                    }
                                //                }
                                //            }



                                //        }
                                //    }


                                //}
                                //else if (responseType == ENResponseType.rtItemGroupQueryRs)
                                //{
                                //    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                                //    IItemGroupRet loProduct = default(IItemGroupRet);

                                //    if (loList != null)
                                //    {
                                //        for (int Index = 0; Index < loList.Count; Index++)
                                //        {
                                //            lobjItemdetails = new clsItemDetails();
                                //            loProduct = loList.GetAt(Index);

                                //            //Get Custom Fields for Inventory Item
                                //            if (loProduct.DataExtRetList != null)
                                //            {
                                //                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                //                {
                                //                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                //                    //Get value of DataExtName
                                //                    CustomGroupItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                //                    if (!alProductCustomFields.Contains(CustomGroupItemName))
                                //                    {
                                //                        alProductCustomFields.Add(CustomGroupItemName);
                                //                    }
                                //                }
                                //            }



                                //        }
                                //    }


                                //}

                            }
                        }
                    }


                }

                return alProductCustomFields;
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }

        //Get All custom item field Name with value: Date 13-Dec-2018
        public Dictionary<string, string> GetAllItemCustomFieldsWithNameValue(string pstrItemName)
        {

           // ArrayList alProductCustomFields = new ArrayList();
            string CustomNonInvItemName = string.Empty;
            string CustomInvAssemblyItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string CustomGroupItemName = string.Empty;
            string InvCustomItemValue = string.Empty;
            string GrpCustomItemValue = string.Empty;
            string NonvInvCustomItemValue = string.Empty;
            string InvAssemblyCustomItemValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                //Inventory Items
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
               if (pstrItemName != "")
               {
                    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }

                ////Non Inventory Items
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
                //Service Items
                IItemServiceQuery ItemServiceQueryRq = lMsgRequest.AppendItemServiceQueryRq();
                ItemServiceQueryRq.OwnerIDList.Add("0");
                ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
                //Inventory Assembly Items
                IItemInventoryAssemblyQuery itemInventoryAssemblyQuery  = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                itemInventoryAssemblyQuery.OwnerIDList.Add("0");
                itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
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
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                                    InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (!lobjItemExtensions.ContainsKey(InvCustomItemName))
                                                    {
                                                        lobjItemExtensions.Add(InvCustomItemName, InvCustomItemValue);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }
                                else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                {
                                    IItemNonInventoryRetList loList = (IItemNonInventoryRetList)loResponse.Detail;

                                    IItemNonInventoryRet loProduct = default(IItemNonInventoryRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    CustomNonInvItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                                    NonvInvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(CustomNonInvItemName))
                                                    {
                                                        lobjItemExtensions.Add(CustomNonInvItemName, NonvInvCustomItemValue);
                                                    }
                                                }
                                            }


                                        }
                                    }

                                }
                                else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs)
                                {
                                    IItemInventoryAssemblyRetList loList = (IItemInventoryAssemblyRetList)loResponse.Detail;

                                    IItemInventoryAssemblyRet loProduct = default(IItemInventoryAssemblyRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    CustomInvAssemblyItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                                    InvAssemblyCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(CustomInvAssemblyItemName))
                                                    {
                                                        lobjItemExtensions.Add(CustomInvAssemblyItemName, InvAssemblyCustomItemValue);
                                                    }
                                                }
                                            }


                                        }
                                    }

                                }
                                else if (responseType == ENResponseType.rtItemServiceQueryRs)
                                {
                                    IItemServiceRetList loList = (IItemServiceRetList)loResponse.Detail;

                                    IItemServiceRet loProduct = default(IItemServiceRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    CustomNonInvItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                                    NonvInvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(CustomNonInvItemName))
                                                    {
                                                        lobjItemExtensions.Add(CustomNonInvItemName, NonvInvCustomItemValue);
                                                    }
                                                }
                                            }


                                        }
                                    }

                                }
                                //else if (responseType == ENResponseType.rtItemGroupQueryRs)
                                //{
                                //    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                                //    IItemGroupRet loProduct = default(IItemGroupRet);

                                //    if (loList != null)
                                //    {
                                //        for (int Index = 0; Index < loList.Count; Index++)
                                //        {
                                //            lobjItemdetails = new clsItemDetails();
                                //            loProduct = loList.GetAt(Index);

                                //            //Get Custom Fields for Inventory Item
                                //            if (loProduct.DataExtRetList != null)
                                //            {
                                //                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                //                {
                                //                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                //                    //Get value of DataExtName
                                //                    CustomGroupItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();
                                //                    GrpCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                //                    if (!lobjItemExtensions.ContainsKey(CustomGroupItemName))
                                //                    {
                                //                        lobjItemExtensions.Add(CustomGroupItemName, GrpCustomItemValue);
                                //                    }
                                //                }
                                //            }



                                //        }
                                //    }


                                //}

                            }
                        }
                    }


                }

                return lobjItemExtensions;
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }


        //for close mode
        public Dictionary<string, string> GetItemCustomFields(string pstrItemName, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {

            // ArrayList alProduct = new ArrayList();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
               // lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                //  IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", 8, 0);
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
         
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                // ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);



                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                //Set field value for ToName
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);



               // lQBSessionManager.OpenConnection("", "Label Connector");
              //  lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {
                //if ((lQBSessionManager != null))
                //{
                //    lQBSessionManager.EndSession();
                //    lQBSessionManager.CloseConnection();
                //}
            }
            try
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    // IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IResponseList responseList = lMsgResponse.ResponseList;
                    if (responseList == null) return null;

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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            if (loProduct.FullName != null)
                                                lobjItemdetails.FullName = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child


                                            //Get Custom Fields for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loProduct.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    string InvCustomItemName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                                    //Get value of DataExtValue
                                                    string InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(InvCustomItemName))
                                                        lobjItemExtensions.Add(InvCustomItemName, InvCustomItemValue);
                                                }
                                            }



                                        }
                                    }


                                }


                            }
                        }
                    }


                }

                return lobjItemExtensions;
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }

       
        private void createItemNode(clsItemDetails clsobjItem, XmlTextWriter writer)
        {
           
            writer.WriteStartElement("Item");
            writer.WriteStartElement("itemname"); //1
            writer.WriteString(clsobjItem.itemname.ToString());  //1
            writer.WriteEndElement(); //1
            if(!string.IsNullOrWhiteSpace(clsobjItem.description))
            {
                writer.WriteStartElement("description");
                writer.WriteString(clsobjItem.description.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.salesprice))
            {
                writer.WriteStartElement("salesprice");
                writer.WriteString(clsobjItem.salesprice.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.quantityonsalesorder))
            {
                writer.WriteStartElement("quantityonsalesorder");
                writer.WriteString(clsobjItem.quantityonsalesorder.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.ReorderPoint))
            {
                writer.WriteStartElement("reorderpoint");
                writer.WriteString(clsobjItem.ReorderPoint.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.Max))
            {
                writer.WriteStartElement("max");
                writer.WriteString(clsobjItem.Max.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.quantityonorder))
            {
                writer.WriteStartElement("quantityonorder");
                writer.WriteString(clsobjItem.quantityonorder.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.quantityonhand))
            {
                writer.WriteStartElement("quantityonhand");
                writer.WriteString(clsobjItem.quantityonhand.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.averagecost))
            {
                writer.WriteStartElement("averagecost");
                writer.WriteString(clsobjItem.averagecost.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.unitofmeasuresetref))
            {
                writer.WriteStartElement("unitofmeasuresetref");
                writer.WriteString(clsobjItem.unitofmeasuresetref.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.mpn))
            {
                writer.WriteStartElement("mpn");
                writer.WriteString(clsobjItem.mpn.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.purchasedesc))
            {
                writer.WriteStartElement("purchasedesc");
                writer.WriteString(clsobjItem.purchasedesc.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.purchasecost))
            {
                writer.WriteStartElement("purchasecost");
                writer.WriteString(clsobjItem.purchasecost.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.incomeaccountref))
            {
                writer.WriteStartElement("incomeaccountref");
                writer.WriteString(clsobjItem.incomeaccountref.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.subitemof))
            {
                writer.WriteStartElement("subitemof");
                writer.WriteString(clsobjItem.subitemof.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.prefvendorref))
            {
                writer.WriteStartElement("prefvendorref");
                writer.WriteString(clsobjItem.prefvendorref.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.barcodevalue))
            {
                writer.WriteStartElement("barcodevalue");
                writer.WriteString(clsobjItem.barcodevalue.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.cogsaccountref))
            {
                writer.WriteStartElement("cogsaccountref");
                writer.WriteString(clsobjItem.cogsaccountref.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.assetaccountref))
            {
                writer.WriteStartElement("assetaccountref");
                writer.WriteString(clsobjItem.assetaccountref.ToString());
                writer.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(clsobjItem.itemtype))
            {
                writer.WriteStartElement("itemtype");
                writer.WriteString(clsobjItem.itemtype.ToString());
                writer.WriteEndElement();
            }

            if (clsobjItem.CustomItem.Count > 0)
            {
                //const string SpecialChars = @"<>&\/";
                //write custom field here
                writer.WriteStartElement("CustomItem"); //1
                foreach (KeyValuePair<string, string> dictItem in clsobjItem.CustomItem)
                {
                   
                   writer.WriteElementString(dictItem.Key, dictItem.Value);  //1
                                     
                   
                }
                
                writer.WriteEndElement(); //1
            }


            writer.WriteEndElement();
        
        }

        //Get All Item of type Inventory/Non-Inventory, Assembly.Date 21-Aug-2017
        public ArrayList GetAllQuickBooksItemsDetails()
        {

            ArrayList alProduct = new ArrayList();
            //List<clsItemDetails> empList = new List<clsItemDetails>();

            clsItemDetails lobjItemdetails = null;
            Dictionary<string, string> lobjInventoryItemExtensions = new Dictionary<string, string>();
            string strInventoryCustomerFieldName = string.Empty;
            string strInventoryCustomerFieldValue = string.Empty;

            //write items to xml file: Dae 12-08-2017 
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");
            if (System.IO.File.Exists(strStartupPath + "QuickBookItems.xml"))
            {
                System.IO.File.Delete(strStartupPath + "QuickBookItems.xml");
            }
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(strStartupPath + "QuickBookItems.xml", System.Text.Encoding.UTF8);
            objXmlTextWriter.WriteStartDocument(true);
            objXmlTextWriter.Formatting = Formatting.Indented;
            objXmlTextWriter.Indentation = 2;
            objXmlTextWriter.WriteStartElement("QuickBooks");


            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                //  IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0
                               
                //for Assembly Item
                IItemInventoryAssemblyQuery AssemblyItemInventoryQueryRq = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
                AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward

                //for Non-Inventory Item
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward


                //for Group Item
               // IItemGroupQuery GroupItemQueryRq = lMsgRequest.AppendItemGroupQueryRq();
                //GroupItemQueryRq.OwnerIDList.Add("0");
               // GroupItemQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward


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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            
                                           // if (loProduct.Name != null)
                                            //    lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue());//Get child only
                                            if (loProduct.FullName != null)
                                                lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child
                                            //if (loProduct.ParentRef != null)
                                             //   lobjItemdetails.ParentFullName = Convert.ToString(loProduct.ParentRef.FullName.GetValue()); //Get parent name only
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
                                            if(loProduct.UnitOfMeasureSetRef !=null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(loProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if(loProduct.ManufacturerPartNumber !=null)
                                                lobjItemdetails.mpn = Convert.ToString(loProduct.ManufacturerPartNumber.GetValue());
                                            if(loProduct.PurchaseDesc !=null)
                                                lobjItemdetails.purchasedesc = Convert.ToString(loProduct.PurchaseDesc.GetValue());
                                            if (loProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(loProduct.PurchaseCost.GetValue());
                                            if(loProduct.IncomeAccountRef !=null)
                                                lobjItemdetails.incomeaccountref = Convert.ToString(loProduct.IncomeAccountRef.FullName.GetValue());
                                            if(loProduct.PrefVendorRef !=null)
                                                lobjItemdetails.prefvendorref = Convert.ToString(loProduct.PrefVendorRef.FullName.GetValue());
                                            if(loProduct.BarCodeValue !=null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(loProduct.BarCodeValue.GetValue());
                                            if (loProduct.COGSAccountRef != null)
                                                lobjItemdetails.cogsaccountref = Convert.ToString(loProduct.COGSAccountRef.FullName.GetValue());
                                            if(loProduct.AssetAccountRef !=null)
                                                lobjItemdetails.assetaccountref = Convert.ToString(loProduct.AssetAccountRef.FullName.GetValue());
                                            lobjItemdetails.itemtype = "Inventory Part";
                                        
                                            //Get Custom Field for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < loProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add(strInventoryCustomerFieldName, strInventoryCustomerFieldValue);

                                                              
                                                }
                                            }

                                           // alProduct.Add(loProduct);
                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);

                                            alProduct.Add(lobjItemdetails);
                                           
                                           
                                        }

                                    }


                                }
                                else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs) //Supoort of assembly item Date:04-20-2017
                                {

                                    IItemInventoryAssemblyRetList AssemblyloList = (IItemInventoryAssemblyRetList)loResponse.Detail;

                                    IItemInventoryAssemblyRet AssemblyloProduct = default(IItemInventoryAssemblyRet);

                                    if (AssemblyloList != null)
                                    {
                                        for (int Index = 0; Index < AssemblyloList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            AssemblyloProduct = AssemblyloList.GetAt(Index);
                                           // if (AssemblyloProduct.Name != null)
                                              //  lobjItemdetails.Name = Convert.ToString(AssemblyloProduct.Name.GetValue());//Get child only
                                            if (AssemblyloProduct.FullName != null)
                                                lobjItemdetails.itemname = Convert.ToString(AssemblyloProduct.FullName.GetValue()); //Get Parent : child
                                           // if (AssemblyloProduct.ParentRef != null)
                                            //    lobjItemdetails.ParentFullName = Convert.ToString(AssemblyloProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (AssemblyloProduct.SalesDesc != null)
                                            {
                                               // lobjItemdetails.SalesDescription = Convert.ToString(AssemblyloProduct.SalesDesc.GetValue());
                                                lobjItemdetails.description = Convert.ToString(AssemblyloProduct.SalesDesc.GetValue());
                                            }
                                            if (AssemblyloProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(AssemblyloProduct.SalesPrice.GetValue());
                                            if (AssemblyloProduct.QuantityOnSalesOrder != null)
                                                lobjItemdetails.quantityonsalesorder = Convert.ToString(AssemblyloProduct.QuantityOnSalesOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnOrder != null)
                                                lobjItemdetails.quantityonorder = Convert.ToString(AssemblyloProduct.QuantityOnOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(AssemblyloProduct.QuantityOnHand.GetValue());
                                            //Get Avg cost and Qty on hand:Date 03-April-2017
                                            if (AssemblyloProduct.AverageCost != null)
                                            {
                                                lobjItemdetails.averagecost = Convert.ToString(AssemblyloProduct.AverageCost.GetValue());
                                            }
                                            if (AssemblyloProduct.UnitOfMeasureSetRef != null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(AssemblyloProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if (AssemblyloProduct.ManufacturerPartNumber != null)
                                                lobjItemdetails.mpn = Convert.ToString(AssemblyloProduct.ManufacturerPartNumber.GetValue());
                                            if (AssemblyloProduct.PurchaseDesc != null)
                                                lobjItemdetails.purchasedesc = Convert.ToString(AssemblyloProduct.PurchaseDesc.GetValue());
                                            if (AssemblyloProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(AssemblyloProduct.PurchaseCost.GetValue());
                                            if (AssemblyloProduct.IncomeAccountRef != null)
                                                lobjItemdetails.incomeaccountref = Convert.ToString(AssemblyloProduct.IncomeAccountRef.FullName.GetValue());
                                            if (AssemblyloProduct.PrefVendorRef != null)
                                                lobjItemdetails.prefvendorref = Convert.ToString(AssemblyloProduct.PrefVendorRef.FullName.GetValue());
                                            if (AssemblyloProduct.BarCodeValue != null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(AssemblyloProduct.BarCodeValue.GetValue());
                                            if (AssemblyloProduct.COGSAccountRef != null)
                                                lobjItemdetails.cogsaccountref = Convert.ToString(AssemblyloProduct.COGSAccountRef.FullName.GetValue());
                                            if (AssemblyloProduct.AssetAccountRef != null)
                                                lobjItemdetails.assetaccountref = Convert.ToString(AssemblyloProduct.AssetAccountRef.FullName.GetValue());
                                            lobjItemdetails.itemtype = "Inventory Assembly";
                                               
                                            //Get Custom Field for Assembly Item
                                            if (AssemblyloProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < AssemblyloProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = AssemblyloProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add(strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                }
                                            }

                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }

                                }
                                //else if (responseType == ENResponseType.rtItemGroupQueryRs) //support group item :date 06-22-2017
                                //{

                                //    IItemGroupRetList GrouploList = (IItemGroupRetList)loResponse.Detail;

                                //    IItemGroupRet GrouploProduct = default(IItemGroupRet);

                                //    if (GrouploList != null)
                                //    {
                                //        for (int Index = 0; Index < GrouploList.Count; Index++)
                                //        {
                                //            lobjItemdetails = new clsItemDetails();
                                //            GrouploProduct = GrouploList.GetAt(Index);
                                //            if (GrouploProduct.Name != null)
                                //            {
                                //                lobjItemdetails.Name = Convert.ToString(GrouploProduct.Name.GetValue());
                                //                lobjItemdetails.FullName = Convert.ToString(GrouploProduct.Name.GetValue());
                                //            }
                                //            if (GrouploProduct.ItemDesc != null)
                                //                lobjItemdetails.SalesDescription = Convert.ToString(GrouploProduct.ItemDesc.GetValue());

                                //            lobjItemdetails.blnAvgCostDisable = true;

                                           

                                //            alProduct.Add(lobjItemdetails);
                                //        }
                                //    }



                                //}

                                else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                {

                                    IItemNonInventoryRetList ItemNonInventoryloList = (IItemNonInventoryRetList)loResponse.Detail;

                                    IItemNonInventoryRet ItemNonInventoryProduct = default(IItemNonInventoryRet);

                                    if (ItemNonInventoryloList != null)
                                    {
                                        for (int Index = 0; Index < ItemNonInventoryloList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            ItemNonInventoryProduct = ItemNonInventoryloList.GetAt(Index);

                                           // if (ItemNonInventoryProduct.Name != null)
                                          //      lobjItemdetails.Name = Convert.ToString(ItemNonInventoryProduct.Name.GetValue());//Get child only
                                            if (ItemNonInventoryProduct.FullName != null)
                                                lobjItemdetails.itemname = Convert.ToString(ItemNonInventoryProduct.FullName.GetValue()); //Get Parent : child
                                          //  if (ItemNonInventoryProduct.ParentRef != null)
                                             //   lobjItemdetails.ParentFullName = Convert.ToString(ItemNonInventoryProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc != null)
                                                {
                                                    //lobjItemdetails.SalesDescription = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                                    lobjItemdetails.description = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice != null)
                                                {
                                                    lobjItemdetails.salesprice = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.UnitOfMeasureSetRef != null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(ItemNonInventoryProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if (ItemNonInventoryProduct.ManufacturerPartNumber != null)
                                                lobjItemdetails.mpn = Convert.ToString(ItemNonInventoryProduct.ManufacturerPartNumber.GetValue());
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc != null)
                                                {
                                                    lobjItemdetails.purchasedesc = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase !=null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost != null)
                                                {
                                                    lobjItemdetails.purchasecost = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef != null)
                                                {
                                                    lobjItemdetails.incomeaccountref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef != null)
                                                {
                                                    lobjItemdetails.prefvendorref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef.FullName.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.BarCodeValue != null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(ItemNonInventoryProduct.BarCodeValue.GetValue());
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef != null)
                                                {
                                                    lobjItemdetails.expenseaccountref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                                }
                                            }

                                            lobjItemdetails.itemtype = "Non-Inventory Part";
                                            //Get Custom Field for Assembly Item
                                            if (ItemNonInventoryProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < ItemNonInventoryProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = ItemNonInventoryProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add(strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                }
                                            }
                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            alProduct.Add(lobjItemdetails);
                                        }
                                    }



                                }


                            }
                        }
                    }

                    //close xmlwriter object
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();


                }
                
                return alProduct;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }


        
        }

        public string GetSubItemName(string pstrItemName)
        {

            // ArrayList alProductCustomFields = new ArrayList();
            string CustomNonInvItemName = string.Empty;
            string CustomInvAssemblyItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string CustomGroupItemName = string.Empty;
            string InvCustomItemValue = string.Empty;
            string GrpCustomItemValue = string.Empty;
            string NonvInvCustomItemValue = string.Empty;
            string InvAssemblyCustomItemValue = string.Empty;
            string SubitemofName = string.Empty;


            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                //Inventory Items
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }

                ////Non Inventory Items
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
                //Service Items
                IItemServiceQuery ItemServiceQueryRq = lMsgRequest.AppendItemServiceQueryRq();
                ItemServiceQueryRq.OwnerIDList.Add("0");
                ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    ItemServiceQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
                //Inventory Assembly Items
                IItemInventoryAssemblyQuery itemInventoryAssemblyQuery = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                itemInventoryAssemblyQuery.OwnerIDList.Add("0");
                itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                if (pstrItemName != "")
                {
                    itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                    //Set field value for ToName
                    itemInventoryAssemblyQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                }
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
                    if (responseList == null) return null;

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

                                    IItemInventoryRet losalesInventoryRet = default(IItemInventoryRet);

                                    if (loList != null)
                                    {

                                        losalesInventoryRet = loList.GetAt(0);
                                        if (losalesInventoryRet.ParentRef.FullName != null)
                                            SubitemofName = Convert.ToString(losalesInventoryRet.ParentRef.FullName.GetValue()); //Get parent name only
                                        return SubitemofName;

                                    }


                                }
                                else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                {
                                    IItemNonInventoryRetList loList = (IItemNonInventoryRetList)loResponse.Detail;

                                    IItemNonInventoryRet losalesNonInventoryRet = default(IItemNonInventoryRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            losalesNonInventoryRet = loList.GetAt(Index);

                                            if (losalesNonInventoryRet.ParentRef != null)
                                            {
                                                SubitemofName = Convert.ToString(losalesNonInventoryRet.ParentRef.FullName.GetValue());
                                            }
                                            else
                                            {
                                                SubitemofName = string.Empty;
                                            }

                                        }

                                        //losalesNonInventoryRet = loList.GetAt(0);
                                        //if (losalesNonInventoryRet.BarCodeValue != null)
                                        //    SubitemofName = Convert.ToString(losalesNonInventoryRet.ParentRef.FullName.GetValue()); //Get parent name only
                                        //return SubitemofName;

                                    }

                                }
                                else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs)
                                {
                                    IItemInventoryAssemblyRetList loList = (IItemInventoryAssemblyRetList)loResponse.Detail;

                                    IItemInventoryAssemblyRet losalesInventoryRet = default(IItemInventoryAssemblyRet);

                                    if (loList != null)
                                    {

                                        losalesInventoryRet = loList.GetAt(0);
                                        if (losalesInventoryRet.ParentRef.FullName != null)
                                            SubitemofName = Convert.ToString(losalesInventoryRet.ParentRef.FullName.GetValue()); //Get parent name only
                                        return SubitemofName;

                                    }

                                }
                                else if (responseType == ENResponseType.rtItemServiceQueryRs)
                                {
                                    IItemServiceRetList loList = (IItemServiceRetList)loResponse.Detail;

                                    IItemServiceRet losalesServiceRet = default(IItemServiceRet);

                                    if (loList != null)
                                    {

                                        losalesServiceRet = loList.GetAt(0);
                                        if (losalesServiceRet.ParentRef.FullName != null)
                                            SubitemofName = Convert.ToString(losalesServiceRet.ParentRef.FullName.GetValue()); //Get parent name only
                                        return SubitemofName;

                                    }

                                }

                            }
                        }
                    }


                }
                return SubitemofName;

            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }

        //Write Inventory,Non-Inventory,Assembly Item to xml file : Date 13-Sept-2017
        public string WriteQuickBookItemToXml(string pstrApplicationPath,bool InvItemCheck,bool AssemblyItemCheck,bool NonInvItemCheck, bool GroupItemCheck)
        {
            //string lstrLastDownloadPath = string.Empty;
            string lstrProductDownloadcount = string.Empty;
            int lproductcount = 0;
            

            clsItemDetails lobjItemdetails = null;
            Dictionary<string, string> lobjInventoryItemExtensions = new Dictionary<string, string>();
            string strInventoryCustomerFieldName = string.Empty;
            string strInventoryCustomerFieldValue = string.Empty;

            
            //write items to xml file: Dae 13-08-2017 
           
            if (System.IO.File.Exists(pstrApplicationPath))
            {
                
                    System.IO.File.Delete(pstrApplicationPath);
                
            }
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(pstrApplicationPath, System.Text.Encoding.UTF8);
            objXmlTextWriter.WriteStartDocument(true);
            objXmlTextWriter.Formatting = Formatting.Indented;
            objXmlTextWriter.Indentation = 2;
            objXmlTextWriter.WriteStartElement("QuickBooks");

           
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                //for Inventory Item
                if (InvItemCheck == true)
                {
                    IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                    ItemInventoryQueryRq.OwnerIDList.Add("0");
                    //  IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                    ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                    // ItemInventoryQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 10.0
                    

                }

                //for Assembly Item
                if (AssemblyItemCheck == true)
                {
                    IItemInventoryAssemblyQuery AssemblyItemInventoryQueryRq = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                    AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
                    AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); 
                }

                //for Non-Inventory Item
                if (NonInvItemCheck == true)
                {
                    IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                    ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                    ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                }

                //for Group Item
                if (GroupItemCheck == true)
                {
                    IItemGroupQuery GroupItemQueryRq = lMsgRequest.AppendItemGroupQueryRq();
                    GroupItemQueryRq.OwnerIDList.Add("0");
                    GroupItemQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                }

                //for Group Item
                // IItemGroupQuery GroupItemQueryRq = lMsgRequest.AppendItemGroupQueryRq();
                //GroupItemQueryRq.OwnerIDList.Add("0");
                // GroupItemQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward


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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            // if (loProduct.Name != null)
                                            //    lobjItemdetails.Name = Convert.ToString(loProduct.Name.GetValue());//Get child only
                                            if (loProduct.FullName != null)
                                                //lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child - commented by srinivas on 28-Sep-2017
                                                lobjItemdetails.itemname = Convert.ToString(loProduct.Name.GetValue()); //Get child
                                            if (loProduct.ParentRef != null)
                                               lobjItemdetails.subitemof = Convert.ToString(loProduct.ParentRef.FullName.GetValue()); //Get parent name only
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
                                            if (loProduct.UnitOfMeasureSetRef != null && loProduct.UnitOfMeasureSetRef.FullName !=null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(loProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if (loProduct.ManufacturerPartNumber != null)
                                                lobjItemdetails.mpn = Convert.ToString(loProduct.ManufacturerPartNumber.GetValue());
                                            if (loProduct.ReorderPoint != null)
                                                lobjItemdetails.ReorderPoint = Convert.ToString(loProduct.ReorderPoint.GetValue());
                                            if (loProduct.Max != null)
                                                lobjItemdetails.Max = Convert.ToString(loProduct.Max.GetValue());
                                            if (loProduct.PurchaseDesc != null)
                                                lobjItemdetails.purchasedesc = Convert.ToString(loProduct.PurchaseDesc.GetValue());
                                            if (loProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(loProduct.PurchaseCost.GetValue());
                                            if (loProduct.IncomeAccountRef != null)
                                                lobjItemdetails.incomeaccountref = Convert.ToString(loProduct.IncomeAccountRef.FullName.GetValue());
                                            if (loProduct.PrefVendorRef != null && loProduct.PrefVendorRef.FullName !=null) //FullName not null check added
                                                lobjItemdetails.prefvendorref = Convert.ToString(loProduct.PrefVendorRef.FullName.GetValue());
                                            if (loProduct.BarCodeValue != null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(loProduct.BarCodeValue.GetValue());
                                            if (loProduct.COGSAccountRef != null && loProduct.COGSAccountRef.FullName !=null)
                                                lobjItemdetails.cogsaccountref = Convert.ToString(loProduct.COGSAccountRef.FullName.GetValue());
                                            if (loProduct.AssetAccountRef != null && loProduct.AssetAccountRef.FullName !=null)
                                                lobjItemdetails.assetaccountref = Convert.ToString(loProduct.AssetAccountRef.FullName.GetValue());
                                            lobjItemdetails.itemtype = "Inventory Part";

                                            //Get Custom Field for Inventory Item
                                            if (loProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < loProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = loProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldName = Regex.Replace(RemoveSpecialCharacters(strInventoryCustomerFieldName.ToString()), @"\s+", "").Replace("/", "");
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add("_" + strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                }
                                            }

                                            
                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            
                                            lproductcount++;
                                        }

                                    }


                                }
                                else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs) //Supoort of assembly item Date:04-20-2017
                                {

                                    IItemInventoryAssemblyRetList AssemblyloList = (IItemInventoryAssemblyRetList)loResponse.Detail;

                                    IItemInventoryAssemblyRet AssemblyloProduct = default(IItemInventoryAssemblyRet);

                                    if (AssemblyloList != null)
                                    {
                                        for (int Index = 0; Index < AssemblyloList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            AssemblyloProduct = AssemblyloList.GetAt(Index);
                                            // if (AssemblyloProduct.Name != null)
                                            //  lobjItemdetails.Name = Convert.ToString(AssemblyloProduct.Name.GetValue());//Get child only
                                            if (AssemblyloProduct.FullName != null)
                                                //lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child - commented by srinivas on 28-Sep-2017
                                                lobjItemdetails.itemname = Convert.ToString(AssemblyloProduct.Name.GetValue()); //Get child
                                             if (AssemblyloProduct.ParentRef != null)
                                               lobjItemdetails.subitemof = Convert.ToString(AssemblyloProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (AssemblyloProduct.SalesDesc != null)
                                            {
                                                // lobjItemdetails.SalesDescription = Convert.ToString(AssemblyloProduct.SalesDesc.GetValue());
                                                lobjItemdetails.description = Convert.ToString(AssemblyloProduct.SalesDesc.GetValue());
                                            }
                                            if (AssemblyloProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(AssemblyloProduct.SalesPrice.GetValue());
                                            if (AssemblyloProduct.QuantityOnSalesOrder != null)
                                                lobjItemdetails.quantityonsalesorder = Convert.ToString(AssemblyloProduct.QuantityOnSalesOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnOrder != null)
                                                lobjItemdetails.quantityonorder = Convert.ToString(AssemblyloProduct.QuantityOnOrder.GetValue());
                                            if (AssemblyloProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(AssemblyloProduct.QuantityOnHand.GetValue());
                                            //Get Avg cost and Qty on hand:Date 03-April-2017
                                            if (AssemblyloProduct.AverageCost != null)
                                            {
                                                lobjItemdetails.averagecost = Convert.ToString(AssemblyloProduct.AverageCost.GetValue());
                                            }                                            
                                            if (AssemblyloProduct.UnitOfMeasureSetRef != null && AssemblyloProduct.UnitOfMeasureSetRef.FullName !=null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(AssemblyloProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if (AssemblyloProduct.ManufacturerPartNumber != null)
                                                lobjItemdetails.mpn = Convert.ToString(AssemblyloProduct.ManufacturerPartNumber.GetValue());
                                            if (AssemblyloProduct.PurchaseDesc != null)
                                                lobjItemdetails.purchasedesc = Convert.ToString(AssemblyloProduct.PurchaseDesc.GetValue());
                                            if (AssemblyloProduct.PurchaseCost != null)
                                                lobjItemdetails.purchasecost = Convert.ToString(AssemblyloProduct.PurchaseCost.GetValue());
                                            if (AssemblyloProduct.IncomeAccountRef != null && AssemblyloProduct.IncomeAccountRef.FullName !=null)
                                                lobjItemdetails.incomeaccountref = Convert.ToString(AssemblyloProduct.IncomeAccountRef.FullName.GetValue());
                                            if (AssemblyloProduct.PrefVendorRef != null && AssemblyloProduct.PrefVendorRef.FullName != null)
                                                lobjItemdetails.prefvendorref = Convert.ToString(AssemblyloProduct.PrefVendorRef.FullName.GetValue());
                                            if (AssemblyloProduct.BarCodeValue != null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(AssemblyloProduct.BarCodeValue.GetValue());
                                            if (AssemblyloProduct.COGSAccountRef != null && AssemblyloProduct.COGSAccountRef.FullName !=null)
                                                lobjItemdetails.cogsaccountref = Convert.ToString(AssemblyloProduct.COGSAccountRef.FullName.GetValue());
                                            if (AssemblyloProduct.AssetAccountRef != null && AssemblyloProduct.AssetAccountRef.FullName !=null)
                                                lobjItemdetails.assetaccountref = Convert.ToString(AssemblyloProduct.AssetAccountRef.FullName.GetValue());
                                            lobjItemdetails.itemtype = "Inventory Assembly";

                                            //Get Custom Field for Assembly Item
                                            if (AssemblyloProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < AssemblyloProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = AssemblyloProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldName = Regex.Replace(RemoveSpecialCharacters(strInventoryCustomerFieldName.ToString()), @"\s+", "").Replace("/", "");
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add("_" + strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                }
                                            }

                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            lproductcount++;
                                        }
                                    }

                                }
                                else if (responseType == ENResponseType.rtItemGroupQueryRs) //support group item :date 09-10-2017
                                {

                                    IItemGroupRetList GrouploList = (IItemGroupRetList)loResponse.Detail;

                                    IItemGroupRet GrouploProduct = default(IItemGroupRet);

                                    if (GrouploList != null)
                                    {
                                        for (int Index = 0; Index < GrouploList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            GrouploProduct = GrouploList.GetAt(Index);
                                            if (GrouploProduct.Name != null)
                                            {
                                                lobjItemdetails.itemname = Convert.ToString(GrouploProduct.Name.GetValue());
                                            }
                                            if (GrouploProduct.ItemDesc != null)
                                                lobjItemdetails.description = Convert.ToString(GrouploProduct.ItemDesc.GetValue());

                                            lobjItemdetails.itemtype = "Group";
                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            lproductcount++;
                                        }
                                    }



                                }

                                else if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                                {

                                    IItemNonInventoryRetList ItemNonInventoryloList = (IItemNonInventoryRetList)loResponse.Detail;

                                    IItemNonInventoryRet ItemNonInventoryProduct = default(IItemNonInventoryRet);

                                    if (ItemNonInventoryloList != null)
                                    {
                                        for (int Index = 0; Index < ItemNonInventoryloList.Count; Index++)
                                        {
                                            lobjItemdetails = new clsItemDetails();
                                            ItemNonInventoryProduct = ItemNonInventoryloList.GetAt(Index);

                                            // if (ItemNonInventoryProduct.Name != null)
                                            //      lobjItemdetails.Name = Convert.ToString(ItemNonInventoryProduct.Name.GetValue());//Get child only
                                            if (ItemNonInventoryProduct.FullName != null)
                                                //lobjItemdetails.itemname = Convert.ToString(loProduct.FullName.GetValue()); //Get Parent : child - commented by srinivas on 28-Sep-2017
                                                lobjItemdetails.itemname = Convert.ToString(ItemNonInventoryProduct.Name.GetValue()); //Get child
                                              if (ItemNonInventoryProduct.ParentRef != null)
                                               lobjItemdetails.subitemof = Convert.ToString(ItemNonInventoryProduct.ParentRef.FullName.GetValue()); //Get parent name only
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc != null)
                                                {
                                                    //lobjItemdetails.SalesDescription = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                                    lobjItemdetails.description = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice != null)
                                                {
                                                    lobjItemdetails.salesprice = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.SalesPrice.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.UnitOfMeasureSetRef != null && ItemNonInventoryProduct.UnitOfMeasureSetRef.FullName !=null)
                                                lobjItemdetails.unitofmeasuresetref = Convert.ToString(ItemNonInventoryProduct.UnitOfMeasureSetRef.FullName.GetValue());

                                            if (ItemNonInventoryProduct.ManufacturerPartNumber != null)
                                                lobjItemdetails.mpn = Convert.ToString(ItemNonInventoryProduct.ManufacturerPartNumber.GetValue());
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc != null)
                                                {
                                                    lobjItemdetails.purchasedesc = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseDesc.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost != null)
                                                {
                                                    lobjItemdetails.purchasecost = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName !=null)
                                                {
                                                    lobjItemdetails.incomeaccountref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef.FullName !=null) //Fullname not null check added
                                                {
                                                    lobjItemdetails.prefvendorref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PrefVendorRef.FullName.GetValue());
                                                }
                                            }
                                            if (ItemNonInventoryProduct.BarCodeValue != null)
                                                lobjItemdetails.barcodevalue = Convert.ToString(ItemNonInventoryProduct.BarCodeValue.GetValue());
                                            if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef != null && ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName !=null)
                                                {
                                                    lobjItemdetails.expenseaccountref = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.GetValue());
                                                }
                                            }

                                            lobjItemdetails.itemtype = "Non-Inventory Part";
                                            //Get Custom Field for Assembly Item
                                            if (ItemNonInventoryProduct.DataExtRetList != null)
                                            {
                                                for (int custcol = 0; custcol < ItemNonInventoryProduct.DataExtRetList.Count; custcol++)
                                                {
                                                    IDataExtRet DataExtRet = ItemNonInventoryProduct.DataExtRetList.GetAt(custcol);

                                                    strInventoryCustomerFieldName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                                    strInventoryCustomerFieldName = Regex.Replace(RemoveSpecialCharacters(strInventoryCustomerFieldName.ToString()), @"\s+", "").Replace("/", "");
                                                    strInventoryCustomerFieldValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    lobjItemdetails.CustomItem.Add("_" + strInventoryCustomerFieldName, strInventoryCustomerFieldValue);


                                                }
                                            }
                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            lproductcount++;
                                        }
                                    }



                                }


                            }
                        }
                    }

                    //close xmlwriter object
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();


                }
                lstrProductDownloadcount = Convert.ToString(lproductcount);
                return lstrProductDownloadcount;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }


        
        }

        public string WriteQuickBookNwnItemToXml(string pstrApplicationPath)
        {
           
            string lstrProductDownloadcount = string.Empty;
            int lproductcount = 0;


            clsItemDetails lobjItemdetails = null;
            Dictionary<string, string> lobjInventoryItemExtensions = new Dictionary<string, string>();
            string strInventoryCustomerFieldName = string.Empty;
            string strInventoryCustomerFieldValue = string.Empty;


            //write items to xml file: Dae 13-08-2017 

            if (System.IO.File.Exists(pstrApplicationPath))
            {

                System.IO.File.Delete(pstrApplicationPath);

            }
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(pstrApplicationPath, System.Text.Encoding.UTF8);
            objXmlTextWriter.WriteStartDocument(true);
            objXmlTextWriter.Formatting = Formatting.Indented;
            objXmlTextWriter.Indentation = 2;
            objXmlTextWriter.WriteStartElement("QuickBooks");


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
                                            lobjItemdetails = new clsItemDetails();
                                            loProduct = loList.GetAt(Index);

                                            //Get items where Qty on hand > 0
                                            if (Convert.ToDouble(loProduct.QuantityOnHand.GetValue()) > 0)
                                            { 

                                                if (loProduct.FullName != null)
                                                    lobjItemdetails.itemname = Convert.ToString(loProduct.Name.GetValue()); //Get child
                                            if (loProduct.SalesDesc != null)
                                            {

                                                lobjItemdetails.description = Convert.ToString(loProduct.SalesDesc.GetValue());
                                            }

                                            if (loProduct.SalesPrice != null)
                                                lobjItemdetails.salesprice = Convert.ToString(loProduct.SalesPrice.GetValue());

                                            if (loProduct.QuantityOnHand != null)
                                                lobjItemdetails.quantityonhand = Convert.ToString(loProduct.QuantityOnHand.GetValue());

                                                //Get Qty on Sales Order : 05-Oct-2018
                                            if (loProduct.QuantityOnSalesOrder != null)
                                                {
                                                    lobjItemdetails.quantityonsalesorder = Convert.ToString(loProduct.QuantityOnSalesOrder.GetValue());
                                                }
                                                //Get Avg cost and Qty on hand:Date 03-April-2017

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


                                            //Insert single Item to xml textwriter object
                                            createItemNode(lobjItemdetails, objXmlTextWriter);
                                            lproductcount++;
                                        }
                                        }

                                    }


                                }
                         
                        
                            }
                        }
                    }

                    //close xmlwriter object
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();


                }
                lstrProductDownloadcount = Convert.ToString(lproductcount);
                return lstrProductDownloadcount;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }



        }


        public enum PlantCategories
        {
           
            BAMB,
            FERN,
            FRUIT,
            Grass,
            Heath

        };

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }




    }
}
