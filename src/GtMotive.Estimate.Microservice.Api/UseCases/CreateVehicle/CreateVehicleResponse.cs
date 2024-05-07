using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents a response from the CreateVehicle use case.
    /// </summary>
    public class CreateVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleResponse"/> class.
        /// </summary>
        /// <param name="brand">The brand of the created vehicle.</param>
        /// <param name="model">The model of the created vehicle.</param>
        /// <param name="color">The color of the created vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the created vehicle.</param>
        /// <param name="vin">The Vehicle Identification Number (VIN) of the created vehicle.</param>
        public CreateVehicleResponse(string brand, string model, string color, DateOnly manufactureDate, string vin)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ManufactureDate = manufactureDate;
            VIN = vin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleResponse"/> class.
        /// </summary>
        /// <param name="message">The message from the use case.</param>
        public CreateVehicleResponse(string message)
        {
            Message = message;
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
        /// Gets the message from the use case.
        /// </summary>
        public string Message { get; private set; }
    }
}
