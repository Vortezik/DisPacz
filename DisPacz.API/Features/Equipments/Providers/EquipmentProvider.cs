using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Equipments.Providers
{
    public class EquipmentProvider : IEquipmentProvider
    {
        private readonly ApplicationDbContext _context;

        public EquipmentProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Equipments.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.OrderBy(e => e.Name).ToListAsync(cancellationToken);
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Equipments.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var equipment = await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return equipment ?? throw new KeyNotFoundException($"Equipment with ID {id} not found.");
        }
    }
}
