using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PromoCodeFactory.WebHost
{
    public static class Registrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<Options>().Bind(configuration);
            var options = configuration.Get<Options>();

            services.AddDbContext<DataBaseContext>(optionsBulder =>
            {
                //optionsBulder.UseSqlite(options.SqliteConnectionString);
                optionsBulder.UseNpgsql(options.PostgresConnectionString);
            });

            //services.AddSingleton(typeof(IRepository<Employee>), (x) =>
            //    new InMemoryRepository<Employee>(FakeDataFactory.Employees));

            var provider = services.BuildServiceProvider();
            var db = provider.GetRequiredService<DataBaseContext>();

            services.AddSingleton(typeof(IRepository<Employee>), (x) =>
              new EfRepository<Employee>(db));

            services.AddSingleton(typeof(IRepository<Customer>), (x) =>
              new EfRepository<Customer>(db));

            services.AddSingleton(typeof(IRepository<Role>), (x) =>
                new EfRepository<Role>(db));

            services.AddSingleton(typeof(IRepository<Preference>), (x) =>
                new EfRepository<Preference>(db));

            services.AddSingleton(typeof(IRepository<PromoCode>), (x) =>
               new EfRepository<PromoCode>(db));

            return services;   
        }
    }
}
