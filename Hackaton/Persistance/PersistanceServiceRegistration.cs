using Application.AccountTypes.Contracts;
using Application.TransactionTypes.Contracts;
using Application.UserTypes.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistanceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HackatonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
