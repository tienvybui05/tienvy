using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Admin.report
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext _context;

        public DetailsModel(KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext context)
        {
            _context = context;
        }

        public Report Report { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Report = await _context.Reports.FirstOrDefaultAsync(m => m.ReportId == id);

            if (Report == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
