using DisPacz.API.Models;

namespace DisPacz.API.Features.Workers.Providers
{
    public interface IWorkerProvider
    {
        Task<IEnumerable<Worker>> GetAllWorkersAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
        Task<Worker> GetWorkerByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    }
}
