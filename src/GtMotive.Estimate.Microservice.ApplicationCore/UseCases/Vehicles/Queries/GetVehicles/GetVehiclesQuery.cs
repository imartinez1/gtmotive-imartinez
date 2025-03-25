using System;
using System.Collections.ObjectModel;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles
{
    /// <summary>
    /// GetVehiclesQuery.
    /// </summary>
    public class GetVehiclesQuery : IRequest<ReadOnlyCollection<GetVehiclesResponse>>
    {
        /// <summary>
        /// Gets or sets Year.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Gets or sets DateTo.
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
