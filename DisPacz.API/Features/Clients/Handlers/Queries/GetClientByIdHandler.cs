using DisPacz.API.Features.Clients.Messages.DTOs;
using DisPacz.API.Features.Clients.Messages.Queries;
using DisPacz.API.Features.Clients.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Clients.Handlers.Queries
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientProvider _clientProvider;

        public GetClientByIdHandler(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientProvider.GetClientByIdAsync(request.Id, true, cancellationToken);

            return client.Adapt<ClientDto>();
        }
    }
}
