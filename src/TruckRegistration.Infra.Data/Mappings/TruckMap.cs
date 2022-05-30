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

            builder.Property(c => c.Origem)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Destino)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
        }
    }
}
