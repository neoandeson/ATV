using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IContractDetailRepository : IRepository<ContractDetail>
    {

    }
    public class ContractDetailRepository : Repository<ContractDetail>, IContractDetailRepository
    {
        public ContractDetailRepository()
        {
        }
    }
}
