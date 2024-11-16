using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "CustomerOnly")]
    public class CancelServiceOrderModel : PageModel
    {
        readonly IServiceHistoryService _service;

        public CancelServiceOrderModel(IServiceHistoryService service)
        {
            _service = service;
        }

        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            ServiceHistory = await _service.GetServiceHistoryById(ID);

            if (ServiceHistory != null)
            {
                await _service.DelServiceHistory(ServiceHistory);
            }

            return RedirectToPage("/Account/ServiceBookingHistory");
        }
    }
}
