using DisPacz.API.Features.Locations.Messages.DTOs;
using DisPacz.API.Features.Locations.Messages.Queries;
using DisPacz.API.Features.Locations.Providers;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Locations.Handlers.Queries
{
    public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsQuery, List<LocationDto>>
    {
        private readonly ILocationProvider _locationProvider;

        public GetAllLocationsHandler(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public async Task<List<LocationDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationProvider.GetAllLocationsAsync(true, cancellationToken);
            return locations.Adapt<List<LocationDto>>();
        }
    }
}
