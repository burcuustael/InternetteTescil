using System;
using System.Collections.Generic;

namespace InternetteTescil.Entities.Entities;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Taxno { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Cellno { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
