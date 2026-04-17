using MediatR;

namespace DisPacz.API.Features.Workers.Messages.Commands
{
    public class DeleteWorkerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
