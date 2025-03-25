using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
#pragma warning disable
    /// <summary>
    /// Vehicle class.
    /// </summary>
    public class Vehicle : BaseDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        public Vehicle()
        {
            Rentals = new HashSet<Rental>();
        }

        /// <summary>
        /// Gets or sets Brand.
        /// </summary>]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets RegistrationNumber.
        /// </summary>]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets ManufacturingDate.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or inits Rentals.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; init; }
    }
}
#pragma warning restore
