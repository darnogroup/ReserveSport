using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface IStateInterface
    {
        Task<IEnumerable<StateModel>> GetStates();
        Task<StateModel> GetStateById(int id);
        Task<IEnumerable<StateModel>> GetTrashStates();
        Task<StateModel> GetDeletedStateById(int id);
        void Create(StateModel model);
        void Update(StateModel model);
        void Delete(StateModel model);
    }
}
