using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IDiscountRepository : IRepository<Discount>
    {

    }
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository()
        {
        }
    }
}
