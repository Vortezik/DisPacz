using MediatR;

namespace DisPacz.API.Features.Equipments.Messages.Commands
{
    public class DeleteEquipmentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
