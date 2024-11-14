using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Services.Interfaces;
using KoiFishServiceCenter.Services.Services;

namespace KoiServiceCenter.WebApp.Pages.Services.Book
{
    public class IndexModel : PageModel
    {
        private readonly IServiceHistoryService _service;
        private readonly IVetScheduleService _vetScheduleService;
        public IndexModel(IServiceHistoryService service, IVetScheduleService vetScheduleService)
        {
            _service = service;
            _vetScheduleService = vetScheduleService;
        }

        public async Task<IActionResult> OnGet()
        {
            int ranDumID;
            ranDumID = await _service.CreateId();

            ServiceHistory = new ServiceHistory
            {
                HistoryId = ranDumID
            };
            // Load c�c ViewData kh�c n?u c?n
            ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
            ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
            ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");

            return Page();
        }


        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }
        public VetSchedule VetSchedule { get; set; }


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            //await _service.AddServiceHistory(ServiceHistory);
            var checkID = await _service.GetServiceHistoryById(ServiceHistory.HistoryId);
            var checkDateTime = await _service.BundByDate(ServiceHistory);
            if (checkID != null)
            {
                ModelState.AddModelError("ServiceHistory.HistoryId", "M� ??n d?ch v? ?� t?n t?i. Vui l�ng nh?p m� kh�c.");
                ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
                ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
                ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
                return Page();
            }
            if (checkDateTime == false)
            {
                ModelState.AddModelError("ServiceHistory.ServiceDate", "B�c s? ?� c� l?ch. Vui l�ng ch?n ng�y kh�c.");
                ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
                ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
                ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
                return Page();
            }
            else
            {
                await _service.AddServiceHistory(ServiceHistory);
                bool check = false;
                Random random = new Random();
                int ranDumID;
                do
                {
                    ranDumID = random.Next(1, 1001);
                    var x = await _service.GetServiceHistoryById(ranDumID);
                    if (x == null)
                    {
                        check = true;
                    }

                } while (check != true);
                VetSchedule = new VetSchedule();
                VetSchedule.ScheduleId = ranDumID;
                VetSchedule.VeterinarianId = ServiceHistory.VeterinarianId;
                VetSchedule.ScheduleDate = ServiceHistory.ServiceDate;
                ViewData["VeterinarianId"] = _vetScheduleService.GetVeterinarianSelect();
                await _vetScheduleService.AddVetSchedule(VetSchedule);// Th�m v�o l?ch l�m vi?c c?a b�c s?

                return Redirect(Url.Page("/Services/Datlichthanhcong/Index"));
            }
        }
    }
}