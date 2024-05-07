using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Contracts
{
    /// <summary>
    /// Defines a unit of work using the repository pattern.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the vehicle repository.
        /// </summary>
        IVehicleRepository Vehicles { get; }

        /// <summary>
        /// Gets the rental repository.
        /// </summary>
        IRentalRepository Rentals { get; }

        /// <summary>
        /// Gets the customer repository.
        /// </summary>
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Gets the fleet repository.
        /// </summary>
        IFleetRepository Fleets { get; }

        /// <summary>
        /// Saves all changes made in this unit of work to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of objects written to the underlying database.</returns>
        Task<int> Save();
    }
}
