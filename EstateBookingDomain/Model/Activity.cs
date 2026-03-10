using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Activity: Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<EstateActivity> EstateActivities { get; set; } = new List<EstateActivity>();
}
