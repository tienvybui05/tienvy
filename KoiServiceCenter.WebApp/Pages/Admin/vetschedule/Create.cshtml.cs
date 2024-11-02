using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.vetschedule
{
    public class CreateModel : PageModel
    {
        private readonly IVetScheduleService _service;

        public CreateModel(IVetScheduleService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["VeterinarianId"] = _service.GetVeterinarianSelect();
            return Page();
        }

        [BindProperty]
        public VetSchedule VetSchedule { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.VetSchedules.Add(VetSchedule);
            //await _context.SaveChangesAsync();
            await _service.AddVetSchedule(VetSchedule);
            return RedirectToPage("./Index");
        }
    }
}
