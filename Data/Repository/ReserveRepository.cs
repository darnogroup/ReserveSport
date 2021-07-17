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
    public class ReserveRepository:IReserveInterface
    {
        private readonly DataBaseContext _context;

        public ReserveRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReserveModel>> GetReserves(int id)
        {
            return await _context.Reserve.Where(w => w.CollectionId == id).ToListAsync();
        }

        public async Task<ReserveModel> GetReserveById(int id)
        {
            return await _context.Reserve.FindAsync(id);
        }

        public void Create(ReserveModel model)
        {
            _context.Reserve.Add(model);Save();
        }

        public void Update(ReserveModel model)
        {
            _context.Update(model);
            Save();
        }

        public void Remove(ReserveModel model)
        {
            _context.Reserve.Remove(model);Save();
        }

        public async Task<int> GetCollectionId(int userId)
        {
            return await _context.Collection.Where(w => w.UserId == userId).Select(s => s.CollectionId)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Exist(DateTime time, string start, string end,string price= "")
        {
            return await _context.Reserve
                .Where(w=>w.DayTime.Date==time.Date&&w.StartTime==start&&w.EndTime== end&&w.Price==price)
                .AnyAsync();
        }

        public async Task<IEnumerable<ReserveModel>> GetReserveCollection(int id,  DateTime end)
        {
            return await _context.Reserve
                .Where(w => w.CollectionId == id
                          && w.DayTime.Date < end.Date).ToListAsync();
        }

        public async Task<IEnumerable<ReserveModel>> GetTimeItem(DateTime time,int collectionId)
        {
            return await _context.Reserve.Where(w =>w.CollectionId==collectionId&& w.DayTime.Date == time.Date).ToListAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}