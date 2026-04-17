using DisPacz.API.Features.Workers.Messages.Commands;
using DisPacz.API.Features.Workers.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Workers.Handlers.Commands
{
    public class UpdateWorkerHandler : IRequestHandler<UpdateWorkerCommand>
    {
        private readonly IWorkerService _workerService;

        public UpdateWorkerHandler(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public async Task Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = request.Adapt<Worker>();

            await _workerService.UpdateWorker(request.Id, worker, cancellationToken);
        }
    }
}
