using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;

namespace KoiServiceCenter.WebApp.Pages.Services.Tuvantructuyen
{
    public class IndexModel : PageModel
    {
        private readonly KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext _context;

        public IndexModel(KoiFishServiceCenter.Repositories.Entities.KoiVetServicesDbContext context)
        {
            _context = context;
        }

        public IList<ServiceHistory> ServiceHistory { get;set; }

        public async Task OnGetAsync()
        {
            ServiceHistory = await _context.ServiceHistories
                .Include(s => s.Customer)
                .Include(s => s.Service)
                .Include(s => s.Veterinarian).ToListAsync();
        }
    }
}
