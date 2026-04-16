namespace DisPacz.API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
