using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<bool> DelVetSchedule(int Id);
        Task<bool> DelVetSchedule(VetSchedule vetSchedule);
        Task<bool> AddVetSchedule(VetSchedule vetSchedule);
        Task<bool> UpdateVetSchedule(VetSchedule vetSchedule);
        Task<VetSchedule> GetVetScheduleById(int Id);
        Task<List<VetSchedule>> SearchAsync(DateTime dateTime);
        SelectList GetVeterinarianSelect();
        Task<int> CountSchedule();
        Task<bool> BundByDate(VetSchedule vetSchedule);

    }
}
