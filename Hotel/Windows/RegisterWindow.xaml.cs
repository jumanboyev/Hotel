using Hotel.Constans;
using Hotel.Edentity;
using Hotel.Security;
using Npgsql;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var user = new Users();
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.email = tbEmail.Text;

            string password = tbPassword.Password.ToString();
            var hasherResult=PasswordHasher.Hash(password);

            user.PasswordHash = hasherResult.PasswordHash;
            user.Salt= hasherResult.Salt;

            try
            {
                var dbResult= await RegisterAsync(user);
                if (dbResult) MessageBox.Show("Saqlandi");
                else MessageBox.Show("Saqlanmadi");
            }
            catch 
            {
                MessageBox.Show("Xatoli");
            }
        }

        public async Task<bool> RegisterAsync(Users user)
        {
            int result = 0;
            await using (var connection = new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO public.users(first_name, last_name, email, password_hash, salt)" +
                    "VALUES (@first_name, @last_name, @email, @password_hash, @salt);";

                await using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("first_name",user.FirstName);
                    command.Parameters.AddWithValue("last_name", user.LastName);
                    command.Parameters.AddWithValue("email", user.email);
                    command.Parameters.AddWithValue("password_hash", user.PasswordHash);
                    command.Parameters.AddWithValue("salt", user.Salt);

                    result=await command.ExecuteNonQueryAsync();
                }

                await connection.CloseAsync();
            }
            return result > 0;
        }
    }
}
