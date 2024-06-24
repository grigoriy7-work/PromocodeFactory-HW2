using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class Customer: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Preference> Preferences { get; set; }

        public virtual ICollection<PromoCode> PromoCodes { get; set; }
    }
}
