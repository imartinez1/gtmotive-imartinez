using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Tests.Vehicles
{
    public class VehiclesInfrastructureTests
    {
        [Fact]
        public async Task PostVehicleShouldFailValidationWhenYearIsInvalid()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            await using var application = new TestWebApplication();
            var client = application.CreateClient();

            var invalidVehicle = new CreateVehicleRequest() { Model = "Model1", Brand = "Brand1", RegistrationNumber = "1212YYY", Year = 2000 };
            var content = new StringContent(JsonSerializer.Serialize(invalidVehicle), Encoding.UTF8, "application/json");

            var uri = new Uri(client.BaseAddress, "api/vehicles");
            var response = await client.PostAsync(uri, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("The vehicle cannot be older than 5 years", responseContent, StringComparison.OrdinalIgnoreCase);
        }
    }
}
