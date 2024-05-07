using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Input for the CreateRentalUseCase.
    /// </summary>
    public class CreateRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalInput"/> class.
        /// </summary>
        /// <param name="customerId">The ID of the customer who is renting the vehicle.</param>
        /// <param name="vehicleId">The ID of the vehicle that is being rented.</param>
        /// <param name="period">The rental period.</param>
        public CreateRentalInput(Guid customerId, Guid vehicleId, RentalPeriod period)
        {
            CustomerId = customerId;
            VehicleId = vehicleId;
            Period = period;
        }

        /// <summary>
        /// Gets the ID of the customer who is renting the vehicle.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the ID of the vehicle that is being rented.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets the rental period.
        /// </summary>
        public RentalPeriod Period { get; private set; }
    }
}
