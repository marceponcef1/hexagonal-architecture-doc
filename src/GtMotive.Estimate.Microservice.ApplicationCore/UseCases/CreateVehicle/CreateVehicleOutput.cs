using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output for the CreateVehicleUseCase. Contains the details of the created vehicle.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="brand">The brand of the created vehicle.</param>
        /// <param name="model">The model of the created vehicle.</param>
        /// <param name="color">The color of the created vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the created vehicle.</param>
        /// <param name="vin">The Vehicle Identification Number (VIN) of the created vehicle.</param>
        /// <param name="fleetId">The unique identifier of the fleet that the vehicle belongs to.</param>
        public CreateVehicleOutput(string brand, string model, string color, DateOnly manufactureDate, string vin, Guid fleetId)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ManufactureDate = manufactureDate;
            VIN = vin;
            FleetId = fleetId;
        }

        /// <summary>
        /// Gets the brand of the created vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the model of the created vehicle.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the color of the created vehicle.
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Gets the manufacture date of the created vehicle.
        /// </summary>
        public DateOnly ManufactureDate { get; private set; }

        /// <summary>
        /// Gets the Vehicle Identification Number (VIN) of the created vehicle.
        /// </summary>
        public string VIN { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the fleet that the vehicle belongs to.
        /// </summary>
        public Guid FleetId { get; private set; }
    }
}
