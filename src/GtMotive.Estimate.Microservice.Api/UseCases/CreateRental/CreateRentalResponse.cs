using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// Represents a response from the CreateRental use case.
    /// </summary>
    public class CreateRentalResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalResponse"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the created rental.</param>
        /// <param name="customerId">The ID of the customer who rented the vehicle.</param>
        /// <param name="vehicleId">The ID of the vehicle that was rented.</param>
        /// <param name="period">The rental period.</param>
        /// <param name="status">The status of the rental.</param>
        public CreateRentalResponse(Guid rentalId, Guid customerId, Guid vehicleId, RentalPeriod period, RentalStatus status)
        {
            RentalId = rentalId;
            CustomerId = customerId;
            VehicleId = vehicleId;
            Period = period;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalResponse"/> class.
        /// </summary>
        /// <param name="message">The message of the response.</param>
        public CreateRentalResponse(string message)
        {
            Message = message;
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

        /// <summary>
        /// Gets the message of the response.
        /// </summary>
        public string Message { get; }
    }
}
