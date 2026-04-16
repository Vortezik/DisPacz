using DisPacz.API.Features.Jobs.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Jobs.Mappings
{
    public class JobMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Job, JobDto>();
        }
    }
}
