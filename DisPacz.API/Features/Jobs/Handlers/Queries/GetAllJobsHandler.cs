using DisPacz.API.Features.Jobs.Messages.DTOs;
using DisPacz.API.Features.Jobs.Messages.Queries;
using DisPacz.API.Features.Jobs.Providers;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Queries
{
    public class GetAllJobsHandler : IRequestHandler<GetAllJobsQuery, List<JobDto>>
    {
        private readonly IJobProvider _jobProvider;

        public GetAllJobsHandler(IJobProvider jobProvider)
        {
            _jobProvider = jobProvider;
        }

        public async Task<List<JobDto>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobProvider.GetAllJobsAsync(true, cancellationToken);
            return jobs.Adapt<List<JobDto>>();
        }
    }
}