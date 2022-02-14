using Interop.QBFC13;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConnector
{
    class clsSalesReceiptLineItems
    {
        double _dblSalesReceiptLineQuantity;
        //double _dblPreInvoiced;//new added
        //double _dblToInvoiced; //new added
        //double _dblItmePrice; //new added
        string _strPONumber;
        string _strShipMethod;
        double _dblItemAmount;
        string _strBarcodeValue;
        string _strSalesReceiptCustomer;
        string _strSalesReceiptLineUnitOfMeasure;
        string _strSalesReceiptLineItemRefFullName;
        string _strSalesReceiptLineDesc;
        string _strSalesReceiptLineType;
        string _strSalesReceiptLineTxnLineID;
        string _strRefNumber;
        string _dtTxnDate;
        string _strCustomerRefFullName;
        string _strCustomerPOLineNo;
        string _strCustPartNo;
        string _CustNo;
        double _dblSRQty;
        string _strCompanyName;
        string _strShipAddressAddr1;
        string _strShipAddressAddr2;
        string _strShipAddressAddr3;
        string _strShipAddressAddr4;
        string _strShipAddressAddr5;
        string _strShipAddressCity;
        string _strShipAddressState;
        string _strShipAddressPostalCode;
        string _strShipAddressCountry;
        double _unitpercase;
        string _Entry1;
        string _Entry2;
        string _SRQty;
        string _strFOB;
        string _strCheckNumber;
        string _strMemo;
        string _srother;
        string _dtDueDate;
        string _strsalesReceiptitemname;
        string _strSalesReceiptLineRate;
        string _srShipDate;
        string _strSalesReceiptBin; // Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO
        string _strSROther2; // Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        string _strOther2L;
        string _strSalesPrice;
        string _strPhone;
        string _strMarkUpPrice;
        string _strManufacturerPartNumber;
        string _strLotNumber;
        string _strSalesRepRef;
        string _strOther1T;
        string _strOther1L;
        string _strNote;
        string _strcitystatezip = string.Empty;
        double _SRQty1;
        string _strclass;
        string _strBillAddressAddr1;
        string _strBillAddressAddr2;
        string _strAmount;
        string _strCost;
        // ***Start*** Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO 
        public string Bin
        {
            get { return _strSalesReceiptBin; }
            set { _strSalesReceiptBin = value; }
        }
        // ***End*** Added by Srinivas on 09-Aug-2017 for Printing Bin value in SO 

        public string LotNumber
        {
            get { return _strLotNumber; }
            set { _strLotNumber = value; }
        }

        public string QtyOnLabel
        {
            get { return _SRQty; }
            set { _SRQty = value; }
        }
        public double Qty1
        {
            get { return _SRQty1; }
            set { _SRQty1 = value; }
        }

        public string Other
        {
            get { return _srother; }
            set { _srother = value; }
        }

        public string SalesRepRef
        {
            get { return _strSalesRepRef; }
            set { _strSalesRepRef = value; }
        }

        public string Phone
        {
            get
            {
                return _strPhone;
            }
            set
            {
                _strPhone = value;
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
            get { return _srShipDate; }
            set { _srShipDate = value; }
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
        public string BarcodeValue
        {
            get
            {
                return _strBarcodeValue;
            }
            set
            {
                _strBarcodeValue = value;
            }
        }
        public string GroupItemType
        {
            get; set;
        }
        public double SalesReceiptQty
        {
            get
            {
                return _dblSalesReceiptLineQuantity;
            }
            set
            {
                _dblSalesReceiptLineQuantity = value;
            }
        }
        public double SRQty
        {
            get
            {
                return _dblSRQty;
            }
            set
            {
                _dblSRQty = value;
            }
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


        public string SalesReceiptShipMethod
        {
            get { return _strShipMethod; }
            set { _strShipMethod = value; }
        }

        public string SalesReceiptCustomer
        {
            get { return _strSalesReceiptCustomer; }
            set { _strSalesReceiptCustomer = value; }

        }

        public string CustomerPOLineNo
        {
            get { return _strCustomerPOLineNo; }
            set { _strCustomerPOLineNo = value; }
        }
        //***Start***Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        public string SROther2
        {
            get { return _strSROther2; }
            set { _strSROther2 = value; }
        }
        //***End***Added by Srinivas on 16-Jan-2018 for Printing Other2 value in SO
        public string CustPartNo
        {
            get { return _strCustPartNo; }
            set { _strCustPartNo = value; }
        }

        public string SalesReceiptLineUnitOfMeasure
        {
            get
            {
                return _strSalesReceiptLineUnitOfMeasure;
            }

            set
            {
                _strSalesReceiptLineUnitOfMeasure = value == null ? "" : value;
            }
        }
        public string SalesReceiptLineItemRefFullName
        {
            get
            {
                return _strSalesReceiptLineItemRefFullName;
            }
            set
            {
                //_strSalesReceiptLineItemRefFullName = value;
                _strSalesReceiptLineItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
            }
        }

        public string SalesReceiptItemName
        {
            get { return _strsalesReceiptitemname; }
            set { _strsalesReceiptitemname = value; }
        }
        public string SalesReceiptLineDesc
        {
            get
            {
                return _strSalesReceiptLineDesc;
            }
            set
            {
                _strSalesReceiptLineDesc = value;
            }
        }
        public string SalesReceiptLineType
        {
            get
            {
                return _strSalesReceiptLineType;
            }
            set
            {
                _strSalesReceiptLineType = value;
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

        public string SalesReceiptLineTxnLineID
        {
            get
            {
                return _strSalesReceiptLineTxnLineID;
            }
            set
            {
                _strSalesReceiptLineTxnLineID = value;
            }
        }

        public string SalesReceiptLineRate
        {
            get { return _strSalesReceiptLineRate; }
            set { _strSalesReceiptLineRate = value; }
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
        public string CheckNumber
        {
            get
            {
                return _strCheckNumber;
            }
            set
            {
                _strCheckNumber = value;
            }
        }
        public string Memo
        {
            get
            {
                return _strMemo;
            }
            set
            {
                _strMemo = value;
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
        public ArrayList GetFilterSalesReceiptForPrint(string strstartdate, string strenddate, out List<Dictionary<string, string>> pobjItemExtensions, string strMarkupPriceField)
        {
            ArrayList alSalesReceiptLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //step2: create QBFC session manager and prepare the request
            //QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            List<Dictionary<string, string>> objcustvalue = new List<Dictionary<string, string>>();
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            string strItemcost = string.Empty;
            Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
            decimal roundofresult;
            string lstrCustomerCustomFieldColonLeftpart = string.Empty;
            string lstrCustomerCustomFieldColonRightpart = string.Empty;
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();
                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();

                SalesReceiptQuery.IncludeLineItems.SetValue(true);

                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields

                // SalesReceiptQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(strstartdate));
                //Set field value for ToTxnDate
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(strenddate));


                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRetList loSalesReceiptLine = default(ISalesReceiptLineRetList);

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
                            loSalesReceipt = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();
                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                {
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = "";
                                    }
                                }
                                if (objSRLine.SalesReceiptLineItemRefFullName == "")
                                {
                                    continue;
                                }

                                IItemOtherChargeRetList loList1 = null;
                                if ((lobjQBConfiguration.GetLabelConfigSettings("SREnableotherchargesfields").ToString() == "0"))
                                {
                                    OtherChargeQueryRq.OwnerIDList.Add("0");
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSRLine.SalesReceiptLineItemRefFullName);
                                    OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSRLine.SalesReceiptLineItemRefFullName);
                                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                    IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                    loList1 = (IItemOtherChargeRetList)loResponse2.Detail;
                                }
                                if (loList1 == null)
                                {
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet != null)
                                    {
                                        objSRLine = new clsSalesReceiptLineItems();
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.ItemGroupRef.FullName != null)
                                        {
                                            objSRLine.SalesReceiptLineItemRefFullName = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.ItemGroupRef.FullName.GetValue();
                                            objSRLine.GroupItemType = "P";
                                        }
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Quantity != null)
                                        {
                                            objSRLine.SalesReceiptQty = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Quantity.GetValue();

                                        }
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Desc != null)
                                        {
                                            objSRLine.SalesReceiptLineDesc = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Desc.GetValue();

                                        }
                                        //9-Dec-2018.Add new condition for group item print
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.TxnLineID != null)
                                        {
                                            objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.TxnLineID.GetValue());
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineTxnLineID = "";
                                        }
                                         objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                        if (!string.IsNullOrWhiteSpace(objSRLine.RefNumber))
                                        {
                                            alSalesReceiptLine.Add(objSRLine); //Group parent Item add
                                        }
                                        objSRLine = new clsSalesReceiptLineItems();               //Get child items for Group Item:Date 26-Feb-2020
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList != null)
                                        {

                                            for (int grpitem = 0; grpitem < loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.Count; grpitem++)
                                            {
                                                objSRLine = new clsSalesReceiptLineItems();
                                                ISalesReceiptLineRet SalesReceiptLineRet = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.GetAt(grpitem);
                                                if (SalesReceiptLineRet.Quantity != null && Convert.ToInt64(SalesReceiptLineRet.Quantity.GetValue()) != 0)
                                                {

                                                    if (SalesReceiptLineRet.ItemRef.FullName != null)
                                                    {
                                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                                        objSRLine.MPN = GetFMGPartNumber(Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                    }
                                                    if (SalesReceiptLineRet.Desc != null)
                                                    {
                                                        objSRLine.SalesReceiptLineDesc = Convert.ToString(SalesReceiptLineRet.Desc.GetValue());
                                                    }
                                                    if (SalesReceiptLineRet.Quantity != null)
                                                    {
                                                        objSRLine.SalesReceiptQty = SalesReceiptLineRet.Quantity.GetValue();

                                                    }
                                                    if (SalesReceiptLineRet.ORRate != null)
                                                    {
                                                        if (SalesReceiptLineRet.ORRate.Rate != null)
                                                        {
                                                            objSRLine.SalesPrice = Convert.ToString(SalesReceiptLineRet.ORRate.Rate.GetValue());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        objSRLine.SalesPrice = null;
                                                    }
                                                    if (SalesReceiptLineRet.Other1 != null) //16-Mar-2020
                                                    {
                                                        objSRLine.Other1L = Convert.ToString(SalesReceiptLineRet.Other1.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Other1L = "";
                                                    }
                                                    if (SalesReceiptLineRet.Other2 != null)
                                                    {
                                                        objSRLine.Other2L = Convert.ToString(SalesReceiptLineRet.Other2.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Other2L = "";
                                                    }
                                                    if (SalesReceiptLineRet.ClassRef != null)
                                                    {
                                                        if (SalesReceiptLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                        {
                                                            objSRLine.Class = Convert.ToString(SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                        }
                                                        else
                                                        {
                                                            objSRLine.Class = "";
                                                        }
                                                    }
                                                    if (SalesReceiptLineRet.Amount != null) //16-Mar-2020
                                                    {
                                                        objSRLine.Amount = Convert.ToString(SalesReceiptLineRet.Amount.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Amount = "";
                                                    }
                                                    if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                    {
                                                        objSRLine.Cost = Convert.ToString(strItemcost);
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Cost = "";
                                                    }
                                                    if (SalesReceiptLineRet.TxnLineID != null)
                                                    {
                                                        objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(SalesReceiptLineRet.TxnLineID.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.SalesReceiptLineTxnLineID = "";
                                                    }
                                                    objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                                    if (loSalesReceipt.CustomerRef != null)
                                                    {
                                                        if (loSalesReceipt.CustomerRef.FullName != null)
                                                        {
                                                            objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                                                            //Get Customer custom field
                                                            if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                            {
                                                                lcustomercustomfield = GetSalesRecepitCustomerCustomField(objSRLine.SalesReceiptCustomer);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            objSRLine.SalesReceiptCustomer = "";
                                                        }
                                                    }
                                                    if (lcustomercustomfield.Count > 0)
                                                    {
                                                        //Get Dictionary value by key SalesReceiptLineRateDiscounted
                                                        // if (lcustomercustomfield.ContainsKey("SalesReceiptLINERATEDISCOUNTED"))
                                                        if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                        {
                                                            //Get Item Sales price
                                                            // objSRLine.SalesPrice = GetItemSalesPrice(objSRLine.SalesReceiptItemName);
                                                            if (!string.IsNullOrWhiteSpace(objSRLine.SalesPrice))
                                                            {
                                                                //get Left and right part of the ":" in string
                                                                lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                                lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                                // Multiply sales price by custom field left part(:) value and round off value
                                                                // roundofresult = Math.Round(Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
                                                                //Remove Round off from calculation :Date 22-Mar-2018
                                                                roundofresult = Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                                if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                                {

                                                                    objSRLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                                }
                                                                else
                                                                {
                                                                    objSRLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                                }
                                                            }


                                                        }
                                                    }



                                                    if (!string.IsNullOrWhiteSpace(objSRLine.RefNumber))
                                                    {
                                                        alSalesReceiptLine.Add(objSRLine); //add child for group item
                                                    }
                                                    objSRLine = new clsSalesReceiptLineItems();
                                                }
                                            }
                                        }

                                    }


                                    else if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                    {

                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity != null)
                                        {
                                            objSRLine.SalesReceiptQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());

                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptQty = 0.00;

                                        }

                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure != null)
                                        {
                                            objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                        }
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                        {
                                            objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineItemRefFullName = "";
                                        }
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc != null)
                                        {
                                            objSRLine.SalesReceiptLineDesc = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc.GetValue());
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineDesc = "";
                                        }

                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID != null)
                                        {
                                            objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineTxnLineID = "";
                                        }

                                        objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                        objSRLine.TxnDate = Convert.ToString(loSalesReceipt.TxnDate.GetValue().ToString("MM-dd-yyyy"));
                                        if (loSalesReceipt.FOB != null) objSRLine.FOB = Convert.ToString(loSalesReceipt.FOB.GetValue());


                                        if (loSalesReceipt.ShipAddress != null)
                                        {
                                            if (loSalesReceipt.ShipAddress.Addr1 != null)
                                                objSRLine.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                            if (loSalesReceipt.ShipAddress.Addr2 != null)
                                                objSRLine.ShipAddressAddr2 = Convert.ToString(loSalesReceipt.ShipAddress.Addr2.GetValue());

                                            if (loSalesReceipt.ShipAddress.Addr3 != null)
                                                objSRLine.ShipAddressAddr3 = Convert.ToString(loSalesReceipt.ShipAddress.Addr3.GetValue());

                                            if (loSalesReceipt.ShipAddress.Addr4 != null)
                                                objSRLine.ShipAddressAddr4 = Convert.ToString(loSalesReceipt.ShipAddress.Addr4.GetValue());

                                            if (loSalesReceipt.ShipAddress.Addr5 != null)
                                                objSRLine.ShipAddressAddr5 = Convert.ToString(loSalesReceipt.ShipAddress.Addr5.GetValue());

                                            if (loSalesReceipt.ShipAddress.City != null)
                                                objSRLine.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                            if (loSalesReceipt.ShipAddress.State != null)
                                                objSRLine.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());

                                            if (loSalesReceipt.ShipAddress.PostalCode != null)
                                                objSRLine.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                            if (loSalesReceipt.ShipAddress.Country != null)
                                                objSRLine.ShipAddressCountry = Convert.ToString(loSalesReceipt.ShipAddress.Country.GetValue());

                                            if (loSalesReceipt.ShipMethodRef != null) Convert.ToString(loSalesReceipt.ShipMethodRef.FullName.GetValue());
                                            if (loSalesReceipt.ShipDate != null) Convert.ToString(loSalesReceipt.ShipDate.GetValue());

                                        }

                                        if(loSalesReceipt.CustomerRef != null)
                                        {
                                            objSRLine.SalesReceiptCustomer = loSalesReceipt.CustomerRef.FullName.GetValue();
                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptCustomer = "";
                                        }
                                    }
                                    if (objSRLine.SalesReceiptLineItemRefFullName == "" || objSRLine.SalesReceiptQty == 0)
                                    {
                                        continue;
                                    }



                                    if ((lobjQBConfiguration.GetLabelConfigSettings("SREnablecustomfields").ToString() == "1"))
                                    {
                                        //----------------------- News logic end to Get custom fields from sales order---------------
                                        //custom field show for sales order added by khushal:date 01/24/13
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSRLine.SalesReceiptLineItemRefFullName);

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
                                            CustomerQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSRLine.SalesReceiptCustomer);
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
                                            string refvalue = objSRLine.RefNumber + "&" + objSRLine.SalesReceiptLineTxnLineID;
                                            lobjItemExtensions.Add("refnumber", refvalue);
                                            objcustvalue.Add(lobjItemExtensions);
                                            lobjItemExtensions = new Dictionary<string, string>();

                                        }

                                    }
                                    if (!string.IsNullOrWhiteSpace(objSRLine.RefNumber))
                                    {
                                        alSalesReceiptLine.Add(objSRLine);
                                    }
                                    objSRLine = new clsSalesReceiptLineItems();

                                    // }
                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = objcustvalue;
                return alSalesReceiptLine;
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



        private clsSalesReceiptLineItems GetInvItem(ISalesReceiptLineRet poInvoiceLineRet)
        {
            clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();
            double dbluomquantity = 0;
            string lstruomquantity = string.Empty;

            if (poInvoiceLineRet.Quantity != null)
            {
                objSRLine.SalesReceiptQty = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
                // objINVLine.InvoiceQuantity = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptQty = 0.00;
            }

            if (poInvoiceLineRet.UnitOfMeasure != null)
            {
                objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue());
                //convert UOM quantity to quantity
                if (poInvoiceLineRet.Quantity != null)
                {
                    lstruomquantity = System.Text.RegularExpressions.Regex.Replace(Convert.ToString(poInvoiceLineRet.UnitOfMeasure.GetValue()), "[^0-9]+", string.Empty);
                    if (!string.IsNullOrWhiteSpace(lstruomquantity))
                    {
                        dbluomquantity = Convert.ToDouble(lstruomquantity);
                        objSRLine.SalesReceiptQty = Convert.ToDouble(poInvoiceLineRet.Quantity.GetValue()) / dbluomquantity;
                    }

                }

            }
            else
            {
                objSRLine.SalesReceiptLineUnitOfMeasure = "";
            }


            if (poInvoiceLineRet.ItemRef != null)
            {
                objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());
                objSRLine.SalesReceiptItemName = Convert.ToString(poInvoiceLineRet.ItemRef.FullName.GetValue());


            }

            else
            {
                objSRLine.SalesReceiptLineItemRefFullName = "";
            }
            if (poInvoiceLineRet.Desc != null)
            {
                objSRLine.SalesReceiptLineDesc = Convert.ToString(poInvoiceLineRet.Desc.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineDesc = "";
            }
            //for test only:Date 01-Nov-2018
            if (poInvoiceLineRet.Other1 != null)
            {
                objSRLine.Other1L = poInvoiceLineRet.Other1.GetValue();

            }
            else
            {
                objSRLine.Other1L = "";
            }
            if (poInvoiceLineRet.TxnLineID != null)
            {
                objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(poInvoiceLineRet.TxnLineID.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineTxnLineID = "";
            }

            return objSRLine;
        }

        private clsSalesReceiptLineItems GetInvGroupItem(ISalesReceiptLineGroupRet poInvoiceLineGroupRet)
        {
            clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();

            if (poInvoiceLineGroupRet.Quantity != null)
            {
                objSRLine.SalesReceiptQty = Convert.ToDouble(poInvoiceLineGroupRet.Quantity.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptQty = 0.00;
            }

            if (poInvoiceLineGroupRet.Desc != null)
            {
                objSRLine.SalesReceiptLineDesc = Convert.ToString(poInvoiceLineGroupRet.Desc.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineDesc = string.Empty;
            }

            if (poInvoiceLineGroupRet.ItemGroupRef != null)
            {
                objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(poInvoiceLineGroupRet.ItemGroupRef.FullName.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineItemRefFullName = string.Empty;
            }

            if (poInvoiceLineGroupRet.TxnLineID != null)
            {
                objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(poInvoiceLineGroupRet.TxnLineID.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineTxnLineID = string.Empty;
            }

            if (poInvoiceLineGroupRet.UnitOfMeasure != null)
            {
                objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(poInvoiceLineGroupRet.UnitOfMeasure.GetValue());
            }
            else
            {
                objSRLine.SalesReceiptLineUnitOfMeasure = string.Empty;
            }

            return objSRLine;
        }

        //sales order item display for close mode
        public ArrayList GetSRLine(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alSalesReceiptLine = new ArrayList();
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                SalesReceiptQuery.IncludeLineItems.SetValue(true);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRetList loSalesReceiptLine = default(ISalesReceiptLineRetList);
                    string strExtFieldName = string.Empty;
                    string strExtFieldValue = string.Empty;
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesReceipt = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();

                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                                //To not show item when quantity does not exist or zeoro: Date 01/07/2015
                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity != null && loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue() != 0)
                                {
                                    objSRLine.SalesReceiptQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());
                                    //To print customer part number                                    

                                    //To show shipping method
                                    if (loSalesReceipt.ShipMethodRef != null)
                                    {
                                        objSRLine.SalesReceiptShipMethod = Convert.ToString(loSalesReceipt.ShipMethodRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptShipMethod = "";
                                    }
                                    if (loSalesReceipt.CustomerRef.FullName != null)
                                    {
                                        objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptCustomer = "";
                                    }

                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure != null)
                                    {
                                        objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = "";
                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc != null)
                                    {
                                        objSRLine.SalesReceiptLineDesc = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineDesc = "";
                                    }

                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID != null)
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = "";
                                    }
                                    // alSalesReceiptsLine.Add(objSRLine);

                                    IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                    if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                    {
                                        for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                        {
                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);
                                            ////Get value of OwnerID
                                            //if (DataExtRet.OwnerID != null)
                                            //{
                                            //    string OwnerID115 = (string)DataExtRet.OwnerID.GetValue();
                                            //}
                                            //Get value of DataExtName
                                            switch ((string)DataExtRet.DataExtName.GetValue().ToUpper().Trim())
                                            {

                                                case "OTHER1":
                                                    objSRLine.CustomerPOLineNo = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                case "CUSTNO":
                                                    objSRLine.CustNo = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                case "OTHER2":
                                                    objSRLine.SROther2 = (string)DataExtRet.DataExtValue.GetValue();
                                                    break;
                                                default:
                                                    break;


                                            }
                                            //strdName = (string)DataExtRet.DataExtName.GetValue();
                                            ////Get value of DataExtType
                                            //ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                            ////Get value of DataExtValue
                                            //strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                            //if (!lobjItemExtensions.ContainsKey(strdName))
                                            //lobjItemExtensions.Add(strdName, strdValue);
                                        }
                                    }

                                    alSalesReceiptLine.Add(objSRLine);


                                }
                            }
                        }
                    }
                }
                return alSalesReceiptLine;
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


        private clsSalesReceiptLineItems GetSRGroupItem(ISalesReceiptLineGroupRet poInvoiceLineGroupRet)
        {

            clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();

            if (poInvoiceLineGroupRet.ItemGroupRef != null)
            {
                objSRLine.CustomerRefFullName = Convert.ToString(poInvoiceLineGroupRet.ItemGroupRef.FullName.GetValue());
            }
            return objSRLine;
        }

        //sales order item display for open mode,add out param:Date 10-APR-2019
        public ArrayList GetSRLine(string strRefNumber, string strMarkupPriceField)
        {

            ArrayList alSalesReceiptLine = new ArrayList();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lcustomercustomfield = new Dictionary<string, string>();
            decimal roundofresult;
            string lstrCustomerCustomFieldColonLeftpart = string.Empty;
            string lstrCustomerCustomFieldColonRightpart = string.Empty;

            // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                // lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                IItemQuery lobjIItemQuery = null;
                IResponse lobjIResponse;
                ENObjectType lobjResponseDetailType;
                IORItemRetList lobjIORItemRetList;
                ENResponseType lobjResponseType;

                IORItemRet lobjIORItemRet;
                IMsgSetResponse lobjIMsgSetResponse;
                IDataExtRetList lobjIDataExtRetList;

                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                IItemOtherChargeQuery OtherChargeQueryRq = lMsgRequest.AppendItemOtherChargeQueryRq();

                SalesReceiptQuery.IncludeLineItems.SetValue(true);
                //SalesReceiptQuery.IncludeLinkedTxns.SetValue(true);
                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRetList loSalesReceiptLine = default(ISalesReceiptLineRetList);
                    string strExtFieldName = string.Empty;
                    string strExtFieldValue = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strItemcost = string.Empty;


                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesReceipt = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                //  clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();
                                clsSalesReceiptLineItems objSRLine;

                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet != null)
                                {
                                    objSRLine = new clsSalesReceiptLineItems();
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.ItemGroupRef.FullName != null)
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.ItemGroupRef.FullName.GetValue();
                                        objSRLine.GroupItemType = "P";
                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Quantity != null)
                                    {
                                        objSRLine.SalesReceiptQty = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Quantity.GetValue();

                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Desc != null)
                                    {
                                        objSRLine.SalesReceiptLineDesc = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.Desc.GetValue();

                                    }
                                    //9-Dec-2018.Add new condition for group item print
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.TxnLineID != null)
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = "";
                                    }
                                    alSalesReceiptLine.Add(objSRLine); //Group parent Item add
                                    //Get child items for Group Item:Date 26-Feb-2020
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.Count; grpitem++)
                                        {
                                            objSRLine = new clsSalesReceiptLineItems();
                                            ISalesReceiptLineRet SalesReceiptLineRet = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.GetAt(grpitem);
                                            if (SalesReceiptLineRet.Quantity != null && Convert.ToInt64(SalesReceiptLineRet.Quantity.GetValue()) != 0)
                                            {

                                                if (SalesReceiptLineRet.ItemRef.FullName != null)
                                                {
                                                    objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                                    objSRLine.MPN = GetFMGPartNumber(Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                }
                                                if (SalesReceiptLineRet.Desc != null)
                                                {
                                                    objSRLine.SalesReceiptLineDesc = Convert.ToString(SalesReceiptLineRet.Desc.GetValue());
                                                }
                                                if (SalesReceiptLineRet.Quantity != null)
                                                {
                                                    objSRLine.SalesReceiptQty = SalesReceiptLineRet.Quantity.GetValue();

                                                }
                                                if (SalesReceiptLineRet.ORRate != null)
                                                {
                                                    if (SalesReceiptLineRet.ORRate.Rate != null)
                                                    {
                                                        objSRLine.SalesPrice = Convert.ToString(SalesReceiptLineRet.ORRate.Rate.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSRLine.SalesPrice = null;
                                                }
                                                if (SalesReceiptLineRet.Other1 != null) //16-Mar-2020
                                                {
                                                    objSRLine.Other1L = Convert.ToString(SalesReceiptLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Other1L = "";
                                                }
                                                if (SalesReceiptLineRet.Other2 != null)
                                                {
                                                    objSRLine.Other2L = Convert.ToString(SalesReceiptLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Other2L = "";
                                                }
                                                if (SalesReceiptLineRet.ClassRef != null)
                                                {
                                                    if (SalesReceiptLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSRLine.Class = Convert.ToString(SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Class = "";
                                                    }
                                                }
                                                if (SalesReceiptLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSRLine.Amount = Convert.ToString(SalesReceiptLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Amount = "";
                                                }
                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSRLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSRLine.Cost = "";
                                                }
                                                if (SalesReceiptLineRet.TxnLineID != null)
                                                {
                                                    objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(SalesReceiptLineRet.TxnLineID.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.SalesReceiptLineTxnLineID = "";
                                                }
                                                if (loSalesReceipt.CustomerRef != null)
                                                {
                                                    if (loSalesReceipt.CustomerRef.FullName != null)
                                                    {
                                                        objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                                                        //Get Customer custom field
                                                        if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                        {
                                                            lcustomercustomfield = GetSalesRecepitCustomerCustomField(objSRLine.SalesReceiptCustomer);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        objSRLine.SalesReceiptCustomer = "";
                                                    }
                                                }
                                                if (lcustomercustomfield.Count > 0)
                                                {
                                                    //Get Dictionary value by key SalesReceiptLineRateDiscounted
                                                    // if (lcustomercustomfield.ContainsKey("SalesReceiptLINERATEDISCOUNTED"))
                                                    if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                    {
                                                        //Get Item Sales price
                                                        // objSRLine.SalesPrice = GetItemSalesPrice(objSRLine.SalesReceiptItemName);
                                                        if (!string.IsNullOrWhiteSpace(objSRLine.SalesPrice))
                                                        {
                                                            //get Left and right part of the ":" in string
                                                            lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                            lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                            // Multiply sales price by custom field left part(:) value and round off value
                                                            // roundofresult = Math.Round(Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
                                                            //Remove Round off from calculation :Date 22-Mar-2018
                                                            roundofresult = Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                            if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                            {

                                                                objSRLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                            }
                                                            else
                                                            {
                                                                objSRLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                            }
                                                        }


                                                    }
                                                }

                                                alSalesReceiptLine.Add(objSRLine); //add child for group item
                                            }
                                        }
                                    }

                                }


                                else if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                {
                                    objSRLine = new clsSalesReceiptLineItems();
                                    //To not show item when quantity does not exist or zeoro: Date 01/07/2015
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity != null && loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue() != 0 && loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                    {

                                        objSRLine.SalesReceiptQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());

                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                        {
                                            objSRLine.SalesReceiptItemName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptItemName = "";
                                        }
                                        IItemOtherChargeRetList loList1 = null;
                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SREnableotherchargesfields").ToString() == "0"))
                                        {
                                            OtherChargeQueryRq.OwnerIDList.Add("0");
                                            OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                            OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(objSRLine.SalesReceiptItemName);
                                            OtherChargeQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(objSRLine.SalesReceiptItemName);
                                            lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                            IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);
                                             loList1 = (IItemOtherChargeRetList)loResponse2.Detail;

                                        }
                                        if (loList1 == null)
                                        {
                                            //To print customer part number
                                            // objSRLine.MfrpartNumber= GetFMGPartNumber(Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue()));
                                            //To show PONumber
                                            //if (loSalesReceipt.PONumber != null)
                                            //{
                                            //    objSRLine.PONumber = Convert.ToString(loSalesReceipt.PONumber.GetValue());
                                            //}
                                            //else
                                            //{
                                            //    objSRLine.PONumber = "";
                                            //}

                                            //To show shipping method
                                            if (loSalesReceipt.ShipMethodRef != null)
                                            {
                                                objSRLine.SalesReceiptShipMethod = Convert.ToString(loSalesReceipt.ShipMethodRef.FullName.GetValue());

                                            }
                                            else
                                            {
                                                objSRLine.SalesReceiptShipMethod = "";
                                            }
                                            if (loSalesReceipt.CustomerRef != null)
                                            {
                                                if (loSalesReceipt.CustomerRef.FullName != null)
                                                {
                                                    objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                                                    //Get Customer custom field
                                                    //if (lcustomercustomfield.ContainsKey("SalesReceiptLINERATEDISCOUNTED") == false)
                                                    if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()) == false)
                                                    {
                                                        lcustomercustomfield = GetSalesRecepitCustomerCustomField(objSRLine.SalesReceiptCustomer);
                                                    }
                                                }
                                                else
                                                {
                                                    objSRLine.SalesReceiptCustomer = "";
                                                }
                                            }
                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure != null)
                                            {
                                                objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                            }
                                            else
                                            {
                                                objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                            }
                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                            {
                                                objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                                //Show MPN:16-Mar-2020
                                                objSRLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue()), ref strItemcost);
                                                //Added on 29-11-2017
                                                objSRLine.SalesReceiptItemName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());

                                                //Get Item Sales price
                                                //objSRLine.SalesPrice = GetItemSalesPrice(objSRLine.SalesReceiptItemName);
                                                //get sales price from sales line items : Date 22-Feb-2018
                                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate != null)
                                                {
                                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate.Rate != null)
                                                    {
                                                        objSRLine.SalesPrice = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate.Rate.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSRLine.SalesPrice = null;
                                                }

                                                if (lcustomercustomfield.Count > 0)
                                                {
                                                    //Get Dictionary value by key SalesReceiptLineRateDiscounted
                                                    // if (lcustomercustomfield.ContainsKey("SalesReceiptLINERATEDISCOUNTED"))
                                                    if (lcustomercustomfield.ContainsKey(strMarkupPriceField.Trim().ToUpper()))
                                                    {
                                                        //Get Item Sales price
                                                        // objSRLine.SalesPrice = GetItemSalesPrice(objSRLine.SalesReceiptItemName);
                                                        if (!string.IsNullOrWhiteSpace(objSRLine.SalesPrice))
                                                        {
                                                            //get Left and right part of the ":" in string
                                                            lstrCustomerCustomFieldColonLeftpart = clsStringExtension.SubstringBefore(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                            lstrCustomerCustomFieldColonRightpart = clsStringExtension.SubstringAfter(lcustomercustomfield[strMarkupPriceField.Trim().ToUpper()].ToString(), ":");
                                                            // Multiply sales price by custom field left part(:) value and round off value
                                                            // roundofresult = Math.Round(Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart), 0);
                                                            //Remove Round off from calculation :Date 22-Mar-2018
                                                            roundofresult = Convert.ToDecimal(objSRLine.SalesPrice.ToString()) * Convert.ToDecimal(lstrCustomerCustomFieldColonLeftpart);
                                                            if (!string.IsNullOrWhiteSpace(lstrCustomerCustomFieldColonRightpart))
                                                            {
                                                                //objSRLine.MarkUpPrice = Convert.ToString(roundofresult) + "." + lstrCustomerCustomFieldColonRightpart;
                                                                objSRLine.MarkUpPrice = clsStringExtension.SubstringBefore(Convert.ToString(roundofresult), ".") + "." + lstrCustomerCustomFieldColonRightpart;
                                                            }
                                                            else
                                                            {
                                                                objSRLine.MarkUpPrice = Convert.ToString(roundofresult);
                                                            }
                                                        }


                                                    }
                                                }

                                            }
                                            else
                                            {
                                                objSRLine.SalesReceiptLineItemRefFullName = "";
                                                objSRLine.SalesReceiptItemName = "";
                                            }
                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc != null)
                                            {
                                                objSRLine.SalesReceiptLineDesc = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc.GetValue());
                                            }
                                            else
                                            {
                                                objSRLine.SalesReceiptLineDesc = "";
                                            }
                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Amount != null) //16-Mar-2020
                                            {
                                                objSRLine.Amount = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Amount.GetValue());
                                            }
                                            else
                                            {
                                                objSRLine.Amount = "";
                                            }
                                            if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                            {
                                                objSRLine.Cost = Convert.ToString(strItemcost);
                                            }
                                            else
                                            {
                                                objSRLine.Cost = "";
                                            }

                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef != null)
                                            {
                                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                {
                                                    objSRLine.Class = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Class = "";
                                                }
                                            }

                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID != null)
                                            {
                                                objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                            }
                                            else
                                            {
                                                objSRLine.SalesReceiptLineTxnLineID = "";
                                            }

                                            IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                            if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                            {
                                                for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                                {
                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);
                                                    ////Get value of OwnerID
                                                    //if (DataExtRet.OwnerID != null)
                                                    //{
                                                    //    string OwnerID115 = (string)DataExtRet.OwnerID.GetValue();
                                                    //}
                                                    //Get value of DataExtName
                                                    switch ((string)DataExtRet.DataExtName.GetValue().ToUpper().Trim())
                                                    {

                                                        case "OTHER1":
                                                            objSRLine.CustomerPOLineNo = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        case "CUSTNO":
                                                            objSRLine.CustNo = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        case "OTHER2":
                                                            objSRLine.SROther2 = (string)DataExtRet.DataExtValue.GetValue();
                                                            break;
                                                        // case "UNITS/CASE": //added for div CR:Date 05-2016
                                                        //   objSRLine.UnitsPerCase = Convert.ToDouble(DataExtRet.DataExtValue.GetValue());
                                                        //   break;
                                                        default:
                                                            break;


                                                    }
                                                    //strdName = (string)DataExtRet.DataExtName.GetValue();
                                                    ////Get value of DataExtType
                                                    //ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                    ////Get value of DataExtValue
                                                    //strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    //if (!lobjItemExtensions.ContainsKey(strdName))
                                                    //lobjItemExtensions.Add(strdName, strdValue);
                                                }
                                            }

                                            alSalesReceiptLine.Add(objSRLine);

                                            //if (lobjIDataExtRetList1 != null)
                                            //{
                                            //    for (int k = 0; k < lobjIDataExtRetList1.Count; k++)
                                            //    {
                                            //        strdName = Convert.ToString(lobjIDataExtRetList1.GetAt(k).DataExtName.GetValue()).Replace(" ", string.Empty);
                                            //        strdValue = Convert.ToString(lobjIDataExtRetList1.GetAt(k).DataExtValue.GetValue());
                                            //        if (!lobjItemExtensions.ContainsKey(strdName))
                                            //            lobjItemExtensions.Add(strdName, strdValue);

                                            //    }
                                            //}

                                        }

                                    }
                                }


                            }
                        }
                    }
                }
                //pobjItemExtensions = lobjItemExtensions;
                return alSalesReceiptLine;
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


        //Get custom items and other so item details for so packaging mode
        public ArrayList GetSRPackagingLine(string strRefNumber, out List<Itemcustomfields> pobjItemExtensions)
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


                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();
                SalesReceiptQuery.IncludeLineItems.SetValue(true);
                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRet loSalesReceiptLineRetItem = null;
                    ISalesReceiptLineGroupRet loInvoiceLineGroupRet = null;
                    clsSalesReceiptLineItems lobjclsSalesReceiptLineItems = null;

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
                            loSalesReceipt = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                {
                                    loSalesReceiptLineRetItem = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet;
                                    lobjclsSalesReceiptLineItems = GetInvItem(loSalesReceiptLineRetItem);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName != string.Empty && lobjclsSalesReceiptLineItems.SalesReceiptQty != 0)
                                    {
                                        lobjclsSalesReceiptLineItems.RefNumber = strRefNumber;
                                        //if (loSalesReceipt.PONumber != null)
                                        //{
                                        //    lobjclsSalesReceiptLineItems.PONumber = loSalesReceipt.PONumber.GetValue();
                                        //}
                                        if (loSalesReceipt.ShipMethodRef != null)
                                        {
                                            lobjclsSalesReceiptLineItems.SalesReceiptShipMethod = loSalesReceipt.ShipMethodRef.FullName.GetValue();
                                        }
                                        alInvoicesLine.Add(lobjclsSalesReceiptLineItems);

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");


                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsSalesReceiptLineItems.SalesReceiptItemName);
                                        //Set field value for ToName
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsSalesReceiptLineItems.SalesReceiptItemName);


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
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
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
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
                                                                            {
                                                                                blnfieldexist = true;
                                                                                break;
                                                                            }

                                                                        }
                                                                        if (blnfieldexist == false)
                                                                        {
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
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

                                        IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                        if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                        {
                                            for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                            {
                                                IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);

                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();
                                                //Get value of DataExtValue
                                                strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                foreach (var item in list)
                                                {
                                                    if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
                                                    {
                                                        blnfieldexist = true;
                                                        break;
                                                    }

                                                }
                                                if (blnfieldexist == false)
                                                {
                                                    list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
                                                }

                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    //loInvoiceLineGroupRet = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet;
                                    //lobjclsSalesReceiptLineItems = new clsSalesReceiptLineItems();
                                    //lobjclsSalesReceiptLineItems = GetInvGroupItem(loInvoiceLineGroupRet);
                                    ////Below condition to not show item if it is empty
                                    //if (lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName != string.Empty && lobjclsSalesReceiptLineItems.SalesReceiptLineQuantity != 0)
                                    //{
                                    //    lobjclsSalesReceiptLineItems.RefNumber = strRefNumber;
                                    //    alInvoicesLine.Add(lobjclsSalesReceiptLineItems);
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
                  //  lQBSessionManager.EndSession();
                   // lQBSessionManager.CloseConnection();
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
        public ArrayList GetSRDateRangeCustomFields(string strRefNumber, out List<Itemcustomfields> pobjItemExtensions)
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


                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();
                SalesReceiptQuery.IncludeLineItems.SetValue(true);
                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields
                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);

                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                if (lMsgResponse.ResponseList.Count > 0)
                {
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRet loSalesReceiptLineRetItem = null;
                    //ISalesReceiptLineGroupRet loInvoiceLineGroupRet = null;
                    clsSalesReceiptLineItems lobjclsSalesReceiptLineItems = null;

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
                            loSalesReceipt = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                {
                                    loSalesReceiptLineRetItem = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet;
                                    lobjclsSalesReceiptLineItems = GetInvItem(loSalesReceiptLineRetItem);
                                    //Below condition to not show item if it is empty
                                    if (lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName != string.Empty && lobjclsSalesReceiptLineItems.SalesReceiptQty != 0)
                                    {
                                        lobjclsSalesReceiptLineItems.RefNumber = strRefNumber;
                                        //if (loSalesReceipt.PONumber != null)
                                        //{
                                        //    lobjclsSalesReceiptLineItems.PONumber = loSalesReceipt.PONumber.GetValue();
                                        //}
                                        if (loSalesReceipt.ShipMethodRef != null)
                                        {
                                            lobjclsSalesReceiptLineItems.SalesReceiptShipMethod = loSalesReceipt.ShipMethodRef.FullName.GetValue();
                                        }
                                        alInvoicesLine.Add(lobjclsSalesReceiptLineItems);

                                        //----------------------------------------- Custom Field Logic ------------------------------------
                                        lobjIItemQuery = default(IItemQuery);
                                        lMsgItemsRequest.ClearRequests();

                                        lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                        lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                        lobjIItemQuery.OwnerIDList.Add("0");


                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lobjclsSalesReceiptLineItems.SalesReceiptItemName);
                                        //Set field value for ToName
                                        lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lobjclsSalesReceiptLineItems.SalesReceiptItemName);


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
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
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
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
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
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
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
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
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
                                                                            if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
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
                                                                            list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
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

                                        IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                        if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                        {
                                            for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                            {
                                                IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);

                                                strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).Trim().Replace(" ", string.Empty);
                                                //Get value of DataExtValue
                                                strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                foreach (var item in list)
                                                {
                                                    if (item.CustItemkey.Equals(strdName) && item.CustItemRefFullName.ToLower().Equals(lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName.ToLower()))
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
                                                    list.Add(new Itemcustomfields("", lobjclsSalesReceiptLineItems.SalesReceiptLineItemRefFullName, strdName, strdValue));
                                                }

                                            }
                                        }

                                    }
                                }
                                else
                                {

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
        public ArrayList GetSRLine(string lstrQuantityonLabel, string strRefNumber, string strSalesReceiptTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, out Dictionary<string, string> pobjItemExtensions, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alSalesReceiptLine = new ArrayList();
            //Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //step2: create QBFC session manager and prepare the request

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                SalesReceiptQuery.IncludeLineItems.SetValue(true);

                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields

                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    //we have one response for  single add request

                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);

                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRetList loSalesReceiptLine = default(ISalesReceiptLineRetList);

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
                            loSalesReceipt = loList.GetAt(Index);
                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();

                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet == null)
                                {
                                    throw new Exception("Order Containing Group Type of Items are not Supported");
                                }

                                strTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                if (strTxnLineID == strSalesReceiptTxnLineID)
                                {
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity != null)
                                    {
                                        objSRLine.SalesReceiptQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());
                                        objSRLine.SRQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());

                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptQty = 0.00;
                                        objSRLine.SRQty = 0.00; //merge from H-H ver
                                    }

                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure != null)
                                    {
                                        objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineItemRefFullName = "";
                                    }
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc != null)
                                    {
                                        objSRLine.SalesReceiptLineDesc = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineDesc = "";
                                    }

                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID != null)
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                    }
                                    else
                                    {
                                        objSRLine.SalesReceiptLineTxnLineID = "";
                                    }
                                    //new column PONumber printed:Date:01/24/13





                                    objSRLine.CustomerRefFullName = strCustomerRefFullName;
                                    objSRLine.CustomerCompanyName = strCompanyName;
                                    objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                    objSRLine.TxnDate = dtTransactionDate.ToShortDateString();
                                    alSalesReceiptLine.Add(objSRLine);

                                    //-----------Added by srinivas on 22-Dec-2014
                                    lobjIItemQuery = default(IItemQuery);
                                    lMsgItemsRequest.ClearRequests();

                                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                    lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                    lobjIItemQuery.OwnerIDList.Add("0");
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSRLine.SalesReceiptLineItemRefFullName);
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

                                    IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                    if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                    {
                                        for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                        {
                                            IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);


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
                                    alSalesReceiptLine.Add(objSRLine);

                                }
                            }
                        }
                    }
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesReceiptLine;
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
        public Dictionary<string, string> GetSalesRecepitCustomerCustomField(string pstrItemName)
        {

            // ArrayList alProduct = new ArrayList();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            // clsItemDetails lobjItemdetails = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
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
                   // lQBSessionManager.EndSession();
                   // lQBSessionManager.CloseConnection();
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
        public string GetCustomerPhoneNumber(string pstrCustomerName)
        {
            string lstrGetCompanyName = string.Empty;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
                ICustomerQuery CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.MaxReturned.SetValue(1);
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrCustomerName);
                //Set field value for ToName
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrCustomerName);

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

                                if (responseType == ENResponseType.rtCustomerQueryRs)
                                {
                                    ICustomerRetList loList = (ICustomerRetList)loResponse.Detail;

                                    ICustomerRet loProduct = default(ICustomerRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {

                                            loProduct = loList.GetAt(Index);
                                            if (loProduct.Phone != null)
                                                lstrGetCompanyName = Convert.ToString(loProduct.Phone.GetValue());

                                        }
                                    }


                                }


                            }
                        }
                    }



                }
                return lstrGetCompanyName;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

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
        public ArrayList GetSRLine(string lstrQuantityonLabel, string strRefNumber, string strSalesReceiptTxnLineID, DateTime dtTransactionDate, string strCustomerRefFullName, string strCompanyName, string strQtypercontainerfield, out Dictionary<string, string> pobjItemExtensions)
        {
            ArrayList alSalesReceiptLine = new ArrayList();
            ArrayList alSRLineAssemblyItem = new ArrayList();
            var lobjQBConfiguration = new QBConfiguration();
            string Itemname = "";
            //Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
            //step2: create QBFC session manager and prepare the request
            //QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;

            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            IMsgSetResponse lobjIMsgItemsResponse = default(IMsgSetResponse);
            try
            {
                // IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                // lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);

                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();
                IItemInventoryAssemblyQuery AssemblyItemInventoryQueryRq = lMsgRequest.AppendItemInventoryAssemblyQueryRq();
                IItemQuery ItemQueryRq = lMsgRequest.AppendItemQueryRq();

                SalesReceiptQuery.IncludeLineItems.SetValue(true);

                SalesReceiptQuery.OwnerIDList.Add("0"); //to show all fields

                SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);

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

                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);
                    ISalesReceiptLineRetList loSalesReceiptLine = default(ISalesReceiptLineRetList);

                    //------------------------- DataExtensionFields -----------------------------
                    string strTxnLineID = string.Empty;
                    string strdName = string.Empty;
                    string strdValue = string.Empty;
                    string strOwnerID = string.Empty;
                    string strItemcost = string.Empty;

                    if (loList != null)
                    {
                        // IMsgSetRequest lMsgItemsRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
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
                        ////lobjIItemQuery = default(IItemQuery);
                        IDataExtRetList lobjIDataExtRetList;

                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesReceipt = loList.GetAt(Index);

                            for (int intLine = 0; intLine < loSalesReceipt.ORSalesReceiptLineRetList.Count; intLine++)
                            {
                                // clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();
                                clsSalesReceiptLineItems objSRLine = new clsSalesReceiptLineItems();

                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet != null)
                                {
                                    //Get Group Item child record
                                    if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList != null)
                                    {

                                        for (int grpitem = 0; grpitem < loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.Count; grpitem++)
                                        {

                                            ISalesReceiptLineRet SalesReceiptLineRet = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineGroupRet.SalesReceiptLineRetList.GetAt(grpitem);
                                            strTxnLineID = Convert.ToString(SalesReceiptLineRet.TxnLineID.GetValue());
                                            if (strTxnLineID == strSalesReceiptTxnLineID)
                                            {
                                                objSRLine = new clsSalesReceiptLineItems();

                                                if ((lobjQBConfiguration.GetLabelConfigSettings("SREnablecustomfields").ToString() == "1"))
                                                {
                                                    //Get Custom field for group line item.Date 9-Dec-2018
                                                    if (SalesReceiptLineRet.DataExtRetList != null)
                                                    {
                                                        for (int i165 = 0; i165 < SalesReceiptLineRet.DataExtRetList.Count; i165++)
                                                        {
                                                            IDataExtRet DataExtRet = SalesReceiptLineRet.DataExtRetList.GetAt(i165);

                                                            strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty);
                                                            strdValue = Convert.ToString(DataExtRet.DataExtValue.GetValue());
                                                            if (!lobjItemExtensions.ContainsKey(strdName))
                                                                lobjItemExtensions.Add(strdName, strdValue);

                                                        }
                                                    }
                                                    else // get Custom field from item defination.
                                                    {

                                                    }
                                                }
                                                //}
                                                if (SalesReceiptLineRet.ItemRef.FullName != null)
                                                {
                                                    objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                                    //To print MPN from Items screen
                                                    objSRLine.MPN = GetFMGPartNumber(Convert.ToString(SalesReceiptLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                }
                                                if (SalesReceiptLineRet.Desc != null)
                                                {
                                                    objSRLine.SalesReceiptLineDesc = Convert.ToString(SalesReceiptLineRet.Desc.GetValue());
                                                }
                                                if (SalesReceiptLineRet.Quantity != null)
                                                {
                                                    objSRLine.SRQty = SalesReceiptLineRet.Quantity.GetValue();
                                                    objSRLine.SalesReceiptQty = SalesReceiptLineRet.Quantity.GetValue();
                                                }
                                                if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                {
                                                    objSRLine.QtyOnLabel = lstrQuantityonLabel;
                                                }
                                                else
                                                {
                                                    objSRLine.QtyOnLabel = string.Empty;
                                                }
                                                //Add Rate(cost)column support :Date 01-09-2017
                                                if (SalesReceiptLineRet.ORRate != null && SalesReceiptLineRet.ORRate.Rate != null)
                                                {

                                                    objSRLine.SalesReceiptLineRate = Convert.ToString(SalesReceiptLineRet.ORRate.Rate.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.SalesReceiptLineRate = "0";
                                                }

                                                if (loSalesReceipt.FOB != null)
                                                {

                                                    objSRLine.FOB = Convert.ToString(loSalesReceipt.FOB.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.FOB = "";
                                                }
                                                if (loSalesReceipt.Memo != null)
                                                {

                                                    objSRLine.Memo = Convert.ToString(loSalesReceipt.Memo.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Memo = "";
                                                }
                                                if (loSalesReceipt.CheckNumber != null)
                                                {

                                                    objSRLine.CheckNumber = Convert.ToString(loSalesReceipt.CheckNumber.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.CheckNumber = "";
                                                }
                                                if (SalesReceiptLineRet.InventorySiteLocationRef != null)
                                                {
                                                    objSRLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(SalesReceiptLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                }
                                                else
                                                {
                                                    objSRLine.Bin = "";
                                                }
                                                if (SalesReceiptLineRet.ORSerialLotNumber != null)
                                                {
                                                    if (SalesReceiptLineRet.ORSerialLotNumber.LotNumber != null)
                                                    {
                                                        objSRLine.LotNumber = Convert.ToString(SalesReceiptLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                    }
                                                }
                                                else
                                                {
                                                    objSRLine.LotNumber = string.Empty;
                                                }

                                                if (SalesReceiptLineRet.Other1 != null)
                                                {
                                                    objSRLine.Other1L = Convert.ToString(SalesReceiptLineRet.Other1.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Other1L = "";
                                                }
                                                if (SalesReceiptLineRet.Other2 != null)
                                                {
                                                    objSRLine.Other2L = Convert.ToString(SalesReceiptLineRet.Other2.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Other2L = "";
                                                }
                                                if (SalesReceiptLineRet.ClassRef != null)
                                                {
                                                    if (SalesReceiptLineRet.ClassRef.FullName != null) //16-Mar-2020
                                                    {
                                                        objSRLine.Class = Convert.ToString(SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                    }
                                                    else
                                                    {
                                                        objSRLine.Class = "";
                                                    }
                                                }
                                                if (SalesReceiptLineRet.Amount != null) //16-Mar-2020
                                                {
                                                    objSRLine.Amount = Convert.ToString(SalesReceiptLineRet.Amount.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.Amount = "";
                                                }

                                                if (SalesReceiptLineRet.UnitOfMeasure != null)
                                                {
                                                    objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                                }
                                                else
                                                {
                                                    objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                                }

                                                if (loSalesReceipt.DueDate != null)
                                                {
                                                    objSRLine.DueDate = Convert.ToString(loSalesReceipt.DueDate.GetValue());
                                                }
                                               
                                                if (loSalesReceipt.CustomerRef != null)
                                                {
                                                    if (loSalesReceipt.CustomerRef.FullName != null)
                                                    {
                                                        objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()); //Get Customer only
                                                    }
                                                    else
                                                    {
                                                        objSRLine.SalesReceiptCustomer = "";
                                                    }
                                                }

                                                if (loSalesReceipt.SalesRepRef != null)
                                                {
                                                    if (loSalesReceipt.SalesRepRef.FullName != null)
                                                    {
                                                        objSRLine.SalesRepRef = loSalesReceipt.SalesRepRef.FullName.GetValue();
                                                    }
                                                    else
                                                    {
                                                        objSRLine.SalesRepRef = string.Empty;
                                                    }

                                                }
                                                if (loSalesReceipt.Other != null)
                                                {
                                                    objSRLine.Other = loSalesReceipt.Other.GetValue();
                                                }
                                                else
                                                {
                                                    objSRLine.Other = string.Empty;
                                                }

                                                if (loSalesReceipt.ShipDate != null)
                                                {
                                                    objSRLine.ShipDate = loSalesReceipt.ShipDate.GetValue().ToShortDateString();
                                                }
                                                else
                                                {
                                                    objSRLine.ShipDate = string.Empty;
                                                }

                                                //17-Mar-2020

                                                if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                {
                                                    objSRLine.Cost = Convert.ToString(strItemcost);
                                                }
                                                else
                                                {
                                                    objSRLine.Cost = "";
                                                }


                                                if (loSalesReceipt.ShipAddress != null)
                                                {
                                                    if (loSalesReceipt.ShipAddress.Addr1 != null)
                                                        objSRLine.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                                    if (loSalesReceipt.ShipAddress.Addr2 != null)
                                                        objSRLine.ShipAddressAddr2 = Convert.ToString(loSalesReceipt.ShipAddress.Addr2.GetValue());

                                                    if (loSalesReceipt.ShipAddress.Addr3 != null)
                                                        objSRLine.ShipAddressAddr3 = Convert.ToString(loSalesReceipt.ShipAddress.Addr3.GetValue());
                                                    //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                    if (loSalesReceipt.ShipAddress.Addr4 != null)
                                                        objSRLine.ShipAddressAddr4 = Convert.ToString(loSalesReceipt.ShipAddress.Addr4.GetValue());
                                                    if (loSalesReceipt.ShipAddress.Addr5 != null)
                                                        objSRLine.ShipAddressAddr5 = Convert.ToString(loSalesReceipt.ShipAddress.Addr5.GetValue());

                                                    if (loSalesReceipt.ShipAddress.City != null)
                                                        objSRLine.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                                    if (loSalesReceipt.ShipAddress.State != null)
                                                        objSRLine.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());

                                                    if (loSalesReceipt.ShipAddress.PostalCode != null)
                                                        objSRLine.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                                    if (loSalesReceipt.ShipAddress.Country != null)
                                                        objSRLine.ShipAddressCountry = Convert.ToString(loSalesReceipt.ShipAddress.Country.GetValue());

                                                    //support of Note Field:Date 30-Nov-2019
                                                    if (loSalesReceipt.ShipAddress.Note != null)
                                                        objSRLine.Note = Convert.ToString(loSalesReceipt.ShipAddress.Note.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(objSRLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressPostalCode))
                                                    {
                                                        objSRLine.citystatezip += objSRLine.ShipAddressCity + " " + objSRLine.ShipAddressState + " " + objSRLine.ShipAddressPostalCode;
                                                    }


                                                }
                                                //Add BillAddress Block:21-Nov-2019

                                                if (loSalesReceipt.BillAddress != null)
                                                {
                                                    if (loSalesReceipt.BillAddress.Addr1 != null)
                                                        objSRLine.BillAddressAddr1 = Convert.ToString(loSalesReceipt.BillAddress.Addr1.GetValue());

                                                    if (loSalesReceipt.BillAddress.Addr2 != null)
                                                        objSRLine.BillAddressAddr2 = Convert.ToString(loSalesReceipt.BillAddress.Addr2.GetValue());


                                                }

                                                //9-Dec-2018
                                                objSRLine.CustomerRefFullName = strCustomerRefFullName;
                                                objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                                objSRLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                if (loSalesReceipt.ClassRef != null) //from child
                                                {
                                                    if (loSalesReceipt.ClassRef.FullName != null)
                                                    {
                                                        objSRLine.Class = Convert.ToString(loSalesReceipt.ClassRef.FullName.GetValue());
                                                    }

                                                }

                                                //if (SalesReceiptLineRet.ClassRef != null) //from child
                                                //{
                                                //    if (SalesReceiptLineRet.ClassRef.FullName != null)
                                                //    {
                                                //        objSRLine.Class = Convert.ToString(SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                //    }

                                                //}


                                                alSalesReceiptLine.Add(objSRLine);
                                                Itemname = objSRLine.RefNumber.ToString();
                                                ////goto Test;
                                            } // end Txn id compare
                                        } //end for child item
                                    }
                                    // alSalesReceiptsLine.Add(objSRLine);0
                                    //} //TxnId compare end
                                }
                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet != null)
                                {

                                    strTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                    if (strTxnLineID == strSalesReceiptTxnLineID)
                                    {
                                        objSRLine = new clsSalesReceiptLineItems();
                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                        {
                                            objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());

                                        }
                                        else
                                        {
                                            objSRLine.SalesReceiptLineItemRefFullName = "";

                                        }
                                        AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
                                        AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                        string parentName = "";
                                        if ((lMsgResponse.ResponseList.Count > 0))
                                        {
                                            IResponse loResponse1 = lMsgResponse.ResponseList.GetAt(1);

                                            ENResponseType responseType1 = (ENResponseType)loResponse1.Type.GetValue();
                                            if (responseType1 == ENResponseType.rtItemInventoryAssemblyQueryRs) //Supoort of assembly item Date:04-20-2017
                                            {

                                                IItemInventoryAssemblyRetList AssemblyloList = (IItemInventoryAssemblyRetList)loResponse1.Detail;

                                                IItemInventoryAssemblyRet AssemblyloProduct = default(IItemInventoryAssemblyRet);

                                                if (AssemblyloList != null)
                                                {
                                                    for (int i = 0; i < AssemblyloList.Count; i++)
                                                    {

                                                        AssemblyloProduct = AssemblyloList.GetAt(i);

                                                        if (AssemblyloProduct.FullName != null)
                                                        {
                                                            string subName = Convert.ToString(AssemblyloProduct.Name.GetValue());
                                                            if (objSRLine.SalesReceiptLineItemRefFullName == subName)
                                                            {
                                                                if (AssemblyloProduct.ParentRef != null)
                                                                {
                                                                    if (AssemblyloProduct.ParentRef.FullName != null)
                                                                    {
                                                                        parentName = Convert.ToString(AssemblyloProduct.ParentRef.FullName.GetValue());
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        if (parentName != "")
                                                            break;
                                                    }

                                                    string filterItemName = "";
                                                    if (parentName != "")
                                                    {
                                                        filterItemName = (parentName + ":" + objSRLine.SalesReceiptLineItemRefFullName).ToString();
                                                    }
                                                    else
                                                    {
                                                        filterItemName = objSRLine.SalesReceiptLineItemRefFullName;
                                                    }
                                                    AssemblyItemInventoryQueryRq.OwnerIDList.Add("0");
                                                    AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                                    AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(filterItemName);
                                                    AssemblyItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(filterItemName);
                                                    lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);

                                                    if ((lMsgResponse.ResponseList.Count > 0))
                                                    {
                                                        IResponse loResponse2 = lMsgResponse.ResponseList.GetAt(1);

                                                        IItemInventoryAssemblyRetList loList1 = (IItemInventoryAssemblyRetList)loResponse2.Detail;
                                                        IItemInventoryAssemblyRet loSalesReceipt1 = default(IItemInventoryAssemblyRet);

                                                        if (loList1 != null)
                                                        {
                                                            for (int Z = 0; Z < loList1.Count; Z++)
                                                            {
                                                                loSalesReceipt1 = loList1.GetAt(Z);
                                                                for (int intLine2 = 0; intLine2 < loSalesReceipt1.ItemInventoryAssemblyLineList.Count; intLine2++)
                                                                {
                                                                    objSRLine = new clsSalesReceiptLineItems();
                                                                    objSRLine.SalesReceiptLineType = "Assembly";
                                                                    try
                                                                    {
                                                                        var dd = loSalesReceipt1.ItemInventoryAssemblyLineList.GetAt(intLine2).ItemInventoryRef.FullName.GetValue();
                                                                        var Qty = loSalesReceipt1.ItemInventoryAssemblyLineList.GetAt(intLine2).Quantity.GetValue();


                                                                        if (string.IsNullOrWhiteSpace(Qty.ToString().Trim()) || string.IsNullOrEmpty(Qty.ToString().Trim()))
                                                                        {
                                                                            continue;
                                                                        }
                                                                        else if (Convert.ToInt32(Qty) == 0)
                                                                        {
                                                                            continue;
                                                                        }

                                                                        ItemQueryRq.OwnerIDList.Add("0");
                                                                        ItemQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly); //for qb dll 11.0 onward
                                                                        ItemQueryRq.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(dd);
                                                                        ItemQueryRq.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(dd);
                                                                        lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                                                                        bool isitem = true;

                                                                        if ((lMsgResponse.ResponseList.Count > 0))
                                                                        {
                                                                            IResponse loResponse3 = lMsgResponse.ResponseList.GetAt(2);

                                                                            IORItemRetList loList2 = (IORItemRetList)loResponse3.Detail;
                                                                            for (int Index1 = 0; Index1 < loList2.Count; Index1++)
                                                                            {
                                                                                var ItemInventoryAssemblyRet = loList2.GetAt(Index1).ItemInventoryAssemblyRet;
                                                                                var ItemInventoryRet = loList2.GetAt(Index1).ItemInventoryRet;
                                                                                if (ItemInventoryAssemblyRet == null && ItemInventoryRet == null)
                                                                                {
                                                                                    isitem = false;
                                                                                }

                                                                                if (ItemInventoryRet != null)
                                                                                {
                                                                                    if (ItemInventoryRet.ParentRef != null)
                                                                                    {
                                                                                        string parentItemName = "";
                                                                                        if (ItemInventoryRet.ParentRef.FullName != null)
                                                                                        {
                                                                                            parentItemName = Convert.ToString(ItemInventoryRet.ParentRef.FullName.GetValue());
                                                                                        }
                                                                                        if (parentItemName == "SHIPPING-BOXES" || parentItemName == "SHIPPING-BOX")
                                                                                        {
                                                                                            isitem = false;
                                                                                            break;
                                                                                        }


                                                                                    }
                                                                                    if (ItemInventoryRet.FullName != null)
                                                                                    {

                                                                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(ItemInventoryRet.Name.GetValue());
                                                                                        if (objSRLine.SalesReceiptLineItemRefFullName == "SHIPPING-BOXES" || objSRLine.SalesReceiptLineItemRefFullName == "SHIPPING-BOX")
                                                                                        {
                                                                                            isitem = false;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineItemRefFullName = "";
                                                                                    }


                                                                                    if (ItemInventoryRet.SalesDesc != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineDesc = Convert.ToString(ItemInventoryRet.SalesDesc.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineDesc = "";
                                                                                    }
                                                                                    if (ItemInventoryRet.SalesPrice != null)
                                                                                    {
                                                                                        objSRLine.SalesPrice = Convert.ToString(ItemInventoryRet.SalesPrice.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesPrice = "0.00";
                                                                                    }
                                                                                    if (ItemInventoryRet.ClassRef != null)
                                                                                    {
                                                                                        if (ItemInventoryRet.ClassRef != null)
                                                                                        {
                                                                                            if (ItemInventoryRet.ClassRef.FullName != null)
                                                                                            {
                                                                                                objSRLine.Class = Convert.ToString(ItemInventoryRet.ClassRef.FullName.GetValue());
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            objSRLine.Class = "";
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.Class = "";
                                                                                    }
                                                                                    if (ItemInventoryRet.BarCodeValue != null)
                                                                                    {
                                                                                        objSRLine.BarcodeValue = Convert.ToString(ItemInventoryRet.BarCodeValue.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.BarcodeValue = "";
                                                                                    }
                                                                                    if (Qty != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptQty = (Qty * Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue()));
                                                                                        objSRLine.SRQty = Qty;

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptQty = 0.00;
                                                                                        objSRLine.SRQty = 0.00; //merge from H-H ver
                                                                                    }

                                                                                    if (ItemInventoryRet.PurchaseCost != null)
                                                                                    {
                                                                                        objSRLine.Cost = Convert.ToString(ItemInventoryRet.PurchaseCost.GetValue());
                                                                                        objSRLine.SalesReceiptLineRate = Convert.ToString(ItemInventoryRet.PurchaseCost.GetValue());
                                                                                        objSRLine.Amount = Convert.ToString(ItemInventoryRet.PurchaseCost.GetValue() * Convert.ToDouble(objSRLine.SalesReceiptQty));
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.Cost = "";
                                                                                        objSRLine.SalesReceiptLineRate = "";
                                                                                    }

                                                                                    if (ItemInventoryRet.UnitOfMeasureSetRef != null && ItemInventoryRet.UnitOfMeasureSetRef.FullName != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(ItemInventoryRet.UnitOfMeasureSetRef.FullName.GetValue());
                                                                                    }

                                                                                    if (ItemInventoryRet.ManufacturerPartNumber != null)
                                                                                    {
                                                                                        objSRLine.MPN = Convert.ToString(ItemInventoryRet.ManufacturerPartNumber.GetValue());
                                                                                    }

                                                                                }
                                                                                if (ItemInventoryAssemblyRet != null)
                                                                                {
                                                                                 
                                                                                    //}
                                                                                    if (ItemInventoryAssemblyRet.FullName != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(ItemInventoryAssemblyRet.Name.GetValue());

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineItemRefFullName = "";
                                                                                    }
                                                                                    if (ItemInventoryAssemblyRet.SalesDesc != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineDesc = Convert.ToString(ItemInventoryAssemblyRet.SalesDesc.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineDesc = "";
                                                                                    }
                                                                                    if (ItemInventoryAssemblyRet.SalesPrice != null)
                                                                                    {
                                                                                        objSRLine.SalesPrice = Convert.ToString(ItemInventoryAssemblyRet.SalesPrice.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesPrice = "0.00";
                                                                                    }
                                                                                    if (ItemInventoryAssemblyRet.ClassRef != null)
                                                                                    {
                                                                                        if (ItemInventoryAssemblyRet.ClassRef.FullName != null)
                                                                                        {
                                                                                            objSRLine.Class = Convert.ToString(ItemInventoryAssemblyRet.ClassRef.FullName.GetValue());
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            objSRLine.Class = "";
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.Class = "";
                                                                                    }
                                                                                    if (ItemInventoryAssemblyRet.BarCodeValue != null)
                                                                                    {
                                                                                        objSRLine.BarcodeValue = Convert.ToString(ItemInventoryAssemblyRet.BarCodeValue.GetValue());
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.BarcodeValue = "";
                                                                                    }
                                                                                    if (Qty != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptQty = (Qty * Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue()));
                                                                                        objSRLine.SRQty = Qty;

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.SalesReceiptQty = 0.00;
                                                                                        objSRLine.SRQty = 0.00; //merge from H-H ver
                                                                                    }

                                                                                    if (ItemInventoryAssemblyRet.PurchaseCost != null)
                                                                                    {
                                                                                        objSRLine.Cost = Convert.ToString(ItemInventoryAssemblyRet.PurchaseCost.GetValue());
                                                                                        objSRLine.SalesReceiptLineRate = Convert.ToString(ItemInventoryAssemblyRet.PurchaseCost.GetValue());
                                                                                        objSRLine.Amount = Convert.ToString(ItemInventoryAssemblyRet.PurchaseCost.GetValue() * Convert.ToDouble(objSRLine.SalesReceiptQty));
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        objSRLine.Cost = "";
                                                                                        objSRLine.SalesReceiptLineRate = "";
                                                                                    }

                                                                                    if (ItemInventoryAssemblyRet.UnitOfMeasureSetRef != null && ItemInventoryAssemblyRet.UnitOfMeasureSetRef.FullName != null)
                                                                                    {
                                                                                        objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(ItemInventoryAssemblyRet.UnitOfMeasureSetRef.FullName.GetValue());
                                                                                    }

                                                                                    if (ItemInventoryAssemblyRet.ManufacturerPartNumber != null)
                                                                                    {
                                                                                        objSRLine.MPN = Convert.ToString(ItemInventoryAssemblyRet.ManufacturerPartNumber.GetValue());
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                        if (!isitem)
                                                                            continue;

                                                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other1 != null)
                                                                        {
                                                                            objSRLine.Other1L = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other1.GetValue());
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.Other1L = "";
                                                                        }
                                                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other2 != null)
                                                                        {
                                                                            objSRLine.Other2L = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other2.GetValue());
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.Other2L = "";
                                                                        }
                                                                        if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.InventorySiteLocationRef != null)
                                                                        {
                                                                            objSRLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.Bin = "";
                                                                        }
                                                                        if (loSalesReceipt.FOB != null)
                                                                        {

                                                                            objSRLine.FOB = Convert.ToString(loSalesReceipt.FOB.GetValue());
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.FOB = "";
                                                                        }
                                                                        if (loSalesReceipt.CheckNumber != null)
                                                                        {

                                                                            objSRLine.CheckNumber = Convert.ToString(loSalesReceipt.CheckNumber.GetValue());
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.CheckNumber = "";
                                                                        }
                                                                        if (loSalesReceipt.Memo != null)
                                                                        {

                                                                            objSRLine.Memo = Convert.ToString(loSalesReceipt.Memo.GetValue());
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.Memo = "";
                                                                        }

                                                                        //Get DueDate on 21-Feb-2017
                                                                        if (loSalesReceipt.DueDate != null)
                                                                        {

                                                                            objSRLine.DueDate = Convert.ToString(loSalesReceipt.DueDate.GetValue().ToShortDateString());
                                                                        }


                                                                        // add qty on label on multimode so printing : Date 26-08-2016
                                                                        if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                                        {
                                                                            objSRLine.QtyOnLabel = lstrQuantityonLabel;
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.QtyOnLabel = string.Empty;
                                                                        }



                                                                        objSRLine.CustomerRefFullName = strCustomerRefFullName;
                                                                        objSRLine.CustomerCompanyName = strCompanyName;
                                                                        objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                                                        objSRLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                                        //Add SalesReceiptCustomer & BillAddress1:Date 21-Nov-2019
                                                                        if (loSalesReceipt.CustomerRef != null)
                                                                        {
                                                                            if (loSalesReceipt.CustomerRef.FullName != null)
                                                                            {
                                                                                objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()); //Get Customer only
                                                                            }
                                                                            else
                                                                            {
                                                                                objSRLine.SalesReceiptCustomer = "";
                                                                            }
                                                                        }



                                                                        //Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORSerialLotNumber.LotNumber.GetValue());

                                                                        //support for SalesRepRef in so header :Date 01-Jun-2018
                                                                        if (loSalesReceipt.SalesRepRef != null)
                                                                        {
                                                                            if (loSalesReceipt.SalesRepRef.FullName != null)
                                                                            {
                                                                                objSRLine.SalesRepRef = loSalesReceipt.SalesRepRef.FullName.GetValue();
                                                                            }
                                                                            else
                                                                            {
                                                                                objSRLine.SalesRepRef = string.Empty;
                                                                            }

                                                                        }

                                                                        //other field added for so
                                                                        if (loSalesReceipt.Other != null)
                                                                        {
                                                                            objSRLine.Other = loSalesReceipt.Other.GetValue();
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.Other = string.Empty;
                                                                        }
                                                                        //SHIPdATE field added for so ON 24-jULY-2017
                                                                        if (loSalesReceipt.ShipDate != null)
                                                                        {
                                                                            objSRLine.ShipDate = loSalesReceipt.ShipDate.GetValue().ToShortDateString();
                                                                        }
                                                                        else
                                                                        {
                                                                            objSRLine.ShipDate = string.Empty;
                                                                        }

                                                                        //To show ShipAddressBlock for unit case per quantity modification

                                                                        if (loSalesReceipt.ShipAddress != null)
                                                                        {
                                                                            if (loSalesReceipt.ShipAddress.Addr1 != null)
                                                                                objSRLine.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.Addr2 != null)
                                                                                objSRLine.ShipAddressAddr2 = Convert.ToString(loSalesReceipt.ShipAddress.Addr2.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.Addr3 != null)
                                                                                objSRLine.ShipAddressAddr3 = Convert.ToString(loSalesReceipt.ShipAddress.Addr3.GetValue());
                                                                            //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                                            if (loSalesReceipt.ShipAddress.Addr4 != null)
                                                                                objSRLine.ShipAddressAddr4 = Convert.ToString(loSalesReceipt.ShipAddress.Addr4.GetValue());
                                                                            if (loSalesReceipt.ShipAddress.Addr5 != null)
                                                                                objSRLine.ShipAddressAddr5 = Convert.ToString(loSalesReceipt.ShipAddress.Addr5.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.City != null)
                                                                                objSRLine.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.State != null)
                                                                                objSRLine.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.PostalCode != null)
                                                                                objSRLine.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                                                            if (loSalesReceipt.ShipAddress.Country != null)
                                                                                objSRLine.ShipAddressCountry = Convert.ToString(loSalesReceipt.ShipAddress.Country.GetValue());

                                                                            //support of Note Field:Date 30-Nov-2019
                                                                            if (loSalesReceipt.ShipAddress.Note != null)
                                                                                objSRLine.Note = Convert.ToString(loSalesReceipt.ShipAddress.Note.GetValue());
                                                                            //citystatezip field added:Date 30-APR-2019
                                                                            if (!string.IsNullOrWhiteSpace(objSRLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressPostalCode))
                                                                            {
                                                                                objSRLine.citystatezip += objSRLine.ShipAddressCity + " " + objSRLine.ShipAddressState + " " + objSRLine.ShipAddressPostalCode;
                                                                            }


                                                                        }
                                                                        //Add BillAddress Block:21-Nov-2019

                                                                        if (loSalesReceipt.BillAddress != null)
                                                                        {
                                                                            if (loSalesReceipt.BillAddress.Addr1 != null)
                                                                                objSRLine.BillAddressAddr1 = Convert.ToString(loSalesReceipt.BillAddress.Addr1.GetValue());

                                                                            if (loSalesReceipt.BillAddress.Addr2 != null)
                                                                                objSRLine.BillAddressAddr2 = Convert.ToString(loSalesReceipt.BillAddress.Addr2.GetValue());


                                                                        }
                                                                        if ((lobjQBConfiguration.GetLabelConfigSettings("SREnablecustomfields").ToString() == "1"))
                                                                        {
                                                                            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("CustomField") == "S")
                                                                            {
                                                                                //----------------------- News logic end to Get custom fields from sales recipt---------------
                                                                                //custom field show for sales recipt added by TamilRK
                                                                                lobjIItemQuery = default(IItemQuery);
                                                                                lMsgItemsRequest.ClearRequests();

                                                                                lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                                                                lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                                                                lobjIItemQuery.OwnerIDList.Add("0");
                                                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                                                                lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSRLine.SalesReceiptLineItemRefFullName);
                                                                                //lobjIMsgSetResponse = pobjQBSessionManager.DoRequests(lMsgItemsRequest);
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
                                                                            }
                                                                            //custom field code end//

                                                                            //Below code added from H-H ver : Date 06/25/2015

                                                                            IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                                                            if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                                                            {
                                                                                for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                                                                {
                                                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);


                                                                                    //strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim();
                                                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                                                    //Get value of DataExtType
                                                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                                                    //Get value of DataExtValue
                                                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                                                    //Get QtyperContainer Custom field value:Date 05-23-2016
                                                                                    //if (strdName != "QTYPERCONTAINER")
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
                                                                        alSalesReceiptLine.Add(objSRLine);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {

                                                                        throw ex;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            //Other1 as Other1L and Other2 as Other2L Added:Date 16-May-2016
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other1 != null)
                                                            {
                                                                objSRLine.Other1L = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other1.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Other1L = "";
                                                            }
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other2 != null)
                                                            {
                                                                objSRLine.Other2L = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Other2.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Other2L = "";
                                                            }
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.InventorySiteLocationRef != null)
                                                            {
                                                                objSRLine.Bin = clsStringExtension.SubstringAfter(Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.InventorySiteLocationRef.FullName.GetValue()), ":");

                                                            }
                                                            else
                                                            {
                                                                objSRLine.Bin = "";
                                                            }

                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity != null)
                                                            {
                                                                objSRLine.SalesReceiptQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());
                                                                objSRLine.SRQty = Convert.ToDouble(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Quantity.GetValue());

                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptQty = 0.00;
                                                                objSRLine.SRQty = 0.00; //merge from H-H ver
                                                            }

                                                            if (!string.IsNullOrWhiteSpace(strItemcost)) //17-Mar-2020
                                                            {
                                                                objSRLine.Cost = Convert.ToString(strItemcost);
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Cost = "";
                                                            }

                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Amount != null)
                                                            {
                                                                objSRLine.Amount = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Amount.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Amount = "";
                                                            }


                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure != null)
                                                            {
                                                                objSRLine.SalesReceiptLineUnitOfMeasure = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.UnitOfMeasure.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptLineUnitOfMeasure = "";
                                                            }
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef != null)
                                                            {
                                                                objSRLine.SalesReceiptLineItemRefFullName = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue());
                                                                //To print MPN from Items screen
                                                                objSRLine.MPN = GetFMGPartNumber(Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ItemRef.FullName.GetValue()), ref strItemcost);

                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptLineItemRefFullName = "";

                                                            }
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc != null)
                                                            {
                                                                objSRLine.SalesReceiptLineDesc = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.Desc.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptLineDesc = "";
                                                            }

                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID != null)
                                                            {
                                                                objSRLine.SalesReceiptLineTxnLineID = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.TxnLineID.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptLineTxnLineID = "";
                                                            }
                                                            //Add Rate(cost)column support :Date 01-09-2017
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate != null && loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate.Rate != null)
                                                            {
                                                                objSRLine.SalesReceiptLineRate = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORRate.Rate.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.SalesReceiptLineRate = "0";
                                                            }


                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORSerialLotNumber != null)
                                                            {
                                                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORSerialLotNumber.LotNumber != null)
                                                                {
                                                                    objSRLine.LotNumber = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORSerialLotNumber.LotNumber.GetValue());
                                                                }
                                                            }
                                                            else
                                                            {
                                                                objSRLine.LotNumber = string.Empty;
                                                            }
                                                            if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef != null)
                                                            {
                                                                if (loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef.FullName != null)
                                                                {
                                                                    objSRLine.Class = Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ClassRef.FullName.GetValue());
                                                                }
                                                            }
                                                            if (loSalesReceipt.FOB != null)
                                                            {
                                                                objSRLine.FOB = Convert.ToString(loSalesReceipt.FOB.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.FOB = "";
                                                            }
                                                            if (loSalesReceipt.Memo != null)
                                                            {

                                                                objSRLine.Memo = Convert.ToString(loSalesReceipt.Memo.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Memo = "";
                                                            }
                                                            if (loSalesReceipt.CheckNumber != null)
                                                            {

                                                                objSRLine.CheckNumber = Convert.ToString(loSalesReceipt.CheckNumber.GetValue());
                                                            }
                                                            else
                                                            {
                                                                objSRLine.CheckNumber = "";
                                                            }

                                                            if (loSalesReceipt.DueDate != null)
                                                            {

                                                                objSRLine.DueDate = Convert.ToString(loSalesReceipt.DueDate.GetValue().ToShortDateString());
                                                            }


                                                            if (!string.IsNullOrWhiteSpace(lstrQuantityonLabel))
                                                            {
                                                                objSRLine.QtyOnLabel = lstrQuantityonLabel;
                                                            }
                                                            else
                                                            {
                                                                objSRLine.QtyOnLabel = string.Empty;
                                                            }



                                                            objSRLine.CustomerRefFullName = strCustomerRefFullName;
                                                            objSRLine.CustomerCompanyName = strCompanyName;
                                                            objSRLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                                                            objSRLine.TxnDate = dtTransactionDate.ToShortDateString();

                                                            if (loSalesReceipt.CustomerRef != null)
                                                            {
                                                                if (loSalesReceipt.CustomerRef.FullName != null)
                                                                {
                                                                    objSRLine.SalesReceiptCustomer = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':') > -1 ? Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).Substring(0, Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()).IndexOf(':')) : Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue()); //Get Customer only
                                                                }
                                                                else
                                                                {
                                                                    objSRLine.SalesReceiptCustomer = "";
                                                                }
                                                            }

                                                            //Convert.ToString(loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine).SalesReceiptLineRet.ORSerialLotNumber.LotNumber.GetValue());

                                                            if (loSalesReceipt.SalesRepRef != null)
                                                            {
                                                                if (loSalesReceipt.SalesRepRef.FullName != null)
                                                                {
                                                                    objSRLine.SalesRepRef = loSalesReceipt.SalesRepRef.FullName.GetValue();
                                                                }
                                                                else
                                                                {
                                                                    objSRLine.SalesRepRef = string.Empty;
                                                                }

                                                            }

                                                            if (loSalesReceipt.Other != null)
                                                            {
                                                                objSRLine.Other = loSalesReceipt.Other.GetValue();
                                                            }
                                                            else
                                                            {
                                                                objSRLine.Other = string.Empty;
                                                            }

                                                            if (loSalesReceipt.ShipDate != null)
                                                            {
                                                                objSRLine.ShipDate = loSalesReceipt.ShipDate.GetValue().ToShortDateString();
                                                            }
                                                            else
                                                            {
                                                                objSRLine.ShipDate = string.Empty;
                                                            }

                                                            //To show ShipAddressBlock for unit case per quantity modification

                                                            if (loSalesReceipt.ShipAddress != null)
                                                            {
                                                                if (loSalesReceipt.ShipAddress.Addr1 != null)
                                                                    objSRLine.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                                                if (loSalesReceipt.ShipAddress.Addr2 != null)
                                                                    objSRLine.ShipAddressAddr2 = Convert.ToString(loSalesReceipt.ShipAddress.Addr2.GetValue());

                                                                if (loSalesReceipt.ShipAddress.Addr3 != null)
                                                                    objSRLine.ShipAddressAddr3 = Convert.ToString(loSalesReceipt.ShipAddress.Addr3.GetValue());
                                                                //ShipAddress4,ShipAddress5 support added:30-Nov-2019
                                                                if (loSalesReceipt.ShipAddress.Addr4 != null)
                                                                    objSRLine.ShipAddressAddr4 = Convert.ToString(loSalesReceipt.ShipAddress.Addr4.GetValue());
                                                                if (loSalesReceipt.ShipAddress.Addr5 != null)
                                                                    objSRLine.ShipAddressAddr5 = Convert.ToString(loSalesReceipt.ShipAddress.Addr5.GetValue());

                                                                if (loSalesReceipt.ShipAddress.City != null)
                                                                    objSRLine.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                                                if (loSalesReceipt.ShipAddress.State != null)
                                                                    objSRLine.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());

                                                                if (loSalesReceipt.ShipAddress.PostalCode != null)
                                                                    objSRLine.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                                                if (loSalesReceipt.ShipAddress.Country != null)
                                                                    objSRLine.ShipAddressCountry = Convert.ToString(loSalesReceipt.ShipAddress.Country.GetValue());

                                                                //support of Note Field:
                                                                if (loSalesReceipt.ShipAddress.Note != null)
                                                                    objSRLine.Note = Convert.ToString(loSalesReceipt.ShipAddress.Note.GetValue());
                                                                //citystatezip field added:
                                                                if (!string.IsNullOrWhiteSpace(objSRLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objSRLine.ShipAddressPostalCode))
                                                                {
                                                                    objSRLine.citystatezip += objSRLine.ShipAddressCity + " " + objSRLine.ShipAddressState + " " + objSRLine.ShipAddressPostalCode;
                                                                }


                                                            }
                                                            //Add BillAddress Block

                                                            if (loSalesReceipt.BillAddress != null)
                                                            {
                                                                if (loSalesReceipt.BillAddress.Addr1 != null)
                                                                    objSRLine.BillAddressAddr1 = Convert.ToString(loSalesReceipt.BillAddress.Addr1.GetValue());

                                                                if (loSalesReceipt.BillAddress.Addr2 != null)
                                                                    objSRLine.BillAddressAddr2 = Convert.ToString(loSalesReceipt.BillAddress.Addr2.GetValue());


                                                            }

                                                            if ((lobjQBConfiguration.GetLabelConfigSettings("SREnablecustomfields").ToString() == "1"))
                                                            {
                                                                if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("CustomField") == "S")
                                                                {
                                                                    //----------------------- News logic end to Get custom fields from sales Receipt---------------
                                                                    //custom field show for sales receipt added by TamilRk
                                                                    lobjIItemQuery = default(IItemQuery);
                                                                    lMsgItemsRequest.ClearRequests();

                                                                    lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;
                                                                    lobjIItemQuery = lMsgItemsRequest.AppendItemQueryRq();
                                                                    lobjIItemQuery.OwnerIDList.Add("0");
                                                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                                                                    lobjIItemQuery.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(objSRLine.SalesReceiptLineItemRefFullName);
                                                                    //lobjIMsgSetResponse = pobjQBSessionManager.DoRequests(lMsgItemsRequest);
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
                                                                }
                                                            }
                                                            //custom field code end//


                                                            IORSalesReceiptLineRet lobjIDataExtRetList1 = loSalesReceipt.ORSalesReceiptLineRetList.GetAt(intLine);

                                                            if (lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList != null)
                                                            {
                                                                for (int k = 0; k < lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.Count; k++)
                                                                {
                                                                    IDataExtRet DataExtRet = lobjIDataExtRetList1.SalesReceiptLineRet.DataExtRetList.GetAt(k);


                                                                    //strdName = (string)DataExtRet.DataExtName.GetValue().ToUpper().Trim();
                                                                    strdName = Convert.ToString(DataExtRet.DataExtName.GetValue()).ToUpper().Trim().Replace(" ", string.Empty).ToUpper();

                                                                    //Get value of DataExtType
                                                                    ENDataExtType DataExtType117 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                                                    //Get value of DataExtValue
                                                                    strdValue = (string)DataExtRet.DataExtValue.GetValue();
                                                                    //Get QtyperContainer Custom field value:Date 05-23-2016
                                                                    //if (strdName != "QTYPERCONTAINER")
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

                                                            alSalesReceiptLine.Add(objSRLine);
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
                }
                pobjItemExtensions = lobjItemExtensions;
                return alSalesReceiptLine;

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

    }
}
