using DisPacz.API.Features.Dispatches.Messages.Commands;
using DisPacz.API.Features.Dispatches.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Handlers.Commands
{
    public class CreateDispatchHandler : IRequestHandler<CreateDispatchCommand, int>
    {
        private readonly IDispatchService _dispatchService;
        private readonly ILogger<CreateDispatchHandler> _logger;

        public CreateDispatchHandler(IDispatchService dispatchService, ILogger<CreateDispatchHandler> logger)
        {
            _dispatchService = dispatchService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateDispatchCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating dispatch with Job ID: {JobId} and Worker ID: {WorkerId}", request.JobId, request.WorkerId);
            var dispatch = request.Adapt<Dispatch>();
            await _dispatchService.CreateDispatch(dispatch, cancellationToken);
            _logger.LogInformation("Dispatch created with ID: {DispatchId}", dispatch.Id);

            return dispatch.Id;
        }
    }
}
