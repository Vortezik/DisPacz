using DisPacz.API.Features.Equipments.Messages.DTOs;
using DisPacz.API.Features.Equipments.Messages.Queries;
using DisPacz.API.Features.Equipments.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Equipments.Handlers.Queries
{
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentDto>
    {
        private readonly IEquipmentProvider _equipmentProvider;

        public GetEquipmentByIdHandler(IEquipmentProvider equipmentProvider)
        {
            _equipmentProvider = equipmentProvider;
        }

        public async Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentProvider.GetEquipmentByIdAsync(request.Id, true, cancellationToken);

            return equipment.Adapt<EquipmentDto>();
        }
    }
}
