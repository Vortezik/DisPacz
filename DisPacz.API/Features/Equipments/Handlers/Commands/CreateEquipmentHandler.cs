using DisPacz.API.Features.Equipments.Messages.Commands;
using DisPacz.API.Features.Equipments.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Equipments.Handlers.Commands
{
    public class CreateEquipmentHandler : IRequestHandler<CreateEquipmentCommand, int>
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<CreateEquipmentHandler> _logger;

        public CreateEquipmentHandler(IEquipmentService equipmentService, ILogger<CreateEquipmentHandler> logger)
        {
            _equipmentService = equipmentService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating equipment: {Name}", request.Name);
            var equipment = request.Adapt<Equipment>();
            await _equipmentService.CreateEquipment(equipment, cancellationToken);
            _logger.LogInformation("Equipment created with ID: {Id}", equipment.Id);

            return equipment.Id;
        }
    }
}
