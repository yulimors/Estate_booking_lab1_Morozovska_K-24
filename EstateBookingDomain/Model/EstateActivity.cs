using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class EstateActivity: Entity
{
    public int? ActivityId { get; set; }

    public int? EstateId { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual Estate? Estate { get; set; }
}
