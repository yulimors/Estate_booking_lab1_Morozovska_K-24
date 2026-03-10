using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Review: Entity
{
    public int UserId { get; set; }

    public int EstateId { get; set; }

    public string Text { get; set; } = null!;

    public int Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Estate Estate { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
