using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class AssignWorkerToJobHandler : IRequestHandler<AssignWorkerToJobCommand>
    {
        private readonly ApplicationDbContext _context;

        public AssignWorkerToJobHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AssignWorkerToJobCommand request, CancellationToken cancellationToken)
        {
            var workerjob = await _context.JobWorkers.AnyAsync(jw => jw.JobId == request.JobId && jw.WorkerId == request.WorkerId, cancellationToken);

            if (!workerjob)
            {
                _context.JobWorkers.Add(new JobWorker
                {
                    JobId = request.JobId,
                    WorkerId = request.WorkerId
                });

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
