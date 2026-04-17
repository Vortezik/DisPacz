using DisPacz.API.Features.Workers.Messages.Commands;
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

            config.NewConfig<CreateWorkerCommand, Worker>()
                .Ignore(dest => dest.Id);
            
            config.NewConfig<UpdateWorkerCommand, Worker>()
                .Ignore(dest => dest.Id);
        }
    }
}
