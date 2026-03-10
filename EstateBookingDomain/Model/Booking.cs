using System;
using System.Collections.Generic;

namespace EstateBookingDomain.Model;

public partial class Booking : Entity
{
    public int UserId { get; set; }

    public int EstateId { get; set; }

    public DateOnly CheckIn { get; set; }

    public DateOnly CheckOut { get; set; }

    public int GuestsCount { get; set; }

    public int StatusId { get; set; }

    public string? GuestComment { get; set; }

    public decimal FixedPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Estate Estate { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
