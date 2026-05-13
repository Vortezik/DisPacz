using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Models.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class RemoveWorkerFromJobHandler : IRequestHandler<RemoveWorkerFromJobCommand>
    {
        private readonly ApplicationDbContext _context;

        public RemoveWorkerFromJobHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveWorkerFromJobCommand request, CancellationToken cancellationToken)
        {
            var assignments = await _context.JobWorkers
                .Where(jw => jw.JobId == request.JobId)
                .ToListAsync(cancellationToken);

            var workerjob = assignments.FirstOrDefault(jw => jw.WorkerId == request.WorkerId);

            if (workerjob != null)
            {
                _context.JobWorkers.Remove(workerjob);

                var dispatches = await _context.Dispatches
                    .Where(d => d.JobId == request.JobId && d.WorkerId == request.WorkerId)
                    .ToListAsync(cancellationToken);
                _context.Dispatches.RemoveRange(dispatches);

                var remaining = assignments.Count - 1;

                if (remaining <= 0)
                {
                    var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == request.JobId, cancellationToken);

                    if (job != null && job.Status != "Completed")
                    {
                        job.Status = "Open";
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
