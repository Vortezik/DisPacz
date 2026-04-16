using DisPacz.API.Features.Clients.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;

namespace DisPacz.API.Features.Clients.Handlers.Commands
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateClientHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);
            return client.Id;
        }
    }
}
