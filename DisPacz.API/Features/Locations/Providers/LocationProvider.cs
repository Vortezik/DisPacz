using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Locations.Providers
{
    public class LocationProvider : ILocationProvider
    {
        private readonly ApplicationDbContext _context;

        public LocationProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync(bool asNotracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Locations.AsQueryable();

            if (asNotracking)
            {
                query = query.AsNoTracking();
            }

            return await query.OrderBy(l => l.City).ThenBy(l => l.Address).ToListAsync(cancellationToken);
        }

        public async Task<Location> GetLocationByIdAsync(int id, bool asNotracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Locations.AsQueryable();

            if (asNotracking)
            {
                query = query.AsNoTracking();
            }

            var location = await query.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

            return location ?? throw new KeyNotFoundException($"Location with ID {id} not found.");
        }
    }
}
