using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            Database.EnsureCreated();
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

            modelBuilder.Entity<Role>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(r => r.Roles)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
