using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class CostRepository : ICostRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public CostRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task <List<Cost>> GetAllCostAsync()
        {
            List<Cost> costs = null;
            try
            {
                costs = await _dbContext.Costs.ToListAsync();
            }
            catch (Exception ex)
            {
                costs?.Add(new Cost());
            }
            return costs;
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
            return await _dbContext.Costs.Where(p => p.CostId.Equals(costId)).FirstOrDefaultAsync();
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
    }
}
