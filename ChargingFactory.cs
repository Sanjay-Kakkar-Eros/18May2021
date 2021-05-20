using Framework.ChargingLibrary.ChargingClients;
//using TZPLATFORM.Charging;

namespace Framework.ChargingLibrary
{
    public class ChargingFactory
    {
        public static ChargingClient Lookup(string chargingClient)
        {
            switch (chargingClient.ToUpper())
            {
                case "SAPI":
                    return new AirtelSapiClient();
                case "AXIATAAOCCHARGINGCLIENT":
                    return new AxiataAOCChargingClient();
                case "AXIATAAOCDIRECT":
                    return new AxiataAOCDirectChargingClient();
                case "AIRTELAFCHARGINGCLIENT":
                    return new AirtelAfricaChargingClient();
                case "AIRTELSUBENGINE":
                    return new AirtelSubEngChargingClient();
                case "AXIATACHARGINGCLIENT":
                    return new AxiataChargingClient();
                case "GENERICHTTP":
                    return new GenericHttpChargingClient();
                case "MTNL":
                case "SMSC":
                    return new SmscChargingClient();
                case "ETISALAT":
                    return new EtisalatHttpChargingClient();
                case "MALAYSIANCHARGINGCLIENT":
                    return new MalaysianChargingClient();
                case "AIRTELSL":
                    return new AirtelSrilankaOcsChargingClient();
                case "AIRTELLKMBAS":
                    return new MBasChargingClient();
                case "HUTCHLK":
                    return new HutchSrilankaChargingClient();
                case "HUTCHLKCG":
                    return new HutchSriLankaChargingClientV1();
                case "MOBITEL":
                    return new MobitelSrilankaChargingClient();
                //case "DIALOGLK":
                //    return new DialogChargingClient();
                case "DIALOGLKSDPCG":
                    return new DialogCgChargingClient();
                case "UMOBILECHARGING":
                    return new UMobileChargingClient();
                case "DUTIMWE":
                    return new DuTimweChargingClient();
                case "DIGICELFJ":
                    return new DigicelFJChargingClient();
                case "MAXISNDS":
                    return new MaxisNdsChargingClient();
                case "OOREDOOTIMWE":
                    return new OoredooTimweChargingClient();
                case "OOREDOOTIMWEV1":
                    return new OoredooTimweChargingClientV1();
                case "OOREDOOKW":
                    return new OoredooKwtChargingClient();
                case "TIMWESMSC":
                    return new TimweSmscChargingClient();
                case "TIMWEDCB":
                    return new TimweDCBChargingClient();
                case "DIMOCO":
                    return new DimocoChargingClient();
                case "DIGIMYTL":
                    return new TelenorDigiChargingClient();
                case "DIGIMY":
                    return new DigiOTTChargingClient();
                case "UMOBILEOTTCHARGING":
                    return new UmobileOTTChargingClient();
                case "KIOSKTH": 
                    return new KioskTlChargingClient();
                case "MOBITELLKGAMES":
                    return new MobitelGamesChargingClient();
                case "TPAY":
                    return new TpayChargingClient();
                case "ZAINFOO":
                    return new FooChargingClient();
                case "VODATIMWE":
                    return new VodaTimweChargingClient();
                case "MTNAFGHANISTAN":
                    return new MtnAfghanistanChargingClient();
                default:
                    return null;
            }
        }
    }
}
