using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Report
{
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    [DisplayName("Mã báo cáo")]
    public int ReportId { get; set; }
    [DisplayName("Ngày làm")]
    public DateTime ReportDate { get; set; }
    [DisplayName("Tổng khách hàng")]
    public int? TotalCustomers { get; set; }
    [DisplayName("Tổng dịch vụ")]
    public int? TotalServices { get; set; }
    [DisplayName("Điểm đánh giá")]
    public decimal? AverageRating { get; set; }
    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }
}
