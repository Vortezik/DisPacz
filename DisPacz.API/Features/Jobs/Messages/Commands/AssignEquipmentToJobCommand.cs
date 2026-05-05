using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Commands
{
    public class AssignEquipmentToJobCommand : IRequest
    {
        public int JobId { get; set; }
        public int EquipmentId { get; set; }
    }
}
