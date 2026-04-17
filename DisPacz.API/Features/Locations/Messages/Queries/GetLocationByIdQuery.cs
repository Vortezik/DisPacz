using DisPacz.API.Features.Locations.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Locations.Messages.Queries
{
    public class GetLocationByIdQuery : IRequest<LocationDto>
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
