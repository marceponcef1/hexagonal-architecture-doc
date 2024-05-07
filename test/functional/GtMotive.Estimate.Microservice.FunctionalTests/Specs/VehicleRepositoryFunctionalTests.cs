using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class VehicleRepositoryFunctionalTests
    {
        [Fact]
        public async Task AddVehicleAndRetrieveIt()
        {
            // Arrange
            // Create a new instance of DbContextOptions configured to use an in-memory database
            var options = new DbContextOptionsBuilder<GtMotiveContext>()
                .UseInMemoryDatabase(databaseName: "FunctionalTestDatabase")
                .Options;

            // Use that instance to create a new GtMotiveContext
            using var context = new GtMotiveContext(options);
            var repository = new VehicleRepository(context);

            // Create a new vehicle
            var vehicle = new Vehicle("Test Brand", "Test Model", "Test Color", DateOnly.FromDateTime(DateTime.Now.AddYears(-4)), "Test VIN", Guid.NewGuid());

            // Act
            // Add the vehicle to the repository and save changes
            await repository.AddAsync(vehicle);

            // Retrieve the vehicle from the database
            var savedVehicle = await repository.GetByIdAsync(vehicle.Id);

            // Assert
            // Verify that the vehicle has been saved correctly and can be retrieved
            Assert.NotNull(savedVehicle);
            Assert.Equal(vehicle.Brand, savedVehicle.Brand);
            Assert.Equal(vehicle.Model, savedVehicle.Model);
            Assert.Equal(vehicle.Color, savedVehicle.Color);
        }
    }
}
