using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public CustomerRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            try
            {
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<int> CountCustomersAsync()
        {
            return await _dbContext.Customers.CountAsync();
        }

        public async Task<bool> DelCustomer(int Id)
        {
            try
            {
                var customer = await _dbContext.Customers.FindAsync(Id);
                if (customer != null)
                {
                    _dbContext.Customers.Remove(customer);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DelCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _dbContext.Customers.Include(c => c.User).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            //if (Id <= 0)
            //{
            //    throw new ArgumentException("Id không hợp lệ. Id phải lớn hơn 0.");
            //}
            //else
            //    return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == Id);
            if (Id <= 0)
            {
                throw new ArgumentException("Id không hợp lệ. Id phải lớn hơn 0.");
            }
            else
            {
                return await _dbContext.Customers.Include(c => c.User).FirstOrDefaultAsync(m => m.CustomerId == Id);
            }
        }

        public SelectList GetCustomerSelect()
        {
            return new SelectList(_dbContext.UserAccounts, "UserId", "Email");
        }

        public async Task<List<Customer>> SearcheAsync(string searchString)
        {
            return await _dbContext.Customers.Where(a => a.FullName.Contains(searchString)).Include(c => c.User).ToListAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}