namespace DisPacz.API.Features.Jobs.Messages.DTOs
{
    public class EquipmentOnJobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }

    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int LocationId { get; set; }
        public string LocationAddress { get; set; }
        public List<EquipmentOnJobDto> AssignedEquipment { get; set; } = new();
    }
}
