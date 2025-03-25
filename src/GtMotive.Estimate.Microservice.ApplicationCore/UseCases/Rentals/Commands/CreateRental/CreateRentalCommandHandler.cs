using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental
{
    /// <summary>
    /// CreateRentalCommandHandler.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateRentalCommandHandler"/> class.
    /// </remarks>
    /// <param name="rentalRepository">IBaseRepository.</param>
    /// <param name="mapper">IMapper.</param>
    /// <param name="logger">ILogger.</param>
    public class CreateRentalCommandHandler(IBaseRepository<Rental> rentalRepository, IMapper mapper, ILogger<CreateRentalCommandHandler> logger) : IRequestHandler<CreateRentalCommand, CreateRentalResponse>
    {
        private readonly IBaseRepository<Rental> _rentalRepository = rentalRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateRentalCommandHandler> _logger = logger;

        /// <summary>
        /// Handle rental creation request.
        /// </summary>
        /// <param name="request">CreateRentalCommand.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>CreateRentalResponse.</returns>
        public async Task<CreateRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new CreateRentalResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid request"
                };
            }

            var overlappingRental = await _rentalRepository.Filtered(r => r.UserId == request.UserId, cancellationToken);
            if (overlappingRental.Count != 0)
            {
                return new CreateRentalResponse
                {
                    Success = false,
                    ErrorMessage = "The user already has an active rental."
                };
            }

            try
            {
                var newRental = new Rental
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    VehicleId = request.VehicleId,
                    UserId = request.UserId
                };

                var res = await _rentalRepository.Create(newRental, cancellationToken);
                return _mapper.Map<CreateRentalResponse>(res);
            }
            catch (DbException dbEx)
            {
                _logger.LogError(dbEx, "Database error occurred while creating a rental.");
                throw new CustomException("A database error occurred while creating the rental.", dbEx);
            }
        }
    }
}
