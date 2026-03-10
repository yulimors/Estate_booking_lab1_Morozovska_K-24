using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class EstateAmenity: Entity
{
    public int? AmenitiesId { get; set; }

    public int? EstateId { get; set; }

    public virtual Amenity? Amenities { get; set; }

    public virtual Estate? Estate { get; set; }
}
