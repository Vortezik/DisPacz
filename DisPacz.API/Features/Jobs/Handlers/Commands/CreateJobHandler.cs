using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Features.Jobs.Services;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class CreateJobHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IJobService _jobService;
        private readonly ILogger<CreateJobHandler> _logger;

        public CreateJobHandler(IJobService jobService, ILogger<CreateJobHandler> logger)
        {
            _jobService = jobService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating job with title: {Title}", request.Title);
            var job = request.Adapt<Job>();
            await _jobService.CreateJob(job, cancellationToken);
            _logger.LogInformation("Job created with ID: {Id}", job.Id);
            return job.Id;
        }
    }
}
