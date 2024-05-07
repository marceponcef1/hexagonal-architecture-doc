using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Represents a response from the ListAvailableVehicles use case.
    /// </summary>
    public class ListAvailableVehiclesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesResponse"/> class.
        /// </summary>
        /// <param name="vehicles">The collection of available vehicles.</param>
        public ListAvailableVehiclesResponse(ICollection<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public ICollection<Vehicle> Vehicles { get; }
    }
}
