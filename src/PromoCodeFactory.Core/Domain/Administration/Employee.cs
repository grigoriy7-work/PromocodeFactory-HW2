﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Employee : BaseEntity
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";


        [MaxLength(100)]
        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public ICollection<Role> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}