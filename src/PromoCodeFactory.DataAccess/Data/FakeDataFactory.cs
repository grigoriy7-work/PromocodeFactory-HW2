using System;
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
                Id = Guid.Parse("f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9"),
                Name = "Семья",
                CustomerPreferences = new List<CustomerPreference>(),
                PromoCodes = new List<PromoCode>()
            },
            new Preference()
            {
                Id = Guid.Parse("237e6d2d-519a-42a6-859b-2f70ecacfb71"),
                Name = "Дети",
                CustomerPreferences = new List<CustomerPreference>(),
                PromoCodes = new List<PromoCode>()
            },
            new Preference()
            {
                Id = Guid.Parse("1a40591f-a22c-4300-aefa-29c12a093dd2"),
                Name = "Театр",
                CustomerPreferences = new List<CustomerPreference>(),
                PromoCodes = new List<PromoCode>()

            },
            new Preference()
            {
                Id = Guid.Parse("f1346ed6-d126-4cda-be54-8a37b18d87f9"),
                Name = "Бизнес",
                CustomerPreferences = new List<CustomerPreference>(),
                PromoCodes = new List<PromoCode>()
            },
        };

        public static IList<Customer> Customers => new List<Customer>()
        {
            new()
            {
                Id = Guid.Parse("2d56645d-84bb-40f5-adbc-6850c2d30ef9"),
                FirstName = "Синдзи",
                LastName = "Икари",
                Email = "shinji@mail.com",
            },
            new()
            {
                Id = Guid.Parse("119a2ebc-85e5-43b9-bd7c-097e52196373"),
                FirstName = "Мисато",
                LastName = "Кацураги",
                Email = "misato@mail.com",
            },
            new()
            {
                Id = Guid.Parse("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"),
                FirstName = "Рицуко",
                LastName = "Акаги",
                Email = "ritsuko@mail.com",
            }
        };

        public static IList<CustomerPreference> CustomerPreferences = new List<CustomerPreference>()
        {
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Синдзи").Id,
                PreferenceId = Preferences.First(p => p.Name == "Бизнес").Id
            },
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Синдзи").Id,
                PreferenceId = Preferences.First(p => p.Name == "Театр").Id
            },
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Мисато").Id,
                PreferenceId = Preferences.First(p => p.Name == "Театр").Id
            },
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Мисато").Id,
                PreferenceId = Preferences.First(p => p.Name == "Дети").Id
            },
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Рицуко").Id,
                PreferenceId = Preferences.First(p => p.Name == "Дети").Id
            },
            new()
            {
                CustomerId = Customers.First(c => c.FirstName == "Рицуко").Id,
                PreferenceId = Preferences.First(p => p.Name == "Семья").Id
            }
        };
    }
}