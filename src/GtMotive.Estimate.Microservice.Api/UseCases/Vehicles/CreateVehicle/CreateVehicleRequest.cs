using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    public class CreateVehicleRequest
    {
        [JsonRequired]
        public string RegistrationNumber { get; set; }

        [JsonRequired]
        public int Year { get; set; }

        [JsonRequired]
        public string Brand { get; set; }

        [JsonRequired]
        public string Model { get; set; }
    }
}
