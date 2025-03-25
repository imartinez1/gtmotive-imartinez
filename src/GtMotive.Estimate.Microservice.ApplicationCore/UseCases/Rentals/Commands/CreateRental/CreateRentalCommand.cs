using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental
{
    /// <summary>
    /// Create renatal command.
    /// </summary>
    public class CreateRentalCommand : IRequest<CreateRentalResponse>
    {
        /// <summary>
        /// Gets or sets userId.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets DateFrom.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets DateTo.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets VehicleId.
        /// </summary>
        public int VehicleId { get; set; }
    }
}
