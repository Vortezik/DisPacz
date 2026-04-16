using DisPacz.API.Features.Locations.Messages.DTOs;
using DisPacz.API.Features.Locations.Messages.Queries;
using DisPacz.API.Models.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Locations.Handlers.Queries
{
    public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsQuery, List<LocationDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllLocationsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocationDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _context.Locations.ToListAsync(cancellationToken);
            return locations.Adapt<List<LocationDto>>();
        }
    }
}
