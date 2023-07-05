using Hotel.Entities.Clients;
using Hotel.Entities.Rooms;
using Hotel.Helper;
using Hotel.Interfaces.Clients;
using Hotel.Interfaces.Rooms;
using Hotel.Repositories.Clients;
using Hotel.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Hotel.Windows
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private readonly IClientRepository _clientRepository;
        private readonly IRoomRepository _roomRepository;
        public ClientWindow()
        {
            InitializeComponent();
            this._roomRepository = new RoomRepository();
            this._clientRepository = new ClientRepository();
        }

        private async void btSave_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            Client client = new Client();
            if (!string.IsNullOrEmpty(tbFirstName.Text))
            {
                client.FirstName = tbFirstName.Text;
                count++;
            }
            if (!string.IsNullOrEmpty(tbLastName.Text))
            {
                client.LastName = tbLastName.Text;
                count++;
            }
            if (!string.IsNullOrEmpty(tbPhone.Text))
            {
                client.PhoneNumber = tbPhone.Text;
                count++;
            }

            short roomNUm = short.Parse(cmbRoomNumber.SelectedItem.ToString());
            var roomObj = await _roomRepository.GetRooId(roomNUm);

            var res = await _roomRepository.SetRoomStatus(roomObj.Id);
            if (!string.IsNullOrEmpty(tbNight.Text) && short.Parse(tbNight.Text)>0)
            {
                client.TotalPrice = int.Parse(tbNight.Text.ToString()) * roomObj.Price;
                count++;
            }
            if (dtpBirthdate.SelectedDate is not null)
            {
                client.BirthDate = DateOnly.FromDateTime(dtpBirthdate.SelectedDate.Value);
                count++;        
            }
            else client.BirthDate = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (dtpStartDate.SelectedDate is not null)
            {
                count++;
                client.StartDate = DateOnly.FromDateTime(dtpStartDate.SelectedDate.Value);
            }
            else client.StartDate = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (dtpEndDate.SelectedDate is not null)
            {
                count++;
                client.EndDate = DateOnly.FromDateTime(dtpEndDate.SelectedDate.Value);
            }
            else client.EndDate = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (rbIsMale.IsChecked!.Value) client.isMale = true;
            else client.isMale = false;

            client.CreateAt = client.UpdateAt = TimeHelper.GetDateTime();
            client.RoomID = roomObj.Id;

            if (count == 7)
            {
                var result = await _clientRepository.CreateAsync(client);
                if (result > 0)
                {
                    MessageBox.Show("yaratildi");
                    this.Close();
                }
            }
            else MessageBox.Show("Iltimos malumotlarni to'liq kiriting!");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var res = await _roomRepository.GetRooNumber();

            List<short> rooms = res;

            foreach (var i in rooms)
            {

                cmbRoomNumber.Items.Add(i.ToString());

            }



        }
    }
}
