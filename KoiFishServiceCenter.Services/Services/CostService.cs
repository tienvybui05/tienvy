using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Services.Interfaces;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiFishServiceCenter.Services.Services
{
    public class CostService : ICostService
    {
        private readonly ICostRepository _costRepository;
        public CostService(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        public async Task<bool> AddCostAsync(Cost cost)
        {
            if(cost.Cost1<0||cost.AdditionalFees<0)
            {
                return false;
            }    
            return await _costRepository.AddCostAsync(cost);
        }
        public Task<bool> DeleteCostAsync(Cost cost)
        {
            return _costRepository.DeleteCostAsync(cost);
        }
        public Task<Cost> GetCostByIdAsync(int costId)
        {
            return _costRepository.GetCostByIdAsync(costId);
        }
        public Task<bool> DeleteCostByIdAsync(int costId)
        {
            return _costRepository.DeleteCostByIdAsync(costId);
        }
        public async Task<bool> UpdateCostAsync(Cost cost)
        {
            if (cost.Cost1 < 0 || cost.AdditionalFees < 0)
            {
                return false;
            }
            return await _costRepository.UpdateCostAsync(cost);
        }

        public Task<int> CountCostAsync()
        {
            return _costRepository.CountCostAsync();
        }

        public Task<List<Cost>> SearchAsync(int search)
        {
            return _costRepository.SearchAsync(search);
        }

        public SelectList GetCostSelect(string viewData)
        {
            return _costRepository.GetCostSelect(viewData);
        }

        public Task<List<Cost>> GetCostsAsync()
        {
            return _costRepository.GetCostsAsync();
        }
        public Task<int> CreateId()
        {
            return _costRepository.CreateId();
        }
    }
}
