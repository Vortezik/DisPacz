namespace DisPacz.API.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public ICollection<JobEquipment> JobEquipments { get; set; }
    }
}
