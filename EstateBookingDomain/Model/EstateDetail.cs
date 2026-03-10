using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class EstateDetail
{
    public int EstateId { get; set; }

    public int? RoomsCount { get; set; }

    public int? BedsCount { get; set; }

    public int? GuestsCount { get; set; }

    public int? BathroomsCount { get; set; }

    public int? Floor { get; set; }

    public virtual Estate Estate { get; set; } = null!;
}
