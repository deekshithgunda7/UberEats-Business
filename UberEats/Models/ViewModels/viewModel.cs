namespace UberEats.Models
{
    public class viewModel
    {
        public IList<Category> categories { get; set; }

        public Partners partners { get; set; }

        public IList<Partners> Partners { get; set; }

        public Driver driver { get; set; }

        public IList<Driver> Drivers { get; set; }
    }
}
