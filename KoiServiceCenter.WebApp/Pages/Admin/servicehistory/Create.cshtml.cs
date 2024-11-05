using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.servicehistory
{
    public class CreateModel : PageModel
    {
        private readonly IServiceHistoryService _service;
		private readonly IVetScheduleService _vetScheduleService;
		public CreateModel(IServiceHistoryService service, IVetScheduleService vetScheduleService)
		{
			_service = service;
			_vetScheduleService = vetScheduleService;
		}
		//public CreateModel(IServiceHistoryService service)
		//{
		//    _service = service;
		//}

		public IActionResult OnGet()
        {
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _service.AddServiceHistory(ServiceHistory);
            var checkID = await _service.GetServiceHistoryById(ServiceHistory.HistoryId);
            var checkDateTime = await _service.BundByDate(ServiceHistory);
            if (checkID != null)
            {
                ModelState.AddModelError("ServiceHistory.HistoryId", "Mã đơn dịch vụ đã tồn tại. Vui lòng nhập mã khác.");
                ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
                ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
                ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
                return Page();
            }
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
                await _vetScheduleService.AddVetSchedule(VetSchedule);// Thêm vào lịch làm việc của bác sĩ


                return RedirectToPage("./Index");
            }    
        }
    }
}
