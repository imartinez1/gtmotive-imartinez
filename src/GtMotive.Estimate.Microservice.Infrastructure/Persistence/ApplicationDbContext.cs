using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// ApplicationDbContext.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// ApplicationDbContext.
    /// </remarks>
    /// <param name="options">DbContextOptions.</param>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
#pragma warning disable
        /// <summary>
        /// Gets or sets Vehicles entities.
        /// </summary>
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// OnConfiguring.
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Suprimir la advertencia de cambios pendientes

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder != null)
            {
                SeedInitialData(modelBuilder);
            }
        }

        /// <summary>
        /// SeedInitialData.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        private static void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, RegistrationNumber = "6296HKZ", Brand = "Seat", Model = "Leon", Year = 2021},
                new Vehicle { Id = 2, RegistrationNumber = "6734IOP", Brand = "Volkswagen", Model = "Golf", Year = 2021 },
                new Vehicle { Id = 3, RegistrationNumber = "3462CVB", Brand = "Toyota", Model = "Corolla", Year = 2021 },
                new Vehicle { Id = 4, RegistrationNumber = "1982AYZ", Brand = "Ford", Model = "Focus", Year = 2022 },
                new Vehicle { Id = 5, RegistrationNumber = "4512ERX", Brand = "Renault", Model = "Megane", Year = 2023 },
                new Vehicle { Id = 6, RegistrationNumber = "7283LMN", Brand = "Peugeot", Model = "308", Year = 2022 },
                new Vehicle { Id = 7, RegistrationNumber = "9845BCD", Brand = "Hyundai", Model = "i30", Year = 2024 },
                new Vehicle { Id = 8, RegistrationNumber = "5621FGH", Brand = "Kia", Model = "Ceed", Year = 2021 },
                new Vehicle { Id = 9, RegistrationNumber = "3147QWE", Brand = "BMW", Model = "Serie 1", Year = 2023 },
                new Vehicle { Id = 10, RegistrationNumber = "8762RTY", Brand = "Audi", Model = "A3", Year = 2025 }
            );
        }
    }
}
#pragma warning restore
