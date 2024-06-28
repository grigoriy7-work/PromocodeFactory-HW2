﻿using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class PromoCode: BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string PartnerName { get; set; }

        public Employee PartnerManager { get; set; }

        public Preference Preference { get; set; }

        public Customer Customer { get; set; }
    }
}
