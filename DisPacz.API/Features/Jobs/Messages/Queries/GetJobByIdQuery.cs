using DisPacz.API.Features.Jobs.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Queries
{
    public class GetJobByIdQuery : IRequest<JobDto>
    {
        public int Id { get; set; }

        public GetJobByIdQuery(int id)
        {
            Id = id;
        }
    }
}
