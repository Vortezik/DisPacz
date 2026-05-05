using DisPacz.API.Models;

namespace DisPacz.API.Features.Dispatches.Services
{
    public interface IDispatchService
    {
        Task CreateDispatch(Dispatch dispatch, CancellationToken cancellationToken);
        Task UpdateDispatch(int id, Dispatch dispatch, CancellationToken cancellationToken);
        Task DeleteDispatch(int id, CancellationToken cancellationToken);
    }
}
