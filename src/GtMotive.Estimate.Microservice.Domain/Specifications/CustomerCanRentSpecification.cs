using System;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Specifications
{
    /// <summary>
    /// Checks if a customer can rent a vehicle.
    /// A customer can rent a vehicle if they don't have any active rentals.
    /// </summary>
    public class CustomerCanRentSpecification : ISpecification<Customer>
    {
        /// <summary>
        /// Checks if the customer satisfies the specification.
        /// </summary>
        /// <param name="entity">The customer to check.</param>
        /// <returns>True if the customer satisfies the specification, false otherwise.</returns>
        public bool IsSatisfiedBy(Customer entity)
        {
            return entity is null ? throw new ArgumentNullException(nameof(entity)) : entity.CanRent();
        }
    }
}
