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
	public class IndexModel : PageModel
    {
        private readonly ICustomerService _service;

        public IndexModel(ICustomerService service)
        {
               _service = service;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Customer = await _service.SearcheAsync(searchString);
            }
            else
            {
                Customer = await _service.GetCustomersAsync();
            }
        }
    }
}
