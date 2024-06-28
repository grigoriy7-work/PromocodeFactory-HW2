using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class Customer: BaseEntity
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(100)]
        public string Email { get; set; }

        public virtual ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();

        public virtual ICollection<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();
    }
}
