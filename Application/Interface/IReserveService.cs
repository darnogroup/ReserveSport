using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Reserve;
using Domin.Entity;

namespace Application.Interface
{
    public interface IReserveService
    {
        Tuple<List<ReserveViewModel>, int, int> GetReserve(int id,int page=1);
        Task<EditReserveViewModel> GetReserveById(int id);
        void Create(CreateReserveViewModel model);
        void Edit(EditReserveViewModel model);
        void Delete(int id);
        Task<bool> Exist(string time, string start, string end, string price = "");
        Task<int> CollectionId(int userId);
    }
}
