using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<Options> _options;
        public DataBaseContext(IOptions<Options> options)
        {
            _options = options;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            base.Database.EnsureCreated();
            //optionsBuilder.UseSqlite(_options.Value.SqliteConnectionString);
        }
    }
}
