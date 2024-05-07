using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Defines a repository for accessing Fleet data.
    /// </summary>
    public interface IFleetRepository : IGenericRepository<Fleet>
    {
        /// <summary>
        /// Gets a fleet by its ID.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the fleet if found, null otherwise.</returns>
        Task<Fleet> GetFleetAsync(Guid fleetId);

        /// <summary>
        /// Gets the collection of available vehicles in a fleet.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of vehicles if found, null otherwise.</returns>
        Task<ICollection<Vehicle>> GetAvailableVehiclesAsync(Guid fleetId);
    }
}
