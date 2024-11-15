using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Account.Veterinarian
{
    [Authorize(Policy = "VeterinarianOnly")]
    public class WorkScheduleModel : PageModel
    {
        private readonly IVetScheduleService _service;
        private readonly IUserAccountService _userAccountService;
        public WorkScheduleModel(IVetScheduleService service, IUserAccountService userAccountService)
        {
            _service = service;
            _userAccountService = userAccountService;
        }

        public IList<VetSchedule> VetSchedule { get; set; }

        public async Task OnGetAsync(DateTime dateTime)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            VetSchedule = await _service.GetWordSchedule(id, dateTime);

        }
    }
}
