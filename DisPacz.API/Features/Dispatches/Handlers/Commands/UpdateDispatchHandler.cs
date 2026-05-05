using DisPacz.API.Features.Dispatches.Messages.Commands;
using DisPacz.API.Features.Dispatches.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Handlers.Commands
{
    public class UpdateDispatchHandler : IRequestHandler<UpdateDispatchCommand>
    {
        private readonly IDispatchService _dispatchService;

        public UpdateDispatchHandler(IDispatchService dispatchService)
        {
            _dispatchService = dispatchService;
        }

        public async Task Handle(UpdateDispatchCommand request, CancellationToken cancellationToken)
        {
            var dispatch = request.Adapt<Dispatch>();

            await _dispatchService.UpdateDispatch(request.Id, dispatch, cancellationToken);
        }
    }
}
