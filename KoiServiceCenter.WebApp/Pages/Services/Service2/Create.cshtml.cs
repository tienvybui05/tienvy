using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Services.Dieutribenhchoca
{
    public class CreateModel : PageModel
    {
        private readonly KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext _context;

        public CreateModel(KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Description");
            ViewData["VeterinarianId"] = new SelectList(_context.UserAccounts, "UserId", "Email");
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

            _context.ServiceHistories.Add(ServiceHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
