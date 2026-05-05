using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Jobs.Handlers.Commands
{
    public class AssignEquipmentToJobHandler : IRequestHandler<AssignEquipmentToJobCommand>
    {
        private readonly ApplicationDbContext _context;

        public AssignEquipmentToJobHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AssignEquipmentToJobCommand request, CancellationToken cancellationToken)
        {
            var equipmentjob = await _context.JobEquipments.AnyAsync(je => je.JobId == request.JobId && je.EquipmentId == request.EquipmentId, cancellationToken);

            if (!equipmentjob)
            {
                _context.JobEquipments.Add(new JobEquipment
                {
                    JobId = request.JobId,
                    EquipmentId = request.EquipmentId
                });

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
