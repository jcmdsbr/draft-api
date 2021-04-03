using Core.Contracts;
using Infra.SQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.SQL
{
    public static class Bootstrapper
    {
        public static void AddRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = typeof(CustomContext).Namespace;
            var dbConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CustomContext>(options =>
                options.UseSqlServer(dbConnectionString,
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(assemblyName)
                )
            );
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}