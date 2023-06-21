using Hotel.Enums;
using MaterialDesignThemes.Wpf;

namespace Hotel.Entities.Rooms;

public sealed class Room
{
    public long Id { get; set; }

    public short Number { get; set; }

    public RoomStatus Status { get; set; }

    public float Price { get; set; }

    public short Capacity { get; set; }

    public RoomType Type { get; set; } 

    public string Describtion { get; set; } = string.Empty;

}
