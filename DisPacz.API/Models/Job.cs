namespace DisPacz.API.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
