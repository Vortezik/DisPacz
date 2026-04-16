namespace DisPacz.API.Models
{
    public class Dispatch
    {
        public int Id { get; set; }
        public DateTime AssignedAt { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
