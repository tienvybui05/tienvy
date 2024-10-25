using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IVetScheduleService
    {
       Task<List<VetSchedule>>GetVetSchedulesAsync();
        bool DelVetSchedule(int Id);
        bool DelVetSchedule(VetSchedule vetSchedule);
        bool AddVetSchedule(VetSchedule vetSchedule);
        bool UpdateVetSchedule(VetSchedule vetSchedule);
        Task<VetSchedule> GetVetScheduleById(int Id);
    }
}
