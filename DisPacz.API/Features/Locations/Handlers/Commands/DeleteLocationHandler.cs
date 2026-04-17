using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Features.Locations.Services;
using MediatR;

namespace DisPacz.API.Features.Locations.Handlers.Commands
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly ILocationService _locationService;

        public DeleteLocationHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationService.DeleteLocation(request.Id, cancellationToken);
        }
    }
}
