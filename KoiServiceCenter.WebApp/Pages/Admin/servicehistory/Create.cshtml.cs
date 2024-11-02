using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.servicehistory
{
    public class CreateModel : PageModel
    {
        private readonly IServiceHistoryService _service;

        public CreateModel(IServiceHistoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
            ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
            ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
            return Page();
        }

        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddServiceHistory(ServiceHistory);

            return RedirectToPage("./Index");
        }
    }
}
