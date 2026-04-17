using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateJob(Job job, CancellationToken cancellationToken)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateJob(int id, Job job, CancellationToken cancellationToken)
        {
            var existing = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id, cancellationToken);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            existing.Title = job.Title;
            existing.Description = job.Description;
            existing.Status = job.Status;
            existing.ScheduledDate = job.ScheduledDate;
            existing.ClientId = job.ClientId;
            existing.LocationId = job.LocationId;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteJob(int id, CancellationToken cancellationToken)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id, cancellationToken);

            if (job == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
