using DisPacz.API.Features.Equipments.Messages.DTOs;
using DisPacz.API.Features.Equipments.Messages.Queries;
using DisPacz.API.Features.Equipments.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Equipments.Handlers.Queries
{
    public class GetAllEquipmentsHandler : IRequestHandler<GetAllEquipmentsQuery, List<EquipmentDto>>
    {
        private readonly IEquipmentProvider _equipmentProvider;

        public GetAllEquipmentsHandler(IEquipmentProvider equipmentProvider)
        {
            _equipmentProvider = equipmentProvider;
        }

        public async Task<List<EquipmentDto>> Handle(GetAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var equipments = await _equipmentProvider.GetAllEquipmentsAsync(true, cancellationToken);
            return equipments.Adapt<List<EquipmentDto>>();
        }
    }
}
