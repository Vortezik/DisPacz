using DisPacz.API.Features.Jobs.Messages.DTOs;
using DisPacz.API.Features.Jobs.Messages.Queries;
using DisPacz.API.Features.Jobs.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Jobs.Handlers.Queries
{
    public class GetJobByIdHandler : IRequestHandler<GetJobByIdQuery, JobDto>
    {
        private readonly IJobProvider _jobProvider;

        public GetJobByIdHandler(IJobProvider jobProvider)
        {
            _jobProvider = jobProvider;
        }

        public async Task<JobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobProvider.GetJobByIdAsync(request.Id, true, cancellationToken);
            return job.Adapt<JobDto>();
        }
    }
}
