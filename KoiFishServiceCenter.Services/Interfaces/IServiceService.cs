using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IServiceService
    {
        Task<List<Service>> GetServicesAsync();
        Task<Service> GetServicerById(int id);
        Task<bool> DelService(int id);
        Task<bool> DelService(Service service);
        Task<bool> AddService(Service service);
        Task<bool> UpdateService(Service service);
        Task<int> CountService();
    }
}
