using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.City;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class CityService:ICityService
    {
        private readonly ICityInterface _city;

        public CityService(ICityInterface city)
        {
            _city = city;
        }
        public Tuple<List<CityViewModel>, int, int> GetCityList(string search, int stateId, int page = 1)
        {
            var result = _city.GetCities(stateId).Result;
            List<CityViewModel> models = new List<CityViewModel>();
            var cities = result.Where(w => w.CityName.Contains(search))
                .OrderByDescending(o => o.CityId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(cities.Count, 10);
            int skip = (page - 1) * 10;
            var cityList = cities.Skip(skip).Take(10).ToList();
            foreach (var item in cityList)
            {
                models.Add(new CityViewModel()
                {
                   StateName = item.State.StateName,
                   CityName = item.CityName,
                   CityId = item.CityId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<CityViewModel>, int, int> GetCityTrashList(string search, int stateId, int page = 1)
        {
            var result = _city.GetTrashCity(stateId).Result;
            List<CityViewModel> models = new List<CityViewModel>();
            var cities = result.Where(w => w.CityName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(cities.Count, 10);
            int skip = (page - 1) * 10;
            var cityList = cities.Skip(skip).Take(10).ToList();
            foreach (var item in cityList)
            {
                models.Add(new CityViewModel()
                {
                    StateName = item.State.StateName,
                    CityName = item.CityName,
                    CityId = item.CityId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditCityViewModel> GetCityById(int id)
        {
            var result = await _city.GetCityById(id);
            EditCityViewModel city=new EditCityViewModel();
            city.StateId = result.StateId;
            city.CityName = result.CityName;
            city.CityId = result.CityId;
            return city;

        }

       
        public void Create(CreateCityViewModel model)
        {
            CityModel city=new CityModel();
            city.CityName = model.CityName;
            city.StateId = model.StateId;
            _city.Create(city);
        }

        public void Update(EditCityViewModel model)
        {
            var city = _city.GetCityById(model.CityId).Result;
            city.CityName = model.CityName;
            _city.Update(city);
        }

        public void Delete(int id)
        {
            var city = _city.GetCityById(id).Result;
            city.IsDelete = true;
            _city.Update(city);
        }

        public void Back(int id)
        {
            var city = _city.GetDeletedCityById(id).Result;
            city.IsDelete = false;
            _city.Update(city);
        }

        public void Remove(int id)
        {
            var city = _city.GetDeletedCityById(id).Result;
           _city.Delete(city);
        }
        public async Task<bool> IsExistCityByStateId(int stateId)
        {
            return await _city.IsExistCityByStateId(stateId);
        }
    }
}
