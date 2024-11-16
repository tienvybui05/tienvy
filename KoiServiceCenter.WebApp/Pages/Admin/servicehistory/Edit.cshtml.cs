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

namespace KoiServiceCenter.WebApp.Pages.Admin.servicehistory
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class EditModel : PageModel
    {
        private readonly IServiceHistoryService _service;
        private readonly IVetScheduleService _vetScheduleService;
        public EditModel(IServiceHistoryService service, IVetScheduleService vetScheduleService)
        {
            _service = service;
            _vetScheduleService = vetScheduleService;
        }

        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }
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
            ServiceHistory = await _service.GetServiceHistoryById(ID);

            if (ServiceHistory == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
            ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
            ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
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

            var checkDateTime = await _service.BundByDate(ServiceHistory);
            if (checkDateTime == false)
            {
                ModelState.AddModelError("ServiceHistory.ServiceDate", "Bác sĩ đã có lịch. Vui lòng chọn ngày khác.");
                ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
                ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
                ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
                return Page();
            }
            else
            {
                if(await _service.UpdateServiceHistory(ServiceHistory)==false)
                {
                    ModelState.AddModelError("ServiceHistory.ServiceDate", "Không hợp lệ. Vui lòng chọn ngày khác.");
                    ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
                    ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
                    ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
                    return Page();
                }    
                VetSchedule = new VetSchedule();
                VetSchedule.VeterinarianId = ServiceHistory.VeterinarianId;
                VetSchedule.ScheduleDate = ServiceHistory.ServiceDate;
                ViewData["VeterinarianId"] = _vetScheduleService.GetVeterinarianSelect();
                await _vetScheduleService.UpdateVetSchedule(VetSchedule);
            }

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceHistoryExists(ServiceHistory.HistoryId))
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

        private bool ServiceHistoryExists(int id)
        {
            return _service.GetServiceHistoryById(id) != null;
        }
    }
}
