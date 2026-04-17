using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Workers.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly ApplicationDbContext _context;

        public WorkerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateWorker(Worker worker, CancellationToken cancellationToken)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateWorker(int id, Worker worker, CancellationToken cancellationToken)
        {
            var existing = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            existing.FullName = worker.FullName;
            existing.Phone = worker.Phone;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteWorker(int id, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

            if (worker == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Workers.Remove(worker);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
