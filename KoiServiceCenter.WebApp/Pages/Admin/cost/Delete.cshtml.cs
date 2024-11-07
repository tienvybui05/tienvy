using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.cost
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class DeleteModel : PageModel
    {
        private readonly ICostService _service;

        public DeleteModel(ICostService service)
        {
            _service = service;
        }

        [BindProperty]
        public Cost Cost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            Cost = await _service.GetCostByIdAsync(ID);

            if (Cost == null)
            {
                return NotFound();
            }
            return Page();
        }

            public async Task<IActionResult> OnPostAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            Cost = await _service.GetCostByIdAsync(ID);

            if (Cost != null)
            {
                await _service.DeleteCostByIdAsync(ID);
            }

            return RedirectToPage("./Index");
        }
    }
}
