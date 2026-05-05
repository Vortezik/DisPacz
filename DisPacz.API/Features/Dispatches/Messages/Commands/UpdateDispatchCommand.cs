using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Dispatches.Messages.Commands
{
    public class UpdateDispatchCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public DateTime AssignedAt { get; set; }
        public int JobId { get; set; }
        public int WorkerId { get; set; }
    }
}
