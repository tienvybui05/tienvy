using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<Boolean> DelVetSchedule(int Id);
        Task<Boolean> DelVetSchedule(VetSchedule vetSchedule);
        Task<Boolean> AddVetSchedule(VetSchedule vetSchedule);
        Task<Boolean> UpdateVetSchedule(VetSchedule vetSchedule);
        Task<VetSchedule> GetVetScheduleById(int Id);
        Task<List<VetSchedule>> SearchAsync(DateTime dateTime);
        SelectList GetVeterinarianSelect();
        Task<int> CountVetSchedule();
        Task<bool> BundByDate(VetSchedule vetSchedule);

    }
}
