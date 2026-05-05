using DisPacz.API.Models;

namespace DisPacz.API.Features.Dispatches.Providers
{
    public interface IDispatchProvider
    {
        Task<IEnumerable<Dispatch>> GetAllDispatchesAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
        Task<Dispatch> GetDispatchByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    }
}
