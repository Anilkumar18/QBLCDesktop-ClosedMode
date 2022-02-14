using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Windows.Forms;
using LabelConnector;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;

namespace QBLC
{
    class clsPurchaseOrderLine
    {
        double _dblPurchaseOrderLineQuantity;
        string _strPurchaseOrderLineUnitOfMeasure;
        string _strPurchaseOrderLineItemRefFullName;
        string _strPurchaseOrderLineDesc;
        string _strPurchaseOrderLineTxnLineID;
        string _strRefNumber;
        string _dtTxnDate;
        string _strVendorRefFullName;
        string _strPOCustomer;
        string _strBarCodeValue;
        string _strSalesDesc;
        string _strSalesPrice;
        string _strPurchaseOrderLoc;
        string _strPurchaseOrderBin;
        string _strCreatedTime;
        string _strPoNumber;
        string _strPurchaseOrderSN;
        string _strPurchaseOrderLocation;
        string _strpurchaseOrderDate;
        int _intrecount = 0;
        int _intcalcount;
        double _dblPurchaseOrderLineQtytoPrint;
        double _dblPurchaseOrderQty;
        double _intPrintLblQty;
        string _strErrormsg = string.Empty;
        string _strsubItemOf = string.Empty;
        string _strpurchaseordercombineItem = string.Empty;
        string _strCustomerJob=string.Empty;
        string _strQtyOnLabel = string.Empty;
        string _strSerialNumber = string.Empty;
        string _strOther1;
        string lstrQuantityonHand = string.Empty;
        string lstrAverageCost = string.Empty;
        string _strManufacturerPartNumber = string.Empty;
        string _strLotNo = string.Empty;
        string _strMemo = string.Empty;
        string _strOther2 = string.Empty;
        string _strFOB = string.Empty;
        string _lstrStatic = string.Empty;
        string _dblPurchaseOrderLineRate = string.Empty;
        string _dblpoamount = string.Empty;
        int _lntTransID = 0;

        string _lntTxnLineID = string.Empty;
        string _strShipAddressAddr1=string.Empty;
        string _strShipAddressAddr2=string.Empty;
        string _strShipAddressAddr3=string.Empty;
        string _strShipAddressAddr4=string.Empty;
        string _strShipAddressAddr5=string.Empty;
        string _strShipAddressCity=string.Empty;
        string _strShipAddressState=string.Empty;
        string _strShipAddressPostalCode = string.Empty;
        string _strShipAddressAddrPostalCode = string.Empty;
        string _strShipAddressCountry=string.Empty;
        string _strcitystatezip = string.Empty;
        string _strPOCustomerjob = string.Empty;

        public string ShipAddressAddr1
        {
            get
            {
                return _strShipAddressAddr1;
            }
            set
            {
                _strShipAddressAddr1 = value;
            }
        }

        public string ShipAddressAddr2
        {
            get
            {
                return _strShipAddressAddr2;
            }
            set
            {
                _strShipAddressAddr2 = value;
            }
        }

        public string ShipAddressAddr3
        {
            get
            {
                return _strShipAddressAddr3;
            }
            set
            {
                _strShipAddressAddr3 = value;
            }
        }

        public string ShipAddressAddr4
        {
            get
            {
                return _strShipAddressAddr4;
            }
            set
            {
                _strShipAddressAddr4 = value;
            }
        }

        public string ShipAddressAddr5
        {
            get
            {
                return _strShipAddressAddr5;
            }
            set
            {
                _strShipAddressAddr5 = value;
            }
        }


        public string ShipAddressCity
        {
            get
            {
                return _strShipAddressCity;
            }
            set
            {
                _strShipAddressCity = value;
            }
        }
        public string ShipAddressState
        {
            get
            {
                return _strShipAddressState;
            }
            set
            {
                _strShipAddressState = value;
            }
        }
        public string ShipAddressPostalCode
        {
            get
            {
                return _strShipAddressPostalCode;
            }
            set
            {
                _strShipAddressPostalCode = value;
            }
        }
        
                    public string ShipAddressAddrPostalCode
        {
            get
            {
                return _strShipAddressAddrPostalCode;
            }
            set
            {
                _strShipAddressAddrPostalCode = value;
            }
        }
        public string ShipAddressCountry
        {
            get
            {
                return _strShipAddressCountry;
            }
            set
            {
                _strShipAddressCountry = value;
            }
        }
        public string citystatezip
        {
            get
            {
                return _strcitystatezip;
            }
            set
            {
                _strcitystatezip = value;
            }
        }

        public string TxnLineID
        {
            get { return _lntTxnLineID; }
            set { _lntTxnLineID = value; }
        }

        public string POReceivedItemCreatedTime
        {
            get { return _strCreatedTime; }
            set { _strCreatedTime = value; }
        }

        public string PurchaseOrderLineRate
        {
            get
            {
                return _dblPurchaseOrderLineRate;
            }
            set
            {
                _dblPurchaseOrderLineRate = value;
            }
        }
        public string PurchaseOrderLineAmount
        {
            get
            {
                return _dblpoamount;
            }
            set
            {
                _dblpoamount = value;
            }
        }

        public int TransID
        {
            get
            {
                return _lntTransID;
            }
            set
            {
                _lntTransID = value;
            }
        }
        public string QtyOnLabel
        {
            get { return _strQtyOnLabel; }
            set { _strQtyOnLabel = value; }
        }
        public int Calcount
        {
            get { return _intcalcount; }
            set { _intcalcount = value; }
        }

        public string PurchaseOrderLoc
        {
            get { return _strPurchaseOrderLoc;}
            set { _strPurchaseOrderLoc = value; }
        }

        public string ReceiptSerialNumber
        {
            get { return _strSerialNumber; }
            set { _strSerialNumber = value; }
        }
        public string Bin
        {
            get { return _strPurchaseOrderBin; }
            set { _strPurchaseOrderBin = value; }
        }
        public string Entry1
        {
            get { return _strpurchaseOrderDate; }
            set { _strpurchaseOrderDate = value; }
        }
        public double PrintLblQty
        {
            get { return _intPrintLblQty; }
            set { _intPrintLblQty = value; }
        }
        public string Site
        {
            get { return _strPurchaseOrderLocation; }
            set { _strPurchaseOrderLocation = value; }
        }
        public string LotNo
        {
            get { return _strLotNo; }
            set { _strLotNo = value; }
        }

        public string Entry2
        {
            get { return _strPurchaseOrderSN; }
            set { _strPurchaseOrderSN = value; }
        }

        public double PurchaseOrderLineQtytoPrint
        {
            get { return _dblPurchaseOrderLineQtytoPrint; }
            set { _dblPurchaseOrderLineQtytoPrint = value; }
        }
        public double PurchaseOrderQty
        {
            get { return _dblPurchaseOrderQty; }
            set { _dblPurchaseOrderQty = value; }
        }
        public string ErrorMessage
        {

            get { return _strErrormsg; }
            set { _strErrormsg = value; }
        }

        public string BarCodeValue
        {
            get
            {
                return _strBarCodeValue;
            }
            set
            {
                _strBarCodeValue = value;
            }
        }

        public int Reccount
        {
            get { return _intrecount; }
            set { _intrecount = value; }
        
        }


        public string SalesDesc
        {
            get
            {
                return _strSalesDesc;
            }
            set
            {
                _strSalesDesc = value;
            }
        }

        public string SalesPrice
        {
            get
            {
                return _strSalesPrice;
            }
            set
            {
                _strSalesPrice = value;
            }
        }

        public string MPN
        {
            get { return _strManufacturerPartNumber; }
            set { _strManufacturerPartNumber = value; }
        }

        public string AverageCost
        {
            get { return lstrAverageCost; }
            set { lstrAverageCost = value; }
        }
        public string QuantityOnHand
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

        public double RecQty
        {
            get
            {
                return _dblPurchaseOrderLineQuantity;
            }
            set
            {
                _dblPurchaseOrderLineQuantity = value;
            }
        }
        public string PurchaseOrderCustomer
        {
            get
            {
                return _strPOCustomer;
            }
            set
            {
                _strPOCustomer = value;
            }
        }

        
        public string POCustomerJob
        {
            get
            {
                return _strPOCustomerjob;
            }
            set
            {
                _strPOCustomerjob = value;
            }
        }
        public string PurchaseOrderLineUnitOfMeasure
        {
            get
            {
                return _strPurchaseOrderLineUnitOfMeasure;
            }

            set
            {
                _strPurchaseOrderLineUnitOfMeasure = value==null? "": value ;
            }
        }
        public string PurchaseOrderLineItemRefFullName
        {
            get
            {
                return _strPurchaseOrderLineItemRefFullName;
            }
            set
            {
               // _strPurchaseOrderLineItemRefFullName = value;// 25-02-2016
               _strPurchaseOrderLineItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
            }
        }

        public string CustomerJob
        {
            get 
            { 
                return _strCustomerJob;
            }
            set
            {
                _strCustomerJob = value.Substring(value.LastIndexOf(':') + 1);

            }
        }



        public string SubItemOf //get left side of :
        {
            get {
                return _strsubItemOf;
            
            }
            set {
                //_strsubItemOf = value;
                _strsubItemOf = value.IndexOf(':') > -1 ? value.Substring(0, value.IndexOf(':')) : "";
            
            }
        }
        public string purchaseordercombineItem
        {
            get { return _strpurchaseordercombineItem; }
            set { _strpurchaseordercombineItem = value; }
        
        }

        public string Memo
        {
            get { return _strMemo; }
            set { _strMemo = value; }
        }


        public string PurchaseOrderLineDesc
        {
            get
            {
                return _strPurchaseOrderLineDesc;
            }
            set
            {
                _strPurchaseOrderLineDesc = value;
            }
        }
        public string PurchaseOrderLineTxnLineID
        {
            get
            {
                return _strPurchaseOrderLineTxnLineID;
            }
            set
            {
                _strPurchaseOrderLineTxnLineID = value;
            }
        }
        //public string RefNumber
        //{
        //    get
        //    {
        //        return _strRefNumber;
        //    }
        //    set
        //    {
        //        _strRefNumber = value;
        //    }
        //}

        public string RefNumber
        {
            get
            {
                return _strPoNumber;
            }
            set
            {
                _strPoNumber = value;
            }
        }

        public string TxnDate
        {
            get
            {
                return _dtTxnDate;
            }

            set
            {
                _dtTxnDate = value;
            }
        }


        public string Static
        {
            get
            {
                return _lstrStatic;
            }
            set
            {
                _lstrStatic = value;
            }
        }

        public string Other1H
        {

            get { return _strOther1; }
            set { _strOther1 = value; }
        }
        public string Other2
        {

            get { return _strOther2; }
            set { _strOther2 = value; }
        }
        public string FOB
        {

            get { return _strFOB; }
            set { _strFOB = value; }
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

        public class ReceiptItemCustomValues
        {
            string lstrReceiptItemID = string.Empty;
            string lstrReceiptCustomFieldkey = string.Empty;
            string lstrReceiptCustomFieldValue = string.Empty;



            public string ReceiptItemID
            {
                get
                {
                    return lstrReceiptItemID;
                }
                set
                {
                    lstrReceiptItemID = value;
                }
            }


            public string ReceiptCustomFieldkey
            {
                get
                {
                    return lstrReceiptCustomFieldkey;
                }
                set
                {
                    lstrReceiptCustomFieldkey = value;
                }
            }

            public string ReceiptCustomFieldValue
            {
                get
                {
                    return lstrReceiptCustomFieldValue;
                }
                set
                {
                    lstrReceiptCustomFieldValue = value;
                }
            }

          public ReceiptItemCustomValues(string ItemID, string CustomKey, string CustomValue)
            {
                ReceiptItemID = ItemID;
                ReceiptCustomFieldkey = CustomKey;
                ReceiptCustomFieldValue = CustomValue;

            }

        };


        public ArrayList GetPOLine(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alPurchaseOrdersLine = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);

                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();

                PurchaseOrderQuery.IncludeLineItems.SetValue(true);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);
                    IPurchaseOrderLineRetList loPurchaseOrderLine = default(IPurchaseOrderLineRetList);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loPurchaseOrder.ORPurchaseOrderLineRetList.Count; intLine++)
                            {
                                clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();

                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null)
                                {
                                    objPOLine.PrintLblQty = Convert.ToDouble(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue());
                                    objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                }
                                else
                                {
                                    objPOLine.PrintLblQty = 0.00;
                                    objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                }
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure != null)
                                {
                                    objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure.GetValue());
                                }
                                else
                                {
                                    objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                }
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                {
                                    objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                   // objPOLine.PurchaseOrderLineItemRefFullName = clsStringExtension.SubstringAfter(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue()), ":");


                                }
                                else
                                {
                                    objPOLine.PurchaseOrderLineItemRefFullName = "";
                                }
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                {
                                    objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());
                                }
                                else
                                {
                                    objPOLine.PurchaseOrderLineDesc = "";
                                }
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID != null)
                                {
                                    objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());
                                }
                                else
                                {
                                    objPOLine.PurchaseOrderLineTxnLineID = "";
                                }
                                alPurchaseOrdersLine.Add(objPOLine);
                            }
                        }
                    }
                }
                return alPurchaseOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                return null;
            }
            finally
            {
            }
        }

        public ArrayList GetPOLine(string strRefNumber)
        { 
            ArrayList alPurchaseOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            //string lstrQBItemName = string.Empty;
            //ArrayList lobjarr = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            //QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager =null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                if(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    lQBSessionManager = LabelConnector.QBHelper.ConnectQBCloseMode(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                }

                else
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }
              
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
               // IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);

               

                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                PurchaseOrderQuery.OwnerIDList.Add("0"); //to show all fields
                PurchaseOrderQuery.IncludeLinkedTxns.SetValue(true);
               
                PurchaseOrderQuery.IncludeLineItems.SetValue(true);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
           
               
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);
                    IPurchaseOrderLineRetList loPurchaseOrderLine = default(IPurchaseOrderLineRetList);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            //if (loPurchaseOrder.LinkedTxnList != null)
                            //{
                            //    for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                            //    {
                            //        ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);
                                 
                            //        if (LinkedTxn.RefNumber != null)
                            //        {
                            //            string ponumber1 = (string)LinkedTxn.RefNumber.GetValue();
                            //        }
                            //        if (LinkedTxn.TxnDate != null)
                            //        {

                            //            DateTime dtdate = Convert.ToDateTime(LinkedTxn.TxnDate.GetValue());
                                    
                            //        }
                                    
                                   
                            //    }

                            //}
                            for (int intLine = 0; intLine < loPurchaseOrder.ORPurchaseOrderLineRetList.Count; intLine++)
                            {
                                clsPurchaseOrderLine objPOLine = null; // new clsPurchaseOrderLine();
                                //uncomment on 23-sept-2019 to show group type item
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet != null)
                                {
                                    //To not show item when quantity does not exist or zeoro: Date 05/20/2016
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue() != 0 && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                    {
                                        objPOLine = new clsPurchaseOrderLine();
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = "";
                                        }
                                        
                                        OtherChargeQueryRq.OwnerIDList.Add("0");
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objPOLine.PurchaseOrderLineItemRefFullName);
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objPOLine.PurchaseOrderLineItemRefFullName);
                                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                        IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                        IItemOtherChargeRetList loList1 = (IItemOtherChargeRetList)loResponse2.Detail;

                                        if (loList1 == null)
                                        {
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null)
                                            {
                                                objPOLine.PrintLblQty = Convert.ToDouble(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue());
                                                objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                            }
                                            else
                                            {
                                                objPOLine.PrintLblQty = 0.00;
                                                objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                            }
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure != null)
                                            {
                                                objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure.GetValue());
                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                            }
                                            //MPN display in grid :Date 07-Dec-2018
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ManufacturerPartNumber != null)
                                            {
                                                objPOLine.MPN = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ManufacturerPartNumber.GetValue());
                                            }
                                            else
                                            {
                                                objPOLine.MPN = "";
                                            }

                                            var txtID = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue();

                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                            {
                                                objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());

                                                //Get PO subItemOf
                                                objPOLine.SubItemOf = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.purchaseordercombineItem = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());

                                                //objPOLine.PurchaseOrderLineItemRefFullName = clsStringExtension.SubstringAfter(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue()), ":");


                                                ////Get BarCodeValue,Sale Desc,Sales Price for perticular Item
                                                //lstrQBItemName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                                //lobjarr = PoItemDetails(lstrQBItemName);
                                                //if (lobjarr.Count > 0 && lobjarr != null)
                                                //{
                                                //    foreach (clsPurchaseOrderLine item in lobjarr)
                                                //    {
                                                //        objPOLine.BarCodeValue = item.BarCodeValue;
                                                //        objPOLine.SalesDesc = item.SalesDesc;
                                                //        objPOLine.SalesPrice = item.SalesPrice;


                                                //    }
                                                //}

                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineItemRefFullName = "";
                                            }
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                            {
                                                objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());
                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineDesc = "";
                                            }
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID != null)
                                            {
                                                objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());
                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineTxnLineID = "";
                                            }
                                            alPurchaseOrdersLine.Add(objPOLine);
                                        }
                                    }
                                } //purchaseorderlineret end
                                //show group type item for purchase order
                                else if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet != null)
                                {
                                    //To not show item when quantity does not exist or zeoro: Date 05/20/2016
                                   // if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Quantity != null && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Quantity.GetValue() != 0 && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.ItemGroupRef != null)
                                   // {
                                        //PO Group header items
                                        //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.ItemGroupRef.FullName != null)
                                        //{
                                        //    objPOLine.PurchaseOrderLineItemRefFullName = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.ItemGroupRef.FullName.GetValue();

                                        //}
                                        //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Quantity != null)
                                        //{
                                        //    objPOLine.PurchaseOrderLineQuantity = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Quantity.GetValue();

                                        //}
                                        //else
                                        //{
                                        //    objPOLine.PurchaseOrderLineQuantity = 0.00;
                                        //}
                                        //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Desc != null)
                                        //{
                                        //    objPOLine.PurchaseOrderLineDesc = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.Desc.GetValue();

                                        //}
                                        //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.UnitOfMeasure != null)
                                        //{
                                        //    objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.UnitOfMeasure.GetValue());
                                        //}
                                        //else
                                        //{
                                        //    objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                        //}

                                        //PO Group Item Details
                                        //Get Group Item child record--below block required only
                                        //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList != null)
                                        //{

                                        //    for (int grpitem = 0; grpitem < loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList.Count; grpitem++)
                                        //    {
                                        //    objPOLine = new clsPurchaseOrderLine();
                                        //    IPurchaseOrderLineRet PurchaseOrderLineRet = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList.GetAt(grpitem);
                                                
                                        //        if (PurchaseOrderLineRet.ItemRef != null)
                                        //        {
                                        //            if (PurchaseOrderLineRet.ItemRef.FullName != null)
                                        //            {
                                        //                objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                        //            }

                                        //        }
                                        //        if(PurchaseOrderLineRet.Desc !=null)
                                        //        {
                                        //            objPOLine.PurchaseOrderLineDesc = Convert.ToString(PurchaseOrderLineRet.Desc.GetValue());

                                        //        }
                                        //        if (PurchaseOrderLineRet.Quantity != null)
                                        //        {
                                        //            objPOLine.PurchaseOrderLineQuantity = Convert.ToDouble(PurchaseOrderLineRet.Quantity.GetValue());
                                                    
                                        //        }
                                        //        if (PurchaseOrderLineRet.UnitOfMeasure != null)
                                        //        {
                                        //            objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(PurchaseOrderLineRet.UnitOfMeasure.GetValue());

                                        //        }
                                        //        if(PurchaseOrderLineRet.TxnLineID !=null)
                                        //        {
                                        //             objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(PurchaseOrderLineRet.TxnLineID.GetValue());
                                        //        }


                                        //    alPurchaseOrdersLine.Add(objPOLine);
                                        //}
                                        //}

                                 
                                }
                                
                            }
                        }
                    }
                }
                return alPurchaseOrdersLine;
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

        //Date: 11-14-2016
        public List<clsPurchaseOrderLine> GetPOItemReceiptDetails(string strRefNumber, DateTime pstrmindate, DateTime pstrmaxdate, out string pstrErrormessage)
        {
          

            QBHelper.WriteLog("Filter Dates" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + strRefNumber + "MinDate:=>" + pstrmindate + "MaxDate:=>" + pstrmaxdate);
            List<clsPurchaseOrderLine> objclspurchaseorder = new List<clsPurchaseOrderLine>();

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //string strdName = string.Empty;
            //string strdValue = string.Empty;
            ArrayList lobjarr = new ArrayList();

            string lstrErrMsg = string.Empty;
            int statusCode = 0;
            string statusMessage = string.Empty;
            string statusSeverity=string.Empty;
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IItemReceiptQuery ItemReceiptQuery = default(IItemReceiptQuery);
               

                ItemReceiptQuery = lMsgRequest.AppendItemReceiptQueryRq();
                ItemReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                ItemReceiptQuery.IncludeLinkedTxns.SetValue(true);
                ItemReceiptQuery.IncludeLineItems.SetValue(true);

                              


                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(pstrmindate);
                //Set field value for ToTxnDate
                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(pstrmaxdate);

               

                //ItemReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue("90876");
                ////Set field value for ToRefNumber
                //ItemReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue("90876");



                QBHelper.WriteLog("13" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB open connection start....");
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                QBHelper.WriteLog("14" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Dorequest process start....");
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                QBHelper.WriteLog("15" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Dorequest process end....");

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                     statusCode = loResponse.StatusCode;
                     statusMessage = loResponse.StatusMessage;
                     statusSeverity = loResponse.StatusSeverity;
                   // MessageBox.Show("Status:\nCode = " + statusCode + "\nMessage = " + statusMessage + "\nSeverity = " + statusSeverity);
			


                    IItemReceiptRetList loList = (IItemReceiptRetList)loResponse.Detail;
                    IItemReceiptRet loPurchaseOrder = default(IItemReceiptRet);


                    if (loList != null)
                    {
                        QBHelper.WriteLog("16" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "loList contain data....");
                        bool equals = false;
                        string ponumber = string.Empty;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);


                            if (loPurchaseOrder.LinkedTxnList != null)
                            {
                                for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                                {
                                    ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);
                                    equals = strRefNumber.Equals((string)LinkedTxn.RefNumber.GetValue(), StringComparison.OrdinalIgnoreCase);
                                    ponumber = (string)LinkedTxn.RefNumber.GetValue();

                                }


                            }

                            if (equals == true)
                            {
                                QBHelper.WriteLog("17" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Po no data matched with receipt data.");
                                if (loPurchaseOrder.ORItemLineRetList != null)
                                {
                                    QBHelper.WriteLog("18" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "ORItemLineRetList is not null.");
                                    for (int Itemlist = 0; Itemlist < loPurchaseOrder.ORItemLineRetList.Count; Itemlist++)
                                    {
                                        IORItemLineRet ORItemLineRet = loPurchaseOrder.ORItemLineRetList.GetAt(Itemlist);
                                        clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();
                                        if (ORItemLineRet.ItemLineRet != null)
                                        {
                                            if (ORItemLineRet.ItemLineRet != null)
                                            {
                                                if (ORItemLineRet.ItemLineRet.ItemRef != null)
                                                {
                                                    if (ORItemLineRet.ItemLineRet.ItemRef.FullName != null)
                                                    {
                                                        //get both sub and main item and combine item : Date 07-Feb-2017
                                                        objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                        objPOLine.SubItemOf = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                        objPOLine.purchaseordercombineItem = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());

                                                        //Get  CustomerJob from receipt :Aug-2018
                                                        if(ORItemLineRet.ItemLineRet.CustomerRef !=null)
                                                        {
                                                            if(ORItemLineRet.ItemLineRet.CustomerRef.FullName !=null)
                                                            {
                                                                objPOLine.CustomerJob = Convert.ToString(ORItemLineRet.ItemLineRet.CustomerRef.FullName.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objPOLine.CustomerJob = "";
                                                            }

                                                        }
                                                        //get right site part currently active
                                                       // objPOLine.PurchaseOrderLineItemRefFullName = clsStringExtension.SubstringAfter(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()), ":");


                                                        //get parent item as sub item of (from left side)
                                                       //  objPOLine.PurchaseOrderLineItemRefFullName = clsStringExtension.SubstringBefore(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()), ":");

                                                       
                                                        objPOLine.BarCodeValue = GetItemsBarCode(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()));
                                                        QBHelper.WriteLog("25" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Get Bardcodevalue as =>" + objPOLine.BarCodeValue);


                                                    }

                                                }
                                                if (ORItemLineRet.ItemLineRet.Quantity != null)
                                                {
                                                    objPOLine.RecQty = Convert.ToDouble(ORItemLineRet.ItemLineRet.Quantity.GetValue());
                                                    objPOLine.RefNumber = ponumber;
                                                }
                                                if (ORItemLineRet.ItemLineRet.Desc != null)
                                                {
                                                    objPOLine.PurchaseOrderLineDesc = Convert.ToString(ORItemLineRet.ItemLineRet.Desc.GetValue());

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
                                                        //objPOLine.Bin = Regex.Match(Convert.ToString(ORItemLineRet.ItemLineRet.InventorySiteLocationRef.FullName.GetValue()), @":([\w-]+).").Groups[1].Value;
                                                        //  objPOLine.Bin = Convert.ToString(ORItemLineRet.ItemLineRet.InventorySiteLocationRef.FullName.GetValue());
                                                        objPOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(ORItemLineRet.ItemLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");
                                                        QBHelper.WriteLog("26" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Get Bin Value as =>" + objPOLine.Bin);

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

                                                if (loPurchaseOrder.TimeCreated != null)
                                                {
                                                    objPOLine.POReceivedItemCreatedTime = Convert.ToString(loPurchaseOrder.TimeCreated.GetValue());


                                                }

                                            }


                                           
                                        }

                                        //enable  item custom field for item receipt : Date 07-Feb-2017
                                        //lobjarr = PoItemDetails(objPOLine.PurchaseOrderLineItemRefFullName, out lobjCustItemExtensions);


                                        //if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                        //{
                                        //    for (int custfield = 0; custfield < ORItemLineRet.ItemLineRet.DataExtRetList.Count; custfield++)
                                        //    {
                                        //        IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(custfield);
                                        //        if (Convert.ToString(DataExtRet.DataExtName.GetValue()).Trim().ToUpper()=="BIN#")
                                        //        {
                                        //            objPOLine.Bin = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                        //        }
                                        //        if (Convert.ToString(DataExtRet.DataExtName.GetValue()).Trim().ToUpper() == "LOCATION")
                                        //        {
                                        //            objPOLine.Site = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                        //        }

                                        //    }
                                        //}
                                        
                                        ////enable custom field for receipt item : date 30th-jan-2017

                                        //if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                        //{
                                        //    for (int custfield = 0; custfield < ORItemLineRet.ItemLineRet.DataExtRetList.Count; custfield++)
                                        //    {
                                        //        IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(custfield);
                                        //        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty);
                                        //        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                        //        if (!lobjItemExtensions.ContainsKey(strdName))
                                        //            lobjItemExtensions.Add(strdName, strdValue);

                                        //    }
                                        //}
                            
                                        objclspurchaseorder.Add(objPOLine);

                                    }

                                }
                            }//if end
                            else
                            {
                                QBHelper.WriteLog("Error" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Bill item receipt not supported");

                                lstrErrMsg = "Bill item receipt transaction not supported";
                            
                            }


                        }
                    }
                    else
                    {
                        QBHelper.WriteLog("Error" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + statusMessage);

                        lstrErrMsg = statusMessage;

                        
                    }
                    
                }
                pstrErrormessage = lstrErrMsg;
               // pobjItemExtensions = lobjItemExtensions;
                return objclspurchaseorder;
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




        public ArrayList GetPOLine(string strRefNumber, string PurchaseOrderLineTxnLineID, DateTime dtTransactionDate, string strVendorRefFullName,  IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alPurchaseOrdersLine = new ArrayList();
            string strTxnLineID = string.Empty;
            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);

                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();

                PurchaseOrderQuery.IncludeLineItems.SetValue(true);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);
                    //IPurchaseOrderLineRetList loPurchaseOrderLine = default(IPurchaseOrderLineRetList);
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loPurchaseOrder.ORPurchaseOrderLineRetList.Count; intLine++)
                            {
                                clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet == null)
                                {
                                   throw new Exception("Order Containing Group Type of Items are not Supported");
                                }
                                strTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());

                                if (PurchaseOrderLineTxnLineID == strTxnLineID)
                                {
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null)
                                    {
                                        objPOLine.PrintLblQty = Convert.ToDouble(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue());
                                        objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                    }
                                    else
                                    {
                                        objPOLine.PrintLblQty = 0.00;
                                        objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                    }
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure != null)
                                    {
                                        objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure.GetValue());
                                    }
                                    else
                                    {
                                        objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                    }
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                    {
                                       objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                        //objPOLine.PurchaseOrderLineItemRefFullName = clsStringExtension.SubstringAfter(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue()), ":");


                                    }
                                    else
                                    {
                                        objPOLine.PurchaseOrderLineItemRefFullName = "";
                                    }
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                    {
                                        objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());
                                    }
                                    else
                                    {
                                        objPOLine.PurchaseOrderLineDesc = "";
                                    }
                                    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID != null)
                                    {
                                        objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objPOLine.PurchaseOrderLineTxnLineID = "";
                                    }

                                    //Get customer for purchase order
                                    
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                        {

                                            objPOLine.PurchaseOrderCustomer = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderCustomer = "";
                                        }


                                        //Get CustomerJOb for PO : Date 16-Feb-2017
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                        {

                                            objPOLine.CustomerJob = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.CustomerJob = "";
                                        }

                                    

                                    objPOLine.TxnDate = dtTransactionDate.ToShortDateString();
                                    objPOLine.VendorRefFullName = strVendorRefFullName;
                                    objPOLine.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                                    
                                    alPurchaseOrdersLine.Add(objPOLine);
                                }
                            }
                        }
                    }
                }
                return alPurchaseOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                return null;
            }
            finally
            {
            }
        }
        //Get BarcodeValue,SalesDesc and SalesPrice :Date 12-02-2016
        public ArrayList PoItemDetails(string pstrItemName, out Dictionary<string, string> pobjItemExtensions)
        {
            clsPurchaseOrderLine objpoitem = new clsPurchaseOrderLine();
            ArrayList lobjArryItem = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            string strdName = string.Empty;
            string strdValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            clsPurchaseOrderLine objPOLine = null;
            try
            {
                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    lQBSessionManager = LabelConnector.QBHelper.ConnectQBCloseMode(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                }
                else
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }
               
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventory = default(IItemInventoryQuery);
                ItemInventory = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventory.OwnerIDList.Add("0");
               
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
               
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if (lQBSessionManager != null)
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;
                    IItemInventoryRet loItemname = default(IItemInventoryRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            objPOLine = new clsPurchaseOrderLine();
                            loItemname = loList.GetAt(Index);
                            if (loItemname.BarCodeValue != null)
                                objPOLine.BarCodeValue = Convert.ToString(loItemname.BarCodeValue.GetValue());// Get barcode value
                            if (loItemname.SalesDesc != null)
                                objPOLine.SalesDesc = Convert.ToString(loItemname.SalesDesc.GetValue());// Get sales desc value
                            if (loItemname.SalesPrice != null)
                                objPOLine.SalesPrice = Convert.ToString(loItemname.SalesPrice.GetValue());// Get sales price value 
                              //Add support for multi PO Mfr Part Number :Date 16-May-2017
                            if (loItemname.ManufacturerPartNumber != null)
                                objPOLine.MPN = Convert.ToString(loItemname.ManufacturerPartNumber.GetValue());
                            
                            //Get Avg cost & quantity on hand: Date 03-April-2017
                            if (loItemname.AverageCost != null)
                            {
                                objPOLine.AverageCost = Convert.ToString(loItemname.AverageCost.GetValue());// Get average cost
                            }
                            if (loItemname.QuantityOnHand != null)
                            {
                                objPOLine.QuantityOnHand = Convert.ToString(loItemname.QuantityOnHand.GetValue());// Get quantity on hand   

                            }
                            if (loItemname.UnitOfMeasureSetRef != null)
                            {
                                if (loItemname.UnitOfMeasureSetRef.FullName != null)
                                {
                                    objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loItemname.UnitOfMeasureSetRef.FullName.GetValue());
                                        }
                            }


                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);
                                   
                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                    if (!lobjItemExtensions.ContainsKey(strdName))
                                        lobjItemExtensions.Add(strdName, strdValue);
                                     

                                }
                            }

                        }
                    }
                    else
                    {
                        pobjItemExtensions = lobjItemExtensions;
                        return lobjArryItem;
                      
                    }

                   
                }
                lobjArryItem.Add(objPOLine);
                pobjItemExtensions = lobjItemExtensions;
                return lobjArryItem;
            }
            catch(Exception ex)
            {
                 throw;
                 return null;
            
            }
            

        }

        public ArrayList PoCustomerCustomDetails(string pstrCustomerName, Dictionary<string, string> ExistingItems, out Dictionary<string, string> pobjItemExtensions)
        {
            ArrayList lobjArryItem = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            string strdName = string.Empty;
            string strdValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            lobjItemExtensions = ExistingItems;

              QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            clsPurchaseOrderLine objPOLine = null;
            try
            {
                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    lQBSessionManager = LabelConnector.QBHelper.ConnectQBCloseMode(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                }

                else
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                    ICustomerQuery CustomerQuery = default(ICustomerQuery);
                    CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                    CustomerQuery.OwnerIDList.Add("0");
                    CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrCustomerName);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if (lQBSessionManager != null)
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
               
                    if (lMsgResponse != null && lMsgResponse.ResponseList != null && lMsgResponse.ResponseList.Count > 0)
                    {
                        IResponse lobjIResponse = lMsgResponse.ResponseList.GetAt(0);
                        ICustomerRetList lobjICustomerRetList = (ICustomerRetList)lobjIResponse.Detail;
                        ICustomerRet loCustomerRet = default(ICustomerRet);
                        if (lobjICustomerRetList != null)
                        {
                            for (int Index1 = 0; Index1 < lobjICustomerRetList.Count; Index1++)
                            {
                                loCustomerRet = lobjICustomerRetList.GetAt(Index1);
                                if (!string.IsNullOrWhiteSpace(loCustomerRet.FullName.GetValue()))
                                {
                                    if (loCustomerRet.DataExtRetList != null)
                                    {
                                        for (int i = 0; i < loCustomerRet.DataExtRetList.Count; i++)
                                        {
                                            IDataExtRet DataExtRet = loCustomerRet.DataExtRetList.GetAt(i);

                                            strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                            strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                lobjItemExtensions.Add(strdName, strdValue);
                                        }
                                    }
                                }

                            }
                        }
                    else
                    {
                        pobjItemExtensions = lobjItemExtensions;
                        return lobjArryItem;

                    }

                }

                lobjArryItem.Add(objPOLine);
                pobjItemExtensions = lobjItemExtensions;
                return lobjArryItem;
            }
            catch (Exception ex)
            {
                throw;
                return null;

            }


        }

        // ***Start*** added by Srinivas on 10-Aug-2017 to get values for Non Inventory Items
        // Get BarcodeValue,SalesDesc and SalesPrice :Date 10-08-2017
        public ArrayList PoItemDetailsForNonInventoryItems(string pstrItemName, out Dictionary<string, string> pobjItemExtensions)
        {
            clsPurchaseOrderLine objpoitem = new clsPurchaseOrderLine();
            ArrayList lobjArryItem = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            string strdName = string.Empty;
            string strdValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            clsPurchaseOrderLine objPOLine = null;
            try
            {
                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    lQBSessionManager = LabelConnector.QBHelper.ConnectQBCloseMode(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                }
                else
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }


                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemNonInventoryQuery ItemInventory = default(IItemNonInventoryQuery);
                ItemInventory = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemNonInventoryRetList loList = (IItemNonInventoryRetList)loResponse.Detail;
                    IItemNonInventoryRet loItemname = default(IItemNonInventoryRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            objPOLine = new clsPurchaseOrderLine();
                            loItemname = loList.GetAt(Index);
                            if (loItemname.BarCodeValue != null)
                                objPOLine.BarCodeValue = Convert.ToString(loItemname.BarCodeValue.GetValue());// Get barcode value
                            if (loItemname.ORSalesPurchase.SalesAndPurchase != null) // null check added 29-Oct-2018
                            {
                                if (loItemname.ORSalesPurchase.SalesAndPurchase.SalesDesc != null)
                                {
                                    objPOLine.SalesDesc = Convert.ToString(loItemname.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue());// Get sales desc value
                                }
                            }
                            if (loItemname.ORSalesPurchase.SalesAndPurchase != null) // null check added 29-Oct-2018
                            {
                                if (loItemname.ORSalesPurchase.SalesAndPurchase.SalesPrice != null)
                                {
                                    objPOLine.SalesPrice = Convert.ToString(loItemname.ORSalesPurchase.SalesAndPurchase.SalesPrice.GetValue());// Get sales price value 
                                }
                            }
                            //Add support for multi PO Mfr Part Number :Date 16-May-2017
                            if (loItemname.ManufacturerPartNumber != null)
                                objPOLine.MPN = Convert.ToString(loItemname.ManufacturerPartNumber.GetValue());

                            ////Get Avg cost & quantity on hand: Date 03-April-2017
                            //if (loItemname.AverageCost != null)
                            //{
                            //    objPOLine.AverageCost = Convert.ToString(loItemname.AverageCost.GetValue());// Get average cost
                            //}
                            //if (loItemname.QuantityOnHand != null)
                            //{
                            //    objPOLine.QuantityOnHand = Convert.ToString(loItemname.QuantityOnHand.GetValue());// Get quantity on hand   

                            //}

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                    if (!lobjItemExtensions.ContainsKey(strdName))
                                        lobjItemExtensions.Add(strdName, strdValue);

                                }
                            }
                        }
                    }
                    else
                    {
                        pobjItemExtensions = lobjItemExtensions;
                        return lobjArryItem;

                    }
                }
                lobjArryItem.Add(objPOLine);
                pobjItemExtensions = lobjItemExtensions;
                return lobjArryItem;
            }
            catch (Exception ex)
            {
                throw;
                return null;

            }

        }

        //***End***

        //Get custom field for Assembly item for po
        public ArrayList PoItemDetailsForAssemblyInventoryItems(string pstrItemName, out Dictionary<string, string> pobjItemExtensions)
        {
            clsPurchaseOrderLine objpoitem = new clsPurchaseOrderLine();
            ArrayList lobjArryItem = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();    
            string strdName = string.Empty;
            string strdValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            clsPurchaseOrderLine objPOLine = null;
            try
            {
                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
                {
                    lQBSessionManager = LabelConnector.QBHelper.ConnectQBCloseMode(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                }

                else
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryAssemblyQuery ItemInventory = default(IItemInventoryAssemblyQuery);
              
                ItemInventory = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemInventoryAssemblyRetList loList = (IItemInventoryAssemblyRetList)loResponse.Detail;
                    IItemInventoryAssemblyRet loItemname = default(IItemInventoryAssemblyRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            objPOLine = new clsPurchaseOrderLine();
                            loItemname = loList.GetAt(Index);
                            if (loItemname.BarCodeValue != null)
                                objPOLine.BarCodeValue = Convert.ToString(loItemname.BarCodeValue.GetValue());// Get barcode value
                            
                                if (loItemname.SalesDesc != null)
                                {
                                    objPOLine.SalesDesc = Convert.ToString(loItemname.SalesDesc.GetValue());// Get sales desc value
                                }
                            
                            if (loItemname.SalesPrice != null) // null check added 29-Oct-2018
                            {
                               
                               objPOLine.SalesPrice = Convert.ToString(loItemname.SalesPrice.GetValue());// Get sales price value 
                               
                            }
                            //Add support for multi PO Mfr Part Number :Date 16-May-2017
                            if (loItemname.ManufacturerPartNumber != null)
                                objPOLine.MPN = Convert.ToString(loItemname.ManufacturerPartNumber.GetValue());

                            ////Get Avg cost & quantity on hand: Date 03-April-2017
                            //if (loItemname.AverageCost != null)
                            //{
                            //    objPOLine.AverageCost = Convert.ToString(loItemname.AverageCost.GetValue());// Get average cost
                            //}
                            //if (loItemname.QuantityOnHand != null)
                            //{
                            //    objPOLine.QuantityOnHand = Convert.ToString(loItemname.QuantityOnHand.GetValue());// Get quantity on hand   

                            //}

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                    if (!lobjItemExtensions.ContainsKey(strdName))
                                        lobjItemExtensions.Add(strdName, strdValue);

                                }
                            }
                        }
                    }
                    else
                    {
                        pobjItemExtensions = lobjItemExtensions;
                        return lobjArryItem;

                    }
                }
                lobjArryItem.Add(objPOLine);
                pobjItemExtensions = lobjItemExtensions;
                return lobjArryItem;
            }
            catch (Exception ex)
            {
                throw;
                return null;

            }

        }


        //Get BarCode Values for PO Item receipt
        public string GetItemsBarCode(string pstrItemName,bool connection =false)
        {           
            string strItembarcode = string.Empty;
           

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
         
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemQuery ItemQuery = default(IItemQuery);
                ItemQuery = lMsgRequest.AppendItemQueryRq();
                ItemQuery.OwnerIDList.Add("0");


                ItemQuery.ORListQuery.FullNameList.Add(pstrItemName);
                if(connection)
                {
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }              
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if(lQBSessionManager !=null && connection)
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
             
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                   
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IORItemRetList loList = (IORItemRetList)loResponse.Detail;
                    IItemInventoryRet loItemname = default(IItemInventoryRet);
                    

                    if (loList != null)
                    {
                        if(loList.GetAt(0).ItemInventoryRet != null)
                        {
                            IItemInventoryRet ItemDate = loList.GetAt(0).ItemInventoryRet;
                            if(ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }else if(loList.GetAt(0).ItemNonInventoryRet != null)
                        {
                            IItemNonInventoryRet ItemDate = loList.GetAt(0).ItemNonInventoryRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                        else if (loList.GetAt(0).ItemInventoryAssemblyRet != null)
                        {
                            IItemInventoryAssemblyRet ItemDate = loList.GetAt(0).ItemInventoryAssemblyRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                        else if (loList.GetAt(0).ItemServiceRet != null)
                        {
                            IItemServiceRet ItemDate = loList.GetAt(0).ItemServiceRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                        else if (loList.GetAt(0).ItemOtherChargeRet != null)
                        {
                            IItemOtherChargeRet ItemDate = loList.GetAt(0).ItemOtherChargeRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                        else if (loList.GetAt(0).ItemGroupRet != null)
                        {
                            IItemGroupRet ItemDate = loList.GetAt(0).ItemGroupRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        return strItembarcode;
                    }
                }
               
                return strItembarcode;
            }
            catch (Exception ex)
            {
                
                throw;
                return null;

            }


        }
        public ArrayList GetPOLine(string lstrQuantityonLabel, string strRefNumber, string PurchaseOrderLineTxnLineID, DateTime dtTransactionDate, string strVendorRefFullName, out Dictionary<string, string> pobjCustomfieldExtensions)
        {
            ArrayList alPurchaseOrdersLine = new ArrayList();
            string strTxnLineID = string.Empty;
            string lstrQBItemName = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            Dictionary<string, string> lobjCustItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lobjCustomerCustExtensions = new Dictionary<string, string>();
            ArrayList lobjarr = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                //IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);

                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();

                PurchaseOrderQuery.IncludeLineItems.SetValue(true);
                PurchaseOrderQuery.OwnerIDList.Add("0"); 
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
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
            try
                { 
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    ICustomerRetList lobjICustomerRetList = null;
                        IResponse lobjIResponse;
                        IMsgSetResponse lobjIMsgSetResponse;
                        IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);
                    //IPurchaseOrderLineRetList loPurchaseOrderLine = default(IPurchaseOrderLineRetList);
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loPurchaseOrder.ORPurchaseOrderLineRetList.Count; intLine++)
                            {
                                clsPurchaseOrderLine objPOLine = null; //new clsPurchaseOrderLine();
                                //if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet == null)
                                //{
                                //    throw new Exception("Order Containing Group Type of Items are not Supported");
                                //}
                                //print group item child custom fields :Date 20-Sept-2019
                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet != null)
                                {
                                    objPOLine = new clsPurchaseOrderLine();
                                    strTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());

                                    if (PurchaseOrderLineTxnLineID == strTxnLineID)
                                    {
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null)
                                        {
                                            objPOLine.PrintLblQty = Convert.ToDouble(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue());
                                            objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                        }
                                        else
                                        {
                                            objPOLine.PrintLblQty = 0.00;
                                            objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                        }
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                        }
                                        //Add Rate & Amount : 19-Feb-2019

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Amount != null)
                                        {

                                            objPOLine.PurchaseOrderLineAmount = string.Format("{0:N}", loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineAmount = "0";
                                        }

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate != null && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate != null)
                                        {

                                            objPOLine.PurchaseOrderLineRate = string.Format("{0:N}", loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineRate = "0";
                                        }
                                        //BIN Field feature:05-APR-2019
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef != null)
                                        {
                                            //Get value of FullName
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef.FullName != null)
                                            {
                                                objPOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");
                                            }
                                        }

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                            objPOLine.purchaseordercombineItem = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                            //Get Memo Field for PO:Date 07-May-2018
                                            if (loPurchaseOrder.Memo != null)
                                                objPOLine.Memo = Convert.ToString(loPurchaseOrder.Memo.GetValue());
                                            else
                                                objPOLine.Memo = "";
                                            //Get PO SubItemOf
                                            objPOLine.SubItemOf = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());

                                            //enable custom field for po

                                            lobjarr = PoItemDetails(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                            //lobjarr = PoItemDetails(objPOLine.PurchaseOrderLineItemRefFullName, out lobjCustItemExtensions);
                                            //***Start***Added by Srinivas on 10-Aug-2017 for getting Non Inventory Items
                                            if (lobjarr.Count < 1)
                                            {
                                                lobjarr = PoItemDetailsForNonInventoryItems(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                            }
                                            //***End***Added by Srinivas on 10-Aug-2017 for getting Non Inventory Items
                                            //Add support for print assembly item custom field:03-Jan-2020
                                            if (lobjarr.Count < 1)
                                            {
                                                lobjarr = PoItemDetailsForAssemblyInventoryItems(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                            }

                                            //check if po item desc present
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                            {
                                                objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());

                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineDesc = "";
                                            }

                                            //Get customer for purchase order

                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                            {
                                                //Get Customer Only
                                                objPOLine.PurchaseOrderCustomer = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()); //Get Customer only
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        //Get Customer Job only:Date 26-Nov-2019
                                                objPOLine.POCustomerJob = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).Substring(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).LastIndexOf(':') + 1); //Get Job only from customer

                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderCustomer = "";
                                            }
                                            if(objPOLine.POCustomerJob != "" && (lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                            {
                                                    lobjCustomerCustExtensions = lobjCustItemExtensions;
                                                    PoCustomerCustomDetails(objPOLine.POCustomerJob, lobjCustomerCustExtensions, out lobjCustItemExtensions);
                                            }
                                        

                                            if (lobjarr.Count > 0 && lobjarr != null)
                                            {
                                                foreach (clsPurchaseOrderLine item in lobjarr)
                                                {
                                                    objPOLine.BarCodeValue = item.BarCodeValue;
                                                    objPOLine.SalesDesc = item.SalesDesc;
                                                    objPOLine.SalesPrice = item.SalesPrice;
                                                    //Get Avg cost & Qty on hand :Date 03-April-2017
                                                    objPOLine.AverageCost = item.AverageCost;
                                                    objPOLine.QuantityOnHand = item.QuantityOnHand;
                                                    //assign Mfr Part No: 17-May-2017
                                                    objPOLine.MPN = item.MPN;

                                                }
                                            }

                                            //Add custom field from po line item :  Date 30-jan-2017
                                            IORPurchaseOrderLineRet lobjIDataExtRetList1 = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.GetAt(k);

                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    if (!lobjCustItemExtensions.ContainsKey(strdName))
                                                    {
                                                        //change Other1 to Other1L for line item
                                                        if (strdName == "OTHER1")
                                                        {
                                                            strdName = "OTHER1L";
                                                        }
                                                        else if (strdName == "OTHER2")
                                                        {
                                                            strdName = "OTHER2L";
                                                        }
                                                        lobjCustItemExtensions.Add(strdName, strdValue);
                                                    }
                                                    else
                                                    {
                                                        //update key/value
                                                        lobjCustItemExtensions.Remove(strdName);
                                                        if (strdName == "OTHER1")
                                                        {
                                                            strdName = "OTHER1L";
                                                        }
                                                        else if (strdName == "OTHER2")
                                                        {
                                                            strdName = "OTHER2L";
                                                        }
                                                        lobjCustItemExtensions.Add(strdName, strdValue);


                                                    }

                                                }
                                            }


              
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = "";
                                        }
                                        // if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                        // {
                                        // objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());
                                        //Get BarCodeValue,Sale Desc,Sales Price for perticular Item
                                        // lstrQBItemName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                        //lobjarr = PoItemDetails(lstrQBItemName, out lobjCustItemExtensions);
                                        //if (lobjarr.Count > 0 && lobjarr != null)
                                        //{
                                        //    foreach (clsPurchaseOrderLine item in lobjarr)
                                        //    {
                                        //        objPOLine.BarCodeValue = item.BarCodeValue;
                                        //        objPOLine.SalesDesc = item.SalesDesc;
                                        //        objPOLine.SalesPrice = item.SalesPrice;

                                        //    }
                                        //}


                                        ////Add custom field from po line item :  Date 27-jan-2017
                                        //IORPurchaseOrderLineRet lobjIDataExtRetList1 = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine);

                                        //if (lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList != null)
                                        //{
                                        //    for (int k = 0; k < lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.Count; k++)
                                        //    {
                                        //        IDataExtRet DataExtRet = lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.GetAt(k);

                                        //        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                        //        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                        //        if (!lobjCustItemExtensions.ContainsKey(strdName))
                                        //        {
                                        //            lobjCustItemExtensions.Add(strdName, strdValue);
                                        //        }
                                        //        else
                                        //        {
                                        //            //update key/value
                                        //            lobjCustItemExtensions.Remove(strdName);
                                        //            lobjCustItemExtensions.Add(strdName, strdValue);


                                        //        }

                                        //    }
                                        //}

                                        // }
                                        // else
                                        // {
                                        //objPOLine.PurchaseOrderLineDesc = "";
                                        // }
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID != null)
                                        {
                                            objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineTxnLineID = "";
                                        }
                                     

                                        //Get CustomerJOb for PO : Date 16-Feb-2017
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                        {

                                            objPOLine.CustomerJob = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.CustomerJob = "";
                                        }

                                        objPOLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        objPOLine.VendorRefFullName = strVendorRefFullName;
                                        objPOLine.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                                        //Add ShipAddress Block:04-APR-2019
                                        if (loPurchaseOrder.ShipAddress != null)
                                        {
                                            if (loPurchaseOrder.ShipAddress.Addr1 != null)
                                                objPOLine.ShipAddressAddr1 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr1.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr2 != null)
                                                objPOLine.ShipAddressAddr2 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr2.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr3 != null)
                                                objPOLine.ShipAddressAddr3 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr3.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr4 != null)
                                                objPOLine.ShipAddressAddr4 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr4.GetValue());
                                            if (loPurchaseOrder.ShipAddress.Addr5 != null)
                                                objPOLine.ShipAddressAddr5 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr5.GetValue());

                                            if (loPurchaseOrder.ShipAddress.City != null)
                                                objPOLine.ShipAddressCity = Convert.ToString(loPurchaseOrder.ShipAddress.City.GetValue());

                                            if (loPurchaseOrder.ShipAddress.State != null)
                                                objPOLine.ShipAddressState = Convert.ToString(loPurchaseOrder.ShipAddress.State.GetValue());

                                            if (loPurchaseOrder.ShipAddress.PostalCode != null)
                                            {
                                                objPOLine.ShipAddressPostalCode = Convert.ToString(loPurchaseOrder.ShipAddress.PostalCode.GetValue());
                                                objPOLine.ShipAddressAddrPostalCode = Convert.ToString(loPurchaseOrder.ShipAddress.PostalCode.GetValue());
                                            }
                                               

                                            if (loPurchaseOrder.ShipAddress.Country != null)
                                                objPOLine.ShipAddressCountry = Convert.ToString(loPurchaseOrder.ShipAddress.Country.GetValue());

                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objPOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressPostalCode))
                                            {
                                                objPOLine.citystatezip += objPOLine.ShipAddressCity + " " + objPOLine.ShipAddressState + " " + objPOLine.ShipAddressPostalCode;
                                            }

                                        }


                                        //Other1 support for po: 03-09-2017
                                        if (loPurchaseOrder.Other1 != null)
                                        {
                                            objPOLine.Other1H = Convert.ToString(loPurchaseOrder.Other1.GetValue());
                                        }
                                        //new added Other2: 14-Feb-2019
                                        if (loPurchaseOrder.Other2 != null)
                                        {
                                            objPOLine.Other2 = Convert.ToString(loPurchaseOrder.Other2.GetValue());
                                        }
                                        if (loPurchaseOrder.FOB != null) //14-Feb-2019
                                        {
                                            objPOLine.FOB = Convert.ToString(loPurchaseOrder.FOB.GetValue());
                                        }

                                        // add qty on label on po printing : Date 16-Feb-2017
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            objPOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            objPOLine.QtyOnLabel = string.Empty;
                                        }


                                        alPurchaseOrdersLine.Add(objPOLine);
                                    } // transid comp end 
                                } //purchaseorderLineRet end
                                //comment polinegroup block
                                //else if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet != null)
                                //{
                                //    //if child item is group type:20-Sept-2019
                                //    objPOLine = new clsPurchaseOrderLine();
                                  
                                    ////Get Group Item child record
                                //    if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList != null)
                                //    {

                                //        for (int grpitem = 0; grpitem < loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList.Count; grpitem++)
                                //        {
                                //            IPurchaseOrderLineRet PurchaseOrderLineRet = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineGroupRet.PurchaseOrderLineRetList.GetAt(grpitem);
                                //            if(PurchaseOrderLineRet.TxnLineID !=null)
                                //            {
                                //                strTxnLineID = Convert.ToString(PurchaseOrderLineRet.TxnLineID.GetValue());
                                                
                                //            }

                                //            if (PurchaseOrderLineTxnLineID == strTxnLineID)
                                //            {

                                //                //Get Custom field for group line item.Date 9-Dec-2018
                                //                if (PurchaseOrderLineRet.DataExtRetList != null)
                                //                {
                                //                    for (int i165 = 0; i165 < PurchaseOrderLineRet.DataExtRetList.Count; i165++)
                                //                    {
                                //                        IDataExtRet DataExtRet = PurchaseOrderLineRet.DataExtRetList.GetAt(i165);

                                //                        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                //                        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                //                        if (!lobjCustItemExtensions.ContainsKey(strdName))
                                //                        {
                                //                            //change Other1 to Other1L for line item
                                //                            if (strdName == "OTHER1")
                                //                            {
                                //                                strdName = "OTHER1L";
                                //                            }
                                //                            else if (strdName == "OTHER2")
                                //                            {
                                //                                strdName = "OTHER2L";
                                //                            }
                                //                            lobjCustItemExtensions.Add(strdName, strdValue);
                                //                        }
                                //                        else
                                //                        {
                                //                            lobjCustItemExtensions.Remove(strdName);
                                //                            if (strdName == "OTHER1")
                                //                            {
                                //                                strdName = "OTHER1L";
                                //                            }
                                //                            else if (strdName == "OTHER2")
                                //                            {
                                //                                strdName = "OTHER2L";
                                //                            }
                                //                            lobjCustItemExtensions.Add(strdName, strdValue);

                                //                        }

                                //                    }
                                //                }
                                //                else // get Custom field from item defination.
                                //                {

                                //                }
                                                
                                //                if (PurchaseOrderLineRet.ItemRef !=null)
                                //                {
                                //                    if(PurchaseOrderLineRet.ItemRef.FullName !=null)
                                //                    {
                                //                        objPOLine.PurchaseOrderLineItemRefFullName = PurchaseOrderLineRet.ItemRef.FullName.GetValue();

                                //                    }
                                //                }
                                //                if (PurchaseOrderLineRet.Desc != null)
                                //                {
                                //                    objPOLine.PurchaseOrderLineDesc = Convert.ToString(PurchaseOrderLineRet.Desc.GetValue());

                                //                }
                                //                if (PurchaseOrderLineRet.Quantity != null)
                                //                {
                                //                    objPOLine.PurchaseOrderLineQuantity = Convert.ToDouble(PurchaseOrderLineRet.Quantity.GetValue());

                                //                }
                                //                if (PurchaseOrderLineRet.Rate != null)
                                //                {
                                //                    objPOLine.PurchaseOrderLineRate = Convert.ToString(string.Format("{0:N}", PurchaseOrderLineRet.Rate.GetValue()));
                                                   
                                //                }
                                //                if (PurchaseOrderLineRet.ManufacturerPartNumber != null)
                                //                {
                                //                    objPOLine.MPN = Convert.ToString(PurchaseOrderLineRet.ManufacturerPartNumber.GetValue());

                                //                }
                                //                if (PurchaseOrderLineRet.CustomerRef != null)
                                //                {
                                //                    if (PurchaseOrderLineRet.CustomerRef.FullName != null)
                                //                    {
                                //                        if (PurchaseOrderLineRet.CustomerRef.FullName.GetValue().IndexOf(":") > 0)
                                //                        {
                                //                            objPOLine.PurchaseOrderCustomer = PurchaseOrderLineRet.CustomerRef.FullName.GetValue().Substring(0, PurchaseOrderLineRet.CustomerRef.FullName.GetValue().IndexOf(':'));
                                                           

                                //                        }
                                                       
                                //                    }

                                //                }
                                //                if (PurchaseOrderLineRet.Amount != null)
                                //                {
                                //                    objPOLine.PurchaseOrderLineAmount = Convert.ToString(PurchaseOrderLineRet.Amount.GetValue());

                                //                }
                                //                if (PurchaseOrderLineRet.InventorySiteLocationRef != null) //Get BIN
                                //                {
                                //                    if (PurchaseOrderLineRet.InventorySiteLocationRef.FullName != null)
                                //                    {
                                //                        objPOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(PurchaseOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");
                                //                    }
                                //                }
                                //                if (PurchaseOrderLineRet.UnitOfMeasure != null)
                                //                {
                                //                    objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(PurchaseOrderLineRet.UnitOfMeasure.GetValue());

                                //                }

                                //                if (PurchaseOrderLineRet.CustomerRef != null)
                                //                {
                                //                    if (PurchaseOrderLineRet.CustomerRef.FullName != null)
                                //                    {
                                //                        objPOLine.CustomerJob = Convert.ToString(PurchaseOrderLineRet.CustomerRef.FullName.GetValue());
                                //                    }

                                //                }

                                              

                                //                //Get PO Heade Info
                                //                objPOLine.TxnDate = dtTransactionDate.ToShortDateString();
                                //                objPOLine.VendorRefFullName = strVendorRefFullName;
                                //                objPOLine.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                                //                //Add ShipAddress Block:04-APR-2019
                                //                if (loPurchaseOrder.ShipAddress != null)
                                //                {
                                //                    if (loPurchaseOrder.ShipAddress.Addr1 != null)
                                //                        objPOLine.ShipAddressAddr1 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr1.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.Addr2 != null)
                                //                        objPOLine.ShipAddressAddr2 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr2.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.Addr3 != null)
                                //                        objPOLine.ShipAddressAddr3 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr3.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.Addr4 != null)
                                //                        objPOLine.ShipAddressAddr4 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr4.GetValue());
                                //                    if (loPurchaseOrder.ShipAddress.Addr5 != null)
                                //                        objPOLine.ShipAddressAddr5 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr5.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.City != null)
                                //                        objPOLine.ShipAddressCity = Convert.ToString(loPurchaseOrder.ShipAddress.City.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.State != null)
                                //                        objPOLine.ShipAddressState = Convert.ToString(loPurchaseOrder.ShipAddress.State.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.PostalCode != null)
                                //                        objPOLine.ShipAddressPostalCode = Convert.ToString(loPurchaseOrder.ShipAddress.PostalCode.GetValue());

                                //                    if (loPurchaseOrder.ShipAddress.Country != null)
                                //                        objPOLine.ShipAddressCountry = Convert.ToString(loPurchaseOrder.ShipAddress.Country.GetValue());

                                //                    //citystatezip field added:Date 30-APR-2019
                                //                    if (!string.IsNullOrWhiteSpace(objPOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressPostalCode))
                                //                    {
                                //                        objPOLine.citystatezip += objPOLine.ShipAddressCity + " " + objPOLine.ShipAddressState + " " + objPOLine.ShipAddressPostalCode;
                                //                    }

                                //                    //Other1 support for po: 03-09-2017
                                //                    if (loPurchaseOrder.Other1 != null)
                                //                    {
                                //                        objPOLine.Other1H = Convert.ToString(loPurchaseOrder.Other1.GetValue());
                                //                    }
                                //                    //new added Other2: 14-Feb-2019
                                //                    if (loPurchaseOrder.Other2 != null)
                                //                    {
                                //                        objPOLine.Other2 = Convert.ToString(loPurchaseOrder.Other2.GetValue());
                                //                    }
                                //                    if (loPurchaseOrder.FOB != null) //14-Feb-2019
                                //                    {
                                //                        objPOLine.FOB = Convert.ToString(loPurchaseOrder.FOB.GetValue());
                                //                    }

                                //                    // add qty on label on po printing : Date 16-Feb-2017
                                //                    if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                //                    {
                                //                        objPOLine.Qty = lstrQuantityonLabel;
                                //                    }
                                //                    else
                                //                    {
                                //                        objPOLine.Qty = string.Empty;
                                //                    }

                                //                    if (loPurchaseOrder.Memo != null)
                                //                        objPOLine.Memo = Convert.ToString(loPurchaseOrder.Memo.GetValue());
                                //                    else
                                //                        objPOLine.Memo = "";


                                //                }


                                //                alPurchaseOrdersLine.Add(objPOLine);
                                //            }
                                            

                                //        }
                                //    }



                                //}//purchaseorderLineGroupRet End
                            }
                        }
                    }
                }
                pobjCustomfieldExtensions = lobjCustItemExtensions;
                return alPurchaseOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                return null;
            }

          

        }


        public ArrayList GetPOLineCloseMode(string lstrQuantityonLabel, string strRefNumber, string PurchaseOrderLineTxnLineID, DateTime dtTransactionDate, string strVendorRefFullName, QBSessionManager lQBSessionManager, out Dictionary<string, string> pobjCustomfieldExtensions)
        {
            ArrayList alPurchaseOrdersLine = new ArrayList();
            string strTxnLineID = string.Empty;
            string lstrQBItemName = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            Dictionary<string, string> lobjCustItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lobjCustomerCustExtensions = new Dictionary<string, string>();
            ArrayList lobjarr = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
               // lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);

                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();

                PurchaseOrderQuery.IncludeLineItems.SetValue(true);
                PurchaseOrderQuery.OwnerIDList.Add("0");
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);

                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                //lQBSessionManager.OpenConnection("", "Label Connector");
                //lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
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
            try
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse lobjIResponse;
                    IMsgSetResponse lobjIMsgSetResponse;
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loPurchaseOrder.ORPurchaseOrderLineRetList.Count; intLine++)
                            {
                                clsPurchaseOrderLine objPOLine = null; 

                                if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet != null)
                                {
                                    objPOLine = new clsPurchaseOrderLine();
                                    strTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());

                                    if (PurchaseOrderLineTxnLineID == strTxnLineID)
                                    {
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity != null)
                                        {
                                            objPOLine.PrintLblQty = Convert.ToDouble(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Quantity.GetValue());
                                            objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                        }
                                        else
                                        {
                                            objPOLine.PrintLblQty = 0.00;
                                            objPOLine.PurchaseOrderQty = objPOLine.PrintLblQty;
                                        }
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objPOLine.PurchaseOrderLineUnitOfMeasure = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineUnitOfMeasure = "";
                                        }
                                        //Add Rate & Amount : 19-Feb-2019

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Amount != null)
                                        {

                                            objPOLine.PurchaseOrderLineAmount = string.Format("{0:N}", loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineAmount = "0";
                                        }

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate != null && loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate != null)
                                        {

                                            objPOLine.PurchaseOrderLineRate = string.Format("{0:N}", loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Rate.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineRate = "0";
                                        }
                                        //BIN Field feature:05-APR-2019
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef != null)
                                        {
                                            //Get value of FullName
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef.FullName != null)
                                            {
                                                objPOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");
                                            }
                                        }

                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef != null)
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                            objPOLine.purchaseordercombineItem = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());
                                            //Get Memo Field for PO:Date 07-May-2018
                                            if (loPurchaseOrder.Memo != null)
                                                objPOLine.Memo = Convert.ToString(loPurchaseOrder.Memo.GetValue());
                                            else
                                                objPOLine.Memo = "";
                                            //Get PO SubItemOf
                                            objPOLine.SubItemOf = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.ItemRef.FullName.GetValue());

                                            //enable custom field for po

                                            lobjarr = PoItemDetails(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                            if ((lQBSessionManager != null))
                                            {
                                                LabelConnector.QBHelper.CloseQBConnection(lQBSessionManager);
                                            }
                                            //lobjarr = PoItemDetails(objPOLine.PurchaseOrderLineItemRefFullName, out lobjCustItemExtensions);
                                            //***Start***Added by Srinivas on 10-Aug-2017 for getting Non Inventory Items
                                            if (lobjarr.Count < 1)
                                            {
                                                lobjarr = PoItemDetailsForNonInventoryItems(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                                if ((lQBSessionManager != null))
                                                {
                                                    LabelConnector.QBHelper.CloseQBConnection(lQBSessionManager);
                                                }
                                            }
                                            //***End***Added by Srinivas on 10-Aug-2017 for getting Non Inventory Items
                                            //Add support for print assembly item custom field:03-Jan-2020
                                            if (lobjarr.Count < 1)
                                            {
                                                lobjarr = PoItemDetailsForAssemblyInventoryItems(objPOLine.purchaseordercombineItem, out lobjCustItemExtensions);
                                                if ((lQBSessionManager != null))
                                                {
                                                    LabelConnector.QBHelper.CloseQBConnection(lQBSessionManager);
                                                }
                                            }

                                            //check if po item desc present
                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc != null)
                                            {
                                                objPOLine.PurchaseOrderLineDesc = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.Desc.GetValue());

                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderLineDesc = "";
                                            }

                                            //Get customer for purchase order

                                            if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                            {
                                                //Get Customer Only
                                                objPOLine.PurchaseOrderCustomer = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()); //Get Customer only
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        //Get Customer Job only:Date 26-Nov-2019
                                                objPOLine.POCustomerJob = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).Substring(Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue()).LastIndexOf(':') + 1); //Get Job only from customer

                                            }
                                            else
                                            {
                                                objPOLine.PurchaseOrderCustomer = "";
                                            }
                                            if (objPOLine.POCustomerJob != "" && (lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                            {
                                                lobjCustomerCustExtensions = lobjCustItemExtensions;
                                                PoCustomerCustomDetails(objPOLine.POCustomerJob, lobjCustomerCustExtensions, out lobjCustItemExtensions);
                                                if ((lQBSessionManager != null))
                                                {
                                                    LabelConnector.QBHelper.CloseQBConnection(lQBSessionManager);
                                                }
                                            }


                                            if (lobjarr.Count > 0 && lobjarr != null)
                                            {
                                                foreach (clsPurchaseOrderLine item in lobjarr)
                                                {
                                                    objPOLine.BarCodeValue = item.BarCodeValue;
                                                    objPOLine.SalesDesc = item.SalesDesc;
                                                    objPOLine.SalesPrice = item.SalesPrice;
                                                    //Get Avg cost & Qty on hand :Date 03-April-2017
                                                    objPOLine.AverageCost = item.AverageCost;
                                                    objPOLine.QuantityOnHand = item.QuantityOnHand;
                                                    //assign Mfr Part No: 17-May-2017
                                                    objPOLine.MPN = item.MPN;

                                                }
                                            }

                                            //Add custom field from po line item :  Date 30-jan-2017
                                            IORPurchaseOrderLineRet lobjIDataExtRetList1 = loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.PurchaseOrderLineRet.DataExtRetList.GetAt(k);

                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    if (!lobjCustItemExtensions.ContainsKey(strdName))
                                                    {
                                                        //change Other1 to Other1L for line item
                                                        if (strdName == "OTHER1")
                                                        {
                                                            strdName = "OTHER1L";
                                                        }
                                                        else if (strdName == "OTHER2")
                                                        {
                                                            strdName = "OTHER2L";
                                                        }
                                                        lobjCustItemExtensions.Add(strdName, strdValue);
                                                    }
                                                    else
                                                    {
                                                        //update key/value
                                                        lobjCustItemExtensions.Remove(strdName);
                                                        if (strdName == "OTHER1")
                                                        {
                                                            strdName = "OTHER1L";
                                                        }
                                                        else if (strdName == "OTHER2")
                                                        {
                                                            strdName = "OTHER2L";
                                                        }
                                                        lobjCustItemExtensions.Add(strdName, strdValue);


                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineItemRefFullName = "";
                                        }
                                       
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID != null)
                                        {
                                            objPOLine.PurchaseOrderLineTxnLineID = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.TxnLineID.GetValue());
                                        }
                                        else
                                        {
                                            objPOLine.PurchaseOrderLineTxnLineID = "";
                                        }


                                        //Get CustomerJOb for PO : Date 16-Feb-2017
                                        if (loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef != null)
                                        {

                                            objPOLine.CustomerJob = Convert.ToString(loPurchaseOrder.ORPurchaseOrderLineRetList.GetAt(intLine).PurchaseOrderLineRet.CustomerRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objPOLine.CustomerJob = "";
                                        }

                                        objPOLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        objPOLine.VendorRefFullName = strVendorRefFullName;
                                        objPOLine.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                                        //Add ShipAddress Block:04-APR-2019
                                        if (loPurchaseOrder.ShipAddress != null)
                                        {
                                            if (loPurchaseOrder.ShipAddress.Addr1 != null)
                                                objPOLine.ShipAddressAddr1 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr1.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr2 != null)
                                                objPOLine.ShipAddressAddr2 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr2.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr3 != null)
                                                objPOLine.ShipAddressAddr3 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr3.GetValue());

                                            if (loPurchaseOrder.ShipAddress.Addr4 != null)
                                                objPOLine.ShipAddressAddr4 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr4.GetValue());
                                            if (loPurchaseOrder.ShipAddress.Addr5 != null)
                                                objPOLine.ShipAddressAddr5 = Convert.ToString(loPurchaseOrder.ShipAddress.Addr5.GetValue());

                                            if (loPurchaseOrder.ShipAddress.City != null)
                                                objPOLine.ShipAddressCity = Convert.ToString(loPurchaseOrder.ShipAddress.City.GetValue());

                                            if (loPurchaseOrder.ShipAddress.State != null)
                                                objPOLine.ShipAddressState = Convert.ToString(loPurchaseOrder.ShipAddress.State.GetValue());

                                            if (loPurchaseOrder.ShipAddress.PostalCode != null)
                                            {
                                                objPOLine.ShipAddressPostalCode = Convert.ToString(loPurchaseOrder.ShipAddress.PostalCode.GetValue());
                                                objPOLine.ShipAddressAddrPostalCode = Convert.ToString(loPurchaseOrder.ShipAddress.PostalCode.GetValue());
                                            }


                                            if (loPurchaseOrder.ShipAddress.Country != null)
                                                objPOLine.ShipAddressCountry = Convert.ToString(loPurchaseOrder.ShipAddress.Country.GetValue());

                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objPOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objPOLine.ShipAddressPostalCode))
                                            {
                                                objPOLine.citystatezip += objPOLine.ShipAddressCity + " " + objPOLine.ShipAddressState + " " + objPOLine.ShipAddressPostalCode;
                                            }

                                        }


                                        //Other1 support for po: 03-09-2017
                                        if (loPurchaseOrder.Other1 != null)
                                        {
                                            objPOLine.Other1H = Convert.ToString(loPurchaseOrder.Other1.GetValue());
                                        }
                                        //new added Other2: 14-Feb-2019
                                        if (loPurchaseOrder.Other2 != null)
                                        {
                                            objPOLine.Other2 = Convert.ToString(loPurchaseOrder.Other2.GetValue());
                                        }
                                        if (loPurchaseOrder.FOB != null) //14-Feb-2019
                                        {
                                            objPOLine.FOB = Convert.ToString(loPurchaseOrder.FOB.GetValue());
                                        }

                                        // add qty on label on po printing : Date 16-Feb-2017
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            objPOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            objPOLine.QtyOnLabel = string.Empty;
                                        }


                                        alPurchaseOrdersLine.Add(objPOLine);
                                    } // transid comp end 
                                } 
                            }
                        }
                    }
                }
                pobjCustomfieldExtensions = lobjCustItemExtensions;
                return alPurchaseOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                return null;
            }



        }


        // Get Vendors List:Date 06-10-2017
        public ArrayList GetVendorList()
        {
            string lstrvendorname = string.Empty;
            ArrayList lstVendor = new ArrayList();
           
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorQuery IVendorsQuery = default(IVendorQuery);
                
                IVendorsQuery = lMsgRequest.AppendVendorQueryRq();

                IVendorsQuery.ORVendorListQuery.VendorListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                
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
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IVendorRetList loList = (IVendorRetList)loResponse.Detail;
                    IVendorRet lovendors = default(IVendorRet);
                    


                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            lovendors = loList.GetAt(Index);

                            if (lovendors.Name != null)
                                lstVendor.Add(Convert.ToString(lovendors.Name.GetValue()));
                            

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //throw;
                return null;
            }


            return lstVendor;

        }

        //Get Item Receipt Data: Date 06-2017
        public List<clsPurchaseOrderLine> GetItemReceiptDetailsByPO(string strRefNumber, DateTime pstrmindate, DateTime pstrmaxdate, out string pstrErrormessage, out List<ReceiptItemCustomValues> pobjItemExtensions)
        {


            List<clsPurchaseOrderLine> objclspurchaseorder = new List<clsPurchaseOrderLine>();

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            List<ReceiptItemCustomValues> objreceiptcustomvalues = new List<ReceiptItemCustomValues>();

            ArrayList lobjarr = new ArrayList();

            string lstrErrMsg = string.Empty;
            int statusCode = 0;
            string statusMessage = string.Empty;
            string statusSeverity = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IItemReceiptQuery ItemReceiptQuery = default(IItemReceiptQuery);


                ItemReceiptQuery = lMsgRequest.AppendItemReceiptQueryRq();
                ItemReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                ItemReceiptQuery.IncludeLinkedTxns.SetValue(true);
                ItemReceiptQuery.IncludeLineItems.SetValue(true);

                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(pstrmindate);
                //Set field value for ToTxnDate
                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(pstrmaxdate);



                // ItemReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                ////Set field value for ToRefNumber
                // ItemReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                QBHelper.WriteLog("14" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Dorequest process start....");
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                QBHelper.WriteLog("15" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Dorequest process end....");

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    statusCode = loResponse.StatusCode;
                    statusMessage = loResponse.StatusMessage;
                    statusSeverity = loResponse.StatusSeverity;

                    IItemReceiptRetList loList = (IItemReceiptRetList)loResponse.Detail;
                    IItemReceiptRet loPurchaseOrder = default(IItemReceiptRet);


                    if (loList != null)
                    {
                        bool equals = false;
                        string ponumber = string.Empty;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);


                            if (loPurchaseOrder.LinkedTxnList != null)
                            {
                                for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                                {
                                    ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);
                                    if (LinkedTxn.RefNumber != null)
                                    {
                                        equals = strRefNumber.Equals((string)LinkedTxn.RefNumber.GetValue(), StringComparison.OrdinalIgnoreCase);
                                        ponumber = (string)LinkedTxn.RefNumber.GetValue();
                                    }

                                }


                            }

                            if (equals == true)
                            {
                                if (loPurchaseOrder.ORItemLineRetList != null)
                                {
                                    QBHelper.WriteLog("18" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "ORItemLineRetList is not null.");
                                    for (int Itemlist = 0; Itemlist < loPurchaseOrder.ORItemLineRetList.Count; Itemlist++)
                                    {
                                        IORItemLineRet ORItemLineRet = loPurchaseOrder.ORItemLineRetList.GetAt(Itemlist);
                                        clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();
                                        if (ORItemLineRet.ItemLineRet != null)
                                        {
                                            objPOLine.TransID = loPurchaseOrder.TxnNumber.GetValue(); //Get TransID: 26-oct-2017

                                            if (ORItemLineRet.ItemLineRet.ItemRef != null)
                                                {
                                                    if (ORItemLineRet.ItemLineRet.ItemRef.FullName != null)
                                                    {
                                                        //get both sub and main item and combine item : Date 07-Feb-2017
                                                        objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                        objPOLine.SubItemOf = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                        objPOLine.purchaseordercombineItem = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                        objPOLine.TxnLineID = ORItemLineRet.ItemLineRet.TxnLineID.GetValue();
                                                   
                                                       objPOLine.BarCodeValue = GetItemsBarCode(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()));


                                                }

                                                }
                                                if (ORItemLineRet.ItemLineRet.Quantity != null)
                                                {
                                                    objPOLine.RecQty = Convert.ToDouble(ORItemLineRet.ItemLineRet.Quantity.GetValue());
                                                    objPOLine.RefNumber = ponumber;
                                                }
                                                if (ORItemLineRet.ItemLineRet.Desc != null)
                                                {
                                                    objPOLine.PurchaseOrderLineDesc = Convert.ToString(ORItemLineRet.ItemLineRet.Desc.GetValue());

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

                                                if (loPurchaseOrder.TimeCreated != null)
                                                {
                                                    objPOLine.POReceivedItemCreatedTime = Convert.ToString(loPurchaseOrder.TimeCreated.GetValue());


                                                }

                                            //Custom fields for Item Receipt
                                            if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                            {
                                                QBHelper.WriteLog("POR-13" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Custom field......");

                                                for (int j = 0; j < ORItemLineRet.ItemLineRet.DataExtRetList.Count; j++)
                                                {
                                                    IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(j);
                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                    strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                    objreceiptcustomvalues.Add(new ReceiptItemCustomValues(objPOLine.TxnLineID, strdName, strdValue));

                                                }
                                            }
                                            

                                        }



                                        objclspurchaseorder.Add(objPOLine);

                                    }

                                }
                            }//if end
                            else
                            {
                                QBHelper.WriteLog("Error" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Bill item receipt not supported");

                                lstrErrMsg = "Bill item receipt transaction not supported";

                            }


                        }
                    }
                    else
                    {
                        QBHelper.WriteLog("Error" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + statusMessage);

                        lstrErrMsg = statusMessage;


                    }

                }
                pstrErrormessage = lstrErrMsg;
                pobjItemExtensions = objreceiptcustomvalues;
                // pobjItemExtensions = lobjItemExtensions;
                return objclspurchaseorder;
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


        //Get All Item Receipts: Date 07-10-2017

        public List<clsPurchaseOrderLine> GetAllItemReceipts(string pstrVendorName, out List<ReceiptItemCustomValues> pobjItemExtensions)
        {

            List<clsPurchaseOrderLine> objclspurchaseorder = new List<clsPurchaseOrderLine>();
            List<ReceiptItemCustomValues> objreceiptcustomvalues = new List<ReceiptItemCustomValues>();

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            string strdName = string.Empty;
            string strdValue = string.Empty;
            ArrayList lobjarr = new ArrayList();

            string lstrErrMsg = string.Empty;
            int statusCode = 0;
            string statusMessage = string.Empty;
            string statusSeverity = string.Empty;
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IItemReceiptQuery ItemReceiptQuery = default(IItemReceiptQuery);


                ItemReceiptQuery = lMsgRequest.AppendItemReceiptQueryRq();
                ItemReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                ItemReceiptQuery.IncludeLinkedTxns.SetValue(true);
                ItemReceiptQuery.IncludeLineItems.SetValue(true);

                //ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(pstrmindate);
                //Set field value for ToTxnDate
                //ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(pstrmaxdate);


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    statusCode = loResponse.StatusCode;
                    statusMessage = loResponse.StatusMessage;
                    statusSeverity = loResponse.StatusSeverity;

                    IItemReceiptRetList loList = (IItemReceiptRetList)loResponse.Detail;
                    IItemReceiptRet loPurchaseOrder = default(IItemReceiptRet);


                    if (loList != null)
                    {
                        bool equals = false;

                        string ponumber = string.Empty;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);

                            //string spo =loPurchaseOrder.VendorRef.FullName.GetValue();

                            //if (loPurchaseOrder.LinkedTxnList != null)
                            //{
                            //    for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                            //    {
                            //        ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);
                            //       // equals = strRefNumber.Equals((string)LinkedTxn.RefNumber.GetValue(), StringComparison.OrdinalIgnoreCase);
                            //        ponumber = (string)LinkedTxn.RefNumber.GetValue();

                            //    }


                            //}


                            if (loPurchaseOrder.ORItemLineRetList != null)
                            {


                                for (int Itemlist = 0; Itemlist < loPurchaseOrder.ORItemLineRetList.Count; Itemlist++)
                                {
                                    IORItemLineRet ORItemLineRet = loPurchaseOrder.ORItemLineRetList.GetAt(Itemlist);
                                    clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();
                                    if (ORItemLineRet.ItemLineRet != null)
                                    {

                                        //Get Trans ID - 23-Oct-2017
                                        objPOLine.TransID = loPurchaseOrder.TxnNumber.GetValue();

                                        //if (ORItemLineRet.ItemLineRet != null)
                                        //{
                                        if (ORItemLineRet.ItemLineRet.ItemRef != null)
                                        {
                                            if (ORItemLineRet.ItemLineRet.ItemRef.FullName != null)
                                            {
                                                //get both sub and main item and combine item : Date 07-Feb-2017
                                                objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.SubItemOf = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.purchaseordercombineItem = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.TxnLineID = ORItemLineRet.ItemLineRet.TxnLineID.GetValue();
                                                //commented on 24-oct-2017
                                                //objPOLine.BarCodeValue = GetItemsBarCode(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()));
                                                objPOLine.VendorRefFullName = loPurchaseOrder.VendorRef.FullName.GetValue().ToString();


                                            }

                                        }
                                        if (ORItemLineRet.ItemLineRet.Quantity != null)
                                        {
                                            objPOLine.RecQty = Convert.ToDouble(ORItemLineRet.ItemLineRet.Quantity.GetValue());
                                            objPOLine.RefNumber = ponumber;

                                        }
                                        if (ORItemLineRet.ItemLineRet.Desc != null)
                                        {
                                            objPOLine.PurchaseOrderLineDesc = Convert.ToString(ORItemLineRet.ItemLineRet.Desc.GetValue());

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

                                        if (loPurchaseOrder.TimeCreated != null)
                                        {
                                            objPOLine.POReceivedItemCreatedTime = Convert.ToString(loPurchaseOrder.TimeCreated.GetValue());


                                        }
                                        //Custom fields for Item Receipt
                                        if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                        {
                                            for (int j = 0; j < ORItemLineRet.ItemLineRet.DataExtRetList.Count; j++)
                                            {
                                                IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(j);
                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                objreceiptcustomvalues.Add(new ReceiptItemCustomValues(objPOLine.TxnLineID, strdName, strdValue));

                                            }
                                        }

                                        //}

                                    }
                                    if (objPOLine.VendorRefFullName != null)
                                    {
                                        //Get match vendors items receipt data
                                        if (pstrVendorName.ToLower().Trim() == objPOLine.VendorRefFullName.ToString().ToLower().Trim())
                                        {

                                            objclspurchaseorder.Add(objPOLine);
                                        }
                                    }
                                   
                                }

                            }


                        }
                    }
                    else
                    {

                        lstrErrMsg = statusMessage;


                    }

                }
                pobjItemExtensions = objreceiptcustomvalues;
                return objclspurchaseorder;
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


        //Get Receipt by DateRange Search : Date 02-11-2015

        public List<clsPurchaseOrderLine> GetReceiptsByDateRange(string pstrStartDate, string pstrEndDate, out List<ReceiptItemCustomValues> pobjItemExtensions)
        {

            List<clsPurchaseOrderLine> objclspurchaseorder = new List<clsPurchaseOrderLine>();
            List<ReceiptItemCustomValues> objreceiptcustomvalues = new List<ReceiptItemCustomValues>();

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            ArrayList lobjarr = new ArrayList();

            string lstrErrMsg = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            //int statusCode = 0;
            //string statusMessage = string.Empty;
            //string statusSeverity = string.Empty;
            string strRefNumber = string.Empty;
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IItemReceiptQuery ItemReceiptQuery = default(IItemReceiptQuery);


                ItemReceiptQuery = lMsgRequest.AppendItemReceiptQueryRq();
                ItemReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                ItemReceiptQuery.IncludeLinkedTxns.SetValue(true);
                ItemReceiptQuery.IncludeLineItems.SetValue(true);

                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pstrStartDate));
                //Set field value for ToTxnDate
                ItemReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pstrEndDate));


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    IItemReceiptRetList loList = (IItemReceiptRetList)loResponse.Detail;
                    IItemReceiptRet loPurchaseOrder = default(IItemReceiptRet);


                    if (loList != null)
                    {

                        string ponumber = string.Empty;
                        string strdate = "";
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);

                            if (loPurchaseOrder.LinkedTxnList != null)
                            {
                                for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                                {
                                    ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);
                                    if (LinkedTxn.RefNumber != null)
                                    {

                                        strRefNumber = (string)LinkedTxn.RefNumber.GetValue();
                                     
                                        if (LinkedTxn.TxnDate != null)
                                        {
                                            strRefNumber = (string)LinkedTxn.RefNumber.GetValue();
                                            strdate =Convert.ToString(LinkedTxn.TxnDate.GetValue().ToString("MM-dd-yyyy"));
                                        }
                                    }
                                    

                                }

                            }
                            else
                            {
                                strRefNumber = string.Empty;
                                continue;
                            }

                            if (loPurchaseOrder.ORItemLineRetList != null)
                            {
                                for (int Itemlist = 0; Itemlist < loPurchaseOrder.ORItemLineRetList.Count; Itemlist++)
                                {
                                    IORItemLineRet ORItemLineRet = loPurchaseOrder.ORItemLineRetList.GetAt(Itemlist);
                                    clsPurchaseOrderLine objPOLine = new clsPurchaseOrderLine();
                                    objPOLine.TxnDate = strdate;
                                    if (ORItemLineRet.ItemLineRet != null)
                                    {

                                        //Get Trans ID - 23-Oct-2017
                                        objPOLine.TransID = loPurchaseOrder.TxnNumber.GetValue();

                                        //if (ORItemLineRet.ItemLineRet != null)
                                        //{
                                        if (ORItemLineRet.ItemLineRet.ItemRef != null)
                                        {
                                            if (ORItemLineRet.ItemLineRet.ItemRef.FullName != null)
                                            {
                                                //get both sub and main item and combine item : Date 07-Feb-2017
                                                objPOLine.PurchaseOrderLineItemRefFullName = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.SubItemOf = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());
                                                objPOLine.purchaseordercombineItem = Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue());

                                                objPOLine.BarCodeValue = GetItemsBarCode(Convert.ToString(ORItemLineRet.ItemLineRet.ItemRef.FullName.GetValue()));
                                                objPOLine.VendorRefFullName = loPurchaseOrder.VendorRef.FullName.GetValue().ToString();
                                                objPOLine.TxnLineID = ORItemLineRet.ItemLineRet.TxnLineID.GetValue();


                                            }

                                        }
                                        if (ORItemLineRet.ItemLineRet.Quantity != null)
                                        {
                                            objPOLine.RecQty = Convert.ToDouble(ORItemLineRet.ItemLineRet.Quantity.GetValue());
                                            objPOLine.RefNumber = strRefNumber;

                                        }
                                        if (ORItemLineRet.ItemLineRet.Desc != null)
                                        {
                                            objPOLine.PurchaseOrderLineDesc = Convert.ToString(ORItemLineRet.ItemLineRet.Desc.GetValue());

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

                                        if (loPurchaseOrder.TimeCreated != null)
                                        {
                                            objPOLine.POReceivedItemCreatedTime = Convert.ToString(loPurchaseOrder.TimeCreated.GetValue());


                                        }

                                        //Custom fields for Item Receipt
                                        if (ORItemLineRet.ItemLineRet.DataExtRetList != null)
                                        {
                                            for (int j = 0; j < ORItemLineRet.ItemLineRet.DataExtRetList.Count; j++)
                                            {
                                                IDataExtRet DataExtRet = ORItemLineRet.ItemLineRet.DataExtRetList.GetAt(j);
                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());

                                                objreceiptcustomvalues.Add(new ReceiptItemCustomValues(objPOLine.TxnLineID, strdName, strdValue));

                                            }
                                        }


                                        //}

                                    }
                                    objclspurchaseorder.Add(objPOLine);

                                    //if (objPOLine.VendorRefFullName != null)
                                    //{
                                    //    //Get match vendors items receipt data
                                    //    //if (pstrVendorName.ToLower().Trim() == objPOLine.VendorRefFullName.ToString().ToLower().Trim())
                                    //    //{

                                    //    //    objclspurchaseorder.Add(objPOLine);
                                    //    //}
                                    //}

                                }

                            }


                        }
                    }
                    //else
                    //{

                    //    lstrErrMsg = statusMessage;


                    //}

                }
                pobjItemExtensions = objreceiptcustomvalues;

                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
                return objclspurchaseorder;
            }
            catch (Exception)
            {
                if ((lQBSessionManager != null))
                {
                    lQBSessionManager.EndSession();
                    lQBSessionManager.CloseConnection();
                }
                throw ;              
            }     
          

            
        }

        // Get Vendors List:Date 06-10-2017
        public string WriteVendorToXml(string pstrApplicationPath)
        {
            string lstrvendorname = string.Empty;
            string lstrVendorDownloadcount = string.Empty;
            // ArrayList lstVendor = new ArrayList();
            int lproductcount = 0;
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
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorQuery IVendorsQuery = default(IVendorQuery);

                IVendorsQuery = lMsgRequest.AppendVendorQueryRq();

                IVendorsQuery.ORVendorListQuery.VendorListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

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
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IVendorRetList loList = (IVendorRetList)loResponse.Detail;
                    IVendorRet lovendors = default(IVendorRet);



                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            lovendors = loList.GetAt(Index);

                            if (lovendors.Name != null)
                            // lstVendor.Add(Convert.ToString(lovendors.Name.GetValue()));
                            {
                                //Insert vendor to xml textwriter object
                                createVendorNode(Convert.ToString(lovendors.Name.GetValue()), objXmlTextWriter);
                                lproductcount++;
                            }

                        }

                        //close xmlwriter object
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteEndDocument();
                        objXmlTextWriter.Flush();
                        objXmlTextWriter.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                //throw;
                return null;
            }

            lstrVendorDownloadcount = Convert.ToString(lproductcount);
            return lstrVendorDownloadcount;


        }


        private void createVendorNode(string clsobjvendor, XmlTextWriter writer)
        {
            writer.WriteStartElement("Vendor");
            writer.WriteStartElement("vendorname"); //1
            writer.WriteString(clsobjvendor.ToString());  //1
            writer.WriteEndElement(); //1

            writer.WriteEndElement();

        }


    }
}
