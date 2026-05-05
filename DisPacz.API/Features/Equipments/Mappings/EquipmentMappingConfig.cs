using DisPacz.API.Features.Equipments.Messages.Commands;
using DisPacz.API.Features.Equipments.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Equipments.Mappings
{
    public class EquipmentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Equipment, EquipmentDto>();

            config.NewConfig<CreateEquipmentCommand, Equipment>()
                .Ignore(dest => dest.Id);

            config.NewConfig<UpdateEquipmentCommand, Equipment>()
                .Ignore(dest => dest.Id);
        }
    }
}
