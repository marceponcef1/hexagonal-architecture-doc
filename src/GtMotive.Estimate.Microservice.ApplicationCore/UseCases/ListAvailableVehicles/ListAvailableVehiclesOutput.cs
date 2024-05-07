using GtMotive.Estimate.Microservice.Domain.Entities;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output for the ListAvailableVehiclesUseCase. Contains the list of available vehicles for a specific fleet.
    /// </summary>
    public class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The collection of available vehicles.</param>
        public ListAvailableVehiclesOutput(ICollection<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public ICollection<Vehicle> Vehicles { get; }
    }
}
