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
    
    public class ServiceRepository : IServiceRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;

        public ServiceRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddService(Service service)
        {
            try
            {
                _dbContext.Services.Add(service);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelService(Service service)
        {
            try
            {
                _dbContext.Services.Remove(service);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelService(int Id)
        {
            try
            {
                var objDel = _dbContext.Services.Where(p => p.ServiceId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Services.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _dbContext.Services.Where(p => p.ServiceId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Service>> GetServices()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public bool UpdateService(Service service)
        {
            try
            {
                _dbContext.Services.Update(service);
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
