using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Defines a service for managing fleets.
    /// </summary>
    public interface IFleetService
    {
        /// <summary>
        /// Adds a vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddVehicleAsync(Vehicle vehicle);

        /// <summary>
        /// Gets the available vehicles in the fleet.
        /// </summary>
        /// <returns>A collection of vehicles that are available in the fleet.</returns>
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
    }
}
