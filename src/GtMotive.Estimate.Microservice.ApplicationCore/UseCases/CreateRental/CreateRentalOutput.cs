using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Output for the CreateRentalUseCase. Contains the details of the created rental.
    /// </summary>
    public class CreateRentalOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalOutput"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the created rental.</param>
        /// <param name="customerId">The ID of the customer who rented the vehicle.</param>
        /// <param name="vehicleId">The ID of the vehicle that was rented.</param>
        /// <param name="period">The rental period.</param>
        /// <param name="status">The status of the rental.</param>
        public CreateRentalOutput(Guid rentalId, Guid customerId, Guid vehicleId, RentalPeriod period, RentalStatus status)
        {
            RentalId = rentalId;
            CustomerId = customerId;
            VehicleId = vehicleId;
            Period = period;
            Status = status;
        }

        /// <summary>
        /// Gets the ID of the created rental.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the ID of the customer who rented the vehicle.
        /// </summary>
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the ID of the vehicle that was rented.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the rental period.
        /// </summary>
        public RentalPeriod Period { get; }

        /// <summary>
        /// Gets the status of the rental.
        /// </summary>
        public RentalStatus Status { get; }
    }
}
