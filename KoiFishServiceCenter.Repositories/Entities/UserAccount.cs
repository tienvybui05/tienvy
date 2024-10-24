using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

    public virtual ICollection<VetSchedule> VetSchedules { get; set; } = new List<VetSchedule>();
}
