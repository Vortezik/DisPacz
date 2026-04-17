using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Clients.Messages.Commands
{
    public class UpdateClientCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
