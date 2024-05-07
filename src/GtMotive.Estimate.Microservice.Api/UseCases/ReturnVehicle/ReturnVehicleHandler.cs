using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Handles the returning of a vehicle.
    /// </summary>
    public class ReturnVehicleHandler : IRequestHandler<ReturnVehicleRequest, IReturnVehiclePresenter>
    {
        private readonly IReturnVehicleUseCase _useCase;
        private readonly IReturnVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleHandler"/> class.
        /// </summary>
        /// <param name="useCase">The use case.</param>
        /// <param name="presenter">The presenter.</param>
        public ReturnVehicleHandler(IReturnVehicleUseCase useCase, IReturnVehiclePresenter presenter)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        public async Task<IReturnVehiclePresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new ReturnVehicleInput(request.RentalId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
