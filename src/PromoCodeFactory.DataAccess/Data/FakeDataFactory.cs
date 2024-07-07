﻿using System;
using System.Collections.Generic;
using System.Linq;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static IList<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                RoleId = Roles.FirstOrDefault(x => x.Name == "Admin").Id,
                AppliedPromocodesCount = 5
            },
            new Employee()
            {
                Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                RoleId = Roles.FirstOrDefault(x => x.Name == "PartnerManager").Id,
                AppliedPromocodesCount = 10
            },
        };

        public static IList<Role> Roles => new List<Role>()
        {
            new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Admin",
                Description = "Администратор",
            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "PartnerManager",
                Description = "Партнерский менеджер"
            }
        };

        public static IList<Preference> Preferences => new List<Preference>()
        {
            new Preference()
            {
                Id = Guid.NewGuid(),
                Name = "Семья",
                PromoCodeId = null,
                CustomerPreferences = new List<CustomerPreference>()
            },
            new Preference()
            {
                Id = Guid.NewGuid(),
                Name = "Дети",
                PromoCodeId = null,
                CustomerPreferences = new List<CustomerPreference>()
            },
            new Preference()
            {
                Id = Guid.NewGuid(),
                Name = "Театр",
                PromoCodeId = null,
                CustomerPreferences = new List<CustomerPreference>()
            },
            new Preference()
            {
                Id = Guid.NewGuid(),
                Name = "Бизнес",
                PromoCodeId = null,
                CustomerPreferences = new List<CustomerPreference>()
            },
        };

        public static IList<Customer> Customers => new List<Customer>()
        {
        };
    }
}