using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories;
using KoiFishServiceCenter.Repositories.Entities;
namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        bool DelCusomer(int Id);
        bool DelCustomer(Customer customer);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        Task<Customer> GetCustomer(int Id);
    }
}
