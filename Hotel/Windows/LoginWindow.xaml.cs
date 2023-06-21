using Hotel.Constans;
using Hotel.Security;
using Npgsql;
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
using System.Windows.Shapes;

namespace Hotel.Windows
{

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(tbPassword.Visibility == Visibility.Visible)
            {
                tb2Password.Visibility = Visibility.Visible;
                tb2Password.Text = tbPassword.Password;
                tbPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                tbPassword.Visibility = Visibility.Visible;
                tbPassword.Password = tb2Password.Text;
                tb2Password.Visibility = Visibility.Hidden;
            }
        }

        private async void BorderLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string password = tbPassword.Password;
            string email = tbEmail.Text;

            var checking=await CheckAsync(email, password);
            try
            {
                if (checking == true) MessageBox.Show("Sucsesfull");
                else MessageBox.Show("Not found");
            }
            catch 
            {
                MessageBox.Show("Something wrong");
              
            }
        }
        public async Task<bool> CheckAsync(string email, string password)
        {
            int a = 0;
            await using (var connection = new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();

                string query = "Select * from Users where email=@email;";

                await using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("email", email);

                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string reader_email = reader.GetString(3);
                            string reader_password = reader.GetString(4);
                            string reader_salt = reader.GetString(5);

                            var checked_reader = PasswordHasher.Verify(password, reader_password, reader_salt);
                            if (checked_reader) a++;
                        }
                    }
                }

                await connection.CloseAsync();
            }
            if (a == 1) return true;
            else return false;
        }


    }
}
