using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.vetschedule
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class DeleteModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public DeleteModel(IVetScheduleService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //VetSchedule = await _context.VetSchedules.FindAsync(id);

            //if (VetSchedule != null)
            //{
            //    _context.VetSchedules.Remove(VetSchedule);
            //    await _context.SaveChangesAsync();
            //}
            await _service.DelVetSchedule(VetSchedule);
            return RedirectToPage("./Index");
        }
    }
}
