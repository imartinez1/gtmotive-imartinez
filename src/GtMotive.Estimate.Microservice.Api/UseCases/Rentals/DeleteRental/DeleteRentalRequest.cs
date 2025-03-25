using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.DeleteRental
{
    public class DeleteRentalRequest
    {
        [JsonRequired]
        public int Id { get; set; }
    }
}
