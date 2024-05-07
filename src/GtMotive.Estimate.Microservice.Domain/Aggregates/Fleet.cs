using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represents a fleet of vehicles in the system. A fleet is a collection of vehicles that belong to the same rental service.
    /// The fleet tracks the vehicles that are part of it and provides operations to add and remove vehicles, as well as to get the list of available vehicles.
    /// </summary>
    public class Fleet : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        public Fleet()
        {
            Vehicles = new List<Vehicle>();
        }

        /// <summary>
        /// Gets the collection of vehicles that are part of the fleet. This collection includes all vehicles, regardless of their status.
        /// </summary>
        public ICollection<Vehicle> Vehicles { get; private set; }

        /// <summary>
        /// Adds a vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        /// <summary>
        /// Removes a vehicle from the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to remove.</param>
        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }

        /// <summary>
        /// Gets the collection of available vehicles in the fleet.
        /// </summary>
        /// <returns>A list of vehicles that are available for rent.</returns>
        public ICollection<Vehicle> GetAvailableVehicles()
        {
            return Vehicles.Where(v => v.Status == VehicleStatus.Available).ToList();
        }
    }
}
