using Interop.QBFC13;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LabelConnector
{
   public class clsInvoiceGroupingByCustomField
    {
        public Dictionary<string, string> GetCustomerCustomFieldList()
        {

           // ArrayList alCustomerCustomF = new ArrayList();
           Dictionary<string, string> lobjItemExtensions = new Dictionary<string, string>();
          
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

               // CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(pstrItemName);
               // CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(pstrItemName);

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


        public Tuple<Dictionary<string, string>, Dictionary<string, string>>  GetAllItems_Customers_CustomFiledList()
        {

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
                //Inventory Items
                IItemInventoryQuery ItemInventoryQueryRq = lMsgRequest.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.OwnerIDList.Add("0");
                ItemInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);
                //Non Inventory Items
                IItemNonInventoryQuery ItemNonInventoryQueryRq = lMsgRequest.AppendItemNonInventoryQueryRq();
                ItemNonInventoryQueryRq.OwnerIDList.Add("0");
                ItemNonInventoryQueryRq.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                //for test/////

                ICustomerQuery CustomerQueryRq = lMsgRequest.AppendCustomerQueryRq();

                CustomerQueryRq.OwnerIDList.Add("0");
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);

                //for test/////


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
                                if (!alProductCustomFields.ContainsKey(string.Empty))
                                {
                                    alProductCustomFields.Add(string.Empty, string.Empty);
                                }
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
                                                                                                     
                                                    //Get value of DataExtValue
                                                    InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();


                                                    if (!alProductCustomFields.ContainsKey(InvCustomItemName))
                                                    {
                                                        alProductCustomFields.Add(InvCustomItemName, InvCustomItemValue);
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
                                                    //Get value of DataExtValue
                                                    InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (!alProductCustomFields.ContainsKey(CustomNonInvItemName))
                                                    {
                                                        alProductCustomFields.Add(CustomNonInvItemName, InvCustomItemValue);
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
                                                    //Get value of DataExtValue
                                                    InvCustomItemValue = (string)DataExtRet.DataExtValue.GetValue();

                                                    if (!alProductCustomFields.ContainsKey(CustomGroupItemName))
                                                    {
                                                        alProductCustomFields.Add(CustomGroupItemName, InvCustomItemValue);
                                                    }
                                                }
                                            }



                                        }
                                    }


                                }


                                if (responseType == ENResponseType.rtCustomerQueryRs)
                                {
                                    if (!lobjCustomerCustomFieldExtensions.ContainsKey(string.Empty))
                                    {
                                        lobjCustomerCustomFieldExtensions.Add(string.Empty, string.Empty);
                                    }
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
                                                     InvCustomCustomerFieldName = (string)DataExtRet.DataExtName.GetValue().Trim().ToUpper();

                                                    //Get value of DataExtValue
                                                     InvCustomCustomerFieldValue = (string)DataExtRet.DataExtValue.GetValue();
                                                    if (!lobjCustomerCustomFieldExtensions.ContainsKey(InvCustomCustomerFieldName))
                                                        lobjCustomerCustomFieldExtensions.Add(InvCustomCustomerFieldName, InvCustomCustomerFieldValue);
                                                }
                                            }



                                        }
                                    }


                                }

                            }
                        }
                    }


                }

                return Tuple.Create(lobjCustomerCustomFieldExtensions,alProductCustomFields);
            }
            catch (Exception ex)
            {
                throw;
                // return null;
            }

        }

       

    }
}
