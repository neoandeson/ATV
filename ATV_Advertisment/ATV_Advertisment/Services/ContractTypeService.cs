using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IContractTypeService
    {
        ContractType GetById(int id);
        List<ContractType> GetAll();
        Dictionary<int, string> Getoptions();
        int DeleteContractType(int id);
        int AddContractType(ContractType input);
        int EditContractType(ContractType input);
    }

    public class ContractTypeService : IContractTypeService
    {
        private readonly ContractTypeRepository _ContractTypeRepository;

        public ContractTypeService()
        {
            _ContractTypeRepository = new ContractTypeRepository();
        }

        public int AddContractType(ContractType input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                //TODO: Define if seperative ContractType
                //bool isExisted = _ContractTypeRepository.Exist(t => t.Length == input.Length);
                //if (!isExisted)
                input.StatusId = CommonStatus.ACTIVE;
                input.CreateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateBy = Common.Session.GetId();
                _ContractTypeRepository.Add(input);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        /// <summary>
        /// Onyly mark as cancel 
        /// must not print on schedule
        /// optional when print report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteContractType(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var ContractType = _ContractTypeRepository.GetById(id);
            if (ContractType != null)
            {
                ContractType.StatusId = CommonStatus.CANCEL;

                ContractType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractType.LastUpdateBy = Common.Session.GetId();
                _ContractTypeRepository.Update(ContractType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditContractType(ContractType input)
        {
            int result = CRUDStatusCode.ERROR;
            var ContractType = _ContractTypeRepository.GetById(input.Id);
            if (ContractType != null)
            {
                //TODO: Define if seperative ContractType
                //bool isExisted = _ContractTypeRepository.Exist(t => t. == input.Length);
                //if (!isExisted)
                ContractType.Type = input.Type;
                ContractType.Description = input.Description;

                ContractType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractType.LastUpdateBy = Common.Session.GetId();
                _ContractTypeRepository.Update(ContractType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<ContractType> GetAll()
        {
            return _ContractTypeRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public ContractType GetById(int id)
        {
            return _ContractTypeRepository.GetById(id);
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _ContractTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Type);
            return options;
        }
    }
}
