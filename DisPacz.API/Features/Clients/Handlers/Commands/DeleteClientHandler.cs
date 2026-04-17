using DisPacz.API.Features.Clients.Messages.Commands;
using DisPacz.API.Features.Clients.Services;
using MediatR;

namespace DisPacz.API.Features.Clients.Handlers.Commands
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientService _clientService;

        public DeleteClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _clientService.DeleteClient(request.Id, cancellationToken);
        }
    }
}
