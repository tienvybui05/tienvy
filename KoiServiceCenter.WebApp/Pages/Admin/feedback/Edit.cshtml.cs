
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

namespace KoiServiceCenter.WebApp.Pages.Admin.feedback
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class EditModel : PageModel
    {
        private readonly IFeedbackService _service;

        public EditModel(IFeedbackService service)
        {
            _service=service;
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

            ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
           ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
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

            if(await _service.UpdateFeedback(Feedback)==false)
            {
                ModelState.AddModelError("Feedback.Rating", "Không hợp lệ.");
                ViewData["CustomerId"] = _service.GetFeedbackSelect("CustomerId");
                ViewData["ServiceId"] = _service.GetFeedbackSelect("ServiceId");
                return Page();
            }    

            try
            {
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(Feedback.FeedbackId))
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

        private bool FeedbackExists(int id)
        {
            return _service.GetFeedbackById(id)!=null;
        }
    }
}
