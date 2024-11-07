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

namespace KoiServiceCenter.WebApp.Pages.Admin.customer
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class DetailsModel : PageModel
    {
        private readonly ICustomerService _service;

        public DetailsModel(ICustomerService service)
        {
            _service = service;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            Customer = await _service.GetCustomerByIdAsync(Id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
