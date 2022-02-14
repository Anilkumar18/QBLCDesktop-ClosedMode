using System;
using System.Collections.Generic;
using System.Text;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Collections;
using System.Windows.Forms;
using LabelConnector;
using System.Configuration;
using System.Threading.Tasks;
using System.Threading;

namespace QBLC
{
    class clsSalesOrderLine
    {
      
        double _dblSalesOrderLineQuantity;
        //double _dblPreInvoiced;//new added
        //double _dblToInvoiced; //new added
        //double _dblItmePrice; //new added
        string _strPONumber;
        string _strShipMethod;
        double _dblItemAmount;
        string _strSalesOrderCustomer;
        string _strSalesOrderLineUnitOfMeasure;
        decimal _strToPick =0;
        string _strSalesOrderLineItemRefFullName;
        string _strSalesOrderLineDesc;
        string _strSalesOrderLineTxnLineID;
        string _strRefNumber;
        string _dtTxnDate;
        string _strCustomerRefFullName;
        string _strCustomerPOLineNo;
        string _strCustPartNo;
        string _CustNo;
        double _dblSOQty;
        string _strCompanyName;
        string _strShipAddressAddr1;
        string _strShipAddressAddr2;
        string _strShipAddressAddr3;
        string _strShipAddressAddr4;
        string _strShipAddressAddr5;
        string _strShipAddressCity;
        string _strShipAddressState;
        string _strShipAddressPostalCode;
        string _strShipAddressAddrPostalCode;
        string _strShipAddressCountry;
        double _unitpercase;
        string _Entry1;
        string _Entry2;
        string _soQtyOnLabel;
        string _strFOB;
        string _soother;
        string _dtDueDate;
        string _dtBarCodeValue;
        string _strsalesorderitemname;
        string _strSalesOrderLineRate;
        string _soShipDate;
        string _strSalesOrderOrderBin; // Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO
        string _strSOOther2; // Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        string _strOther2L;
        string _strSalesPrice;
        string _strMarkUpPrice;
        string _strManufacturerPartNumber;
        string _strLotNumber;
        string _strSalesRepRef;
        string _strOther1T;
        string _strOther1L;
        string _strNote;
        string _strcitystatezip = string.Empty;
        double _soqty1;
        string _strclass;
        string _strBillAddressAddr1;
        string _strBillAddressAddr2;
        string _strAmount;
        string _strCost;
        string _strSubItemof;


        // ***Start*** Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO 
        public string Bin
        {
            get { return _strSalesOrderOrderBin; }
            set { _strSalesOrderOrderBin = value; }
        }
        // ***End*** Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO 

        public string LotNumber
        {
            get { return _strLotNumber; }
            set { _strLotNumber = value; }
        }
        public string SubItemof
        {
            get { return _strSubItemof; }
            set { _strSubItemof = value.IndexOf(':') > -1 ? value.Substring(0, value.LastIndexOf(':')) : ""; }
        }
        public string QtyOnLabel
        {
            get { return _soQtyOnLabel; }
            set { _soQtyOnLabel = value; }
        }
        public double Qty1
        {
            get { return _soqty1; }
            set { _soqty1 = value; }
        }

        public string Other
        {
            get { return _soother; }
            set { _soother = value; }
        }

        public string SalesRepRef
        {
            get { return _strSalesRepRef; }
            set { _strSalesRepRef = value; }
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

        public string MarkUpPrice
        {
            get
            {
                return _strMarkUpPrice;
            }
            set
            {
                _strMarkUpPrice = value;
            }
        }

        public string ShipDate
        {
            get { return _soShipDate; }
            set { _soShipDate = value; }
        }
        public string Note
        {
            get { return _strNote; }
            set { _strNote = value; }
        }

        public string entryone
        {
            get { return _Entry1; }
            set { _Entry1 = value; }
        }
        public string entrytwo
        {
            get { return _Entry2; }
            set { _Entry2 = value; }
        }
        public string GroupItemType
        {
            get; set;
        }
        public double SalesOrderLineQuantity
        {
            get
            {
                return _dblSalesOrderLineQuantity;
            }
            set
            {
                _dblSalesOrderLineQuantity = value;
            }
        }
        //public double SOQty
        //{
        //    get
        //    {
        //        return _dblSOQty;
        //    }
        //    set
        //    {
        //        _dblSOQty = value;
        //    }
        //}

        public string PONumber
        {
            get { return _strPONumber; }
            set { _strPONumber = value; }
        }
        public string Cost
        {
            get { return _strCost; }
            set { _strCost = value; }
        }


        public string DueDate
        {
            get
            {
                return _dtDueDate;
            }

            set
            {
                _dtDueDate = value;
            }
        }
        public string BarCodeValue
        {
            get
            {
                return _dtBarCodeValue;
            }

            set
            {
                _dtBarCodeValue = value;
            }
        }

        public string CustNo
        {
            get { return _CustNo; }
            set { _CustNo = value; }
        }

        public double UnitsPerCase
        {
            get { return _unitpercase; }
            set { _unitpercase = value; }
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


        public string SalesOrderShipMethod
        {
            get { return _strShipMethod; }
            set { _strShipMethod = value; }
        }

        public string SalesOrdrCustomer
        {
            get { return _strSalesOrderCustomer; }
            set { _strSalesOrderCustomer = value; }

        }

        public string CustomerPOLineNo
        {
            get { return _strCustomerPOLineNo; }
            set { _strCustomerPOLineNo = value; }
        }
        //***Start***Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        public string SOOther2
        {
            get { return _strSOOther2; }
            set { _strSOOther2 = value; }
        }
        //***End***Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        public string CustPartNo
        {
            get { return _strCustPartNo; }
            set { _strCustPartNo = value; }
        }

        public string SalesOrderLineUnitOfMeasure
        {
            get
            {
                return _strSalesOrderLineUnitOfMeasure;
            }

            set
            {
                _strSalesOrderLineUnitOfMeasure = value == null ? "" : value;
            }
        }
        public string SalesOrderLineItemRefFullName
        {
            get
            {
                return _strSalesOrderLineItemRefFullName;
            }
            set
            {
                //_strSalesOrderLineItemRefFullName = value;
                _strSalesOrderLineItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
            }
        }
        //public decimal ToPick
        //{
        //    get
        //    {
        //        return _strToPick;
        //    }
        //    set
        //    {
        //        //_strSalesOrderLineItemRefFullName = value;
        //        _strToPick = value;
        //    }
        //}
        public string SalesORderItemName
        {
            get { return _strsalesorderitemname; }
            set { _strsalesorderitemname = value; }
        }
        public string SalesOrderLineDesc
        {
            get
            {
                return _strSalesOrderLineDesc;
            }
            set
            {
                _strSalesOrderLineDesc = value;
            }
        }

        public string Other1T
        {
            get
            {
                return _strOther1T;
            }
            set
            {
                _strOther1T = value;
            }
        }

        public string Other1L
        {
            get
            {
                return _strOther1L;
            }
            set
            {
                _strOther1L = value;
            }
        }

        public string Other2L
        {
            get
            {
                return _strOther2L;
            }
            set
            {
                _strOther2L = value;
            }
        }

        public string MPN
        {
            get { return _strManufacturerPartNumber; }
            set { _strManufacturerPartNumber = value; }
        }

        public string SalesOrderLineTxnLineID
        {
            get
            {
                return _strSalesOrderLineTxnLineID;
            }
            set
            {
                _strSalesOrderLineTxnLineID = value;
            }
        }

        public string SalesOrderLineRate
        {
            get { return _strSalesOrderLineRate; }
            set { _strSalesOrderLineRate = value; }
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

        public string Class
        {
            get { return _strclass; }
            set { _strclass = value; }
        }
        public string Amount
        {
            get
            {
                return _strAmount;
            }
            set
            {
                _strAmount = value;
            }

        }


        public string CustomerCompanyName
        {
            get
            {
                return _strCompanyName;
            }
            set
            {
                _strCompanyName = value;
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

        public string CustomerRefFullName
        {
            get
            {
                return _strCustomerRefFullName;
            }
            set
            {
                _strCustomerRefFullName = value;
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

        public class Itemcustomfields
        {
            string _strCustItemRefNo = string.Empty;
            string _strCustItemRefFullName = string.Empty;
            string _strCustItemkey = string.Empty;
            string _strCustItemkeyvalue = string.Empty;

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


            public Itemcustomfields(string refnumber, string itemname, string keyname, string keyval)
            {
                CustItemRefNumber = refnumber;
                CustItemRefFullName = itemname;
                CustItemkey = keyname;
                CustItemkeyvalue = keyval;
            }


        };

        //Get filtered Sales orders by date range to print: 08-09-2016

        public ArrayList GetFilterSalesOrderForPrint(string strstartdate, string strenddate, out List<Dictionary<string, string>> pobjItemExtensions)
        {
            ArrayList alSalesOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
            decimal roundofresult;
            string lstrCustomerCustomFieldColonLeftpart = string.Empty;
            string lstrCustomerCustomFieldColonRightpart = string.Empty;
            QBSessionManager lQBSessionManager = null;
            List<Dictionary<string, string>> objcustvalue = new List<Dictionary<string, string>>();
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            string strItemcost = string.Empty;
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
                //Set field value for ToTxnDate
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    if (loList != null)
                    {

                        IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                        ICustomerRetList lobjICustomerRetList = null;
                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;

                        IDataExtRetList lobjIDataExtRetList;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                clsSalesOrderLine objSOLine = new clsSalesOrderLine();

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {

                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = "";
                                    }
                                }
                                if (objSOLine.SalesOrderLineItemRefFullName == "")
                                {
                                    continue;
                                }

                                IItemOtherChargeRetList loList1 = null;
                                if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnableotherchargesfields").ToString() == "0"))
                                {
                                    OtherChargeQueryRq.OwnerIDList.Add("0");
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                    IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                    loList1 = (IItemOtherChargeRetList)loResponse2.Detail;
                                }

                                if (loList1 == null)
                                {
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                    {
                                        objSOLine = new clsSalesOrderLine();

                                        //Get child items for Group Item:Date 26-Feb-2020
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                        {
                                            for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                            {
                                                objSOLine = new clsSalesOrderLine();
                                                ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);

                                                if (SalesOrderLineRet.ItemRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    objSOLine.SalesORderItemName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                }
                                                if (SalesOrderLineRet.Desc != null)
                                                {
                                                    objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                                }
                                                if (SalesOrderLineRet.Quantity != null)
                                                {
                                                    objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                                }
                                                if (SalesOrderLineRet.ORRate != null)
                                                {
                                                    if (SalesOrderLineRet.ORRate.Rate != null)
                                                    {
                                                        objSOLine.SalesPrice = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.SalesPrice = null;
                                                }
                                                if (SalesOrderLineRet.Other1 != null) //16-Mar-2020
                                                {
                                                    objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other1L = "";
                                                }
                                                if (SalesOrderLineRet.Other2 != null)
                                                {
                                                    objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other2L = "";
                                                }
                                                if (SalesOrderLineRet.ClassRef != null)
                                                {
                                                    if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSOLine.Class = "";
                                                    }
                                                }
                                                if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Amount = "";
                                                }
                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSOLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSOLine.Cost = "";
                                                }
                                                if (SalesOrderLineRet.TxnLineID != null)
                                                {
                                                    objSOLine.SalesOrderLineTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineTxnLineID = "";
                                                }
                                                if (loSalesOrder.CustomerRef != null)
                                                {

                                                    objSOLine.CustomerRefFullName = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.CustomerRefFullName = "";
                                                }


                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());




                                                //----------------------- News logic end to Get custom fields from sales order---------------
                                                //custom field show for sales order added by khushal:date 01/24/13
                                                lobjIItemQuery = default(IItemQuery);
                                                lMsgItemsRequest.ClearRequests();

                                                lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                                lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                                lobjIItemQuery.OwnerIDList.Add("0");
                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesORderItemName);

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
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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

                                                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                                {
                                                    ICustomerQuery CustomerQuery = default(ICustomerQuery);
                                                    lMsgRequest.ClearRequests();
                                                    CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                                                    CustomerQuery.OwnerIDList.Add("0");
                                                    CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.CustomerRefFullName);
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
                                                    string refvalue = objSOLine.RefNumber + "&" + objSOLine.SalesOrderLineTxnLineID;
                                                    lobjItemExtensions.Add("refnumber", refvalue);
                                                    objcustvalue.Add(lobjItemExtensions);
                                                    lobjItemExtensions = new Dictionary<string, string>();

                                                }


                                                alSalesOrdersLine.Add(objSOLine); //add child for group item

                                            }
                                        }
                                    }


                                    else if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                    {

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
                                        {
                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineQuantity = 0.00;

                                        }
                                        if(!string.IsNullOrWhiteSpace(objSOLine.SalesOrderLineItemRefFullName))
                                        {
                                            objSOLine.BarCodeValue = GetItemsBarCode(objSOLine.SalesOrderLineItemRefFullName);
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = "";
                                        }

                                        
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                            objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = "";
                                        }
                                        objSOLine.SubItemof = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()) != null ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()) : "";
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                        {
                                            objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineDesc = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = "";
                                        }


                                        if (loSalesOrder.PONumber != null)
                                        {

                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.PONumber = "";
                                        }

                                        if (loSalesOrder.CustomerRef != null)
                                        {

                                            objSOLine.CustomerRefFullName = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.CustomerRefFullName = "";
                                        }

                                        objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                        objSOLine.TxnDate = Convert.ToString(loSalesOrder.TxnDate.GetValue().ToString("MM-dd-yyyy"));
                                        if (loSalesOrder.FOB != null) objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());


                                        if (loSalesOrder.ShipAddress != null)
                                        {
                                            if (loSalesOrder.ShipAddress.Addr1 != null)
                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr2 != null)
                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr3 != null)
                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr4 != null)
                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr5 != null)
                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                            if (loSalesOrder.ShipAddress.City != null)
                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                            if (loSalesOrder.ShipAddress.State != null)
                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                            if (loSalesOrder.ShipAddress.PostalCode != null)
                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                            if (loSalesOrder.ShipAddress.Country != null)
                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                            if (loSalesOrder.ShipMethodRef != null) Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue());
                                            if (loSalesOrder.ShipDate != null) Convert.ToString(loSalesOrder.ShipDate.GetValue());

                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                            {
                                                objSOLine.SalesPrice = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                            }
                                        }
                                        else
                                        {
                                            objSOLine.SalesPrice = null;
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null) //16-Mar-2020
                                        {
                                            objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other1L = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
                                        {
                                            objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other2L = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                            {
                                                objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Class = "";
                                            }
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null) //16-Mar-2020
                                        {
                                            objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Amount = "";
                                        }
                                        if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                        {
                                            objSOLine.Cost = Convert.ToString(strItemcost);
                                        }
                                        else
                                        {
                                            objSOLine.Cost = "";
                                        }



                                        if (objSOLine.SalesOrderLineItemRefFullName == "" || objSOLine.SalesOrderLineQuantity == 0)
                                        {
                                            continue;
                                        }


                                        //----------------------- News logic end to Get custom fields from sales order---------------
                                        //custom field show for sales order added by khushal:date 01/24/13

                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                                        {
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesORderItemName);

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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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

                                            if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                                            {
                                                ICustomerQuery CustomerQuery = default(ICustomerQuery);
                                                lMsgRequest.ClearRequests();
                                                CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                                                CustomerQuery.OwnerIDList.Add("0");
                                                CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.CustomerRefFullName);
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
                                                string refvalue = objSOLine.RefNumber + "&" + objSOLine.SalesOrderLineTxnLineID;
                                                lobjItemExtensions.Add("refnumber", refvalue);
                                                objcustvalue.Add(lobjItemExtensions);
                                                lobjItemExtensions = new Dictionary<string, string>();

                                            }
                                        }

                                        alSalesOrdersLine.Add(objSOLine);

                                    }


                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = objcustvalue;
                return alSalesOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                //pobjItemExtensions = null; 
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




        //public ArrayList GetFilterSalesOrderForPrint(string strstartdate, string strenddate)
        //{
        //    ArrayList alSalesorderLine = new ArrayList();
        //    string strTxnLineID = string.Empty;

        //    QBSessionManager lQBSessionManager = null;
        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //        ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

        //        SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
        //        SalesOrderQuery.IncludeLineItems.SetValue(true);


        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
        //        //Set field value for ToTxnDate
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

        //        if (lMsgResponse.ResponseList.Count > 0)
        //        {
        //            //we have one response for  single add request
        //            IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
        //            ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
        //            ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
        //            ISalesOrderLineRet loSalesOrderLineRetItem = null;
        //            ISalesOrderLineGroupRet loSalesOrderLineGroupRet = null;
        //            clsSalesOrderLine lobjclsSalesOrderLine = null;

        //            if (loList != null)
        //            {
        //                for (int Index = 0; Index < loList.Count; Index++)
        //                {
        //                    loSalesOrder = loList.GetAt(Index);

        //                    for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
        //                    {
        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
        //                        {
        //                            loSalesOrderLineRetItem = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet;
        //                            lobjclsSalesOrderLine = GetInvItem(loSalesOrderLineRetItem);
        //                            //Below condition to not show item if it is empty
        //                            if (lobjclsSalesOrderLine.SalesOrderLineItemRefFullName != "")
        //                            {
        //                                lobjclsSalesOrderLine.RefNumber = loSalesOrder.RefNumber.GetValue();
        //                                alSalesorderLine.Add(lobjclsSalesOrderLine);
        //                            }

        //                            if (loSalesOrder.PONumber != null)
        //                            {
        //                                lobjclsSalesOrderLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
        //                            }
        //                            else
        //                            {

        //                                lobjclsSalesOrderLine.PONumber = string.Empty;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            loSalesOrderLineGroupRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet;
        //                            lobjclsSalesOrderLine = new clsSalesOrderLine();
        //                            lobjclsSalesOrderLine = GetInvGroupItem(loSalesOrderLineGroupRet);
        //                            //Below condition to not show item if it is empty
        //                            if (lobjclsSalesOrderLine.SalesOrderLineItemRefFullName != string.Empty)
        //                            {
        //                                lobjclsSalesOrderLine.RefNumber = loSalesOrder.RefNumber.GetValue();
        //                                alSalesorderLine.Add(lobjclsSalesOrderLine);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return alSalesorderLine;
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

        //Get filtered Sales orders by date range to print: 08-09-2016 



        //public ArrayList GetFilterSalesOrderForPrint(string strstartdate, string strenddate, out Dictionary<string, string> pobjItemExtensions)
        //{
        //    ArrayList alSalesOrdersLine = new ArrayList();

        //    Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
        //    //step2: create QBFC session manager and prepare the request
        //    //QBSessionManager lQBSessionManager = default(QBSessionManager);
        //    QBSessionManager lQBSessionManager = null;

        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
        //    IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


        //        ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

        //        SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

        //        IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();

        //        SalesOrderQuery.IncludeLineItems.SetValue(true);

        //        SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

        //        // SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
        //        //Set field value for ToTxnDate
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

        //        if ((lMsgResponse.ResponseList.Count > 0))
        //        {
        //            //we have one response for  single add request

        //            IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

        //            ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
        //            ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
        //            ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

        //            //------------------------- DataExtensionFields -----------------------------
        //            string strTxnLineID = string.Empty;
        //            string strdName = string.Empty;
        //            string strdValue = string.Empty;
        //            string strOwnerID = string.Empty;
        //            if (loList != null)
        //            {

        //                IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //                lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //                IItemQuery lobjIItemQuery = null;
        //                IResponse lobjIResponse;
        //                ENObjectType lobjResponseDetailType;
        //                IORItemRetList lobjIORItemRetList;
        //                ENResponseType lobjResponseType;

        //                IORItemRet lobjIORItemRet;
        //                IMsgSetResponse lobjIMsgSetResponse;

        //                IDataExtRetList lobjIDataExtRetList;

        //                for (int Index = 0; Index < loList.Count; Index++)
        //                {
        //                    loSalesOrder = loList.GetAt(Index);
        //                    for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
        //                    {
        //                        clsSalesOrderLine objSOLine = new clsSalesOrderLine();
        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
        //                        {

        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                            {
        //                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineItemRefFullName = "";
        //                            }
        //                        }
        //                        if (objSOLine.SalesOrderLineItemRefFullName == "")
        //                        {
        //                            continue;
        //                        }
        //                        OtherChargeQueryRq.OwnerIDList.Add("0");
        //                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
        //                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
        //                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
        //                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
        //                        IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
        //                        IItemOtherChargeRetList loList1 = (IItemOtherChargeRetList)loResponse2.Detail;


        //                        if (loList1 == null)
        //                        {

        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
        //                        {

        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
        //                            {
        //                                objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineQuantity = 0.00;

        //                            }

        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
        //                            {
        //                                objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineUnitOfMeasure = "";
        //                            }
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                            {
        //                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineItemRefFullName = "";
        //                            }
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
        //                            {
        //                                objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineDesc = "";
        //                            }

        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
        //                            {
        //                                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineTxnLineID = "";
        //                            }


        //                            if (loSalesOrder.PONumber != null)
        //                            {

        //                                objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.PONumber = "";
        //                            }



        //                            objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
        //                            objSOLine.TxnDate = Convert.ToString(loSalesOrder.TxnDate.GetValue().ToString("MM-dd-yyyy"));
        //                            if (loSalesOrder.FOB != null) objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());


        //                            if (loSalesOrder.ShipAddress != null)
        //                            {
        //                                if (loSalesOrder.ShipAddress.Addr1 != null)
        //                                    objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

        //                                if (loSalesOrder.ShipAddress.Addr2 != null)
        //                                    objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

        //                                if (loSalesOrder.ShipAddress.Addr3 != null)
        //                                    objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());

        //                                if (loSalesOrder.ShipAddress.Addr4 != null)
        //                                    objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());

        //                                if (loSalesOrder.ShipAddress.Addr5 != null)
        //                                    objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

        //                                if (loSalesOrder.ShipAddress.City != null)
        //                                    objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

        //                                if (loSalesOrder.ShipAddress.State != null)
        //                                    objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

        //                                if (loSalesOrder.ShipAddress.PostalCode != null)
        //                                    objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

        //                                if (loSalesOrder.ShipAddress.Country != null)
        //                                    objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

        //                                if (loSalesOrder.ShipMethodRef != null) Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue());
        //                                if (loSalesOrder.ShipDate != null) Convert.ToString(loSalesOrder.ShipDate.GetValue());

        //                            }
        //                        }

        //                        if (objSOLine.SalesOrderLineItemRefFullName == "" || objSOLine.SalesOrderLineQuantity == 0)
        //                        {
        //                            continue;
        //                        }


        //                        //----------------------- News logic end to Get custom fields from sales order---------------
        //                        //custom field show for sales order added by khushal:date 01/24/13
        //                        lobjIItemQuery = default(IItemQuery);
        //                        lMsgItemsRequest.ClearRequests();

        //                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
        //                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
        //                        lobjIItemQuery.OwnerIDList.Add("0");
        //                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
        //                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);

        //                        lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);
        //                        if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
        //                        {
        //                            lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
        //                            if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
        //                            {
        //                                if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
        //                                {
        //                                    lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
        //                                    lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
        //                                    if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
        //                                    {
        //                                        lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
        //                                        for (int i = 0; i < lobjIORItemRetList.Count; i++)
        //                                        {
        //                                            lobjIORItemRet = lobjIORItemRetList.GetAt(i);
        //                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
        //                                            {
        //                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
        //                                                if (lobjIDataExtRetList != null)
        //                                                {
        //                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                    {
        //                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
        //                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                        if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                            lobjItemExtensions.Add(strdName, strdValue);
        //                                                    }
        //                                                }
        //                                            }
        //                                            else if (lobjIORItemRet.ItemInventoryRet != null)
        //                                            {
        //                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
        //                                                if (lobjIDataExtRetList != null)
        //                                                {
        //                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                    {
        //                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
        //                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                        if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                            lobjItemExtensions.Add(strdName, strdValue);
        //                                                    }
        //                                                }
        //                                            }
        //                                            //Add non inventory Item custom field from items
        //                                            else if (lobjIORItemRet.ItemNonInventoryRet != null)
        //                                            {
        //                                                lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
        //                                                if (lobjIDataExtRetList != null)
        //                                                {
        //                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                    {
        //                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
        //                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                        if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                            lobjItemExtensions.Add(strdName, strdValue);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }

        //                        //custom field code end//

        //                        //Below code added from H-H ver : Date 06/25/2015

        //                        //IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

        //                        //if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
        //                        //{
        //                        //    for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
        //                        //    {
        //                        //        IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);


        //                        //        strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim();
        //                        //        //Get value of DataExtType
        //                        //        ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
        //                        //        //Get value of DataExtValue
        //                        //        strdValue = (string)DataExtRet.DataExtValue.GetValue();
        //                        //        //Get QtyperContainer Custom field value:Date 05-23-2016
        //                        //        if (strdName.ToUpper() != "QTYPERCONTAINER")
        //                        //        {
        //                        //            if (!lobjItemExtensions.ContainsKey(strdName))
        //                        //            {
        //                        //                lobjItemExtensions.Add(strdName, strdValue);
        //                        //            }
        //                        //            else
        //                        //            {
        //                        //                //update key/value
        //                        //                lobjItemExtensions.Remove(strdName);
        //                        //                lobjItemExtensions.Add(strdName, strdValue);


        //                        //            }
        //                        //        }

        //                        //    }
        //                        //}
        //                        alSalesOrdersLine.Add(objSOLine);

        //                        // }
        //                    }
        //                    }
        //                }
        //            }
        //        }
        //        pobjItemExtensions = lobjItemExtensions;
        //        return alSalesOrdersLine;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //        //pobjItemExtensions = null; 
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


        private clsSalesOrderLine GetInvItem(ISalesOrderLineRet poInvoiceLineRet)
        {
            clsSalesOrderLine objSOLine = new clsSalesOrderLine();
            double dbluomquantity = 0;
            string lstruomquantity = string.Empty;

            if (poInvoiceLineRet.Quantity != null)
            {
                objSOLine.SalesOrderLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
                // objINVLine.InvoiceQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
            }
            else
            {
                objSOLine.SalesOrderLineQuantity = 0.00;
            }

            if (poInvoiceLineRet.UnitOfMeasure != null)
            {
                objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue());
                //convert UOM quantity to quantity
                if (poInvoiceLineRet.Quantity != null)
                {
                    lstruomquantity = System.Text.RegularExpressions.Regex.Replace(Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue()), "[^0-9]+", string.Empty);
                    if (!string.IsNullOrWhiteSpace(lstruomquantity))
                    {
                        dbluomquantity = Convert.ToDouble(lstruomquantity);
                        objSOLine.SalesOrderLineQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue()) / dbluomquantity;
                    }

                }

            }
            else
            {
                objSOLine.SalesOrderLineUnitOfMeasure = "";
            }


            if (poInvoiceLineRet.ItemRef != null)
            {
                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
                objSOLine.SalesORderItemName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());


            }

            else
            {
                objSOLine.SalesOrderLineItemRefFullName = "";
            }
            if (poInvoiceLineRet.Desc != null)
            {
                objSOLine.SalesOrderLineDesc = Convert.ToString(poInvoiceLineRet.Desc.GetValue());
            }
            else
            {
                objSOLine.SalesOrderLineDesc = "";
            }
            //for test only:Date 01-Nov-2018
            if (poInvoiceLineRet.Other1 != null)
            {
                objSOLine.Other1L = poInvoiceLineRet.Other1.GetValue();

            }
            else
            {
                objSOLine.Other1L = "";
            }
            if (poInvoiceLineRet.TxnLineID != null)
            {
                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(poInvoiceLineRet.TxnLineID.GetValue());
            }
            else
            {
                objSOLine.SalesOrderLineTxnLineID = "";
            }

            return objSOLine;
        }

        private clsSalesOrderLine GetInvGroupItem(ISalesOrderLineGroupRet poInvoiceLineGroupRet)
        {
            clsSalesOrderLine objSoLine = new clsSalesOrderLine();

            if (poInvoiceLineGroupRet.Quantity != null)
            {
                objSoLine.SalesOrderLineQuantity = Convert.ToDouble(poInvoiceLineGroupRet.Quantity.GetValue());
            }
            else
            {
                objSoLine.SalesOrderLineQuantity = 0.00;
            }

            if (poInvoiceLineGroupRet.Desc != null)
            {
                objSoLine.SalesOrderLineDesc = Convert.ToString(poInvoiceLineGroupRet.Desc.GetValue());
            }
            else
            {
                objSoLine.SalesOrderLineDesc = string.Empty;
            }

            if (poInvoiceLineGroupRet.ItemGroupRef != null)
            {
                objSoLine.SalesOrderLineItemRefFullName = Convert.ToString(poInvoiceLineGroupRet.ItemGroupRef.FullName.GetValue());
            }
            else
            {
                objSoLine.SalesOrderLineItemRefFullName = string.Empty;
            }

            if (poInvoiceLineGroupRet.TxnLineID != null)
            {
                objSoLine.SalesOrderLineTxnLineID = Convert.ToString(poInvoiceLineGroupRet.TxnLineID.GetValue());
            }
            else
            {
                objSoLine.SalesOrderLineTxnLineID = string.Empty;
            }

            if (poInvoiceLineGroupRet.UnitOfMeasure != null)
            {
                objSoLine.SalesOrderLineUnitOfMeasure = Convert.ToString(poInvoiceLineGroupRet.UnitOfMeasure.GetValue());
            }
            else
            {
                objSoLine.SalesOrderLineUnitOfMeasure = string.Empty;
            }

            return objSoLine;
        }

        //sales order item display for close mode
        public ArrayList GetSOLine(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
          
            ArrayList alSalesOrdersLine = new ArrayList();
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
              
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);
                    string strExtFieldName = string.Empty;
                    string strExtFieldValue = string.Empty;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                clsSalesOrderLine objSOLine = new clsSalesOrderLine();

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                              
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue() != 0)
                                {
                                    objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
                                  
                                    //To show PONumber
                                    if (loSalesOrder.PONumber != null)
                                    {
                                        objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.PONumber = "";
                                    }

                                    //To show shipping method
                                    if (loSalesOrder.ShipMethodRef != null)
                                    {
                                        objSOLine.SalesOrderShipMethod = Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderShipMethod = "";
                                    }
                                    if (loSalesOrder.CustomerRef.FullName != null)
                                    {
                                        objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrdrCustomer = "";
                                    }

                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                    {
                                        objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineUnitOfMeasure = "";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = "";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                    {
                                        objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineDesc = "";
                                    }

                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = "";
                                    }
                                   

                                    IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                    if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                    {
                                        for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                        {
                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);
                                           
                                            switch ((string)DataExtRet.DataExtName.GetValue().ToUpper().Trim())
                                            {

                                                case "OTHER1":
                                                    objSOLine.CustomerPOLineNo = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                case "CUSTNO":
                                                    objSOLine.CustNo = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                case "OTHER2":
                                                    objSOLine.SOOther2 = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                default:
                                                    break;


                                            }
                                      
                                        }
                                    }

                                    alSalesOrdersLine.Add(objSOLine);


                                }
                            }
                        }
                    }
                }
                return alSalesOrdersLine;
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


        private clsSalesOrderLine GetSoGroupItem(ISalesOrderLineGroupRet poInvoiceLineGroupRet)
        {

            clsSalesOrderLine objsoLine = new clsSalesOrderLine();

            if (poInvoiceLineGroupRet.ItemGroupRef != null)
            {
                objsoLine.CustomerRefFullName = Convert.ToString(poInvoiceLineGroupRet.ItemGroupRef.FullName.GetValue());
            }
            return objsoLine;
        }

        //get gridline in sales order mode.

       
        public async Task <ArrayList> GetGridSOLine(string strRefNumber, string strMarkupPriceField)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            ArrayList alSalesOrdersLine = new ArrayList();
            ArrayList alSalesOrdersFieldLine = new ArrayList();
            clsGridSalesOrderLine objclsSOLine;

            Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
            decimal roundofresult;
            string lstrCustomerCustomFieldColonLeftpart = string.Empty;
            string lstrCustomerCustomFieldColonRightpart = string.Empty;

         
            QBSessionManager lQBSessionManager = ModGlobal.QBGlobalSessionManager; 
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

          
            try
            {
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
             
                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    string strItemcost = string.Empty;

                    IItemQuery lobjIItemQuery = null;
                    IResponse lobjIResponse;
                    ENObjectType lobjResponseDetailType;
                    IORItemRetList lobjIORItemRetList;
                    ENResponseType lobjResponseType;
                    IORItemRet lobjIORItemRet;
                    IMsgSetResponse lobjIMsgSetResponse;
                    IDataExtRetList lobjIDataExtRetList;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                   

                    if (loList != null)
                    {
                       await Task.Run(() => {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                clsGridSalesOrderLine objSOLine;
                                

                                   if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {
                                    objSOLine = new clsGridSalesOrderLine();
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName != null)
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName.GetValue();
                                        objSOLine.GroupItemType = "P";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity != null)
                                    {
                                        objSOLine.SalesOrderLineQuantity = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity.GetValue();

                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc != null)
                                    {
                                        objSOLine.SalesOrderLineDesc = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc.GetValue();

                                    }
                                    //9-Dec-2018.Add new condition for group item print
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID != null)
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = "";
                                    }
                                   // objSOLine.ToPick = 0;
                                    alSalesOrdersLine.Add(objSOLine); //Group parent Item add
                                    //Get child items for Group Item:Date 26-Feb-2020
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {
                                            objSOLine = new clsGridSalesOrderLine();
                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
                                           
                                            if (SalesOrderLineRet.ItemRef.FullName != null)
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                            }
                                            if (SalesOrderLineRet.Desc != null)
                                            {
                                                objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                            }
                                            if (SalesOrderLineRet.Quantity != null)
                                            {
                                                objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                            }
                                            if (SalesOrderLineRet.ORRate != null)
                                            {
                                                if (SalesOrderLineRet.ORRate.Rate != null)
                                                {
                                                    objSOLine.SalesPrice = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                            }
                                            else
                                            {
                                                objSOLine.SalesPrice = null;
                                            }
                                            if (SalesOrderLineRet.Other1 != null) //16-Mar-2020
                                            {
                                                objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Other1L = "";
                                            }
                                            if (SalesOrderLineRet.Other2 != null)
                                            {
                                                objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Other2L = "";
                                            }
                                            if (SalesOrderLineRet.ClassRef != null)
                                            {
                                                if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                {
                                                    objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Class = "";
                                                }
                                            }
                                            if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                            {
                                                objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Amount = "";
                                            }
                                            if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                            {
                                                objSOLine.Cost = Convert.ToString(strItemcost);
                                            }
                                            else
                                            {
                                                objSOLine.Cost = "";
                                            }
                                            if (SalesOrderLineRet.TxnLineID != null)
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = "";
                                            }
                                               if (loSalesOrder.CustomerRef.FullName != null)
                                               {
                                                   objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                                   //Get Customer custom field
                                                   if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                   {
                                                       lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer,false);
                                                   }
                                               }
                                               else
                                               {
                                                   objSOLine.SalesOrdrCustomer = "";
                                               }

                                               if (lcustomercustomfield.Count > 0)
                                               {
                                                   //Get Dictionary value by key SalesOrderLineRateDiscounted
                                                   // if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED"))
                                                   if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                   {
                                                       //Get Item Sales price
                                                       // objSOLine.SalesPrice = GetItemSalesPrice(objSOLine.SalesORderItemName);
                                                       if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
                                                       {
                                                           //get Left and right part of the ":" in string
                                                           lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                           lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                           // Multiply sales price by custom field left part(:) value and round off value
                                                           // roundofresult = Math.Round(Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
                                                           //Remove Round off from calculation :Date 22-Mar-2018
                                                           roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                           if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                           {

                                                               objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                           }
                                                           else
                                                           {
                                                               objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                           }
                                                       }


                                                   }
                                               }

                                               alSalesOrdersLine.Add(objSOLine); //add child for group item

                                        }
                                    }
                                }

                                else if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {
                                    objSOLine = new clsGridSalesOrderLine();
                                    //Do not show item when quantity does not exist or zero: Date 01/07/2015
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue() != 0 && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                    {
                                          
                                           if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                               
                                           }

                                          
                                           IItemOtherChargeRetList loList1 = null;
                                           if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnableotherchargesfields").ToString() == "0"))
                                           {
                                               OtherChargeQueryRq.OwnerIDList.Add("0");
                                               OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                               OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                               OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                               lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                               IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                                loList1 = (IItemOtherChargeRetList)loResponse2.Detail;
                                           }

                                           if (loList1 == null)
                                            {
                                               


                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
                                           
                                            objSOLine.PONumber = (loSalesOrder.PONumber != null) ? Convert.ToString(loSalesOrder.PONumber.GetValue()) : "";

                                            objSOLine.SalesOrderShipMethod = (loSalesOrder.ShipMethodRef != null) ? Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue()) : "";
                                               if (loSalesOrder.CustomerRef.FullName != null)
                                               {
                                                   objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                                   //Get Customer custom field
                                                   //if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED") == false)
                                                   if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                   {
                                                       lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer,false);
                                                   }
                                               }
                                               else
                                               {
                                                   objSOLine.SalesOrdrCustomer = "";
                                               }

                                               objSOLine.SalesOrderLineUnitOfMeasure = (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null) ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue()) : "";

                                         

                                               if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                //Show MPN:16-Mar-2020
                                               // objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                //Added on 29-11-2017
                                                objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

                                                   objSOLine.SubItemof = objSOLine.SalesORderItemName != null ? objSOLine.SalesORderItemName : "";



                                                   //Get Item Sales price

                                                   if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null)
                                                {
                                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                                    {
                                                        objSOLine.SalesPrice = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.SalesPrice = null;
                                                }

                                                   if (lcustomercustomfield.Count > 0)
                                                   {
                                                       //Get Dictionary value by key SalesOrderLineRateDiscounted
                                                       // if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED"))
                                                       if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                       {
                                                           //Get Item Sales price
                                                           // objSOLine.SalesPrice = GetItemSalesPrice(objSOLine.SalesORderItemName);
                                                           if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
                                                           {
                                                               //get Left and right part of the ":" in string
                                                               lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                               lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                               // Multiply sales price by custom field left part(:) value and round off value
                                                               // roundofresult = Math.Round(Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
                                                               //Remove Round off from calculation :Date 22-Mar-2018
                                                               roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                               if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                               {
                                                                   //objSOLine.MarkUpPrice = Convert.ToString(roundofresult) + "." + lstrCustomerCustomFieldColonRightpart;
                                                                   objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                               }
                                                               else
                                                               {
                                                                   objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                               }
                                                           }


                                                       }
                                                   }
                                               }
                                            else
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = "";
                                                objSOLine.SalesORderItemName = "";
                                            }

                                            objSOLine.SalesOrderLineDesc = (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null) ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue()) : "";

                                              

                                               objSOLine.Amount = (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null) ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue()) : "";

                                            objSOLine.Cost = (!string.IsNullOrWhiteSpace(strItemcost)) ? Convert.ToString(strItemcost) : "";

                                               if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null) //16-Mar-2020
                                               {
                                                   objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                               }
                                               else
                                               {
                                                   objSOLine.Other1L = "";
                                               }
                                               if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
                                               {
                                                   objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                               }
                                               else
                                               {
                                                   objSOLine.Other2L = "";
                                               }

                                               if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                            {
                                                objSOLine.Class = (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null) ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue()) : "";
                                            }

                                            objSOLine.SalesOrderLineTxnLineID = (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null) ? Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue()) : "";
                                            


                                            alSalesOrdersLine.Add(objSOLine);
                                        }

                                    }
                                }


                               
                              
                             }
                    }
                        });
                    }
                }

                return alSalesOrdersLine;

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


        //sales order item display for open mode,add out param:Date 10-APR-2019
        public ArrayList GetSOLine(string strRefNumber, string strMarkupPriceField)
        {

            ArrayList alSalesOrdersLine = new ArrayList();

            Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
            decimal roundofresult;
            string lstrCustomerCustomFieldColonLeftpart = string.Empty;
            string lstrCustomerCustomFieldColonRightpart = string.Empty;


            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    string strItemcost = string.Empty;


                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                clsSalesOrderLine objSOLine;

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {
                                    objSOLine = new clsSalesOrderLine();
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName != null)
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName.GetValue();
                                        objSOLine.GroupItemType = "P";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity != null)
                                    {
                                        objSOLine.SalesOrderLineQuantity = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity.GetValue();

                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc != null)
                                    {
                                        objSOLine.SalesOrderLineDesc = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc.GetValue();

                                    }
                                    //9-Dec-2018.Add new condition for group item print
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID != null)
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = "";
                                    }
                                    // objSOLine.ToPick = 0;
                                    alSalesOrdersLine.Add(objSOLine); //Group parent Item add
                                    //Get child items for Group Item:Date 26-Feb-2020
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {
                                            objSOLine = new clsSalesOrderLine();
                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);

                                            if (SalesOrderLineRet.ItemRef.FullName != null)
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                            }
                                            if (SalesOrderLineRet.Desc != null)
                                            {
                                                objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                            }
                                            if (SalesOrderLineRet.Quantity != null)
                                            {
                                                objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                            }
                                            if (SalesOrderLineRet.ORRate != null)
                                            {
                                                if (SalesOrderLineRet.ORRate.Rate != null)
                                                {
                                                    objSOLine.SalesPrice = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                            }
                                            else
                                            {
                                                objSOLine.SalesPrice = null;
                                            }
                                            if (SalesOrderLineRet.Other1 != null) //16-Mar-2020
                                            {
                                                objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Other1L = "";
                                            }
                                            if (SalesOrderLineRet.Other2 != null)
                                            {
                                                objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Other2L = "";
                                            }
                                            if (SalesOrderLineRet.ClassRef != null)
                                            {
                                                if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                {
                                                    objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Class = "";
                                                }
                                            }
                                            if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                            {
                                                objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Amount = "";
                                            }
                                            if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                            {
                                                objSOLine.Cost = Convert.ToString(strItemcost);
                                            }
                                            else
                                            {
                                                objSOLine.Cost = "";
                                            }
                                            if (SalesOrderLineRet.TxnLineID != null)
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = "";
                                            }

                                            if (loSalesOrder.CustomerRef.FullName != null)
                                            {
                                                objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                                                //Get Customer custom field
                                                if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                {
                                                    lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer);
                                                }
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrdrCustomer = "";
                                            }

                                            if (lcustomercustomfield.Count > 0)
                                            {

                                                if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                {

                                                    if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
                                                    {
                                                        //get Left and right part of the ":" in string
                                                        lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                        lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");

                                                        roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                        if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                        {

                                                            objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                        }
                                                        else
                                                        {
                                                            objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                        }
                                                    }


                                                }
                                            }
                                            //objSOLine.ToPick = 0;
                                            alSalesOrdersLine.Add(objSOLine); //add child for group item

                                        }
                                    }
                                }

                                else if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {
                                    objSOLine = new clsSalesOrderLine();
                                    //Do not show item when quantity does not exist or zero: Date 01/07/2015
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue() != 0 && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                    {
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

                                        }

                                        OtherChargeQueryRq.OwnerIDList.Add("0");
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                        OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                        IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                        IItemOtherChargeRetList loList1 = (IItemOtherChargeRetList)loResponse2.Detail;


                                        if (loList1 == null)
                                        {

                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                            if (loSalesOrder.PONumber != null)
                                            {
                                                objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.PONumber = "";
                                            }

                                            //To show shipping method
                                            if (loSalesOrder.ShipMethodRef != null)
                                            {
                                                objSOLine.SalesOrderShipMethod = Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue());

                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderShipMethod = "";
                                            }
                                            if (loSalesOrder.CustomerRef.FullName != null)
                                            {
                                                objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());

                                                if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                {
                                                    lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer);
                                                }
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrdrCustomer = "";
                                            }

                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                            {
                                                objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineUnitOfMeasure = "";
                                            }
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                //Show MPN:16-Mar-2020
                                                objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                //Added on 29-11-2017
                                                objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

                                                //Get Item Sales price

                                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null)
                                                {
                                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                                    {
                                                        objSOLine.SalesPrice = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.SalesPrice = null;
                                                }

                                                if (lcustomercustomfield.Count > 0)
                                                {

                                                    if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                    {

                                                        if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
                                                        {

                                                            lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                            lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");

                                                            roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                            if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                            {

                                                                objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                            }
                                                            else
                                                            {
                                                                objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                            }
                                                        }


                                                    }
                                                }

                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineItemRefFullName = "";
                                                objSOLine.SalesORderItemName = "";
                                            }
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                            {
                                                objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineDesc = "";
                                            }
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null) //16-Mar-2020
                                            {
                                                objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.Amount = "";
                                            }
                                            if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                            {
                                                objSOLine.Cost = Convert.ToString(strItemcost);
                                            }
                                            else
                                            {
                                                objSOLine.Cost = "";
                                            }

                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                            {
                                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                {
                                                    objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Class = "";
                                                }
                                            }

                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                            }
                                            else
                                            {
                                                objSOLine.SalesOrderLineTxnLineID = "";
                                            }

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);

                                                    switch ((string)DataExtRet.DataExtName.GetValue().ToUpper().Trim())
                                                    {

                                                        case "OTHER1":
                                                            objSOLine.CustomerPOLineNo = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        case "CUSTNO":
                                                            objSOLine.CustNo = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        case "OTHER2":
                                                            objSOLine.SOOther2 = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        default:
                                                            break;


                                                    }
                                                }
                                            }

                                            alSalesOrdersLine.Add(objSOLine);
                                        }

                                    }
                                }


                            }
                        }
                    }
                }

                return alSalesOrdersLine;
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


        public ArrayList GetCustomFieldSOLine(string strRefNumber,string strSalesOrderTxnLineID, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions)
        {
                 ArrayList alSalesOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

                QBSessionManager lQBSessionManager = null;

                IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
                IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
                try
                {
                if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                    IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                    lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                    ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                    SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                    SalesOrderQuery.IncludeLineItems.SetValue(true);

                    SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);

                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                    if ((lMsgResponse.ResponseList.Count > 0))
                    {
                        //we have one response for  single add request

                        IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                        ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                        ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                        ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                        //------------------------- DataExtensionFields -----------------------------
                        string strTxnLineID = string.Empty;
                        string strdName = string.Empty;
                        string strdValue = string.Empty;
                        string strOwnerID = string.Empty;
                        string strItemcost = string.Empty;

                        if (loList != null)
                        {

                            IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                            IItemQuery lobjIItemQuery = null;
                            IResponse lobjIResponse;
                            ENObjectType lobjResponseDetailType;
                            IORItemRetList lobjIORItemRetList;
                            ENResponseType lobjResponseType;

                            IORItemRet lobjIORItemRet;
                            IMsgSetResponse lobjIMsgSetResponse;

                            IDataExtRetList lobjIDataExtRetList;

                            for (int Index = 0; Index < loList.Count; Index++)
                            {
                                loSalesOrder = loList.GetAt(Index);

                                for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                                {

                                    clsSalesOrderLine objSOLine;


                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                    {

                                        strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                        if (strTxnLineID == strSalesOrderTxnLineID)
                                        {
                                            objSOLine = new clsSalesOrderLine();


                                            //----------------------- News logic end to Get custom fields from sales order---------------
                                            //custom field show for sales order added by khushal:date 01/24/13
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()));

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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //custom field code end//

                                            //Below code added from H-H ver : Date 06/25/2015

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);



                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                    //Get value of DataExtType
                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (strdName != strQtypercontainerfield.ToUpper())
                                                    {
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


                                            alSalesOrdersLine.Add(objSOLine);

                                        }
                                    }
                                }
                            }
                        }
                    }
                    pobjItemExtensions = lobjItemExtensions;
                    return alSalesOrdersLine;

                }


                pobjItemExtensions = lobjItemExtensions;
                return alSalesOrdersLine;
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

        //public ArrayList GetSOLine(string strRefNumber, string strMarkupPriceField)
        //{

        //    ArrayList alSalesOrdersLine = new ArrayList();

        //    Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
        //    Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
        //    decimal roundofresult;
        //    string lstrCustomerCustomFieldColonLeftpart = string.Empty;
        //    string lstrCustomerCustomFieldColonRightpart = string.Empty;

        //    // QBSessionManager lQBSessionManager = default(QBSessionManager);
        //    QBSessionManager lQBSessionManager = null;
        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

        //    try
        //    {
        //        //IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
        //        // lQBSessionManager = new QBSessionManagerClass();
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
        //        IItemQuery lobjIItemQuery = null;
        //        IResponse lobjIResponse;
        //        ENObjectType lobjResponseDetailType;
        //        IORItemRetList lobjIORItemRetList;
        //        ENResponseType lobjResponseType;

        //        IORItemRet lobjIORItemRet;
        //        IMsgSetResponse lobjIMsgSetResponse;
        //        IDataExtRetList lobjIDataExtRetList;

        //        ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

        //        SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
        //        IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
        //        SalesOrderQuery.IncludeLineItems.SetValue(true);
        //        //SalesOrderQuery.IncludeLinkedTxns.SetValue(true);
        //        SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

        //        if ((lMsgResponse.ResponseList.Count > 0))
        //        {
        //            //we have one response for  single add request
        //            IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
        //            ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
        //            ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
        //            ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);
        //            string strExtFieldName = string.Empty;
        //            string strExtFieldValue = string.Empty;
        //            string strdName = string.Empty;
        //            string strdValue = string.Empty;
        //            string strItemcost = string.Empty;


        //            if (loList != null)
        //            {
        //                for (int Index = 0; Index < loList.Count; Index++)
        //                {
        //                    loSalesOrder = loList.GetAt(Index);

        //                    for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
        //                    {
        //                        //  clsSalesOrderLine objSOLine = new clsSalesOrderLine();
        //                        clsSalesOrderLine objSOLine;

        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
        //                        {
        //                            objSOLine = new clsSalesOrderLine();
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName != null)
        //                            {
        //                                objSOLine.SalesOrderLineItemRefFullName = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.ItemGroupRef.FullName.GetValue();
        //                                objSOLine.GroupItemType = "P";
        //                            }
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity != null)
        //                            {
        //                                objSOLine.SalesOrderLineQuantity = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Quantity.GetValue();

        //                            }
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc != null)
        //                            {
        //                                objSOLine.SalesOrderLineDesc = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.Desc.GetValue();

        //                            }
        //                            //9-Dec-2018.Add new condition for group item print
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID != null)
        //                            {
        //                                objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.TxnLineID.GetValue());
        //                            }
        //                            else
        //                            {
        //                                objSOLine.SalesOrderLineTxnLineID = "";
        //                            }
        //                            // objSOLine.ToPick = 0;
        //                            alSalesOrdersLine.Add(objSOLine); //Group parent Item add
        //                            //Get child items for Group Item:Date 26-Feb-2020
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
        //                            {

        //                                for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
        //                                {
        //                                    objSOLine = new clsSalesOrderLine();
        //                                    ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
        //                                    //Get Custom field for group line item.Date 9-Dec-2018
        //                                    //if (SalesOrderLineRet.DataExtRetList != null)
        //                                    //{
        //                                    //    for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
        //                                    //    {
        //                                    //        IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

        //                                    //        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
        //                                    //        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
        //                                    //        if (!lobjItemExtensions.ContainsKey(strdName))
        //                                    //            lobjItemExtensions.Add(strdName, strdValue);

        //                                    //    }
        //                                    //}
        //                                    //else // get Custom field from item defination.
        //                                    //{

        //                                    //}
        //                                    if (SalesOrderLineRet.ItemRef.FullName != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                                        objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
        //                                    }
        //                                    if (SalesOrderLineRet.Desc != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
        //                                    }
        //                                    if (SalesOrderLineRet.Quantity != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

        //                                    }
        //                                    if (SalesOrderLineRet.ORRate != null)
        //                                    {
        //                                        if (SalesOrderLineRet.ORRate.Rate != null)
        //                                        {
        //                                            objSOLine.SalesPrice = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesPrice = null;
        //                                    }
        //                                    if (SalesOrderLineRet.Other1 != null) //16-Mar-2020
        //                                    {
        //                                        objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Other1L = "";
        //                                    }
        //                                    if (SalesOrderLineRet.Other2 != null)
        //                                    {
        //                                        objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Other2L = "";
        //                                    }
        //                                    if (SalesOrderLineRet.ClassRef != null)
        //                                    {
        //                                        if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
        //                                        {
        //                                            objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Class = "";
        //                                        }
        //                                    }
        //                                    if (SalesOrderLineRet.Amount != null) //16-Mar-2020
        //                                    {
        //                                        objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Amount = "";
        //                                    }
        //                                    if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
        //                                    {
        //                                        objSOLine.Cost = Convert.ToString(strItemcost);
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Cost = "";
        //                                    }
        //                                    if (SalesOrderLineRet.TxnLineID != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderLineTxnLineID = "";
        //                                    }

        //                                    if (loSalesOrder.CustomerRef.FullName != null)
        //                                    {
        //                                        objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
        //                                        //Get Customer custom field
        //                                        if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
        //                                        {
        //                                            lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer);
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrdrCustomer = "";
        //                                    }

        //                                    if (lcustomercustomfield.Count > 0)
        //                                    {
        //                                        //Get Dictionary value by key SalesOrderLineRateDiscounted
        //                                        // if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED"))
        //                                        if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
        //                                        {
        //                                            //Get Item Sales price
        //                                            // objSOLine.SalesPrice = GetItemSalesPrice(objSOLine.SalesORderItemName);
        //                                            if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
        //                                            {
        //                                                //get Left and right part of the ":" in string
        //                                                lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
        //                                                lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
        //                                                // Multiply sales price by custom field left part(:) value and round off value
        //                                                // roundofresult = Math.Round(Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
        //                                                //Remove Round off from calculation :Date 22-Mar-2018
        //                                                roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
        //                                                if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
        //                                                {

        //                                                    objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
        //                                                }
        //                                                else
        //                                                {
        //                                                    objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
        //                                                }
        //                                            }


        //                                        }
        //                                    }
        //                                    //objSOLine.ToPick = 0;
        //                                    alSalesOrdersLine.Add(objSOLine); //add child for group item

        //                                }
        //                            }



        //                            //IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

        //                            //if (lobjIDataExtRetList1.SalesOrderLineGroupRet.DataExtRetList != null)
        //                            //{
        //                            //    for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineGroupRet.DataExtRetList.Count; k++)
        //                            //    {
        //                            //    }
        //                            //}

        //                            ///   alSalesOrdersLine.Add(objSOLine); //#
        //                            //throw new Exception("Order Containing Group Type of Items are not Supported");
        //                        }

        //                        //if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
        //                        //{
        //                        //    objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
        //                        //}
        //                        //else
        //                        //{
        //                        //    objSOLine.SalesOrderLineQuantity = 0.00;
        //                        //}
        //                        else if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
        //                        {
        //                            objSOLine = new clsSalesOrderLine();
        //                            //To not show item when quantity does not exist or zeoro: Date 01/07/2015
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue() != 0 && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                            {
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                                {
        //                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                                    //objSOLine.ToPick = GetToPickQty(objSOLine.SalesOrderLineItemRefFullName);
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineItemRefFullName = "";
        //                                }
        //                                OtherChargeQueryRq.OwnerIDList.Add("0");
        //                                OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
        //                                OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
        //                                OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSOLine.SalesOrderLineItemRefFullName);
        //                                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
        //                                IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
        //                                IItemOtherChargeRetList loList1 = (IItemOtherChargeRetList)loResponse2.Detail;


        //                                if (loList1 == null)
        //                                {

        //                                    objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
        //                                    //To print customer part number
        //                                    // objSOLine.MfrpartNumber= GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()));
        //                                    //To show PONumber
        //                                    if (loSalesOrder.PONumber != null)
        //                                    {
        //                                        objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.PONumber = "";
        //                                    }

        //                                    //To show shipping method
        //                                    if (loSalesOrder.ShipMethodRef != null)
        //                                    {
        //                                        objSOLine.SalesOrderShipMethod = Convert.ToString(loSalesOrder.ShipMethodRef.FullName.GetValue());

        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderShipMethod = "";
        //                                    }
        //                                    if (loSalesOrder.CustomerRef.FullName != null)
        //                                    {
        //                                        objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
        //                                        //Get Customer custom field
        //                                        //if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED") == false)
        //                                        if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
        //                                        {
        //                                            lcustomercustomfield = GetSalesOrderCustomerCustomField(objSOLine.SalesOrdrCustomer);
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrdrCustomer = "";
        //                                    }

        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderLineUnitOfMeasure = "";
        //                                    }
        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                                        //Show MPN:16-Mar-2020
        //                                        objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
        //                                        //Added on 29-11-2017
        //                                        objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

        //                                        //Get Item Sales price
        //                                        //objSOLine.SalesPrice = GetItemSalesPrice(objSOLine.SalesORderItemName);
        //                                        //get sales price from sales line items : Date 22-Feb-2018
        //                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null)
        //                                        {
        //                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
        //                                            {
        //                                                objSOLine.SalesPrice = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.SalesPrice = null;
        //                                        }

        //                                        if (lcustomercustomfield.Count > 0)
        //                                        {
        //                                            //Get Dictionary value by key SalesOrderLineRateDiscounted
        //                                            // if (lcustomercustomfield.ContainsKey("SALESORDERLINERATEDISCOUNTED"))
        //                                            if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
        //                                            {
        //                                                //Get Item Sales price
        //                                                // objSOLine.SalesPrice = GetItemSalesPrice(objSOLine.SalesORderItemName);
        //                                                if (!string.IsNullOrWhiteSpace(objSOLine.SalesPrice))
        //                                                {
        //                                                    //get Left and right part of the ":" in string
        //                                                    lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
        //                                                    lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
        //                                                    // Multiply sales price by custom field left part(:) value and round off value
        //                                                    // roundofresult = Math.Round(Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
        //                                                    //Remove Round off from calculation :Date 22-Mar-2018
        //                                                    roundofresult = Convert.ToDecimal(objSOLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
        //                                                    if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
        //                                                    {
        //                                                        //objSOLine.MarkUpPrice = Convert.ToString(roundofresult) + "." + lstrCustomerCustomFieldColonRightpart;
        //                                                        objSOLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        objSOLine.MarkUpPrice = Convert.ToString(roundofresult);
        //                                                    }
        //                                                }


        //                                            }
        //                                        }

        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderLineItemRefFullName = "";
        //                                        objSOLine.SalesORderItemName = "";
        //                                    }
        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderLineDesc = "";
        //                                    }
        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null) //16-Mar-2020
        //                                    {
        //                                        objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Amount = "";
        //                                    }
        //                                    if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
        //                                    {
        //                                        objSOLine.Cost = Convert.ToString(strItemcost);
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.Cost = "";
        //                                    }

        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
        //                                    {
        //                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
        //                                        {
        //                                            objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Class = "";
        //                                        }
        //                                    }

        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
        //                                    {
        //                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesOrderLineTxnLineID = "";
        //                                    }



        //                                    // alSalesOrdersLine.Add(objSOLine);

        //                                    //To show packaging option for sales order Date:04/30/2015

        //                                    //custom field show for sales order: Date 10-APR-2019
        //                                    //lobjIItemQuery = default(IItemQuery);
        //                                    //lMsgRequest.ClearRequests();

        //                                    //lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
        //                                    //lobjIItemQuery = lMsgRequest.AppendItemQueryRq();
        //                                    //lobjIItemQuery.OwnerIDList.Add("0");
        //                                    //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
        //                                    //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);

        //                                    //lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgRequest);
        //                                    //if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
        //                                    //{
        //                                    //    lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
        //                                    //    if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
        //                                    //    {
        //                                    //        if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
        //                                    //        {
        //                                    //            lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
        //                                    //            lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
        //                                    //            if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
        //                                    //            {
        //                                    //                lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
        //                                    //                for (int i = 0; i < lobjIORItemRetList.Count; i++)
        //                                    //                {
        //                                    //                    lobjIORItemRet = lobjIORItemRetList.GetAt(i);
        //                                    //                    if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
        //                                    //                    {
        //                                    //                        lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
        //                                    //                        if (lobjIDataExtRetList != null)
        //                                    //                        {
        //                                    //                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                    //                            {
        //                                    //                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
        //                                    //                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                    //                                if (!lobjItemExtensions.ContainsKey(strdName))
        //                                    //                                {
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                                else
        //                                    //                                {
        //                                    //                                    //update key/value
        //                                    //                                    lobjItemExtensions.Remove(strdName);
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                            }
        //                                    //                        }
        //                                    //                    }
        //                                    //                    else if (lobjIORItemRet.ItemInventoryRet != null)
        //                                    //                    {
        //                                    //                        lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
        //                                    //                        if (lobjIDataExtRetList != null)
        //                                    //                        {
        //                                    //                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                    //                            {
        //                                    //                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
        //                                    //                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                    //                                if (!lobjItemExtensions.ContainsKey(strdName))
        //                                    //                                {
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                                else
        //                                    //                                {
        //                                    //                                    //update key/value
        //                                    //                                    lobjItemExtensions.Remove(strdName);
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                            }
        //                                    //                        }
        //                                    //                    }
        //                                    //                    else if (lobjIORItemRet.ItemNonInventoryRet != null)
        //                                    //                    {
        //                                    //                        lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
        //                                    //                        if (lobjIDataExtRetList != null)
        //                                    //                        {
        //                                    //                            for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                    //                            {
        //                                    //                                strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
        //                                    //                                strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                    //                                if (!lobjItemExtensions.ContainsKey(strdName))
        //                                    //                                {
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                                else
        //                                    //                                {
        //                                    //                                    //update key/value
        //                                    //                                    lobjItemExtensions.Remove(strdName);
        //                                    //                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                    //                                }
        //                                    //                            }
        //                                    //                        }
        //                                    //                    }
        //                                    //                }
        //                                    //            }
        //                                    //        }
        //                                    //    }
        //                                    //} //end so custom field logic


        //                                    IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

        //                                    if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
        //                                    {
        //                                        for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
        //                                        {
        //                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);
        //                                            ////Get value of OwnerID
        //                                            //if (DataExtRet.OwnerID != null)
        //                                            //{
        //                                            //    string OwnerID115 = (string)DataExtRet.OwnerID.GetValue();
        //                                            //}
        //                                            //Get value of DataExtName
        //                                            switch ((string)DataExtRet.DataExtName.GetValue().ToUpper().Trim())
        //                                            {

        //                                                case "OTHER1":
        //                                                    objSOLine.CustomerPOLineNo = (string)DataExtRet.DataExtValue.GetValue();
        //                                                    break;
        //                                                case "CUSTNO":
        //                                                    objSOLine.CustNo = (string)DataExtRet.DataExtValue.GetValue();
        //                                                    break;
        //                                                case "OTHER2":
        //                                                    objSOLine.SOOther2 = (string)DataExtRet.DataExtValue.GetValue();
        //                                                    break;
        //                                                // case "UNITS/CASE": //added for div CR:Date 05-2016
        //                                                //   objSOLine.UnitsPerCase = Convert.ToDouble(DataExtRet.DataExtValue.GetValue());
        //                                                //   break;
        //                                                default:
        //                                                    break;


        //                                            }
        //                                            //strdName = (string)DataExtRet.DataExtName.GetValue();
        //                                            ////Get value of DataExtType
        //                                            //ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
        //                                            ////Get value of DataExtValue
        //                                            //strdValue = (string)DataExtRet.DataExtValue.GetValue();
        //                                            //if (!lobjItemExtensions.ContainsKey(strdName))
        //                                            //lobjItemExtensions.Add(strdName, strdValue);
        //                                        }
        //                                    }

        //                                    alSalesOrdersLine.Add(objSOLine);

        //                                    //if (lobjIDataExtRetList1 != null)
        //                                    //{
        //                                    //    for (int k = 0; k < lobjIDataExtRetList1.Count; k++)
        //                                    //    {
        //                                    //        strdName = Convert.ToString(lobjIDataExtRetList1.GetAt(k).DataExtName.GetValue()).Replace(" ", string.Empty);
        //                                    //        strdValue = Convert.ToString(lobjIDataExtRetList1.GetAt(k).DataExtValue.GetValue());
        //                                    //        if (!lobjItemExtensions.ContainsKey(strdName))
        //                                    //            lobjItemExtensions.Add(strdName, strdValue);

        //                                    //    }
        //                                    //}

        //                                }

        //                            }
        //                        }


        //                    }
        //                }
        //            }
        //        }
        //        //pobjItemExtensions = lobjItemExtensions;
        //        return alSalesOrdersLine;
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


        //Get custom items and other so item details for so packaging mode
        public ArrayList GetSOPackagingLine(string strRefNumber, out List<Itemcustomfields> pobjItemExtensions)
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


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();
                SalesOrderQuery.IncludeLineItems.SetValue(true);
                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRet loSalesOrderLineRetItem = null;
                    ISalesOrderLineGroupRet loInvoiceLineGroupRet = null;
                    clsSalesOrderLine lobjclsSalesOrderLine = null;

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
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {
                                    loSalesOrderLineRetItem = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet;
                                    lobjclsSalesOrderLine = GetInvItem(loSalesOrderLineRetItem);

                                    OtherChargeQueryRq.OwnerIDList.Add("0");
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName);
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName);
                                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                    IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                    IItemOtherChargeRetList loList1 = (IItemOtherChargeRetList)loResponse2.Detail;


                                    if (loList1 == null)
                                    {

                                        //Below condition to not show item if it is empty
                                        if (lobjclsSalesOrderLine.SalesOrderLineItemRefFullName != string.Empty && lobjclsSalesOrderLine.SalesOrderLineQuantity != 0)
                                        {
                                            lobjclsSalesOrderLine.RefNumber = strRefNumber;
                                            if (loSalesOrder.PONumber != null)
                                            {
                                                lobjclsSalesOrderLine.PONumber = loSalesOrder.PONumber.GetValue();
                                            }
                                            if (loSalesOrder.ShipMethodRef != null)
                                            {
                                                lobjclsSalesOrderLine.SalesOrderShipMethod = loSalesOrder.ShipMethodRef.FullName.GetValue();
                                            }
                                            alInvoicesLine.Add(lobjclsSalesOrderLine);

                                            //----------------------------------------- Custom Field Logic ------------------------------------
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");


                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsSalesOrderLine.SalesORderItemName);
                                            //Set field value for ToName
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsSalesOrderLine.SalesORderItemName);


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
                                                                            
                                                                            foreach (var item in list)
                                                                            {
                                                                                if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                                                {
                                                                                    blnfieldexist = true;
                                                                                    break;
                                                                                }

                                                                            }
                                                                            if (blnfieldexist == false)
                                                                            {
                                                                                list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
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
                                                                           
                                                                            foreach (var item in list)
                                                                            {
                                                                                if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                                                {
                                                                                    blnfieldexist = true;
                                                                                    break;
                                                                                }

                                                                            }
                                                                            if (blnfieldexist == false)
                                                                            {
                                                                                list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
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

                                            //Get custom item field from so line

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);

                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    foreach (var item in list)
                                                    {
                                                        if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                        {
                                                            blnfieldexist = true;
                                                            break;
                                                        }

                                                    }
                                                    if (blnfieldexist == false)
                                                    {
                                                        list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
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
        public string GetFMGPartNumber(string pstrItemRefFullName, ref string pstrcost)
        {
            string lstrGetPartNumber = string.Empty;
            string lstrItemcost = string.Empty;
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

                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemRefFullName);
                //Set field value for ToName
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemRefFullName);

                //for Non-Inventory Item
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemRefFullName);
                //Set field value for ToName
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemRefFullName);


               // lQBSessionManager.OpenConnection("", "Label Connector");
               // lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
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
                 //   lQBSessionManager.EndSession();
                 //  lQBSessionManager.CloseConnection();
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

                                            loProduct = loList.GetAt(Index);
                                            if (loProduct.ManufacturerPartNumber != null)
                                                lstrGetPartNumber = Convert.ToString(loProduct.ManufacturerPartNumber.GetValue());//Get mfg part number

                                            if (loProduct.PurchaseCost != null)
                                                lstrItemcost = Convert.ToString(loProduct.PurchaseCost.GetValue());
                                        }
                                    }


                                }
                                else if (responseType == ENResponseType.rtItemNonInventoryQueryRs) //Add support for Non-Inventory Item MPN : Date 21-Mar-2018
                                {
                                    IItemNonInventoryRetList ItemNonInventoryloList = (IItemNonInventoryRetList)loResponse.Detail;
                                    IItemNonInventoryRet ItemNonInventoryProduct = default(IItemNonInventoryRet);
                                    if (ItemNonInventoryloList != null)
                                    {
                                        for (int Index = 0; Index < ItemNonInventoryloList.Count; Index++)
                                        {

                                            ItemNonInventoryProduct = ItemNonInventoryloList.GetAt(Index);
                                            if (ItemNonInventoryProduct.ManufacturerPartNumber != null)
                                                lstrGetPartNumber = Convert.ToString(ItemNonInventoryProduct.ManufacturerPartNumber.GetValue()); //Get MPN

                                            if (ItemNonInventoryProduct.ORSalesPurchase != null)
                                            {
                                                if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase != null)
                                                {

                                                    if (ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost != null)
                                                        lstrItemcost = Convert.ToString(ItemNonInventoryProduct.ORSalesPurchase.SalesAndPurchase.PurchaseCost.GetValue());
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }
                    }



                }
                pstrcost = lstrItemcost;
                return lstrGetPartNumber;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }



        }

        //Get sales order date range item custom fieldvalues:14-jan-2020
        public ArrayList GetSODateRangeCustomFields(string strRefNumber, out List<Itemcustomfields> pobjItemExtensions)
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


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();
                SalesOrderQuery.IncludeLineItems.SetValue(true);
                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRet loSalesOrderLineRetItem = null;
                    //ISalesOrderLineGroupRet loInvoiceLineGroupRet = null;
                    clsSalesOrderLine lobjclsSalesOrderLine = null;

                    // IItemGroupQuery lobjIItemGroupQuery = null;

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
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {
                                    loSalesOrderLineRetItem = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet;
                                    lobjclsSalesOrderLine = GetInvItem(loSalesOrderLineRetItem);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsSalesOrderLine.SalesOrderLineItemRefFullName != string.Empty && lobjclsSalesOrderLine.SalesOrderLineQuantity != 0)
                                    {
                                        lobjclsSalesOrderLine.RefNumber = strRefNumber;
                                        if (loSalesOrder.PONumber != null)
                                        {
                                            lobjclsSalesOrderLine.PONumber = loSalesOrder.PONumber.GetValue();
                                        }
                                        if (loSalesOrder.ShipMethodRef != null)
                                        {
                                            lobjclsSalesOrderLine.SalesOrderShipMethod = loSalesOrder.ShipMethodRef.FullName.GetValue();
                                        }
                                        alInvoicesLine.Add(lobjclsSalesOrderLine);

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");


                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsSalesOrderLine.SalesORderItemName);
                                        //Set field value for ToName
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsSalesOrderLine.SalesORderItemName);


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
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Trim().Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        //if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //  lobjItemExtensions.Add(strdName, strdValue);

                                                                        //list.Add(new Itemcustomfields("", lobjclsInvoiceLine.InvoiceLineItemRefFullName, strdName, strdValue));
                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }
                                                                            else
                                                                            {
                                                                                blnfieldexist = false;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
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
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Trim().Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                        // if (!lobjItemExtensions.ContainsKey(strdName))
                                                                        //  lobjItemExtensions.Add(strdName, strdValue);
                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }
                                                                            else
                                                                            {
                                                                                blnfieldexist = false;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
                                                                        }


                                                                    }
                                                                }



                                                            }
                                                            else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                            {

                                                                lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                                if (lobjIDataExtRetList != null)
                                                                {
                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                    {
                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Trim().Replace(" ", string.Empty);
                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());

                                                                        foreach (var item in list)
                                                                        {
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }
                                                                            else
                                                                            {
                                                                                blnfieldexist = false;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
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

                                        //Get custom item field from so line

                                        IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                        if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                        {
                                            for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                            {
                                                IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);

                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Trim().Replace(" ", string.Empty);
                                                //Get value of DataExtValue
                                                strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                foreach (var item in list)
                                                {
                                                    if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesOrderLine.SalesOrderLineItemRefFullName.ToLower()))
                                                    {
                                                        blnfieldexist = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        blnfieldexist = false;
                                                    }

                                                }
                                                if (blnfieldexist == false)
                                                {
                                                    list.Add(new Itemcustomfields("", lobjclsSalesOrderLine.SalesOrderLineItemRefFullName, strdName, strdValue));
                                                }

                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    //loInvoiceLineGroupRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet;
                                    //lobjclsSalesOrderLine = new clsSalesOrderLine();
                                    //lobjclsSalesOrderLine = GetInvGroupItem(loInvoiceLineGroupRet);
                                    ////Below condition to not show item if it is empty
                                    //if (lobjclsSalesOrderLine.SalesOrderLineItemRefFullName != string.Empty && lobjclsSalesOrderLine.SalesOrderLineQuantity != 0)
                                    //{
                                    //    lobjclsSalesOrderLine.RefNumber = strRefNumber;
                                    //    alInvoicesLine.Add(lobjclsSalesOrderLine);
                                    //}
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
        //sales order multilple for close mode
        public ArrayList GetSOLine(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, out Dictionary<string, string> pobjItemExtensions, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alSalesOrdersLine = new ArrayList();
            //Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //step2: create QBFC session manager and prepare the request

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                //                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                //SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    if (loList != null)
                    {
                        IMsgSetRequest lMsgItemsRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;
                        ////lobjIItemQuery = default(IItemQuery);
                        IDataExtRetList lobjIDataExtRetList;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                                clsSalesOrderLine objSOLine = new clsSalesOrderLine();

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                                strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                if (strTxnLineID == strSalesOrderTxnLineID)
                                {
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
                                    {
                                        objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
                                       // objSOLine.SOQty = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineQuantity = 0.00;
                                        //objSOLine.SOQty = 0.00; //merge from H-H ver
                                    }

                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                    {
                                        objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineUnitOfMeasure = "";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineItemRefFullName = "";
                                    }
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                    {
                                        objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineDesc = "";
                                    }

                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.SalesOrderLineTxnLineID = "";
                                    }
                                    //new column PONumber printed:Date:01/24/13

                                    if (loSalesOrder.PONumber != null)
                                    {

                                        objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                    }
                                    else
                                    {
                                        objSOLine.PONumber = "";
                                    }



                                    objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                    objSOLine.CustomerCompanyName = strCompanyName;
                                    objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                    objSOLine.TxnDate = dtTransactionDate.ToShortDateString();
                                    alSalesOrdersLine.Add(objSOLine);
                                    ////----------------------- NewsStyleUriParser logic to Get custom fields from sales order---------------
                                    //lobjIDataExtRetList = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.DataExtRetList;
                                    //if (lobjIDataExtRetList != null)
                                    //{
                                    //    for (int k = 0; k < lobjIDataExtRetList.Count; k++)
                                    //    {
                                    //        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(k).DataExtName.GetValue()).Replace(" ", string.Empty);
                                    //        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(k).DataExtValue.GetValue());
                                    //        if (!lobjItemExtensions.ContainsKey(strdName))
                                    //            lobjItemExtensions.Add(strdName, strdValue);

                                    //    }
                                    //}
                                    ////----------------------- News logic end to Get custom fields from sales order---------------
                                    //custom field show for sales order added by khushal:date 01/24/13

                                    //-----------Added by srinivas on 22-Dec-2014
                                    lobjIItemQuery = default(IItemQuery);
                                    lMsgItemsRequest.ClearRequests();

                                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                    lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                    lobjIItemQuery.OwnerIDList.Add("0");
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);
                                    lobjIMsgSetResponse = pobjQBSessionManager.DoRequests(lMsgItemsRequest);
                                    //lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);
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

                                    //--------------End 22-Dec-2014


                                    //custom field code end//


                                    //Below code added from H-H ver : Date 06/25/2015

                                    IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                    if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                    {
                                        for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                        {
                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);


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
                                    alSalesOrdersLine.Add(objSOLine);

                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesOrdersLine;
            }
            catch (Exception Ex)
            {
                throw;
                //pobjItemExtensions = null; 
                return null;
            }
            finally
            {

            }
        }

        //Get customer custom field for sales order customer :Date 08-Jan-2018
        public Dictionary<string, string> GetSalesOrderCustomerCustomField(string pstrItemName,bool connection=true)
        {

            // ArrayList alProduct = new ArrayList();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            // clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = ModGlobal.QBGlobalSessionManager; 
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                ICustomerQuery CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

                CustomerQueryRq.OwnerIDList.Add("0");

                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);
                if(connection)
                {
                     lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }
               
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {
                if (connection)
                {
                    if ((lQBSessionManager != null))
                    {
                        lQBSessionManager.EndSession();
                        lQBSessionManager.CloseConnection();
                    }
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

                                if (responseType == ENResponseType.rtCustomerQueryRs)
                                {
                                    ICustomerRetList loList = (ICustomerRetList)loResponse.Detail;

                                    ICustomerRet loCustomer = default(ICustomerRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            // lobjItemdetails = new clsItemDetails();
                                            loCustomer = loList.GetAt(Index);

                                            // if (loCustomer.FullName != null)
                                            //   lobjItemdetails.FullName = Convert.ToString(loCustomer.FullName.GetValue()); //Get Parent : child


                                            //Get Custom Fields for Inventory Item
                                            if (loCustomer.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loCustomer.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loCustomer.DataExtRetList.GetAt(invItem);

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

        //public decimal GetToPickQty(string pstrItemName)
        //{
        //    QBSessionManager lQBSessionManager = null;
        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //        IItemInventoryAssemblyQuery AssemblyItemInventoryQueryRq = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
        //        AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
        //        AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

        //        IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
        //        ItemInventoryQueryRq.OwnerIDList.Add("0");
        //        ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);


        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
        //    }

        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if ((lQBSessionManager != null))
        //        {
        //            lQBSessionManager.EndSession();
        //            lQBSessionManager.CloseConnection();
        //        }
        //    }
        //    if ((lMsgResponse.ResponseList.Count > 0))
        //    {

        //        IResponseList responseList = lMsgResponse.ResponseList;
        //        if (responseList == null)
        //        {

        //            return 0;
        //        }
        //        for (int i = 0; i < responseList.Count; i++)
        //        {
        //            IResponse loResponse = responseList.GetAt(i);
        //            //check the status code of the response, 0=ok, >0 is warning
        //            if (loResponse.StatusCode >= 0)
        //            {
        //                //the request-specific response is in the details, make sure we have some
        //                if (loResponse.Detail != null)
        //                {
        //                    //make sure the response is the type we're expecting
        //                    ENResponseType responseType = (ENResponseType)loResponse.Type.GetValue();

        //                    string itemname = "";
        //                    decimal quantityonsalesorder=0;
        //                    decimal quantityonhand=0;
        //                    if (responseType == ENResponseType.rtItemInventoryQueryRs)
        //                    {
        //                        IItemInventoryRetList loList = (IItemInventoryRetList)loResponse.Detail;

        //                        IItemInventoryRet loProduct = default(IItemInventoryRet);

        //                        if (loList != null)
        //                        {
        //                            for (int Index = 0; Index < loList.Count; Index++)
        //                            {
        //                                loProduct = loList.GetAt(Index);
        //                                if (loProduct.FullName != null)
        //                                {
        //                                     itemname = Convert.ToString(loProduct.Name.GetValue());
        //                                    if (pstrItemName == itemname)
        //                                    {
        //                                        if (loProduct.QuantityOnSalesOrder != null)
        //                                        {
        //                                             quantityonsalesorder = Convert.ToDecimal(loProduct.QuantityOnSalesOrder.GetValue());
        //                                        }
                                                 
        //                                        if (loProduct.QuantityOnHand != null)
        //                                        {
        //                                             quantityonhand = Convert.ToDecimal(loProduct.QuantityOnHand.GetValue());
        //                                        }

        //                                        if (quantityonhand<0)
        //                                        {
        //                                            return 0;
        //                                        }
        //                                        else if (quantityonhand < quantityonsalesorder)
        //                                        {
        //                                            return quantityonhand;
        //                                        } else
        //                                        {
        //                                            return quantityonsalesorder;
        //                                        }
        //                                    }
        //                                }
                                        

        //                            }
        //                        }
        //                    }
        //                    else if (responseType == ENResponseType.rtItemInventoryAssemblyQueryRs)
        //                    {
        //                        IItemInventoryAssemblyRetList AssemblyloList = (IItemInventoryAssemblyRetList)loResponse.Detail;

        //                        IItemInventoryAssemblyRet AssemblyloProduct = default(IItemInventoryAssemblyRet);

        //                        if (AssemblyloList != null)
        //                        {
        //                            for (int Index = 0; Index < AssemblyloList.Count; Index++)
        //                            {
        //                                AssemblyloProduct = AssemblyloList.GetAt(Index);
                                     
        //                                if (AssemblyloProduct.FullName != null)
        //                                {
        //                                    itemname = Convert.ToString(AssemblyloProduct.Name.GetValue());
        //                                    if (pstrItemName == itemname)
        //                                    {
        //                                        if (AssemblyloProduct.QuantityOnSalesOrder != null)
        //                                        {
        //                                            quantityonsalesorder = Convert.ToDecimal(AssemblyloProduct.QuantityOnSalesOrder.GetValue());
        //                                        }

        //                                        if (AssemblyloProduct.QuantityOnHand != null)
        //                                        {
        //                                            quantityonhand = Convert.ToDecimal(AssemblyloProduct.QuantityOnHand.GetValue());
        //                                        }
        //                                        if (quantityonhand < 0)
        //                                        {
        //                                            return 0;
        //                                        }
        //                                        else if(quantityonhand < quantityonsalesorder)
        //                                        {
        //                                            return quantityonhand;
        //                                        }
        //                                        else
        //                                        {
        //                                            return quantityonsalesorder;
        //                                        }
        //                                    }
        //                                }                                        
                                          
        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    return 0;

        //}

        //Get Item Sales price for sales order item :Date 08-Jan-2018
        public string GetItemSalesPrice(string pstrItemName)
        {

            string lstrItemSalesprice = string.Empty;
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


                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
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

                                            loProduct = loList.GetAt(Index);

                                            if (loProduct.FullName != null)
                                                lstrItemSalesprice = Convert.ToString(loProduct.SalesPrice.GetValue());

                                        }
                                    }


                                }


                            }
                        }
                    }


                }

                return lstrItemSalesprice;
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }
        //sales order printing for open mode

        public ArrayList GetPrintSOLine(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions,ArrayList SalesOrderFields)
        {
            ArrayList alSalesOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    string strItemcost = string.Empty;

                    if (loList != null)
                    {

                        IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;

                        IDataExtRetList lobjIDataExtRetList;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {

                                clsSalesOrderLine objSOLine;

                               

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {


                                    //Get Group Item child record
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {

                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
                                            strTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            if (strTxnLineID == strSalesOrderTxnLineID)
                                            {
                                                objSOLine = new clsSalesOrderLine();
                                                //Get Custom field for group line item.Date 9-Dec-2018
                                                if (SalesOrderLineRet.DataExtRetList != null)
                                                {
                                                    for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
                                                    {
                                                        IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

                                                        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                                        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);

                                                    }
                                                }

                                                if (SalesOrderLineRet.ItemRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    //To print MPN from Items screen
                                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                }
                                                if (SalesOrderLineRet.Desc != null)
                                                {
                                                    objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                                }
                                                if (SalesOrderLineRet.Quantity != null)
                                                {
                                                    objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                                }
                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    objSOLine.QtyOnLabel = string.Empty;
                                                }
                                                //Add Rate(cost)column support :Date 01-09-2017
                                                if (SalesOrderLineRet.ORRate != null && SalesOrderLineRet.ORRate.Rate != null)
                                                {

                                                    objSOLine.SalesOrderLineRate = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineRate = "0";
                                                }

                                                if (loSalesOrder.FOB != null)
                                                {

                                                    objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.FOB = "";
                                                }
                                                if (SalesOrderLineRet.InventorySiteLocationRef != null)
                                                {
                                                    objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                }
                                                else
                                                {
                                                    objSOLine.Bin = "";
                                                }
                                                if (SalesOrderLineRet.ORSerialLotNumber != null)
                                                {
                                                    if (SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objSOLine.LotNumber = Convert.ToString(SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.LotNumber = string.Empty;
                                                }

                                                if (SalesOrderLineRet.Other1 != null)
                                                {
                                                    objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other1L = "";
                                                }
                                                if (SalesOrderLineRet.Other2 != null)
                                                {
                                                    objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other2L = "";
                                                }
                                                if (SalesOrderLineRet.ClassRef != null)
                                                {
                                                    if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSOLine.Class = "";
                                                    }
                                                }
                                                if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Amount = "";
                                                }

                                                if (SalesOrderLineRet.UnitOfMeasure != null)
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(SalesOrderLineRet.UnitOfMeasure.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = "";
                                                }

                                                if (loSalesOrder.DueDate != null)
                                                {
                                                    objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue());
                                                }
                                                //9-Dec-2018
                                                if (loSalesOrder.PONumber != null)
                                                {
                                                    objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());

                                                }
                                                if (loSalesOrder.CustomerRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrdrCustomer = "";
                                                }
                                                if (loSalesOrder.SalesRepRef != null)
                                                {
                                                    if (loSalesOrder.SalesRepRef.FullName != null)
                                                    {
                                                        objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                                    }
                                                    else
                                                    {
                                                        objSOLine.SalesRepRef = string.Empty;
                                                    }

                                                }
                                                if (loSalesOrder.Other != null)
                                                {
                                                    objSOLine.Other = loSalesOrder.Other.GetValue();
                                                }
                                                else
                                                {
                                                    objSOLine.Other = string.Empty;
                                                }

                                                if (loSalesOrder.ShipDate != null)
                                                {
                                                    objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                                }
                                                else
                                                {
                                                    objSOLine.ShipDate = string.Empty;
                                                }

                                                //17-Mar-2020

                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSOLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSOLine.Cost = "";
                                                }


                                                if (loSalesOrder.ShipAddress != null)
                                                {
                                                    if (loSalesOrder.ShipAddress.Addr1 != null)
                                                        objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr2 != null)
                                                        objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr3 != null)
                                                        objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Addr4 != null)
                                                        objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                                    if (loSalesOrder.ShipAddress.Addr5 != null)
                                                        objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                                    if (loSalesOrder.ShipAddress.City != null)
                                                        objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                                    if (loSalesOrder.ShipAddress.State != null)
                                                        objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                                    if (loSalesOrder.ShipAddress.PostalCode != null)
                                                        objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                                    if (loSalesOrder.ShipAddress.Country != null)
                                                        objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                                    //support of Note Field:Date 30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Note != null)
                                                        objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                                    {
                                                        objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                                    }


                                                }
                                                //Add BillAddress Block:21-Nov-2019

                                                if (loSalesOrder.BillAddress != null)
                                                {
                                                    if (loSalesOrder.BillAddress.Addr1 != null)
                                                        objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                                    if (loSalesOrder.BillAddress.Addr2 != null)
                                                        objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                                }

                                                //9-Dec-2018
                                                objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                if (loSalesOrder.ClassRef != null) //from child
                                                {
                                                    if (loSalesOrder.ClassRef.FullName != null)
                                                    {
                                                        objSOLine.Class = Convert.ToString(loSalesOrder.ClassRef.FullName.GetValue());
                                                    }

                                                }

                                                alSalesOrdersLine.Add(objSOLine);
                                            } // end Txn id compare
                                        } //end for child item
                                    }

                                }
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {
                                   

                                        
                                   
                                    strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    if (strTxnLineID == strSalesOrderTxnLineID)
                                    {
                                        objSOLine = new clsSalesOrderLine();

                                        foreach (var objSOtemplatefields in SalesOrderFields)
                                        {




                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null && objSOtemplatefields.ToString() == "SalesOrderLineQuantity")
                                        {
                                         
                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                        }
                                      
                                        //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null && objSOtemplatefields.ToString() == "Other1L")
                                        {
                                            objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                        }
                                       
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null && objSOtemplatefields.ToString() == "Other2L")
                                        {
                                            objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                        }
                                       
                                        if (!string.IsNullOrWhiteSpace(strItemcost) && objSOtemplatefields.ToString() == "Cost") //17-Mar-2020
                                        {
                                            objSOLine.Cost = Convert.ToString(strItemcost);
                                        }
                                      

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null && objSOtemplatefields.ToString() == "Amount")
                                        {
                                            objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                        }
                                      


                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null && objSOtemplatefields.ToString() == "SalesOrderLineUnitOfMeasure")
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null && objSOtemplatefields.ToString() == "SalesOrderLineItemRefFullName")
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                            //To print MPN from Items screen

                                                if(objSOtemplatefields.ToString() == "MPN")
                                            objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                        }
                                        
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null && objSOtemplatefields.ToString() == "SalesOrderLineDesc")
                                        {
                                            objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                        }
                                        

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null && objSOtemplatefields.ToString() == "SalesOrderLineTxnLineID")
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());

                                        }
                                     
                                        //Add Rate(cost)column support :Date 01-09-2017
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null && objSOtemplatefields.ToString() == "SalesOrderLineRate")
                                        {

                                            objSOLine.SalesOrderLineRate = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                        }
                                       

                                        //new column PONumber printed:Date:01/24/13

                                        if (loSalesOrder.PONumber != null && objSOtemplatefields.ToString() == "PONumber")
                                        {

                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                        }
                                       

                                        //FOB support for so Date 18-jan-2017
                                        if (loSalesOrder.FOB != null && objSOtemplatefields.ToString() == "FOB")
                                        {

                                            objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                        }
                                       

                                        //Get DueDate on 21-Feb-2017
                                        if (loSalesOrder.DueDate != null && objSOtemplatefields.ToString() == "DueDate")
                                        {

                                            objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue().ToShortDateString());
                                        }


                                        // add qty on label on multimode so printing : Date 26-08-2016
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel) && objSOtemplatefields.ToString() == "QtyOnLabel")
                                        {
                                            objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                       
                                        //***Start*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef != null && objSOtemplatefields.ToString() == "Bin")
                                        {
                                            objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                        }
                                       
                                        //***End*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        //Lot Number for sales order :Date 24-Apr-2018

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber != null )
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber != null && objSOtemplatefields.ToString() == "LotNumber")
                                            {
                                                objSOLine.LotNumber = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                            }
                                        }
                                       

                                        if(objSOtemplatefields.ToString() == "CustomerRefFullName")
                                        objSOLine.CustomerRefFullName = strCustomerRefFullName;

                                            if (objSOtemplatefields.ToString() == "CustomerCompanyName")
                                                objSOLine.CustomerCompanyName = strCompanyName;

                                            if (objSOtemplatefields.ToString() == "RefNumber")
                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());

                                            if (objSOtemplatefields.ToString() == "TxnDate")
                                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                        //Add SalesOrderCustomer & BillAddress1:Date 21-Nov-2019

                                        if (loSalesOrder.CustomerRef.FullName != null && objSOtemplatefields.ToString() == "SalesOrdrCustomer")
                                        {


                                            objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                        }
                                       

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null )
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null && objSOtemplatefields.ToString() == "Class")
                                            {
                                                objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                            }


                                        }

                                        //support for SalesRepRef in so header :Date 01-Jun-2018
                                        if (loSalesOrder.SalesRepRef != null )
                                        {
                                            if (loSalesOrder.SalesRepRef.FullName != null && objSOtemplatefields.ToString() == "SalesRepRef")
                                            {
                                                objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                            }
                                        }

                                        //other field added for so
                                        if (loSalesOrder.Other != null && objSOtemplatefields.ToString() == "Other")
                                        {
                                            objSOLine.Other = loSalesOrder.Other.GetValue();
                                        }
                                       
                                        //SHIPdATE field added for so ON 24-jULY-2017
                                        if (loSalesOrder.ShipDate != null && objSOtemplatefields.ToString() == "ShipDate")
                                        {
                                            objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                        }
                                       

                                        //To show ShipAddressBlock for unit case per quantity modification

                                        if (loSalesOrder.ShipAddress != null )
                                        {
                                            if (loSalesOrder.ShipAddress.Addr1 != null && objSOtemplatefields.ToString() == "ShipAddressAddr1")
                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr2 != null && objSOtemplatefields.ToString() == "ShipAddressAddr2")
                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr3 != null && objSOtemplatefields.ToString() == "ShipAddressAddr3")
                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Addr4 != null && objSOtemplatefields.ToString() == "ShipAddressAddr4")
                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                            if (loSalesOrder.ShipAddress.Addr5 != null && objSOtemplatefields.ToString() == "ShipAddressAddr5")
                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                            if (loSalesOrder.ShipAddress.City != null && objSOtemplatefields.ToString() == "ShipAddressCity")
                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                            if (loSalesOrder.ShipAddress.State != null && objSOtemplatefields.ToString() == "ShipAddressState")
                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                            if (loSalesOrder.ShipAddress.PostalCode != null && objSOtemplatefields.ToString() == "ShipAddressPostalCode")
                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                            if (loSalesOrder.ShipAddress.Country != null && objSOtemplatefields.ToString() == "ShipAddressCountry")
                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                            //support of Note Field:Date 30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Note != null && objSOtemplatefields.ToString() == "Note")
                                                objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                            {
                                                objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                            }


                                        }
                                        //Add BillAddress Block:21-Nov-2019

                                        if (loSalesOrder.BillAddress != null)
                                        {
                                            if (loSalesOrder.BillAddress.Addr1 != null && objSOtemplatefields.ToString() == "BillAddressAddr1")
                                                objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                            if (loSalesOrder.BillAddress.Addr2 != null && objSOtemplatefields.ToString() == "BillAddressAddr2")
                                                objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                        }

                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                                        {

                                            //----------------------- News logic end to Get custom fields from sales order---------------
                                            //custom field show for sales order added by khushal:date 01/24/13
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);

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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //custom field code end//

                                            //Below code added from H-H ver : Date 06/25/2015

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);



                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                    //Get value of DataExtType
                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (strdName != strQtypercontainerfield.ToUpper())
                                                    {
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

                                        }
                                        alSalesOrdersLine.Add(objSOLine);

                                    }


                                    }
                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesOrdersLine;
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


        public ArrayList GetSOLine(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions)
        { 
            ArrayList alSalesOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
         
            QBSessionManager lQBSessionManager = null;

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {
             
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
             
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    string strItemcost = string.Empty;

                    if (loList != null)
                    {
                        
                        IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;
                      
                        IDataExtRetList lobjIDataExtRetList;
                    
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {
                            
                                clsSalesOrderLine objSOLine;

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {

                                  
                                    //Get Group Item child record
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {

                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
                                            strTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            if (strTxnLineID == strSalesOrderTxnLineID)
                                            {
                                                objSOLine = new clsSalesOrderLine();
                                                //Get Custom field for group line item.Date 9-Dec-2018
                                                if (SalesOrderLineRet.DataExtRetList != null)
                                                {
                                                    for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
                                                    {
                                                        IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

                                                        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                                        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);

                                                    }
                                                }
                                               
                                                if (SalesOrderLineRet.ItemRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    //To print MPN from Items screen
                                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                }
                                                if (SalesOrderLineRet.Desc != null)
                                                {
                                                    objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                                }
                                                if (SalesOrderLineRet.Quantity != null)
                                                {
                                                    objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();
                                                   
                                                }
                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    objSOLine.QtyOnLabel = string.Empty;
                                                }
                                                //Add Rate(cost)column support :Date 01-09-2017
                                                if (SalesOrderLineRet.ORRate != null && SalesOrderLineRet.ORRate.Rate != null)
                                                {

                                                    objSOLine.SalesOrderLineRate = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineRate = "0";
                                                }

                                                if (loSalesOrder.FOB != null)
                                                {

                                                    objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.FOB = "";
                                                }
                                                if (SalesOrderLineRet.InventorySiteLocationRef != null)
                                                {
                                                    objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                }
                                                else
                                                {
                                                    objSOLine.Bin = "";
                                                }
                                                if (SalesOrderLineRet.ORSerialLotNumber != null)
                                                {
                                                    if (SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objSOLine.LotNumber = Convert.ToString(SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.LotNumber = string.Empty;
                                                }

                                                if (SalesOrderLineRet.Other1 != null)
                                                {
                                                    objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other1L = "";
                                                }
                                                if (SalesOrderLineRet.Other2 != null)
                                                {
                                                    objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other2L = "";
                                                }
                                                if (SalesOrderLineRet.ClassRef != null)
                                                {
                                                    if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSOLine.Class = "";
                                                    }
                                                }
                                                if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Amount = "";
                                                }

                                                if (SalesOrderLineRet.UnitOfMeasure != null)
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(SalesOrderLineRet.UnitOfMeasure.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = "";
                                                }

                                                if (loSalesOrder.DueDate != null)
                                                {
                                                    objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue());
                                                }
                                                //9-Dec-2018
                                                if (loSalesOrder.PONumber != null)
                                                {
                                                    objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());

                                                }
                                                if (loSalesOrder.CustomerRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrdrCustomer = "";
                                                }
                                                if (loSalesOrder.SalesRepRef != null)
                                                {
                                                    if (loSalesOrder.SalesRepRef.FullName != null)
                                                    {
                                                        objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                                    }
                                                    else
                                                    {
                                                        objSOLine.SalesRepRef = string.Empty;
                                                    }

                                                }
                                                if (loSalesOrder.Other != null)
                                                {
                                                    objSOLine.Other = loSalesOrder.Other.GetValue();
                                                }
                                                else
                                                {
                                                    objSOLine.Other = string.Empty;
                                                }

                                                if (loSalesOrder.ShipDate != null)
                                                {
                                                    objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                                }
                                                else
                                                {
                                                    objSOLine.ShipDate = string.Empty;
                                                }

                                                //17-Mar-2020

                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSOLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSOLine.Cost = "";
                                                }


                                                if (loSalesOrder.ShipAddress != null)
                                                {
                                                    if (loSalesOrder.ShipAddress.Addr1 != null)
                                                        objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr2 != null)
                                                        objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr3 != null)
                                                        objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Addr4 != null)
                                                        objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                                    if (loSalesOrder.ShipAddress.Addr5 != null)
                                                        objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                                    if (loSalesOrder.ShipAddress.City != null)
                                                        objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                                    if (loSalesOrder.ShipAddress.State != null)
                                                        objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                                    if (loSalesOrder.ShipAddress.PostalCode != null)
                                                        objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                                    if (loSalesOrder.ShipAddress.Country != null)
                                                        objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                                    //support of Note Field:Date 30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Note != null)
                                                        objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                                    {
                                                        objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                                    }


                                                }
                                                //Add BillAddress Block:21-Nov-2019

                                                if (loSalesOrder.BillAddress != null)
                                                {
                                                    if (loSalesOrder.BillAddress.Addr1 != null)
                                                        objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                                    if (loSalesOrder.BillAddress.Addr2 != null)
                                                        objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                                }

                                                //9-Dec-2018
                                                objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                if (loSalesOrder.ClassRef != null) //from child
                                                {
                                                    if (loSalesOrder.ClassRef.FullName != null)
                                                    {
                                                        objSOLine.Class = Convert.ToString(loSalesOrder.ClassRef.FullName.GetValue());
                                                    }

                                                }

                                                alSalesOrdersLine.Add(objSOLine);
                                            } // end Txn id compare
                                        } //end for child item
                                    }
                                   
                                }
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {

                                    strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    if (strTxnLineID == strSalesOrderTxnLineID)
                                    {
                                        objSOLine = new clsSalesOrderLine();
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
                                        {
                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());
                                        
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineQuantity = 0.00;
                                          
                                        }
                                        //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null)
                                        {
                                            objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other1L = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
                                        {
                                            objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other2L = "";
                                        }
                                        if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                        {
                                            objSOLine.Cost = Convert.ToString(strItemcost);
                                        }
                                        else
                                        {
                                            objSOLine.Cost = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null)
                                        {
                                            objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Amount = "";
                                        }


                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                            //To print MPN from Items screen
                                            objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = "";

                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                        {
                                            objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineDesc = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = "";
                                        }
                                        //Add Rate(cost)column support :Date 01-09-2017
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                        {

                                            objSOLine.SalesOrderLineRate = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineRate = "0";
                                        }

                                        //new column PONumber printed:Date:01/24/13

                                        if (loSalesOrder.PONumber != null)
                                        {

                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.PONumber = "";
                                        }

                                        //FOB support for so Date 18-jan-2017
                                        if (loSalesOrder.FOB != null)
                                        {

                                            objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.FOB = "";
                                        }

                                        //Get DueDate on 21-Feb-2017
                                        if (loSalesOrder.DueDate != null)
                                        {

                                            objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue().ToShortDateString());
                                        }


                                        // add qty on label on multimode so printing : Date 26-08-2016
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            objSOLine.QtyOnLabel = string.Empty;
                                        }
                                        //***Start*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef != null)
                                        {
                                            objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                        }
                                        else
                                        {
                                            objSOLine.Bin = "";
                                        }
                                        //***End*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        //Lot Number for sales order :Date 24-Apr-2018

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                            {
                                                objSOLine.LotNumber = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                            }
                                        }
                                        else
                                        {
                                            objSOLine.LotNumber = string.Empty;
                                        }


                                        objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                        objSOLine.CustomerCompanyName = strCompanyName;
                                        objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                        objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                        //Add SalesOrderCustomer & BillAddress1:Date 21-Nov-2019

                                        if (loSalesOrder.CustomerRef.FullName != null)
                                        {

                                           
                                            objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrdrCustomer = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null)
                                            {
                                                objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                            }


                                        }
                                      
                                        //support for SalesRepRef in so header :Date 01-Jun-2018
                                        if (loSalesOrder.SalesRepRef != null)
                                        {
                                            if (loSalesOrder.SalesRepRef.FullName != null)
                                            {
                                                objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                            }
                                            else
                                            {
                                                objSOLine.SalesRepRef = string.Empty;
                                            }

                                        }

                                        //other field added for so
                                        if (loSalesOrder.Other != null)
                                        {
                                            objSOLine.Other = loSalesOrder.Other.GetValue();
                                        }
                                        else
                                        {
                                            objSOLine.Other = string.Empty;
                                        }
                                        //SHIPdATE field added for so ON 24-jULY-2017
                                        if (loSalesOrder.ShipDate != null)
                                        {
                                            objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                        }
                                        else
                                        {
                                            objSOLine.ShipDate = string.Empty;
                                        }

                                        //To show ShipAddressBlock for unit case per quantity modification

                                        if (loSalesOrder.ShipAddress != null)
                                        {
                                            if (loSalesOrder.ShipAddress.Addr1 != null)
                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr2 != null)
                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr3 != null)
                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Addr4 != null)
                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                            if (loSalesOrder.ShipAddress.Addr5 != null)
                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                            if (loSalesOrder.ShipAddress.City != null)
                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                            if (loSalesOrder.ShipAddress.State != null)
                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                            if (loSalesOrder.ShipAddress.PostalCode != null)
                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                            if (loSalesOrder.ShipAddress.Country != null)
                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                            //support of Note Field:Date 30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Note != null)
                                                objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                            {
                                                objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                            }


                                        }
                                        //Add BillAddress Block:21-Nov-2019

                                        if (loSalesOrder.BillAddress != null)
                                        {
                                            if (loSalesOrder.BillAddress.Addr1 != null)
                                                objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                            if (loSalesOrder.BillAddress.Addr2 != null)
                                                objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                        }

                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                                        {

                                            //----------------------- News logic end to Get custom fields from sales order---------------
                                            //custom field show for sales order added by khushal:date 01/24/13
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);

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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //custom field code end//

                                            //Below code added from H-H ver : Date 06/25/2015

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);



                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                    //Get value of DataExtType
                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (strdName != strQtypercontainerfield.ToUpper())
                                                    {
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

                                        }
                                        alSalesOrdersLine.Add(objSOLine);

                                    }
                                }
                            }
                        }
                     
                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesOrdersLine;
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
        //public ArrayList GetSOLineAsync(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions)
        //{
        //    ArrayList alSalesOrdersLine = new ArrayList();
        //    QBConfiguration lobjQBConfiguration = new QBConfiguration();
        //    Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
        //    clsSalesOrderLine objSOLine = new clsSalesOrderLine();
        //    QBSessionManager lQBSessionManager = null;

        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
        //    IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;
        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //        ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

        //        SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

        //        SalesOrderQuery.IncludeLineItems.SetValue(true);

        //        SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);

        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
        //        SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);


        //        IItemQuery lobjIItemQuery = default(IItemQuery);
        //        lobjIItemQuery = lMsgRequest.AppendItemQueryRq();
        //        lobjIItemQuery.OwnerIDList.Add("0");
        //        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
        //        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(SalesOrderQuery.ORTxnNoAccountQuery.);



        //        lQBSessionManager.OpenConnection("", "Label Connector");
        //        lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);




        //        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

        //        if ((lMsgResponse.ResponseList.Count > 0))
        //        {
        //            //we have one response for  single add request

        //            IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

        //            ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
        //            ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
        //            ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

        //            //------------------------- DataExtensionFields -----------------------------
        //            string strTxnLineID = string.Empty;
        //            string strdName = string.Empty;
        //            string strdValue = string.Empty;
        //            string strOwnerID = string.Empty;
        //            string strItemcost = string.Empty;

        //            if (loList != null)
        //            {

        //                IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //                lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

        //                ICustomerRetList lobjICustomerRetList = null;
        //                IItemQuery lobjIItemQuery = null;
        //                IResponse lobjIResponse;
        //                ENObjectType lobjResponseDetailType;
        //                IORItemRetList lobjIORItemRetList;
        //                ENResponseType lobjResponseType;

        //                IORItemRet lobjIORItemRet;
        //                IMsgSetResponse lobjIMsgSetResponse;

        //                IDataExtRetList lobjIDataExtRetList;

        //                for (int Index = 0; Index < loList.Count; Index++)
        //                {
        //                    loSalesOrder = loList.GetAt(Index);



        //                    for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
        //                    {

        //                        // clsSalesOrderLine objSOLine;

        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
        //                        {


        //                            //Get Group Item child record
        //                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
        //                            {

        //                                for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
        //                                {

        //                                    ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
        //                                    strTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
        //                                    if (strTxnLineID == strSalesOrderTxnLineID)
        //                                    {
        //                                        objSOLine = new clsSalesOrderLine();
        //                                        //Get Custom field for group line item.Date 9-Dec-2018
        //                                        if (SalesOrderLineRet.DataExtRetList != null)
        //                                        {
        //                                            for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
        //                                            {
        //                                                IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

        //                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
        //                                                strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
        //                                                if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                    lobjItemExtensions.Add(strdName, strdValue);

        //                                            }
        //                                        }

        //                                        if (SalesOrderLineRet.ItemRef.FullName != null)
        //                                        {
        //                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                                            //To print MPN from Items screen
        //                                            objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

        //                                        }
        //                                        if (SalesOrderLineRet.Desc != null)
        //                                        {
        //                                            objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
        //                                        }
        //                                        if (SalesOrderLineRet.Quantity != null)
        //                                        {
        //                                            objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

        //                                        }
        //                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
        //                                        {
        //                                            objSOLine.QtyOnLabel = lstrQuantityonLabel;
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.QtyOnLabel = string.Empty;
        //                                        }
        //                                        //Add Rate(cost)column support :Date 01-09-2017
        //                                        if (SalesOrderLineRet.ORRate != null && SalesOrderLineRet.ORRate.Rate != null)
        //                                        {

        //                                            objSOLine.SalesOrderLineRate = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.SalesOrderLineRate = "0";
        //                                        }

        //                                        if (loSalesOrder.FOB != null)
        //                                        {

        //                                            objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.FOB = "";
        //                                        }
        //                                        if (SalesOrderLineRet.InventorySiteLocationRef != null)
        //                                        {
        //                                            objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Bin = "";
        //                                        }
        //                                        if (SalesOrderLineRet.ORSerialLotNumber != null)
        //                                        {
        //                                            if (SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
        //                                            {
        //                                                objSOLine.LotNumber = Convert.ToString(SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.LotNumber = string.Empty;
        //                                        }

        //                                        if (SalesOrderLineRet.Other1 != null)
        //                                        {
        //                                            objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Other1L = "";
        //                                        }
        //                                        if (SalesOrderLineRet.Other2 != null)
        //                                        {
        //                                            objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Other2L = "";
        //                                        }
        //                                        if (SalesOrderLineRet.ClassRef != null)
        //                                        {
        //                                            if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
        //                                            {
        //                                                objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
        //                                            }
        //                                            else
        //                                            {
        //                                                objSOLine.Class = "";
        //                                            }
        //                                        }
        //                                        if (SalesOrderLineRet.Amount != null) //16-Mar-2020
        //                                        {
        //                                            objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Amount = "";
        //                                        }

        //                                        if (SalesOrderLineRet.UnitOfMeasure != null)
        //                                        {
        //                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(SalesOrderLineRet.UnitOfMeasure.GetValue());
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.SalesOrderLineUnitOfMeasure = "";
        //                                        }

        //                                        if (loSalesOrder.DueDate != null)
        //                                        {
        //                                            objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue());
        //                                        }
        //                                        //9-Dec-2018
        //                                        if (loSalesOrder.PONumber != null)
        //                                        {
        //                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());

        //                                        }
        //                                        if (loSalesOrder.CustomerRef.FullName != null)
        //                                        {
        //                                            objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.SalesOrdrCustomer = "";
        //                                        }
        //                                        if (loSalesOrder.SalesRepRef != null)
        //                                        {
        //                                            if (loSalesOrder.SalesRepRef.FullName != null)
        //                                            {
        //                                                objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
        //                                            }
        //                                            else
        //                                            {
        //                                                objSOLine.SalesRepRef = string.Empty;
        //                                            }

        //                                        }
        //                                        if (loSalesOrder.Other != null)
        //                                        {
        //                                            objSOLine.Other = loSalesOrder.Other.GetValue();
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Other = string.Empty;
        //                                        }

        //                                        if (loSalesOrder.ShipDate != null)
        //                                        {
        //                                            objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.ShipDate = string.Empty;
        //                                        }

        //                                        //17-Mar-2020

        //                                        if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
        //                                        {
        //                                            objSOLine.Cost = Convert.ToString(strItemcost);
        //                                        }
        //                                        else
        //                                        {
        //                                            objSOLine.Cost = "";
        //                                        }


        //                                        if (loSalesOrder.ShipAddress != null)
        //                                        {
        //                                            if (loSalesOrder.ShipAddress.Addr1 != null)
        //                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

        //                                            if (loSalesOrder.ShipAddress.Addr2 != null)
        //                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

        //                                            if (loSalesOrder.ShipAddress.Addr3 != null)
        //                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
        //                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
        //                                            if (loSalesOrder.ShipAddress.Addr4 != null)
        //                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
        //                                            if (loSalesOrder.ShipAddress.Addr5 != null)
        //                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

        //                                            if (loSalesOrder.ShipAddress.City != null)
        //                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

        //                                            if (loSalesOrder.ShipAddress.State != null)
        //                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

        //                                            if (loSalesOrder.ShipAddress.PostalCode != null)
        //                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

        //                                            if (loSalesOrder.ShipAddress.Country != null)
        //                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

        //                                            //support of Note Field:Date 30-Nov-2019
        //                                            if (loSalesOrder.ShipAddress.Note != null)
        //                                                objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
        //                                            //citystatezip field added:Date 30-APR-2019
        //                                            if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
        //                                            {
        //                                                objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
        //                                            }


        //                                        }
        //                                        //Add BillAddress Block:21-Nov-2019

        //                                        if (loSalesOrder.BillAddress != null)
        //                                        {
        //                                            if (loSalesOrder.BillAddress.Addr1 != null)
        //                                                objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

        //                                            if (loSalesOrder.BillAddress.Addr2 != null)
        //                                                objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


        //                                        }

        //                                        //9-Dec-2018
        //                                        objSOLine.CustomerRefFullName = strCustomerRefFullName;
        //                                        objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
        //                                        objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

        //                                        if (loSalesOrder.ClassRef != null) //from child
        //                                        {
        //                                            if (loSalesOrder.ClassRef.FullName != null)
        //                                            {
        //                                                objSOLine.Class = Convert.ToString(loSalesOrder.ClassRef.FullName.GetValue());
        //                                            }

        //                                        }

        //                                        alSalesOrdersLine.Add(objSOLine);
        //                                    } // end Txn id compare
        //                                } //end for child item
        //                            }

        //                        }
        //                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
        //                        {

        //                            strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
        //                            if (strTxnLineID == strSalesOrderTxnLineID)
        //                            {
        //                                objSOLine = new clsSalesOrderLine();



        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
        //                                {
        //                                    objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineQuantity = 0.00;

        //                                }
        //                                //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null)
        //                                {
        //                                    objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Other1L = "";
        //                                }
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
        //                                {
        //                                    objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Other2L = "";
        //                                }
        //                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
        //                                {
        //                                    objSOLine.Cost = Convert.ToString(strItemcost);
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Cost = "";
        //                                }

        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null)
        //                                {
        //                                    objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Amount = "";
        //                                }


        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
        //                                {
        //                                    objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineUnitOfMeasure = "";
        //                                }
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
        //                                {
        //                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
        //                                    //To print MPN from Items screen
        //                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
        //                                    objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

        //                                    objSOLine.SubItemof = objSOLine.SalesORderItemName != null ? objSOLine.SalesORderItemName : "";
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineItemRefFullName = "";

        //                                }
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
        //                                {
        //                                    objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineDesc = "";
        //                                }

        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
        //                                {
        //                                    objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());

        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineTxnLineID = "";
        //                                }
        //                                //Add Rate(cost)column support :Date 01-09-2017
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
        //                                {

        //                                    objSOLine.SalesOrderLineRate = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrderLineRate = "0";
        //                                }

        //                                //new column PONumber printed:Date:01/24/13

        //                                if (loSalesOrder.PONumber != null)
        //                                {

        //                                    objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.PONumber = "";
        //                                }

        //                                //FOB support for so Date 18-jan-2017
        //                                if (loSalesOrder.FOB != null)
        //                                {

        //                                    objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.FOB = "";
        //                                }

        //                                //Get DueDate on 21-Feb-2017
        //                                if (loSalesOrder.DueDate != null)
        //                                {

        //                                    objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue().ToShortDateString());
        //                                }


        //                                // add qty on label on multimode so printing : Date 26-08-2016
        //                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
        //                                {
        //                                    objSOLine.QtyOnLabel = lstrQuantityonLabel;
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.QtyOnLabel = string.Empty;
        //                                }
        //                                //***Start*** Added by Srinivas on 09-Aug-2017 for getting Bin value
        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef != null)
        //                                {
        //                                    objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Bin = "";
        //                                }
        //                                //***End*** Added by Srinivas on 09-Aug-2017 for getting Bin value
        //                                //Lot Number for sales order :Date 24-Apr-2018

        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber != null)
        //                                {
        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
        //                                    {
        //                                        objSOLine.LotNumber = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.LotNumber = string.Empty;
        //                                }


        //                                objSOLine.CustomerRefFullName = strCustomerRefFullName;
        //                                objSOLine.CustomerCompanyName = strCompanyName;
        //                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
        //                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

        //                                //Add SalesOrderCustomer & BillAddress1:Date 21-Nov-2019

        //                                if (loSalesOrder.CustomerRef.FullName != null)
        //                                {


        //                                    objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.SalesOrdrCustomer = "";
        //                                }

        //                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
        //                                {
        //                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null)
        //                                    {
        //                                        objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
        //                                    }


        //                                }

        //                                //support for SalesRepRef in so header :Date 01-Jun-2018
        //                                if (loSalesOrder.SalesRepRef != null)
        //                                {
        //                                    if (loSalesOrder.SalesRepRef.FullName != null)
        //                                    {
        //                                        objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
        //                                    }
        //                                    else
        //                                    {
        //                                        objSOLine.SalesRepRef = string.Empty;
        //                                    }

        //                                }

        //                                //other field added for so
        //                                if (loSalesOrder.Other != null)
        //                                {
        //                                    objSOLine.Other = loSalesOrder.Other.GetValue();
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.Other = string.Empty;
        //                                }
        //                                //SHIPdATE field added for so ON 24-jULY-2017
        //                                if (loSalesOrder.ShipDate != null)
        //                                {
        //                                    objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
        //                                }
        //                                else
        //                                {
        //                                    objSOLine.ShipDate = string.Empty;
        //                                }

        //                                //To show ShipAddressBlock for unit case per quantity modification

        //                                if (loSalesOrder.ShipAddress != null)
        //                                {
        //                                    if (loSalesOrder.ShipAddress.Addr1 != null)
        //                                        objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

        //                                    if (loSalesOrder.ShipAddress.Addr2 != null)
        //                                        objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

        //                                    if (loSalesOrder.ShipAddress.Addr3 != null)
        //                                        objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
        //                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
        //                                    if (loSalesOrder.ShipAddress.Addr4 != null)
        //                                        objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
        //                                    if (loSalesOrder.ShipAddress.Addr5 != null)
        //                                        objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

        //                                    if (loSalesOrder.ShipAddress.City != null)
        //                                        objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

        //                                    if (loSalesOrder.ShipAddress.State != null)
        //                                        objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

        //                                    if (loSalesOrder.ShipAddress.PostalCode != null)
        //                                    {
        //                                        objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());
        //                                        objSOLine.ShipAddressAddrPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());
        //                                    }

        //                                    if (loSalesOrder.ShipAddress.Country != null)
        //                                        objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

        //                                    //support of Note Field:Date 30-Nov-2019
        //                                    if (loSalesOrder.ShipAddress.Note != null)
        //                                        objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
        //                                    //citystatezip field added:Date 30-APR-2019
        //                                    if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
        //                                    {
        //                                        objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
        //                                    }


        //                                }
        //                                //Add BillAddress Block:21-Nov-2019

        //                                if (loSalesOrder.BillAddress != null)
        //                                {
        //                                    if (loSalesOrder.BillAddress.Addr1 != null)
        //                                        objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

        //                                    if (loSalesOrder.BillAddress.Addr2 != null)
        //                                        objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


        //                                }

        //                                if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
        //                                {

        //                                    //----------------------- News logic end to Get custom fields from sales order---------------
        //                                    //custom field show for sales order added by khushal:date 01/24/13
        //                                   // lobjIItemQuery = default(IItemQuery);
        //                                   // lMsgItemsRequest.ClearRequests();

        //                                    //lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
        //                                    //lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
        //                                    //lobjIItemQuery.OwnerIDList.Add("0");
        //                                    //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
        //                                    //lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesOrderLineItemRefFullName);

        //                                   // lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgItemsRequest);
        //                                    if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
        //                                    {
        //                                        lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
        //                                        if (lobjIResponse != null && lobjIResponse.StatusCode == 0)
        //                                        {
        //                                            if (lobjIResponse.Type != null && lobjIResponse.Detail != null)
        //                                            {
        //                                                lobjResponseType = (ENResponseType)lobjIResponse.Type.GetValue();
        //                                                lobjResponseDetailType = (ENObjectType)lobjIResponse.Detail.Type.GetValue();
        //                                                if (lobjResponseType == ENResponseType.rtItemQueryRs && lobjResponseDetailType == ENObjectType.otORItemRetList)
        //                                                {
        //                                                    lobjIORItemRetList = (IORItemRetList)lobjIResponse.Detail;
        //                                                    for (int i = 0; i < lobjIORItemRetList.Count; i++)
        //                                                    {
        //                                                        lobjIORItemRet = lobjIORItemRetList.GetAt(i);
        //                                                        if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
        //                                                        {
        //                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
        //                                                            if (lobjIDataExtRetList != null)
        //                                                            {

        //                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                                {
        //                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
        //                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                                    if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                                        lobjItemExtensions.Add(strdName, strdValue);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                        else if (lobjIORItemRet.ItemInventoryRet != null)
        //                                                        {
        //                                                            lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
        //                                                            if (lobjIDataExtRetList != null)
        //                                                            {

        //                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                                {
        //                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
        //                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                                    if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                                        lobjItemExtensions.Add(strdName, strdValue);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                        //Add non inventory Item custom field from items
        //                                                        else if (lobjIORItemRet.ItemNonInventoryRet != null)
        //                                                        {
        //                                                            lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
        //                                                            if (lobjIDataExtRetList != null)
        //                                                            {

        //                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                                {
        //                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
        //                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                                    if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                                        lobjItemExtensions.Add(strdName, strdValue);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                        //Add other charge item field support added:Date 02-APR-2019
        //                                                        else if (lobjIORItemRet.ItemOtherChargeRet != null)
        //                                                        {
        //                                                            lobjIDataExtRetList = lobjIORItemRet.ItemOtherChargeRet.DataExtRetList;
        //                                                            if (lobjIDataExtRetList != null)
        //                                                            {
        //                                                                for (int j = 0; j < lobjIDataExtRetList.Count; j++)
        //                                                                {
        //                                                                    strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
        //                                                                    strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
        //                                                                    if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                                        lobjItemExtensions.Add(strdName, strdValue);
        //                                                                }
        //                                                            }

        //                                                        }
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }


        //                                    //custom field code end//

        //                                    //Below code added from H-H ver : Date 06/25/2015

        //                                    IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

        //                                    if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
        //                                    {
        //                                        for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
        //                                        {
        //                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);



        //                                            strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

        //                                            //Get value of DataExtType
        //                                            ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
        //                                            //Get value of DataExtValue
        //                                            strdValue = (string)DataExtRet.DataExtValue.GetValue();

        //                                            if (strdName != strQtypercontainerfield.ToUpper())
        //                                            {
        //                                                if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                {
        //                                                    lobjItemExtensions.Add(strdName, strdValue);
        //                                                }
        //                                                else
        //                                                {
        //                                                    //update key/value
        //                                                    lobjItemExtensions.Remove(strdName);
        //                                                    lobjItemExtensions.Add(strdName, strdValue);


        //                                                }
        //                                            }

        //                                        }
        //                                    }




        //                                    ICustomerQuery CustomerQuery = default(ICustomerQuery);
        //                                    lMsgRequest.ClearRequests();
        //                                    CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
        //                                    CustomerQuery.OwnerIDList.Add("0");
        //                                    CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSOLine.CustomerRefFullName);

        //                                    lobjIMsgSetResponse = lQBSessionManager.DoRequests(lMsgRequest);


        //                                    if (lobjIMsgSetResponse != null && lobjIMsgSetResponse.ResponseList != null && lobjIMsgSetResponse.ResponseList.Count > 0)
        //                                    {
        //                                        lobjIResponse = lobjIMsgSetResponse.ResponseList.GetAt(0);
        //                                        lobjICustomerRetList = (ICustomerRetList)lobjIResponse.Detail;
        //                                        ICustomerRet loCustomerRet = default(ICustomerRet);
        //                                        if (lobjICustomerRetList != null)
        //                                        {
        //                                            for (int Index1 = 0; Index1 < lobjICustomerRetList.Count; Index1++)
        //                                            {
        //                                                loCustomerRet = lobjICustomerRetList.GetAt(Index1);
        //                                                if (!string.IsNullOrWhiteSpace(loCustomerRet.FullName.GetValue()))
        //                                                {
        //                                                    if (loCustomerRet.DataExtRetList != null)
        //                                                    {
        //                                                        for (int i = 0; i < loCustomerRet.DataExtRetList.Count; i++)
        //                                                        {
        //                                                            IDataExtRet DataExtRet = loCustomerRet.DataExtRetList.GetAt(i);

        //                                                            strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
        //                                                            strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
        //                                                            if (!lobjItemExtensions.ContainsKey(strdName))
        //                                                                lobjItemExtensions.Add(strdName, strdValue);

        //                                                        }
        //                                                    }
        //                                                }

        //                                            }
        //                                        }
        //                                    }

        //                                }
        //                                alSalesOrdersLine.Add(objSOLine);

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        pobjItemExtensions = lobjItemExtensions;
        //        return alSalesOrdersLine;
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

       
    
        public ArrayList GetSOLineAsync(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions)
        {
            ArrayList alSalesOrdersLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            clsSalesOrderLine objSOLine = new clsSalesOrderLine();
            QBSessionManager lQBSessionManager = null;

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                {
                    ICustomerQuery CustomerQuery = default(ICustomerQuery);
                    CustomerQuery = lMsgRequest.AppendCustomerQueryRq();
                    CustomerQuery.OwnerIDList.Add("0");
                    CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(strCustomerRefFullName);
                }


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    string strItemcost = string.Empty;

                    if (loList != null)
                    {

                        IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                        ICustomerRetList lobjICustomerRetList = null;
                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;

                        IDataExtRetList lobjIDataExtRetList;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);



                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {

                                // clsSalesOrderLine objSOLine;

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {


                                    //Get Group Item child record
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {

                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
                                            strTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            if (strTxnLineID == strSalesOrderTxnLineID)
                                            {
                                                objSOLine = new clsSalesOrderLine();
                                                //Get Custom field for group line item.Date 9-Dec-2018
                                                if (SalesOrderLineRet.DataExtRetList != null)
                                                {
                                                    for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
                                                    {
                                                        IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

                                                        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                                        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);

                                                    }
                                                }

                                                if (SalesOrderLineRet.ItemRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    //To print MPN from Items screen
                                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                }
                                                if (SalesOrderLineRet.Desc != null)
                                                {
                                                    objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                                }
                                                if (SalesOrderLineRet.Quantity != null)
                                                {
                                                    objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                                }
                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    objSOLine.QtyOnLabel = string.Empty;
                                                }
                                                //Add Rate(cost)column support :Date 01-09-2017
                                                if (SalesOrderLineRet.ORRate != null && SalesOrderLineRet.ORRate.Rate != null)
                                                {

                                                    objSOLine.SalesOrderLineRate = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineRate = "0";
                                                }

                                                if (loSalesOrder.FOB != null)
                                                {

                                                    objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.FOB = "";
                                                }
                                                if (SalesOrderLineRet.InventorySiteLocationRef != null)
                                                {
                                                    objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                }
                                                else
                                                {
                                                    objSOLine.Bin = "";
                                                }
                                                if (SalesOrderLineRet.ORSerialLotNumber != null)
                                                {
                                                    if (SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objSOLine.LotNumber = Convert.ToString(SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.LotNumber = string.Empty;
                                                }

                                                if (SalesOrderLineRet.Other1 != null)
                                                {
                                                    objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other1L = "";
                                                }
                                                if (SalesOrderLineRet.Other2 != null)
                                                {
                                                    objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other2L = "";
                                                }
                                                if (SalesOrderLineRet.ClassRef != null)
                                                {
                                                    if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSOLine.Class = "";
                                                    }
                                                }
                                                if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Amount = "";
                                                }

                                                if (SalesOrderLineRet.UnitOfMeasure != null)
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(SalesOrderLineRet.UnitOfMeasure.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = "";
                                                }

                                                if (loSalesOrder.DueDate != null)
                                                {
                                                    objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue());
                                                }
                                                //9-Dec-2018
                                                if (loSalesOrder.PONumber != null)
                                                {
                                                    objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());

                                                }
                                                if (loSalesOrder.CustomerRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrdrCustomer = "";
                                                }
                                                if (loSalesOrder.SalesRepRef != null)
                                                {
                                                    if (loSalesOrder.SalesRepRef.FullName != null)
                                                    {
                                                        objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                                    }
                                                    else
                                                    {
                                                        objSOLine.SalesRepRef = string.Empty;
                                                    }

                                                }
                                                if (loSalesOrder.Other != null)
                                                {
                                                    objSOLine.Other = loSalesOrder.Other.GetValue();
                                                }
                                                else
                                                {
                                                    objSOLine.Other = string.Empty;
                                                }

                                                if (loSalesOrder.ShipDate != null)
                                                {
                                                    objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                                }
                                                else
                                                {
                                                    objSOLine.ShipDate = string.Empty;
                                                }

                                                //17-Mar-2020

                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSOLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSOLine.Cost = "";
                                                }


                                                if (loSalesOrder.ShipAddress != null)
                                                {
                                                    if (loSalesOrder.ShipAddress.Addr1 != null)
                                                        objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr2 != null)
                                                        objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr3 != null)
                                                        objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Addr4 != null)
                                                        objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                                    if (loSalesOrder.ShipAddress.Addr5 != null)
                                                        objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                                    if (loSalesOrder.ShipAddress.City != null)
                                                        objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                                    if (loSalesOrder.ShipAddress.State != null)
                                                        objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                                    if (loSalesOrder.ShipAddress.PostalCode != null)
                                                        objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                                    if (loSalesOrder.ShipAddress.Country != null)
                                                        objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                                    //support of Note Field:Date 30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Note != null)
                                                        objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                                    {
                                                        objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                                    }


                                                }
                                                //Add BillAddress Block:21-Nov-2019

                                                if (loSalesOrder.BillAddress != null)
                                                {
                                                    if (loSalesOrder.BillAddress.Addr1 != null)
                                                        objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                                    if (loSalesOrder.BillAddress.Addr2 != null)
                                                        objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                                }

                                                //9-Dec-2018
                                                objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                if (loSalesOrder.ClassRef != null) //from child
                                                {
                                                    if (loSalesOrder.ClassRef.FullName != null)
                                                    {
                                                        objSOLine.Class = Convert.ToString(loSalesOrder.ClassRef.FullName.GetValue());
                                                    }

                                                }

                                                alSalesOrdersLine.Add(objSOLine);
                                            } // end Txn id compare
                                        } //end for child item
                                    }

                                }
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {

                                    strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    if (strTxnLineID == strSalesOrderTxnLineID)
                                    {
                                        objSOLine = new clsSalesOrderLine();



                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
                                        {
                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineQuantity = 0.00;

                                        }
                                        //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null)
                                        {
                                            objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other1L = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
                                        {
                                            objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other2L = "";
                                        }
                                        if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                        {
                                            objSOLine.Cost = Convert.ToString(strItemcost);
                                        }
                                        else
                                        {
                                            objSOLine.Cost = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null)
                                        {
                                            objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Amount = "";
                                        }


                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                            //To print MPN from Items screen
                                            objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                            objSOLine.SalesORderItemName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());

                                            objSOLine.SubItemof = objSOLine.SalesORderItemName != null ? objSOLine.SalesORderItemName : "";
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = "";

                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                        {
                                            objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineDesc = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = "";
                                        }
                                        //Add Rate(cost)column support :Date 01-09-2017
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                        {

                                            objSOLine.SalesOrderLineRate = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineRate = "0";
                                        }

                                        //new column PONumber printed:Date:01/24/13

                                        if (loSalesOrder.PONumber != null)
                                        {

                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.PONumber = "";
                                        }

                                        //FOB support for so Date 18-jan-2017
                                        if (loSalesOrder.FOB != null)
                                        {

                                            objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.FOB = "";
                                        }

                                        //Get DueDate on 21-Feb-2017
                                        if (loSalesOrder.DueDate != null)
                                        {

                                            objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue().ToShortDateString());
                                        }


                                        // add qty on label on multimode so printing : Date 26-08-2016
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            objSOLine.QtyOnLabel = string.Empty;
                                        }
                                        //***Start*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef != null)
                                        {
                                            objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                        }
                                        else
                                        {
                                            objSOLine.Bin = "";
                                        }
                                        //***End*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        //Lot Number for sales order :Date 24-Apr-2018

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                            {
                                                objSOLine.LotNumber = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                            }
                                        }
                                        else
                                        {
                                            objSOLine.LotNumber = string.Empty;
                                        }


                                        objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                        objSOLine.CustomerCompanyName = strCompanyName;
                                        objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                        objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                        //Add SalesOrderCustomer & BillAddress1:Date 21-Nov-2019

                                        if (loSalesOrder.CustomerRef.FullName != null)
                                        {


                                            objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrdrCustomer = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null)
                                            {
                                                objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                            }
                                        }

                                        //support for SalesRepRef in so header :Date 01-Jun-2018
                                        if (loSalesOrder.SalesRepRef != null)
                                        {
                                            if (loSalesOrder.SalesRepRef.FullName != null)
                                            {
                                                objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                            }
                                            else
                                            {
                                                objSOLine.SalesRepRef = string.Empty;
                                            }

                                        }

                                        //other field added for so
                                        if (loSalesOrder.Other != null)
                                        {
                                            objSOLine.Other = loSalesOrder.Other.GetValue();
                                        }
                                        else
                                        {
                                            objSOLine.Other = string.Empty;
                                        }
                                        //SHIPdATE field added for so ON 24-jULY-2017
                                        if (loSalesOrder.ShipDate != null)
                                        {
                                            objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                        }
                                        else
                                        {
                                            objSOLine.ShipDate = string.Empty;
                                        }

                                        //To show ShipAddressBlock for unit case per quantity modification

                                        if (loSalesOrder.ShipAddress != null)
                                        {
                                            if (loSalesOrder.ShipAddress.Addr1 != null)
                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr2 != null)
                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr3 != null)
                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Addr4 != null)
                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                            if (loSalesOrder.ShipAddress.Addr5 != null)
                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                            if (loSalesOrder.ShipAddress.City != null)
                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                            if (loSalesOrder.ShipAddress.State != null)
                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                            if (loSalesOrder.ShipAddress.PostalCode != null)
                                            {
                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());
                                                objSOLine.ShipAddressAddrPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());
                                            }

                                            if (loSalesOrder.ShipAddress.Country != null)
                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                            //support of Note Field:Date 30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Note != null)
                                                objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                            {
                                                objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                            }


                                        }
                                        //Add BillAddress Block:21-Nov-2019

                                        if (loSalesOrder.BillAddress != null)
                                        {
                                            if (loSalesOrder.BillAddress.Addr1 != null)
                                                objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                            if (loSalesOrder.BillAddress.Addr2 != null)
                                                objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                        }

                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                                        {

                                            //----------------------- News logic end to Get custom fields from sales order---------------
                                            //custom field show for sales order added by khushal:date 01/24/13
                                            lobjIItemQuery = default(IItemQuery);
                                            lMsgItemsRequest.ClearRequests();

                                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                            lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                            lobjIItemQuery.OwnerIDList.Add("0");
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                            lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSOLine.SalesORderItemName);

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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                                            strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
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
                                                            }
                                                        }
                                                    }
                                                }
                                            }


                                            //custom field code end//

                                            //Below code added from H-H ver : Date 06/25/2015

                                            IORSalesOrderLineRet lobjIDataExtRetList1 = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesOrderLineRet.DataExtRetList.GetAt(k);



                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                    //Get value of DataExtType
                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    //Get value of DataExtValue
                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (strdName != strQtypercontainerfield.ToUpper())
                                                    {
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
                                        alSalesOrdersLine.Add(objSOLine);

                                    }
                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesOrdersLine;
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

        public string GetItemsBarCode(string pstrItemName, bool connection = false)
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
                if (connection)
                {
                    lQBSessionManager.OpenConnection("", "Label Connector");
                    lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                }
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                if (lQBSessionManager != null && connection)
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
                        if (loList.GetAt(0).ItemInventoryRet != null)
                        {
                            IItemInventoryRet ItemDate = loList.GetAt(0).ItemInventoryRet;
                            if (ItemDate.BarCodeValue != null)
                            {
                                strItembarcode = Convert.ToString(ItemDate.BarCodeValue.GetValue());
                            }
                            else
                            {
                                strItembarcode = string.Empty;
                            }
                        }
                        else if (loList.GetAt(0).ItemNonInventoryRet != null)
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
        public async Task <ArrayList> GetFieldSOLine(string lstrQuantityonLabel, string strRefNumber, string strSalesOrderTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName)
        {
            ArrayList alSalesOrdersLine = new ArrayList();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();

            QBSessionManager lQBSessionManager = null;

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);

                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.IncludeLineItems.SetValue(true);

                SalesOrderQuery.OwnerIDList.Add("0"); //to show all fields

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                    ISalesOrderLineRetList loSalesOrderLine = default(ISalesOrderLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strItemcost = string.Empty;
                    Task.Run(() => {
                    if (loList != null)
                    {
                        IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesOrder.ORSalesOrderLineRetList.Count; intLine++)
                            {

                                clsSalesOrderLine objSOLine;

                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet != null)
                                {


                                    //Get Group Item child record
                                    if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.Count; grpitem++)
                                        {

                                            ISalesOrderLineRet SalesOrderLineRet = loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineGroupRet.SalesOrderLineRetList.GetAt(grpitem);
                                            strTxnLineID = Convert.ToString(SalesOrderLineRet.TxnLineID.GetValue());
                                            if (strTxnLineID == strSalesOrderTxnLineID)
                                            {
                                                objSOLine = new clsSalesOrderLine();
                                                //Get Custom field for group line item.Date 9-Dec-2018
                                                if (SalesOrderLineRet.DataExtRetList != null)
                                                {
                                                    for (int i165 = 0; i165 < SalesOrderLineRet.DataExtRetList.Count; i165++)
                                                    {
                                                        IDataExtRet DataExtRet = SalesOrderLineRet.DataExtRetList.GetAt(i165);

                                                        strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                                        strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                        if (!lobjItemExtensions.ContainsKey(strdName))
                                                            lobjItemExtensions.Add(strdName, strdValue);

                                                    }
                                                }

                                                if (SalesOrderLineRet.ItemRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue());
                                                    //To print MPN from Items screen
                                                    objSOLine.MPN = GetFMGPartNumber(Convert.ToString(SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                }
                                                if (SalesOrderLineRet.Desc != null)
                                                {
                                                    objSOLine.SalesOrderLineDesc = Convert.ToString(SalesOrderLineRet.Desc.GetValue());
                                                }
                                                if (SalesOrderLineRet.Quantity != null)
                                                {
                                                    objSOLine.SalesOrderLineQuantity = SalesOrderLineRet.Quantity.GetValue();

                                                }
                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    objSOLine.QtyOnLabel = string.Empty;
                                                }
                                                //Add Rate(cost)column support :Date 01-09-2017
                                                if (SalesOrderLineRet.ORRate != null && SalesOrderLineRet.ORRate.Rate != null)
                                                {

                                                    objSOLine.SalesOrderLineRate = Convert.ToString(SalesOrderLineRet.ORRate.Rate.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineRate = "0";
                                                }

                                                if (loSalesOrder.FOB != null)
                                                {

                                                    objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.FOB = "";
                                                }
                                                if (SalesOrderLineRet.InventorySiteLocationRef != null)
                                                {
                                                    objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                }
                                                else
                                                {
                                                    objSOLine.Bin = "";
                                                }
                                                if (SalesOrderLineRet.ORSerialLotNumber != null)
                                                {
                                                    if (SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objSOLine.LotNumber = Convert.ToString(SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSOLine.LotNumber = string.Empty;
                                                }

                                                if (SalesOrderLineRet.Other1 != null)
                                                {
                                                    objSOLine.Other1L = Convert.ToString(SalesOrderLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other1L = "";
                                                }
                                                if (SalesOrderLineRet.Other2 != null)
                                                {
                                                    objSOLine.Other2L = Convert.ToString(SalesOrderLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Other2L = "";
                                                }
                                                if (SalesOrderLineRet.ClassRef != null)
                                                {
                                                    if (SalesOrderLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSOLine.Class = Convert.ToString(SalesOrderLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSOLine.Class = "";
                                                    }
                                                }
                                                if (SalesOrderLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSOLine.Amount = Convert.ToString(SalesOrderLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.Amount = "";
                                                }

                                                if (SalesOrderLineRet.UnitOfMeasure != null)
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(SalesOrderLineRet.UnitOfMeasure.GetValue());
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrderLineUnitOfMeasure = "";
                                                }

                                                if (loSalesOrder.DueDate != null)
                                                {
                                                    objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue());
                                                }
                                                //9-Dec-2018
                                                if (loSalesOrder.PONumber != null)
                                                {
                                                    objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());

                                                }
                                                if (loSalesOrder.CustomerRef.FullName != null)
                                                {
                                                    objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                                }
                                                else
                                                {
                                                    objSOLine.SalesOrdrCustomer = "";
                                                }
                                                if (loSalesOrder.SalesRepRef != null)
                                                {
                                                    if (loSalesOrder.SalesRepRef.FullName != null)
                                                    {
                                                        objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                                    }
                                                    else
                                                    {
                                                        objSOLine.SalesRepRef = string.Empty;
                                                    }

                                                }
                                                if (loSalesOrder.Other != null)
                                                {
                                                    objSOLine.Other = loSalesOrder.Other.GetValue();
                                                }
                                                else
                                                {
                                                    objSOLine.Other = string.Empty;
                                                }

                                                if (loSalesOrder.ShipDate != null)
                                                {
                                                    objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                                }
                                                else
                                                {
                                                    objSOLine.ShipDate = string.Empty;
                                                }

                                                //17-Mar-2020

                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSOLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSOLine.Cost = "";
                                                }


                                                if (loSalesOrder.ShipAddress != null)
                                                {
                                                    if (loSalesOrder.ShipAddress.Addr1 != null)
                                                        objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr2 != null)
                                                        objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                                    if (loSalesOrder.ShipAddress.Addr3 != null)
                                                        objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Addr4 != null)
                                                        objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                                    if (loSalesOrder.ShipAddress.Addr5 != null)
                                                        objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                                    if (loSalesOrder.ShipAddress.City != null)
                                                        objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                                    if (loSalesOrder.ShipAddress.State != null)
                                                        objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                                    if (loSalesOrder.ShipAddress.PostalCode != null)
                                                        objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                                    if (loSalesOrder.ShipAddress.Country != null)
                                                        objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                                    //support of Note Field:Date 30-Nov-2019
                                                    if (loSalesOrder.ShipAddress.Note != null)
                                                        objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                                    {
                                                        objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                                    }


                                                }
                                                //Add BillAddress Block:21-Nov-2019

                                                if (loSalesOrder.BillAddress != null)
                                                {
                                                    if (loSalesOrder.BillAddress.Addr1 != null)
                                                        objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                                    if (loSalesOrder.BillAddress.Addr2 != null)
                                                        objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                                }

                                                //9-Dec-2018
                                                objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                                objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                                objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                if (loSalesOrder.ClassRef != null) //from child
                                                {
                                                    if (loSalesOrder.ClassRef.FullName != null)
                                                    {
                                                        objSOLine.Class = Convert.ToString(loSalesOrder.ClassRef.FullName.GetValue());
                                                    }

                                                }

                                                alSalesOrdersLine.Add(objSOLine);
                                            } // end Txn id compare
                                        } //end for child item
                                    }

                                }
                                if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet != null)
                                {

                                    strTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());
                                    if (strTxnLineID == strSalesOrderTxnLineID)
                                    {
                                        objSOLine = new clsSalesOrderLine();
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity != null)
                                        {
                                            objSOLine.SalesOrderLineQuantity = Convert.ToDouble(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Quantity.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineQuantity = 0.00;

                                        }
                                        //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1 != null)
                                        {
                                            objSOLine.Other1L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other1.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other1L = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2 != null)
                                        {
                                            objSOLine.Other2L = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Other2.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Other2L = "";
                                        }
                                        if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                        {
                                            objSOLine.Cost = Convert.ToString(strItemcost);
                                        }
                                        else
                                        {
                                            objSOLine.Cost = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount != null)
                                        {
                                            objSOLine.Amount = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Amount.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.Amount = "";
                                        }


                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure != null)
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineUnitOfMeasure = "";
                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef != null)
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue());
                                            //To print MPN from Items screen
                                            objSOLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineItemRefFullName = "";

                                        }
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc != null)
                                        {
                                            objSOLine.SalesOrderLineDesc = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.Desc.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineDesc = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID != null)
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.TxnLineID.GetValue());

                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineTxnLineID = "";
                                        }
                                        //Add Rate(cost)column support :Date 01-09-2017
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate != null && loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate != null)
                                        {

                                            objSOLine.SalesOrderLineRate = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORRate.Rate.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrderLineRate = "0";
                                        }

                                        //new column PONumber printed:Date:01/24/13

                                        if (loSalesOrder.PONumber != null)
                                        {

                                            objSOLine.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.PONumber = "";
                                        }

                                        //FOB support for so Date 18-jan-2017
                                        if (loSalesOrder.FOB != null)
                                        {

                                            objSOLine.FOB = Convert.ToString(loSalesOrder.FOB.GetValue());
                                        }
                                        else
                                        {
                                            objSOLine.FOB = "";
                                        }

                                        //Get DueDate on 21-Feb-2017
                                        if (loSalesOrder.DueDate != null)
                                        {

                                            objSOLine.DueDate = Convert.ToString(loSalesOrder.DueDate.GetValue().ToShortDateString());
                                        }


                                        // add qty on label on multimode so printing : Date 26-08-2016
                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                        {
                                            objSOLine.QtyOnLabel = lstrQuantityonLabel;
                                        }
                                        else
                                        {
                                            objSOLine.QtyOnLabel = string.Empty;
                                        }
                                        //***Start*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef != null)
                                        {
                                            objSOLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                        }
                                        else
                                        {
                                            objSOLine.Bin = "";
                                        }
                                        //***End*** Added by Srinivas on 09-Aug-2017 for getting Bin value
                                        //Lot Number for sales order :Date 24-Apr-2018

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber != null)
                                            {
                                                objSOLine.LotNumber = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                            }
                                        }
                                        else
                                        {
                                            objSOLine.LotNumber = string.Empty;
                                        }


                                        objSOLine.CustomerRefFullName = strCustomerRefFullName;
                                        objSOLine.CustomerCompanyName = strCompanyName;
                                        objSOLine.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                        objSOLine.TxnDate = dtTransactionDate.ToShortDateString();

                                        //Add SalesOrderCustomer & BillAddress1:Date 21-Nov-2019

                                        if (loSalesOrder.CustomerRef.FullName != null)
                                        {


                                            objSOLine.SalesOrdrCustomer = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue()); //Get Customer only
                                        }
                                        else
                                        {
                                            objSOLine.SalesOrdrCustomer = "";
                                        }

                                        if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef != null)
                                        {
                                            if (loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName != null)
                                            {
                                                objSOLine.Class = Convert.ToString(loSalesOrder.ORSalesOrderLineRetList.GetAt(intLine).SalesOrderLineRet.ClassRef.FullName.GetValue());
                                            }


                                        }

                                        //support for SalesRepRef in so header :Date 01-Jun-2018
                                        if (loSalesOrder.SalesRepRef != null)
                                        {
                                            if (loSalesOrder.SalesRepRef.FullName != null)
                                            {
                                                objSOLine.SalesRepRef = loSalesOrder.SalesRepRef.FullName.GetValue();
                                            }
                                            else
                                            {
                                                objSOLine.SalesRepRef = string.Empty;
                                            }

                                        }

                                        //other field added for so
                                        if (loSalesOrder.Other != null)
                                        {
                                            objSOLine.Other = loSalesOrder.Other.GetValue();
                                        }
                                        else
                                        {
                                            objSOLine.Other = string.Empty;
                                        }
                                        //SHIPdATE field added for so ON 24-jULY-2017
                                        if (loSalesOrder.ShipDate != null)
                                        {
                                            objSOLine.ShipDate = loSalesOrder.ShipDate.GetValue().ToShortDateString();
                                        }
                                        else
                                        {
                                            objSOLine.ShipDate = string.Empty;
                                        }

                                        //To show ShipAddressBlock for unit case per quantity modification

                                        if (loSalesOrder.ShipAddress != null)
                                        {
                                            if (loSalesOrder.ShipAddress.Addr1 != null)
                                                objSOLine.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr2 != null)
                                                objSOLine.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                            if (loSalesOrder.ShipAddress.Addr3 != null)
                                                objSOLine.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());
                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Addr4 != null)
                                                objSOLine.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());
                                            if (loSalesOrder.ShipAddress.Addr5 != null)
                                                objSOLine.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                            if (loSalesOrder.ShipAddress.City != null)
                                                objSOLine.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                            if (loSalesOrder.ShipAddress.State != null)
                                                objSOLine.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());

                                            if (loSalesOrder.ShipAddress.PostalCode != null)
                                                objSOLine.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                            if (loSalesOrder.ShipAddress.Country != null)
                                                objSOLine.ShipAddressCountry = Convert.ToString(loSalesOrder.ShipAddress.Country.GetValue());

                                            //support of Note Field:Date 30-Nov-2019
                                            if (loSalesOrder.ShipAddress.Note != null)
                                                objSOLine.Note = Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());
                                            //citystatezip field added:Date 30-APR-2019
                                            if (!string.IsNullOrWhiteSpace(objSOLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSOLine.ShipAddressPostalCode))
                                            {
                                                objSOLine.citystatezip += objSOLine.ShipAddressCity + " " + objSOLine.ShipAddressState + " " + objSOLine.ShipAddressPostalCode;
                                            }


                                        }
                                        //Add BillAddress Block:21-Nov-2019

                                        if (loSalesOrder.BillAddress != null)
                                        {
                                            if (loSalesOrder.BillAddress.Addr1 != null)
                                                objSOLine.BillAddressAddr1 = Convert.ToString(loSalesOrder.BillAddress.Addr1.GetValue());

                                            if (loSalesOrder.BillAddress.Addr2 != null)
                                                objSOLine.BillAddressAddr2 = Convert.ToString(loSalesOrder.BillAddress.Addr2.GetValue());


                                        }

                                    
                                        alSalesOrdersLine.Add(objSOLine);

                                    }
                                }
                            }
                        }
                    }
                    });
                }
             
                return alSalesOrdersLine;
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
