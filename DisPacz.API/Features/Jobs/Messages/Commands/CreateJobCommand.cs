using MediatR;

namespace DisPacz.API.Features.Jobs.Messages.Commands
{
    public class CreateJobCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ClientId { get; set; }
        public int LocationId { get; set; }
    }
}
