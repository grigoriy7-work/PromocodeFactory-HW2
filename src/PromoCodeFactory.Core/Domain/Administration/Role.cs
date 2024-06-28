using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Role : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public Guid EmployeeId { get; set; }

        public ICollection<Employee> Employees { get; set; }  
    }
}