using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Windows.Forms;
using LabelConnector;
using System.Configuration;
using System.Threading.Tasks;

namespace QBLC
{
    class clsSalesOrder
    {
        string _strTxnID;
        DateTime _dtTxnDate;
        string _strRefNumber;
        string _strCustomerRefFullName;
        string _strShipAddressPostalCode;
        string _strShipAddressAddr1;
        string _strShipAddressState;
        string _strShipAddressCity;
        string _strPONumber;
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

            set {
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
        public string PONumber
        {
            get { return _strPONumber; }
            set { _strPONumber = value; }
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
        public ArrayList GetFilteredSalesOrders(string pInvfromdate, string pInvtodate)
        {

            ArrayList alSalesOrder = new ArrayList();
            clsSalesOrder lobjclssalesLine = null;

            //step2: create QBFC session manager and prepare the request
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;

                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
               
                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);
                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(pInvfromdate));
                //Set field value for ToTxnDate
                SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(pInvtodate));

                SalesOrderQuery.IncludeLinkedTxns.SetValue(true);
                SalesOrderQuery.IncludeLineItems.SetValue(true);

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
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesorder = default(ISalesOrderRet);
                 
                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            lobjclssalesLine = new clsSalesOrder(); 
                            loSalesorder = loList.GetAt(Index);
                            lobjclssalesLine.TxnID = Convert.ToString(loSalesorder.TxnID.GetValue());
                            lobjclssalesLine.TxnDate = Convert.ToDateTime(loSalesorder.TxnDate.GetValue());
                            lobjclssalesLine.RefNumber = Convert.ToString(loSalesorder.RefNumber.GetValue());
                            if (lobjclssalesLine.ShipDate != null) Convert.ToString(loSalesorder.ShipDate.GetValue());
                            lobjclssalesLine.CustomerRefFullName = Convert.ToString(loSalesorder.CustomerRef.FullName.GetValue());
                       
                            if (loSalesorder.ShipAddress != null)
                            {
                                if (loSalesorder.ShipAddress.Addr1 != null)
                                    lobjclssalesLine.ShipAddressAddr1 = Convert.ToString(loSalesorder.ShipAddress.Addr1.GetValue());

                            }
                            if (loSalesorder.FOB != null)
                            {
                                lobjclssalesLine.FOB = Convert.ToString(loSalesorder.FOB.GetValue());
                            }

                            alSalesOrder.Add(lobjclssalesLine);
                        }
                    }
                }
                return alSalesOrder;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }

        }

        public ArrayList GetSOList(string strRefNumber, IQBSessionManager pobjQBSessionManager, QuickBooksAccount pobjQuickBooksAccountConfig)
        {
            ArrayList alSalesOrders = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {

                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);
                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                if (strRefNumber != "1=1")
                {
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                    //SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
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
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);
                            TxnID = Convert.ToString(loSalesOrder.TxnID.GetValue());
                            TxnDate = Convert.ToDateTime(loSalesOrder.TxnDate.GetValue());
                            RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());

                            //Get postalcode & shipaddress1 for sales order :Date 11/11/2014
                            if (loSalesOrder.ShipAddress != null)
                            {
                                if (loSalesOrder.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                if (loSalesOrder.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                if (loSalesOrder.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                if (loSalesOrder.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());
                            }
                            string strFullName = "";
                            //if (loSalesOrder.SalesRepRef != null)
                            //{
                            strFullName = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                            //}
                            //else
                            //{
                            //    strFullName = "";
                            //}
                            CustomerRefFullName = strFullName;
                            //Get company name for customer : Date 08/09/2015
                            this.CustomerCompanyName = GetCustomerCompanyname(strFullName);
                            alSalesOrders.Add(this);
                        }
                    }
                }
                return alSalesOrders;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }
        public ArrayList GetGridHeaderSOList(string strRefNumber)
        {
            ArrayList alSalesOrders = new ArrayList();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);
          
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);
                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                if (strRefNumber != "1=1")
                {
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                }
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
            }
            catch (Exception Ex)
            {
              
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
                if (lMsgResponse != null)
                {

                    if ((lMsgResponse.ResponseList.Count > 0))
                    {

                        IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                        ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                        ISalesOrderRet loSalesOrder = default(ISalesOrderRet);
                        GetclassHeaderSalesOrder clssalesorder = new GetclassHeaderSalesOrder();

                        if (loList != null)
                        {
                            for (int Index = 0; Index < loList.Count; Index++)
                            {
                                loSalesOrder = loList.GetAt(Index);
                                clssalesorder.TxnID = Convert.ToString(loSalesOrder.TxnID.GetValue());
                                clssalesorder.TxnDate = Convert.ToDateTime(loSalesOrder.TxnDate.GetValue());
                                clssalesorder.RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                                string strFullName = "";
                                clssalesorder.CustomerRefFullName = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());

                                alSalesOrders.Add(clssalesorder);
                            }
                        }
                    }
                }
                return alSalesOrders;
               
            }
            catch (Exception ex)
            {
             
                return null;
            }
            
        }


        public ArrayList GetSOList(string strRefNumber)
        {
            ArrayList alSalesOrders = new ArrayList();
            QBSessionManager lQBSessionManager = null;
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                IMsgSetRequest lMsgRequest = lQBSessionManager.CreateMsgSetRequest("US", Convert.ToInt16(ConfigurationManager.AppSettings["QBXMLVersion"]), 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQuery = default(ISalesOrderQuery);
                SalesOrderQuery = lMsgRequest.AppendSalesOrderQueryRq();

                if (strRefNumber != "1=1")
                {
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.MaxReturned.SetValue(1);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    SalesOrderQuery.ORTxnNoAccountQuery.TxnFilterNoAccount.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
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
                 
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    ISalesOrderRetList loList = (ISalesOrderRetList)loResponse.Detail;
                    ISalesOrderRet loSalesOrder = default(ISalesOrderRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loSalesOrder = loList.GetAt(Index);
                            TxnID = Convert.ToString(loSalesOrder.TxnID.GetValue());
                            TxnDate = Convert.ToDateTime(loSalesOrder.TxnDate.GetValue());
                            RefNumber = Convert.ToString(loSalesOrder.RefNumber.GetValue());
                        
                            if (loSalesOrder.ShipAddress != null)
                            {
                                if (loSalesOrder.ShipAddress.PostalCode != null)
                                    this.ShipAddressPostalCode = Convert.ToString(loSalesOrder.ShipAddress.PostalCode.GetValue());

                                if (loSalesOrder.ShipAddress.Addr1 != null)
                                    this.ShipAddressAddr1 = Convert.ToString(loSalesOrder.ShipAddress.Addr1.GetValue());

                                if (loSalesOrder.ShipAddress.Addr2 != null)
                                    this.ShipAddressAddr2 = Convert.ToString(loSalesOrder.ShipAddress.Addr2.GetValue());

                                if (loSalesOrder.ShipAddress.Addr3 != null)
                                    this.ShipAddressAddr3 = Convert.ToString(loSalesOrder.ShipAddress.Addr3.GetValue());

                                if (loSalesOrder.ShipAddress.Addr4 != null)
                                    this.ShipAddressAddr4 = Convert.ToString(loSalesOrder.ShipAddress.Addr4.GetValue());

                                if (loSalesOrder.ShipAddress.Addr5 != null)
                                    this.ShipAddressAddr5 = Convert.ToString(loSalesOrder.ShipAddress.Addr5.GetValue());

                                if (loSalesOrder.ShipAddress.City != null)
                                    this.ShipAddressCity = Convert.ToString(loSalesOrder.ShipAddress.City.GetValue());

                                if (loSalesOrder.ShipAddress.State != null)
                                    this.ShipAddressState = Convert.ToString(loSalesOrder.ShipAddress.State.GetValue());
                             
                                if(loSalesOrder.ShipAddress.Note !=null)
                                    this.Note= Convert.ToString(loSalesOrder.ShipAddress.Note.GetValue());

                            }
                       
                            if (loSalesOrder.PONumber != null)
                            {
                                this.PONumber = Convert.ToString(loSalesOrder.PONumber.GetValue());
                            }
                            else
                            {
                                this.PONumber = "";
                            }

                        
                            if (loSalesOrder.ShipDate != null)
                            {
                                this.ShipDate = Convert.ToString(loSalesOrder.ShipDate.GetValue().ToString("MM/dd/yyyy"));
                            }
                            else
                            {
                                this.ShipDate = "";
                            }

                            if(loSalesOrder.Other !=null)
                            {
                                this.Other = Convert.ToString(loSalesOrder.Other.GetValue().ToString());
                            }
                            else
                            {
                                this.Other="";
                            }

                            string strFullName = "";
                        
                                strFullName = Convert.ToString(loSalesOrder.CustomerRef.FullName.GetValue());
                       
                            CustomerRefFullName = strFullName;
                       
                            this.CustomerCompanyName=GetCustomerCompanyname(strFullName);

                            alSalesOrders.Add(this);
                        }
                    }
                }
                return alSalesOrders;
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
