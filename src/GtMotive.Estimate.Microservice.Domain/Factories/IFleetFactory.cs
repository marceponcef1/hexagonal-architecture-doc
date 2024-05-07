using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Factories
{
    /// <summary>
    /// Represents a factory for creating instances of the <see cref="Fleet"/> class.
    /// </summary>
    public interface IFleetFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        /// <returns>The newly created <see cref="Fleet"/> instance.</returns>
        Fleet Create();

        /// <summary>
        /// Creates a new instance of the <see cref="Fleet"/> class and adds an initial set of vehicles to the fleet.
        /// </summary>
        /// <param name="vehicles">The vehicles to add to the fleet.</param>
        /// <returns>A new instance of the <see cref="Fleet"/> class with the specified vehicles.</returns>
        Fleet CreateWithVehicles(IEnumerable<Vehicle> vehicles);
    }
}
