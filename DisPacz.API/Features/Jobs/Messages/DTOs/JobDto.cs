namespace DisPacz.API.Features.Jobs.Messages.DTOs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ClientId { get; set; }
        public int LocationId { get; set; }
    }
}
