using DisPacz.API.Features.Jobs.Messages.DTOs;
using DisPacz.API.Features.Jobs.Messages.Queries;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Queries
{
    public class GetAllJobsHandler : IRequestHandler<GetAllJobsQuery, List<JobDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllJobsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobDto>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.Jobs.ToListAsync(cancellationToken);
            return jobs.Adapt<List<JobDto>>();
        }
    }
}