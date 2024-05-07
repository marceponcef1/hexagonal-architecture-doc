using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Use case for creating a new vehicle.
    /// </summary>
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateVehicleOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository for working with vehicles.</param>
        /// <param name="outputPort">The output port for handling the result of the use case.</param>
        /// <param name="unitOfWork">The unit of work for working with repositories and managing transactions.</param>
        public CreateVehicleUseCase(
            IVehicleRepository vehicleRepository,
            ICreateVehicleOutputPort outputPort,
            IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                // Check if the vehicle exists, using the unique identifier Vehicle Identification Number
                var existingVehicle = await _vehicleRepository.GetByVINAsync(input.VIN);
                if (existingVehicle is not null)
                {
                    throw new VehicleAlreadyExistsException(input.VIN);
                }

                var vehicle = new Vehicle(input.Brand, input.Model, input.Color, input.ManufactureDate, input.VIN, input.FleetId);

                // Check if the vehicle can be created (e.g. it isn't more than 5 years old)
                var vehicleCanRent = _vehicleRepository.CanCreateVehicle(vehicle);
                if (!vehicleCanRent)
                {
                    throw new VehicleCannotBeCreatedException(vehicle.VIN);
                }

                await _unitOfWork.Vehicles.AddAsync(vehicle);
                await _unitOfWork.Save();

                var output = new CreateVehicleOutput(vehicle.Brand, vehicle.Model, vehicle.Color, vehicle.ManufactureDate, vehicle.VIN, vehicle.FleetId);
                _outputPort.StandardHandle(output);
            }
            catch (DomainException exception)
            {
                _outputPort.NotFoundHandle(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _outputPort.BadRequestHandle(exception.Message);
            }
        }
    }
}
