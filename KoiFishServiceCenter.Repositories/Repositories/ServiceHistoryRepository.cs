using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<bool> AddServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                 await _dbContext.ServiceHistories.AddAsync(serviceHistory);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelServiceHistory(int Id)
        {
            try
            {
                var objDel = await _dbContext.ServiceHistories.Where(p => p.HistoryId.Equals(Id)).FirstOrDefaultAsync();
                if (objDel != null)
                {
                    _dbContext.ServiceHistories.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public async Task<bool> DelServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                _dbContext.ServiceHistories.Remove(serviceHistory);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<ServiceHistory>> GetServiceHistories()
        {
            return await _dbContext.ServiceHistories.Include(s => s.Customer)
                .Include(s => s.Service)
                .Include(s => s.Veterinarian).ToListAsync();
        }

        public async Task<ServiceHistory> GetServiceHistoryById(int Id)
        {
            return await _dbContext.ServiceHistories.Include(s => s.Customer)
               .Include(s => s.Service)
               .Include(s => s.Veterinarian).FirstOrDefaultAsync(m => m.HistoryId == Id);
        }

        public async Task<bool> UpdateServiceHistory(ServiceHistory serviceHistory)
        {
            try
            {
                _dbContext.ServiceHistories.Update(serviceHistory);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<List<ServiceHistory>> SearcheAsync(string searchString)
        {
            return await _dbContext.ServiceHistories.Where(a => a.Customer.FullName.Contains(searchString)).Include(s => s.Customer)
                .Include(s => s.Service)
                .Include(s => s.Veterinarian).ToListAsync();

        }
        public SelectList GetServiceHistorySelect(string viewData)
        {
            if (viewData == "CustomerId")
            {
                return new SelectList(_dbContext.Customers, "CustomerId", "FullName");
            }
            else if (viewData == "ServiceId")
            {
                return new SelectList(_dbContext.Services, "ServiceId", "Description");
            }
            else
            {
                var veterinarians = _dbContext.UserAccounts
              .Where(u => u.Role == "veterinarian")
              .ToList();
                return new SelectList(veterinarians, "UserId", "UserName");
            }
        }
        public async Task<int> CountServiceHistory()
        {
            int count = 0;
            var ojb = await _dbContext.ServiceHistories.Include(s => s.Customer)
                .Include(s => s.Service)
                .Include(s => s.Veterinarian).ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;

        }
        public async Task<bool> BundByDate(ServiceHistory serviceHistory)
        {
            var check = await _dbContext.VetSchedules.Include(v => v.Veterinarian).FirstOrDefaultAsync(m =>
            m.VeterinarianId == serviceHistory.VeterinarianId &&
           (m.ScheduleDate.Day == serviceHistory.ServiceDate.Day &&
            m.ScheduleDate.Month == serviceHistory.ServiceDate.Month &&
            m.ScheduleDate.Year == serviceHistory.ServiceDate.Year)
           );
            if (check != null) { return false; }
            return true;
        }

        public async Task<List<ServiceHistory>> HistoryServices(int id)
        {
            Customer accounts = await _dbContext.Customers.FirstOrDefaultAsync(p => p.UserId == id);
            if (accounts != null)
            {
                int x = accounts.CustomerId;
                return await _dbContext.ServiceHistories.Include(s => s.Customer)
                                                .Include(s => s.Service)
                                                .Include(s => s.Veterinarian)
                                                .Where(m => m.CustomerId == x) 
                                                .ToListAsync();
            }
            return null;
        }
    }
}
