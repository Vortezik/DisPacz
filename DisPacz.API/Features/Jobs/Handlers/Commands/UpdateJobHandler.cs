using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Features.Jobs.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class UpdateJobHandler : IRequestHandler<UpdateJobCommand>
    {
        private readonly IJobService _jobService;

        public UpdateJobHandler(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = request.Adapt<Job>();

            await _jobService.UpdateJob(request.Id, job, cancellationToken);
        }
    }
}
