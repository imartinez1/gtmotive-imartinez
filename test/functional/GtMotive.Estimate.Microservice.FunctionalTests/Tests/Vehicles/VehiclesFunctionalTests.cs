using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Tests.Vehicles
{
    /// <summary>
    /// VehiclesTests.
    /// </summary>
    public class VehiclesFunctionalTests : IClassFixture<SqlServerContainerFixture>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public VehiclesFunctionalTests(SqlServerContainerFixture fixture)
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(fixture.ConnectionString));

            services.AddAutoMapper(typeof(GetVehiclesQueryHandler));

            services.AddScoped<IBaseRepository<Vehicle>, BaseRepository<Vehicle>>();

            services.AddMediatR(typeof(GetVehiclesQueryHandler).Assembly);

            var provider = services.BuildServiceProvider();

            _mediator = provider.GetRequiredService<IMediator>();
            _context = provider.GetRequiredService<ApplicationDbContext>();
        }

        [Fact]
        public async Task GetVehiclesQueryShouldReturnAvailableVehicles()
        {
            var user = await CreateTestUserAsync();
            var vehicleToRent = await CreateTestRentedVehiclesAsync();
            await CreateTestRentalAsync(user.Id, vehicleToRent.Id);

            var query = new GetVehiclesQuery();
            var result = await _mediator.Send(query);

            Assert.NotNull(result);
            Assert.IsType<ReadOnlyCollection<GetVehiclesResponse>>(result);
            Assert.NotEmpty(result);
            Assert.DoesNotContain(result, v => v.Id == vehicleToRent.Id);
        }

        private async Task<User> CreateTestUserAsync()
        {
            var user = new User { Email = "test@test.com", UserName = "test@test.com", PasswordHash = "testhash" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task<Vehicle> CreateTestRentedVehiclesAsync()
        {
            var availableVehicles = new List<Vehicle>
            {
                new() { RegistrationNumber = "1234XYZ", Model = "Tesla" },
                new() { RegistrationNumber = "5678ABC", Model = "BMW" }
            };

            var rentedVehicle = new Vehicle { RegistrationNumber = "9999ZZZ", Model = "Audi" };

            _context.Vehicle.AddRange(availableVehicles);
            _context.Vehicle.Add(rentedVehicle);

            await _context.SaveChangesAsync();

            return rentedVehicle;
        }

        private async Task CreateTestRentalAsync(Guid userId, int vehicleId)
        {
            var rental = new Rental { UserId = userId, VehicleId = vehicleId };
            _context.Rental.Add(rental);
            await _context.SaveChangesAsync();
        }
    }
}
