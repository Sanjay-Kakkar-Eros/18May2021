#region

using System;
using System.Configuration;
using Framework.ChargingLibrary.EntitiesTableAdapters;
using Framework.Core;
using Framework.Data;
using System.Data.Objects.SqlClient;
using Framework.ChargingLibrary.Chargers;
using System.Messaging;
using System.Threading;

#endregion

namespace Framework.ChargingLibrary
{
    public static class DataAccessLayer
    {
        static object objSync = new object();
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ChargingGatewayConnectionString"].ConnectionString; }
        }

        private static object objectSync=new Object();

        public static void InsertToMaxisProcessingLogs(string msisdn, string msgID, string message, string url, string errorMessage, string httpResponse,
                                                   string maxisResCode, string MOresponse, OperationResult Maxresponse, string operetor)
        {
            try
            {
                using (var dc = new Framework.Data.TZStoreDataContext())
                {
                    var maxisIncoming = new Framework.Data.MaxisIncomingProcessLog();
                    maxisIncoming.CreatedDate = DateTime.Now;
                    maxisIncoming.ErrorMessage = errorMessage;
                    maxisIncoming.ExcutionTime = 0;
                    maxisIncoming.message = message;
                    maxisIncoming.MessageId = msgID;
                    maxisIncoming.MOResponse = MOresponse;
                    maxisIncoming.Msisdn = msisdn;
                    maxisIncoming.MTRequestUrl = url;
                    maxisIncoming.MTResponse = httpResponse;
                    maxisIncoming.OperationResult = Convert.ToString(Maxresponse);
                    maxisIncoming.Operator = operetor;
                    maxisIncoming.StatusCode = maxisResCode;
                    dc.MaxisIncomingProcessLogs.InsertOnSubmit(maxisIncoming);
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Insert In maxisLogs" + ex.Message, ex, msisdn, operetor);
            }
        }


        public static void InsertToSmscChargingLog(string srcAddress, string destAddress, string message,
                                                   bool askDeliveryReceipt, bool waitForDeliveryReceipt,
                                                   int deliveryReceiptWaitSeconds, string priority, string status,
                                                   int PriceDebited, string errorCode, string errorMessage, 
                                                    string referenceServiceId,string eventType,string options)
        {
            try
            {
                //using (var ta = new SmscChargingLogsTableAdapter())
                //{
                //    ta.Connection.ConnectionString =
                //        ConnectionString;

                //    ta.Insert(DateTime.Now, srcAddress, destAddress, referenceServiceId, message, askDeliveryReceipt,
                //              waitForDeliveryReceipt,
                //              deliveryReceiptWaitSeconds, priority, status, PriceDebited, errorCode, errorMessage, 
                //              eventType, options);
                //}

                //MsmqHelper.InsertInToSmscChargingLogQ(srcAddress, destAddress, message,
                //                                     askDeliveryReceipt, waitForDeliveryReceipt,
                //                                     deliveryReceiptWaitSeconds, priority, status,
                //                                     PriceDebited, errorCode, errorMessage,
                //                                      referenceServiceId, eventType, options);

            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
            }
        }


        public static void InsertToEtisalatChargingLog(string msisdn, string referenceServiceId, string eventType, string amount,
                                                 string chargingCode, string chargingRequest, string chargingResponse,
                                                 string chargingStatus, string errorMessage,
                                                 int executionTime, string options)
        {
            try
            {
                using (var ta = new EtisalatChargingLogsTableAdapter())
                {
                    ta.Connection.ConnectionString =
                        ConnectionString;
                    ta.Insert(DateTime.Now, msisdn, referenceServiceId, eventType, amount, chargingCode, chargingRequest, chargingResponse,
                        chargingStatus, errorMessage, executionTime, options);
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
            }
        }



        public static void InsertToDialogChargingLog(string msisdn, string serviceId, string amount, string result, string priceDebited,
                                               string sessionErrorCode, string sessionErrorMessage, string transactionErrorCode,
                                               string transactionErrorMessage, string appId, string password, string authenticationKey,
                                               string reasonCode, string domainId, bool taxable,
                                               int executionTime, string options)
        {
            try
            {
                /*   using (var ta = new DialogChargingLogTableAdapter())
                   {
                       ta.Connection.ConnectionString =
                           ConnectionString;
                       ta.Insert(DateTime.Now, msisdn, serviceId, amount, result, priceDebited, sessionErrorCode, sessionErrorMessage,
                                   transactionErrorCode, transactionErrorMessage, executionTime, appId, password, authenticationKey,
                                   reasonCode, domainId,taxable,  options);
                   }*/
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
            }
        }

        
    }
}