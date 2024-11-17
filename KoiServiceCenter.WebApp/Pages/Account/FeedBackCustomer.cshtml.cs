using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "CustomerOnly")]
    public class FeedBackCustomerModel : PageModel
    {
        private readonly IFeedbackService _service;
        private readonly IServiceHistoryService _historyService;
        public FeedBackCustomerModel(IFeedbackService service, IServiceHistoryService historyService)
        {
            _service = service;
            _historyService = historyService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            ServiceHistory = await _historyService.GetServiceHistoryById(ID);

            if (ServiceHistory == null)
            {
                return NotFound();
            }
            Feedback = new Feedback
            {
                FeedbackId = await _service.CreateId(),
                ServiceId = ServiceHistory.ServiceId,
                CustomerId = ServiceHistory.CustomerId

            };
            ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
            ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }
        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
                ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
                return Page();
            }
            if (await _service.AddFeedback(Feedback) == false)
            {
                ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
                ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
                return Page();
            }


            return RedirectToPage("/Account/ServiceBookingHistory");
        }
    }
}
