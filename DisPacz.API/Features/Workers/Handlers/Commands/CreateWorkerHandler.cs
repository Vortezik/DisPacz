using DisPacz.API.Features.Workers.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;

namespace DisPacz.API.Features.Workers.Handlers.Commands
{
    public class CreateWorkerHandler : IRequestHandler<CreateWorkerCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateWorkerHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = new Worker
            {
                FullName = request.FullName,
                Phone = request.Phone
            };
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync(cancellationToken);
            return worker.Id;
        }
    }
}
