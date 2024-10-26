using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IServiceHistoryService
    {
        Task<List<ServiceHistory>> GetServiceHistories();
        bool DelServiceHistory(int Id);
        bool DelServiceHistory(ServiceHistory serviceHistory);
        bool AddServiceHistory(ServiceHistory serviceHistory);
        bool UpdateServiceHistory(ServiceHistory serviceHistory);
        Task<ServiceHistory> GetServiceHistoryById(int Id);
    }
}
