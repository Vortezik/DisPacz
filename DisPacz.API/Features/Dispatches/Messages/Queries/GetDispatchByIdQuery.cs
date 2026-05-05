using DisPacz.API.Features.Dispatches.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Messages.Queries
{
    public class GetDispatchByIdQuery : IRequest<DispatchDto>
    {
        public int Id { get; set; }

        public GetDispatchByIdQuery(int id)
        {
            Id = id;
        }
    }
}
