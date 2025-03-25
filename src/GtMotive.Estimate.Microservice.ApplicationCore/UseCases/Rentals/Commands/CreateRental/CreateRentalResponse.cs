using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental
{
    /// <summary>
    /// Create Rental response.
    /// </summary>
    public class CreateRentalResponse : ErrorMessageDto
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

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
