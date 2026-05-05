using DisPacz.API.Features.Equipments.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Equipments.Messages.Queries
{
    public class GetEquipmentByIdQuery : IRequest<EquipmentDto>
    {
        public int Id { get; set; }

        public GetEquipmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
