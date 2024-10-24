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
        public bool AddVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                _dbContext.VetSchedules.AddAsync(vetSchedule);
                _dbContext.SaveChanges();
                return true;
             
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public bool DelVetSchedule(int Id)
        {
           
            try
            {
                var objDel = _dbContext.VetSchedules.Where(p => p.ScheduleId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.VetSchedules.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
                   
            }
            catch(Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public bool DelVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                _dbContext.VetSchedules.Remove(vetSchedule);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<VetSchedule> GetVetScheduleById(int Id)
        {
            return await _dbContext.VetSchedules.Where(p => p.ScheduleId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<VetSchedule>> GetVetSchedulesAsync()
        {
            return await _dbContext.VetSchedules.ToListAsync();
        }

        public bool UpdateVetSchedule(VetSchedule vetSchedule)
        {
            try
            {
                _dbContext.VetSchedules.Update(vetSchedule);
                _dbContext.SaveChanges();   
                return true;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
