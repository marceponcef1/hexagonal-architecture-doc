using System;
using System.Linq;
using System.Reflection;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    /// <summary>
    /// Represents the database context of the GtMotive application.
    /// </summary>
    public class GtMotiveContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GtMotiveContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public GtMotiveContext(DbContextOptions<GtMotiveContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the set of Customers in the context.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the set of Vehicles in the context.
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets the set of Fleets in the context.
        /// </summary>
        public DbSet<Fleet> Fleets { get; set; }

        /// <summary>
        /// Gets or sets the set of Rentals in the context.
        /// </summary>
        public DbSet<Rental> Rentals { get; set; }

        /// <summary>
        /// Initializes the data in the context.
        /// </summary>
        public void InitializeData()
        {
            var fixedFleetId = new Guid("00000000-0000-0000-0000-000000000001");
            var fixedCustomerId = new Guid("00000000-0000-0000-0000-000000000002");
            var vehicleId = new Guid("00000000-0000-0000-0000-000000000003");

            if (!Fleets.Any() && !Vehicles.Any())
            {
                var fleet = Fleets.Add(new Fleet()).Entity;
                fleet.GetType().GetProperty("Id").SetValue(fleet, fixedFleetId, null);

                var vehicle = Vehicles.Add(new Vehicle("Ford", "Focus", "Blue", DateOnly.FromDateTime(DateTime.Now), "1FTEF14N0LNB14869", fleet.Id)).Entity;
                vehicle.GetType().GetProperty("Id").SetValue(vehicle, vehicleId, null);

                fleet.Vehicles.Add(vehicle);
                Vehicles.Add(vehicle);
            }

            if (!Customers.Any())
            {
                var customer = Customers.Add(new Customer("Juan", "Pérez", "911 222 333", "12345678A")).Entity;
                customer.GetType().GetProperty("Id").SetValue(customer, fixedCustomerId, null);
            }

            SaveChanges();
        }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Rental>().OwnsOne(r => r.Period);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
