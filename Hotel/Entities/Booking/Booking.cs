
using System;

namespace Hotel.Entities.Booking;

public class Booking
{
    public long RoomId { get; set; }

    public long ClientId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public float TotalPrice { get; set; }

    public string Describtion { get; set; } = string.Empty;


}
