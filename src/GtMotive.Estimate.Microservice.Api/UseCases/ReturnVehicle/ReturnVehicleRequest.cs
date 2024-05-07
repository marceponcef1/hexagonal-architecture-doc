using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents a request to return a vehicle.
    /// </summary>
    public class ReturnVehicleRequest : IRequest<IReturnVehiclePresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleRequest"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the rental to be returned.</param>
        public ReturnVehicleRequest(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets the ID of the rental to be returned.
        /// </summary>
        public Guid RentalId { get; }
    }
}
