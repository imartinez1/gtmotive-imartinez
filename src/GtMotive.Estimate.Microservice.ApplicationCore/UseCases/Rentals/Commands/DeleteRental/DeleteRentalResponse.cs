using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental
{
    /// <summary>
    /// Delete Rental response.
    /// </summary>
    public class DeleteRentalResponse : ErrorMessageDto
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }
    }
}
