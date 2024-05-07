using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Use case for listing all available vehicles of a specific fleet.
    /// </summary>
    public class ListAvailableVehiclesUseCase : IListAvailableVehiclesUseCase
    {
        private readonly IListAvailableVehiclesOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="outputPort">The output port for handling the result of the use case.</param>
        /// <param name="unitOfWork">The unit of work for working with repositories.</param>
        public ListAvailableVehiclesUseCase(
            IListAvailableVehiclesOutputPort outputPort,
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
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var fleet = await _unitOfWork.Fleets.GetFleetAsync(input.FleetId) ?? throw new FleetNotFoundException(input.FleetId);
                var vehicles = fleet.GetAvailableVehicles();

                var output = new ListAvailableVehiclesOutput(vehicles);
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
