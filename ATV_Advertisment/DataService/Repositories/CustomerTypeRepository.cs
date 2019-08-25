using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ICustomerTypeRepository : IRepository<CustomerType>
    {

    }
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository()
        {
        }
    }
}
