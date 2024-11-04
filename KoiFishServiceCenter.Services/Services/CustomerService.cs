using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Repositories.Repositories;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KoiFishServiceCenter.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repsitory;
        public CustomerService(ICustomerRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            return await _repsitory.AddCustomer(customer);
        }

        public async Task<int> CountCustomersAsync()
        {
            return await _repsitory.CountCustomersAsync();
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _repsitory.DelCustomer(id);
        }

        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            return await _repsitory.DelCustomer(customer);
        }

        public async Task<SelectList> GetAllCustomersAsync()
        {
            var customers = await _repsitory.GetAllCustomersAsync(); 
            return new SelectList(customers, "CustomerId", "FullName");
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _repsitory.GetCustomerById(id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _repsitory.GetCustomerAsync();
        }

        public Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return _repsitory.UpdateCustomer(customer);
        }
    }
}
