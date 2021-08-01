using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CityRepository:ICityInterface
    {
        private readonly DataBaseContext _context;

        public CityRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CityModel>> GetCities(int id)
        {
            return await _context.City.Include(i=>i.State).Where(w => w.StateId == id).ToListAsync();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await _context.City.FindAsync(id);
        }

        public async Task<IEnumerable<CityModel>> GetTrashCity(int id)
        {
            return await _context.City.Include(i => i.State).Where(w => w.StateId == id&&w.IsDelete==true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<CityModel> GetDeletedCityById(int id)
        {
            return await _context.City.IgnoreQueryFilters().SingleOrDefaultAsync(s => s.CityId == id);
        }

        public void Create(CityModel model)
        {
            _context.City.Add(model);
            Save();
        }

        public void Update(CityModel model)
        {
            _context.Update(model);
            Save();
        }

        public void Delete(CityModel model)
        {
            _context.City.Remove(model);Save();
        }
        public async Task<bool> IsExistCityByStateId(int stateId)
        {
            return await _context.City.AnyAsync(n=> n.StateId == stateId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
