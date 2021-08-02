using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.City;

namespace Application.Interface
{
    public interface ICityService
    {
        Tuple<List<CityViewModel>, int, int> GetCityList(string search ,int stateId, int page = 1);
        Tuple<List<CityViewModel>, int, int> GetCityTrashList(string search , int stateId, int page = 1);
        Task<EditCityViewModel> GetCityById(int id);
     
        void Create(CreateCityViewModel model);
        void Update(EditCityViewModel model);
        void Delete(int id);
        void Back(int id);
        bool Remove(int id);
        Task<bool> IsExistCityByStateId(int stateId);
    }
}
