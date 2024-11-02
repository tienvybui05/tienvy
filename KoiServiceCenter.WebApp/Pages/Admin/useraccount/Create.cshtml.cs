using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
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
            return Page();
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserAccounts.Add(UserAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
