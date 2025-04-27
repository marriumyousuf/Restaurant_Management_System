using System;
using System.Collections.Generic;

namespace RMS.Models;

public partial class Item
{
    public int Itemid { get; set; }

    public string? Itemname { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
