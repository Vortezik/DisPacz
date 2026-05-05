using MediatR;

namespace DisPacz.API.Features.Dispatches.Messages.Commands
{
    public class DeleteDispatchCommand : IRequest
    {
        public int Id { get; set; }
    }
}
