using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Features.Locations.Services;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Locations.Handlers.Commands
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<CreateLocationHandler> _logger;

        public CreateLocationHandler(ILocationService locationService, ILogger<CreateLocationHandler> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a location with address: {Address} and city: {City}", request.Address, request.City);
            var location = request.Adapt<Location>();
            await _locationService.CreateLocation(location, cancellationToken);
            _logger.LogInformation("Location created with ID: {Id}", location.Id);

            return location.Id;
        }
    }
}
