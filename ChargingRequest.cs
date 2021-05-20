#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Framework.ChargingLibrary
{
    [DataContract]
    public class ChargingRequest
    {
        [DataMember]
        public string Msisdn { get; set; }
        public string RequestType { get; set; }
        public string CGTransactionId { get; set; }

        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string OperatorId { get; set; }

        [DataMember]
        public string Circle { get; set; }

        [DataMember]
        public Core.ChannelType Channel { get; set; }

        [DataMember]
        public int ThreadId { get; set; }

        [DataMember]
        public ChargingEventType EventType { get; set; }

        [DataMember]
        public string ServiceId { get; set; }

        [DataMember]
        public string ChargingCommand { get; set; }

        [DataMember]
        public string ValidationCommand { get; set; }

        [DataMember]
        public string FallbackPricePoints { get; set; }

        [DataMember]
        public string FallbackValidityDays { get; set; }

        [DataMember]
        public string FallbackChargingCodes { get; set; }

        [DataMember]
        public DateTime? UserValidityEndDate { get; set; }

        [DataMember]
        public string ChargingParameters { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string UserAgent { get; set; }

        [DataMember]
        public string ShortCode { get; set; }

        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public string TransactionId { get; set; }

        [DataMember]
        public string MsgId { get; set; }

        [DataMember]
        public string WapInterfaceID { get; set; }

        public string ManualId { get; set; }
        public bool IsTrial { get; set; }
        public string PSource { get; set; }
        public DateTime SubUserCreatedDate { get; set; }
        public string MsisdnType { get; set; }
        public string ProductID { get; set; }
        public string customerNo { get; set; }
    }

    public enum ChargingEventType
    {
        Subscribe,
        Unsubscribe,
        None,
        Renew,
        Event
    }
}