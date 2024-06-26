using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class Preference: BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<CustomerPreference> CustomerPreferences { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
