using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain
{
    public class Preference: BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public Guid? PromoCodeId { get; set; }

        public ICollection<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();

        public virtual ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
