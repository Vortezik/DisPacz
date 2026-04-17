using DisPacz.API.Features.Workers.Messages.Commands;
using DisPacz.API.Features.Workers.Services;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Workers.Handlers.Commands
{
    public class CreateWorkerHandler : IRequestHandler<CreateWorkerCommand, int>
    {
        private readonly IWorkerService _workerService;
        private readonly ILogger<CreateWorkerHandler> _logger;

        public CreateWorkerHandler(IWorkerService workerService, ILogger<CreateWorkerHandler> logger)
        {
            _workerService = workerService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new worker: {FullName}", request.FullName);
            var worker = request.Adapt<Worker>();
            await _workerService.CreateWorker(worker, cancellationToken);
            _logger.LogInformation("Worker created with ID: {Id}", worker.Id);

            return worker.Id;
        }
    }
}
