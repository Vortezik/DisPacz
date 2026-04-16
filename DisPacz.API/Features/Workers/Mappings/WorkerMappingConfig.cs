using DisPacz.API.Features.Workers.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Workers.Mappings
{
    public class WorkerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Worker, WorkerDto>();
        }
    }
}
