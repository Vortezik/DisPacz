using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Features.Locations.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Locations.Handlers.Commands
{
    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly ILocationService _locationService;

        public UpdateLocationHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = request.Adapt<Location>();

            await _locationService.UpdateLocation(request.Id, location, cancellationToken);
        }
    }
}
