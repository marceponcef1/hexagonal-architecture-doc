using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input message for returning a vehicle.
    /// </summary>
    public class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the rental to be returned.</param>
        public ReturnVehicleInput(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets the ID of the rental to be returned.
        /// </summary>
        public Guid RentalId { get; }
    }
}
