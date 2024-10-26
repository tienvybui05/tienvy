using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface ICostService
    {
        Task<List<Cost>>GetCostAsync();
        Task<int> AddCostAsync(Cost cost);
        Task<int> RemoveCostAsync(int costId);
        Task<bool> DeleteCostAsync(int costId);
        Task<int>UpdateCost(Cost cost);
    }
}
