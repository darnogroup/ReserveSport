using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ICityInterface
    {
        Task<IEnumerable<CityModel>> GetCities(int id);
        Task<CityModel> GetCityById(int id);
        Task<IEnumerable<CityModel>> GetTrashCity(int id);
        Task<CityModel> GetDeletedCityById(int id);
        void Create(CityModel model);
        void Update(CityModel model);
        void Delete(CityModel model);
    }
}
