using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Interfaces
{
    public interface IRepository<TModel,TViewModel>
    {
        public Task<int> CreateAsync(TModel Obj);
        
        public Task<int> UpdateAsync(long Id, TModel EditedObj);

        public Task<int> DeleteAsync(long Id);

        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);

        public Task<TViewModel> GetAscyn(long id);
    }
}
