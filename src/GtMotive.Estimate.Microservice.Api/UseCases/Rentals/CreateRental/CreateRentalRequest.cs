using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.CreateRental
{
    public class CreateRentalRequest
    {
        [JsonRequired]
        public DateTime DateFrom { get; set; }

        [JsonRequired]
        public DateTime DateTo { get; set; }

        [JsonRequired]
        public int VehicleId { get; set; }
    }
}
