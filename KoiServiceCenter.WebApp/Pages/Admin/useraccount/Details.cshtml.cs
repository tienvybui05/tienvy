using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext _context;

        public DetailsModel(KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext context)
        {
            _context = context;
        }

        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccounts.FirstOrDefaultAsync(m => m.UserId == id);

            if (UserAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
