using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TruckRegistration.Infra.Data.Context;

namespace TruckRegistration.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static readonly ILoggerFactory MyLoggerFactory =
           LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                }
           );

        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var inMemoryDatabase = bool.Parse(configuration.GetSection("InMemoryDatabase").Value);

            if (inMemoryDatabase)
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDatabase");
                    options.EnableSensitiveDataLogging();
                    options.UseLoggerFactory(MyLoggerFactory);
                });
            }
            else
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.UseLoggerFactory(MyLoggerFactory);
                });
            }
        }
    }
}
