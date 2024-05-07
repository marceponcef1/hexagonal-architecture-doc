using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Handles the listing of available vehicles.
    /// </summary>
    public class ListAvailableVehiclesHandler : IRequestHandler<ListAvailableVehiclesRequest, IListAvailableVehiclesPresenter>
    {
        private readonly IListAvailableVehiclesUseCase _useCase;
        private readonly IListAvailableVehiclesPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesHandler"/> class.
        /// </summary>
        /// <param name="useCase">The use case.</param>
        /// <param name="presenter">The presenter.</param>
        public ListAvailableVehiclesHandler(IListAvailableVehiclesUseCase useCase, IListAvailableVehiclesPresenter presenter)
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
        public async Task<IListAvailableVehiclesPresenter> Handle(ListAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new ListAvailableVehiclesInput(request.FleetId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
