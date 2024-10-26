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

        public Task<int> AddCostAsync(Cost cost)
        {
            return _costRepository.AddCostAsync(cost);
        }
        public Task<bool> DeleteCostAsync(int costId)
        {
            return _costRepository.DeleteCostAsync(costId);
        }
        public async Task<List<Cost>> GetCostAsync()
        {
            return await _costRepository.GetCosts();
        }
        public Task<int> RemoveCostAsync(int costId)
        {
            return _costRepository.RemoveCostAsync(costId);
        }
        public Task<int> UpdateCost(Cost cost)
        {
            return _costRepository.UpdateCost(cost);
        }
    }
}
