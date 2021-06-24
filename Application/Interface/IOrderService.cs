using Application.ViewModel.Home;
using Application.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOrderService
    {
        Task<bool> IsExistDetail(int detailId);
        void AddToCart(int itemId, int userId);
        Tuple<List<OrderItemViewModel>, OrderViewModel> GetCardItem(int userId);
        void RemoveItemCart(int id);
        Task<OrderViewModel> GetOrderByUserId(int userId);
        Task<int> DetailsCountByOrderId(int orderId);
        Task<OrderViewModel> GetOrderById(int orderId);
        void UpdateOrder(int orderId);
    }
}