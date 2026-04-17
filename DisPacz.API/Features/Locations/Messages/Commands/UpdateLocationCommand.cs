using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Locations.Messages.Commands
{
    public class UpdateLocationCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
