using MediatR;
using System.Text.Json.Serialization;

namespace DisPacz.API.Features.Workers.Messages.Commands
{
    public class UpdateWorkerCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }   
    }
}
