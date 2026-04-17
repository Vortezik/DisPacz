using DisPacz.API.Features.Clients.Messages.Commands;
using DisPacz.API.Features.Clients.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Clients.Handlers.Commands
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientService _clientService;

        public UpdateClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = request.Adapt<Client>();

            await _clientService.UpdateClient(request.Id, client, cancellationToken);
        }
    }
}
