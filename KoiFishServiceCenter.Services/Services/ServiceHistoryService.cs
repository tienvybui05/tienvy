using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Services
{
    public class ServiceHistoryService : IServiceHistoryService
    {
        private readonly IServiceHistoryRepository _repository;
        public ServiceHistoryService(IServiceHistoryRepository repository)
        {
            _repository = repository;
        }
        public bool AddServiceHistory(ServiceHistory serviceHistory)
        {
           return _repository.AddServiceHistory(serviceHistory);
        }

        public bool DelServiceHistory(int Id)
        {
            return _repository.DelServiceHistory(Id);
        }

        public bool DelServiceHistory(ServiceHistory serviceHistory)
        {
            return _repository.DelServiceHistory(serviceHistory);
        }

        public Task<List<ServiceHistory>> GetServiceHistories()
        {
           return _repository.GetServiceHistories();
        }

        public Task<ServiceHistory> GetServiceHistoryById(int Id)
        {
            return _repository.GetServiceHistoryById(Id);
        }

        public bool UpdateServiceHistory(ServiceHistory serviceHistory)
        {
            return _repository.UpdateServiceHistory(serviceHistory);
        }
    }
}
