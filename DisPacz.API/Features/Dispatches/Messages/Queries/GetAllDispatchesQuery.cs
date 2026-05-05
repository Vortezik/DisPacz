using DisPacz.API.Features.Dispatches.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Messages.Queries
{
    public class GetAllDispatchesQuery : IRequest<List<DispatchDto>>
    {
    }
}
