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
    public interface ICustomerService
    {
        List<Customer> GetAll();
        bool DeleteCustomer(int customerId);
        bool SaveCustomer(Customer input);
        bool EditCustomer(Customer input);
    }

    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public bool DeleteCustomer(int customerId)
        {
            bool result = false;
            var customer = _customerRepository.GetById(customerId);
            if(customer != null)
            {
                customer.StatusId = CommonStatus.DELETE;
                customer.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customer.LastUpdateBy = Common.Session.GetId();
                _customerRepository.Delete(customer);
                result = true;
            }

            return result;
        }

        public bool EditCustomer(Customer input)
        {
            bool result = false;
            var customer = _customerRepository.GetById(input.Id);
            if (customer != null)
            {
                customer.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customer.LastUpdateBy = Common.Session.GetId();
                _customerRepository.Delete(customer);
                result = true;
            }

            return result;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public bool SaveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
