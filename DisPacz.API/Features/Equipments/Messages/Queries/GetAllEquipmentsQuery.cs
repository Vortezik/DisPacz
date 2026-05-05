using DisPacz.API.Features.Equipments.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Equipments.Messages.Queries
{
    public class GetAllEquipmentsQuery : IRequest<List<EquipmentDto>>
    {
    }
}
