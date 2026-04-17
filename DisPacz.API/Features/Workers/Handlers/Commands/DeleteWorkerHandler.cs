using DisPacz.API.Features.Workers.Messages.Commands;
using DisPacz.API.Features.Workers.Services;
using MediatR;

namespace DisPacz.API.Features.Workers.Handlers.Commands
{
    public class DeleteWorkerHandler : IRequestHandler<DeleteWorkerCommand>
    {
        private readonly IWorkerService _workerService;

        public DeleteWorkerHandler(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public async Task Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            await _workerService.DeleteWorker(request.Id, cancellationToken);
        }
    }
}
