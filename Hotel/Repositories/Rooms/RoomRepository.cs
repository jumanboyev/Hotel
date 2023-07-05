
using Hotel.Constans;
using Hotel.Entities.Rooms;
using Hotel.Enums;
using Hotel.Interfaces;
using Hotel.Interfaces.Rooms;
using Hotel.ViewModels.Clients;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repositories.Rooms;

public class RoomRepository : IRoomRepository
{
    private readonly NpgsqlConnection _connection;

    public RoomRepository()
    {
        _connection = new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING);
    }


    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Room obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.room(" +
               "number, status, price, capacity, type, describtion, create_at, update_at)" +
                "VALUES (@number, @status, @price, @capacity, @type, @describtion, @create_at, @update_at);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("number", obj.Number);
                command.Parameters.AddWithValue("status", obj.Status.ToString());
                command.Parameters.AddWithValue("price", obj.Price);
                command.Parameters.AddWithValue("capacity", obj.Capacity);
                command.Parameters.AddWithValue("type", obj.Type.ToString());
                command.Parameters.AddWithValue("describtion", obj.Describtion);
                command.Parameters.AddWithValue("create_at", obj.CreateAt);
                command.Parameters.AddWithValue("update_at", obj.UpdateAt);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
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

    public async Task<int> DeleteRoomAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM public.room where id= {Id}";

            await using(var command = new NpgsqlCommand(query,_connection))
            {
                var dbResult= await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch 
        {
            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }
    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update room set status='Empty' where id={Id}";
            await using (var command = new NpgsqlCommand(query , _connection))
            {
                var i = await command.ExecuteNonQueryAsync();
                return i;
            }
        }
        catch (Exception)
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
    }


    public async Task<IList<Room>> GetAllAsync()
    {
        try
        {
            var list = new List<Room>();
            await _connection.OpenAsync();
            string query = $"select * from room order by id ";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Room room = new Room()
                        {
                            Id = reader.GetInt64(0),
                            Number = reader.GetInt16(1),
                            Price = reader.GetFloat(3),
                            Capacity = reader.GetInt16(4),
                            Describtion = reader.GetString(6),
                            CreateAt = reader.GetDateTime(7),
                            UpdateAt = reader.GetDateTime(8)
                        };
                        //  room.Status = (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2).ToString(), true);
                        // room.Type = (RoomType)Enum.Parse(typeof(RoomType),reader.GetString(5),true);
                        RoomStatus roomStatus;
                        RoomType roomType;
                        Enum.TryParse<RoomStatus>(reader.GetString(2).ToString(), out roomStatus);
                        Enum.TryParse<RoomType>(reader.GetString(5).ToString(), out roomType);
                        room.Status = roomStatus;
                        room.Type = roomType;
                        list.Add(room);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Room>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Room> GetAscyn(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Room> GetRooId(short roomNum)
    {
        try
        {
            Room room=new Room();
            await _connection.OpenAsync();
            string query = $"select * from room where number = {roomNum}";
            await using(var command = new NpgsqlCommand(query, _connection))
            {
                await using(var reader = await command.ExecuteReaderAsync()) 
                {
                    if (await reader.ReadAsync())
                    {
                        room.Id = reader.GetInt64(0);
                        room.Number=reader.GetInt16(1);
                        room.Price = reader.GetFloat(3);
                        room.Capacity=reader.GetInt16(4);
                        room.Describtion=reader.GetString(6);
                        room.CreateAt=reader.GetDateTime(7);
                        room.UpdateAt = reader.GetDateTime(8);
                    }
                    RoomStatus roomStatus;
                    RoomType roomType;
                    Enum.TryParse<RoomStatus>(reader.GetString(2).ToString(), out roomStatus);
                    Enum.TryParse<RoomType>(reader.GetString(5).ToString(), out roomType);
                    room.Status = roomStatus;
                    room.Type = roomType;

                }

                return room;
            }
        }
        catch (Exception)
        {

            return new Room();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<List<short>> GetRooNumber()
    {
        try
        {
            List<short> list = new List<short>();
            await _connection.OpenAsync();
            string query = $"select number from room where status = 'Empty';";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        var res = reader.GetInt16(0);
                          
                        //  room.Status = (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2).ToString(), true);
                        // room.Type = (RoomType)Enum.Parse(typeof(RoomType),reader.GetString(5),true);
                      
                        list.Add((short)res);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<short>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> SetRoomStatus(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"update room set status = 'Booked' where id = {id}";
            await using(var command = new NpgsqlCommand(query, _connection))
            {
                var res = await command.ExecuteNonQueryAsync();
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

    public async Task<int> UpdateAsync(long Id, Room EditedObj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.room " +
                "SET number = @number, status=@status, price=@price, capacity=@capacity, type=@type," +
                $" describtion = @describtion,  update_at = @update_at  where id={Id}";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("number", EditedObj.Number);
                command.Parameters.AddWithValue("status", EditedObj.Status.ToString());
                command.Parameters.AddWithValue("price", EditedObj.Price);
                command.Parameters.AddWithValue("capacity", EditedObj.Capacity);
                command.Parameters.AddWithValue("type", EditedObj.Type.ToString());
                command.Parameters.AddWithValue("describtion", EditedObj.Describtion);
                command.Parameters.AddWithValue("update_at", EditedObj.UpdateAt);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
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

    
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    

    public async Task<Room> GetAllRooms(long id)
    {
        try
        {
            Room room = new Room();

            await _connection.OpenAsync();
            string query = $"select * from room where id = {id}";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {

                            room.Id = reader.GetInt64(0);
                            room.Number = reader.GetInt16(1);
                            room.Price = reader.GetFloat(3);
                            room.Capacity = reader.GetInt16(4);
                            room.Describtion = reader.GetString(6);
                            room.CreateAt = reader.GetDateTime(7);
                            room.UpdateAt = reader.GetDateTime(8);
                        
                        //  room.Status = (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2).ToString(), true);
                        // room.Type = (RoomType)Enum.Parse(typeof(RoomType),reader.GetString(5),true);
                        RoomStatus roomStatus;
                        RoomType roomType;
                        Enum.TryParse<RoomStatus>(reader.GetString(2).ToString(), out roomStatus);
                        Enum.TryParse<RoomType>(reader.GetString(5).ToString(), out roomType);
                        room.Status = roomStatus;
                        room.Type = roomType;
                        
                    }
                }
                
            }
            return room;

        }
        catch
        {
            return new Room();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
