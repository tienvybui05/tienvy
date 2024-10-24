using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface IVetScheduleRepository
    {
        Task<List<VetSchedule>> GetVetSchedulesAsync();
        bool DelVetSchedule(int Id);
        bool DelVetSchedule(VetSchedule vetSchedule);
        bool AddVetSchedule(VetSchedule vetSchedule);
        bool UpdateVetSchedule(VetSchedule vetSchedule);
        Task<VetSchedule> GetVetScheduleById(int Id);
    }
}
