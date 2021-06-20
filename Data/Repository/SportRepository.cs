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
    public class SportRepository:ISportInterface
    {
        private readonly DataBaseContext _context;

        public SportRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SportModel>> GetSports()
        {
            return await _context.Sport.ToListAsync();
        }

        public async Task<IEnumerable<SportModel>> GetTrashSports()
        {
            return await _context.Sport.Where(w=>w.IsDelete==true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<SportModel> GetSportById(int id)
        {
            return await _context.Sport.FindAsync(id);
        }

        public async Task<SportModel> GetDeletedSportById(int id)
        {
            return await _context.Sport.Where(w => w.IsDelete == true).IgnoreQueryFilters()
                .SingleOrDefaultAsync(s => s.SportId == id);
        }

        public void Create(SportModel model)
        {
            _context.Sport.Add(model);Save();
        }

        public void Update(SportModel model)
        {
            _context.Update(model);Save();
        }

        public void Delete(SportModel model)
        {
            _context.Sport.Remove(model);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
