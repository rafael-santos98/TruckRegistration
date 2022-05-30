using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Infra.Data.Mappings
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck");

            builder.Property(c => c.Id)
               .HasColumnName("Id")
               .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Model)
                .HasColumnType("varchar(2)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.ModelYear)
                .HasColumnType("int")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.ManufactureYear)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
