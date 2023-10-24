namespace UberEats.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Partners> Partners { get; set; }

        public IList<Driver> Drivers { get; set; }
    }
}
