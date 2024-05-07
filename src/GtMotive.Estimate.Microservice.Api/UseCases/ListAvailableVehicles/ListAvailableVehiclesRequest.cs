using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Represents a request to list available vehicles.
    /// </summary>
    public class ListAvailableVehiclesRequest : IRequest<IListAvailableVehiclesPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesRequest"/> class.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet.</param>
        public ListAvailableVehiclesRequest(Guid fleetId)
        {
            FleetId = fleetId;
        }

        /// <summary>
        /// Gets the ID of the fleet.
        /// </summary>
        public Guid FleetId { get; }
    }
}
