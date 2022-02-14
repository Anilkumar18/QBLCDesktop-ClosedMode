using System;
using System.Collections.Generic;
using System.Text;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Collections;
using System.Windows.Forms;
using LabelConnector;
using System.Configuration;

namespace QBLC
{
    class clsPurchaseOrder
    {
        string _strTxnID;
        DateTime _dtTxnDate;
        string _strRefNumber;
        string _strVendorRefFullName;
       


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
        public string RefFullName
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


        //Filter item receipt by Trans date
        public class FilterReceiptTransDate
        {
            DateTime _dtReceiptTrasnDate;
            
            public DateTime ReceiptTrasnDate
            {
                get
                {
                    return _dtReceiptTrasnDate;
                }
                set
                {
                    _dtReceiptTrasnDate = value;
                }
            }


            public FilterReceiptTransDate(DateTime TransDate)
            {
                ReceiptTrasnDate = TransDate;
               
            }

        };


        public ArrayList GetPOList(string strRefNumber, IQBSessionManager pobjQBSessionManager)
        {
            ArrayList alPurchaseOrders = new ArrayList();

            //step2: create QBFC session manager and prepare the request
            IMsgSetResponse lMsgResponse = default(IMsgSetResponse);

            try
            {
                //IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest(pobjQuickBooksAccountConfig.QBCountry, Convert.ToInt16(pobjQuickBooksAccountConfig.QBMajorVersion), Convert.ToInt16(pobjQuickBooksAccountConfig.QBMinorVersion));
                IMsgSetRequest lMsgRequest = pobjQBSessionManager.CreateMsgSetRequest("US", 13, 0);
                lMsgRequest.Attributes.OnError = ENRqOnError.roeContinue;


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);
                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();

                if (strRefNumber != "1=1")
                {
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
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
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);

                    if (loList != null)
                    {
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);
                            if (loPurchaseOrder.TxnID != null)
                            {
                                this.TxnID = Convert.ToString(loPurchaseOrder.TxnID.GetValue());
                            }
                            else
                            {
                                this.TxnID = string.Empty;
                            }
                            if (loPurchaseOrder.TxnDate != null)
                                this.TxnDate = Convert.ToDateTime(loPurchaseOrder.TxnDate.GetValue());
                            else
                                this.TxnDate = DateTime.MinValue;
                            
                            if (loPurchaseOrder.RefNumber!=null)
                                this.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                            else
                                this.RefNumber = string.Empty;

                            if (loPurchaseOrder.VendorRef != null)
                                this.RefFullName = Convert.ToString(loPurchaseOrder.VendorRef.FullName.GetValue());
                            else
                                this.RefFullName = string.Empty;
                            alPurchaseOrders.Add(this);
                        }
                    }
                }
                return alPurchaseOrders;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public ArrayList GetPOList(string strRefNumber)
        {
            ArrayList alPurchaseOrders = new ArrayList();
            //List<FilterReceiptTransDate> txndatelist = new List<FilterReceiptTransDate>();
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


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);
                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();
                //To get TxnDate
                //PurchaseOrderQuery.OwnerIDList.Add("0"); //to show all fields
               // PurchaseOrderQuery.IncludeLinkedTxns.SetValue(true);
                //PurchaseOrderQuery.IncludeLineItems.SetValue(true);

                if (strRefNumber != "1=1")
                {
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                }
                QBHelper.WriteLog("3" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " Open QB connection started ...");
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                QBHelper.WriteLog("4" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB DoRequest processes started...");
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                QBHelper.WriteLog("5" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB DoRequest processes completed...");
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
                    QBHelper.WriteLog("6" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " Open QB connection ended ...");
                }
            }
            try
            {
                
                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    QBHelper.WriteLog("7" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Generate responselist...");
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);

                   
                    if (loList != null)
                    {
                        QBHelper.WriteLog("8" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "loList is generated");
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);

                            //Get link Txn Item receipt
                            //if (loPurchaseOrder.LinkedTxnList != null)
                            //{
                            //    for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                            //    {
                            //        ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);

                            //        if (LinkedTxn.TxnDate != null)
                            //        {

                            //            DateTime dtdate = Convert.ToDateTime(LinkedTxn.TxnDate.GetValue());
                            //            txndatelist.Add(new FilterReceiptTransDate(dtdate));

                            //        }
 
                            //    }

                            //}

                            if (loPurchaseOrder.TxnID != null)
                            {
                                this.TxnID = Convert.ToString(loPurchaseOrder.TxnID.GetValue());
                            }
                            else
                            {
                                this.TxnID = string.Empty;
                            }
                            if (loPurchaseOrder.TxnDate != null)
                                this.TxnDate = Convert.ToDateTime(loPurchaseOrder.TxnDate.GetValue());
                             
                                
                            else
                                this.TxnDate = DateTime.MinValue;

                            if (loPurchaseOrder.RefNumber != null)
                                this.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                            else
                                this.RefNumber = string.Empty;

                            if (loPurchaseOrder.VendorRef != null)
                                this.RefFullName = Convert.ToString(loPurchaseOrder.VendorRef.FullName.GetValue());
                            else
                                this.RefFullName = string.Empty;

                           
                            alPurchaseOrders.Add(this);
                           // alPurchaseOrders.Add(txndatelist);
                        }
                    }
                }
                return alPurchaseOrders;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }


        public ArrayList GetMulitiplePO(string strRefNumber,out List<FilterReceiptTransDate> pobjTxndates)
        {
            ArrayList alPurchaseOrders = new ArrayList();
            List<FilterReceiptTransDate> txndatelist = new List<FilterReceiptTransDate>();
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


                IPurchaseOrderQuery PurchaseOrderQuery = default(IPurchaseOrderQuery);
                PurchaseOrderQuery = lMsgRequest.AppendPurchaseOrderQueryRq();
                //To get TxnDate
                //PurchaseOrderQuery.OwnerIDList.Add("0"); //to show all fields
                PurchaseOrderQuery.IncludeLinkedTxns.SetValue(true);
                //PurchaseOrderQuery.IncludeLineItems.SetValue(true);

                if (strRefNumber != "1=1")
                {
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(1);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.FromRefNumber.SetValue(strRefNumber);
                    PurchaseOrderQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberRangeFilter.ToRefNumber.SetValue(strRefNumber);
                }
                QBHelper.WriteLog("3" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " Open QB connection started ...");
                lQBSessionManager.OpenConnection("", "Label Connector");
                lQBSessionManager.BeginSession("", ENOpenMode.omDontCare);
                QBHelper.WriteLog("4" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB DoRequest processes started...");
                lMsgResponse = lQBSessionManager.DoRequests(lMsgRequest);
                QBHelper.WriteLog("5" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB DoRequest processes completed...");
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
                    QBHelper.WriteLog("6" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " Open QB connection ended ...");
                }
            }
            try
            {

                if ((lMsgResponse.ResponseList.Count > 0))
                {
                    QBHelper.WriteLog("7" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + " QB Generate responselist...");
                    //we have one response for  single add request
                    IResponse loResponse = lMsgResponse.ResponseList.GetAt(0);
                    IPurchaseOrderRetList loList = (IPurchaseOrderRetList)loResponse.Detail;
                    IPurchaseOrderRet loPurchaseOrder = default(IPurchaseOrderRet);


                    if (loList != null)
                    {
                        QBHelper.WriteLog("8" + "<==>" + "LabelConnector:Time:-" + DateTime.Now.ToString() + "loList is generated");
                        for (int Index = 0; Index < loList.Count; Index++)
                        {
                            loPurchaseOrder = loList.GetAt(Index);

                            //Get link Txn Item receipt
                            if (loPurchaseOrder.LinkedTxnList != null)
                            {
                                for (int lntrans = 0; lntrans < loPurchaseOrder.LinkedTxnList.Count; lntrans++)
                                {
                                    ILinkedTxn LinkedTxn = loPurchaseOrder.LinkedTxnList.GetAt(lntrans);

                                    if (LinkedTxn.TxnDate != null)
                                    {

                                        DateTime dtdate = Convert.ToDateTime(LinkedTxn.TxnDate.GetValue());
                                        txndatelist.Add(new FilterReceiptTransDate(dtdate));

                                    }

                                }

                            }

                            if (loPurchaseOrder.TxnID != null)
                            {
                                this.TxnID = Convert.ToString(loPurchaseOrder.TxnID.GetValue());
                            }
                            else
                            {
                                this.TxnID = string.Empty;
                            }
                            if (loPurchaseOrder.TxnDate != null)
                                this.TxnDate = Convert.ToDateTime(loPurchaseOrder.TxnDate.GetValue());


                            else
                                this.TxnDate = DateTime.MinValue;

                            if (loPurchaseOrder.RefNumber != null)
                                this.RefNumber = Convert.ToString(loPurchaseOrder.RefNumber.GetValue());
                            else
                                this.RefNumber = string.Empty;

                            if (loPurchaseOrder.VendorRef != null)
                                this.RefFullName = Convert.ToString(loPurchaseOrder.VendorRef.FullName.GetValue());
                            else
                                this.RefFullName = string.Empty;


                            alPurchaseOrders.Add(this);
                            // alPurchaseOrders.Add(txndatelist);
                        }
                    }
                }
                pobjTxndates = txndatelist;
                return alPurchaseOrders;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

    }
}
