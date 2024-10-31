using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Services.Interfaces;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;

namespace KoiFishServiceCenter.Services.Services
{
    public class CostService : ICostService
    {
        private readonly ICostRepository _costRepository;
        public CostService(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        public Task<bool> AddCostAsync(Cost cost)
        {
            return _costRepository.AddCostAsync(cost);
        }
        public Task<bool> DeleteCostAsync(Cost cost)
        {
            return _costRepository.DeleteCostAsync(cost);
        }
        public async Task<List<Cost>> GetAllCostAsync()
        {
            return await _costRepository.GetAllCostAsync();
        }
        public Task<Cost> GetCostByIdAsync(int costId)
        {
            return _costRepository.GetCostByIdAsync(costId);
        }
        public Task<bool> DeleteCostByIdAsync(int costId)
        {
            return _costRepository.DeleteCostByIdAsync(costId);
        }
        public Task<bool> UpdateCostAsync(Cost cost)
        {
            return _costRepository.UpdateCostAsync(cost);
        }
    }
}
