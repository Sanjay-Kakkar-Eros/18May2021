#region

using System;
using Framework.Core;

#endregion

namespace Framework.ChargingLibrary
{
    public abstract class ChargingClient
    {
        public ChargingResponse DoCharging(ChargingRequest request)
        {
            if (Global.IsDoNotBill(request.Msisdn))
            {
                var response = new ChargingResponse { PriceDebited = "0", Status = OperationResult.Success };
                var validityDays = request.FallbackValidityDays.GetStringArrayFromCsv();
                if (validityDays != null && validityDays.Length > 0)
                    response.ValidityEndDate = DateTime.Now.AddDays(Convert.ToInt32(validityDays[0]));

                return response;
            }

            return DoChargingInternal(request);
        }

        protected abstract ChargingResponse DoChargingInternal(ChargingRequest request);
    }
}