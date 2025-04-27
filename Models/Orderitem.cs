using System;
using System.Collections.Generic;

namespace RMS.Models;

public partial class Orderitem
{
    public int Orderid { get; set; }

    public int Itemid { get; set; }

    public int Quantity { get; set; }

    public string? Specialinstructions { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
