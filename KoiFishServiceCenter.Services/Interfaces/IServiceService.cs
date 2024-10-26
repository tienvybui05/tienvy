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
        Boolean AddService(Service service);
        Boolean DelService(Service service);
        Boolean DelService(int Id);
        Boolean UpdateService(Service service);
        Task<Service> GetServiceById(int Id);
    }
}
