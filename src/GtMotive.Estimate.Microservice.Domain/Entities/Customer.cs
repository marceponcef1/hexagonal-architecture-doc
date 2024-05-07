using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Common;
using System.Linq;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <param name="dni">The DNI or ID of the customer.</param>
        public Customer(string firstName, string lastName, string phoneNumber, string dni)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Dni = dni;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// Represents a customer in the system.
        /// </summary>
        private Customer()
        {
        }

        /// <summary>
        /// Gets the first name of the customer.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name of the customer.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Gets the DNI ("Documento Nacional de Identidad") of the customer. The ID of the customer.
        /// </summary>
        public string Dni { get; private set; }

        /// <summary>
        /// Gets or sets the email of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the customer.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets the collection of rentals associated with the customer.
        /// This navigation property allows access to the other side of the Customer-Rental relationship.
        /// </summary>
        public ICollection<Rental> Rentals { get; private set; }

        /// <summary>
        /// Determines if the customer is eligible to rent a vehicle.
        /// A customer can rent a vehicle if they don't have any active rentals.
        /// </summary>
        /// <returns>True if the customer can rent a vehicle or if there isn't any active rental, false otherwise.</returns>
        public bool CanRent()
        {
            // If there isn't any active rental, the customer can rent
            if (Rentals == null || Rentals.Count == 0)
            {
                return true;
            }

            // A customer can rent if they don't have any active rentals
            return !Rentals.Any(rental => rental.Status != RentalStatus.Completed);
        }
    }
}
