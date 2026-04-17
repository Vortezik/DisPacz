using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Providers
{
    public class JobProvider : IJobProvider
    {
        private readonly ApplicationDbContext _context;

        public JobProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Jobs.
                Include(j => j.Client)
                .Include(j => j.Location)
                .AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.OrderBy(j => j.ScheduledDate).ToListAsync(cancellationToken);
        }

        public async Task<Job> GetJobByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Jobs
                .Include(j => j.Client)
                .Include(j => j.Location)
                .AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var job = await query.FirstOrDefaultAsync(j => j.Id == id, cancellationToken);

            return job ?? throw new KeyNotFoundException($"Job with ID {id} not found.");
        }
    }
}
