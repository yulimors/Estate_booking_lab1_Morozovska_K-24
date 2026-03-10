using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Type: Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Estate> Estates { get; set; } = new List<Estate>();
}
