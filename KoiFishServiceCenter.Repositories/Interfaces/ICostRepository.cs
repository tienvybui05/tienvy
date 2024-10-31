using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface ICostRepository
    {
        Task<List<Cost>> GetAllCostAsync();
        Task<Cost> GetCostByIdAsync(int costId);
        Task<bool> AddCostAsync(Cost cost);
        Task<bool> DeleteCostByIdAsync(int costId);
        Task<bool> DeleteCostAsync(Cost cost);
        Task<bool> UpdateCostAsync(Cost cost);
    }
}
