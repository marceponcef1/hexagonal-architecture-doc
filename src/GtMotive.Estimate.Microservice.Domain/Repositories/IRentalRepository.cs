using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Defines a repository for accessing Rental data.
    /// </summary>
    public interface IRentalRepository : IGenericRepository<Rental>
    {
        /// <summary>
        /// Gets all rentals for a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of rentals for the specified customer.</returns>
        Task<IEnumerable<Rental>> GetByCustomerIdAsync(Guid customerId);
    }
}
