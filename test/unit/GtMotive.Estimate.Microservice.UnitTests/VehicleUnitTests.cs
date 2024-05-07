using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class VehicleUnitTests
    {
        // This test checks if a vehicle is created correctly
        [Fact]
        public void CreatesVehicleCorrectly()
        {
            // Arrange
            var brand = "Brand";
            var vehiclemodel = "Model";
            var color = "Color";
            var manufactureDate = new DateOnly(2020, 1, 1);
            var vin = "VIN";
            var fleetId = Guid.NewGuid();

            // Act
            var vehicle = new Vehicle(brand, vehiclemodel, color, manufactureDate, vin, fleetId);

            // Assert
            Assert.Equal(brand, vehicle.Brand);
            Assert.Equal(vehiclemodel, vehicle.Model);
            Assert.Equal(color, vehicle.Color);
            Assert.Equal(manufactureDate, vehicle.ManufactureDate);
            Assert.Equal(vin, vehicle.VIN);
            Assert.Equal(fleetId, vehicle.FleetId);
        }

        // This test checks if a vehicle is available when it is not rented
        [Fact]
        public void IsAvailableWhenVehicleIsNotRentedReturnsTrue()
        {
            // Arrange
            var vehicle = new Vehicle("Brand", "Model", "Color", new DateOnly(2020, 1, 1), "VIN", Guid.NewGuid())
            {
                Status = VehicleStatus.Available
            };

            // Act
            var isAvailable = vehicle.IsAvailable();

            // Assert
            Assert.True(isAvailable);
        }

        // This test checks if a vehicle is not available when it is rented
        [Fact]
        public void IsAvailableWhenVehicleIsRentedReturnsFalse()
        {
            // Arrange
            var vehicle = new Vehicle("Brand", "Model", "Color", new DateOnly(2020, 1, 1), "VIN", Guid.NewGuid())
            {
                Status = VehicleStatus.Rented
            };

            // Act
            var isAvailable = vehicle.IsAvailable();

            // Assert
            Assert.False(isAvailable);
        }

        // This test checks if the status of a vehicle changes correctly
        [Fact]
        public void ChangeStatusWhenVehicleIsRentedChangesStatusCorrectly()
        {
            // Arrange
            var vehicle = new Vehicle("Brand", "Model", "Color", new DateOnly(2020, 1, 1), "VIN", Guid.NewGuid())
            {
                Status = VehicleStatus.Available
            };

            // Act
            vehicle.Status = VehicleStatus.Rented;

            // Assert
            Assert.Equal(VehicleStatus.Rented, vehicle.Status);
        }

        [Fact]
        public void VehicleCreationLessThan5Years()
        {
            // Arrange
            var brand = "Brand";
            var vehiclemodel = "Model";
            var color = "Color";
            var vin = "VIN";
            var manufactureDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-4));
            var fleetId = Guid.NewGuid();

            // Act
            var vehicle = new Vehicle(brand, vehiclemodel, color, manufactureDate, vin, fleetId);

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal(manufactureDate, vehicle.ManufactureDate);
        }

        [Fact]
        public void ShouldThrowVehicleCannotBeCreatedException()
        {
            // Arrange
            var brand = "Brand";
            var vehiclemodel = "Model";
            var color = "Color";
            var vin = "VINABCD";
            var manufactureDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-7));
            var fleetId = Guid.NewGuid();

            // Act
            var exception = Record.Exception(() => new Vehicle(brand, vehiclemodel, color, manufactureDate, vin, fleetId));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<VehicleCannotBeCreatedException>(exception);
        }
    }
}
