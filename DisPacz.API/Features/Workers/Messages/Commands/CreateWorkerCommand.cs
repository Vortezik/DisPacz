using MediatR;

namespace DisPacz.API.Features.Workers.Messages.Commands
{
    public class CreateWorkerCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
