using DisPacz.API.Models;

namespace DisPacz.API.Features.Workers.Services
{
    public interface IWorkerService
    {
        Task CreateWorker(Worker worker, CancellationToken cancellationToken);
        Task UpdateWorker(int id, Worker worker, CancellationToken cancellationToken);
        Task DeleteWorker(int id, CancellationToken cancellationToken);
    }
}
