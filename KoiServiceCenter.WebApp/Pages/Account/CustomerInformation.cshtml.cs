using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "EveryoneOnly")]
    public class CustomerInformationModel : PageModel
    {
        private readonly IUserAccountService _service;
        private readonly ICustomerService _customerService;
        public CustomerInformationModel(IUserAccountService service ,ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
        }

        public UserAccount UserAccount { get; set; }
        public Customer Customer { get; set; }  
        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userIdInt = int.Parse(customerId);
            Customer = await _customerService.GetCustomer(userIdInt);
            if(Customer == null)
            {
                return NotFound();
            }
            return Page();

            
        }
    }
}
