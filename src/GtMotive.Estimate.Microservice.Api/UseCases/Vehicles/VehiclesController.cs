using AutoMapper;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Queries.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VehiclesController"/> class.
    /// </summary>
    /// <param name="mediator">IMediator.</param>
    /// <param name="mapper">IMapper.</param>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get all vehicles.
        /// </summary>
        /// <returns>List VehicleResponse.</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GetVehiclesResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new GetVehiclesQuery()));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreateVehicleResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Forbidden, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateVehicleCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return !result.Success ? BadRequest(result.ErrorMessage) : Ok(result);
        }
    }
}
