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
    public class DetailsModel : PageModel
    {
        private readonly IServiceHistoryService _service;

        public DetailsModel(IServiceHistoryService service)
        {
            _service = service;
        }

        public ServiceHistory ServiceHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            ServiceHistory = await _service.GetServiceHistoryById(ID);

            if (ServiceHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
