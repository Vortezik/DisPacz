using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Locations.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateLocation(Location location, CancellationToken cancellationToken)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateLocation(int id, Location location, CancellationToken cancellationToken)
        {
            var existing = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
            
            if (existing == null)
            {
                throw new KeyNotFoundException();
            }
            
            existing.Address = location.Address;
            existing.City = location.City;
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
            
            if (location == null)
            {
                throw new KeyNotFoundException();
            }
            
            _context.Locations.Remove(location);
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
