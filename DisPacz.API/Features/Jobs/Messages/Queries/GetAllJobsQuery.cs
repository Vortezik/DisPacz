using DisPacz.API.Features.Jobs.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Queries
{
    public class GetAllJobsQuery : IRequest<List<JobDto>>
    {
    }
}
