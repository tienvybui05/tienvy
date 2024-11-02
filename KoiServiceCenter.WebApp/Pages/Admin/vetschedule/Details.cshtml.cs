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
    public class DetailsModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public DetailsModel(IVetScheduleService service)
        {
            _service = service;
        }

        public VetSchedule VetSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            VetSchedule = await _service.GetVetScheduleById(ID);

            if (VetSchedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
