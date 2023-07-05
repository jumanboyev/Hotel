using Hotel.Components.Client;
using Hotel.Interfaces.Clients;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Clients;
using Hotel.Repositories.Rooms;
using Hotel.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Pages
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public IRoomRepository _roomRepository { get; set; }
        public readonly IClientRepository _clientRepository;

        public ClientPage()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
            this._clientRepository = new ClientRepository();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.ShowDialog();
        }

        private async void loaded(object sender, RoutedEventArgs e)
        {

           stcClient.Children.Clear();
            var viewModels = await _clientRepository.GetAllClientViewModel();

            foreach (var view in viewModels)
            {
                ClientViewUserControl clientViewUserControl = new ClientViewUserControl();
                clientViewUserControl.SetData(view);
                stcClient.Children.Add(clientViewUserControl);
            }
        }
    }
}
