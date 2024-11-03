using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddService(Service service)
        {
            return _repository.AddService(service);
        }

        public Task<bool> DelService(int id)
        {
            return _repository.DelService(id);
        }

        public Task<bool> DelService(Service service)
        {
            return _repository.DelService(service);
        }

        public Task<Service> GetServicerById(int id)
        {
            return _repository.GetServicerById(id);
        }

        public Task<List<Service>> GetServicesAsync()
        {
            return _repository.GetServicesAsync();
        }

        public Task<bool> UpdateService(Service service)
        {
            return _repository.UpdateService(service);
        }

        public async Task<int> CountService()
        {
            return await _repository.CountService();
        }
    }
}
