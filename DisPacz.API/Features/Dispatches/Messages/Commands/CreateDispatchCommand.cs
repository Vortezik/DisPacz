using MediatR;

namespace DisPacz.API.Features.Dispatches.Messages.Commands
{
    public class CreateDispatchCommand : IRequest<int>
    {
        public DateTime AssignedAt { get; set; }
        public int JobId { get; set; }
        public int WorkerId { get; set; }
    }
}
