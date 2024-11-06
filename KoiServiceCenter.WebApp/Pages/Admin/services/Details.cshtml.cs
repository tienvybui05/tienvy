using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.services
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceService _service;

        public DetailsModel(IServiceService service)
        {
            _service = service;
        }

        public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            Service = await _service.GetServicerById(ID);

            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
