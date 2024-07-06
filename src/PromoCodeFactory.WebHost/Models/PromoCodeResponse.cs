using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class PromoCodeResponse
    {
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PartnerName { get; set; }

        public PreferenceResponse Preference { get; set; }
    }
}
