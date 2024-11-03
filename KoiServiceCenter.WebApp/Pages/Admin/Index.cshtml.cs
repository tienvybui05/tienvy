using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiServiceCenter.WebApp.Pages.Admin
{
    public class Index : PageModel
    {
        private readonly IVetScheduleService _service;
        private readonly IServiceHistoryService _serviceServiceHistory;
        public Index(IVetScheduleService service, IServiceHistoryService serviceServiceHistory)
        {
            _service = service;
            _serviceServiceHistory = serviceServiceHistory;
        }
        public int SoLichLam { get; set; }
        public int SoDichVuDat { get; set; }
        public async Task OnGetAsync()
        {
            SoLichLam = await _service.CountSchedule();
            SoDichVuDat = await _serviceServiceHistory.CountServiceHistory();
        }
    }
}
