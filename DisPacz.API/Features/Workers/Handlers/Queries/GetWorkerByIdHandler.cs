using DisPacz.API.Features.Workers.Messages.DTOs;
using DisPacz.API.Features.Workers.Messages.Queries;
using DisPacz.API.Features.Workers.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Workers.Handlers.Queries
{
    public class GetWorkerByIdHandler : IRequestHandler<GetWorkerByIdQuery, WorkerDto>
    {
        private readonly IWorkerProvider _workerProvider;

        public GetWorkerByIdHandler(IWorkerProvider workerProvider)
        {
            _workerProvider = workerProvider;
        }

        public async Task<WorkerDto> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            var worker = await _workerProvider.GetWorkerByIdAsync(request.Id, true, cancellationToken);

            return worker.Adapt<WorkerDto>();
        }
    }
}
