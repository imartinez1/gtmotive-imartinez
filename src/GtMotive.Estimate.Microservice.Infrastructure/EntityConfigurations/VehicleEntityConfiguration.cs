using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(ConfigurationConstants.Vehicle, ConfigurationConstants.Dbo);

            if (builder != null)
            {
                builder.HasKey(vehicle => vehicle.Id);

                builder.Property(vehicle => vehicle.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                builder.Property(vehicle => vehicle.RegistrationNumber).IsRequired().HasMaxLength(7);
                builder.Property(vehicle => vehicle.Year).IsRequired();
            }
        }
    }
}
