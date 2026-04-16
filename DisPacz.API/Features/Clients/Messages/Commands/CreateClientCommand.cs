using MediatR;

namespace DisPacz.API.Features.Clients.Messages.Commands
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
