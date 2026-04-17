using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Features.Locations.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Locations.Mappings
{
    public class LocationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Location, LocationDto>();

            config.NewConfig<CreateLocationCommand, Location>()
                .Ignore(dest => dest.Id);

            config.NewConfig<UpdateLocationCommand, Location>()
                .Ignore(dest => dest.Id);
        }
    }
}
