using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.feedback
{
    public class DeleteModel : PageModel
    {
        private readonly IFeedbackService _service;

        public DeleteModel(IFeedbackService service)
        {
            _service = service;
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            Feedback = await _service.GetFeedbackById(Id);
                //.Include(f => f.Customer)
                //.Include(f => f.Service).FirstOrDefaultAsync(m => m.FeedbackId == id);

            if (Feedback == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            int Id;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            Feedback = await _service.GetFeedbackById(Id);

            if (Feedback != null)
            {
                await _service.DelFeedback(Feedback);
                //_context.Feedbacks.Remove(Feedback);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
