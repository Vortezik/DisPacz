using DisPacz.API.Features.Clients.Messages.DTOs;
using DisPacz.API.Features.Clients.Messages.Queries;
using DisPacz.API.Features.Clients.Providers;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Clients.Handlers.Queries
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<ClientDto>>
    {
        private readonly IClientProvider _clientProvider;

        public GetAllClientsHandler(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public async Task<List<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientProvider.GetAllClientsAsync(true, cancellationToken);
            return clients.Adapt<List<ClientDto>>();
        }
    }
}
