using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }  
        public DbSet<CustomerPreference> CustomerPreferences { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //optionsBuilder.UseSqlite(_options.Value.SqliteConnectionString);
            modelBuilder.Entity<CustomerPreference>()
                .HasKey(cp => new { cp.CustomerId, cp.PreferenceId });

            modelBuilder.Entity<CustomerPreference>()
                .HasOne<Customer>(p => p.Customer)
                .WithMany(c => c.CustomerPreferences)
                .HasForeignKey(pc => pc.CustomerId);

            modelBuilder.Entity<CustomerPreference>()
                .HasOne<Preference>(p => p.Preference)
                .WithMany(c => c.CustomerPreferences)
                .HasForeignKey(pc => pc.PreferenceId);

            modelBuilder.Entity<Employee>()
                .HasOne<Role>(r => r.Role)
                .WithMany(e => e.Employees)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<PromoCode>()
                .HasOne<Employee>(e => e.PartnerManager)
                .WithMany(r => r.PromoCodes)
                .HasForeignKey(e => e.PartnerManagerId);

            modelBuilder.Entity<PromoCode>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(p => p.PromoCodes)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<PromoCode>()
               .HasOne<Preference>(p => p.Preference)
               .WithMany(p => p.PromoCodes)
               .HasForeignKey(x => x.PreferenceId);

            modelBuilder.Entity<Role>().HasData(FakeDataFactory.Roles);
            modelBuilder.Entity<Employee>().HasData(FakeDataFactory.Employees);
            //modelBuilder.Entity<Preference>().HasData(FakeDataFactory.Preferences);
        }
    }
}
