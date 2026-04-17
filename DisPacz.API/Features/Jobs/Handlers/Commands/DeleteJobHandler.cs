using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Features.Jobs.Services;
using MediatR;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class DeleteJobHandler : IRequestHandler<DeleteJobCommand>
    {
        private readonly IJobService _jobService;

        public DeleteJobHandler(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            await _jobService.DeleteJob(request.Id, cancellationToken);
        }
    }
}
