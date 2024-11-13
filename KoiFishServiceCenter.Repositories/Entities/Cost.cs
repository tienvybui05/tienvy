using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Cost
{
    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [DisplayName ("Mã chi phí")]

    public int CostId { get; set; }
    [DisplayName("Mã dịch vụ")]

    public int? ServiceId { get; set; }
    [DisplayName("Giá")]

    public decimal Cost1 { get; set; }
    [DisplayName("Phí phụ")]

    public decimal? AdditionalFees { get; set; }

    public virtual Service? Service { get; set; }

}
