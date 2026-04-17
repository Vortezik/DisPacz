using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Clients.Providers
{
    public class ClientProvider : IClientProvider
    {
        private readonly ApplicationDbContext _context;

        public ClientProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Clients.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.OrderBy(c => c.Name).ToListAsync(cancellationToken);
        }

        public async Task<Client> GetClientByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _context.Clients.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var client = await query.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return client ?? throw new KeyNotFoundException($"Client with ID {id} not found.");
        }
    }
}
