using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental
{
    /// <summary>
    /// DeleteRentalCommandHandler.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DeleteRentalCommandHandler"/> class.
    /// </remarks>
    /// <param name="rentalRepository">IBaseRepository.</param>
    /// <param name="mapper">IMapper.</param>
    /// <param name="logger">ILogger.</param>
    public class DeleteRentalCommandHandler(IBaseRepository<Rental> rentalRepository, IMapper mapper, ILogger<DeleteRentalCommandHandler> logger) : IRequestHandler<DeleteRentalCommand, DeleteRentalResponse>
    {
        private readonly IBaseRepository<Rental> _rentalRepository = rentalRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<DeleteRentalCommandHandler> _logger = logger;

        /// <summary>
        /// Handle rental creation request.
        /// </summary>
        /// <param name="request">DeleteRentalCommand.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>DeleteRentalResponse.</returns>
        public async Task<DeleteRentalResponse> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalToDelete = await _rentalRepository.GetOne(r => r.Id == request.Id, cancellationToken);
            if (rentalToDelete == null)
            {
                return new DeleteRentalResponse { Success = false, ErrorMessage = "Rental Not Found" };
            }

            try
            {
                await _rentalRepository.Delete(rentalToDelete, cancellationToken);
                return _mapper.Map<DeleteRentalResponse>(rentalToDelete);
            }
            catch (DbException dbEx)
            {
                _logger.LogError(dbEx, "Database error occurred while creating a rental.");
                throw new CustomException("A database error occurred while creating the rental.", dbEx);
            }
        }
    }
}
