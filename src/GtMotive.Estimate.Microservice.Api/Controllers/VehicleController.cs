using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Represents a controller for managing vehicles.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator for handling requests.</param>
        public VehicleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="request">The request to create a vehicle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle(CreateVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Lists all available vehicles in a fleet.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        [HttpGet("ListAvailableVehicles/{fleetId}")]
        public async Task<IActionResult> ListAvailableVehicles(Guid fleetId)
        {
            var request = new ListAvailableVehiclesRequest(fleetId);
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
