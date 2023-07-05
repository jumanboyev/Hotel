using Hotel.Entities.Clients;
using Hotel.Interfaces;
using Hotel.Interfaces.Clients;
using Hotel.ViewModels.Clients;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Repositories.Clients;



public class ClientRepository : BaseRepasitory, IClientRepository
{
    public async Task<int> CreateAsync(Client Obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.client(first_name, last_name, phone_number, ismale, birthdate, address, pasport_seria_raqam, describtion, create_at, update_at, room_id, end_date, start_date,total_payment,is_booking)" +
                "VALUES (@first_name, @last_name, @phone_number, @ismale, @birthdate, @address, @pasport_seria_raqam, @describtion, @create_at, @update_at, @room_id, @end_date, @start_date , @total_payment,@is_booking)";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("first_name", Obj.FirstName);
                command.Parameters.AddWithValue("last_name", Obj.LastName);
                command.Parameters.AddWithValue("phone_number", Obj.PhoneNumber);
                command.Parameters.AddWithValue("ismale", Obj.isMale);
                command.Parameters.AddWithValue("birthdate", Obj.BirthDate);
                command.Parameters.AddWithValue("address", Obj.Address);
                command.Parameters.AddWithValue("pasport_seria_raqam", Obj.PasportSeriaNumber);
                command.Parameters.AddWithValue("describtion", Obj.Describtion);
                command.Parameters.AddWithValue("create_at", Obj.CreateAt);
                command.Parameters.AddWithValue("update_at", Obj.UpdateAt);
                command.Parameters.AddWithValue("room_id", Obj.RoomID);
                command.Parameters.AddWithValue("end_date", Obj.EndDate);
                command.Parameters.AddWithValue("start_date", Obj.StartDate);
                command.Parameters.AddWithValue("total_payment", Obj.TotalPrice);
                command.Parameters.AddWithValue("is_booking", true);

                var dbresult = await command.ExecuteNonQueryAsync();
                return dbresult;
            }
        }
        catch
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"update client set is_booking = false where id={Id};";

            await using (var command = new Npgsql.NpgsqlCommand(query, _connection))
            {
                var res= await command.ExecuteNonQueryAsync();
                return res;
            }
        }
        catch (Exception)
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ClientViewModel>> GetAllClientViewModel()
    {
        try
        {
            List<ClientViewModel> list = new List<ClientViewModel>();
            await _connection.OpenAsync();
            string query = "Select * from bookin_view where is_booking = true";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ClientViewModel clientViewModel = new ClientViewModel();
                        clientViewModel.RoomNum = reader.GetInt16(0);
                        clientViewModel.RoomStatus = reader.GetString(1);
                        clientViewModel.RoomCapacity = reader.GetInt16(2);
                        clientViewModel.RoomType = reader.GetString(3);
                        clientViewModel.Id = reader.GetInt64(4);
                        clientViewModel.Fio = reader.GetString(5);
                        clientViewModel.ClientId = reader.GetInt64(6);
                        clientViewModel.TotalPrice = reader.GetFloat(7);
                        clientViewModel.IsBooking = reader.GetBoolean(8);
                        clientViewModel.PhoneNum = reader.GetString(9);
                        list.Add(clientViewModel);
                    }
                }
            }
            return list;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return new List<ClientViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }

    public Task<Client> GetAscyn(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long Id, Client EditedObj)
    {
        throw new NotImplementedException();
    }

    Task<IList<ClientViewModel>> IRepository<Client, ClientViewModel>.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<ClientViewModel> IRepository<Client, ClientViewModel>.GetAscyn(long id)
    {
        throw new NotImplementedException();
    }
}
