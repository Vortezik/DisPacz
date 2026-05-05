using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Dispatches.Providers
{
    public class DispatchProvider : IDispatchProvider
    {
        private readonly ApplicationDbContext _context;

        public DispatchProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dispatch>> GetAllDispatchesAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Dispatches
                .Include(d => d.Job)
                .Include(d => d.Worker)
                .AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
                
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Dispatch> GetDispatchByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Dispatches
                .Include(d => d.Job)
                .Include(d => d.Worker)
                .AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var dispatch = await query.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

            return dispatch ?? throw new KeyNotFoundException($"Dispatch with ID {id} not found.");
        }
    }
}
