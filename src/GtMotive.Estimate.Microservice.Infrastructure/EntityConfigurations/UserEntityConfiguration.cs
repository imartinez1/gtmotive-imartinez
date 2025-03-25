using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(ConfigurationConstants.User, ConfigurationConstants.Dbo);

            if (builder != null)
            {
                builder.HasKey(user => user.Id);

                builder.Property(user => user.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            }
        }
    }
}
