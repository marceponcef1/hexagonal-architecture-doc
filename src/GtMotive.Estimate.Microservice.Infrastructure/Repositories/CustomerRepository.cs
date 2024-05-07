using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly GtMotiveContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public CustomerRepository(GtMotiveContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets a customer by its DNI.
        /// </summary>
        /// <param name="dni">The DNI of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the customer if found, null otherwise.</returns>
        public async Task<Customer> GetByDniAsync(string dni)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Dni == dni);
        }

        /// <summary>
        /// Determines if the customer is eligible to rent a vehicle.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the customer can rent a vehicle, false otherwise.</returns>
        public async Task<bool> CanRentAsync(Guid customerId)
        {
            var customer = await _context.Customers
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            return customer.CanRent();
        }
    }
}
