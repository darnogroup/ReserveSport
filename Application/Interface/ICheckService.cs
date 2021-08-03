using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.CheckOut;

namespace Application.Interface
{
    public interface ICheckService
    {
        Tuple<List<CollectionCheckViewModel>, int, int> GetCheckCollection(int id,string search = "", int page = 1);
        Tuple<List<CheckOutViewModel>, int, int> GetChecks( string search = "", int page = 1);
        Task<int> SubmitCheck(int id);
        void Close(int id);
    }
}
