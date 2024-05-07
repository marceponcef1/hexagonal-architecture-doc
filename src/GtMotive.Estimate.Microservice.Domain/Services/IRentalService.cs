using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Defines a service for managing rentals.
    /// </summary>
    public interface IRentalService
    {
        /// <summary>
        /// Rents a vehicle to a customer.
        /// </summary>
        /// <param name="customer">The customer who is renting the vehicle.</param>
        /// <param name="vehicle">The vehicle that is being rented.</param>
        /// <param name="startDate">The start date of the rental period.</param>
        /// <param name="endDate">The end date of the rental period.</param>
        /// <returns>The created rental.</returns>
        Task<Rental> RentVehicleAsync(Customer customer, Vehicle vehicle, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Completes a rental.
        /// </summary>
        /// <param name="rental">The rental to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CompleteRentalAsync(Rental rental);
    }
}
