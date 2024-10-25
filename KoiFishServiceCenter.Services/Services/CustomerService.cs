using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
namespace KoiFishServiceCenter.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repsitory;
        public CustomerService(ICustomerRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public bool AddCustomer(Customer customer)
        {
           return _repsitory.AddCustomer(customer);
        }

        public bool DelCusomer(int Id)
        {
            return _repsitory.DelCusomer(Id);
        }

        public bool DelCustomer(Customer customer)
        {
            return _repsitory.DelCustomer(customer);
        }

        public Task<Customer> GetCustomer(int Id)
        {
            return _repsitory.GetCustomer(Id);
        }

        public Task<List<Customer>> GetCustomerAsync()
        {
            return _repsitory.GetCustomerAsync();
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _repsitory.UpdateCustomer(customer);
        }
    }
}
