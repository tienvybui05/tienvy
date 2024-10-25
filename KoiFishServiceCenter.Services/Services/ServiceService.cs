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
        public bool AddService(Service service)
        {
            return _repository.AddService(service);
        }

        public bool DelService(Service service)
        {
            return _repository.DelService(service);
        }

        public bool DelService(int Id)
        {
            return _repository.DelService(Id);
        }

        public Task<Service> GetServiceById(int Id)
        {
            return _repository.GetServiceById(Id);
        }

        public Task<List<Service>> GetServices()
        {
            return _repository.GetServices();
        }

        public bool UpdateService(Service service)
        {
            return _repository.UpdateService(service);
        }
    }
}
