using DisPacz.API.Models;

namespace DisPacz.API.Features.Locations.Providers
{
    public interface ILocationProvider
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
        Task<Location> GetLocationByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    }
}
