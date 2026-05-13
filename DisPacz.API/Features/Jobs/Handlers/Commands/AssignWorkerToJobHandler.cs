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

                _context.Dispatches.Add(new Dispatch
                {
                    AssignedAt = DateTime.UtcNow,
                    JobId = request.JobId,
                    WorkerId = request.WorkerId
                });

                var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == request.JobId, cancellationToken);

                if (job != null && job.Status != "Completed")
                {
                    job.Status = "In Progress";
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
