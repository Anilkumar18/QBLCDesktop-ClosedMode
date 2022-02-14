using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Windows.Forms;
//using System.Collections;
using LabelConnector;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace QBLC
{
    class clsInvoice
    {
        string _strTxnID;
        DateTime _dtTxnDate;
        string _strRefNumber;
        string _strBillAddressAddr1;
        //To add shipAddress block
        string _strShipAddressAddr1;
        string _strShipAddressAddr2;
        string _strShipAddressAddr3;
        string _strShipAddressAddr4;
        string _strShipAddressAddr5;
        string _strShipAddressCity;
        string _strShipAddressState;
        string _strShipAddressPostalCode;
        string _strShipAddressCountry;
        string _strShipAddressMethod;
        string _strShipDate;
        string _strBillAddressAddr2;
        string _strBillAddress;
        //To show So.No. in the invoice
        string _strLinkTxnRefNumber;
      //  string _strsorderNo;
        //To show Room in the invoice
        string _strCustomFieldOther;
        string _strCustomerRefFullName;
        string _strcitystatezip;
     


        DateTime lstrresult;
        //  string _strRoom;
        string _strBillAddressAddr3;
        string _strBillAddressAddr4;
        string _strBillAddressAddr5;
        string _strBillAddressPostalCode;
        string _strBillAddressCity;
        string _strBillAddressState;
        string _strBillAddressCountry;

        string _dblSalesTaxTotal;
        string _dblBalanceRemaining;
        string _strPONumber;
        string _strFOB;

        

        public string TxnID
        {
            get
            {
                return _strTxnID;
            }
            set
            {
                _strTxnID = value;
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


        public string PONumber
        {
            get
            {
                return _strPONumber;
            }
            set
            {
                _strPONumber = value;
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


        public string CustomerRefFullName
        {
            get { return _strCustomerRefFullName; }
            set { _strCustomerRefFullName = value; }

        }

        public DateTime TxnDate
        {
            get
            {
                return Convert.ToDateTime(_dtTxnDate.ToShortDateString());
            }

            set
            {
                _dtTxnDate = value;
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

        public string BillAddressAddr3
        {
            get
            {
                return _strBillAddressAddr3;
            }
            set
            {
                _strBillAddressAddr3 = value;
            }
        }
        public string BillAddressAddr4
        {
            get
            {
                return _strBillAddressAddr4;
            }
            set
            {
                _strBillAddressAddr4 = value;
            }
        }
        public string BillAddressAddr5
        {
            get
            {
                return _strBillAddressAddr5;
            }
            set
            {
                _strBillAddressAddr5 = value;
            }
        }

        public string BillAddressCity
        {
            get
            {
                return _strBillAddressCity;
            }
            set
            {
                _strBillAddressCity = value;
            }
        }
        public string BillAddressState
        {
            get
            {
                return _strBillAddressState;
            }
            set
            {
                _strBillAddressState = value;
            }
        }
        public string BillAddressPostalCode
        {
            get
            {
                return _strBillAddressPostalCode;
            }
            set
            {
                _strBillAddressPostalCode = value;
            }
        }
        public string BillAddressCountry
        {
            get
            {
                return _strBillAddressCountry;
            }
            set
            {
                _strBillAddressCountry = value;
            }
        }
        public string BillAddress
        {

            get { return _strBillAddress; }
            set { _strBillAddress = value; }
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

        public string ShipAddressMethod
        {
            get { return _strShipAddressMethod; }
            set { _strShipAddressMethod = value; }
        
        }
        public string ShipDate
        {
            get { return _strShipDate; }
            set { _strShipDate = value; }

        }

        //public string CustomerRefListID
        //{
        //    get
        //    {
        //        return _CustomerRefListID;
        //    }
        //    set
        //    {
        //        _CustomerRefListID = value;
        //    }
        //}


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

        public string SalesTaxTotal
        {
            get
            {
                return _dblSalesTaxTotal ?? string.Empty;
            }
            set
            {
                _dblSalesTaxTotal = value;
            }
        }

        public string BalanceRemaining
        {
            get
            {
                return _dblBalanceRemaining ?? string.Empty;
            }
            set
            {
                _dblBalanceRemaining = value;
            }
        }




        string _strCustItemRefNo = string.Empty;
        string _strCustItemRefFullName = string.Empty;
        string _strCustItemkey = string.Empty;
        string _strCustItemkeyvalue = string.Empty;
        string _strCustChildvalue = string.Empty;
        string _strCustParentvalue = string.Empty;
        string _strItemdesc = string.Empty;

        public string CustItemRefFullName
        {
            get
            {
                return _strCustItemRefFullName;
            }
            set
            {
                _strCustItemRefFullName = value; //.Substring(value.LastIndexOf(':') + 1);
            }
        }

        public string Itemdesc
        {
            get
            {
                return _strItemdesc;
            }
            set
            {
                _strItemdesc = value; //.Substring(value.LastIndexOf(':') + 1);
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

        

      
        public List<clsInvoiceLine> LineItemList { get; set; }
        public List<clsInvoice> LineCustomFieldList { get; set; }
        public clsInvoice()
        {
              LineItemList = new List<clsInvoiceLine>();
            // LineCustomFieldList = new List<clsInvoiceLine.Itemcustomfields>();
            LineCustomFieldList = new List<clsInvoice>();
        }

        public clsInvoice(string refnumber, string itemname,string itemdesc, string keyname, string keyval)
        {
            CustItemRefNumber = refnumber;
            CustItemRefFullName = itemname;
            Itemdesc = itemdesc;
            CustItemkey = keyname;
            CustItemkeyvalue = keyval;
           
        }


        // public List<clsInvoiceLine> clsItemlist { get; set; }
        //public void getinvoiceitem(clsInvoiceLine argValue)
        //{
        //    clsItemlist.Add(argValue);
        //}
        //private List<clsInvoice> _children;
        //public List<clsInvoice> Children
        //{
        //    get { return _children; }
        //    set { _children = value; }
        //}
        //public clsInvoiceLine newlist
        //{
        //    get;set;
        //}
        //  public class Itemcustomfields
        //{
        //    string _strCustItemRefNo = string.Empty;
        //    string _strCustItemRefFullName = string.Empty;
        //    string _strCustItemkey = string.Empty;
        //    string _strCustItemkeyvalue = string.Empty;
        //    string _strCustChildvalue = string.Empty;
        //    string _strCustParentvalue = string.Empty;

        //    public string CustItemRefFullName
        //    {
        //        get
        //        {
        //            return _strCustItemRefFullName;
        //        }
        //        set
        //        {
        //            _strCustItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
        //        }
        //    }

        //    public string CustItemRefNumber
        //    {
        //        get
        //        {
        //            return _strCustItemRefNo;
        //        }
        //        set
        //        {
        //            _strCustItemRefNo = value;
        //        }
        //    }

        //    public string CustItemkey
        //    {
        //        get
        //        {
        //            return _strCustItemkey;
        //        }
        //        set
        //        {
        //            _strCustItemkey = value;
        //        }
        //    }

        //    public string CustItemkeyvalue
        //    {
        //        get
        //        {
        //            return _strCustItemkeyvalue;
        //        }
        //        set
        //        {
        //            _strCustItemkeyvalue = value;
        //        }
        //    }


        //    public string CustChild
        //    {
        //        get
        //        {
        //            return _strCustChildvalue;
        //        }
        //        set
        //        {
        //            _strCustChildvalue = value;
        //        }
        //    }
        //    public string CustParent
        //    {
        //        get
        //        {
        //            return _strCustParentvalue;
        //        }
        //        set
        //        {
        //            _strCustParentvalue = value;
        //        }
        //    }


        //    public Itemcustomfields(string refnumber, string itemname, string keyname, string keyval)
        //    {
        //        CustItemRefNumber = refnumber;
        //        CustItemRefFullName = itemname;
        //        CustItemkey = keyname;
        //        CustItemkeyvalue = keyval;
        //    }
        //    public Itemcustomfields(string refnumber, string childcustomer,string parentcustomer, string keyname, string keyval)
        //    {
        //        CustItemRefNumber = refnumber;
        //        CustChild = childcustomer;
        //        CustParent = parentcustomer;
        //        CustItemkey = keyname;
        //        CustItemkeyvalue = keyval;
        //    }

        //};



        //method for mulitple invoice packaging option
        public ArrayList GetFilteredInvoices(string pInvfromdate, string pInvtodate)
        {

            ArrayList alInvoices = new ArrayList(); 
           
           clsInvoice lobjclsInvoiceLine = null;
           
            string InvCustomCustomerFieldName = string.Empty;
            string InvCustomCustomerFieldValue = string.Empty;
            Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
           // List<clsInvoiceLine.Itemcustomfields> listinvcustlist = new List<clsInvoiceLine.Itemcustomfields>();
            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
             
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();


                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));

               // InvoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.FullNameWithChildren.SetValue("Abercrombie, Kristy");

                InvoiceQuery.IncludeLinkedTxns.SetValue(true);
                InvoiceQuery.IncludeLineItems.SetValue(true);
                //Get customer custom field
                //ICustomerQuery CustomerQueryRq = default(ICustomerQuery);
                //CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

                //CustomerQueryRq.OwnerIDList.Add("0");
                //CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                


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
                    IResponseList responseList = lMsgResponse.ResponseList;
                   // pobjInvcustlist = listinvcustlist;
                    if (responseList == null) return null;

                    //IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    //IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    // IInvoiceRet loInvoice = default(IInvoiceRet);

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

                                if (responseType == ENResponseType.rtInvoiceQueryRs)
                                {
                                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                                    IInvoiceRet loInvoice = default(IInvoiceRet);

                                    if (loList != null)
                                    {
                                        for (int Index = 0; Index < loList.Count; Index++)
                                        {
                                            lobjclsInvoiceLine = new clsInvoice();
                                            loInvoice = loList.GetAt(Index);
                                            lobjclsInvoiceLine.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
                                            lobjclsInvoiceLine.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
                                            lobjclsInvoiceLine.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                                            if (lobjclsInvoiceLine.ShipDate != null) Convert.ToString(loInvoice.ShipDate.GetValue());
                                            if (loInvoice.BillAddress != null)
                                            {
                                                if (loInvoice.BillAddress.Addr1 != null)
                                                    lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());

                                                //if (loInvoice.BillAddress.Addr2 != null)
                                                //    lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                                //if (loInvoice.BillAddress.Addr3 != null)
                                                //    lobjclsInvoiceLine.BillAddressAddr3 = Convert.ToString(loInvoice.BillAddress.Addr3.GetValue());

                                                //if (loInvoice.BillAddress.Addr4 != null)
                                                //    lobjclsInvoiceLine.BillAddressAddr4 = Convert.ToString(loInvoice.BillAddress.Addr4.GetValue());

                                                //if (loInvoice.BillAddress.Addr5 != null)
                                                //    lobjclsInvoiceLine.BillAddressAddr5 = Convert.ToString(loInvoice.BillAddress.Addr5.GetValue());

                                                //if (loInvoice.BillAddress.City != null)
                                                //    lobjclsInvoiceLine.BillAddressCity = Convert.ToString(loInvoice.BillAddress.City.GetValue());

                                                //if (loInvoice.BillAddress.State != null)
                                                //    lobjclsInvoiceLine.BillAddressState = Convert.ToString(loInvoice.BillAddress.State.GetValue());

                                                //if (loInvoice.BillAddress.PostalCode != null)
                                                //    lobjclsInvoiceLine.BillAddressPostalCode = Convert.ToString(loInvoice.BillAddress.PostalCode.GetValue());

                                                //if (loInvoice.BillAddress.Country != null)
                                                //    lobjclsInvoiceLine.BillAddressCountry = Convert.ToString(loInvoice.BillAddress.Country.GetValue());

                                            }
                                            ////To add shipAddressBlock

                                            if (loInvoice.ShipAddress != null)
                                            {
                                                if (loInvoice.ShipAddress.Addr1 != null)
                                                    lobjclsInvoiceLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());

                                                //if (loInvoice.ShipAddress.Addr2 != null)
                                                //    lobjclsInvoiceLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());

                                                //if (loInvoice.ShipAddress.Addr3 != null)
                                                //    lobjclsInvoiceLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());

                                                //if (loInvoice.ShipAddress.Addr4 != null)
                                                //    lobjclsInvoiceLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());

                                                //if (loInvoice.ShipAddress.Addr5 != null)
                                                //    lobjclsInvoiceLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());

                                                //if (loInvoice.ShipAddress.City != null)
                                                //    lobjclsInvoiceLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                                //if (loInvoice.ShipAddress.State != null)
                                                //    lobjclsInvoiceLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());

                                                //if (loInvoice.ShipAddress.PostalCode != null)
                                                //    lobjclsInvoiceLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());

                                                //if (loInvoice.ShipAddress.Country != null)
                                                //    lobjclsInvoiceLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                                //if (loInvoice.Other != null)
                                                //    lobjclsInvoiceLine._strCustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());
                                                //if (loInvoice.ShipDate != null)
                                                //    lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());


                                            }
                                            if (loInvoice.FOB != null)
                                            {
                                                lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                            }

                                            //Get Customer Name from invoice:16-Jun-2019
                                            if (loInvoice.CustomerRef != null)
                                            {
                                                if (loInvoice.CustomerRef.FullName != null)
                                                {
                                                    lobjclsInvoiceLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
                                                    //get parent customers
                                                   // listinvcustlist.Add(new clsInvoiceLine.Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.CustomerRefFullName, "", "", ""));
                                                }

                                            }

                                            //add column sales tax total and balanceonremaining
                                            //if (loInvoice.SalesTaxTotal != null)

                                            //    lobjclsInvoiceLine._dblSalesTaxTotal = string.Format("{0:N}", loInvoice.SalesTaxTotal.GetValue());
                                            //if (loInvoice.BalanceRemaining != null)
                                            //    lobjclsInvoiceLine._dblBalanceRemaining = string.Format("{0:N}", loInvoice.BalanceRemaining.GetValue());

                                            //if (loInvoice.PONumber != null)
                                            //    lobjclsInvoiceLine._strPONumber = Convert.ToString(loInvoice.PONumber.GetValue());


                                            //To show S.O.No for invoice
                                            //if (loInvoice.LinkedTxnList != null)
                                            //{
                                            //    if (loInvoice.LinkedTxnList.Count > 1)
                                            //        lobjclsInvoiceLine.LinkTxnRefNumber = "Multiple";
                                            //    else
                                            //    {
                                            //        for (int invtrans = 0; invtrans < loInvoice.LinkedTxnList.Count; invtrans++)
                                            //        {
                                            //            ILinkedTxn LinkTxn = loInvoice.LinkedTxnList.GetAt(invtrans);
                                            //            if (LinkTxn.RefNumber != null)
                                            //                lobjclsInvoiceLine.LinkTxnRefNumber = LinkTxn.RefNumber.GetValue();

                                            //        }
                                            //    }

                                            //}

                                            alInvoices.Add(lobjclsInvoiceLine);
                                        }
                                    }
                                }// responselist

                              //else if (responseType == ENResponseType.rtCustomerQueryRs)
                              //  {
                              //      ICustomerRetList locustomercustomfieldList = (ICustomerRetList)loResponse.Detail;
                              //      ICustomerRet loCustomerField = default(ICustomerRet);

                              //      if (locustomercustomfieldList != null)
                              //      {
                              //          for (int Index = 0; Index < locustomercustomfieldList.Count; Index++)
                              //          {
                              //              lobjclsInvoiceLine = new clsInvoice();
                              //              loCustomerField = locustomercustomfieldList.GetAt(Index);

                              //              if(loCustomerField.DataExtRetList !=null)
                              //              {

                              //                  for (int invItem = 0; invItem < loCustomerField.DataExtRetList.Count; invItem++)
                              //                  {
                              //                      IDataExtRet DataExtRet = loCustomerField.DataExtRetList.GetAt(invItem);

                              //                      //Get value of DataExtName
                              //                      InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                              //                      //Get value of DataExtValue
                              //                      InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue();
                              //                      if (!lobjCustomerCustomFieldExtensions.ContainsKey(InvCustomCustomerFieldName))
                              //                          lobjCustomerCustomFieldExtensions.Add(InvCustomCustomerFieldName, InvCustomCustomerFieldValue);
                              //                  }

                              //              }

                              //          }
                              //      }
                              //  }



                                        }
                        }
                    }
                }
               // pobjInvcustlist = listinvcustlist;
                return alInvoices;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }

        }
        //Get invoices list for matched customer
        //public ArrayList GetInvoicesForMatchCustomer(string pInvfromdate, string pInvtodate, string pstrmatchcustomer, List<clsInvoiceLine.Itemcustomfields> pbojfilterinvcustomerlist)
        //{

        //    ArrayList alInvoices = new ArrayList();
        //    string InvCustomCustomerFieldName = string.Empty;
        //    string InvCustomCustomerFieldValue = string.Empty;
        //    Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
        //    //List<clsInvoiceLine.Itemcustomfields> listinvcustlist = new List<clsInvoiceLine.Itemcustomfields>();
        //    foreach (var customername in pbojfilterinvcustomerlist)
        //    {

        //        clsInvoice lobjclsInvoiceLine = null;

        //    //step2: create QBFC session manager and prepare the request
        //    QBSessionManager lQBSessionManager = null;
        //    IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

        //    try
        //    {
        //        lQBSessionManager = ModGlobal.QBGlobalSessionManager;

        //        IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
        //        lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


        //        IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
        //        InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();


        //        InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
        //        InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));

        //        InvoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.FullNameWithChildren.SetValue(customername.CustParent.ToString());
        //        //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.FullNameWithChildren.SetValue(pstrmatchcustomer);

        //        InvoiceQuery.IncludeLinkedTxns.SetValue(true);
        //        InvoiceQuery.IncludeLineItems.SetValue(true);
        //        //Get customer custom field
        //        //ICustomerQuery CustomerQueryRq = default(ICustomerQuery);
        //        //CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

        //        //CustomerQueryRq.OwnerIDList.Add("0");
        //        //CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);



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
        //    try
        //    {
        //        if ((lMsgResponse.ResponseList.Count > 0))
        //        {
        //            //we have one response for  single add request
        //            IResponseList responseList = lMsgResponse.ResponseList;
        //            //pobjInvcustlist = listinvcustlist;
        //            if (responseList == null) return null;

        //            //IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
        //            //IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
        //            // IInvoiceRet loInvoice = default(IInvoiceRet);

        //            for (int i = 0; i < responseList.Count; i++)
        //            {
        //                IResponse loResponse = responseList.GetAt(i);
        //                //check the status code of the response, 0=ok, >0 is warning
        //                if (loResponse.StatusCode >= 0)
        //                {
        //                    //the request-specific response is in the details, make sure we have some
        //                    if (loResponse.Detail != null)
        //                    {
        //                        //make sure the response is the type we're expecting
        //                        ENResponseType responseType = (ENResponseType)loResponse.Type.GetValue();

        //                        if (responseType == ENResponseType.rtInvoiceQueryRs)
        //                        {
        //                            IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
        //                            IInvoiceRet loInvoice = default(IInvoiceRet);

        //                            if (loList != null)
        //                            {
        //                                for (int Index = 0; Index < loList.Count; Index++)
        //                                {
        //                                    lobjclsInvoiceLine = new clsInvoice();
        //                                    loInvoice = loList.GetAt(Index);
        //                                    lobjclsInvoiceLine.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
        //                                    lobjclsInvoiceLine.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
        //                                    lobjclsInvoiceLine.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());

        //                                    if (lobjclsInvoiceLine.ShipDate != null) Convert.ToString(loInvoice.ShipDate.GetValue());
        //                                    if (loInvoice.BillAddress != null)
        //                                    {
        //                                        if (loInvoice.BillAddress.Addr1 != null)
        //                                            lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());

        //                                        //if (loInvoice.BillAddress.Addr2 != null)
        //                                        //    lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

        //                                        //if (loInvoice.BillAddress.Addr3 != null)
        //                                        //    lobjclsInvoiceLine.BillAddressAddr3 = Convert.ToString(loInvoice.BillAddress.Addr3.GetValue());

        //                                        //if (loInvoice.BillAddress.Addr4 != null)
        //                                        //    lobjclsInvoiceLine.BillAddressAddr4 = Convert.ToString(loInvoice.BillAddress.Addr4.GetValue());

        //                                        //if (loInvoice.BillAddress.Addr5 != null)
        //                                        //    lobjclsInvoiceLine.BillAddressAddr5 = Convert.ToString(loInvoice.BillAddress.Addr5.GetValue());

        //                                        //if (loInvoice.BillAddress.City != null)
        //                                        //    lobjclsInvoiceLine.BillAddressCity = Convert.ToString(loInvoice.BillAddress.City.GetValue());

        //                                        //if (loInvoice.BillAddress.State != null)
        //                                        //    lobjclsInvoiceLine.BillAddressState = Convert.ToString(loInvoice.BillAddress.State.GetValue());

        //                                        //if (loInvoice.BillAddress.PostalCode != null)
        //                                        //    lobjclsInvoiceLine.BillAddressPostalCode = Convert.ToString(loInvoice.BillAddress.PostalCode.GetValue());

        //                                        //if (loInvoice.BillAddress.Country != null)
        //                                        //    lobjclsInvoiceLine.BillAddressCountry = Convert.ToString(loInvoice.BillAddress.Country.GetValue());

        //                                    }
        //                                    ////To add shipAddressBlock

        //                                    if (loInvoice.ShipAddress != null)
        //                                    {
        //                                        if (loInvoice.ShipAddress.Addr1 != null)
        //                                            lobjclsInvoiceLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());

        //                                        //if (loInvoice.ShipAddress.Addr2 != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());

        //                                        //if (loInvoice.ShipAddress.Addr3 != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());

        //                                        //if (loInvoice.ShipAddress.Addr4 != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());

        //                                        //if (loInvoice.ShipAddress.Addr5 != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());

        //                                        //if (loInvoice.ShipAddress.City != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

        //                                        //if (loInvoice.ShipAddress.State != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());

        //                                        //if (loInvoice.ShipAddress.PostalCode != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());

        //                                        //if (loInvoice.ShipAddress.Country != null)
        //                                        //    lobjclsInvoiceLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
        //                                        //if (loInvoice.Other != null)
        //                                        //    lobjclsInvoiceLine._strCustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());
        //                                        //if (loInvoice.ShipDate != null)
        //                                        //    lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());


        //                                    }
        //                                    if (loInvoice.FOB != null)
        //                                    {
        //                                        lobjclsInvoiceLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
        //                                    }

        //                                    //Get Customer Name from invoice:16-Jun-2019
        //                                    if (loInvoice.CustomerRef != null)
        //                                    {
        //                                        if (loInvoice.CustomerRef.FullName != null)
        //                                        {
        //                                            lobjclsInvoiceLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
        //                                            //get parent customers
        //                                            //listinvcustlist.Add(new clsInvoiceLine.Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.CustomerRefFullName, "", "", ""));
        //                                        }

        //                                    }

        //                                        //add column sales tax total and balanceonremaining
        //                                        //if (loInvoice.SalesTaxTotal != null)

        //                                        //    lobjclsInvoiceLine._dblSalesTaxTotal = string.Format("{0:N}", loInvoice.SalesTaxTotal.GetValue());
        //                                        //if (loInvoice.BalanceRemaining != null)
        //                                        //    lobjclsInvoiceLine._dblBalanceRemaining = string.Format("{0:N}", loInvoice.BalanceRemaining.GetValue());

        //                                        //if (loInvoice.PONumber != null)
        //                                        //    lobjclsInvoiceLine._strPONumber = Convert.ToString(loInvoice.PONumber.GetValue());


        //                                        //To show S.O.No for invoice
        //                                        //if (loInvoice.LinkedTxnList != null)
        //                                        //{
        //                                        //    if (loInvoice.LinkedTxnList.Count > 1)
        //                                        //        lobjclsInvoiceLine.LinkTxnRefNumber = "Multiple";
        //                                        //    else
        //                                        //    {
        //                                        //        for (int invtrans = 0; invtrans < loInvoice.LinkedTxnList.Count; invtrans++)
        //                                        //        {
        //                                        //            ILinkedTxn LinkTxn = loInvoice.LinkedTxnList.GetAt(invtrans);
        //                                        //            if (LinkTxn.RefNumber != null)
        //                                        //                lobjclsInvoiceLine.LinkTxnRefNumber = LinkTxn.RefNumber.GetValue();

        //                                        //        }
        //                                        //    }

        //                                        //}

        //                                        if (!alInvoices.Cast<QBLC.clsInvoice>().ToList().Any(p => p.RefNumber == lobjclsInvoiceLine.RefNumber))
        //                                        {

        //                                            alInvoices.Add(lobjclsInvoiceLine);
        //                                        }
        //                                }
        //                            }
        //                        }// responselist

        //                        //else if (responseType == ENResponseType.rtCustomerQueryRs)
        //                        //  {
        //                        //      ICustomerRetList locustomercustomfieldList = (ICustomerRetList)loResponse.Detail;
        //                        //      ICustomerRet loCustomerField = default(ICustomerRet);

        //                        //      if (locustomercustomfieldList != null)
        //                        //      {
        //                        //          for (int Index = 0; Index < locustomercustomfieldList.Count; Index++)
        //                        //          {
        //                        //              lobjclsInvoiceLine = new clsInvoice();
        //                        //              loCustomerField = locustomercustomfieldList.GetAt(Index);

        //                        //              if(loCustomerField.DataExtRetList !=null)
        //                        //              {

        //                        //                  for (int invItem = 0; invItem < loCustomerField.DataExtRetList.Count; invItem++)
        //                        //                  {
        //                        //                      IDataExtRet DataExtRet = loCustomerField.DataExtRetList.GetAt(invItem);

        //                        //                      //Get value of DataExtName
        //                        //                      InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

        //                        //                      //Get value of DataExtValue
        //                        //                      InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue();
        //                        //                      if (!lobjCustomerCustomFieldExtensions.ContainsKey(InvCustomCustomerFieldName))
        //                        //                          lobjCustomerCustomFieldExtensions.Add(InvCustomCustomerFieldName, InvCustomCustomerFieldValue);
        //                        //                  }

        //                        //              }

        //                        //          }
        //                        //      }
        //                        //  }



        //                    }
        //                }
        //            }
        //        }
        //       // pobjInvcustlist = listinvcustlist;
        //       // return alInvoices;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw;
        //        return null;
        //    }


        //    }//customerlist loop end
        //   // pobjInvcustlist = listinvcustlist;
        //    return alInvoices;
        //}//end


        //Get custom field for selected invoice

        public ArrayList GetInvoicesForMatchCustomer(string pInvfromdate, string pInvtodate, string pstritemcustomfieldvalue,bool isdefalutqtyoption, List<clsInvoiceLine.Itemcustomfields> pbojfilterinvcustomerlist)
        {

            ArrayList alInvoices = new ArrayList();
            string InvCustomCustomerFieldName = string.Empty;
            string InvCustomCustomerFieldValue = string.Empty;
           // bool isdefalutqtyoption=false;
            string strdName = string.Empty;
            string strdValue = string.Empty;
            string printlblvalue = string.Empty;
            bool ispackernoexist = false;
            bool isprintlabelyes = false;

            Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
            //List<clsInvoiceLine.Itemcustomfields> listinvcustlist = new List<clsInvoiceLine.Itemcustomfields>();
            foreach (var customername in pbojfilterinvcustomerlist)
            {

                clsInvoice lobjclsInvoice = null;
                clsInvoiceLine lobjclsInvoiceLine = null;
                clsInvoice lobjcustomfieldlist = null;
                //step2: create QBFC session manager and prepare the request
                QBSessionManager lQBSessionManager = null;
                IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

                try
                {
                    lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                    IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                    lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                    IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                    InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();


                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));

                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.FullNameWithChildren.SetValue(customername.CustParent.ToString());
                    //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.FullNameWithChildren.SetValue(pstrmatchcustomer);

                    InvoiceQuery.IncludeLinkedTxns.SetValue(true);
                    InvoiceQuery.IncludeLineItems.SetValue(true);
                    //Get customer custom field
                    //ICustomerQuery CustomerQueryRq = default(ICustomerQuery);
                    //CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

                    //CustomerQueryRq.OwnerIDList.Add("0");
                    //CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);



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
                        IResponseList responseList = lMsgResponse.ResponseList;
                        IInvoiceLineRet loInvoiceLineRetItem = null;
                        //pobjInvcustlist = listinvcustlist;
                        if (responseList == null) return null;

                        //IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                        //IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                        // IInvoiceRet loInvoice = default(IInvoiceRet);

                        IItemQuery lobjIItemQuery = null;
                        IResponse lobjIResponse;
                        ENObjectType lobjResponseDetailType;
                        IORItemRetList lobjIORItemRetList;
                        ENResponseType lobjResponseType;

                        IORItemRet lobjIORItemRet;
                        IMsgSetResponse lobjIMsgSetResponse;
                        lobjIItemQuery = default(IItemQuery);
                        IDataExtRetList lobjIDataExtRetList;

                        for (int i = 0; i < responseList.Count; i++)
                        {
                            IResponse loResponse = responseList.GetAt(i);

                            
                            IMsgSetRequest lMsgItemsRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                            lMsgItemsRequest.Attributes.OnError = ENRqOnError.roeContinue;

                            //check the status code of the response, 0=ok, >0 is warning
                            if (loResponse.StatusCode >= 0)
                            {
                                //the request-specific response is in the details, make sure we have some
                                if (loResponse.Detail != null)
                                {
                                    //make sure the response is the type we're expecting
                                    ENResponseType responseType = (ENResponseType)loResponse.Type.GetValue();

                                    if (responseType == ENResponseType.rtInvoiceQueryRs)
                                    {
                                        IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                                        IInvoiceRet loInvoice = default(IInvoiceRet);

                                        if (loList != null)
                                        {
                                            for (int Index = 0; Index < loList.Count; Index++)
                                            {
                                                lobjclsInvoice = new clsInvoice();
                                                lobjclsInvoiceLine = new clsInvoiceLine();
                                               

                                                loInvoice = loList.GetAt(Index);
                                                for (int intLine = 0; intLine < loInvoice.ORInvoiceLineRetList.Count; intLine++) //getting line items loop
                                                {
                                                    if (loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet != null)
                                                    {
                                                        loInvoiceLineRetItem = loInvoice.ORInvoiceLineRetList.GetAt(intLine).InvoiceLineRet;
                                                        lobjclsInvoiceLine = GetDateRangeInvoiceItems(loInvoiceLineRetItem, isdefalutqtyoption, loInvoice.RefNumber.GetValue().ToString(),loInvoice);
                                                        if (lobjclsInvoiceLine.InvoiceLineItemRefFullName == "" || lobjclsInvoiceLine.InvoiceLineQuantity == 0)
                                                        {
                                                            continue;
                                                        }
                                                       // lobjclsInvoice.LineItemList.Add(lobjclsInvoiceLine); // add line item one by one

                                                        //lobjclsInvoice.getinvoiceitem(lobjclsInvoiceLine);

                                                        //-----------------------------------------To get Custom Fields ------------------------------------
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
                                                                        for (int p = 0; p < lobjIORItemRetList.Count; p++)
                                                                        {
                                                                            lobjIORItemRet = lobjIORItemRetList.GetAt(p);
                                                                            if (lobjIORItemRet != null && lobjIORItemRet.ItemInventoryAssemblyRet != null && lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList != null)
                                                                            {
                                                                                ispackernoexist = false;
                                                                                isprintlabelyes = false;
                                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryAssemblyRet.DataExtRetList;
                                                                                if (lobjIDataExtRetList != null)
                                                                                {
                                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                                    {
                                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty);
                                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                        if (strdName == pstritemcustomfieldvalue) //check if item custom field value matched with quickbooks column
                                                                                        {
                                                                                            ispackernoexist = true;

                                                                                        }
                                                                                        else if (strdName.Trim() == "PRINTLABEL" && strdValue.ToUpper().Trim() == "YES")
                                                                                        {
                                                                                            isprintlabelyes = true;
                                                                                        }
                                                                                        lobjcustomfieldlist = new clsInvoice(Convert.ToString(loInvoice.RefNumber.GetValue()), lobjclsInvoiceLine.InvoiceItemName, lobjclsInvoiceLine.InvoiceLineDesc, strdName, strdValue);
                                                                                        // store custom fields to list

                                                                                        lobjclsInvoice.LineCustomFieldList.Add(lobjcustomfieldlist);
                                                                                        
                                                                                    }
                                                                                }
                                                                            }
                                                                            else if (lobjIORItemRet.ItemInventoryRet != null)
                                                                            {
                                                                                ispackernoexist = false;
                                                                                isprintlabelyes = false;
                                                                                lobjIDataExtRetList = lobjIORItemRet.ItemInventoryRet.DataExtRetList;
                                                                                if (lobjIDataExtRetList != null)
                                                                                {
                                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                                    {
                                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                        if (strdName == pstritemcustomfieldvalue) //check if item custom field value matched with quickbooks column
                                                                                        {
                                                                                            ispackernoexist = true;

                                                                                        }
                                                                                        else if (strdName.Trim() == "PRINTLABEL" && strdValue.ToUpper().Trim() == "YES")
                                                                                        {
                                                                                            isprintlabelyes = true;
                                                                                        }
                                                                                        lobjcustomfieldlist = new clsInvoice(Convert.ToString(loInvoice.RefNumber.GetValue()), lobjclsInvoiceLine.InvoiceItemName, lobjclsInvoiceLine.InvoiceLineDesc, strdName, strdValue);
                                                                                        // store custom fields to list

                                                                                        lobjclsInvoice.LineCustomFieldList.Add(lobjcustomfieldlist);

                                                                                    }
                                                                                }


                                                                            }
                                                                            //Add non inventory Item custom field from items
                                                                            else if (lobjIORItemRet.ItemNonInventoryRet != null)
                                                                            {
                                                                                ispackernoexist = false;
                                                                                isprintlabelyes = false;
                                                                                lobjIDataExtRetList = lobjIORItemRet.ItemNonInventoryRet.DataExtRetList;
                                                                                if (lobjIDataExtRetList != null)
                                                                                {
                                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                                    {
                                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                        if (strdName == pstritemcustomfieldvalue) //check if item custom field value matched with quickbooks column
                                                                                        {
                                                                                            ispackernoexist = true;

                                                                                        }
                                                                                        else if (strdName.Trim() == "PRINTLABEL" && strdValue.ToUpper().Trim() == "YES")
                                                                                        {
                                                                                            isprintlabelyes = true;
                                                                                        }
                                                                                        lobjcustomfieldlist = new clsInvoice(Convert.ToString(loInvoice.RefNumber.GetValue()), lobjclsInvoiceLine.InvoiceItemName, lobjclsInvoiceLine.InvoiceLineDesc, strdName, strdValue);
                                                                                        // store custom fields to list

                                                                                        lobjclsInvoice.LineCustomFieldList.Add(lobjcustomfieldlist);
                                                                                    }
                                                                                }

                                                                            }
                                                                            //support service item:Date 16-July-2019
                                                                            else if (lobjIORItemRet.ItemServiceRet != null)
                                                                            {
                                                                                 ispackernoexist = false;
                                                                                 isprintlabelyes = false;
                                                                                lobjIDataExtRetList = lobjIORItemRet.ItemServiceRet.DataExtRetList;
                                                                                if (lobjIDataExtRetList != null)
                                                                                {
                                                                                    for (int j = 0; j < lobjIDataExtRetList.Count; j++)
                                                                                    {
                                                                                        strdName = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtName.GetValue()).Replace(" ", string.Empty).ToUpper();
                                                                                        strdValue = Convert.ToString(lobjIDataExtRetList.GetAt(j).DataExtValue.GetValue());
                                                                                        if (strdName == pstritemcustomfieldvalue) //check if item custom field value matched with quickbooks column
                                                                                        {
                                                                                            ispackernoexist = true;

                                                                                        }
                                                                                        else if(strdName.Trim() == "PRINTLABEL" && strdValue.ToUpper().Trim()=="YES")
                                                                                        {
                                                                                            isprintlabelyes = true;
                                                                                        }
                                                                                        lobjcustomfieldlist = new clsInvoice(Convert.ToString(loInvoice.RefNumber.GetValue()), lobjclsInvoiceLine.InvoiceItemName, lobjclsInvoiceLine.InvoiceLineDesc, strdName, strdValue);
                                                                                        // store custom fields to list
                                                                                       
                                                                                        lobjclsInvoice.LineCustomFieldList.Add(lobjcustomfieldlist);
                                                                                    }
                                                                                    //Add item to list if it has packerwarehouse no and print label set to yes
                                                                                    ///check if packerno item custom field exist and print label field has vaulue yes then get item
                                                                                    //if(ispackernoexist==true && isprintlabelyes==true)
                                                                                    //{
                                                                                    //    lobjclsInvoice.LineItemList.Add(lobjclsInvoiceLine); // add line item to list
                                                                                    //}
                                                                                                                                                                        
                                                                                }

                                                                            }

                                                                            if (ispackernoexist == true && isprintlabelyes == true)
                                                                            {
                                                                                lobjclsInvoice.LineItemList.Add(lobjclsInvoiceLine); // add line item to list
                                                                            }

                                                                        } //end for
                                                                    }
                                                                }
                                                            }
                                                        }





                                                    }//#1
                                              }//#2

                                                lobjclsInvoice.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
                                                lobjclsInvoice.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
                                                lobjclsInvoice.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());

                                                if (lobjclsInvoice.ShipDate != null) Convert.ToString(loInvoice.ShipDate.GetValue());
                                                if (loInvoice.BillAddress != null)
                                                {
                                                    if (loInvoice.BillAddress.Addr1 != null)
                                                        lobjclsInvoice.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                                                    if (loInvoice.BillAddress.Addr2 != null)
                                                        lobjclsInvoice.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                                }


                                                if (loInvoice.PONumber != null)
                                                {
                                                    lobjclsInvoice.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                                                }

                                                //To add shipAddressBlock
                                                if (loInvoice.ShipAddress != null)
                                                {
                                                    if (loInvoice.ShipAddress.Addr1 != null) lobjclsInvoice.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());
                                                    if (loInvoice.ShipAddress.Addr2 != null) lobjclsInvoice.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());
                                                    if (loInvoice.ShipAddress.Addr3 != null) lobjclsInvoice.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());
                                                    if (loInvoice.ShipAddress.Addr4 != null) lobjclsInvoice.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());
                                                    if (loInvoice.ShipAddress.Addr5 != null) lobjclsInvoice.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());
                                                    if (loInvoice.ShipAddress.City != null) lobjclsInvoice.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                                    if (loInvoice.ShipAddress.State != null) lobjclsInvoice.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());
                                                    if (loInvoice.ShipAddress.PostalCode != null) lobjclsInvoice.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());
                                                    if (loInvoice.ShipAddress.Country != null) lobjclsInvoice.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                                    if (loInvoice.ShipMethodRef != null) lobjclsInvoice.ShipAddressMethod = Convert.ToString(loInvoice.ShipMethodRef.FullName.GetValue());
                                                    if (loInvoice.ShipDate != null) lobjclsInvoice.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());
                                                    //citystatezip field added:Date 30-APR-2019
                                                    if (!string.IsNullOrWhiteSpace(lobjclsInvoice.ShipAddressCity) || !string.IsNullOrWhiteSpace(lobjclsInvoice.ShipAddressState) || !string.IsNullOrWhiteSpace(lobjclsInvoice.ShipAddressPostalCode))
                                                    {
                                                        lobjclsInvoice.citystatezip += lobjclsInvoice.ShipAddressCity + " " + lobjclsInvoice.ShipAddressState + " " + lobjclsInvoice.ShipAddressPostalCode;
                                                    }
                                                }
                                                if (loInvoice.FOB != null)
                                                {
                                                    lobjclsInvoice.FOB = Convert.ToString(loInvoice.FOB.GetValue());
                                                }

                                                //Get Customer Name from invoice:16-Jun-2019
                                                if (loInvoice.CustomerRef != null)
                                                {
                                                    if (loInvoice.CustomerRef.FullName != null)
                                                    {
                                                        lobjclsInvoice.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
                                                        //get parent customers
                                                        //listinvcustlist.Add(new clsInvoiceLine.Itemcustomfields(lobjclsInvoiceLine.RefNumber, lobjclsInvoiceLine.CustomerRefFullName, "", "", ""));
                                                    }

                                                }


                                                //if (!alInvoices.Cast<QBLC.clsInvoice>().ToList().Any(p => p.RefNumber == lobjclsInvoice.RefNumber))
                                                //{

                                                alInvoices.Add(lobjclsInvoice);

                                                //}



                                            }
                                        }
                                    }// responselist

                                    //else if (responseType == ENResponseType.rtCustomerQueryRs)
                                    //  {
                                    //      ICustomerRetList locustomercustomfieldList = (ICustomerRetList)loResponse.Detail;
                                    //      ICustomerRet loCustomerField = default(ICustomerRet);

                                    //      if (locustomercustomfieldList != null)
                                    //      {
                                    //          for (int Index = 0; Index < locustomercustomfieldList.Count; Index++)
                                    //          {
                                    //              lobjclsInvoiceLine = new clsInvoice();
                                    //              loCustomerField = locustomercustomfieldList.GetAt(Index);

                                    //              if(loCustomerField.DataExtRetList !=null)
                                    //              {

                                    //                  for (int invItem = 0; invItem < loCustomerField.DataExtRetList.Count; invItem++)
                                    //                  {
                                    //                      IDataExtRet DataExtRet = loCustomerField.DataExtRetList.GetAt(invItem);

                                    //                      //Get value of DataExtName
                                    //                      InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                    //                      //Get value of DataExtValue
                                    //                      InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue();
                                    //                      if (!lobjCustomerCustomFieldExtensions.ContainsKey(InvCustomCustomerFieldName))
                                    //                          lobjCustomerCustomFieldExtensions.Add(InvCustomCustomerFieldName, InvCustomCustomerFieldValue);
                                    //                  }

                                    //              }

                                    //          }
                                    //      }
                                    //  }



                                }
                            }
                        }
                    }
                    // pobjInvcustlist = listinvcustlist;
                    // return alInvoices;
                }

                catch (Exception ex)
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


            }//customerlist loop end
             // pobjInvcustlist = listinvcustlist;
            return alInvoices;
        }//end

        private clsInvoiceLine GetDateRangeInvoiceItems(IInvoiceLineRet poInvoiceLineRet, bool InvoiceQtyIsDefault, string pstrRefNumber, IInvoiceRet loInvoice)
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
                objINVLine.RefNumber = pstrRefNumber;
                //if (!string.IsNullOrEmpty(autoManualPath) && !string.IsNullOrEmpty(autoManualCheck))
                //{
                //    if (autoManualCheck == "Auto")
                //    {
                //        DirectoryInfo d = new DirectoryInfo(autoManualPath);//Assuming Test is your Folder
                //        FileInfo[] Files = d.GetFiles("*.btw"); //Getting Text files
                //        string str = "";
                //        string com = "";
                //        foreach (FileInfo file in Files)
                //        {
                //            str = file.Name;
                //            com = objINVLine.InvoiceLineItemRefFullName + ".btw";
                //            if (com.ToUpper().Trim() == str.ToUpper().Trim())
                //            {
                //                objINVLine.IsAuto = true;
                //            }
                //        }
                //    }
                //}
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

                      
           

            //Get value of LotNumber from invoice lineitem :Date 02/11/2015
            if (poInvoiceLineRet.ORSerialLotNumber != null)
            {
                if (poInvoiceLineRet.ORSerialLotNumber.LotNumber != null)
                {
                    objINVLine.InvoiceLineLotNumber = Convert.ToString(poInvoiceLineRet.ORSerialLotNumber.LotNumber.GetValue());
                }
            }

            //Get Ship Info

            objINVLine.TxnDate = Convert.ToString(loInvoice.TxnDate.GetValue());

            if (objINVLine.ShipDate != null) Convert.ToString(loInvoice.ShipDate.GetValue());
            if (loInvoice.BillAddress != null)
            {
                if (loInvoice.BillAddress.Addr1 != null)
                    objINVLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                if (loInvoice.BillAddress.Addr2 != null)
                    objINVLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

            }


            if (loInvoice.PONumber != null)
            {
                objINVLine.PONumber = Convert.ToString(loInvoice.PONumber.GetValue());
            }

            //To add shipAddressBlock
            if (loInvoice.ShipAddress != null)
            {
                if (loInvoice.ShipAddress.Addr1 != null) objINVLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());
                if (loInvoice.ShipAddress.Addr2 != null) objINVLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());
                if (loInvoice.ShipAddress.Addr3 != null) objINVLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());
                if (loInvoice.ShipAddress.Addr4 != null) objINVLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());
                if (loInvoice.ShipAddress.Addr5 != null) objINVLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());
                if (loInvoice.ShipAddress.City != null) objINVLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                if (loInvoice.ShipAddress.State != null) objINVLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());
                if (loInvoice.ShipAddress.PostalCode != null) objINVLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());
                if (loInvoice.ShipAddress.Country != null) objINVLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                if (loInvoice.ShipMethodRef != null) objINVLine.ShipAddressMethod = Convert.ToString(loInvoice.ShipMethodRef.FullName.GetValue());
                if (loInvoice.ShipDate != null) objINVLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());
                //citystatezip field added:Date 30-APR-2019
                if (!string.IsNullOrWhiteSpace(objINVLine.ShipAddressCity) || !string.IsNullOrWhiteSpace(objINVLine.ShipAddressState) || !string.IsNullOrWhiteSpace(objINVLine.ShipAddressPostalCode))
                {
                    objINVLine.citystatezip += objINVLine.ShipAddressCity + " " + objINVLine.ShipAddressState + " " + objINVLine.ShipAddressPostalCode;
                }
            }
            if (loInvoice.FOB != null)
            {
                objINVLine.FOB = Convert.ToString(loInvoice.FOB.GetValue());
            }
            if (loInvoice.CustomerRef != null)
            {
                if (loInvoice.CustomerRef.FullName != null)
                {
                    objINVLine.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
                    
                }

            }



            return objINVLine;
        }


        public bool? GetInvoiceFor_CustomFiledList(string lstcustomercustomfields,string customfieldsettingvalue,string routenumbertextboxvalue)
        {
            bool blnresult = false;
            //ArrayList alProductCustomFields = new ArrayList();
            Dictionary<string, string> alProductCustomFields = new Dictionary<string, string>();
            Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
            string CustomNonInvItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string InvCustomItemValue = string.Empty;
            string CustomGroupItemName = string.Empty;
            string InvCustomCustomerFieldName = string.Empty;
            string InvCustomCustomerFieldValue = string.Empty;


            clsItemDetails lobjItemdetails = null;

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
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);


                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lstcustomercustomfields);
                //Set field value for ToName
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lstcustomercustomfields);
                
               

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                blnresult = false;
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
                    //alProductCustomFields.Add("--Select--", "0");
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

                                            loCustomer = loList.GetAt(Index);
                                            
                                            //Get Custom Fields for Inventory Item
                                            if (loCustomer.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loCustomer.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loCustomer.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Replace(" ", string.Empty).ToUpper().Trim();
                                                    //Get value of DataExtValue
                                                    InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue().ToLower();
                                                    if (InvCustomCustomerFieldName == customfieldsettingvalue.ToUpper().Trim())
                                                    {
                                                        if(!string.IsNullOrWhiteSpace(InvCustomCustomerFieldValue))
                                                        {
                                                            if (!string.IsNullOrWhiteSpace(routenumbertextboxvalue))
                                                            {
                                                                //check textbox enter route no value with quickbooks route no custom field value
                                                                if (String.Equals(routenumbertextboxvalue, InvCustomCustomerFieldValue))
                                                                {
                                                                    blnresult = true;
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //return match with customer custom field set in setting page
                                                                blnresult = true;
                                                                break;
                                                            }
                                                        }

                                                    }
                                                    
                                                   // if (!lobjCustomerCustomFieldExtensions.ContainsKey(InvCustomCustomerFieldName))
                                                     //   lobjCustomerCustomFieldExtensions.Add(InvCustomCustomerFieldName, InvCustomCustomerFieldValue);
                                                }
                                            }



                                        }
                                    }


                                }

                            }
                        }
                    }


                }

                return blnresult;
            }
            catch (Exception ex)
            {
                blnresult = false;
                throw;
                // return null;
            }

        }

        //Get All customer and their customs fields
        public List<clsInvoiceLine.Itemcustomfields> GetAllcustomersWithCustomField(string customfieldsettingvalue, string routenumbertextboxvalue)
        {
            //bool blnresult = false;
            //ArrayList alProductCustomFields = new ArrayList();
            Dictionary<string, string> alProductCustomFields = new Dictionary<string, string>();
            Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
            List<clsInvoiceLine.Itemcustomfields> custfieldlist = new List<clsInvoiceLine.Itemcustomfields>();
            string CustomNonInvItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string InvCustomItemValue = string.Empty;
            string CustomGroupItemName = string.Empty;
            string InvCustomCustomerFieldName = string.Empty;
            string InvCustomCustomerFieldValue = string.Empty;
            string CustomerName = string.Empty;


            //clsItemDetails lobjItemdetails = null;

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
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);


               // CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(lstcustomercustomfields);
                //Set field value for ToName
               // CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(lstcustomercustomfields);



                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                //blnresult = false;
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
                    //alProductCustomFields.Add("--Select--", "0");
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

                                            loCustomer = loList.GetAt(Index);
                                            CustomerName = "";
                                            //CustomerName = loCustomer.Name.GetValue();

                                            if (loCustomer.ParentRef != null)
                                            {

                                                //Get value of FullName
                                                if (loCustomer.ParentRef.FullName != null)
                                                {
                                                    CustomerName = (string)loCustomer.ParentRef.FullName.GetValue();
                                                }
                                            }
                                            

                                            //custfieldlist.Add(new clsInvoiceLine.Itemcustomfields("", loCustomer.Name.GetValue().ToString(), CustomerName,"",""));


                                            //Get Custom Fields for Inventory Item
                                            if (loCustomer.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loCustomer.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loCustomer.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Replace(" ", string.Empty).ToUpper().Trim();
                                                    //Get value of DataExtValue
                                                    InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue().ToLower();


                                                    //if (InvCustomCustomerFieldName == customfieldsettingvalue.ToUpper().Trim())
                                                   // {
                                                        //if (!string.IsNullOrWhiteSpace(InvCustomCustomerFieldValue))
                                                       // {
                                                            if (!string.IsNullOrWhiteSpace(CustomerName))
                                                            {
                                                                custfieldlist.Add(new clsInvoiceLine.Itemcustomfields("",  CustomerName + ":" + loCustomer.Name.GetValue().ToString(), "", InvCustomCustomerFieldName, InvCustomCustomerFieldValue));
                                                           }
                                                            else
                                                            {
                                                               custfieldlist.Add(new clsInvoiceLine.Itemcustomfields("",  loCustomer.Name.GetValue().ToString(), "", InvCustomCustomerFieldName, InvCustomCustomerFieldValue));
                                                          }
                                                       // }
                                                   // }
                                                    
                                                    //if (InvCustomCustomerFieldName == customfieldsettingvalue.ToUpper().Trim())
                                                    //{
                                                    //    if (!string.IsNullOrWhiteSpace(InvCustomCustomerFieldValue))
                                                    //    {
                                                    //        if (!string.IsNullOrWhiteSpace(routenumbertextboxvalue))
                                                    //        {
                                                    //            //check textbox enter route no value with quickbooks route no custom field value
                                                    //            if (String.Equals(routenumbertextboxvalue, InvCustomCustomerFieldValue))
                                                    //            {
                                                    //                blnresult = true;
                                                    //                break;
                                                    //            }
                                                    //        }
                                                    //        else
                                                    //        {
                                                    //            //return match with customer custom field set in setting page
                                                    //            blnresult = true;
                                                    //            break;
                                                    //        }
                                                    //    }

                                                    //}


                                                }
                                            }



                                        }
                                    }


                                }

                            }
                        }
                    }


                }
                return custfieldlist;
               // return blnresult;
            }
            catch (Exception ex)
            {
               // blnresult = false;
                throw;
                // return null;
            }

        }
        //Get All Customer custom field with matching route number value
        public List<clsInvoiceLine.Itemcustomfields> GetAllcustomersWithMatchedCustomField(string customfieldsettingvalue, string routenumbertextboxvalue)
        {
                     
            Dictionary<string, string> alProductCustomFields = new Dictionary<string, string>();
            Dictionary<string, string> lobjCustomerCustomFieldExtensions = new Dictionary<string, string>();
            List<clsInvoiceLine.Itemcustomfields> custfieldlist = new List<clsInvoiceLine.Itemcustomfields>();
            string CustomNonInvItemName = string.Empty;
            string InvCustomItemName = string.Empty;
            string InvCustomItemValue = string.Empty;
            string CustomGroupItemName = string.Empty;
            string InvCustomCustomerFieldName = string.Empty;
            string InvCustomCustomerFieldValue = string.Empty;
            string CustomerName = string.Empty;
            
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
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
                //blnresult = false;
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
                    //alProductCustomFields.Add("--Select--", "0");
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

                                            loCustomer = loList.GetAt(Index);
                                            CustomerName = "";
                                           
                                            if (loCustomer.ParentRef != null)
                                            {

                                                //Get value of FullName
                                                if (loCustomer.ParentRef.FullName != null)
                                                {
                                                    CustomerName = (string)loCustomer.ParentRef.FullName.GetValue();
                                                }
                                            }
                                            
                                            //Get Custom Fields for Inventory Item
                                            if (loCustomer.DataExtRetList != null)
                                            {
                                                for (int invItem = 0; invItem < loCustomer.DataExtRetList.Count; invItem++)
                                                {
                                                    IDataExtRet DataExtRet = loCustomer.DataExtRetList.GetAt(invItem);

                                                    //Get value of DataExtName
                                                    InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Replace(" ", string.Empty).ToUpper().Trim();
                                                    //Get value of DataExtValue
                                                    InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue().ToLower();
                                                    
                                                   
                                                    if (InvCustomCustomerFieldName == customfieldsettingvalue.Replace(" ", string.Empty).ToUpper().Trim())
                                                    {
                                                        //if (!string.IsNullOrWhiteSpace(InvCustomCustomerFieldValue))
                                                       // {
                                                            //if (!string.IsNullOrWhiteSpace(routenumbertextboxvalue))
                                                            //{
                                                                //check textbox enter route no value with quickbooks route no custom field value
                                                                if (String.Equals(routenumbertextboxvalue, InvCustomCustomerFieldValue))
                                                                {
                                                                    if (!string.IsNullOrWhiteSpace(CustomerName))
                                                                    {
                                                                        custfieldlist.Add(new clsInvoiceLine.Itemcustomfields("", "", CustomerName + ":" + loCustomer.Name.GetValue().ToString(), "", ""));
                                                                    }
                                                                    else
                                                                    {
                                                                        custfieldlist.Add(new clsInvoiceLine.Itemcustomfields("", "", loCustomer.Name.GetValue().ToString(), "", ""));
                                                                    }

                                                                }
                                                            //}
                                                        //}
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
                return custfieldlist;
               
            }
            catch (Exception ex)
            {
                // blnresult = false;
                throw;
                // return null;
            }

        }


        public ArrayList GetInvoiceList(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alInvoices = new ArrayList();
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
            try
            {
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();
                
                if (strRefNumber != "1=1")
                {
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    InvoiceQuery.IncludeLinkedTxns.SetValue(true);
                }
                lMsgResponse = pobjQBSessionManager.DoRequests(lMsgRequest);
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
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            this.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
                            this.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
                            this.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                            if (loInvoice.BillAddress != null)
                                this.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                            else
                                this.BillAddressAddr1 = "";
                            //To add shipAddressBlock

                            if (loInvoice.ShipAddress != null)
                            {
                                if (loInvoice.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());

                                if (loInvoice.ShipAddress.Addr2 != null)
                                    this.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());

                                if (loInvoice.ShipAddress.Addr3 != null)
                                    this.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());

                                if (loInvoice.ShipAddress.Addr4 != null)
                                    this.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());

                                if (loInvoice.ShipAddress.Addr5 != null)
                                    this.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());

                                if (loInvoice.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                if (loInvoice.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());

                                if (loInvoice.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());

                                if (loInvoice.ShipAddress.Country != null)
                                    this.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                if (loInvoice.Other != null)
                                    this._strCustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());
                                
                                
                                ////To show S.O.No in invoice old code
                                //if (loInvoice.CustomerRef.ListID != null)
                                //    this.CustomerRefListID = Convert.ToString(loInvoice.CustomerRef.ListID.GetValue());
                                ////To get S.O.No from sales order using CustomerListID from invoice
                                //this.SONO = GetSalesOrderNo(this.CustomerRefListID,pobjQBSessionManager,pobjQuickBooksAccountConfig);

                            }


                            //To show S.O.No for invoice
                            if (loInvoice.LinkedTxnList != null)
                            {
                                if (loInvoice.LinkedTxnList.Count > 1)
                                    this.LinkTxnRefNumber = "Multiple";
                                else
                                {
                                    for (int invtrans = 0; invtrans < loInvoice.LinkedTxnList.Count; invtrans++)
                                    {
                                        ILinkedTxn LinkTxn = loInvoice.LinkedTxnList.GetAt(invtrans);
                                        if (LinkTxn.RefNumber != null)
                                            this.LinkTxnRefNumber = LinkTxn.RefNumber.GetValue();

                                    }
                                }


                            }



                            alInvoices.Add(this);
                        }
                    }
                }
                return alInvoices;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        //To create Invoiced for sales order items
        public void CreateSalesInvoice(ArrayList invoiceitemlist, Hashtable itemnames, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            //step1: create QBFC session manager and prepare the request
            IMsgSetResponse msgSetRs = default(IMsgSetResponse);

            try
            {
            
                IMsgSetRequest msgSetRq = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                msgSetRq.Attributes.OnError = ENRqOnError.roeContinue;

                msgSetRq.ClearRequests();
                msgSetRq.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceAdd InvoiceAddRq = msgSetRq.AppendInvoiceAddRq();
                foreach (clsSalesOrderLine objSOLine in invoiceitemlist)
                {
                   // foreach (object objitem in itemnames)
                    foreach (DictionaryEntry objitem in itemnames)
                    {
                        if (objSOLine.SalesOrderLineItemRefFullName.ToString().Trim() == objitem.Key.ToString())
                        {
                            IInvoiceLineAdd invoiceLineAdd = InvoiceAddRq.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                            invoiceLineAdd.ItemRef.FullName.SetValue(objSOLine.SalesOrderLineItemRefFullName.ToString());
                            invoiceLineAdd.Desc.SetValue(objSOLine.SalesOrderLineDesc.ToString());
                            invoiceLineAdd.Quantity.SetValue(Convert.ToDouble(objitem.Value));
                            invoiceLineAdd.UnitOfMeasure.SetValue(objSOLine.SalesOrderLineUnitOfMeasure.ToString());
                        }
                    }
                    InvoiceAddRq.CustomerRef.FullName.SetValue(objSOLine.SalesOrdrCustomer);
                    InvoiceAddRq.PONumber.SetValue(objSOLine.PONumber);
                }
                msgSetRs = pobjQBSessionManager.DoRequests(msgSetRq);
                IResponse response = msgSetRs.ResponseList.GetAt(0);
                int statusCode = response.StatusCode;
                if (statusCode == 0)
                {
                    MessageBox.Show("Inventory removed and Invoice created", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
            }
        }



        public void CreateSalesInvoice(ArrayList invoiceitemlist, Hashtable itemnames)
        {
            //step1: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse msgSetRs = default(IMsgSetResponse);

            try
            {
                //lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest msgSetRq = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

               // IMsgSetRequest msgSetRq = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                msgSetRq.Attributes.OnError = ENRqOnError.roeContinue;

                msgSetRq.ClearRequests();
                msgSetRq.Attributes.OnError = ENRqOnError.roeContinue;
                IInvoiceAdd InvoiceAddRq = msgSetRq.AppendInvoiceAddRq();
                foreach (clsSalesOrderLine objSOLine in invoiceitemlist)
                {
                    // foreach (object objitem in itemnames)
                    foreach (DictionaryEntry objitem in itemnames)
                    {
                        if (objSOLine.SalesOrderLineItemRefFullName.ToString().Trim() == objitem.Key.ToString())
                        {
                            IInvoiceLineAdd invoiceLineAdd = InvoiceAddRq.ORInvoiceLineAddList.Append().InvoiceLineAdd;
                            invoiceLineAdd.ItemRef.FullName.SetValue(objSOLine.SalesOrderLineItemRefFullName.ToString());
                            invoiceLineAdd.Desc.SetValue(objSOLine.SalesOrderLineDesc.ToString());
                            invoiceLineAdd.Quantity.SetValue(Convert.ToDouble(objitem.Value));
                            invoiceLineAdd.UnitOfMeasure.SetValue(objSOLine.SalesOrderLineUnitOfMeasure.ToString());
                        }
                    }
                    InvoiceAddRq.CustomerRef.FullName.SetValue(objSOLine.SalesOrdrCustomer);
                    InvoiceAddRq.PONumber.SetValue(objSOLine.PONumber);
                }
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                msgSetRs = lQBSessionManager.DoRequests(msgSetRq);
                IResponse response = msgSetRs.ResponseList.GetAt(0);
                int statusCode = response.StatusCode;
                if (statusCode == 0)
                {
                    MessageBox.Show("Inventory removed and Invoice created", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
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
        //-----------Added on 12-Feb-2013 for allowing user to acces QB Data based on the option selected selection----------
        public ArrayList GetInvoiceList(string strRefNumber)
        {
            ArrayList alInvoices = new ArrayList();

            //step2: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = default(QBSessionManager);
            StringBuilder lobjBillAddress = new StringBuilder();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
               // lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();

                if (strRefNumber != "1=1")
                {
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(1);
                    //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                    InvoiceQuery.IncludeLinkedTxns.SetValue(true);

                   
                }
                else
                {
                    //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENActiveStatus.asAll);
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
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);
                            this.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
                            this.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
                            this.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                            this.PONumber = loInvoice.PONumber != null ? Convert.ToString(loInvoice.PONumber.GetValue()) : string.Empty; //davino code merged
                            this.CustomerRefFullName = Convert.ToString(loInvoice.CustomerRef.FullName.GetValue());
                            if (loInvoice.BillAddress != null)
                            {
                                if (loInvoice.BillAddress.Addr1 != null)
                                this.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());
                                //Get more BillAddress Info for lotnumber:Date 02/02/2013
                                if (loInvoice.BillAddress.Addr2 != null)
                                this.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());
                                if (loInvoice.BillAddress.City != null)
                                    lobjBillAddress.Append(Convert.ToString(loInvoice.BillAddress.City.GetValue()));
                                if (loInvoice.BillAddress.State != null)
                                {
                                    lobjBillAddress.Append(",");
                                    lobjBillAddress.Append(" ");
                                    lobjBillAddress.Append(Convert.ToString(loInvoice.BillAddress.State.GetValue()));
                                    
                                }
                                if (loInvoice.BillAddress.PostalCode != null)
                                {
                                    lobjBillAddress.Append(" ");
                                    lobjBillAddress.Append(Convert.ToString(loInvoice.BillAddress.PostalCode.GetValue()));
                                }

                                this.BillAddress = lobjBillAddress.ToString();
                                
                            }
                            else
                                this.BillAddressAddr1 = "";
                            //To add shipAddressBlock

                            if (loInvoice.ShipAddress != null)
                            {
                                if (loInvoice.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());

                                if (loInvoice.ShipAddress.Addr2 != null)
                                    this.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());
                               
                                if (loInvoice.ShipAddress.Addr3 != null)
                                    this.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());

                                if (loInvoice.ShipAddress.Addr4 != null)
                                    this.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());

                                if (loInvoice.ShipAddress.Addr5 != null)
                                    this.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());

                                if (loInvoice.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                if (loInvoice.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());

                                if (loInvoice.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());

                                if (loInvoice.ShipAddress.Country != null)
                                    this.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                if (loInvoice.Other != null)
                                    this._strCustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());

                                //show ship method in report :Date 01/13/2015
                                if(loInvoice.ShipMethodRef !=null)
                                    this._strShipAddressMethod = Convert.ToString(loInvoice.ShipMethodRef.FullName.GetValue());
                              
                                //shipDate for lotNumber:Date 02/02/2015
                              
                                if (loInvoice.ShipDate != null)
                                {
                                    if (DateTime.TryParse(Convert.ToString(loInvoice.ShipDate.GetValue()), out lstrresult))
                                    {
                                        this.ShipDate = lstrresult.ToShortDateString();
                                    }
                                }
                                    //this.ShipDate=Convert.ToString(loInvoice.ShipDate.GetValue());


                                //To show S.O.No in invoice old code
                               //if (loInvoice.CustomerRef.ListID != null)
                               //    this.CustomerRefListID = Convert.ToString(loInvoice.CustomerRef.ListID.GetValue());
                               // //To get S.O.No from sales order using CustomerListID from invoice
                               //  this.SONO=GetSalesOrderNo1(this.CustomerRefListID);
                                

                            }
                            //davino code added on 5th April 2017
                            //add column sales tax total and balanceonremaining
                            if (loInvoice.SalesTaxTotal != null)

                                this._dblSalesTaxTotal = string.Format("{0:N}", loInvoice.SalesTaxTotal.GetValue());
                            if (loInvoice.BalanceRemaining != null && loInvoice.BalanceRemaining.GetValue() != 0)
                            {

                                this._dblBalanceRemaining = string.Format("{0:N}", loInvoice.BalanceRemaining.GetValue());
                            }
                            else
                            {
                                this._dblBalanceRemaining = string.Format("{0:N}", stripcharfromstring(loInvoice.AppliedAmount.GetValue().ToString(), "-"));
                            }


                            if (loInvoice.PONumber != null)
                                this._strPONumber = Convert.ToString(loInvoice.PONumber.GetValue());
                            else
                                this._strPONumber = null;
                           

                            //To show S.O.No for invoice
                            if (loInvoice.LinkedTxnList != null)
                            {
                                if (loInvoice.LinkedTxnList.Count > 1)
                                    this.LinkTxnRefNumber = "Multiple";
                                else
                                {
                                    for (int invtrans = 0; invtrans < loInvoice.LinkedTxnList.Count; invtrans++)
                                    {
                                        ILinkedTxn LinkTxn = loInvoice.LinkedTxnList.GetAt(invtrans);
                                        if (LinkTxn.RefNumber != null)
                                            this.LinkTxnRefNumber = LinkTxn.RefNumber.GetValue();

                                    }
                                }


                            }

                            alInvoices.Add(this);
                        }
                    }
                }
                return alInvoices;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        private double stripcharfromstring(string pstrTotal, string pstrchartoremove)
        {
            string lstrcleanpath = string.Empty;
            int index = pstrTotal.IndexOf(pstrchartoremove);
            lstrcleanpath = (index < 0) ? pstrTotal : pstrTotal.Remove(index, pstrchartoremove.Length);
            return Convert.ToDouble(lstrcleanpath);

        }
        //To get S.O.No for open connection
        private string GetSalesOrderNo1(string pstrCustomerRefListID)
        {
            string sno = string.Empty;
            //step2: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
               // lQBSessionManager = new QBSessionManagerClass();
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery IInvoiceQuery = default(IInvoiceQuery);

                IInvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();

                if (pstrCustomerRefListID != "1=1")
                {

                   
                    IInvoiceQuery.IncludeLineItems.SetValue(true);
                }
                else
                {

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
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    //ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                   // ISalesOrderRet loSalesOrder = default(ISalesOrderRet);

                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);



                    List<string> lstlist = new List<string>();
                    List<string> lstlistnew = new List<string>();
                    

                    if (loList != null)
                    {


                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loInvoice = loList.GetAt(Index);

                            if (loInvoice.RefNumber != null)
                                sno = Convert.ToString(loInvoice.RefNumber.GetValue());
                            else
                                sno = "";
                        }




                        //if (loList.Count > 1)
                        //{
                        //    //for (int Index = 0; Index < loList.Count; Index++)
                        //    //{
                        //    //    loSalesOrder = loList.GetAt(Index);
                        //    //    lstlist.Add(loSalesOrder.RefNumber.GetValue().ToString());
                        //    //}
                        //    sno = "Multiple";
                        //}
                        //else
                        //{
                        //    //for (int Index = 0; Index < loList.Count; Index++)
                        //    //{
                        //    //    loSalesOrder = loList.GetAt(Index);

                        //    //    if (loSalesOrder.RefNumber != null)
                        //    //        sno = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                        //    //    else
                        //    //        sno = "";

                        //    //}

                        //    loSalesOrder = loList.GetAt(0);
                        //    if (loSalesOrder.RefNumber != null)
                        //        sno = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                        //    else
                        //        sno = "";


                        //}
                    }
                }
            }

            catch (Exception ex)
            {
                throw;
                return null;
            }


            return sno;

        }



        //To get S.O.No for close connection
        private string GetSalesOrderNo(string pstrCustomerRefListID, IQBSessionManager pobjIQBSessionManager, QuickBooksAccount pobjQuickBooksAccount)
        {
            string sno = string.Empty;
            //step2: create QBFC session manager and prepare the request
           // QBSessionManager lQBSessionManager = default(QBSessionManager);
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //lQBSessionManager = new QBSessionManagerClass();
                //IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", 8, 0);
                IMsgSetRequest lMsgRequest = pobjIQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccount.QBCountry, Convert.ToInt16(pobjQuickBooksAccount.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccount.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery ISalesOrderQuery = default(ISalesOrderQuery);

                ISalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                if (pstrCustomerRefListID != "1=1")
                {
                    //ISalesOrderQuery.ORSalesOrderQuery.SalesOrderFilter.MaxReturned.SetValue(1);
                    ISalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.EntityFilter.OREntityFilter.ListIDList.Add(pstrCustomerRefListID);

                    ISalesOrderQuery.IncludeLineItems.SetValue(true);
                }
                else
                {

                }

               // lQBSessionManager.OpenConnection("", "Label Connector");
                //lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
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
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                   
                  
                   
                    if (loList != null)
                    {
                        if (loList.Count > 1)
                        
                            sno = "Multiple";
                                                    
                        else
                        {
                            //for (int Index = 0; Index < loList.Count; Index++)
                            //{
                            //    loSalesOrder = loList.GetAt(Index);

                            //    if (loSalesOrder.RefNumber != null)
                            //        sno = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                            //    else
                            //        sno = "";

                            //}

                            loSalesOrder = loList.GetAt(0);
                            if (loSalesOrder.RefNumber != null)
                                sno = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                            else
                                sno = "";


                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw;
                return null;
            }


            return sno;

        }

        //method for mulitple invoice packaging option
        public ArrayList GetInvoiceListPackaging(string pInvfromdate, string pInvtodate)
        {

            ArrayList alInvoices = new ArrayList();
            clsInvoice lobjclsInvoiceLine = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);

                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                InvoiceQuery = lMsgRequest.AppendInvoiceQueryRq();


                //InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.ModifiedDateRangeFilter.FromModifiedDate.SetValue(DateTime.Parse(pInvfromdate), false);
                // InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.ModifiedDateRangeFilter.ToModifiedDate.SetValue(DateTime.Parse(pInvtodate), false);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));

                InvoiceQuery.IncludeLinkedTxns.SetValue(true);
                InvoiceQuery.IncludeLineItems.SetValue(true);




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
                    IInvoiceRetList loList = (IInvoiceRetList)loResponse.Detail;
                    IInvoiceRet loInvoice = default(IInvoiceRet);
                    // clsInvoice lobjclsInvoiceLine = new clsInvoice();
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            lobjclsInvoiceLine = new clsInvoice();
                            loInvoice = loList.GetAt(Index);
                            lobjclsInvoiceLine.TxnID = Convert.ToString(loInvoice.TxnID.GetValue());
                            lobjclsInvoiceLine.TxnDate = Convert.ToDateTime(loInvoice.TxnDate.GetValue());
                            lobjclsInvoiceLine.RefNumber = Convert.ToString(loInvoice.RefNumber.GetValue());
                            if (loInvoice.ShipDate != null)
                            {
                                lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());
                            }
                            if (loInvoice.BillAddress != null)
                            {
                                if (loInvoice.BillAddress.Addr1 != null)
                                    lobjclsInvoiceLine.BillAddressAddr1 = Convert.ToString(loInvoice.BillAddress.Addr1.GetValue());

                                if (loInvoice.BillAddress.Addr2 != null)
                                    lobjclsInvoiceLine.BillAddressAddr2 = Convert.ToString(loInvoice.BillAddress.Addr2.GetValue());

                                if (loInvoice.BillAddress.Addr3 != null)
                                    lobjclsInvoiceLine.BillAddressAddr3 = Convert.ToString(loInvoice.BillAddress.Addr3.GetValue());

                                if (loInvoice.BillAddress.Addr4 != null)
                                    lobjclsInvoiceLine.BillAddressAddr4 = Convert.ToString(loInvoice.BillAddress.Addr4.GetValue());

                                if (loInvoice.BillAddress.Addr5 != null)
                                    lobjclsInvoiceLine.BillAddressAddr5 = Convert.ToString(loInvoice.BillAddress.Addr5.GetValue());

                                if (loInvoice.BillAddress.City != null)
                                    lobjclsInvoiceLine.BillAddressCity = Convert.ToString(loInvoice.BillAddress.City.GetValue());

                                if (loInvoice.BillAddress.State != null)
                                    lobjclsInvoiceLine.BillAddressState = Convert.ToString(loInvoice.BillAddress.State.GetValue());

                                if (loInvoice.BillAddress.PostalCode != null)
                                    lobjclsInvoiceLine.BillAddressPostalCode = Convert.ToString(loInvoice.BillAddress.PostalCode.GetValue());

                                if (loInvoice.BillAddress.Country != null)
                                    lobjclsInvoiceLine.BillAddressCountry = Convert.ToString(loInvoice.BillAddress.Country.GetValue());

                            }
                            //To add shipAddressBlock

                            if (loInvoice.ShipAddress != null)
                            {
                                if (loInvoice.ShipAddress.Addr1 != null)
                                    lobjclsInvoiceLine.ShipAddressAddr1 = Convert.ToString(loInvoice.ShipAddress.Addr1.GetValue());

                                if (loInvoice.ShipAddress.Addr2 != null)
                                    lobjclsInvoiceLine.ShipAddressAddr2 = Convert.ToString(loInvoice.ShipAddress.Addr2.GetValue());

                                if (loInvoice.ShipAddress.Addr3 != null)
                                    lobjclsInvoiceLine.ShipAddressAddr3 = Convert.ToString(loInvoice.ShipAddress.Addr3.GetValue());

                                if (loInvoice.ShipAddress.Addr4 != null)
                                    lobjclsInvoiceLine.ShipAddressAddr4 = Convert.ToString(loInvoice.ShipAddress.Addr4.GetValue());

                                if (loInvoice.ShipAddress.Addr5 != null)
                                    lobjclsInvoiceLine.ShipAddressAddr5 = Convert.ToString(loInvoice.ShipAddress.Addr5.GetValue());

                                if (loInvoice.ShipAddress.City != null)
                                    lobjclsInvoiceLine.ShipAddressCity = Convert.ToString(loInvoice.ShipAddress.City.GetValue());

                                if (loInvoice.ShipAddress.State != null)
                                    lobjclsInvoiceLine.ShipAddressState = Convert.ToString(loInvoice.ShipAddress.State.GetValue());

                                if (loInvoice.ShipAddress.PostalCode != null)
                                    lobjclsInvoiceLine.ShipAddressPostalCode = Convert.ToString(loInvoice.ShipAddress.PostalCode.GetValue());

                                if (loInvoice.ShipAddress.Country != null)
                                    lobjclsInvoiceLine.ShipAddressCountry = Convert.ToString(loInvoice.ShipAddress.Country.GetValue());
                                if (loInvoice.Other != null)
                                    lobjclsInvoiceLine._strCustomFieldOther = Convert.ToString(loInvoice.Other.GetValue());
                                if (loInvoice.ShipDate != null)
                                    lobjclsInvoiceLine.ShipDate = Convert.ToString(loInvoice.ShipDate.GetValue());


                                //To show S.O.No in invoice old code
                                //if (loInvoice.CustomerRef.ListID != null)
                                //    this.CustomerRefListID = Convert.ToString(loInvoice.CustomerRef.ListID.GetValue());
                                // //To get S.O.No from sales order using CustomerListID from invoice
                                //  this.SONO=GetSalesOrderNo1(this.CustomerRefListID);


                            }
                            //add column sales tax total and balanceonremaining
                            if (loInvoice.SalesTaxTotal != null)

                                lobjclsInvoiceLine._dblSalesTaxTotal = string.Format("{0:N}", loInvoice.SalesTaxTotal.GetValue());
                            if (loInvoice.BalanceRemaining != null)
                                lobjclsInvoiceLine._dblBalanceRemaining = string.Format("{0:N}", loInvoice.BalanceRemaining.GetValue());
                            // if (loInvoice.TxnDate != null)
                            //    this._strTxnDate = Convert.ToString(loInvoice.TxnDate.GetValue());
                            if (loInvoice.PONumber != null)
                                lobjclsInvoiceLine._strPONumber = Convert.ToString(loInvoice.PONumber.GetValue());





                            //To show S.O.No for invoice
                            if (loInvoice.LinkedTxnList != null)
                            {
                                if (loInvoice.LinkedTxnList.Count > 1)
                                    lobjclsInvoiceLine.LinkTxnRefNumber = "Multiple";
                                else
                                {
                                    for (int invtrans = 0; invtrans < loInvoice.LinkedTxnList.Count; invtrans++)
                                    {
                                        ILinkedTxn LinkTxn = loInvoice.LinkedTxnList.GetAt(invtrans);
                                        if (LinkTxn.RefNumber != null)
                                            lobjclsInvoiceLine.LinkTxnRefNumber = LinkTxn.RefNumber.GetValue();

                                    }
                                }


                            }

                            alInvoices.Add(lobjclsInvoiceLine);
                        }
                    }
                }
                return alInvoices;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }

        }



        
        //-----------END Added on 12-Feb-2013 for allowing user to acces QB Data based on the option selected selection----------
    }
}
