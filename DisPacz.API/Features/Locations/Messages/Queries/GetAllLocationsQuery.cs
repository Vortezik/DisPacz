using DisPacz.API.Features.Locations.Messages.DTOs;
using MediatR;

namespace DisPacz.API.Features.Locations.Messages.Queries
{
    public class GetAllLocationsQuery : IRequest<List<LocationDto>>
    {
    }
}
