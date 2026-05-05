using DisPacz.API.Features.Equipments.Messages.Commands;
using DisPacz.API.Features.Equipments.Services;
using DisPacz.API.Models;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Equipments.Handlers.Commands
{
    public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IEquipmentService _equipmentService;

        public UpdateEquipmentHandler(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public async Task Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = request.Adapt<Equipment>();

            await _equipmentService.UpdateEquipment(request.Id, equipment, cancellationToken);
        }
    }
}
