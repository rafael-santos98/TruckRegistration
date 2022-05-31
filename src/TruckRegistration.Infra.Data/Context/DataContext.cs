using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDevPack.Messaging;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Infra.Data.Mappings;

namespace TruckRegistration.Infra.Data.Context
{
    public sealed class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Truck> Truck { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new TruckMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var inMemoryDatabase = bool.Parse(configuration.GetSection("InMemoryDatabase").Value);

                if (!inMemoryDatabase)
                {
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }
        }
    }
}
