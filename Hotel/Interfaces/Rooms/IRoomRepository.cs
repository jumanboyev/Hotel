
using Hotel.Entities.Rooms;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Rooms;

public interface IRoomRepository:IRepository<Room,Room>
{
    public Task<int> CountAsync();

}
