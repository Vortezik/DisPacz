using DisPacz.API.Features.Equipments.Messages.Commands;
using DisPacz.API.Features.Equipments.Services;
using MediatR;

namespace DisPacz.API.Features.Equipments.Handlers.Commands
{
    public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentCommand>
    {
        private readonly IEquipmentService _equipmentService;

        public DeleteEquipmentHandler(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            await _equipmentService.DeleteEquipment(request.Id, cancellationToken);
        }
    }
}
