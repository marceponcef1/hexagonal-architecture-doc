using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Handles the creation of a vehicle.
    /// </summary>
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, ICreateVehiclePresenter>
    {
        private readonly ICreateVehicleUseCase _useCase;
        private readonly ICreateVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleHandler"/> class.
        /// </summary>
        /// <param name="useCase">The use case for creating a vehicle.</param>
        /// <param name="presenter">The presenter for handling the output of the use case.</param>
        public CreateVehicleHandler(ICreateVehicleUseCase useCase, ICreateVehiclePresenter presenter)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        /// <summary>
        /// Handles the request to create a vehicle.
        /// </summary>
        /// <param name="request">The request to create a vehicle.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the use case.</returns>
        public async Task<ICreateVehiclePresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var manufactureDate = DateOnly.FromDateTime(request.ManufactureDate);
            var input = new CreateVehicleInput(request.Brand, request.Model, request.Color, manufactureDate, request.VIN, request.FleetId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
