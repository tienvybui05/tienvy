using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories;
using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> DeleteCustomerAsync(Customer customer);
        Task<bool> AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<int> CountCustomersAsync();
        Task<SelectList> GetAllCustomersAsync();
    }
}
