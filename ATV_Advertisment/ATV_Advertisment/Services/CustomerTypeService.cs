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
        List<CustomerType> GetAll();
        Dictionary<int, string> Getoptions();
    }

    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly CustomerTypeRepository _customerTypeRepository;

        public CustomerTypeService()
        {
            _customerTypeRepository = new CustomerTypeRepository();
        }

        public List<CustomerType> GetAll()
        {
            return _customerTypeRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _customerTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Type);
            return options;
        }
    }
}
