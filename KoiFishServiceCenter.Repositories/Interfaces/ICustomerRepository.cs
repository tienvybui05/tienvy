using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomerAsync();
        bool DelCusomer(int Id);
        bool DelCustomer(Customer customer);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        Task<Customer> GetCustomer(int Id);
    }
}
