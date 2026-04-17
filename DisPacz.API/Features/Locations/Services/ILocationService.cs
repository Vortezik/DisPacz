using DisPacz.API.Models;

namespace DisPacz.API.Features.Locations.Services
{
    public interface ILocationService
    {
        Task CreateLocation(Location location, CancellationToken cancellationToken);
        Task UpdateLocation(int id, Location location, CancellationToken cancellationToken);
        Task DeleteLocation(int id, CancellationToken cancellationToken);
    }
}
