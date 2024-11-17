using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiServiceCenter.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public void OnGet()
        //{

        //}
       
        public List<Service> FilteredServices { get; private set; } = new List<Service>();
        public IActionResult OnGet(string? keyword)
        {
            var services = GetServices();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                // Tìm kiếm dịch vụ khớp với từ khóa
                var matchedService = services.FirstOrDefault(s =>
                    s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||  // so sách và không phân biệt hoa và thường theo tên dịch vụ
                    s.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));// tương tự trên nhương sẽ so sách theo mô tả dịch vụ

                // Nếu tìm thấy, chuyển hướng đến trang của dịch vụ
                if (matchedService != null)
                {
                    return Redirect(matchedService.Url);
                }
            }

            // Nếu không tìm thấy hoặc không có từ khóa, trả về danh sách đầy đủ
            ViewData["FilteredServices"] = services;

            return Page();
        }

        private List<Service> GetServices()
        {
            return new List<Service>
        {
            new Service { Name = "Tư vấn trực tuyến", Description = "Dịch vụ trực tuyến với bác sĩ", Url = "/dich-vu/tu-van-truc-tuyen" },
            new Service { Name = "Điều trị bệnh cho cá", Description = "Khám bệnh, chuẩn đoán cho cá", Url = "/dich-vu/dieu-tri-benh-cho-ca" },
            new Service { Name = "Đánh giá tư vấn hồ cá", Description = "Chăm sóc hồ cá", Url = "/dich-vu/danh-gia-tu-van-ho-ca" }
        };
        }
        public class Service

        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
        }
    }
}
