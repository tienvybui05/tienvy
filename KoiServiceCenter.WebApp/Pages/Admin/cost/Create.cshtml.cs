using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.cost
{
    public class CreateModel : PageModel
    {
        private readonly ICostService _service;

        public CreateModel(ICostService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
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

            await _service.AddCostAsync(Cost);

            return RedirectToPage("./Index");
        }
    }
}
