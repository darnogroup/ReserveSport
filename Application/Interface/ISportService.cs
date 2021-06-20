using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Sport;

namespace Application.Interface
{
    public interface ISportService
    {
        Tuple<List<SportViewModel>, int, int> GetSports(string search="",int page=1);
        Tuple<List<SportViewModel>, int, int> GetTrashSports(string search = "", int page = 1);
        Task<EditSportViewModel> GetSportById(int id);
        void Add(CreateSportViewModel model);
        void Edit(EditSportViewModel model);
        void Remove(int id);
        void Back(int id);
        void Delete(int id);
    }
}
