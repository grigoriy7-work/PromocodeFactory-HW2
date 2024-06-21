using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain
{
    public class PromoCode: BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }  
    }
}
