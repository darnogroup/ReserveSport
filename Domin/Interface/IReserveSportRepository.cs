using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Interface
{
    public interface IReserveSportRepository
    {
        Task<IEnumerable<ReserveSportsModel>> GetAllReserveSports(int reserveId);
        Task<IEnumerable<ReserveSportsModel>> GetAllReserveSports();
        void AddReserveSport(ReserveSportsModel model);
        void RemoveReserveSport(ReserveSportsModel model);
        void UpdateReserveSport(ReserveSportsModel model);
        Task<ReserveSportsModel> GetReserveSportByIds(int reserveId,int sportId);
        Task<ReserveSportsModel> GetReserveSportByIds(DateTime date, int collectionId, int sportId);
        Task<IEnumerable<ReserveSportsModel>> GetReserveSportsByOrderId(int orderId);
        void Save();
    }
}
