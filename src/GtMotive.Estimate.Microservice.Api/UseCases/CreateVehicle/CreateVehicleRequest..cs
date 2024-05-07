using MediatR;
using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents a request to create a vehicle.
    /// </summary>
    public class CreateVehicleRequest : IRequest<ICreateVehiclePresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleRequest"/> class with the specified brand, model, color, manufacture date, and VIN.
        /// </summary>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="color">The color of the vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
        /// <param name="vin">The Vehicle Identification Number (VIN) of the vehicle.</param>
        /// <param name="fleetId">The unique identifier of the fleet that the vehicle belongs to.</param>
        public CreateVehicleRequest(string brand, string model, string color, DateTime manufactureDate, string vin, Guid fleetId)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ManufactureDate = manufactureDate;
            VIN = vin;
            FleetId = fleetId;
        }

        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the color of the vehicle.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the manufacture date of the vehicle.
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets the Vehicle Identification Number (VIN) of the vehicle.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Gets the unique identifier of the fleet that the vehicle belongs to.
        /// </summary>
        public Guid FleetId { get; private set; }
    }
}
