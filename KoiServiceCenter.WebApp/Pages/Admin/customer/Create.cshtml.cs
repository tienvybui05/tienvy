using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.customer
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _service;

        public CreateModel(ICustomerService service)
        {
            _service=service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CustomerId"] = await _service.GetAllCustomersAsync();
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Customers.Add(Customer);
            //await _context.SaveChangesAsync();
            await _service.AddCustomerAsync(Customer);
            return RedirectToPage("./Index");
        }
    }
}
