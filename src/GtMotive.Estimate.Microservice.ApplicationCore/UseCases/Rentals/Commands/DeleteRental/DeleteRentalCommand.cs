using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental
{
    /// <summary>
    /// Create renatal command.
    /// </summary>
    public class DeleteRentalCommand : IRequest<DeleteRentalResponse>
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }
    }
}
