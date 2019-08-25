using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IPriceTagRepository : IRepository<PriceTag>
    {

    }
    public class PriceTagRepository : Repository<PriceTag>, IPriceTagRepository
    {
        public PriceTagRepository()
        {
        }
    }
}
