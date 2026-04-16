using DisPacz.API.Features.Clients.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Clients.Messages.Queries
{
    public class GetAllClientsQuery : IRequest<List<ClientDto>>
    {
    }
}
