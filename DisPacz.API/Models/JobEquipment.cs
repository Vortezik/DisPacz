namespace DisPacz.API.Models
{
    public class JobEquipment
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
