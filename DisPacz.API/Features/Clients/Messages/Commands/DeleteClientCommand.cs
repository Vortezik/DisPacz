using MediatR;

namespace DisPacz.API.Features.Clients.Messages.Commands
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }
    }
}
