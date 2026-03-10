using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Amenity : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<EstateAmenity> EstateAmenities { get; set; } = new List<EstateAmenity>();
}
