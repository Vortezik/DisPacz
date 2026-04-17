using DisPacz.API.Features.Workers.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Workers.Messages.Queries
{
    public class GetWorkerByIdQuery : IRequest<WorkerDto>
    {
        public int Id { get; set; }

        public GetWorkerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
