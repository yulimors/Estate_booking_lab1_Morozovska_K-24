using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Estate: Entity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int LocationId { get; set; }

    public decimal PricePerNight { get; set; }

    public int AdminId { get; set; }

    public int TypeId { get; set; }

    public string Address { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Admin { get; set; } = null!;

    public virtual Booking? Booking { get; set; }

    public virtual ICollection<EstateActivity> EstateActivities { get; set; } = new List<EstateActivity>();

    public virtual ICollection<EstateAmenity> EstateAmenities { get; set; } = new List<EstateAmenity>();

    public virtual EstateDetail? EstateDetail { get; set; }

    public virtual ICollection<EstatePhoto> EstatePhotos { get; set; } = new List<EstatePhoto>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Saved> Saveds { get; set; } = new List<Saved>();

    public virtual Type Type { get; set; } = null!;
}
