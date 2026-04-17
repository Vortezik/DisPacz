using DisPacz.API.Models;

namespace DisPacz.API.Features.Jobs.Providers
{
    public interface IJobProvider
    {
        Task<IEnumerable<Job>> GetAllJobsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
        Task<Job> GetJobByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    }
}
