
using Hotel.Entities.Rooms;
using Hotel.Interfaces.Rooms;
using Hotel.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repositories.Rooms;

public class RoomRepository : IRoomRepository
{
    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(Room Obj)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(long Id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<Room>> GetAllAsync(PaginationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<Room> GetAscyn(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long Id, Room EditedObj)
    {
        throw new System.NotImplementedException();
    }
}
