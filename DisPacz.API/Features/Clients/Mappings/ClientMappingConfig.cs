using DisPacz.API.Features.Clients.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Clients.Mappings
{
    public class ClientMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Client, ClientDto>();
        }
    }
}
