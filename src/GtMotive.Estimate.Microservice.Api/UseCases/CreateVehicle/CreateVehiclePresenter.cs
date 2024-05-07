using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Presents the output of the CreateVehicle use case.
    /// </summary>
    public class CreateVehiclePresenter : ICreateVehiclePresenter, ICreateVehicleOutputPort
    {
        /// <summary>
        /// Gets the response from the use case.
        /// </summary>
        public IActionResult ActionResult { get; private set; }

        /// <summary>
        /// Handles the standard output of the use case.
        /// </summary>
        /// <param name="response">The output from the use case.</param>
        /// <exception cref="ArgumentNullException">Thrown when the response is null.</exception>
        public void StandardHandle(CreateVehicleOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var vehicleResponse = new CreateVehicleResponse(response.Brand, response.Model, response.Color, response.ManufactureDate, response.VIN);
            ActionResult = new OkObjectResult(vehicleResponse);
        }

        /// <summary>
        /// Handles the not found output of the use case.
        /// </summary>
        /// <param name="message">The not found message.</param>
        public void NotFoundHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        /// <summary>
        /// Handles the bad request output of the use case.
        /// </summary>
        /// <param name="message">The bad request message.</param>
        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
