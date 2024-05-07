using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class FleetRepository : GenericRepository<Fleet>, IFleetRepository
    {
        private readonly GtMotiveContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public FleetRepository(GtMotiveContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets a fleet by its ID.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the fleet if found, null otherwise.</returns>
        public async Task<Fleet> GetFleetAsync(Guid fleetId)
        {
            return await _context.Fleets
                .Include(f => f.Vehicles)
                .FirstOrDefaultAsync(f => f.Id == fleetId);
        }

        /// <summary>
        /// Gets the collection of available vehicles in a fleet.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of vehicles if found, null otherwise.</returns>
        public async Task<ICollection<Vehicle>> GetAvailableVehiclesAsync(Guid fleetId)
        {
            var fleet = await GetFleetAsync(fleetId);
            return fleet?.GetAvailableVehicles();
        }
    }
}
