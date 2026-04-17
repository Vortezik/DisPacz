using DisPacz.API.Features.Clients.Messages.Commands;
using DisPacz.API.Features.Clients.Services;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Clients.Handlers.Commands
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientService _clientService;
        private readonly ILogger<CreateClientHandler> _logger;

        public CreateClientHandler(IClientService clientService, ILogger<CreateClientHandler> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating client: {Name}", request.Name);
            var client = request.Adapt<Client>();
            await _clientService.CreateClient(client, cancellationToken);
            _logger.LogInformation("Client created with ID: {Id}", client.Id);

            return client.Id;
        }
    }
}
