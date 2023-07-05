
using Hotel.Entities.Rooms;
using Hotel.ViewModels.Clients;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace Hotel.Interfaces.Rooms;

public interface IRoomRepository:IRepository<Room,Room>
{


    public Task<List<short>> GetRooNumber();

    public Task<Room> GetRooId(short roomNum);

    public Task<int> SetRoomStatus(long id);

    public Task <Room> GetAllRooms(long id);



}
