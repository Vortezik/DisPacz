using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Commands
{
    public class AssignWorkerToJobCommand : IRequest
    {
        public int JobId { get; set; }
        public int WorkerId { get; set; }
    }
}
