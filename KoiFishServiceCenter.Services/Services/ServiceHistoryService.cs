using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Task<bool> AddServiceHistory(ServiceHistory serviceHistory)
        {
           return _repository.AddServiceHistory(serviceHistory);
        }

        public Task<bool> DelServiceHistory(int Id)
        {
            return _repository.DelServiceHistory(Id);
        }

        public Task<bool>  DelServiceHistory(ServiceHistory serviceHistory)
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

        public Task<bool> UpdateServiceHistory(ServiceHistory serviceHistory)
        {
            return _repository.UpdateServiceHistory(serviceHistory);
        }
        public SelectList GetServiceHistorySelect(string viewData)
        {
            return _repository.GetServiceHistorySelect(viewData);
        }
        public Task<List<ServiceHistory>> SearcheAsync(string searchString)
        {
            return _repository.SearcheAsync(searchString);
        }
        public Task<int> CountServiceHistory()
        {
            return _repository.CountServiceHistory();
        }
        public Task<bool> BundByDate(ServiceHistory serviceHistory)
        {
            return _repository.BundByDate(serviceHistory);
        }

        public Task<List<ServiceHistory>> HistoryServices(int id)
        {
            return _repository.HistoryServices(id); 
        }
    }
}
