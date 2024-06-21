using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class Customer: BaseEntity
    {
        public virtual ICollection<Preference> Preferences { get; set; }

        public virtual ICollection<PromoCode> PromoCodes { get; set; }
    }
}
