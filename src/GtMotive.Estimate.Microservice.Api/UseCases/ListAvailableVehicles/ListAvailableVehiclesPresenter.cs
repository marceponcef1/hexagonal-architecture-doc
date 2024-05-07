using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Presents the output of the ListAvailableVehicles use case.
    /// </summary>
    public class ListAvailableVehiclesPresenter : IListAvailableVehiclesPresenter, IListAvailableVehiclesOutputPort
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
        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var vehiclesResponse = new ListAvailableVehiclesResponse(response.Vehicles);
            ActionResult = new OkObjectResult(vehiclesResponse);
        }

        /// <summary>
        /// Handles the not found output of the use case.
        /// </summary>
        /// <param name="message">The not found message.</param>
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
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
