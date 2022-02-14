using System;
using System.Collections.Generic;
using System.Text;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Collections;
using System.Windows.Forms;
using LabelConnector;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

namespace QBLC
{
    class clsInvoiceLine
    {
        double _dblInvoiceLineQuantity;
        string _strInvoiceLineUnitOfMeasure;
        string _strInvoiceLineItemRefFullName;
        string _strInvoiceLineDesc;
        string _strInvoiceLineTxnLineID;
        string _strRefNumber;
        string _dtTxnDate;
        string _strBillAddressAddr1;
        string _strShipAddressAddr1;
        string _strShipAddressAddr2;
        string _strShipAddressAddr3;
        string _strShipAddressAddr4;
        string _strShipAddressAddr5;
        string _strShipAddressCity;
        string _stringShipAddressMethod;
        string _strShipAddressState;
        string _strShipAddressPostalCode;
        string _strShipDate;
        string _strBillAddressAddr2;
        string _strBillAddress;
        string _strOther;
        string _strcitystatezip;

        string _strLotNumber;
        string _strSerialNumber;
        private bool _IsValueFound = false;

        private bool _IsAuto = false;

        string _strShipAddressCountry;

        //Add Vendor
        string _strPrefVendorRefFullName;

        string _strLinkTxnRefNumber;
        //To show Room in the invoice
        string _strCustomFieldOther;
        //  string _strRoom;
        string _strCustomFieldInvoiceLineOther1;
        //  string _strRoom;
        string _strCustomFieldInvoiceLineOther2;
        string _strInvoiceItemName;
        //  string _strRoom;
        string _strPONumber;
        string _strFOB;
        string _InvoiceLineQuantityOnLabel;
        string _strShipAddressAddrPostalCode;
        double _InvoiceQuantity;
        double _dblpackperunits;
        string _dblInvoiceLineRate;
        string _dblInvoiceLineAmount;
        string _strSalesRepRef;
        string _strManufacturerPartNumber;
        string _strCustomerRefFullName;
        string _strBarCodeValue;
        string _strSubItemof;

        public double InvoiceLineQuantity
        {
            get
            {
                return _dblInvoiceLineQuantity;
            }
            set
            {
                _dblInvoiceLineQuantity = value;
            }
        }

        public string SubItemof
        {
            get
            {
                return _strSubItemof;
            }
            set
            {
                _strSubItemof = value.IndexOf(':') > -1 ? value.Substring(0, value.LastIndexOf(':')) : "";
            }
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
        public string CustomerRefFullName
        {
            get { return _strCustomerRefFullName; }
            set { _strCustomerRefFullName = value; }

        }

        public string MPN
        {
            get { return _strManufacturerPartNumber; }
            set { _strManufacturerPartNumber = value; }
        }

        public double InvoiceQuantity
        {
            get
            {

                return _InvoiceQuantity;
            }
            set
            {
                _InvoiceQuantity = value;
            }


        }

        public double PackPerUnits
        {

            get { return _dblpackperunits; }
            set { _dblpackperunits = value; }
        }

        public string QtyOnLabel
        {
            get
            {
                return _InvoiceLineQuantityOnLabel;
            }
            set
            {
                _InvoiceLineQuantityOnLabel = value;
            }
        }
        public string PONumber
        {
            get { return _strPONumber; }
            set { _strPONumber = value; }
        }


        public string InvoiceLineUnitOfMeasure
        {
            get
            {
                return _strInvoiceLineUnitOfMeasure;
            }

            set
            {
                _strInvoiceLineUnitOfMeasure = value == null ? "" : value;
            }
        }
        public string InvoiceLineItemRefFullName
        {
            get
            {
                return _strInvoiceLineItemRefFullName;
            }
            set
            {
                _strInvoiceLineItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
            }
        }
        public string GroupItemType
        {
            get; set;
        }
        public string InvoiceItemName
        {
            get { return _strInvoiceItemName; }
            set { _strInvoiceItemName = value; }
        }
        public string InvoiceLineDesc
        {
            get
            {
                return _strInvoiceLineDesc;
            }
            set
            {
                _strInvoiceLineDesc = value;
            }
        }

        public string InvoiceLineLotNumber
        {
            get
            {
                return _strLotNumber;
            }
            set
            {
                _strLotNumber = value;
            }
        }
        public string SerialNumber
        {
            get
            {
                return _strSerialNumber;
            }
            set
            {
                _strSerialNumber = value;
            }

        }

        public string InvoiceLineRate
        {
            get
            {
                return _dblInvoiceLineRate;
            }
            set
            {
                _dblInvoiceLineRate = value;
            }
        }

        public string InvoiceLineAmount
        {
            get
            {
                return _dblInvoiceLineAmount;
            }
            set
            {
                _dblInvoiceLineAmount = value;
            }
        }

        public string Other1
        {
            get
            {
                return _strCustomFieldInvoiceLineOther1;
            }
            set
            {
                _strCustomFieldInvoiceLineOther1 = value;
            }
        }

        public string InvoiceLineTxnLineID
        {
            get
            {
                return _strInvoiceLineTxnLineID;
            }
            set
            {
                _strInvoiceLineTxnLineID = value;
            }
        }
        public string RefNumber
        {
            get
            {
                return _strRefNumber;
            }
            set
            {
                _strRefNumber = value;
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

        public string BillAddressAddr1
        {
            get
            {
                return _strBillAddressAddr1;
            }
            set
            {
                _strBillAddressAddr1 = value;
            }
        }

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

        public string ShipAddressMethod
        {
            get { return _stringShipAddressMethod; }
            set { _stringShipAddressMethod = value; }
        }

        public string PrefVendorRefFullName
        {
            get
            {
                return _strPrefVendorRefFullName;
            }
            set
            {
                _strPrefVendorRefFullName = value;
            }
        }

        public string LinkTxnRefNumber
        {
            get
            {
                return _strLinkTxnRefNumber;
            }
            set
            {
                _strLinkTxnRefNumber = value;
            }
        }

        public string CustomFieldOther
        {
            get
            {
                return _strCustomFieldOther;
            }
            set
            {
                _strCustomFieldOther = value;
            }
        }
        public string CustomFieldInvoiceLineOther1
        {
            get
            {
                return _strCustomFieldInvoiceLineOther1;
            }
            set
            {
                _strCustomFieldInvoiceLineOther1 = value;
            }
        }
        public string CustomFieldInvoiceLineOther2
        {
            get
            {
                return _strCustomFieldInvoiceLineOther2;
            }
            set
            {
                _strCustomFieldInvoiceLineOther2 = value;
            }
        }

        public string BillAddressAddr2
        {
            get
            {
                return _strBillAddressAddr2;
            }
            set
            {
                _strBillAddressAddr2 = value;
            }
        }
        public string FOB
        {
            get
            {
                return _strFOB;
            }
            set
            {
                _strFOB = value;
            }
        }

        public string Other
        {
            get
            {
                return _strOther;
            }
            set
            {
                _strOther = value;
            }
        }

        public string SalesRepRef
        {
            get
            {
                return _strSalesRepRef;
            }
            set
            {
                _strSalesRepRef = value;
            }
        }


        public string BillAddress
        {

            get { return _strBillAddress; }
            set { _strBillAddress = value; }
        }



        public string ShipDate
        {
            get { return _strShipDate; }
            set { _strShipDate = value; }

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


        public bool IsValueFound
        {
            get { return _IsValueFound; }
            set { _IsValueFound = value; }
        }
        public bool IsAuto
        {
            get { return _IsAuto; }
            set { _IsAuto = value; }
        }

        //commented on 09-09-2016
        //public ArrayList GetFilterInvoiceForPrint(string strstartdate, string strenddate)
        //{
        //    ArrayList alInvoicesLine = new ArrayList();
        //    string strTxnLineID = string.Empty;

        //    QBSessionManager lQBSessionManager = null;
        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //        IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

        //        InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
        //        InvoiceQuery.IncludeLineItems.SetValue(true);
        //        //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);

        //        InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
        //        InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

        //        if (lMsgResponse.ResponseList.Count > 0)
        //        {
        //            //we have one response for  single add request
        //            IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
        //            IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
        //            IInvoiceRet loInvoice = default(IInvoiceRet);
        //            IInvoiceLineRet loInvoiceLineRetItem = null;
        //            IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
        //            clsInvoiceLine lobjclsInvoiceLine = null;

        //            if (loList != null)
        //            {
        //                for (int Index = 0; Index < loList.Count; Index++)
        //                {
        //                    loInvoice = loList.GetAt(Index);

        //                    for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
        //                    {
        //                        if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
        //                        {
        //                            loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
        //                            lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem,string.Empty,string.Empty);
        //                            //Below condition to not show item if it is empty
        //                            if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "")
        //                            {
        //                                lobjclsInvoiceLine.RefNumber = loInvoice.RefNumber.GetValue();
        //                                alInvoicesLine.Add(lobjclsInvoiceLine);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
        //                            lobjclsInvoiceLine = new clsInvoiceLine();
        //                            lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
        //                            //Below condition to not show item if it is empty
        //                            if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty)
        //                            {
        //                                lobjclsInvoiceLine.RefNumber = loInvoice.RefNumber.GetValue();
        //                                alInvoicesLine.Add(lobjclsInvoiceLine);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return alInvoicesLine;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //        return null;
        //    }
        //    finally
        //    {
        //        if ((lQBSessionManager != null))
        //        {
        //            lQBSessionManager.EndSession();
        //            lQBSessionManager.CloseConnection();
        //        }
        //    }
        //}

        //change method to get custom item fields for ranged invoices
        public ArrayList GetFilterInvoiceByItemCustomField(string strstartdate, string strenddate, string strConfigItemCustomField, bool isdefalutqtyoption, out List<Itemcustomfields> pobjItemExtensions, out List<Itemcustomfields> pobjPrintcustomExt)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            bool blnfieldexist = false;
            bool blnprintfield = false;
            bool IsItemIncludetoprint = false;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            List<Itemcustomfields> list = new List<Itemcustomfields>();
            List<Itemcustomfields> listforprint = new List<Itemcustomfields>();

            QBSessionManager lQBSessionManager = null;

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.OwnerIDList.Add("0"); //to show all fields
                InvoiceQuery.IncludeLineItems.SetValue(true);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;



                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    IsItemIncludetoprint = false;
                                    blnprintfield = false;
                                    lobjclsInvoiceLine = GetDateRangeInvoiceItems(loInvoiceLineRetItem, isdefalutqtyoption, string.Empty, string.Empty);
                                    //filter item when itemname not exist
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName == "" || lobjclsInvoiceLine.InvoiceLineQuantity == 0)
                                    {
                                        continue;
                                    }
                                    lobjclsInvoiceLine.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                                    lobjclsInvoiceLine.TxnDate = Convert.ToString(loInvoice.TxnDate.GetValue().ToString("MM-dd-yyyy"));

                                    if (loInvoice.PONumber != null)
                                    {
                                        lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                    }


                                    if (loInvoice.ShipAddress != null)
                                    {
                                        if (loInvoice.ShipAddress.Addr1 != null) lobjclsInvoiceLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());
                                        if (loInvoice.ShipAddress.Addr2 != null) lobjclsInvoiceLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());
                                        if (loInvoice.ShipAddress.Addr3 != null) lobjclsInvoiceLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());
                                        if (loInvoice.ShipAddress.Addr4 != null) lobjclsInvoiceLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());
                                        if (loInvoice.ShipAddress.Addr5 != null) lobjclsInvoiceLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());
                                        if (loInvoice.ShipAddress.City != null) lobjclsInvoiceLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                        if (loInvoice.ShipAddress.State != null) lobjclsInvoiceLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());
                                        if (loInvoice.ShipAddress.PostalCode != null) lobjclsInvoiceLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());
                                        if (loInvoice.ShipAddress.Country != null) lobjclsInvoiceLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                        if (loInvoice.ShipMethodRef != null) lobjclsInvoiceLine.ShipAddressMethod = Convert.ToString(loInvoice.ShipMethodRef.FullName.GetValue());
                                        if (loInvoice.ShipDate != null) lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());
                                        //citystatezip field added:Date 30-APR-2019
                                        if (!string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressState) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressPostalCode))
                                        {
                                            lobjclsInvoiceLine.citystatezip += lobjclsInvoiceLine.ShipAddressCity + " " + lobjclsInvoiceLine.ShipAddressState + " " + lobjclsInvoiceLine.ShipAddressPostalCode;
                                        }
                                    }

                                    if (loInvoice.BillAddress != null)
                                    {
                                        if (loInvoice.BillAddress.Addr1 != null) lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                                        if (loInvoice.BillAddress.Addr2 != null) lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                    }
                                    if (loInvoice.FOB != null)
                                    {
                                        lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                    }

                                    ////Get Customer Name from invoice:16-Jun-2019
                                    //if(loInvoice.CustomerMsgRef !=null)
                                    // {
                                    //    if(loInvoice.CustomerMsgRef.FullName !=null)
                                    //    {
                                    //        lobjclsInvoiceLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerMsgRef.FullName.GetValue());
                                    //    }

                                    // }

                                    //if (loInvoice.BillAddress != null)
                                    //{
                                    //    if (loInvoice.BillAddress.Addr1 != null)
                                    //        lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());

                                    //    if (loInvoice.BillAddress.Addr2 != null)
                                    //        lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                    //    if (loInvoice.BillAddress.Addr3 != null)
                                    //        lobjclsInvoiceLine.BillAddressAddr3 = Convert.ToString(loInvoice.BillAddress.Addr3.GetValue());

                                    //    if (loInvoice.BillAddress.Addr4 != null)
                                    //        lobjclsInvoiceLine.BillAddressAddr4 = Convert.ToString(loInvoice.BillAddress.Addr4.GetValue());

                                    //    if (loInvoice.BillAddress.Addr5 != null)
                                    //        lobjclsInvoiceLine.BillAddressAddr5 = Convert.ToString(loInvoice.BillAddress.Addr5.GetValue());

                                    //    if (loInvoice.BillAddress.City != null)
                                    //        lobjclsInvoiceLine.BillAddressCity = Convert.ToString(loInvoice.BillAddress.City.GetValue());

                                    //    if (loInvoice.BillAddress.State != null)
                                    //        lobjclsInvoiceLine.BillAddressState = Convert.ToString(loInvoice.BillAddress.State.GetValue());

                                    //    if (loInvoice.BillAddress.PostalCode != null)
                                    //        lobjclsInvoiceLine.BillAddressPostalCode = Convert.ToString(loInvoice.BillAddress.PostalCode.GetValue());

                                    //    if (loInvoice.BillAddress.Country != null)
                                    //        lobjclsInvoiceLine.BillAddressCountry = Convert.ToString(loInvoice.BillAddress.Country.GetValue());

                                    //}   
                                    //if (loInvoice.Other != null)
                                    //{
                                    //    lobjclsInvoiceLine.CustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());

                                    //}

                                    //if (loInvoice.SalesTaxTotal != null)
                                    //    lobjclsInvoiceLine._dblSalesTaxTotal = string.Format("{0:N}", loInvoice.SalesTaxTotal.GetValue());
                                    //if (loInvoice.BalanceRemaining != null)
                                    //    lobjclsInvoiceLine._dblBalanceRemaining = string.Format("{0:N}", loInvoice.BalanceRemaining.GetValue());



                                    //----------------------------------------- Custom Field Logic ------------------------------------
                                    lobjIItemQuery = default(IItemQuery);
                                    lMsgItemsRequest.ClearRequests();

                                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                    lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                    lobjIItemQuery.OwnerIDList.Add("0");
                                    // lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains); //22-July-2019
                                    // lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine.InvoiceItemName); //_strInvoiceLineItemRefFullName
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                    //Set field value for ToName
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceItemName);

                                    lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                    if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                    {
                                        lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                        if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                        {
                                            if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                            {
                                                lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                {
                                                    lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                    for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                    {
                                                        lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                        if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                    //for printing
                                                                    foreach (var item in listforprint)
                                                                    {
                                                                        if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()) && item.CustItemRefNumber.ToLower().Equals(lobjclsInvoiceLine.RefNumber.ToLower()))
                                                                        {
                                                                            blnprintfield = true;
                                                                            break;
                                                                        }

                                                                    }
                                                                    if (blnprintfield == false)
                                                                    {

                                                                        listforprint.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));

                                                                    }


                                                                    //for comparision
                                                                    //skip item having print label field value 'NO'
                                                                    if (strdName.ToUpper() == "PRINTLABEL" && strdValue.ToUpper() == "YES")
                                                                    {
                                                                        IsItemIncludetoprint = true;
                                                                    }
                                                                    if (blnfieldexist == false)
                                                                    {
                                                                        if (strdName == strConfigItemCustomField) //filter item by  item custom field
                                                                        {
                                                                            list.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        }

                                                                    }


                                                                }
                                                            }
                                                        }
                                                        else if (lobjIORItemRet.ItemInventoryRet != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                    //for printing
                                                                    foreach (var item in listforprint)
                                                                    {
                                                                        if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()) && item.CustItemRefNumber.ToLower().Equals(lobjclsInvoiceLine.RefNumber.ToLower()))
                                                                        {
                                                                            blnprintfield = true;
                                                                            break;
                                                                        }

                                                                    }
                                                                    if (blnprintfield == false)
                                                                    {

                                                                        listforprint.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));

                                                                    }

                                                                    //for comparision
                                                                    if (strdName.ToUpper() == "PRINTLABEL" && strdValue.ToUpper() == "YES")
                                                                    {
                                                                        IsItemIncludetoprint = true;
                                                                    }
                                                                    if (blnfieldexist == false)
                                                                    {
                                                                        if (strdName == strConfigItemCustomField) //filter item by  item custom field
                                                                        {
                                                                            list.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        }

                                                                    }



                                                                }
                                                            }


                                                        }
                                                        //Add non inventory Item custom field from items
                                                        else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                    //for printing
                                                                    foreach (var item in listforprint)
                                                                    {
                                                                        if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()) && item.CustItemRefNumber.ToLower().Equals(lobjclsInvoiceLine.RefNumber.ToLower()))
                                                                        {
                                                                            blnprintfield = true;
                                                                            break;
                                                                        }

                                                                    }
                                                                    if (blnprintfield == false)
                                                                    {

                                                                        listforprint.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));

                                                                    }

                                                                    //for comparison
                                                                    if (strdName.ToUpper() == "PRINTLABEL" && strdValue.ToUpper() == "YES")
                                                                    {
                                                                        IsItemIncludetoprint = true;
                                                                    }
                                                                    if (blnfieldexist == false)
                                                                    {
                                                                        if (strdName == strConfigItemCustomField) //filter item by  item custom field
                                                                        {
                                                                            list.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        }

                                                                    }

                                                                }
                                                            }

                                                        }
                                                        //support service item:Date 16-July-2019
                                                        else if (lobjIORItemRet.ItemServiceRet != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemServiceRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                    //for printing
                                                                    foreach (var item in listforprint)
                                                                    {
                                                                        if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()) && item.CustItemRefNumber.ToLower().Equals(lobjclsInvoiceLine.RefNumber.ToLower()))
                                                                        {
                                                                            blnprintfield = true;
                                                                            break;
                                                                        }

                                                                    }
                                                                    if (blnprintfield == false)
                                                                    {

                                                                        listforprint.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));

                                                                    }

                                                                    //for comparison
                                                                    if (strdName.ToUpper() == "PRINTLABEL" && strdValue.ToUpper() == "YES")
                                                                    {
                                                                        IsItemIncludetoprint = true;
                                                                    }
                                                                    if (blnfieldexist == false)
                                                                    {
                                                                        if (strdName == strConfigItemCustomField) //filter item by  item custom field
                                                                        {
                                                                            list.Add(new Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
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

                                    //Add custom field from invoice
                                    IORInvoiceLineRet lobjIDataExtRetList1 = loInvoice.ORInvoiceLineRetList.GetAt(intLine);

                                    if (lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList != null)
                                    {
                                        for (int k = 0; k < lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.Count; k++)
                                        {
                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.GetAt(k);


                                            strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim();
                                            //Get value of DataExtType
                                            ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                            //Get value of DataExtValue
                                            strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                            {
                                                lobjItemExtensions.Add(strdName, strdValue);
                                            }
                                            else
                                            {
                                                //update key/value
                                                lobjItemExtensions.Remove(strdName);
                                                lobjItemExtensions.Add(strdName, strdValue);


                                            }

                                        }
                                    }
                                    if (IsItemIncludetoprint == true)
                                    {
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }


                                    //------------------------------- Custom Fields Logic ---------------------------------//
                                }// match if condition end




                            }


                        }

                    }
                }
                // pobjItemExtensions = lobjItemExtensions;
                pobjItemExtensions = list;
                pobjPrintcustomExt = listforprint;

                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                pobjItemExtensions = null;
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

        //shows inv data
        public ArrayList GetFilterInvoiceForPrint(string strstartdate, string strenddate, out List<Dictionary<string, string>> pobjItemExtensions)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            List<Dictionary<string, string>> objcustvalue = new List<Dictionary<string, string>>();
            QBSessionManager lQBSessionManager = null;

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                InvoiceQuery.OwnerIDList.Add("0"); //to show all fields
                InvoiceQuery.IncludeLineItems.SetValue(true);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;



                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    ICustomerRetList lobjICustomerRetList = null;
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;

                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //filter item when itemname not exist
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName == "" || lobjclsInvoiceLine.InvoiceLineQuantity == 0)
                                    {
                                        continue;
                                    }

                                    IItemOtherChargeRetList loList1 = null;
                                    if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnableotherchargesfields").ToString() == "0"))
                                    {
                                        OtherChargeQueryRq.OwnerIDList.Add("0");
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceLineItemRefFullName);
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceLineItemRefFullName);
                                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                    IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                     loList1 = (IItemOtherChargeRetList)loResponse2.Detail;
                                    }
                                    if (loList1 == null)
                                    {
                                        lobjclsInvoiceLine.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                                        lobjclsInvoiceLine.TxnDate = Convert.ToString(loInvoice.TxnDate.GetValue().ToString("MM-dd-yyyy"));

                                        if (loInvoice.PONumber != null)
                                        {
                                            lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                        }
                                        if (loInvoice.Other != null)
                                        {
                                            lobjclsInvoiceLine.Other = Convert.ToString(loInvoice.Other.GetValue());

                                        }
                                        if (loInvoice.CustomerRef != null)
                                        {
                                            lobjclsInvoiceLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
                                        }
                                        else
                                        {
                                            lobjclsInvoiceLine.Other = string.Empty;
                                        }

                                        if (loInvoice.ShipAddress != null)
                                        {
                                            if (loInvoice.ShipAddress.Addr1 != null) lobjclsInvoiceLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());
                                            if (loInvoice.ShipAddress.Addr2 != null) lobjclsInvoiceLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());
                                            if (loInvoice.ShipAddress.Addr3 != null) lobjclsInvoiceLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());
                                            if (loInvoice.ShipAddress.Addr4 != null) lobjclsInvoiceLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());
                                            if (loInvoice.ShipAddress.Addr5 != null) lobjclsInvoiceLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());
                                            if (loInvoice.ShipAddress.City != null) lobjclsInvoiceLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                            if (loInvoice.ShipAddress.State != null) lobjclsInvoiceLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());
                                            if (loInvoice.ShipAddress.PostalCode != null) lobjclsInvoiceLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());
                                            if (loInvoice.ShipAddress.Country != null) lobjclsInvoiceLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                            if (loInvoice.ShipMethodRef != null) lobjclsInvoiceLine.ShipAddressMethod = Convert.ToString(loInvoice.ShipMethodRef.FullName.GetValue());
                                            if (loInvoice.ShipDate != null) lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());
                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressState) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressPostalCode))
                                            {
                                                lobjclsInvoiceLine.citystatezip += lobjclsInvoiceLine.ShipAddressCity + " " + lobjclsInvoiceLine.ShipAddressState + " " + lobjclsInvoiceLine.ShipAddressPostalCode;
                                            }
                                        }

                                        if (loInvoice.BillAddress != null)
                                        {
                                            if (loInvoice.BillAddress.Addr1 != null) lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                                            if (loInvoice.BillAddress.Addr2 != null) lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                        }
                                        if (loInvoice.FOB != null)
                                        {
                                            lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                        }

                                        if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1"))
                                        {

                                            //----------------------------------------- Custom Field Logic ------------------------------------
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine.InvoiceItemName); //_strInvoiceLineItemRefFullName


                                            lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                            if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                            {
                                                lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                                if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                                {
                                                    if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                    {
                                                        lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                        lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                        if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                        {
                                                            lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                            for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                            {
                                                                lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                                if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                                {
                                                                    lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                    if (lobjIDataExtRetList != null)
                                                                    {
                                                                        for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                        {
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                            strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                lobjItemExtensions.Add(strdName, strdValue);


                                                                        }
                                                                    }
                                                                }
                                                                else if (lobjIORItemRet.ItemInventoryRet != null)
                                                                {
                                                                    lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                    if (lobjIDataExtRetList != null)
                                                                    {
                                                                        for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                        {
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                            strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                lobjItemExtensions.Add(strdName, strdValue);




                                                                        }
                                                                    }


                                                                }
                                                                //Add non inventory Item custom field from items
                                                                else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                                {
                                                                    lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                                    if (lobjIDataExtRetList != null)
                                                                    {
                                                                        for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                        {
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                            strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                lobjItemExtensions.Add(strdName, strdValue);


                                                                        }
                                                                    }

                                                                }





                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //Add custom field from invoice
                                            IORInvoiceLineRet lobjIDataExtRetList1 = loInvoice.ORInvoiceLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.GetAt(k);


                                                    strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim();
                                                    //Get value of DataExtType
                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjItemExtensions.ContainsKey(strdName))
                                                    {
                                                        lobjItemExtensions.Add(strdName, strdValue);
                                                    }
                                                    else
                                                    {
                                                        //update key/value
                                                        lobjItemExtensions.Remove(strdName);
                                                        lobjItemExtensions.Add(strdName, strdValue);


                                                    }

                                                }
                                            }

                                            if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                            {
                                                ICustomerQuery CustomerQuery = default(ICustomerQuery);
                                                lMsgRequest.ClearRequests();
                                                CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                                                CustomerQuery.OwnerIDList.Add("0");
                                                CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.CustomerRefFullName);
                                                lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                                if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                                {
                                                    lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                                    lobjICustomerRetList = (ICustomerRetList)lobjIResponse.Detail;
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
                                                }
                                            }

                                            if (lobjItemExtensions.Count != 0)
                                            {
                                                string refvalue = lobjclsInvoiceLine.RefNumber + "&" + lobjclsInvoiceLine.InvoiceLineTxnLineID;
                                                lobjItemExtensions.Add("refnumber", refvalue);
                                                objcustvalue.Add(lobjItemExtensions);
                                                lobjItemExtensions = new Dictionary<string, string>();

                                            }

                                        }
                                        alInvoicesLine.Add(lobjclsInvoiceLine);

                                    }


                                    //------------------------------- Custom Fields Logic ---------------------------------//
                                }// match if condition end




                            }


                        }

                    }
                }
                pobjItemExtensions = objcustvalue;

                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                pobjItemExtensions = null;
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



        public ArrayList GetINVLine(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
                                    lobjclsInvoiceLine = new clsInvoiceLine();
                                    lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }
                            }
                        }
                    }
                }
                return alInvoicesLine;
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

        public ArrayList GetINVLine(string strRefNumber, string strpackperunitvalue, string strqbqtypercontainervalue)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
               
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.OwnerIDList.Add("0");
                InvoiceQuery.IncludeLineItems.SetValue(true);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
               
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);

                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        //Get pack/units for inventory items : date 13-Feb-2017
                                        if (strpackperunitvalue.ToUpper() == "Y")
                                        {

                                            lobjclsInvoiceLine.PackPerUnits = GetPackperUnitsInventoryItem(lobjclsInvoiceLine.InvoiceItemName, strqbqtypercontainervalue);
                                        }
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }


                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
                                    lobjclsInvoiceLine = new clsInvoiceLine();
                                    lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        //Get pack/units for inventory items : date 13-Feb-2017
                                        if (strpackperunitvalue.ToUpper() == "Y")
                                        {
                                            lobjclsInvoiceLine.PackPerUnits = GetPackperUnitsGroupItem(lobjclsInvoiceLine.InvoiceLineItemRefFullName, strqbqtypercontainervalue);
                                        }
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }


                            }
                        }
                    }
                }

                return alInvoicesLine;
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

        public ArrayList GetINVLinePrintLabelRecords(string strRefNumber, string pstrprintlabelconfigvalue, out List<KeyValuePair<string, string>> pobjserialnumberlist)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            bool isprintlabelyes = false;
            List<KeyValuePair<string, string>> listserialno = new List<KeyValuePair<string, string>>();
            List<string> lstprintlablelist = new List<string>();
            bool othercharge = true;
            Dictionary<string, string> lstchecklabellist = new Dictionary<string, string>();
          
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
             
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                InvoiceQuery.OwnerIDList.Add("0");
                InvoiceQuery.IncludeLineItems.SetValue(true);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;

                    clsInvoiceLine lobjclsInvoiceLine = null;


                    IItemQuery lobjIItemQuery = null; //#
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                //isprintlabelyes = false;
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet != null)
                                {
                                    if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet != null)
                                    {
                                        lobjclsInvoiceLine = new clsInvoiceLine();


                                        loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;

                                        lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                        //Below condition to not show item if it is empty
                                        if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty)
                                        {
                                            lobjclsInvoiceLine.RefNumber = strRefNumber;

                                            alInvoicesLine.Add(lobjclsInvoiceLine);
                                          
                                        }

                                        for (int grpitem = 0; grpitem < loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet.InvoiceLineRetList.Count; grpitem++)
                                        {
                                            lobjclsInvoiceLine = new clsInvoiceLine();
                                            IInvoiceLineRet InvoiceLineRat = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet.InvoiceLineRetList.GetAt(grpitem);
                                            lobjclsInvoiceLine = GetInvItem(InvoiceLineRat, string.Empty, string.Empty);
                                            if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                            {
                                                lobjclsInvoiceLine.RefNumber = strRefNumber;
                                                alInvoicesLine.Add(lobjclsInvoiceLine);
                                            }                                            
                                        }
                                    }
                                }
                                else
                                {
                                    if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                    {
                                        loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                        lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);


                                        IItemOtherChargeRetList loList1 = null;
                                        if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnableotherchargesfields").ToString() == "0"))
                                        {
                                            OtherChargeQueryRq.OwnerIDList.Add("0");
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceLineItemRefFullName);
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceLineItemRefFullName);
                                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                        IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                         loList1 = (IItemOtherChargeRetList)loResponse2.Detail;
                                        }
                                        if (loList1 == null)
                                        {
                                            othercharge = true;
                                        }
                                        else
                                        {
                                            othercharge = false;
                                        }
                                        //Below condition to not show item if it is empty
                                        if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                        {
                                            lobjclsInvoiceLine.RefNumber = strRefNumber;

                                           
                                            if (!string.IsNullOrWhiteSpace(lobjclsInvoiceLine.SerialNumber))
                                            {

                                                listserialno.Add(new KeyValuePair<string, string>(lobjclsInvoiceLine.InvoiceItemName, lobjclsInvoiceLine.SerialNumber));
                                                

                                            }

                                        }


                                    }
                                    else
                                    {
                                        loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
                                        lobjclsInvoiceLine = new clsInvoiceLine();
                                        lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                        //Below condition to not show item if it is empty
                                        if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                        {
                                            lobjclsInvoiceLine.RefNumber = strRefNumber;

                                         
                                        }
                                    }
                                   
                                    lobjIItemQuery = default(IItemQuery);
                                    lMsgItemsRequest.ClearRequests();

                                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                    lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                    lobjIItemQuery.OwnerIDList.Add("0");
                                   
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                    //Set field value for ToName
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                    lstchecklabellist.Clear();
                                    lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                    if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                    {
                                        lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                        if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                        {
                                            if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                            {
                                                lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                {
                                                    lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                    for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                    {
                                                        lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                        if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {

                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                   
                                                                    if (strdName.Trim() == pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper() && strdValue.ToUpper().Trim() == "YES")
                                                                    {
                                                                        isprintlabelyes = true;
                                                                       
                                                                        lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                    }
                                                                    else
                                                                    {
                                                                        isprintlabelyes = false;
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                isprintlabelyes = false;
                                                                if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                {
                                                                    lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                }
                                                            }
                                                        }
                                                        else if (lobjIORItemRet.ItemInventoryRet != null)
                                                        {
                                                            
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                    if (strdName.Trim() == pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper() && strdValue.ToUpper().Trim() == "YES")
                                                                    {
                                                                        isprintlabelyes = true;
                                                                       
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        isprintlabelyes = false;
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                isprintlabelyes = false;
                                                                if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                {
                                                                    lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                }
                                                            }


                                                        }
                                                        //Add non inventory Item custom field from items
                                                        else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                        {
                                                            //Get MPN Field : Date 029/11/2018
                                                            if (lobjIORItemRet.ItemNonInventoryRet.ManufacturerPartNumber != null)
                                                            {
                                                                lobjclsInvoiceLine.MPN = lobjIORItemRet.ItemNonInventoryRet.ManufacturerPartNumber.GetValue();
                                                            }
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                    if (strdName.Trim() == pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper() && strdValue.ToUpper().Trim() == "YES")
                                                                    {
                                                                        isprintlabelyes = true;
                                                                      
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        isprintlabelyes = false;
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            else
                                                            {
                                                                isprintlabelyes = false;
                                                                if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                {
                                                                    lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                }
                                                            }

                                                        }
                                                        //Add other charge item field support added:Date 02-APR-2019
                                                        else if (lobjIORItemRet.ItemOtherChargeRet != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemOtherChargeRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                    if (strdName.Trim() == pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper() && strdValue.ToUpper().Trim() == "YES")
                                                                    {
                                                                        isprintlabelyes = true;
                                                                        
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        isprintlabelyes = false;
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                isprintlabelyes = false;
                                                                if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                {
                                                                    lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                }
                                                            }

                                                        }
                                                        //service item custom field supported
                                                        else if (lobjIORItemRet.ItemServiceRet != null)
                                                        {
                                                            lobjIDataExtRetList = lobjIORItemRet.ItemServiceRet.DataExtRetList;
                                                            if (lobjIDataExtRetList != null)
                                                            {
                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                {
                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                    if (strdName.Trim() == pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper() && strdValue.ToUpper().Trim() == "YES")
                                                                    {
                                                                        isprintlabelyes = true;
                                                                     
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        isprintlabelyes = false;
                                                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                        {
                                                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                isprintlabelyes = false;
                                                                if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                                                {
                                                                    lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                                                }
                                                            }

                                                        }


                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            isprintlabelyes = false;
                                            if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                            {
                                                lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        isprintlabelyes = false;
                                        if (!lstchecklabellist.ContainsKey(strdName.Trim()))
                                        {
                                            lstchecklabellist.Add(strdName.Trim(), strdValue.ToUpper().Trim());
                                        }
                                    }

                                    if (isprintlabelyes == true)
                                    {

                                        if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0 && othercharge)
                                        {
                                            alInvoicesLine.Add(lobjclsInvoiceLine);
                                        }
                                    }
                                    // }//
                                    else
                                    {

                                       

                                        if (string.IsNullOrWhiteSpace(pstrprintlabelconfigvalue) || ContainsKeyValue(lstchecklabellist, pstrprintlabelconfigvalue.Replace(" ", string.Empty).ToUpper()))
                                        {


                                            if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "" && lobjclsInvoiceLine.InvoiceLineQuantity != 0 && othercharge)
                                            {
                                                //return all records
                                                alInvoicesLine.Add(lobjclsInvoiceLine);
                                            }


                                        }
                                    }


                                }

                            }
                        }
                    }
                }
             
                pobjserialnumberlist = listserialno;
                return alInvoicesLine;
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

        public bool ContainsKeyValue(Dictionary<string, string> dictionary, string expectedKey)
        {
            bool actualValue = false;
            string dictvalue = string.Empty;

            if (dictionary.ContainsKey(expectedKey)) //if field is print label and values is yes or null
            {
                if (dictionary.TryGetValue(expectedKey, out dictvalue))
                {
                    if (dictvalue == "YES")
                    {
                        actualValue = true;
                    }
                }

            }
            else
            {
                actualValue = true;
            }
            return actualValue;


        }


        public ArrayList GetINVLine(string lstrQuantityonLabel, string pstrVendorName, ArrayList strshipinfo, ArrayList strInvoiceInfo, string strRefNumber, string strInvoiceTxnLineID, DateTime dtTransactionDate, string strBillAddressAddr1, out Dictionary<string, string> pobjItemExtensions, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;

                
                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;

                    IMsgSetRequest lMsgItemsRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    if (loInvoiceLineRetItem.TxnLineID != null && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                    {
                                        lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        //Add from TP ver
                                        if (loInvoice.PONumber != null)
                                        {
                                            lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                        }
                                        else
                                        {

                                            lobjclsInvoiceLine.PONumber = string.Empty;
                                        }
                                        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            lobjclsInvoiceLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            lobjclsInvoiceLine.QtyOnLabel = string.Empty;
                                        }
                                        //Add lotnumber invoice info:Date 02/03/2015
                                        if (strInvoiceInfo != null)
                                        {
                                            foreach (clsInvoiceLine invItem in strInvoiceInfo)
                                            {
                                                if (invItem.InvoiceLineItemRefFullName.ToLower().Trim() == pstrVendorName.ToLower().Trim() && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == invItem.InvoiceLineTxnLineID)
                                                {
                                                    if (!string.IsNullOrEmpty(invItem.InvoiceLineLotNumber))
                                                    {
                                                        lobjclsInvoiceLine.InvoiceLineItemRefFullName = invItem.InvoiceLineItemRefFullName;
                                                        lobjclsInvoiceLine.CustomFieldInvoiceLineOther1 = invItem.CustomFieldInvoiceLineOther1;
                                                        lobjclsInvoiceLine.CustomFieldInvoiceLineOther2 = invItem.CustomFieldInvoiceLineOther2;
                                                        lobjclsInvoiceLine.InvoiceLineUnitOfMeasure = invItem.InvoiceLineUnitOfMeasure;
                                                        lobjclsInvoiceLine.InvoiceLineLotNumber = invItem.InvoiceLineLotNumber;
                                                    }
                                                }
                                            }
                                        }
                                        //To add shipAddress

                                        foreach (clsInvoice objInvoice in strshipinfo)
                                        {
                                            lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                            lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                            lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                            lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                            lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                            lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                            lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                            lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                            lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                            lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber;//To add s.o.no
                                            lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                            //To show Ship Address Method :Date 01/13/2015
                                            lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;

                                            //Get LotNumber bill address info
                                            lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                            lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                            lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;


                                        }


                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine._strInvoiceLineItemRefFullName);
                                        lobjIMsgSetResponse = pobjQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }
                                                                //Add Vendor to Invoice
                                                                // if (lobjIORItemRet.ItemInventoryRet.PrefVendorRef != null)
                                                                //   lobjItemExtensions.Add("PrefVendorRefFullName", lobjIORItemRet.ItemInventoryRet.PrefVendorRef.FullName.GetValue());



                                                            }

                                                            //Add non inventory Item custom field from items
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //------------------------------- Custom Fields Logic ---------------------------------//
                                    }
                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;

                                    if (loInvoiceLineGroupRet.TxnLineID != null && Convert.ToString(loInvoiceLineGroupRet.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                    {
                                        lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }

                                    //for (int intGroup = 0; intGroup < loInvoiceLineGroupRet.InvoiceLineRetList.Count; intGroup++)
                                    //{
                                    //    loInvoiceLineRetItem = loInvoiceLineGroupRet.InvoiceLineRetList.GetAt(intGroup);
                                    //    if (loInvoiceLineRetItem.TxnLineID != null && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                    //    {
                                    //        lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem);
                                    //        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                    //        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                    //        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;
                                    //        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    //    }
                                    //}
                                }

                                //lobjIInvoiceQuery = default(IInvoiceQuery);
                                //lMsgItemsRequest.ClearRequests();

                                //lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                //lobjIInvoiceQuery = lMsgItemsRequest.AppendInvoiceQueryRq();
                                //lobjIInvoiceQuery.OwnerIDList.Add("0");
                                //lobjIInvoiceQuery.ORInvoiceQuery.RefNumberList.Add(lobjclsInvoiceLine._strRefNumber);
                                //lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);
                                //if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                //{
                                //    lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                //    if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                //    {
                                //        if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                //        {
                                //            lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                //            lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                //            if (lobjResponseType == ENResponseType.rtInvoiceQueryRs && lobjResponseDetailType == ENObjectType.otInvoiceRetList)
                                //            {
                                //                lobjIORInvoiceLineRetList = (IORInvoiceLineRetList)lobjIResponse.Detail;
                                //                for (int i = 0; i < lobjIORInvoiceLineRetList.Count; i++)
                                //                {
                                //                    lobjIORInvoiceLineRet = lobjIORInvoiceLineRetList.GetAt(i);
                                //                    if (lobjIORInvoiceLineRet != null && lobjIORInvoiceLineRet.InvoiceLineRet != null && lobjIORInvoiceLineRet.InvoiceLineRet.DataExtRetList != null)
                                //                    {
                                //                        lobjIDataExtRetList = lobjIORInvoiceLineRet.InvoiceLineRet.DataExtRetList;
                                //                    }
                                //                    else if (lobjIORInvoiceLineRet != null && lobjIORInvoiceLineRet.InvoiceLineGroupRet != null && lobjIORInvoiceLineRet.InvoiceLineGroupRet.DataExtRetList != null)
                                //                    {
                                //                        lobjIDataExtRetList = lobjIORInvoiceLineRet.InvoiceLineGroupRet.DataExtRetList;
                                //                    }

                                //                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                //                    {
                                //                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue());
                                //                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                //                        lobjItemExtensions.Add(strdName, strdValue);
                                //                    }
                                //                }
                                //            }
                                //        }
                                //    }
                                //}





                            }
                        }

                        //To add vendor name in list
                        lobjclsInvoiceLine.PrefVendorRefFullName = GetVendor(pstrVendorName, pobjQBSessionManager, pobjQuickBooksAccountConfig);

                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                pobjItemExtensions = null;
                return null;
            }
            finally
            {
            }
        }
        //print invoice multi/single mode : 10-Feb-2017
        public ArrayList GetINVLine(string lstrQuantityonLabel, string pstrVendorName, ArrayList strshipinfo, ArrayList strInvoiceInfo, string strRefNumber, string strInvoiceTxnLineID, DateTime dtTransactionDate, string strBillAddressAddr1,string customerName, out Dictionary<string, string> pobjItemExtensions, string autoManualPath, string autoManualCheck)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsPurchaseOrderLine objfPOLine = new clsPurchaseOrderLine();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;

            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.OwnerIDList.Add("0"); //to show all fields
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.IncludeLinkedTxns.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                {
                    ICustomerQuery CustomerQuery = default(ICustomerQuery);
                    CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                    CustomerQuery.OwnerIDList.Add("0");
                    CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(customerName);
                }

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = new clsInvoiceLine();
                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    ICustomerRetList lobjICustomerRetList = null;
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet != null)
                                {
                                    if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet != null)
                                    {
                                        lobjclsInvoiceLine = new clsInvoiceLine();
                                        for (int grpitem = 0; grpitem < loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet.InvoiceLineRetList.Count; grpitem++)
                                        {
                                            lobjclsInvoiceLine = new clsInvoiceLine();
                                            IInvoiceLineRet InvoiceLineRat = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet.InvoiceLineRetList.GetAt(grpitem);
                                            if (InvoiceLineRat.TxnLineID != null && Convert.ToString(InvoiceLineRat.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                            {
                                                lobjclsInvoiceLine = GetInvItem(InvoiceLineRat, string.Empty, string.Empty);
                                                lobjclsInvoiceLine.RefNumber = strRefNumber;
                                                lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                                lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;


                                                //Add from TP ver
                                                if (loInvoice.PONumber != null)
                                                {
                                                    lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                                }
                                                else
                                                {

                                                    lobjclsInvoiceLine.PONumber = string.Empty;
                                                }
                                                //Add FOB field Date 18-jan-2017
                                                if (loInvoice.FOB != null)
                                                {
                                                    lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    lobjclsInvoiceLine.FOB = string.Empty;
                                                }
                                                //Add Sales Rep.field Date 24-Apr-2018
                                                if (loInvoice.SalesRepRef != null)
                                                {
                                                    if (loInvoice.SalesRepRef.FullName != null)
                                                    {
                                                        lobjclsInvoiceLine.SalesRepRef = loInvoice.SalesRepRef.FullName.GetValue();
                                                    }
                                                }
                                                else
                                                {
                                                    lobjclsInvoiceLine.SalesRepRef = string.Empty;
                                                }

                                                //Add lotnumber invoice info:Date 02/03/2015
                                                if (strInvoiceInfo != null)
                                                {
                                                    foreach (clsInvoiceLine invItem in strInvoiceInfo)
                                                    {
                                                        if (invItem.InvoiceLineItemRefFullName.ToLower().Trim() == pstrVendorName.ToLower().Trim() && Convert.ToString(InvoiceLineRat.TxnLineID.GetValue()) == invItem.InvoiceLineTxnLineID)
                                                        {
                                                            if (!string.IsNullOrEmpty(invItem.InvoiceLineLotNumber))
                                                            {
                                                                lobjclsInvoiceLine.InvoiceLineItemRefFullName = invItem.InvoiceLineItemRefFullName;
                                                                lobjclsInvoiceLine.CustomFieldInvoiceLineOther1 = invItem.CustomFieldInvoiceLineOther1;
                                                                lobjclsInvoiceLine.CustomFieldInvoiceLineOther2 = invItem.CustomFieldInvoiceLineOther2;
                                                                lobjclsInvoiceLine.InvoiceLineUnitOfMeasure = invItem.InvoiceLineUnitOfMeasure;
                                                                lobjclsInvoiceLine.InvoiceLineLotNumber = invItem.InvoiceLineLotNumber;
                                                            }
                                                        }
                                                    }
                                                }

                                                //To add ShipAddress

                                                foreach (clsInvoice objInvoice in strshipinfo)
                                                {
                                                    lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                                    lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                                    lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                                    lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                                    lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                                    lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                                    lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                                    lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                                    lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                                    lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber; //to add s.o.no
                                                    lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                                                                                                      //To show Ship Address Method :Date 01/13/2015
                                                    lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;
                                                    //Get LotNumber bill address info
                                                    lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                                    lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                                    lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;



                                                }

                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    lobjclsInvoiceLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    lobjclsInvoiceLine.QtyOnLabel = string.Empty;
                                                }

                                                if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1"))
                                                {
                                                    //customer custom field for invoice : 09-Feb-2017
                                                    if (loInvoice.DataExtRetList != null)
                                                    {
                                                        for (int j = 0; j < loInvoice.DataExtRetList.Count; j++)
                                                        {
                                                            strdName = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                            strdValue = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                                lobjItemExtensions.Add(strdName, strdValue);
                                                        }
                                                    }
                                                }
                                                alInvoicesLine.Add(lobjclsInvoiceLine);
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                    if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                    {
                                        loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;

                                        if (loInvoiceLineRetItem.TxnLineID != null && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                        {
                                           
                                            lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, autoManualPath, autoManualCheck);
                                            lobjclsInvoiceLine.RefNumber = strRefNumber;
                                            lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();

                                            if (!string.IsNullOrWhiteSpace(lobjclsInvoiceLine.SerialNumber))//16-Jun-2020
                                            {
                                                lobjclsInvoiceLine.Other1 = !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.CustomFieldInvoiceLineOther1) ? lobjclsInvoiceLine.CustomFieldInvoiceLineOther1 : "";

                                            }

                                            //Add from TP ver
                                            if (loInvoice.PONumber != null)
                                            {
                                                lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());

                                            }
                                            else
                                            {

                                                lobjclsInvoiceLine.PONumber = string.Empty;
                                            }
                                            //Add CustomerName/Job:Date 05-Mar-2019
                                            if (loInvoice.CustomerRef.FullName != null)
                                            {

                                                lobjclsInvoiceLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());

                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.CustomerRefFullName = "";
                                            }

                                            //Add FOB field Date 18-jan-2017
                                            if (loInvoice.FOB != null)
                                            {
                                                lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.FOB = string.Empty;
                                            }
                                            //Add support for other header field:Date 29-Oct-2018
                                            if (loInvoice.Other != null)
                                            {
                                                lobjclsInvoiceLine.Other = Convert.ToString(loInvoice.Other.GetValue());

                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.Other = string.Empty;
                                            }

                                            //Add Sales Rep.field Date 24-Apr-2018
                                            if (loInvoice.SalesRepRef != null)
                                            {
                                                if (loInvoice.SalesRepRef.FullName != null)
                                                {
                                                    lobjclsInvoiceLine.SalesRepRef = loInvoice.SalesRepRef.FullName.GetValue();

                                                }
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.SalesRepRef = string.Empty;
                                            }


                                            lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;


                                            if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                            {
                                                lobjclsInvoiceLine.QtyOnLabel = lstrQuantityonLabel;
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.QtyOnLabel = string.Empty;
                                            }
                                            //Get BarCodeValue for item

                                            lobjclsInvoiceLine.BarCodeValue = objfPOLine.GetItemsBarCode(Convert.ToString(lobjclsInvoiceLine.InvoiceItemName));

                                            if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1"))
                                            {
                                                //customer custom field for invoice : 09-Feb-2017
                                                if (loInvoice.DataExtRetList != null)
                                                {
                                                    for (int j = 0; j < loInvoice.DataExtRetList.Count; j++)
                                                    {
                                                        strdName = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                        strdValue = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                    }
                                                }
                                            }

                                            //Get prog.columns for invoice: Date 03-APR-2019


                                            //Add lotnumber invoice info:Date 02/03/2015
                                            if (strInvoiceInfo != null)
                                            {
                                                foreach (clsInvoiceLine invItem in strInvoiceInfo)
                                                {
                                                    if (invItem.InvoiceLineItemRefFullName.ToLower().Trim() == pstrVendorName.ToLower().Trim() && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == invItem.InvoiceLineTxnLineID)
                                                    {
                                                        if (!string.IsNullOrEmpty(invItem.InvoiceLineLotNumber))
                                                        {
                                                            lobjclsInvoiceLine.InvoiceLineItemRefFullName = invItem.InvoiceLineItemRefFullName;
                                                            lobjclsInvoiceLine.CustomFieldInvoiceLineOther1 = invItem.CustomFieldInvoiceLineOther1;
                                                            lobjclsInvoiceLine.CustomFieldInvoiceLineOther2 = invItem.CustomFieldInvoiceLineOther2;
                                                            lobjclsInvoiceLine.InvoiceLineUnitOfMeasure = invItem.InvoiceLineUnitOfMeasure;
                                                            lobjclsInvoiceLine.InvoiceLineLotNumber = invItem.InvoiceLineLotNumber;
                                                        }
                                                    }
                                                }
                                            }
                                            if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet.ItemRef != null)
                                            {

                                                lobjclsInvoiceLine.InvoiceItemName = Convert.ToString(loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet.ItemRef.FullName.GetValue());

                                                lobjclsInvoiceLine.SubItemof = lobjclsInvoiceLine.InvoiceItemName != null || lobjclsInvoiceLine.InvoiceItemName != "" ? lobjclsInvoiceLine.InvoiceItemName : "";
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.InvoiceItemName = "";

                                            }

                                            //To add ShipAddress

                                            foreach (clsInvoice objInvoice in strshipinfo)
                                            {
                                                lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                                lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                                lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                                lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                                lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                                lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                                lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                                lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressAddrPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                                lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber; //to add s.o.no
                                                lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                                                                                                  //To show Ship Address Method :Date 01/13/2015
                                                lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;
                                                //Get LotNumber bill address info
                                                lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                                lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                                lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;


                                                //citystatezip field added:Date 30-APR-2019
                                                if (!string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressState) || !string.IsNullOrWhiteSpace(lobjclsInvoiceLine.ShipAddressPostalCode))
                                                {
                                                    lobjclsInvoiceLine.citystatezip += lobjclsInvoiceLine.ShipAddressCity + " " + lobjclsInvoiceLine.ShipAddressState + " " + lobjclsInvoiceLine.ShipAddressPostalCode;
                                                }



                                            }


                                            if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1"))
                                            {
                                                //----------------------------------------- Custom Field Logic ------------------------------------
                                                lobjIItemQuery = default(IItemQuery);
                                                lMsgItemsRequest.ClearRequests();

                                                lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                                lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                                lobjIItemQuery.OwnerIDList.Add("0");

                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                                //Set field value for ToName
                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceItemName);

                                                lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                                if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                                {
                                                    lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                                    if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                                    {
                                                        if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                        {
                                                            lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                            lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                            if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                            {
                                                                lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                                for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                                {
                                                                    lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                                    if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                                    {
                                                                        if (lobjIORItemRet.ItemInventoryAssemblyRet.SalesDesc != null) //#//
                                                                        {
                                                                            lobjclsInvoiceLine.InvoiceLineDesc = lobjIORItemRet.ItemInventoryAssemblyRet.SalesDesc.GetValue();
                                                                        }
                                                                        lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;

                                                                        if (lobjIDataExtRetList != null)
                                                                        {
                                                                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                            {
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                    lobjItemExtensions.Add(strdName, strdValue);
                                                                            }
                                                                        }
                                                                    }
                                                                    else if (lobjIORItemRet.ItemInventoryRet != null)
                                                                    {
                                                                        if (lobjIORItemRet.ItemInventoryRet.SalesDesc != null) //#//
                                                                        {
                                                                            lobjclsInvoiceLine.InvoiceLineDesc = lobjIORItemRet.ItemInventoryRet.SalesDesc.GetValue();
                                                                        }
                                                                        //Get MPN Field : Date 07/10/2018
                                                                        if (lobjIORItemRet.ItemInventoryRet.ManufacturerPartNumber != null)
                                                                        {
                                                                            lobjclsInvoiceLine.MPN = lobjIORItemRet.ItemInventoryRet.ManufacturerPartNumber.GetValue();
                                                                        }
                                                                        lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                        if (lobjIDataExtRetList != null)
                                                                        {
                                                                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                            {
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                    lobjItemExtensions.Add(strdName, strdValue);
                                                                            }
                                                                        }


                                                                    }
                                                                    //Add non inventory Item custom field from items
                                                                    else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                                    {

                                                                        if (lobjIORItemRet.ItemNonInventoryRet.ORSalesPurchase != null)
                                                                        {
                                                                            if (lobjIORItemRet.ItemNonInventoryRet.ORSalesPurchase.SalesAndPurchase != null)
                                                                            {
                                                                                if (lobjIORItemRet.ItemNonInventoryRet.ORSalesPurchase.SalesAndPurchase.SalesDesc != null) //#//
                                                                                {
                                                                                    lobjclsInvoiceLine.InvoiceLineDesc = lobjIORItemRet.ItemNonInventoryRet.ORSalesPurchase.SalesAndPurchase.SalesDesc.GetValue();

                                                                                }
                                                                            }
                                                                        }
                                                                        //Get MPN Field : Date 029/11/2018
                                                                        if (lobjIORItemRet.ItemNonInventoryRet.ManufacturerPartNumber != null)
                                                                        {
                                                                            lobjclsInvoiceLine.MPN = lobjIORItemRet.ItemNonInventoryRet.ManufacturerPartNumber.GetValue();

                                                                        }
                                                                        lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                                        if (lobjIDataExtRetList != null)
                                                                        {
                                                                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                            {
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                    lobjItemExtensions.Add(strdName, strdValue);


                                                                            }

                                                                        }

                                                                    }
                                                                    //Add other charge item field support added:Date 02-APR-2019
                                                                    else if (lobjIORItemRet.ItemOtherChargeRet != null)
                                                                    {
                                                                        lobjIDataExtRetList = lobjIORItemRet.ItemOtherChargeRet.DataExtRetList;
                                                                        if (lobjIDataExtRetList != null)
                                                                        {
                                                                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                            {
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                    lobjItemExtensions.Add(strdName, strdValue);
                                                                            }
                                                                        }

                                                                    }
                                                                    else if (lobjIORItemRet.ItemServiceRet != null)
                                                                    {
                                                                        lobjIDataExtRetList = lobjIORItemRet.ItemServiceRet.DataExtRetList;
                                                                        if (lobjIDataExtRetList != null)
                                                                        {
                                                                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                            {
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                if (!lobjItemExtensions.ContainsKey(strdName))
                                                                                    lobjItemExtensions.Add(strdName, strdValue);
                                                                            }
                                                                        }

                                                                    }


                                                                }
                                                            }
                                                        }
                                                    }
                                                }


                                                //Add custom field from invoice
                                                IORInvoiceLineRet lobjIDataExtRetList1 = loInvoice.ORInvoiceLineRetList.GetAt(intLine);
                                                if (lobjIDataExtRetList1 != null)
                                                {
                                                    if (lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList != null)
                                                    {
                                                        for (int k = 0; k < lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.Count; k++)
                                                        {
                                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.InvoiceLineRet.DataExtRetList.GetAt(k);


                                                            strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim().Replace(" ", "");
                                                            //Get value of DataExtType
                                                            ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                            //Get value of DataExtValue
                                                            strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                            {
                                                                lobjItemExtensions.Add(strdName, strdValue);
                                                            }
                                                            else
                                                            {
                                                                //update key/value
                                                                lobjItemExtensions.Remove(strdName);
                                                                lobjItemExtensions.Add(strdName, strdValue);


                                                            }

                                                        }
                                                    }
                                                }
                                                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                                {
                                                    if (lMsgResponse != null && lMsgResponse.ResponseList != null && lMsgResponse.ResponseList.Count > 0)
                                                    {
                                                        lobjIResponse = lMsgResponse.ResponseList.GetAt(1);
                                                        lobjICustomerRetList = (ICustomerRetList)lobjIResponse.Detail;
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
                                                    }
                                                }

                                            }

                                            alInvoicesLine.Add(lobjclsInvoiceLine);




                                            //------------------------------- Custom Fields Logic ---------------------------------//
                                        }
                                    }
                                    else
                                    {
                                        loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;

                                        if (loInvoiceLineGroupRet.TxnLineID != null && Convert.ToString(loInvoiceLineGroupRet.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                        {
                                            lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                            lobjclsInvoiceLine.RefNumber = strRefNumber;
                                            lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                            lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;

                                            //suport field in invoice group item printing: 13-Sept-2017
                                            //Add from TP ver
                                            if (loInvoice.PONumber != null)
                                            {
                                                lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                            }
                                            else
                                            {

                                                lobjclsInvoiceLine.PONumber = string.Empty;
                                            }
                                            //Add FOB field Date 18-jan-2017
                                            if (loInvoice.FOB != null)
                                            {
                                                lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.FOB = string.Empty;
                                            }
                                            //Add Sales Rep.field Date 24-Apr-2018
                                            if (loInvoice.SalesRepRef != null)
                                            {
                                                if (loInvoice.SalesRepRef.FullName != null)
                                                {
                                                    lobjclsInvoiceLine.SalesRepRef = loInvoice.SalesRepRef.FullName.GetValue();
                                                }
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.SalesRepRef = string.Empty;
                                            }

                                            //Add lotnumber invoice info:Date 02/03/2015
                                            if (strInvoiceInfo != null)
                                            {
                                                foreach (clsInvoiceLine invItem in strInvoiceInfo)
                                                {
                                                    if (invItem.InvoiceLineItemRefFullName.ToLower().Trim() == pstrVendorName.ToLower().Trim() && Convert.ToString(loInvoiceLineGroupRet.TxnLineID.GetValue()) == invItem.InvoiceLineTxnLineID)
                                                    {
                                                        if (!string.IsNullOrEmpty(invItem.InvoiceLineLotNumber))
                                                        {
                                                            lobjclsInvoiceLine.InvoiceLineItemRefFullName = invItem.InvoiceLineItemRefFullName;
                                                            lobjclsInvoiceLine.CustomFieldInvoiceLineOther1 = invItem.CustomFieldInvoiceLineOther1;
                                                            lobjclsInvoiceLine.CustomFieldInvoiceLineOther2 = invItem.CustomFieldInvoiceLineOther2;
                                                            lobjclsInvoiceLine.InvoiceLineUnitOfMeasure = invItem.InvoiceLineUnitOfMeasure;
                                                            lobjclsInvoiceLine.InvoiceLineLotNumber = invItem.InvoiceLineLotNumber;
                                                        }
                                                    }
                                                }
                                            }

                                            //To add ShipAddress

                                            foreach (clsInvoice objInvoice in strshipinfo)
                                            {
                                                lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                                lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                                lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                                lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                                lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                                lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                                lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                                lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                                lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber; //to add s.o.no
                                                lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                                                                                                  //To show Ship Address Method :Date 01/13/2015
                                                lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;
                                                //Get LotNumber bill address info
                                                lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                                lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                                lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;



                                            }

                                            if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                            {
                                                lobjclsInvoiceLine.QtyOnLabel = lstrQuantityonLabel;
                                            }
                                            else
                                            {
                                                lobjclsInvoiceLine.QtyOnLabel = string.Empty;
                                            }

                                            if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1"))
                                            {
                                                //customer custom field for invoice : 09-Feb-2017
                                                if (loInvoice.DataExtRetList != null)
                                                {
                                                    for (int j = 0; j < loInvoice.DataExtRetList.Count; j++)
                                                    {
                                                        strdName = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                        strdValue = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                    }
                                                }
                                            }

                                            alInvoicesLine.Add(lobjclsInvoiceLine);
                                        }
                                    }
                                }

                            }


                        }
                        //To add vendor name in list

                        lobjclsInvoiceLine.PrefVendorRefFullName = GetVendor(pstrVendorName);
                    }
                }
                pobjItemExtensions = lobjItemExtensions;

                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                pobjItemExtensions = null;
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

        //Get BarCode Values for invoice item
        public string GetItemsBarCode(string pstrItemName)
        {
            string strItembarcode = string.Empty;


            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventory = default(IItemInventoryQuery);
                ItemInventory = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                // QBHelper.WriteLog("19" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Get Barcode value open connection.");
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //QBHelper.WriteLog("20" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Get Barcode value ResponseList Generated.");
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;
                    IItemInventoryRet loItemname = default(IItemInventoryRet);


                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {


                            loItemname = loList.GetAt(Index);
                            if (loItemname.BarCodeValue != null)
                                //QBHelper.WriteLog("21" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "check Barcode IndexOf condition start");
                                if (loItemname.BarCodeValue != null)
                                {
                                    //Commond by TamilRK on 10/23/2020- 
                                    ////if (Convert.ToString(loItemname.BarCodeValue.GetValue()).IndexOf(':') != -1)
                                    ////{
                                    ////   // QBHelper.WriteLog("22" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "check Barcode IndexOf condition matched sucessufully");

                                    ////    strItembarcode = clsStringExtension.SubstringAfter(clsStringExtension.ExceptBlanks(Convert.ToString(loItemname.BarCodeValue.GetValue())), "QB:");// Get barcode value
                                    ////}
                                    ////else
                                    ////{
                                    ////    strItembarcode = Convert.ToString(loItemname.BarCodeValue.GetValue());

                                    ////}
                                    strItembarcode = Convert.ToString(loItemname.BarCodeValue.GetValue());
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
                //QBHelper.WriteLog("23" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "return Barcode value as" + strItembarcode);
                return strItembarcode;
            }
            catch (Exception ex)
            {
                QBHelper.WriteLog("24" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "Get Barcode value closed connection.");
                throw;
                return null;

            }


        }
        //Function to find custom field having  label value 'No' for open QuickBoooks connection
        public ArrayList FilterCustomField(string strRefNumber, string strfilterlabelvalue)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {

                //lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;



                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                    string transnumber = string.Empty;

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        //foreach (clsInvoice objInvoice in strInvoiceTxnLineID)
                        //{
                        //    transnumber = objInvoice.TxnID;

                        //}
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;

                                    //if (loInvoiceLineRetItem.TxnLineID != null && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == transnumber)
                                    //{
                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //Remove blank from items in the invoice
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "")
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;




                                        //  alInvoicesLine.Add(lobjclsInvoiceLine);

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine._strInvoiceLineItemRefFullName);

                                        lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        // if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //   lobjItemExtensions.Add(strdName, strdValue);
                                                                        if (strdName == strfilterlabelvalue && strdValue.ToUpper().Trim() == "NO".ToUpper().Trim())
                                                                        {

                                                                            //alInvoicesLine.Add(lobjclsInvoiceLine.IsValueFound);
                                                                            lobjclsInvoiceLine.IsValueFound = true;
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        //if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        // lobjItemExtensions.Add(strdName, strdValue);
                                                                        if (strdName == strfilterlabelvalue.Replace(" ", string.Empty) && strdValue.ToUpper().Trim() == "NO".ToUpper().Trim())
                                                                        {

                                                                            //alInvoicesLine.Add(lobjclsInvoiceLine.IsValueFound);
                                                                            lobjclsInvoiceLine.IsValueFound = true;
                                                                        }

                                                                    }
                                                                }




                                                            }



                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //------------------------------- Custom Fields Logic ---------------------------------//
                                        // }
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }
                                //else
                                //{
                                //    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;

                                //    if (loInvoiceLineGroupRet.TxnLineID != null && Convert.ToString(loInvoiceLineGroupRet.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                //    {
                                //        lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                //        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                //        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                //        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;
                                //        alInvoicesLine.Add(lobjclsInvoiceLine);
                                //    }


                                //}



                            }


                        }

                    }
                }
                // pobjItemExtensions = lobjItemExtensions;

                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                // pobjItemExtensions = null;
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

        //Function to find custom field having label valu No for close QuickBoooks connection
        public ArrayList FilterCustomField(string strRefNumber, string strfilterlabelvalue, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;


            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {


                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    // IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;



                    //IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;

                    IMsgSetRequest lMsgItemsRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));


                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;


                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //Remove blank from items in the invoice
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != "")
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;



                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine._strInvoiceLineItemRefFullName);

                                        lobjIMsgSetResponse = pobjQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                        if (strdName == strfilterlabelvalue && strdValue.ToUpper().Trim() == "NO".ToUpper().Trim())
                                                                        {

                                                                            lobjclsInvoiceLine.IsValueFound = true;
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                        if (strdName == strfilterlabelvalue && strdValue.ToUpper().Trim() == "NO".ToUpper().Trim())
                                                                        {

                                                                            lobjclsInvoiceLine.IsValueFound = true;
                                                                        }

                                                                    }
                                                                }




                                                            }



                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //------------------------------- Custom Fields Logic end ---------------------------------//

                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }



                            }


                        }

                    }
                }


                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                alInvoicesLine = null;
                return null;
            }

        }


        //invoice pack/units records list: Date 15-Feb-2017
        public ArrayList GetPackperUnitINVLine(ArrayList strshipinfo, ArrayList strInvoiceInfo, string strRefNumber, string strInvoiceTxnLineID, DateTime dtTransactionDate, string strBillAddressAddr1, out Dictionary<string, string> pobjItemExtensions)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            string strdName = string.Empty;
            string strdValue = string.Empty;
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.OwnerIDList.Add("0"); //to show all fields
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;


                    //IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            //Get customer custom field from invoice : 02-13-2017
                            if (loInvoice.DataExtRetList != null)
                            {
                                for (int j = 0; j < loInvoice.DataExtRetList.Count; j++)
                                {
                                    strdName = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                    strdValue = Convert.ToString(loInvoice.DataExtRetList.GetAt(j).DataExtValue.GetValue());
                                    if (!lobjItemExtensions.ContainsKey(strdName))
                                        lobjItemExtensions.Add(strdName, strdValue);
                                }
                            }



                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {

                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    if (loInvoiceLineRetItem.TxnLineID != null && Convert.ToString(loInvoiceLineRetItem.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                    {
                                        lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        //Add from TP ver
                                        if (loInvoice.PONumber != null)
                                        {
                                            lobjclsInvoiceLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                        }
                                        else
                                        {

                                            lobjclsInvoiceLine.PONumber = string.Empty;
                                        }
                                        //Add FOB field Date 18-jan-2017
                                        if (loInvoice.FOB != null)
                                        {
                                            lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                        }
                                        else
                                        {
                                            lobjclsInvoiceLine.FOB = string.Empty;
                                        }


                                        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;


                                        //To add ShipAddress
                                        if (strshipinfo.Count > 0)
                                        {
                                            foreach (clsInvoice objInvoice in strshipinfo)
                                            {
                                                lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                                lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                                lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                                lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                                lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                                lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                                lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                                lobjclsInvoiceLine.ShipAddressAddrPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                                lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber; //to add s.o.no
                                                lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                                //To show Ship Address Method :Date 01/13/2015
                                                lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;
                                                //Get LotNumber bill address info
                                                lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                                lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                                lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;

                                            }
                                        }


                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine._strInvoiceLineItemRefFullName);


                                        lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper(); //ToUpper added 02/02/2017
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }


                                                            }
                                                            //Add non inventory Item custom field from items
                                                            else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                                            lobjItemExtensions.Add(strdName, strdValue);
                                                                    }
                                                                }

                                                            }





                                                        }
                                                    }
                                                }
                                            }
                                        }


                                        alInvoicesLine.Add(lobjclsInvoiceLine);




                                        //------------------------------- Custom Fields Logic ---------------------------------//
                                    }
                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;

                                    if (loInvoiceLineGroupRet.TxnLineID != null && Convert.ToString(loInvoiceLineGroupRet.TxnLineID.GetValue()) == strInvoiceTxnLineID)
                                    {
                                        lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        lobjclsInvoiceLine.TxnDate = dtTransactionDate.ToShortDateString();
                                        lobjclsInvoiceLine.BillAddressAddr1 = strBillAddressAddr1;


                                        //Get ShipTo Address for withgroup or without group item : Date-22-Feb-2017
                                        //To add ShipAddress
                                        if (strshipinfo.Count > 0)
                                        {
                                            foreach (clsInvoice objInvoice in strshipinfo)
                                            {

                                                lobjclsInvoiceLine.ShipAddressAddr1 = objInvoice.ShipAddressAddr1;
                                                lobjclsInvoiceLine.ShipAddressAddr2 = objInvoice.ShipAddressAddr2;
                                                lobjclsInvoiceLine.ShipAddressAddr3 = objInvoice.ShipAddressAddr3;
                                                lobjclsInvoiceLine.ShipAddressAddr4 = objInvoice.ShipAddressAddr4;
                                                lobjclsInvoiceLine.ShipAddressAddr5 = objInvoice.ShipAddressAddr5;
                                                lobjclsInvoiceLine.ShipAddressCity = objInvoice.ShipAddressCity;
                                                lobjclsInvoiceLine.ShipAddressState = objInvoice.ShipAddressState;
                                                lobjclsInvoiceLine.ShipAddressAddrPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressPostalCode = objInvoice.ShipAddressPostalCode;
                                                lobjclsInvoiceLine.ShipAddressCountry = objInvoice.ShipAddressCountry;
                                                lobjclsInvoiceLine.LinkTxnRefNumber = objInvoice.LinkTxnRefNumber; //to add s.o.no
                                                lobjclsInvoiceLine.CustomFieldOther = objInvoice.CustomFieldOther;//To add other
                                                //To show Ship Address Method :Date 01/13/2015
                                                lobjclsInvoiceLine.ShipAddressMethod = objInvoice.ShipAddressMethod;
                                                //Get LotNumber bill address info
                                                lobjclsInvoiceLine.ShipDate = objInvoice.ShipDate;
                                                lobjclsInvoiceLine.BillAddressAddr2 = objInvoice.BillAddressAddr2;
                                                lobjclsInvoiceLine.BillAddress = objInvoice.BillAddress;

                                            }

                                        }



                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }


                                }


                            }



                        }
                        //To add vendor name in list
                        //lobjclsInvoiceLine.PrefVendorRefFullName = GetVendor(pstrVendorName);
                    }
                }
                pobjItemExtensions = lobjItemExtensions;

                return alInvoicesLine;
            }
            catch (Exception Ex)
            {
                throw;
                pobjItemExtensions = null;
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

        //Get group item header custom field : Date 10-Feb-2017
        public void InvoiceGroupItemHeaderCustomField(string pstrItemName, Dictionary<string, string> tempdatacollection, out Dictionary<string, string> pobjItemExtensions)
        {

            string strdName = string.Empty;
            string strdValue = string.Empty;

            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            //Dictionary<string, string> objtempdictionary = new Dictionary<string, string>();


            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemGroupQuery ItemInventory = default(IItemGroupQuery);

                ItemInventory = lMsgRequest.AppendItemGroupQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                    IItemGroupRet loItemname = default(IItemGroupRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            loItemname = loList.GetAt(Index);

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
                    //else
                    //{
                    //    pobjItemExtensions = lobjItemExtensions;

                    //}


                }


                if (lobjItemExtensions.Count > 0)
                {
                    foreach (KeyValuePair<string, string> keyitem in lobjItemExtensions)
                    {
                        if (!tempdatacollection.ContainsKey(strdName))
                        {
                            tempdatacollection.Add(keyitem.Key, keyitem.Value);
                        }

                    }
                }


                pobjItemExtensions = tempdatacollection;

            }
            catch (Exception ex)
            {
                throw;

            }


        }

        //Get inventory item custom field pack/units : Date 13-feb-2017
        public double GetPackperUnitsGroupItem(string pstrItemName, string qtypercontainervalue)
        {

            string strdName = string.Empty;
            double intcustValue = 0;

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemGroupQuery ItemInventory = default(IItemGroupQuery);

                ItemInventory = lMsgRequest.AppendItemGroupQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                    IItemGroupRet loItemname = default(IItemGroupRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            loItemname = loList.GetAt(Index);

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                    //if (strdName == "PACK/UNITS")
                                    if (strdName == qtypercontainervalue.ToUpper())
                                    {
                                        intcustValue = Convert.ToInt32(DataExtRet.DataExtValue.GetValue());
                                    }


                                }
                            }


                        }
                    }

                }


                return intcustValue;

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        //check packperunits name matched for  inventory item
        public bool IspackperUnitsNameExist(string pstrNamesearch, string pstrpackperunitmatchstring)
        {
            string strdName = string.Empty;
            bool blnIspackunitExist = false;

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventory = default(IItemInventoryQuery);

                ItemInventory = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventory.OwnerIDList.Add("0");


                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrNamesearch);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrNamesearch);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
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

                            loItemname = loList.GetAt(Index);

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                    if (strdName == pstrpackperunitmatchstring.ToUpper().Trim())
                                    {

                                        blnIspackunitExist = true;
                                        break;

                                    }


                                }
                            }


                        }
                    }

                }


                return blnIspackunitExist;

            }
            catch (Exception ex)
            {
                blnIspackunitExist = false;
                throw;

            }

        }
        //check packperunits name matched for group item
        public bool IsPackperUnitsGroupItemExist(string pstrGroupItemName, string pstrpackperunitmatchstring)
        {

            string strdName = string.Empty;
            bool blngroupItemname = false;

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemGroupQuery ItemInventory = default(IItemGroupQuery);

                ItemInventory = lMsgRequest.AppendItemGroupQueryRq();
                ItemInventory.OwnerIDList.Add("0");

                ItemInventory.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrGroupItemName);
                ItemInventory.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrGroupItemName);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemGroupRetList loList = (IItemGroupRetList)loResponse.Detail;

                    IItemGroupRet loItemname = default(IItemGroupRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {

                            loItemname = loList.GetAt(Index);

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                    if (strdName == pstrpackperunitmatchstring.ToUpper().Trim())
                                    {
                                        blngroupItemname = true;
                                        break;
                                    }


                                }
                            }


                        }
                    }

                }


                return blngroupItemname;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        //Get Group item custom field pack/units : Date 13-feb-2017
        public double GetPackperUnitsInventoryItem(string pstrItemName, string pstrqtypercontainer)
        {

            string strdName = string.Empty;
            double intcustValue = 0;
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemInventoryQuery ItemInventory = default(IItemInventoryQuery);

                ItemInventory = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventory.OwnerIDList.Add("0");


                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                ItemInventory.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
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

                            loItemname = loList.GetAt(Index);

                            //Go cutsom item field for po from item defination : Date 27-jan-2016 
                            if (loItemname.DataExtRetList != null)
                            {
                                for (int j = 0; j < loItemname.DataExtRetList.Count; j++)
                                {
                                    IDataExtRet DataExtRet = loItemname.DataExtRetList.GetAt(j);

                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper().Trim();
                                    // if (strdName == "PACK/UNITS")
                                    if (strdName == pstrqtypercontainer.ToUpper())
                                    {

                                        intcustValue = Convert.ToInt32(DataExtRet.DataExtValue.GetValue());

                                    }


                                }
                            }


                        }
                    }

                }


                return intcustValue;

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        //To get Vendor
        private string GetVendor(string pstrItemName)
        {
            string lstrvendorname = string.Empty;
            //step2: create QBFC session manager and prepare the request
            // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryQuery IItemsQuery = default(IItemInventoryQuery);




                IItemsQuery = lMsgRequest.AppendItemInventoryQueryRq();

                if (pstrItemName != "1=1")
                {
                    //IItemsQuery.ORListQuery.ListFilter.MaxReturned.SetValue(1);
                    //IItemsQuery.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                    //IItemsQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //IItemsQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(pstrItemName);

                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.MaxReturned.SetValue(1);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.Name.SetValue(pstrItemName);




                }
                else
                {

                }

               // lQBSessionManager.OpenConnection("", "Label Connector");
                //lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
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
                  //  lQBSessionManager.EndSession();
                  //  lQBSessionManager.CloseConnection();
                }
            }


            try
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;
                    IItemInventoryRet loItems = default(IItemInventoryRet);



                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loItems = loList.GetAt(Index);

                            // if (loItems.PrefVendorRef.FullName != null)
                            if (loItems.PrefVendorRef != null)
                                lstrvendorname = Convert.ToString(loItems.PrefVendorRef.FullName.GetValue());


                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //throw;
                return null;
            }


            return lstrvendorname;

        }

        //To get Vendor
        private string GetVendor(string pstrItemName, IQBSessionManager pobjIQBSessionManager, QuickBooksAccount pobjQuickBooksAccount)
        {
            string lstrvendorname = string.Empty;

            //step2: create QBFC session manager and prepare the request
            //QBSessionManager lQBSessionManager = default(QBSessionManager);
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //lQBSessionManager = new QBSessionManagerClass();
                IMsgSetRequest lMsgRequest = pobjIQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccount.QBCountry, Convert.ToInt16(pobjQuickBooksAccount.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccount.QBMinorVersion));
                //IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", 8, 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryQuery IItemsQuery = default(IItemInventoryQuery);




                IItemsQuery = lMsgRequest.AppendItemInventoryQueryRq();

                if (pstrItemName != "1=1")
                {
                    //IItemsQuery.ORListQuery.ListFilter.MaxReturned.SetValue(1);
                    //IItemsQuery.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                    //IItemsQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //IItemsQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(pstrItemName);

                    //for qb 11 and above
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.MaxReturned.SetValue(1);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    IItemsQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.Name.SetValue(pstrItemName);

                }
                else
                {

                }

                //pobjIQBSessionManager.OpenConnection("", "Label Connector");
                //objIQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = pobjIQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {

            }


            try
            {
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;
                    IItemInventoryRet loItems = default(IItemInventoryRet);



                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loItems = loList.GetAt(Index);

                            if (loItems.PrefVendorRef.FullName != null)
                                lstrvendorname = Convert.ToString(loItems.PrefVendorRef.FullName.GetValue());


                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //throw;
                return null;
            }


            return lstrvendorname;


        }


        //-----------END Added on 12-Feb-2013 for allowing user to acces QB Data based on the option selected selection----------

        private clsInvoiceLine GetInvItem(IInvoiceLineRet poInvoiceLineRet, string autoManualPath, string autoManualCheck)
        {
            clsInvoiceLine objINVLine = new clsInvoiceLine();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            double dbluomquantity = 0;
            string lstruomquantity = string.Empty;
            if (poInvoiceLineRet.Quantity != null)
            {

                if ((lobjQBConfiguration.GetLabelConfigSettings("MultiInvoiceMode").ToString() == "M"))
                {

                    objINVLine.InvoiceQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
                }
                else
                {
                    objINVLine.InvoiceQuantity = 1;
                }
                objINVLine.InvoiceLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());

                //QBHelper.WriteLog("IP3" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "quantity==>" + objINVLine.InvoiceLineQuantity);
            }
            else
            {
                objINVLine.InvoiceLineQuantity = 0.00;
                objINVLine.InvoiceQuantity = 1;
            }

            if (poInvoiceLineRet.UnitOfMeasure != null)
            {
                objINVLine.InvoiceLineUnitOfMeasure = Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue());
                //QBHelper.WriteLog("IP4" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "quantity==>" + objINVLine.InvoiceLineUnitOfMeasure);
                //convert UOM quantity to quantity
                if (poInvoiceLineRet.Quantity != null)
                {
                    lstruomquantity = Regex.Replace(Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue()), "[^0-9]+", string.Empty);
                    // QBHelper.WriteLog("IP5" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "uom quantity calcu");
                    if (!string.IsNullOrWhiteSpace(lstruomquantity))
                    {
                        dbluomquantity = Convert.ToDouble(lstruomquantity);

                        objINVLine.InvoiceLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue()) / dbluomquantity;

                        if ((lobjQBConfiguration.GetLabelConfigSettings("MultiInvoiceMode").ToString() == "M"))
                        {

                            objINVLine.InvoiceQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue()) / dbluomquantity; ;
                        }
                        else
                        {
                            objINVLine.InvoiceQuantity = 1;
                        }

                        //  QBHelper.WriteLog("IP6" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "uom qty");
                    }
                    //else
                    //{
                    //    dbluomquantity = objINVLine.InvoiceLineQuantity * 100;
                    //    objINVLine.InvoiceLineQuantity = dbluomquantity;
                    //}
                }

            }
            else
            {
                objINVLine.InvoiceLineUnitOfMeasure = "";
            }


            if (poInvoiceLineRet.ItemRef != null)
            {
                objINVLine.InvoiceLineItemRefFullName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
                objINVLine.InvoiceItemName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
                if (!string.IsNullOrEmpty(autoManualPath) && !string.IsNullOrEmpty(autoManualCheck))
                {
                    if (autoManualCheck == "Auto")
                    {
                        DirectoryInfo d = new DirectoryInfo(autoManualPath);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles("*.btw"); //Getting Text files
                        string str = "";
                        string com = "";
                        foreach (FileInfo file in Files)
                        {
                            str = file.Name;
                            com = objINVLine.InvoiceLineItemRefFullName + ".btw";
                            if (com.ToUpper().Trim() == str.ToUpper().Trim())
                            {
                                objINVLine._IsAuto = true;
                            }
                        }
                    }
                }
                objINVLine.SubItemof  = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
            }

            else
            {
                objINVLine.InvoiceLineItemRefFullName = "";
            }
            if (poInvoiceLineRet.Desc != null)
            {
                objINVLine.InvoiceLineDesc = Convert.ToString(poInvoiceLineRet.Desc.GetValue());
                // QBHelper.WriteLog("IP8" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Item desc" + objINVLine.InvoiceLineDesc.ToString());
            }
            else
            {
                objINVLine.InvoiceLineDesc = "";
            }
            if (poInvoiceLineRet.TxnLineID != null)
            {
                objINVLine.InvoiceLineTxnLineID = Convert.ToString(poInvoiceLineRet.TxnLineID.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineTxnLineID = "";
            }
            if (poInvoiceLineRet.Other1 != null)
            {
                objINVLine.CustomFieldInvoiceLineOther1 = Convert.ToString(poInvoiceLineRet.Other1.GetValue());
                // objINVLine.Other1= Convert.ToString(poInvoiceLineRet.Other1.GetValue()); //16-Jun-2020 for serial no label
                // QBHelper.WriteLog("IP9" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Other1" + objINVLine.CustomFieldInvoiceLineOther1.ToString());
            }
            else
            {
                objINVLine.CustomFieldInvoiceLineOther1 = "";
            }
            if (poInvoiceLineRet.Other2 != null)
            {
                objINVLine.CustomFieldInvoiceLineOther2 = Convert.ToString(poInvoiceLineRet.Other2.GetValue());
                //QBHelper.WriteLog("IP10" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Other2" + objINVLine.CustomFieldInvoiceLineOther2.ToString());
            }
            else
            {
                objINVLine.CustomFieldInvoiceLineOther2 = "";
            }


            //adding priceeach and amount column:date: 29-10-2013
            if (poInvoiceLineRet.Amount != null)
            {
                // QBHelper.WriteLog("IP9" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Amount before");
                objINVLine.InvoiceLineAmount = string.Format("{0:N}", poInvoiceLineRet.Amount.GetValue());
                //QBHelper.WriteLog("IP10" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Amount after");
            }
            else
            {
                objINVLine.InvoiceLineAmount = "0";
            }

            if (poInvoiceLineRet.ORRate != null && poInvoiceLineRet.ORRate.Rate != null)
            {
                // QBHelper.WriteLog("IP11" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Rate before");
                objINVLine.InvoiceLineRate = string.Format("{0:N}", poInvoiceLineRet.ORRate.Rate.GetValue());
                //QBHelper.WriteLog("IP12" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "After after");
            }
            else
            {
                objINVLine.InvoiceLineRate = "0";
            }


            //Print LotNumber
            //if (poInvoiceLineRet.DataExtRetList != null)
            //{
            //    for (int custcol = 0; custcol < poInvoiceLineRet.DataExtRetList.Count; custcol++)
            //    {
            //        IDataExtRet DataExtRet = poInvoiceLineRet.DataExtRetList.GetAt(custcol);

            //        switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
            //        {

            //            case "lotnumber":
            //                objINVLine.LotNumber = Convert.ToString(DataExtRet.DataExtValue.GetValue());
            //                break;

            //            default:
            //                break;
            //        }
            //    }


            //}

            //Get value of LotNumber from invoice lineitem :Date 02/11/2015
            if (poInvoiceLineRet.ORSerialLotNumber != null)
            {
                if (poInvoiceLineRet.ORSerialLotNumber.LotNumber != null)
                {
                    // QBHelper.WriteLog("IP13" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Lotno before");
                    objINVLine.InvoiceLineLotNumber = Convert.ToString(poInvoiceLineRet.ORSerialLotNumber.LotNumber.GetValue());
                    // QBHelper.WriteLog("IP14" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "==" + "Lotno after");
                }
            }
            //Get serial numbers enter into the invoice:16-Jun-2020
            if (poInvoiceLineRet.ORSerialLotNumber != null)
            {
                if (poInvoiceLineRet.ORSerialLotNumber.SerialNumber != null)
                {

                    objINVLine.SerialNumber = Convert.ToString(poInvoiceLineRet.ORSerialLotNumber.SerialNumber.GetValue());

                }
            }




            return objINVLine;
        }
        //Get DateRange Invoice Item:12-July-2019
        private clsInvoiceLine GetDateRangeInvoiceItems(IInvoiceLineRet poInvoiceLineRet, bool InvoiceQtyIsDefault, string autoManualPath, string autoManualCheck)
        {
            clsInvoiceLine objINVLine = new clsInvoiceLine();
            double dbluomquantity = 0;
            string lstruomquantity = string.Empty;

            if (poInvoiceLineRet.Quantity != null)
            {
                objINVLine.InvoiceLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
                objINVLine.InvoiceQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());

                if (InvoiceQtyIsDefault == true) //12-July-2019
                {
                    objINVLine.QtyOnLabel = "1"; //if default invoice qty is selected
                }
                else
                {
                    objINVLine.QtyOnLabel = Convert.ToString(poInvoiceLineRet.Quantity.GetValue());
                }


            }
            else
            {
                objINVLine.InvoiceLineQuantity = 0.00;
            }



            if (poInvoiceLineRet.UnitOfMeasure != null)
            {
                objINVLine.InvoiceLineUnitOfMeasure = Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue());
                //convert UOM quantity to quantity
                if (poInvoiceLineRet.Quantity != null)
                {
                    lstruomquantity = Regex.Replace(Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue()), "[^0-9]+", string.Empty);
                    if (!string.IsNullOrWhiteSpace(lstruomquantity))
                    {
                        dbluomquantity = Convert.ToDouble(lstruomquantity);
                        objINVLine.InvoiceLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue()) / dbluomquantity;
                    }
                    //else
                    //{
                    //    dbluomquantity = objINVLine.InvoiceLineQuantity * 100;
                    //    objINVLine.InvoiceLineQuantity = dbluomquantity;
                    //}
                }

            }
            else
            {
                objINVLine.InvoiceLineUnitOfMeasure = "";
            }


            if (poInvoiceLineRet.ItemRef != null)
            {
                objINVLine.InvoiceLineItemRefFullName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
                objINVLine.InvoiceItemName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());

                if (!string.IsNullOrEmpty(autoManualPath) && !string.IsNullOrEmpty(autoManualCheck))
                {
                    if (autoManualCheck == "Auto")
                    {
                        DirectoryInfo d = new DirectoryInfo(autoManualPath);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles("*.btw"); //Getting Text files
                        string str = "";
                        string com = "";
                        foreach (FileInfo file in Files)
                        {
                            str = file.Name;
                            com = objINVLine.InvoiceLineItemRefFullName + ".btw";
                            if (com.ToUpper().Trim() == str.ToUpper().Trim())
                            {
                                objINVLine._IsAuto = true;
                            }
                        }
                    }
                }
            }

            else
            {
                objINVLine.InvoiceLineItemRefFullName = "";
            }
            if (poInvoiceLineRet.Desc != null)
            {
                objINVLine.InvoiceLineDesc = Convert.ToString(poInvoiceLineRet.Desc.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineDesc = "";
            }
            if (poInvoiceLineRet.TxnLineID != null)
            {
                objINVLine.InvoiceLineTxnLineID = Convert.ToString(poInvoiceLineRet.TxnLineID.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineTxnLineID = "";
            }
            if (poInvoiceLineRet.Other1 != null)
            {
                objINVLine.CustomFieldInvoiceLineOther1 = Convert.ToString(poInvoiceLineRet.Other1.GetValue());
            }
            else
            {
                objINVLine.CustomFieldInvoiceLineOther1 = "";
            }
            if (poInvoiceLineRet.Other2 != null)
            {
                objINVLine.CustomFieldInvoiceLineOther2 = Convert.ToString(poInvoiceLineRet.Other2.GetValue());
            }
            else
            {
                objINVLine.CustomFieldInvoiceLineOther2 = "";
            }


            //adding priceeach and amount column:date: 29-10-2013
            if (poInvoiceLineRet.Amount != null)
            {

                objINVLine.InvoiceLineAmount = string.Format("{0:N}", poInvoiceLineRet.Amount.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineAmount = "0";
            }

            if (poInvoiceLineRet.ORRate != null && poInvoiceLineRet.ORRate.Rate != null)
            {

                objINVLine.InvoiceLineRate = string.Format("{0:N}", poInvoiceLineRet.ORRate.Rate.GetValue());

            }
            else
            {
                objINVLine.InvoiceLineRate = "0";
            }


            //Print LotNumber
            //if (poInvoiceLineRet.DataExtRetList != null)
            //{
            //    for (int custcol = 0; custcol < poInvoiceLineRet.DataExtRetList.Count; custcol++)
            //    {
            //        IDataExtRet DataExtRet = poInvoiceLineRet.DataExtRetList.GetAt(custcol);

            //        switch ((string)DataExtRet.DataExtName.GetValue().ToLower())
            //        {

            //            case "lotnumber":
            //                objINVLine.LotNumber = Convert.ToString(DataExtRet.DataExtValue.GetValue());
            //                break;

            //            default:
            //                break;
            //        }
            //    }


            //}

            //Get value of LotNumber from invoice lineitem :Date 02/11/2015
            if (poInvoiceLineRet.ORSerialLotNumber != null)
            {
                if (poInvoiceLineRet.ORSerialLotNumber.LotNumber != null)
                {
                    objINVLine.InvoiceLineLotNumber = Convert.ToString(poInvoiceLineRet.ORSerialLotNumber.LotNumber.GetValue());
                }
            }


            return objINVLine;
        }


        private clsInvoiceLine GetInvGroupItem(IInvoiceLineGroupRet poInvoiceLineGroupRet)
        {
            clsInvoiceLine objINVLine = new clsInvoiceLine();

            if (poInvoiceLineGroupRet.Quantity != null)
            {
                objINVLine.InvoiceLineQuantity = Convert.ToDouble(poInvoiceLineGroupRet.Quantity.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineQuantity = 0.00;
            }

            if (poInvoiceLineGroupRet.Desc != null)
            {
                objINVLine.InvoiceLineDesc = Convert.ToString(poInvoiceLineGroupRet.Desc.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineDesc = string.Empty;
            }

            if (poInvoiceLineGroupRet.ItemGroupRef != null)
            {
                objINVLine.InvoiceLineItemRefFullName = Convert.ToString(poInvoiceLineGroupRet.ItemGroupRef.FullName.GetValue());
                objINVLine.GroupItemType = "P";
            }
            else
            {
                objINVLine.InvoiceLineItemRefFullName = string.Empty;
            }

            if (poInvoiceLineGroupRet.TxnLineID != null)
            {
                objINVLine.InvoiceLineTxnLineID = Convert.ToString(poInvoiceLineGroupRet.TxnLineID.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineTxnLineID = string.Empty;
            }

            if (poInvoiceLineGroupRet.UnitOfMeasure != null)
            {
                objINVLine.InvoiceLineUnitOfMeasure = Convert.ToString(poInvoiceLineGroupRet.UnitOfMeasure.GetValue());
            }
            else
            {
                objINVLine.InvoiceLineUnitOfMeasure = string.Empty;
            }


            return objINVLine;
        }


        public ArrayList GetINVLinePackagingsingle(string strRefNumber, out List<Itemcustomfields> pobjItemExtensions)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            List<Itemcustomfields> list = new List<Itemcustomfields>();
            string strdName = string.Empty;
            string strdValue = string.Empty;
            bool blnfieldexist = false;
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;

                    IItemGroupQuery lobjIItemGroupQuery = null;

                    //--------------------------------------------
                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        alInvoicesLine.Add(lobjclsInvoiceLine);

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");

                                        //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        // lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine.InvoiceLineItemRefFullName);

                                        //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                                        //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                        //Set field value for ToName
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceItemName);


                                        //lQBSessionManager.OpenConnection("", "Label Connector");
                                        //lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                                        lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        //if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //  lobjItemExtensions.Add(strdName, strdValue);

                                                                        //list.Add(new Itemcustomfields("", lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        // if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //  lobjItemExtensions.Add(strdName, strdValue);
                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        }


                                                                    }
                                                                }

                                                                //Add Vendor to Invoice
                                                                // if (lobjIORItemRet.ItemInventoryRet.PrefVendorRef != null)
                                                                //    lobjItemExtensions.Add("PrefVendorRefFullName", lobjIORItemRet.ItemInventoryRet.PrefVendorRef.FullName.GetValue());



                                                            }



                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //------------------------------- Custom Fields Logic ---------------------------------//




                                    }
                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
                                    lobjclsInvoiceLine = new clsInvoiceLine();
                                    lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = strRefNumber;
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }
                            }
                        }
                    }
                }
                // pobjItemExtensions = lobjItemExtensions;
                pobjItemExtensions = list;
                return alInvoicesLine;
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

        public class Itemcustomfields
        {
            string _strCustItemRefNo = string.Empty;
            string _strCustItemRefFullName = string.Empty;
            string _strCustItemkey = string.Empty;
            string _strCustItemkeyvalue = string.Empty;
            string _strCustChildvalue = string.Empty;
            string _strCustParentvalue = string.Empty;

            public string CustItemRefFullName
            {
                get
                {
                    return _strCustItemRefFullName;
                }
                set
                {
                    _strCustItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
                }
            }

            public string CustItemRefNumber
            {
                get
                {
                    return _strCustItemRefNo;
                }
                set
                {
                    _strCustItemRefNo = value;
                }
            }

            public string CustItemkey
            {
                get
                {
                    return _strCustItemkey;
                }
                set
                {
                    _strCustItemkey = value;
                }
            }

            public string CustItemkeyvalue
            {
                get
                {
                    return _strCustItemkeyvalue;
                }
                set
                {
                    _strCustItemkeyvalue = value;
                }
            }


            public string CustChild
            {
                get
                {
                    return _strCustChildvalue;
                }
                set
                {
                    _strCustChildvalue = value;
                }
            }
            public string CustParent
            {
                get
                {
                    return _strCustParentvalue;
                }
                set
                {
                    _strCustParentvalue = value;
                }
            }


            public Itemcustomfields(string refnumber, string itemname, string keyname, string keyval)
            {
                CustItemRefNumber = refnumber;
                CustItemRefFullName = itemname;
                CustItemkey = keyname;
                CustItemkeyvalue = keyval;
            }
            public Itemcustomfields(string refnumber, string childcustomer, string parentcustomer, string keyname, string keyval)
            {
                CustItemRefNumber = refnumber;
                CustChild = childcustomer;
                CustParent = parentcustomer;
                CustItemkey = keyname;
                CustItemkeyvalue = keyval;
            }

        };

        public ArrayList GetPackagingInvoiceItems(string strstartdate, string strenddate, out List<Itemcustomfields> pobjItemExtensions)
        {
            ArrayList alInvoicesLine = new ArrayList();
            string strTxnLineID = string.Empty;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            string dictitemname = string.Empty;
            string dictrefnumber = string.Empty;
            bool blnfieldexist = false;

            List<Itemcustomfields> list = new List<Itemcustomfields>();

            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);

                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                InvoiceQuery.IncludeLineItems.SetValue(true);
                //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);

                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    IInvoiceLineRet loInvoiceLineRetItem = null;
                    IInvoiceLineGroupRet loInvoiceLineGroupRet = null;
                    clsInvoiceLine lobjclsInvoiceLine = null;


                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;

                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    lobjIItemQuery = default(IItemQuery);
                    IDataExtRetList lobjIDataExtRetList;
                    // int incr=0;

                    IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", 8, 0);

                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;


                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++)
                            {
                                //list = new List<Itemcustomfields>();
                                if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                {
                                    loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                    lobjclsInvoiceLine = GetInvItem(loInvoiceLineRetItem, string.Empty, string.Empty);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = loInvoice.RefNumber.GetValue();
                                        alInvoicesLine.Add(lobjclsInvoiceLine);

                                        dictitemname = lobjclsInvoiceLine.InvoiceLineItemRefFullName;
                                        dictrefnumber = lobjclsInvoiceLine.RefNumber;
                                        //}

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(lobjclsInvoiceLine._strInvoiceLineItemRefFullName);

                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsInvoiceLine.InvoiceItemName);
                                        //Set field value for ToName
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsInvoiceLine.InvoiceItemName);

                                        lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);

                                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
                                        {
                                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
                                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
                                            {
                                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
                                                {
                                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
                                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
                                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
                                                    {
                                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
                                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
                                                        {
                                                            //incr++;

                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {

                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        // if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //lobjItemExtensions.Add(strdName, strdValue);

                                                                        // Add three objects to a List.

                                                                        //list.Add(new Itemcustomfields(dictrefnumber, dictitemname, strdName, strdValue));


                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }

                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields(dictrefnumber, dictitemname, strdName, strdValue));
                                                                        }
                                                                        //lobjItemExtensions.Add(strdName + '=' + lobjclsInvoiceLine.RefNumber + "~" + lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdValue);
                                                                    }
                                                                }
                                                            }
                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                            {
                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {

                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        // if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //  lobjItemExtensions.Add(strdName, strdValue);
                                                                        // list.Add(new Itemcustomfields(dictrefnumber, dictitemname, strdName, strdValue));

                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsInvoiceLine.InvoiceLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields(dictrefnumber, dictitemname, strdName, strdValue));
                                                                        }

                                                                        //lobjItemExtensions.Add(strdName + '=' + lobjclsInvoiceLine.RefNumber + "~" + lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdValue);
                                                                    }
                                                                }


                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //------------------------------- Custom Fields Logic ---------------------------------//



                                    }


                                }
                                else
                                {
                                    loInvoiceLineGroupRet = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineGroupRet;
                                    lobjclsInvoiceLine = new clsInvoiceLine();
                                    lobjclsInvoiceLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsInvoiceLine.InvoiceLineItemRefFullName != string.Empty && lobjclsInvoiceLine.InvoiceLineQuantity != 0)
                                    {
                                        lobjclsInvoiceLine.RefNumber = loInvoice.RefNumber.GetValue();
                                        alInvoicesLine.Add(lobjclsInvoiceLine);
                                    }
                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = list;
                return alInvoicesLine;
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
}
