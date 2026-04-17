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
                .Map(dest => dest.LocationAddress, src => src.Location.Address);

            config.NewConfig<CreateJobCommand, Job>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Client)
                .Ignore(dest => dest.Location);

            config.NewConfig<UpdateJobCommand, Job>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Client)
                .Ignore(dest => dest.Location);
        }
    }
}
