using MediatR;

namespace DisPacz.API.Features.Equipments.Messages.Commands
{
    public class CreateEquipmentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}
