using Hotel.Entities.Rooms;
using System.IO.Packaging;

namespace Hotel.ViewModels.Clients;

public class ClientViewModel 
{
    public short RoomNum { get; set; }

    public string RoomType { get; set; } = string.Empty;

    public short RoomCapacity { get; set; }

    public string RoomStatus { get; set; }=string.Empty;

    public float TotalPrice  { get; set; }

    public string Fio { get; set; } = string.Empty;

    public long Id { get; set; }

    public long ClientId { get; set; }

    public string PhoneNum { get; set; } = string.Empty;

    public bool IsBooking { get; set; }
}
