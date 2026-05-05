using DisPacz.API.Features.Dispatches.Messages.Commands;
using DisPacz.API.Features.Dispatches.Services;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Handlers.Commands
{
    public class DeleteDispatchHandler : IRequestHandler<DeleteDispatchCommand>
    {
        private readonly IDispatchService _dispatchService;

        public DeleteDispatchHandler(IDispatchService dispatchService)
        {
            _dispatchService = dispatchService;
        }

        public async Task Handle(DeleteDispatchCommand request, CancellationToken cancellationToken)
        {
            await _dispatchService.DeleteDispatch(request.Id, cancellationToken);
        }
    }
}
