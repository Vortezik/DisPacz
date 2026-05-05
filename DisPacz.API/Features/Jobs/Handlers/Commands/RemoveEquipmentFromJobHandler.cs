using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Models.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class RemoveEquipmentFromJobHandler : IRequestHandler<RemoveEquipmentFromJobCommand>
    {
        private readonly ApplicationDbContext _context;

        public RemoveEquipmentFromJobHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveEquipmentFromJobCommand request, CancellationToken cancellationToken)
        {
            var equipmentjob = await _context.JobEquipments.FirstOrDefaultAsync(je => je.JobId == request.JobId && je.EquipmentId == request.EquipmentId, cancellationToken);

            if (equipmentjob != null)
            {
                _context.JobEquipments.Remove(equipmentjob);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
