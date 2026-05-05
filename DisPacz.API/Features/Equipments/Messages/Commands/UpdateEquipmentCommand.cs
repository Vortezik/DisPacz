using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Equipments.Messages.Commands
{
    public class UpdateEquipmentCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}
