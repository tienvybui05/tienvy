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
    }
}
