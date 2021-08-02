using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.State;

namespace Application.Interface
{
    public interface IStateService
    {
        Tuple<List<StateViewModel>,int,int> GetStateList(string search="",int page=1);
        Tuple<List<StateViewModel>, int, int> GetStateTrashList(string search = "", int page = 1);
        Task<EditStateViewModel> GetStateById(int id);
  
        void Create(CreateStateViewModel model);
        void Update(EditStateViewModel model);
        void Delete(int id);
        void Back(int id);
        bool Remove(int id);
    }
}
