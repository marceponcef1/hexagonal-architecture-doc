using System;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represents a rental transaction in the system. A rental transaction involves a customer, a vehicle, and a rental period.
    /// The rental transaction tracks the status of the rental, from pending to active to completed, and calculates the total cost of the rental based on the duration and the daily rate of the vehicle.
    /// </summary>
    public class Rental : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="customer">The customer who is renting the vehicle.</param>
        /// <param name="vehicle">The vehicle that is being rented.</param>
        /// <param name="period">The rental period.</param>
        public Rental(Customer customer, Vehicle vehicle, RentalPeriod period)
        {
            Customer = customer;
            Vehicle = vehicle;
            Period = period;
            Status = RentalStatus.Pending;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// Represents a rental transaction in the system.
        /// </summary>
        private Rental()
        {
        }

        /// <summary>
        /// Gets the customer who is renting the vehicle.
        /// </summary>
        public Customer Customer { get; private set; }

        /// <summary>
        /// Gets the vehicle that is being rented.
        /// </summary>
        public Vehicle Vehicle { get; private set; }

        /// <summary>
        /// Gets the rental period, start date and end date.
        /// </summary>
        public RentalPeriod Period { get; private set; }

        /// <summary>
        /// Gets or sets the status of the rental. This indicates whether the rental is pending, active, or completed.
        /// </summary>
        public RentalStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the rental. This is calculated based on the duration of the rental and the daily rate of the vehicle.
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Starts the rental. This changes the status of the rental to Active.
        /// Can only be called when the rental is in the Pending state.
        /// </summary>
        public void StartRental()
        {
            if (Status != RentalStatus.Pending)
            {
                throw new InvalidOperationException("Cannot start a rental that is not pending.");
            }

            Status = RentalStatus.Active;
        }

        /// <summary>
        /// Completes the rental. This changes the status of the rental to Completed.
        /// Can only be called when the rental is in the Active state.
        /// </summary>
        public void CompleteRental()
        {
            if (Status != RentalStatus.Active)
            {
                throw new InvalidOperationException("Cannot complete a rental that is not active.");
            }

            Status = RentalStatus.Completed;
        }

        /// <summary>
        /// Sets the rental period.
        /// </summary>
        /// <param name="startDate">The start date of the rental period.</param>
        /// <param name="endDate">The end date of the rental period.</param>
        public void SetRentalPeriod(DateTime startDate, DateTime endDate)
        {
            Period = new RentalPeriod(startDate, endDate);
        }

        /// <summary>
        /// Calculates the total cost of the rental based on the duration of the rental and the daily rate.
        /// Can only be called when the rental is in the Completed state.
        /// </summary>
        /// <param name="dailyRate">The daily rate for the rental.</param>
        public void CalculateTotalCost(decimal dailyRate)
        {
            if (Status != RentalStatus.Completed)
            {
                throw new InvalidOperationException("Cannot calculate the total cost of a rental that is not completed.");
            }

            var rentalDays = (Period.EndDate - Period.StartDate).Days + 1; // +1 to include both the start and end date
            TotalCost = rentalDays * dailyRate;
        }
    }
}
