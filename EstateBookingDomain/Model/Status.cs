using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Status: Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
