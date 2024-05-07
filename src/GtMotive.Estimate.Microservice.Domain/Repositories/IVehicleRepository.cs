using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Defines a repository for accessing Vehicle data.
    /// </summary>
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        /// <summary>
        /// Gets all available vehicles for a specific fleet.
        /// </summary>
        /// <param name="fleetId">The Guid of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of vehicles if found, null otherwise.</returns>
        Task<ICollection<Vehicle>> GetAllAvailableVehiclesAsync(Guid fleetId);

        /// <summary>
        /// Gets an available vehicle by its Guid.
        /// </summary>
        /// <param name="vehicleId">The Guid of the vehicle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the vehicle if it is available, null otherwise.</returns>
        Task<Vehicle> GetAvailableVehicleAsync(Guid vehicleId);

        /// <summary>
        /// Gets a vehicle by its VIN (Vehicle Identification Number).
        /// </summary>
        /// <param name="vin">The VIN of the vehicle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the vehicle if found, null otherwise.</returns>
        Task<Vehicle> GetByVINAsync(string vin);

        /// <summary>
        /// Checks if a vehicle can be created.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>True if the vehicle can be created, false otherwise.</returns>
        bool CanCreateVehicle(Vehicle vehicle);
    }
}
