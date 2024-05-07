using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Represents a repository for managing vehicles in a database.
    /// </summary>
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly GtMotiveContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public VehicleRepository(GtMotiveContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets all available vehicles for a specific fleet.
        /// </summary>
        /// <param name="fleetId">The Guid of the fleet.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of vehicles if found, null otherwise.</returns>
        public async Task<ICollection<Vehicle>> GetAllAvailableVehiclesAsync(Guid fleetId)
        {
            return await _context.Vehicles
                .Where(v => v.FleetId == fleetId && v.Status == VehicleStatus.Available)
                .ToListAsync();
        }

        /// <summary>
        /// Gets an available vehicle by its Guid.
        /// </summary>
        /// <param name="vehicleId">The Guid of the vehicle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the vehicle if it is available, null otherwise.</returns>
        public async Task<Vehicle> GetAvailableVehicleAsync(Guid vehicleId)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.Id == vehicleId && v.Status == VehicleStatus.Available);
        }

        /// <summary>
        /// Gets a vehicle by its VIN (Vehicle Identification Number).
        /// </summary>
        /// <param name="vin">The VIN of the vehicle.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the vehicle if found, null otherwise.</returns>
        public async Task<Vehicle> GetByVINAsync(string vin)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.VIN == vin);
        }

        /// <summary>
        /// Determines if a vehicle could be created based on certain conditions.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>True if the vehicle could be created, false otherwise.</returns>
        public bool CanCreateVehicle(Vehicle vehicle)
        {
            return vehicle != null && !vehicle.VehicleMoreThan5Years();
        }
    }
}
