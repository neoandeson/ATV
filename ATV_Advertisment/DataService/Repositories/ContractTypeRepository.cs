using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IContractTypeRepository : IRepository<ContractType>
    {

    }
    public class ContractTypeRepository : Repository<ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository()
        {
        }
    }
}
