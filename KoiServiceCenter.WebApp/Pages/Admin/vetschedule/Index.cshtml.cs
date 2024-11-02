using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.vetschedule
{
    public class IndexModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public IndexModel(IVetScheduleService service)
        {
            _service = service;
        }

        public IList<VetSchedule> VetSchedule { get;set; }

        //public async Task OnGetAsync()
        //{
        //    VetSchedule = await _context.VetSchedules
        //        .Include(v => v.Veterinarian).ToListAsync();
        //}
        public async Task OnGetAsync(DateTime dateTime)
        {

            if (dateTime != DateTime.MinValue)
            {
                VetSchedule = await _service.SearchAsync(dateTime);
            }
            else
            {
                VetSchedule = await _service.GetVetSchedulesAsync();
            }

        }
    }
}
