using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IContractService
    {
        Contract GetById(int id);
        List<Contract> GetAll();
        List<ContractViewModel> GetForList();
        int DeleteContract(int id);
        int AddContract(Contract input);
        int EditContract(Contract input);
    }

    public class ContractService : IContractService
    {
        private readonly ContractRepository _ContractRepository;
        private readonly ContractTypeRepository _contractTypeRepository;

        public ContractService()
        {
            _ContractRepository = new ContractRepository();
            _contractTypeRepository = new ContractTypeRepository();
        }

        public int AddContract(Contract input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                //TODO: Define if seperative contract
                //bool isExisted = _ContractRepository.Exist(t => t.Length == input.Length);
                //if (!isExisted)
                input.StatusId = CommonStatus.ACTIVE;
                input.CreateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Add(input);
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
        public int DeleteContract(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Contract = _ContractRepository.GetById(id);
            if (Contract != null)
            {
                Contract.StatusId = CommonStatus.CANCEL;

                Contract.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Contract.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Update(Contract);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditContract(Contract input)
        {
            int result = CRUDStatusCode.ERROR;
            var Contract = _ContractRepository.GetById(input.Id);
            if (Contract != null)
            {
                //TODO: Define if seperative contract
                //bool isExisted = _ContractRepository.Exist(t => t. == input.Length);
                //if (!isExisted)
                Contract.ContractTypeId = input.ContractTypeId;
                Contract.CustomerCode = input.CustomerCode;
                Contract.StartDate = input.StartDate;
                Contract.EndDate = input.EndDate;

                Contract.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Contract.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Update(Contract);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<Contract> GetAll()
        {
            return _ContractRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public Contract GetById(int id)
        {
            return _ContractRepository.GetById(id);
        }

        public List<ContractViewModel> GetForList()
        {
            Dictionary<int, string> contractTypes = _contractTypeRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Id, q => q.Type);
            return _ContractRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
                .Select(c => new ContractViewModel()
                {
                    CustomerCode = c.CustomerCode,
                    ContractType = contractTypes.Where(s => s.Key == c.ContractTypeId).FirstOrDefault().Value,
                    StartDate = c.StartDate.Value.ToString("dd/mm/yyyy"),
                    EndDate = c.EndDate.Value.ToString("dd/mm/yyyy")
                })
                .ToList();
        }
    }
}
