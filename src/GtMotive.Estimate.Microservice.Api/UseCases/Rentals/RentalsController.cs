using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Common;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.Commands.DeleteRental;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// /// Initializes a new instance of the <see cref="RentalsController"/> class.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RentalsController(IMapper mapper, IMediator mediator, UserManager<User> userManager)
            : base(userManager)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreateRentalResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] CreateRentalRequest request, CancellationToken cancellationToken)
        {
            if (UserId == null)
            {
                return Unauthorized();
            }

            var command = _mapper.Map<CreateRentalCommand>(request, opt => opt.AfterMap((src, dest) => dest.UserId = UserId.Value));
            var result = await _mediator.Send(command, cancellationToken);

            return !result.Success ? BadRequest(result.ErrorMessage) : Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeleteRentalResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Delete([FromRoute] DeleteRentalRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<DeleteRentalCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return !result.Success ? result.ErrorMessage == "Rental Not Found" ? NotFound(result) : BadRequest(result) : Ok(result);
        }
    }
}
