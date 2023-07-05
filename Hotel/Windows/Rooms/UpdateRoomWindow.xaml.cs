using Hotel.Entities.Rooms;
using Hotel.Enums;
using Hotel.Helper;
using Hotel.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Hotel.Windows.Rooms;

public partial class UpdateRoomWindow : Window
{
    private readonly RoomRepository _roomRepository;
    private long _roomId { get; set; }
    public UpdateRoomWindow()
    {
        InitializeComponent();
        this._roomRepository = new RoomRepository();
    }

    public UpdateRoomWindow(long id)
    {
        _roomId = id;
        InitializeComponent();
        this._roomRepository = new RoomRepository();
    }

    public void SedData(Room room)
    {
        tbNumber.Text = room.Number.ToString();
        tbCapacity.Text = room.Capacity.ToString();
        tbPrice.Text = room.Price.ToString();
        cmbtype.Text = room.Type.ToString();
        tbDescription.Text = room.Describtion.ToString();
    }
    private async void Window_Loaded_1(object sender, RoutedEventArgs e)
    {
        var room = await _roomRepository.GetAllRooms(_roomId);
        tbNumber.Text = room.Number.ToString();
        tbCapacity.Text = room.Capacity.ToString();
        tbPrice.Text = room.Price.ToString();
        
        tbDescription.Text = room.Describtion.ToString();

        List<RoomType> list = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
        cmbtype.ItemsSource = list;
        cmbtype.SelectedItem = room.Type;

    }



    private async void btnupdate(object sender, RoutedEventArgs e)
    {

        int count = 0;
        Room room = new Room();
        if (!string.IsNullOrEmpty(tbNumber.Text) && short.Parse(tbNumber.Text) > 0)
        {
            room.Number = short.Parse(tbNumber.Text);
            count++;
        }
        if (!string.IsNullOrEmpty(tbCapacity.Text) && short.Parse(tbCapacity.Text) > 0)
        {
            room.Capacity = short.Parse(tbCapacity.Text);
            count++;
        }
        if (!string.IsNullOrEmpty(tbPrice.Text) && float.Parse(tbPrice.Text) >= 0)
        {
            room.Price = float.Parse(tbPrice.Text);
            count++;
        }
        if (!string.IsNullOrEmpty(tbDescription.Text.ToString()))
        {
            room.Describtion = tbDescription.Text.ToString();
            count++;
        }

        room.UpdateAt = TimeHelper.GetDateTime();

        room.Type = (RoomType)cmbtype.SelectedItem;
        room.Status = RoomStatus.Empty;
        if (count == 4)
        {
            var result = await _roomRepository.UpdateAsync(_roomId, room);
            if (result > 0)
            {
                MessageBox.Show(" Saqlandi");
                this.Close();
            }
            else MessageBox.Show("error");
        }
        else MessageBox.Show("Iltimos malumotlarni to'liq kiriting va to'g'ri!");

    }




}
