using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Workers.Providers
{
    public class WorkerProvider : IWorkerProvider
    {
        private readonly ApplicationDbContext _context;

        public WorkerProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Workers.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.OrderBy(w => w.FullName).ToListAsync(cancellationToken);
        }

        public async Task<Worker> GetWorkerByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Workers.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var worker = await query.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

            return worker ?? throw new KeyNotFoundException($"Worker with ID {id} not found.");
        }
    }
}
