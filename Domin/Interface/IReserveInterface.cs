using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
   public interface IReserveInterface
    {
        Task<IEnumerable<ReserveModel>> GetReserves(int id);
        Task<ReserveModel> GetReserveById(int id);
        void Create(ReserveModel model);
        void Update(ReserveModel model);
        void Remove(ReserveModel model);
        Task<int> GetCollectionId(int userId);
        Task<bool> Exist(DateTime time,string start,string end,string price="");
        Task<IEnumerable<ReserveModel>> GetReserveCollection(int id, DateTime end);
        Task<IEnumerable<ReserveModel>> GetTimeItem(DateTime time,int collectionId);
    }
}
