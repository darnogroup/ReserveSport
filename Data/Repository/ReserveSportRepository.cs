using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ReserveSportRepository:IReserveSportRepository
    {
        private readonly DataBaseContext _context;

        public ReserveSportRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReserveSportsModel>> GetAllReserveSports(int reserveId)
        {
            return await _context.ReserveSportsModels.Where(n => n.ReserveId == reserveId).ToListAsync();
        }
        public async Task<IEnumerable<ReserveSportsModel>> GetAllReserveSports()
        {
            return await _context.ReserveSportsModels.ToListAsync();
        }
        public void AddReserveSport(ReserveSportsModel model)
        {
            _context.Add(model);
            Save();
        }
        public void UpdateReserveSport(ReserveSportsModel model)
        {
            _context.Update(model);
            Save();
        }
        public void RemoveReserveSport(ReserveSportsModel model)
        {
            _context.Remove(model);
            Save();
        }
        public async Task<ReserveSportsModel> GetReserveSportByIds(int reserveId, int sportId)
        {
            return await _context.ReserveSportsModels.Include(n=> n.Reserve).SingleOrDefaultAsync(n => n.ReserveId == reserveId && n.SportId == sportId);
        }
        public async Task<ReserveSportsModel> GetReserveSportByIds(DateTime date,int collecitonId, int sportId)
        {
            return await _context.ReserveSportsModels.Include(n => n.Reserve).SingleOrDefaultAsync(n => n.Reserve.DayTime == date && n.SportId == sportId && n.Reserve.CollectionId == collecitonId);
        }
        public async Task<IEnumerable<ReserveSportsModel>> GetReserveSportsByOrderId(int orderId)
        {
            return await _context.OrderDetailModels.Include(n=> n.Order).Include(n => n.ReserveModel).ThenInclude(n => n.ReserveSports)
                .Where(n => n.OrderId == orderId && n.Order.IsFinally).SelectMany(n => n.ReserveModel.ReserveSports).ToListAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}