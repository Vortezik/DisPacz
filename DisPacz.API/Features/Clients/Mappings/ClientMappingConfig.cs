using DisPacz.API.Features.Clients.Messages.Commands;
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

            config.NewConfig<CreateClientCommand, Client>()
                .Ignore(dest => dest.Id);

            config.NewConfig<UpdateClientCommand, Client>()
                .Ignore(dest => dest.Id);
        }
    }
}
