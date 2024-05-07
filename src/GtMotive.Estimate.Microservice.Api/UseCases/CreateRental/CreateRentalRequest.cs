using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// Represents a request to create a rental.
    /// </summary>
    public class CreateRentalRequest : IRequest<ICreateRentalPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalRequest"/> class.
        /// </summary>
        /// <param name="customerId">The ID of the customer who is renting the vehicle.</param>
        /// <param name="vehicleId">The ID of the vehicle that is being rented.</param>
        /// <param name="period">The rental period.</param>
        public CreateRentalRequest(Guid customerId, Guid vehicleId, RentalPeriod period)
        {
            CustomerId = customerId;
            VehicleId = vehicleId;
            Period = period;
        }

        /// <summary>
        /// Gets the ID of the customer who is renting the vehicle.
        /// </summary>
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the ID of the vehicle that is being rented.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the rental period.
        /// </summary>
        public RentalPeriod Period { get; }
    }
}
