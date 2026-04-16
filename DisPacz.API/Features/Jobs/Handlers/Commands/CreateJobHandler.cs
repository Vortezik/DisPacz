using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class CreateJobHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateJobHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                ScheduledDate = request.ScheduledDate,
                ClientId = request.ClientId,
                LocationId = request.LocationId
            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync(cancellationToken);
            return job.Id;
        }
    }
}
