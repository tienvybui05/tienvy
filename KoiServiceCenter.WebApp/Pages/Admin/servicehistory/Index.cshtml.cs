using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.servicehistory
{
    public class IndexModel : PageModel
    {
        private readonly IServiceHistoryService _service;

        public IndexModel(IServiceHistoryService service)
        {
            _service = service;
        }

        public IList<ServiceHistory> ServiceHistory { get;set; }

        //public async Task OnGetAsync()
        //{
        //    ServiceHistory = await _context.ServiceHistories
        //        .Include(s => s.Customer)
        //        .Include(s => s.Service)
        //        .Include(s => s.Veterinarian).ToListAsync();
        //}
        public async Task OnGetAsync(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                ServiceHistory = await _service.SearcheAsync(searchString);
            }
            else
            {
                ServiceHistory = await _service.GetServiceHistories();
            }

        }
    }
}
