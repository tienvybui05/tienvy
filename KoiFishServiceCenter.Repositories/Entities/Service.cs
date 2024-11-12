using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Service
{
    [DisplayName("Mã dịch vụ")]
    public int ServiceId { get; set; }
    [DisplayName("Tên dịch vụ")]

    public string ServiceName { get; set; } = null!;
    [DisplayName("Mô tả dịch vụ")]

    public string Description { get; set; } = null!;
    [DisplayName("Giá dịch vụ")]

    public decimal Price { get; set; }

    public virtual ICollection<Cost> Costs { get; set; } = new List<Cost>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();
}
