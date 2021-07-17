using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ISportInterface
    {
        Task<IEnumerable<SportModel>> GetSports();
        Task<IEnumerable<SportModel>> GetTrashSports();
        Task<SportModel> GetSportById(int id);
        Task<SportModel> GetDeletedSportById(int id);
        Task<IEnumerable<SportModel>> GetSportsByCollectionId(int collectionId);
        void Create(SportModel model);
        void Update(SportModel model);
        void Delete(SportModel model);
    }
}
