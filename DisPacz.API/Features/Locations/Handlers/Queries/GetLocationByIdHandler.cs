using DisPacz.API.Features.Locations.Messages.DTOs;
using DisPacz.API.Features.Locations.Messages.Queries;
using DisPacz.API.Features.Locations.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Locations.Handlers.Queries
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, LocationDto>
    {
        private readonly ILocationProvider _locationProvider;

        public GetLocationByIdHandler(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationProvider.GetLocationByIdAsync(request.Id, true, cancellationToken);

            return location.Adapt<LocationDto>();
        }
    }
}
