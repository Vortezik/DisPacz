using DisPacz.API.Models;

namespace DisPacz.API.Features.Jobs.Services
{
    public interface IJobService
    {
        Task CreateJob(Job job, CancellationToken cancellationToken);
        Task UpdateJob(int id, Job job, CancellationToken cancellationToken);
        Task DeleteJob(int id, CancellationToken cancellationToken);
    }
}
