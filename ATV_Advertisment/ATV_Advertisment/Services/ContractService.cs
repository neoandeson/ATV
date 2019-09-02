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
        Contract GetByCode(string code);
        List<Contract> GetAll();
        List<ContractViewModel> GetForList();
        int DeleteContract(int id);
        Contract AddContract(Contract input);
        int EditContract(Contract input);
        int CancelContract(int id);
        double UpdateContractCost(string contractCode);
    }

    public class ContractService : IContractService
    {
        private readonly ContractRepository _ContractRepository;
        private readonly ContractDetailService _contractDetailService;
        private readonly ContractTypeRepository _contractTypeRepository;

        public ContractService()
        {
            _ContractRepository = new ContractRepository();
            _contractDetailService = new ContractDetailService();
            _contractTypeRepository = new ContractTypeRepository();
        }

        public Contract AddContract(Contract input)
        {
            Contract result = null;
            if (input != null)
            {
                //TODO: Define if seperative contract
                //bool isExisted = _ContractRepository.Exist(t => t.Length == input.Length);
                //if (!isExisted)
                input.StatusId = CommonStatus.ACTIVE;
                input.CreateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateBy = Common.Session.GetId();
                result = _ContractRepository.Create(input);
            }

            return result;
        }

        public int CancelContract(int id)
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

        public Contract GetByCode(string code)
        {
            return _ContractRepository.Get(c => c.Code == code).FirstOrDefault();
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
                    Id = c.Id,
                    ContractCode = c.Code,
                    CustomerCode = c.CustomerCode,
                    ContractType = contractTypes.Where(s => s.Key == c.ContractTypeId).FirstOrDefault().Value,
                    StartDate = c.StartDate.Value.ToString("dd/MM/yyyy"),
                    EndDate = c.EndDate.Value.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        public double UpdateContractCost(string contractCode)
        {
            double result = 0;

            Contract contract = GetByCode(contractCode);
            if(contract != null)
            {
                List<ContractDetail> contractDetails = _contractDetailService.GetAllByContractCode(contractCode);
                foreach (var cd in contractDetails)
                {
                    result += cd.TotalCost;
                }

                contract.Cost = result;
                EditContract(contract);
            }

            return result;
        }
    }
}
