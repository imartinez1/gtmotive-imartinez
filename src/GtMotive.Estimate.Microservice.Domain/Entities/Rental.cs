using System;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Rental class.
    /// </summary>
    public class Rental : BaseDomainModel
    {
        /// <summary>
        /// Gets or sets date from.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Id.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets Vehicle related object.
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets User related object.
        /// </summary>
        public virtual User User { get; set; }
    }
}
