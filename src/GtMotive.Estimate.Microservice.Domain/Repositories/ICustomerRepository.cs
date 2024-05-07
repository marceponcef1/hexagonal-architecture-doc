using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Defines a repository for accessing Customer data.
    /// </summary>
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        /// <summary>
        /// Gets a customer by its DNI.
        /// </summary>
        /// <param name="dni">The DNI of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the customer if found, null otherwise.</returns>
        Task<Customer> GetByDniAsync(string dni);

        /// <summary>
        /// Determines if the customer is eligible to rent a vehicle.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the customer can rent a vehicle, false otherwise.</returns>
        Task<bool> CanRentAsync(Guid customerId);
    }
}
