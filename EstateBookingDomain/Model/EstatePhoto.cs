using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class EstatePhoto: Entity
{
    public string PhotoUrl { get; set; } = null!;

    public int? EstateId { get; set; }

    public bool? IsMain { get; set; }

    public virtual Estate? Estate { get; set; }
}
