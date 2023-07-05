using Hotel.Entities.Clients;
using Hotel.ViewModels.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Hotel.Interfaces.Clients;


public interface IClientRepository : IRepository<Client, ClientViewModel>
{

    public Task<List<ClientViewModel>> GetAllClientViewModel();
}

