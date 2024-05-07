using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for returning a vehicle.
    /// </summary>
    public class ReturnVehicleUseCase : IReturnVehicleUseCase
    {
        private readonly IReturnVehicleOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="outputPort">The output port for handling the result of the use case.</param>
        /// <param name="unitOfWork">The unit of work for working with repositories and managing transactions.</param>
        public ReturnVehicleUseCase(
            IReturnVehicleOutputPort outputPort,
            IUnitOfWork unitOfWork)
        {
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(ReturnVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                // Check if the rental exists
                var rental = await _unitOfWork.Rentals.GetByIdAsync(input.RentalId)
                    ?? throw new RentalNotFoundException(input.RentalId);

                // Finish the rent
                rental.CompleteRental();

                // Update the rental using the method from the generic repository
                await _unitOfWork.Save();

                var output = new ReturnVehicleOutput(rental.Id);
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
