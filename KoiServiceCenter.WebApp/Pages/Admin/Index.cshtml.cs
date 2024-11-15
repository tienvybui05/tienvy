using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Admin
{
    [Authorize]// Ủy quyền
               // từ chối danh tính ẩn danh
    public class Index : PageModel
    {
        private readonly IVetScheduleService _service;
        private readonly IServiceHistoryService _serviceServiceHistory;
        private readonly IUserAccountService _userAccountService;
        private readonly IReportService _reportService;
        private readonly IServiceService _serviceService;
        private readonly ICostService _costService;
        private readonly ICustomerService _customerService;
        private readonly IFeedbackService _feedbackService;
        

        public Index(IVetScheduleService service, IServiceHistoryService serviceServiceHistory, IUserAccountService userAccountService, IReportService reportService, IServiceService serviceService, ICostService costService, ICustomerService customerService, IFeedbackService feedbackService)
        {
            _service = service;
            _serviceServiceHistory = serviceServiceHistory;
            _userAccountService = userAccountService;
            _reportService = reportService;
            _costService = costService;
            _serviceService = serviceService;
            _costService = costService;
            _customerService = customerService;
            _feedbackService = feedbackService;
        }
        public int SoLichLam { get; set; }
        public int SoDichVuDat { get; set; }
        public int SoTaiKhoan { get; set; }
        public int SoBaoCao { get; set; }
        public int SoDichVu { get; set; }
        public int SoKhachHang { get; set; }
        public int SoBangGia { get; set; }

        public UserAccount UserAccount { get; set; }    
        public async Task OnGetAsync()
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userIdInt = int.Parse(customerId);
            UserAccount = await _userAccountService.GetUserByIdAsync(userIdInt);
            SoLichLam = await _service.CountSchedule();
            SoDichVuDat = await _serviceServiceHistory.CountServiceHistory();
            SoTaiKhoan = await _userAccountService.CountUserAccount();
            SoBaoCao = await _reportService.CountReport();
            SoDichVu = await _serviceService.CountService();
            SoKhachHang = await _customerService.CountCustomersAsync();
            SoBangGia = await _costService.CountCostAsync();
        }
    }
}
