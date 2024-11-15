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
    public class VetScheduleRepository : IVetScheduleRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public VetScheduleRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                var valuee = await _dbContext.VetSchedules
                            .Where(p => p.ScheduleId == vetSchedule.ScheduleId )
                            .FirstOrDefaultAsync();
                DateTime currentDate = DateTime.Today;
                if(vetSchedule.ScheduleDate  <   currentDate )
                {
                    return false;
                }   
                if (valuee != null)
                {
                    throw new InvalidOperationException("ID đã tồn tại");
                }
                await _dbContext.VetSchedules.AddAsync(vetSchedule);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }


        public async Task<bool> DelVetSchedule(int Id)
        {
           
            try
            {
                var objDel = await _dbContext.VetSchedules.Where(p => p.ScheduleId.Equals(Id)).FirstOrDefaultAsync();
                if (objDel != null)
                {
                    _dbContext.VetSchedules.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
                   
            }
            catch(Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public async Task<bool> DelVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                 _dbContext.VetSchedules.Remove(vetSchedule);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<VetSchedule> GetVetScheduleById(int Id)
        {

            return await _dbContext.VetSchedules.Include(v => v.Veterinarian).FirstOrDefaultAsync(m => m.ScheduleId == Id);


        }

        public async Task<List<VetSchedule>> GetVetSchedulesAsync()
        {
            return await _dbContext.VetSchedules.Include(v => v.Veterinarian).ToListAsync();
        }

        public async Task<bool> UpdateVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                DateTime currentDate = DateTime.Today;
                if (vetSchedule.ScheduleDate < currentDate)
                {
                    return false;
                }
                _dbContext.VetSchedules.Update(vetSchedule);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<List<VetSchedule>> SearchAsync(DateTime dateTime)
        {
            return await _dbContext.VetSchedules.Where(a => (a.ScheduleDate.Day == dateTime.Day) &&
                                                            (a.ScheduleDate.Month == dateTime.Month) &&
                                                            (a.ScheduleDate.Year == dateTime.Year)).ToListAsync();
        }
        public SelectList GetVeterinarianSelect()
        {
            var veterinarians = _dbContext.UserAccounts
               .Where(u => u.Role == "veterinarian")
               .ToList();
            return new SelectList(veterinarians, "UserId", "UserName");
        }
        public async Task<int> CountVetSchedule()
        {
            int count = 0;
            var ojb = await _dbContext.VetSchedules.Include(v => v.Veterinarian).ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;

        }
        public async Task<bool> BundByDate(VetSchedule vetSchedule)
        {
            var check = await _dbContext.VetSchedules.Include(v => v.Veterinarian).FirstOrDefaultAsync(m =>
            m.VeterinarianId == vetSchedule.VeterinarianId &&
           (m.ScheduleDate.Day == vetSchedule.ScheduleDate.Day &&
            m.ScheduleDate.Month == vetSchedule.ScheduleDate.Month &&
            m.ScheduleDate.Year == vetSchedule.ScheduleDate.Year)
           );
            if (check != null) { return false; }
            return true;
        }

        public async Task<int> CreateId()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1,1001);
                var ojb = await GetVetScheduleById(id);
                if(ojb == null)
                {
                    return id;
                }
            } while (true);
        }
        public async Task<List<VetSchedule>> GetWordSchedule(int id, DateTime dateTime)
        {
            var x = await _dbContext.UserAccounts.FindAsync(id);
            if (x == null)
            {
                return new List<VetSchedule>(); // Nếu không tìm thấy User, trả về danh sách rỗng
            }

            var query = _dbContext.VetSchedules.AsQueryable();

            // Lọc theo ngày nếu có
            if (dateTime != DateTime.MinValue)
            {
                query = query.Where(a => a.ScheduleDate.Day == dateTime.Day &&
                                          a.ScheduleDate.Month == dateTime.Month &&
                                          a.ScheduleDate.Year == dateTime.Year);
            }

            // Lọc theo UserName
            query = query.Where(v => v.Veterinarian.UserName == x.UserName);

            // Sử dụng Include để tải Veterinarian (không áp dụng điều kiện vào Include)
            return await query.Include(v => v.Veterinarian).ToListAsync();

        }
    }
}
