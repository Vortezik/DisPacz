namespace DisPacz.API.Features.Dispatches.Messages.DTOs
{
    public class DispatchDto
    {
        public int Id { get; set; }
        public DateTime AssignedAt { get; set; }
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
    }
}
