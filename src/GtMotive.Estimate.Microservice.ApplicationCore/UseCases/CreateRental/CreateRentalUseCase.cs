using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Factories;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Use case for creating a new rental.
    /// </summary>
    public class CreateRentalUseCase : ICreateRentalUseCase
    {
        private readonly ICreateRentalOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRentalFactory _rentalFactory;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalUseCase"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository for working with customers.</param>
        /// <param name="outputPort">The output port for handling the result of the use case.</param>
        /// <param name="unitOfWork">The unit of work for working with repositories and managing transactions.</param>
        /// <param name="rentalFactory">The rental factory for creating new rentals.</param>
        public CreateRentalUseCase(
            ICustomerRepository customerRepository,
            ICreateRentalOutputPort outputPort,
            IUnitOfWork unitOfWork,
            IRentalFactory rentalFactory)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _rentalFactory = rentalFactory ?? throw new ArgumentNullException(nameof(rentalFactory));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(CreateRentalInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                // Check if the customer exists
                var customer = await _unitOfWork.Customers.GetByIdAsync(input.CustomerId)
                    ?? throw new CustomerNotFoundException(input.CustomerId);

                // Check if the customer can rent
                var customerCanRent = await _customerRepository.CanRentAsync(customer.Id);
                if (!customerCanRent)
                {
                    throw new CustomerCannotRentException(input.CustomerId);
                }

                // Check if the vehicle exists
                var vehicle = await _unitOfWork.Vehicles.GetAvailableVehicleAsync(input.VehicleId)
                    ?? throw new VehicleNotFoundException(input.VehicleId);

                // Check if the vehicle is available
                if (!vehicle.IsAvailable())
                {
                    throw new VehicleNotAvailableException(input.VehicleId);
                }

                // Create and start the rental
                var rental = _rentalFactory.Create(customer, vehicle, input.Period);
                rental.StartRental();

                // Save the rental using the method from the generic repository
                await _unitOfWork.Rentals.AddAsync(rental);
                await _unitOfWork.Save();

                var output = new CreateRentalOutput(rental.Id, customer.Id, vehicle.Id, rental.Period, rental.Status);
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
