using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class ServiceHistoryRepository : IServiceHistoryRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public ServiceHistoryRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                _dbContext.ServiceHistories.Add(serviceHistory);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelServiceHistory(int Id)
        {
            try
            {
                var objDel = _dbContext.ServiceHistories.Where(p => p.HistoryId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.ServiceHistories.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public bool DelServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                _dbContext.ServiceHistories.Remove(serviceHistory);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<ServiceHistory>> GetServiceHistories()
        {
            return await _dbContext.ServiceHistories.ToListAsync();
        }

        public async Task<ServiceHistory> GetServiceHistoryById(int Id)
        {
            return await _dbContext.ServiceHistories.Where(p => p.HistoryId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                _dbContext.ServiceHistories.Update(serviceHistory);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
