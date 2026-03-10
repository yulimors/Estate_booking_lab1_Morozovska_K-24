using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Saved: Entity
{
    public int UserId { get; set; }

    public int EstateId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Estate Estate { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
