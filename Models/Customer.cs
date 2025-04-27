using System;
using System.Collections.Generic;

namespace RMS.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string? Customername { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
