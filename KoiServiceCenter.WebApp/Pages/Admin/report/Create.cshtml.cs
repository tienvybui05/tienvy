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

namespace KoiServiceCenter.WebApp.Pages.Admin.report
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class CreateModel : PageModel
    {
        private readonly IReportService _service;

        public CreateModel(IReportService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {

            Report = new Report
            {
                ReportId = await _service.CreateId()
            };
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            void AddValidationError(bool condition, string key, string errorMessage)
            {
                if (condition)
                {
                    ModelState.AddModelError(key, errorMessage);
                }
            }

            
            AddValidationError(Report.TotalServices < 0, "Report.TotalServices", "Không được nhập số âm. Vui lòng chọn ngày khác.");
            AddValidationError(Report.TotalCustomers < 0, "Report.TotalCustomers", "Không được nhập số âm. Vui lòng chọn ngày khác.");
            AddValidationError(Report.AverageRating < 0 || Report.AverageRating > 5, "Report.AverageRating", "Chỉ được phép nhập từ 1 đến 5 *");

            if (!await _service.AddReportAsync(Report))
            {
                AddValidationError(true, "Report.ReportDate", "Không hợp lệ, vui lòng nhập ngày mới");
            }

           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index"); 
        }
    }
}
