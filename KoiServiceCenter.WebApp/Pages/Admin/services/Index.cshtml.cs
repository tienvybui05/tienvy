using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Admin.services
{
    public class IndexModel : PageModel
    {
        private readonly KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext _context;

        public IndexModel(KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Services.ToListAsync();
        }
    }
}
