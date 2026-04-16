using DisPacz.API.Features.Workers.Messages.DTOs;
using DisPacz.API.Features.Workers.Messages.Queries;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Workers.Handlers.Queries
{
    public class GetAllWorkersHandler : IRequestHandler<GetAllWorkersQuery, List<WorkerDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllWorkersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkerDto>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var workers = await _context.Workers.ToListAsync(cancellationToken);
            return workers.Adapt<List<WorkerDto>>();
        }
    }
}
