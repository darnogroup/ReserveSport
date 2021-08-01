using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Interface
{
    public interface IOrderRepository
    {
        #region Orders

        Task<IEnumerable<OrderDetailModel>> GetOrdersItem(int id);
        Task<int> GetUserId(int userId);
        void CreateOrder(OrderModel order);
        Task<OrderModel> GetOrderByUserId(int userId);
        Task<OrderModel> GetOrderById(int orderId);
        void UpdateOrder(OrderModel order);
        Task<IEnumerable<OrderModel>> GetAllOrders();
        void RemoveOrder(OrderModel order);
        Task<bool> IsExistOrderByUserId(int userId);
        #endregion


        #region Details

        Task<IEnumerable<OrderDetailModel>> GetCollectionOrdersItem(int id);
        Task<IEnumerable<OrderModel>> GetByUserId(int id);
        Task<IEnumerable<OrderDetailModel>> GetOrderDetails();
        Task<bool> IsExistDetail(int reserveId, int sportId); 
        Task<bool> IsExistDetail(DateTime date, int collectionId, int sportId); 
        void CreateDetail(OrderDetailModel detail);
        int OrderPrice(int orderId);
        Task<IEnumerable<OrderDetailModel>> GetOrderItems(int orderId);
        Task<OrderDetailModel> GetDetailById(int id);
        Task<OrderModel> GetNotFinalyOrderByUserId(int userId);
        void RemoveDetail(OrderDetailModel detail);
        Task<ReserveModel> GetReserveByInfos(int collectionId,string reserve,string reserveTime);
        Task<int> DetailsCountByOrderId(int orderId);
        Task<int> GetDetailsCount(int orderId);
        void UpdateDetail(OrderDetailModel model);
        #endregion
        void Save();

        
    }
}