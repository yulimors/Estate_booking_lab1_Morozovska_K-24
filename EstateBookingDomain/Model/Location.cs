using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Location: Entity
{
    public string Region { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Estate> Estates { get; set; } = new List<Estate>();
}
