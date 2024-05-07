using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output message for returning a vehicle.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the returned rental.</param>
        public ReturnVehicleOutput(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets the ID of the returned rental.
        /// </summary>
        public Guid RentalId { get; }
    }
}
