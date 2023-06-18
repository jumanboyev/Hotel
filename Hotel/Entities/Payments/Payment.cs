
using Hotel.Enums;

namespace Hotel.Entities.Payments;

public class Payment
{
    public long BookingID { get; set; }

    public PaymentStatus Status { get; set; }

    public string Describtion { get; set; }=string.Empty;
}
