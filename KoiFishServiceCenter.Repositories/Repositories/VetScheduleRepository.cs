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

            var vetSchedule = await _dbContext.VetSchedules.Where(p => p.ScheduleId.Equals(Id)).FirstOrDefaultAsync();
            return vetSchedule;
            
        }

        public async Task<List<VetSchedule>> GetVetSchedulesAsync()
        {
            return await _dbContext.VetSchedules.ToListAsync();
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
    }
}
