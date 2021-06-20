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
    public class StateRepository:IStateInterface
    {
        private readonly DataBaseContext _context;

        public StateRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StateModel>> GetStates()
        {
            return await _context.State.ToListAsync();
        }

        public async Task<StateModel> GetStateById(int id)
        {
            return await _context.State.FindAsync(id);
        }

        public async Task<IEnumerable<StateModel>> GetTrashStates()
        {
            return await _context.State.Where(w => w.IsDelete == true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<StateModel> GetDeletedStateById(int id)
        {
            return await _context.State.Where(w => w.IsDelete == true).IgnoreQueryFilters().SingleOrDefaultAsync(s=>s.StateId==id);
        }

        public void Create(StateModel model)
        {
            _context.State.Add(model);
            Save();
        }

        public void Update(StateModel model)
        {
            _context.Update(model);
            Save();
        }

        public void Delete(StateModel model)
        {
            _context.State.Remove(model);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
