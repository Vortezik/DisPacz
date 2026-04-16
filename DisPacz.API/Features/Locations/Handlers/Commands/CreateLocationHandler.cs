using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;

namespace DisPacz.API.Features.Locations.Handlers.Commands
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateLocationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = new Location
            {
                Address = request.Address,
                City = request.City
            };
            _context.Locations.Add(location);
            await _context.SaveChangesAsync(cancellationToken);
            return location.Id;
        }
    }
}
