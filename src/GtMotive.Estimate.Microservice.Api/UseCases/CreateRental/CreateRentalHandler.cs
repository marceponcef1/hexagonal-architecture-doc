using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalHandler : IRequestHandler<CreateRentalRequest, ICreateRentalPresenter>
    {
        /// <summary>
        /// Handles the creation of a rental.
        /// </summary>
        private readonly ICreateRentalUseCase _useCase;
        private readonly ICreateRentalPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalHandler"/> class.
        /// </summary>
        /// <param name="useCase">The use case.</param>
        /// <param name="presenter">The presenter.</param>
        public CreateRentalHandler(ICreateRentalUseCase useCase, ICreateRentalPresenter presenter)
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
        public async Task<ICreateRentalPresenter> Handle(CreateRentalRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new CreateRentalInput(request.CustomerId, request.VehicleId, request.Period);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
