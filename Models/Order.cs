using System;
using System.Collections.Generic;

namespace RMS.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Customerid { get; set; }

    public int? Totalprice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
