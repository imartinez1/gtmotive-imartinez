using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    public class RentalEntityConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable(ConfigurationConstants.Rental, ConfigurationConstants.Dbo);

            if (builder != null)
            {
                builder.HasKey(rental => rental.Id);

                builder.Property(rental => rental.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                builder.Property(rental => rental.DateFrom)
                    .IsRequired();

                builder.Property(rental => rental.DateTo)
                    .IsRequired();

                builder.Property(rental => rental.VehicleId)
                    .IsRequired();

                builder.HasOne(rental => rental.Vehicle)
                    .WithMany(vehicle => vehicle.Rentals)
                    .HasForeignKey(rental => rental.VehicleId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Property(rental => rental.UserId)
                    .IsRequired();

                builder.HasOne(rental => rental.User)
                    .WithMany(user => user.Rentals)
                    .HasForeignKey(rental => rental.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
