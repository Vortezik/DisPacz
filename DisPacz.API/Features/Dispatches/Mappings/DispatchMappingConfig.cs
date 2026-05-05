using DisPacz.API.Features.Dispatches.Messages.Commands;
using DisPacz.API.Features.Dispatches.Messages.DTOs;
using DisPacz.API.Models;
using Mapster;

namespace DisPacz.API.Features.Dispatches.Mappings
{
    public class DispatchMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Dispatch, DispatchDto>()
                .Map(dest => dest.JobTitle, src => src.Job.Title)
                .Map(dest => dest.WorkerName, src => src.Worker.FullName);

            config.NewConfig<CreateDispatchCommand, Dispatch>()
                .Ignore(dest => dest.Id);

            config.NewConfig<UpdateDispatchCommand, Dispatch>()
                .Ignore(dest => dest.Id);
        }
    }
}
