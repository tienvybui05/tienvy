using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
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
        public bool AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.AddAsync(customer);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCusomer(int Id)
        {
            try
            {
                var objDel = _dbContext.Customers.Where(p => p.CustomerId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Customers.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public bool DelCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Customer> GetCustomer(int Id)
        {
            return await _dbContext.Customers.Where(p => p.CustomerId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Update(customer);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}