using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "CustomerOnly")]
    public class UpdateInformationModel : PageModel
    {
        private readonly ICustomerService _service;

        public UpdateInformationModel(ICustomerService service)
        {
            _service = service;
        }

        [BindProperty]
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
            ViewData["UserId"] = _service.GetCustomerSelect();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.UpdateCustomerAsync(Customer);

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Account/CustomerInformation");
        }

        private bool CustomerExists(int id)
        {
            return _service.GetCustomerByIdAsync(id) != null;
        }
    }
}
