using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Role: Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
