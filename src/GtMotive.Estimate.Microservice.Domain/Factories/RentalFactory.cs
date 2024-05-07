﻿using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Factories
{
    /// <summary>
    /// A factory for creating instances of the <see cref="Rental"/> class.
    /// </summary>
    public class RentalFactory : IRentalFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="customer">The customer who is renting the vehicle.</param>
        /// <param name="vehicle">The vehicle that is being rented.</param>
        /// <param name="period">The rental period.</param>
        /// <returns>A new instance of the <see cref="Rental"/> class with the specified customer, vehicle and rental period.</returns>
        public Rental Create(Customer customer, Vehicle vehicle, RentalPeriod period)
        {
            return new Rental(customer, vehicle, period);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Rental"/> class with a default end date.
        /// The default end date is calculated as a certain number of days after the start date.
        /// </summary>
        /// <param name="customer">The customer who is renting the vehicle.</param>
        /// <param name="vehicle">The vehicle that is being rented.</param>
        /// <param name="startDate">The start date of the rental period.</param>
        /// <param name="rentalDurationDays">The number of days for the rental period.</param>
        /// <returns>A new instance of the <see cref="Rental"/> class with the specified customer, vehicle, start date, and a default end date.</returns>
        public Rental CreateWithDefaultEndDate(Customer customer, Vehicle vehicle, DateTime startDate, int rentalDurationDays)
        {
            var endDate = startDate.AddDays(rentalDurationDays);
            var period = new RentalPeriod(startDate, endDate);
            return new Rental(customer, vehicle, period);
        }
    }
}
