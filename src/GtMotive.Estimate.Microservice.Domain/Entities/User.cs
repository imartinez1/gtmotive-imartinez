using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
#pragma warning disable
    /// <summary>
    /// User class.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        /// <summary>
        /// Gets or inits Reservations.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; init; }
    }
}
#pragma warning restore
