namespace DisPacz.API.Models
{
    public class JobWorker
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
