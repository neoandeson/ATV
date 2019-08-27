using ATV_Advertisment.Common;
using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ICustomerTypeService
    {
        CustomerType GetById(int id);
        List<CustomerType> GetAll();
        Dictionary<int, string> Getoptions();
        int DeleteCustomerType(int id);
        int AddCustomerType(CustomerType input);
        int EditCustomerType(CustomerType input);
    }

    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly CustomerTypeRepository _customerTypeRepository;

        public CustomerTypeService()
        {
            _customerTypeRepository = new CustomerTypeRepository();
        }

        public int AddCustomerType(CustomerType input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _customerTypeRepository.Exist(t => t.Type == input.Type);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _customerTypeRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                } else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public int DeleteCustomerType(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var customerType = _customerTypeRepository.GetById(id);
            if (customerType != null)
            {
                customerType.StatusId = CommonStatus.DELETE;
                customerType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customerType.LastUpdateBy = Common.Session.GetId();
                _customerTypeRepository.Update(customerType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditCustomerType(CustomerType input)
        {
            int result = CRUDStatusCode.ERROR;
            var customerType = _customerTypeRepository.GetById(input.Id);
            if (customerType != null)
            {
                customerType.Type = input.Type;
                customerType.Description = input.Description;
                
                customerType.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customerType.LastUpdateBy = Common.Session.GetId();
                _customerTypeRepository.Update(customerType);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<CustomerType> GetAll()
        {
            return _customerTypeRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public CustomerType GetById(int id)
        {
            return _customerTypeRepository.GetById(id);
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _customerTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Type);
            return options;
        }
    }
}
