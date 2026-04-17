using DisPacz.API.Features.Workers.Messages.DTOs;
using DisPacz.API.Features.Workers.Messages.Queries;
using DisPacz.API.Features.Workers.Providers;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Workers.Handlers.Queries
{
    public class GetAllWorkersHandler : IRequestHandler<GetAllWorkersQuery, List<WorkerDto>>
    {
        private readonly IWorkerProvider _workerProvider;

        public GetAllWorkersHandler(IWorkerProvider workerProvider)
        {
            _workerProvider = workerProvider;
        }

        public async Task<List<WorkerDto>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var workers = await _workerProvider.GetAllWorkersAsync(true, cancellationToken);
            return workers.Adapt<List<WorkerDto>>();
        }
    }
}
