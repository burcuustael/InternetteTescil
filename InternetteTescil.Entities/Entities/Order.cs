using System;
using System.Collections.Generic;

namespace InternetteTescil.Entities.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string OrderEMail { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime Orderdate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
