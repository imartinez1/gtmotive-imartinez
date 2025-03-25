using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle
{
    /// <summary>
    /// CreateVehicleCommandHandler.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleCommandHandler"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">IBaseRepository.</param>
    /// <param name="mapper">IMapper.</param>
    /// <param name="logger">ILogger.</param>
    public class CreateVehicleCommandHandler(IBaseRepository<Vehicle> vehicleRepository, IMapper mapper, ILogger<CreateVehicleCommandHandler> logger) : IRequestHandler<CreateVehicleCommand, CreateVehicleResponse>
    {
        private readonly IBaseRepository<Vehicle> _vehicleRepository = vehicleRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateVehicleCommandHandler> _logger = logger;

        /// <summary>
        /// GetAllVehiclesQueryHandler Handle.
        /// </summary>
        /// <param name="request">GetAllVehiclesQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle.</returns>
        public async Task<CreateVehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new CreateVehicleResponse() { Success = false, ErrorMessage = "Invalid request" };
            }

            try
            {
                var newVehicle = new Vehicle
                {
                    Year = request.Year,
                    RegistrationNumber = request.RegistrationNumber,
                    Model = request.Model,
                    Brand = request.Brand,
                };

                var createdVehicle = await _vehicleRepository.Create(newVehicle, cancellationToken);
                return _mapper.Map<CreateVehicleResponse>(createdVehicle);
            }
            catch (DbException dbEx)
            {
                _logger.LogError(dbEx, "Database error occurred while creating a vehicle.");
                throw new CustomException("A database error occurred while creating the vehicle.", dbEx);
            }
        }
    }
}
