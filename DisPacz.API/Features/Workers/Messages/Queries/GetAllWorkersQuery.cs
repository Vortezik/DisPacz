using DisPacz.API.Features.Workers.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Workers.Messages.Queries
{
    public class GetAllWorkersQuery : IRequest<List<WorkerDto>>
    {
    }
}
