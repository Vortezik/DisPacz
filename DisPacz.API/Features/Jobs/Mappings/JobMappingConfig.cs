using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Features.Jobs.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Jobs.Mappings
{
    public class JobMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Job, JobDto>()
                .Map(dest => dest.ClientName, src => src.Client.Name)
                .Map(dest => dest.LocationAddress, src => src.Location.Address)
                .Map(dest => dest.AssignedEquipment, src => src.JobEquipments == null || !src.JobEquipments.Any()
                    ? new List<EquipmentOnJobDto>()
                    : src.JobEquipments.Select(je => new EquipmentOnJobDto
                    {
                        Id = je.Equipment.Id,
                        Name = je.Equipment.Name,
                        SerialNumber = je.Equipment.SerialNumber,
                    }).ToList());

            config.NewConfig<CreateJobCommand, Job>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Client)
                .Ignore(dest => dest.Location)
                .Ignore(dest => dest.JobEquipments);

            config.NewConfig<UpdateJobCommand, Job>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Client)
                .Ignore(dest => dest.Location)
                .Ignore(dest => dest.JobEquipments);
        }
    }
}
