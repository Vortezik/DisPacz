using DisPacz.API.Features.Clients.Messages.DTOs;
using DisPacz.API.Features.Clients.Messages.Queries;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Clients.Handlers.Queries
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<ClientDto>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllClientsHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _context.Clients.ToListAsync(cancellationToken);
            return clients.Adapt<List<ClientDto>>();
        }
    }
}
