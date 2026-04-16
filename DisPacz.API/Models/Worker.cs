namespace DisPacz.API.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public ICollection<JobWorker> JobWorkers { get; set; }
    }
}
