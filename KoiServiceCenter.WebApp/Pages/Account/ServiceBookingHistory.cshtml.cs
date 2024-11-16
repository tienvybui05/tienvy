using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "CustomerOnly")]
    public class ServiceBookingHistoryModel : PageModel
    {
        private readonly IServiceHistoryService _service;

        public ServiceBookingHistoryModel(IServiceHistoryService service)
        {
            _service = service;
        }

        public IList<ServiceHistory> ServiceHistory { get; set; }

        public async Task OnGetAsync()
        {

            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userIdInt = int.Parse(customerId);


            ServiceHistory = await _service.HistoryServices(userIdInt);
            //ViewData["ServiceHistoryList"] = ServiceHistory;



        }
    }
}
