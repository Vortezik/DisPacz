using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateClient(Client client, CancellationToken cancellationToken)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateClient(int id, Client client, CancellationToken cancellationToken)
        {
            var existing = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            existing.Name = client.Name;
            existing.Phone = client.Phone;
            existing.Email = client.Email;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteClient(int id, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (client == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
