using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles
{
    /// <summary>
    /// GetVehiclesQueryHandler.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="GetVehiclesQueryHandler"/> class.
    /// </remarks>
    /// <param name="mapper">IMapper.</param>
    /// <param name="vehicleRepository">IBaseRepository.</param>
    public class GetVehiclesQueryHandler(IMapper mapper, IBaseRepository<Vehicle> vehicleRepository) : IRequestHandler<GetVehiclesQuery, ReadOnlyCollection<GetVehiclesResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseRepository<Vehicle> _vehicleRepository = vehicleRepository;

        /// <summary>
        /// GetAllVehiclesQueryHandler Handle.
        /// </summary>
        /// <param name="request">GetAllVehiclesQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle.</returns>
        public async Task<ReadOnlyCollection<GetVehiclesResponse>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            var data = await _vehicleRepository.Filtered(v => !v.Rentals.Any(), cancellationToken);
            return _mapper.Map<ReadOnlyCollection<GetVehiclesResponse>>(data);
        }
    }
}
