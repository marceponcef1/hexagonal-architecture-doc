using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents a response from the ReturnVehicle use case.
    /// </summary>
    public class ReturnVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleResponse"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the returned rental.</param>
        public ReturnVehicleResponse(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets the ID of the returned rental.
        /// </summary>
        public Guid RentalId { get; }
    }
}
