using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.vetschedule
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class EditModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public EditModel(IVetScheduleService service)
        {
            _service = service;
        }

        [BindProperty]
        public VetSchedule VetSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            VetSchedule = await _service.GetVetScheduleById(Id);
            if (VetSchedule == null)
            {
                return NotFound();
            }
           ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _service.UpdateVetSchedule(VetSchedule);
            var checkDateTime = await _service.BundByDate(VetSchedule);
            if (checkDateTime == false)
            {
                ModelState.AddModelError("VetSchedule.ScheduleDate", "Bác sĩ đã có lịch. Vui lòng chọn ngày khác.");
                ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
                return Page();
            }
            else
            {
                await _service.UpdateVetSchedule(VetSchedule);
            }
            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetScheduleExists(VetSchedule.ScheduleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VetScheduleExists(int id)
        {
            return _service.GetVetScheduleById(id) != null;
        }
    }
}
