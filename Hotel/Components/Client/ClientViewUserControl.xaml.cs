using Hotel.Interfaces.Clients;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Clients;
using Hotel.Repositories.Rooms;
using Hotel.ViewModels.Clients;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.Components.Client;

/// <summary>
/// Interaction logic for ClientViewUserControl.xaml
/// </summary>
public partial class ClientViewUserControl : UserControl
{
    public readonly IClientRepository _clientRepository;
    public readonly IRoomRepository _roomRepository;
    public long id { get; set; }
    public ClientViewModel CloneClientViewModel { get; set; }
    public ClientViewUserControl()
    {
        InitializeComponent();
        this._clientRepository = new ClientRepository();
        this._roomRepository = new RoomRepository();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }
    public void SetData(ClientViewModel clientViewModel)
    {
        CloneClientViewModel = clientViewModel;
        lbFullName.Content = clientViewModel.Fio;
        lblRoomNumber.Content = clientViewModel.RoomNum;
        lbRoomCapacity.Content = clientViewModel.RoomCapacity;
        lbRoomType.Content = clientViewModel.RoomType;
        lbRoomPrice.Content = clientViewModel.TotalPrice;
        lbStatus.Content = clientViewModel.RoomStatus;
        id = clientViewModel.Id;
    }

    private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        long clientId = CloneClientViewModel.ClientId;
        var res = await _clientRepository.DeleteAsync(clientId);
        long roomId = CloneClientViewModel.Id;
        var r=await _roomRepository.DeleteAsync(roomId);
    }
}
