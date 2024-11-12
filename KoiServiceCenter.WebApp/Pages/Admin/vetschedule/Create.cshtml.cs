using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.vetschedule
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class CreateModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public CreateModel(IVetScheduleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {

            VetSchedule = new VetSchedule
            {
                ScheduleId = await _service.CreateId()
            };
            ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
            return Page();
        }

        [BindProperty]
        public VetSchedule VetSchedule { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            var checkDateTime = await _service.BundByDate(VetSchedule);
            if (checkDateTime == false)
            {
                ModelState.AddModelError("VetSchedule.ScheduleDate", "Bác sĩ đã có lịch. Vui lòng chọn ngày khác.");
                ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
                return Page();
            }
            else
            {
                if(await _service.AddVetSchedule(VetSchedule) == false)
                {
                    ModelState.AddModelError("VetSchedule.ScheduleDate", "Không hợp lệ.");
                    ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
                    return Page();
                }    
                return RedirectToPage("./Index");
            }
        }
    }
}
