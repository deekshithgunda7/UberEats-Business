namespace UberEats.Models.DataLayer.Repositories
{
    public class MenuRepository : Repository<MenuItem>, IMenuRepository
    {
        public MenuRepository(UberEatsContext ctx) : base(ctx)
        {
        }
    }
}
