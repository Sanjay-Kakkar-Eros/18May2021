using System;
using System.Runtime.Serialization;
using Framework.Core;

namespace Framework.ChargingLibrary
{
    [DataContract]
    public class ChargingResponse
    {
        public ChargingResponse()
        {
            DoUnSub = true;
        }
        [DataMember]
        public OperationResult Status { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string BalancePrice { get; set; }
        [DataMember]
        public string PriceDebited { get; set; }
        [DataMember]
        public DateTime? ValidityEndDate { get; set; }
        [DataMember]
        public bool DeleteUser { get; set; }
        [DataMember]
        public string  Optional { get; set; }
        [DataMember]
        public int ValidityInDays { get; set; }
        [DataMember]
        public MsisdnType MsisdnType { get; set; }
        [DataMember]
        public bool DoUnSub { get; set; }
        [DataMember]
        public string PartnerPrice { get; set; }
        [DataMember]
        public string Paswd { get; set; }

        public SubscriptionUserStatus UserSubStatus { get; set; }
    }
}
