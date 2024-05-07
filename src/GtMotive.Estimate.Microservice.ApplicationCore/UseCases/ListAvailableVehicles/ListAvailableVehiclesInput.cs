using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Input for the ListAvailableVehiclesUseCase. Contains the fleetId for which the available vehicles are to be listed.
    /// </summary>
    public class ListAvailableVehiclesInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesInput"/> class.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        public ListAvailableVehiclesInput(Guid fleetId)
        {
            FleetId = fleetId;
        }

        /// <summary>
        /// Gets the ID of the fleet.
        /// </summary>
        public Guid FleetId { get; }
    }
}
