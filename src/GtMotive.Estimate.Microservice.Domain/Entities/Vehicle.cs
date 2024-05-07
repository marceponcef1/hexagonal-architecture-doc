using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle entity, the domain model of a Vehicle.
    /// </summary>
    public class Vehicle : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="color">The color of the vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
        /// <param name="vin">The Vehicle Identification Number (VIN) of the vehicle.</param>
        /// <param name="fleetId">The unique identifier of the fleet that the vehicle belongs to.</param>
        public Vehicle(string brand, string model, string color, DateOnly manufactureDate, string vin, Guid fleetId)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ManufactureDate = manufactureDate;
            VIN = vin;
            FleetId = fleetId;

            if (VehicleMoreThan5Years())
            {
                throw new VehicleCannotBeCreatedException(vin);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// Represents a vehicle in the system.
        /// </summary>
        private Vehicle()
        {
        }

        /// <summary>
        /// Gets the brand of the vehicle. This is the name of the company that manufactured the vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the model of the vehicle. This is the specific name given to the vehicle by the manufacturer.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the color of the vehicle.
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Gets or sets the model year of the vehicle. This is the year that the manufacturer designed the model, which may be different from the manufacture date.
        /// </summary>
        public int ModelYear { get; set; }

        /// <summary>
        /// Gets or sets the fuel type of the vehicle. This indicates whether the vehicle runs on gasoline, diesel, electricity, etc.
        /// </summary>
        public FuelType FuelType { get; set; }

        /// <summary>
        /// Gets the Vehicle Identification Number (VIN) of the vehicle. The VIN is a unique code used to identify individual motor vehicles.
        /// </summary>
        public string VIN { get; private set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle. This is a unique identifier displayed on the vehicle, usually issued by a government authority.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the mileage of the vehicle. This is the total distance that the vehicle has traveled.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Gets or sets the type of the vehicle. This indicates whether the vehicle is a sedan, SUV, truck, etc.
        /// </summary>
        public VehicleType Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the vehicle. This indicates whether the vehicle is available, rented, in maintenance, etc.
        /// </summary>
        public VehicleStatus Status { get; set; }

        /// <summary>
        /// Gets the manufacture date of the vehicle. This is the date when the vehicle was actually produced.
        /// </summary>
        public DateOnly ManufactureDate { get; private set; }

        /// <summary>
        /// Gets or sets the first registration date of the vehicle. This is the date when the vehicle was first registered with a government authority.
        /// </summary>
        public DateOnly FirstRegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the last maintenance date of the vehicle. This is the date when the vehicle last underwent maintenance or a service check.
        /// </summary>
        public DateOnly LastMaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets the fleet that the vehicle belongs to.
        /// </summary>
        public Fleet Fleet { get; set; }

        /// <summary>
        /// Gets the unique identifier of the fleet that the vehicle belongs to.
        /// </summary>
        public Guid FleetId { get; private set; }

        /// <summary>
        /// Determines if the vehicle is available for rental.
        /// A vehicle is considered available if its status is set to Available.
        /// </summary>
        /// <returns>True if the vehicle is available, false otherwise.</returns>
        public bool IsAvailable()
        {
            // A vehicle is available if its status is Available
            return Status == VehicleStatus.Available;
        }

        /// <summary>
        /// Determines if the manufacture date of the vehicle is more than 5 years ago.
        /// </summary>
        /// <returns>True if the manufacture date is more than 5 years ago, false otherwise.</returns>
        public bool VehicleMoreThan5Years()
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            var fiveYearsAgo = currentDate.AddYears(-5);

            return ManufactureDate < fiveYearsAgo;
        }
    }
}
