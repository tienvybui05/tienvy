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

        public async Task<bool> AddService(Service service)
        {
            try
            {
                _dbContext.Services.Add(service);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi thêm tài khoản người dùng", ex);
            }
        }

        public async Task<bool> DelService(int id)
        {
            try
            {
                var objDel = await _dbContext.Services.Where(p => p.ServiceId.Equals(id)).FirstOrDefaultAsync();
                if (objDel != null)
                {
                    _dbContext.Services.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi", ex);
            }
        }

        public async Task<bool> DelService(Service service)
        {
            try
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi", ex);
            }
        }

        public async Task<Service> GetServicerById(int id)
        {
            return await _dbContext.Services.Where(p => p.ServiceId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Service>> GetServicesAsync()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<bool> UpdateService(Service service)
        {
            try
            {
                _dbContext.Services.Update(service);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi", ex);
            }
        }

        public async Task<int> CountService()
        {
            int count = 0;
            var ojb = await _dbContext.Services.ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;
        }
        public async Task<List<Service>> SearcheAsync(string searchString)
        {
            // Kiểm tra nếu searchString có thể là decimal khong
            if (decimal.TryParse(searchString, out decimal searchPrice))
            {
                // Tìm kiếm theo ServiceName, Description, Price
                return await _dbContext.Services
                    .Where(a => a.ServiceName.Contains(searchString)
                                || a.Description.Contains(searchString)
                                || a.Price == searchPrice)
                    .Include(s => s.Costs)
                    .Include(s => s.Feedbacks)
                    .Include(s => s.ServiceHistories)
                    .ToListAsync();
            }
            else
            {
                // Tìm kiếm chỉ theo các thuộc tính dạng chuỗi: ServiceName, Description
                return await _dbContext.Services
                    .Where(a => a.ServiceName.Contains(searchString)
                                || a.Description.Contains(searchString))
                    .Include(s => s.Costs)
                    .Include(s => s.Feedbacks)
                    .Include(s => s.ServiceHistories)
                    .ToListAsync();
            }

        }
    }
}
