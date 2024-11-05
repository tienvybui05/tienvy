using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.feedback
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _service;

        public CreateModel(IFeedbackService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
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
            await _service.AddFeedback(Feedback);
            //_context.Feedbacks.Add(Feedback);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
