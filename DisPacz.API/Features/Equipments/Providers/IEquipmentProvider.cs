using DisPacz.API.Models;

namespace DisPacz.API.Features.Equipments.Providers
{
    public interface IEquipmentProvider
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
        Task<Equipment> GetEquipmentByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    }
}
