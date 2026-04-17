using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Jobs.Messages.Commands
{
    public class UpdateJobCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ClientId { get; set; }
        public int LocationId { get; set; }
    }
}
