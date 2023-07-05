using Hotel.Components.Rooms;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using Hotel.Utils;
using Hotel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Hotel.Pages
{
    /// <summary>
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        private readonly IRoomRepository _roomRepository;
        public RoomPage()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            RoomCreateWindow roomCreateWindow = new RoomCreateWindow();
            roomCreateWindow.ShowDialog();
        }

        public async Task RefreshAsync()
        {
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            var rooms = await _roomRepository.GetAllAsync();

            foreach (var room in rooms)
            {
                RoomViewUserControl roomViewUserControl = new RoomViewUserControl();
                roomViewUserControl.SetData(room);
                wrpRooms.Children.Add(roomViewUserControl);
            }
        }
        private  async void  Page_Loaded(object sender, RoutedEventArgs e)
        {
           await RefreshAsync();
        }
    }
}
