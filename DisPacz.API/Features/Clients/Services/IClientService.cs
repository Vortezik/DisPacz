using DisPacz.API.Models;

namespace DisPacz.API.Features.Clients.Services
{
    public interface IClientService
    {
        Task CreateClient(Client client, CancellationToken cancellationToken);
        Task UpdateClient(int id, Client client, CancellationToken cancellationToken);
        Task DeleteClient(int id, CancellationToken cancellationToken);
    }
}
