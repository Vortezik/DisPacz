using DisPacz.API.Models;

namespace DisPacz.API.Features.Equipments.Services
{
    public interface IEquipmentService
    {
        Task CreateEquipment(Equipment equipment, CancellationToken cancellationToken);
        Task UpdateEquipment(int id, Equipment equipment, CancellationToken cancellationToken);
        Task DeleteEquipment(int id, CancellationToken cancellationToken);
    }
}
