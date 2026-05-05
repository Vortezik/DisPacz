using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Equipments.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ApplicationDbContext _context;

        public EquipmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateEquipment(Equipment equipment, CancellationToken cancellationToken)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEquipment(int id, Equipment equipment, CancellationToken cancellationToken)
        {
            var existing = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            existing.Name = equipment.Name;
            existing.SerialNumber = equipment.SerialNumber;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEquipment(int id, CancellationToken cancellationToken)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);

            if (equipment == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
