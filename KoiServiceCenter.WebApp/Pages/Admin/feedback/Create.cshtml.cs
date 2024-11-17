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

namespace KoiServiceCenter.WebApp.Pages.Admin.feedback
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class CreateModel : PageModel
    {
        private readonly IFeedbackService _service;

        public CreateModel(IFeedbackService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            Feedback = new Feedback
            {
                FeedbackId = await _service.CreateId()
            };
            ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
            ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(await _service.AddFeedback(Feedback)==false)
            {
                ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
                ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
                return Page();
            }    
        

            return RedirectToPage("./Index");
        }
    }
}
