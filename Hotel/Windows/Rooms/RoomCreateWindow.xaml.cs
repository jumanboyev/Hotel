using Hotel.Entities.Rooms;
using Hotel.Enums;
using Hotel.Helper;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Hotel.Windows
{
    /// <summary>
    /// Interaction logic for RoomCreateWindow.xaml
    /// </summary>
    public partial class RoomCreateWindow : Window
    {
        private readonly IRoomRepository _roomRepository;
        public RoomCreateWindow()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            Room room = new Room();
            if (!string.IsNullOrEmpty(tbNumber.Text) && short.Parse(tbNumber.Text)>0)
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
            if (!string.IsNullOrEmpty(rbDescription.ToString()))
            {
                room.Describtion = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
                count++;
            }

            room.CreateAt = room.UpdateAt = TimeHelper.GetDateTime();

            room.Type = (RoomType)cmbtype.SelectedItem;
            room.Status = RoomStatus.Empty;
            var result = await _roomRepository.CreateAsync(room);
            if (count == 4)
            {
                if (result > 0)
                {
                    MessageBox.Show(" Saqlandi");
                    this.Close();
                }
                else MessageBox.Show("error");
            }
            else MessageBox.Show("Iltimos malumotlarni to'liq kiriting va to'g'ri!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<RoomType> list = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            cmbtype.ItemsSource = list;
            cmbtype.SelectedItem= list[0];
        }
    }
}
