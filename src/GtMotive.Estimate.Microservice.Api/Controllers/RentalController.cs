using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Represents a controller for managing rentals.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator for handling requests.</param>
        public RentalController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates a new rental.
        /// </summary>
        /// <param name="request">The request to create a rental.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        [HttpPost("CreateRental")]
        public async Task<IActionResult> CreateRental(CreateRentalRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Returns a rental vehicle.
        /// </summary>
        /// <param name="rentalId">The ID of the rental to be returned.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        [HttpPost("ReturnVehicle/{rentalId}")]
        public async Task<IActionResult> ReturnVehicle(Guid rentalId)
        {
            var request = new ReturnVehicleRequest(rentalId);
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
