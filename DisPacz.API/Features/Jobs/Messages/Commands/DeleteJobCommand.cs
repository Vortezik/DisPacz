using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Commands
{
    public class DeleteJobCommand : IRequest
    {
        public int Id { get; set; }
    }
}
