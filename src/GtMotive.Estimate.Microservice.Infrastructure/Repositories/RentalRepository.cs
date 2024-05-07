using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Represents a repository for managing Rental entities in a database.
    /// </summary>
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        private readonly GtMotiveContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public RentalRepository(GtMotiveContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets all rentals for a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of rentals for the specified customer.</returns>
        public async Task<IEnumerable<Rental>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Set<Rental>()
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .Where(r => r.Customer.Id == customerId)
                .ToListAsync();
        }
    }
}
