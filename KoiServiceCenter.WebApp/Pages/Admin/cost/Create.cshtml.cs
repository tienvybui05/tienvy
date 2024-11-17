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

namespace KoiServiceCenter.WebApp.Pages.Admin.cost
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class CreateModel : PageModel
    {
        private readonly ICostService _service;

        public CreateModel(ICostService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            Cost = new Cost()
            {
                CostId = await _service.CreateId()
            };
            ViewData["ServiceId"] = _service.GetCostSelect("ServiceId");
            return Page();
        }

        [BindProperty]
        public Cost Cost { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Cost.Cost1<0)
            {
                ModelState.AddModelError("Cost.Cost1", "Không được phép âm.");

            } 
            if(Cost.AdditionalFees<0)
            {
                ModelState.AddModelError("Cost.AdditionalFees", "Không được phép âm.");
              
            }    
            if(await _service.AddCostAsync(Cost)==false)
            {
                ViewData["ServiceId"] = _service.GetCostSelect("ServiceId");
                ModelState.AddModelError(string.Empty, "Thêm dữ liệu không thành công. Vui lòng thử lại.");
                return Page();
            }    

            return RedirectToPage("./Index");
        }
    }
}
