using Interop.QBFC13;
using QBLC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConnector
{
    class clsSalesReceipt
    {
        string _strTxnID;
        DateTime _dtTxnDate;
        string _strRefNumber;
        string _strCustomerRefFullName;
        string _strShipAddressPostalCode;
        string _strShipAddressAddr1;
        string _strShipAddressState;
        string _strShipAddressCity;
        string _strIsPending;
        string _strCheckNumber;
        string _strPaymentMethodRef;
        string _strCompanyName;

        string _strBillAddressAddr1;
        string _strBillAddressAddr2;
        string _strBillAddressAddr3;
        string _strBillAddressAddr4;
        string _strBillAddressAddr5;
        string _strBillAddressPostalCode;
        string _strBillAddressCity;
        string _strBillAddressState;
        string _strBillAddressCountry;
        string _dblSalesTaxTotal;
        string _dblBalanceRemaining;
        string _strShipDate;
        string _strCustomFieldOther;

        string _strShipAddressAddr2;
        string _strShipAddressAddr3;
        string _strShipAddressAddr4;
        string _strShipAddressAddr5;
        string _strShipAddressCountry;
        string _strFOB;
        string _strother;
        string _strNote;



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

        public string ShipAddressCity
        {
            get { return _strShipAddressCity; }
            set { _strShipAddressCity = value; }

        }
        public string ShipAddressState
        {
            get { return _strShipAddressState; }
            set { _strShipAddressState = value; }

        }
        public string Note
        {
            get { return _strNote; }
            set { _strNote = value; }
        }
        public string IsPending
        {
            get { return _strIsPending; }
            set { _strIsPending = value; }
        }
        public string CheckNumber
        {
            get { return _strCheckNumber; }
            set { _strCheckNumber = value; }
        }
        public string PaymentMethodRef
        {
            get { return _strPaymentMethodRef; }
            set { _strPaymentMethodRef = value; }
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
                return _dblSalesTaxTotal;
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
                return _dblBalanceRemaining;
            }
            set
            {
                _dblBalanceRemaining = value;
            }
        }


        public string ShipDate
        {
            get { return _strShipDate; }
            set { _strShipDate = value; }

        }
        public string Other
        {
            get { return _strother; }
            set { _strother = value; }
        }

        //method for mulitple sales order to show :Date 07-09-2016
        public ArrayList GetFilteredSalesReceipt(string pInvfromdate, string pInvtodate)
        {

            ArrayList alInvoices = new ArrayList();
            clsSalesReceipt lobjclssalesLine = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                //IInvoiceQuery InvoiceQuery = default(IInvoiceQuery);
                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);
                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
                //Set field value for ToTxnDate
                SalesReceiptQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));


                //SalesReceiptQuery.IncludeLi.SetValue(true);
                SalesReceiptQuery.IncludeLineItems.SetValue(true);




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
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            lobjclssalesLine = new clsSalesReceipt(); ;
                            loSalesReceipt = loList.GetAt(Index);
                            lobjclssalesLine.TxnID = Convert.ToString(loSalesReceipt.TxnID.GetValue());
                            lobjclssalesLine.TxnDate = Convert.ToDateTime(loSalesReceipt.TxnDate.GetValue());
                            lobjclssalesLine.RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());
                            if (lobjclssalesLine.ShipDate != null) Convert.ToString(loSalesReceipt.ShipDate.GetValue());
                            if (loSalesReceipt.CustomerRef != null)
                            {
                                lobjclssalesLine.CustomerRefFullName = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                            }
                            //To add shipAddressBlock

                            if (loSalesReceipt.ShipAddress != null)
                            {
                                if (loSalesReceipt.ShipAddress.Addr1 != null)
                                    lobjclssalesLine.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());  
                            }
                            if (loSalesReceipt.FOB != null)
                            {
                                lobjclssalesLine.FOB = Convert.ToString(loSalesReceipt.FOB.GetValue());
                            }                            
                            alInvoices.Add(lobjclssalesLine);
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

        public ArrayList GetSRList(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alSalesReceipt = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);
                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                if (strRefNumber != "1=1")
                {
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
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
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesReceipt = loList.GetAt(Index);
                            TxnID = Convert.ToString(loSalesReceipt.TxnID.GetValue());
                            TxnDate = Convert.ToDateTime(loSalesReceipt.TxnDate.GetValue());
                            RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());

                            //Get postalcode & shipaddress1 for sales order :Date 11/11/2014
                            if (loSalesReceipt.ShipAddress != null)
                            {
                                if (loSalesReceipt.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                if (loSalesReceipt.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                if (loSalesReceipt.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());
                            }
                            string strFullName = "";
                            strFullName = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());
                            CustomerRefFullName = strFullName;

                            this.CustomerCompanyName = GetCustomerCompanyname(strFullName);
                            alSalesReceipt.Add(this);
                        }
                    }
                }
                return alSalesReceipt;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public ArrayList GetSRList(string strRefNumber)
        {
            ArrayList alSalesReceipt = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            // QBSessionManager lQBSessionManager = default(QBSessionManager);
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesReceiptQuery SalesReceiptQuery = default(ISalesReceiptQuery);
                SalesReceiptQuery = lMsgRequest.AppendSalesReceiptQueryRq();

                if (strRefNumber != "1=1")
                {
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesReceiptQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
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
                    ISalesReceiptRetList loList = (ISalesReceiptRetList)loResponse.Detail;
                    ISalesReceiptRet loSalesReceipt = default(ISalesReceiptRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesReceipt = loList.GetAt(Index);
                            TxnID = Convert.ToString(loSalesReceipt.TxnID.GetValue());
                            TxnDate = Convert.ToDateTime(loSalesReceipt.TxnDate.GetValue());
                            RefNumber = Convert.ToString(loSalesReceipt.RefNumber.GetValue());

                            if (loSalesReceipt.ShipAddress != null)
                            {
                                if (loSalesReceipt.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loSalesReceipt.ShipAddress.PostalCode.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loSalesReceipt.ShipAddress.Addr1.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr2 != null)
                                    this.ShipAddressAddr2 = Convert.ToString(loSalesReceipt.ShipAddress.Addr2.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr3 != null)
                                    this.ShipAddressAddr3 = Convert.ToString(loSalesReceipt.ShipAddress.Addr3.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr4 != null)
                                    this.ShipAddressAddr4 = Convert.ToString(loSalesReceipt.ShipAddress.Addr4.GetValue());

                                if (loSalesReceipt.ShipAddress.Addr5 != null)
                                    this.ShipAddressAddr5 = Convert.ToString(loSalesReceipt.ShipAddress.Addr5.GetValue());

                                if (loSalesReceipt.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loSalesReceipt.ShipAddress.City.GetValue());

                                if (loSalesReceipt.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loSalesReceipt.ShipAddress.State.GetValue());

                                if (loSalesReceipt.ShipAddress.Note != null)
                                    this.Note = Convert.ToString(loSalesReceipt.ShipAddress.Note.GetValue());

                            }
                            //add shipdate for so packaging
                            if (loSalesReceipt.ShipDate != null)
                            {
                                this.ShipDate = Convert.ToString(loSalesReceipt.ShipDate.GetValue().ToString("MM/dd/yyyy"));
                            }
                            else
                            {
                                this.ShipDate = "";
                            }

                            if (loSalesReceipt.Other != null)
                            {
                                this.Other = Convert.ToString(loSalesReceipt.Other.GetValue().ToString());
                            }
                            else
                            {
                                this.Other = "";
                            }

                            string strFullName = "";
                            if (loSalesReceipt.CustomerRef != null)
                            {
                                strFullName = Convert.ToString(loSalesReceipt.CustomerRef.FullName.GetValue());

                                CustomerRefFullName = strFullName;

                                this.CustomerCompanyName = GetCustomerCompanyname(strFullName);
                            }
                            alSalesReceipt.Add(this);
                        }
                    }
                }
                return alSalesReceipt;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public string GetCustomerCompanyname(string pstrCustomerName)
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
                                            if (loProduct.CompanyName != null)
                                                lstrGetCompanyName = Convert.ToString(loProduct.CompanyName.GetValue());//Get company name

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
    }
}
