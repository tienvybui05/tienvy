using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class CostRepository : ICostRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public CostRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCostAsync(Cost cost)
        {
            try
            {
                await _dbContext.Costs.AddAsync(cost);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async  Task<bool> DeleteCostByIdAsync(int costId)
        {

            try
            {
                var objDel = _dbContext.Costs.Where(p => p.CostId.Equals(costId)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Costs.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<bool> DeleteCostAsync(Cost cost)
        {
            try
            {
                _dbContext.Costs.Remove(cost);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<Cost> GetCostByIdAsync(int costId)
        {
            return await _dbContext.Costs.Include(s=>s.Service).FirstOrDefaultAsync(m => m.CostId == costId);
        }

        public async Task<bool> UpdateCostAsync(Cost cost)
        {
            try
            {
                _dbContext.Costs.Update(cost);
                 await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<int> CountCostAsync()
        {
            int count = 0;
            var ojb = await _dbContext.ServiceHistories.Include(s => s.Customer)
                .Include(s => s.Service)
                .Include(s => s.Veterinarian).ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;
        }

        public async Task<List<Cost>> SearchAsync(int search)
        {
            return await _dbContext.Costs.Where(a => a.CostId == search).Include(s => s.Service).ToListAsync();   
        }

        public SelectList GetCostSelect(string viewData)
        {
            if (viewData == "CustomerId")
            {
                return new SelectList(_dbContext.Customers, "CustomerId", "FullName");
            }
            else
            {
                return new SelectList(_dbContext.UserAccounts, "UserId", "Email");
            }
        }

        public async Task<List<Cost>> GetCostsAsync()
        {
            return await _dbContext.Costs.Include(s => s.Service).ToListAsync();
        }
    }
}
