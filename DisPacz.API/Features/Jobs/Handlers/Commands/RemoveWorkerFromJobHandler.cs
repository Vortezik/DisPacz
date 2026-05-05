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
            var workerjob = await _context.JobWorkers.FirstOrDefaultAsync(jw => jw.JobId == request.JobId && jw.WorkerId == request.WorkerId, cancellationToken);

            if (workerjob != null)
            {
                _context.JobWorkers.Remove(workerjob);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
