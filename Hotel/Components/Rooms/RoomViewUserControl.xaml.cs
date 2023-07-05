using Hotel.Entities.Rooms;
using Hotel.Pages;
using Hotel.Repositories.Rooms;
using Hotel.ViewModels.Clients;
using Hotel.Windows;
using Hotel.Windows.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Hotel.Components.Rooms;

/// <summary>
/// Interaction logic for RoomViewUserControl.xaml
/// </summary>
public partial class RoomViewUserControl : UserControl
{
    public readonly RoomRepository _roomRepository;
    public readonly RoomCreateWindow _roomCreateWindow;
    public ClientViewModel ClientViewModel { get; set; }  
    public long id { get; set; }

    public RoomViewUserControl()
    {
        InitializeComponent();
        this._roomRepository = new RoomRepository();
    }

     public void SetData(Room room)
    {
        lbNumber.Content = room.Number.ToString();
        lbType.Content = room.Type.ToString();
        lbPrice.Content = room.Price.ToString();
        lbCapacity.Content = room.Capacity.ToString();
        lbStatus.Content = room.Status.ToString();
        tbDescription.Text=room.Describtion.ToString();
        //tbDescription.Text="asdfasdfasfd";
        id = room.Id;   
        if(lbStatus.Content.ToString() != "Empty")
        {
            this.lbStatus.Foreground = new SolidColorBrush(Colors.Red);
        }
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var res =await _roomRepository.DeleteRoomAsync(id);
        
    }


    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        UpdateRoomWindow updateRoomWindow = new UpdateRoomWindow(id);
        updateRoomWindow.ShowDialog();
    }

    
}
