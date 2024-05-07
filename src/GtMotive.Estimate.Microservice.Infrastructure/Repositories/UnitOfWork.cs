using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Represents a unit of work using the repository pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GtMotiveContext _context;
        private bool _isDisposed;

        private IVehicleRepository _vehicles;
        private IRentalRepository _rentals;
        private ICustomerRepository _customers;
        private IFleetRepository _fleets;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UnitOfWork(GtMotiveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets the vehicle repository.
        /// </summary>
        public IVehicleRepository Vehicles => _vehicles ??= new VehicleRepository(_context);

        /// <summary>
        /// Gets the rental repository.
        /// </summary>
        public IRentalRepository Rentals => _rentals ??= new RentalRepository(_context);

        /// <summary>
        /// Gets the customer repository.
        /// </summary>
        public ICustomerRepository Customers => _customers ??= new CustomerRepository(_context);

        /// <summary>
        /// Gets the fleet repository.
        /// </summary>
        public IFleetRepository Fleets => _fleets ??= new FleetRepository(_context);

        /// <summary>
        /// Saves all changes made in this unit of work to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of objects written to the underlying database.</returns>
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes the current instance of the unit of work and all its repositories.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
