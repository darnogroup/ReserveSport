using Application.Interface;
using Application.Other;
using Application.ViewModel.Home;
using Application.ViewModel.Order;
using Domin.Entity;
using Domin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReserveInterface _reserveInterface;
        public OrderService(IOrderRepository orderRepository,IReserveInterface reserveInterface)
        {
            _orderRepository = orderRepository;
            _reserveInterface = reserveInterface;
        }
        public async Task<bool> IsExistDetail(int detailId)
        {
            return await _orderRepository.IsExistDetail(detailId);
        }
        public void AddToCart(int itemId, int userId)
        {
            var item = _reserveInterface.GetReserveById(itemId).Result;
            item.Reserved = true;
            _reserveInterface.Update(item);
            var order = _orderRepository.GetUserId(userId).Result;
            OrderDetailModel orderDetail = new OrderDetailModel();
            orderDetail.ReserveId = item.ReserveId;
            orderDetail.CollectionId = item.CollectionId;
            orderDetail.Price = Convert.ToInt32(item.Price);
            if (order != 0)
            {
                orderDetail.OrderId = order;
            }
            else
            {
                OrderModel oreModel = new OrderModel();
                oreModel.UserId = userId;
                oreModel.IsFinally = false;
                oreModel.OrderCode = CreateRandom.Number().ToString();
                oreModel.CreateDate = DateTime.Now;
                _orderRepository.CreateOrder(oreModel);
                orderDetail.OrderId = oreModel.OrderId;
            }
            _orderRepository.CreateDetail(orderDetail);
        }
        public Tuple<List<OrderItemViewModel>, OrderViewModel> GetCardItem(int userId)
        {
            var order = _orderRepository.GetOrderByUserId(userId).Result;
            OrderViewModel orderView = new OrderViewModel();
            List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
            if (order != null)
            {
                orderView.OrderCode = order.OrderCode;
                orderView.OrderId = order.OrderId;
                orderView.OrderPrice = _orderRepository.OrderPrice(order.OrderId);
                orderView.IsFinally = false;
                var list = _orderRepository.GetOrderItems(order.OrderId).Result;
                foreach (var item in list)
                {
                    orderItems.Add(new OrderItemViewModel()
                    {
                        Start = item.ReserveModel.StartTime,
                        End = item.ReserveModel.EndTime,
                        ReserveId = item.ReserveId,
                        TimeDay = item.ReserveModel.DayTime.ToShamsi(),
                        Price = item.Price,
                        Id = item.DetailId,
                        ReserveName = item.ReserveModel.Collection.CollectionName
                    });
                }

            }
            return Tuple.Create(orderItems, orderView);
        }
        public void RemoveItemCart(int id)
        {
            var model = _orderRepository.GetDetailById(id).Result;
            var item = _reserveInterface.GetReserveById(model.ReserveId).Result;
            item.Reserved = false;
            _reserveInterface.Update(item);
            _orderRepository.RemoveDetail(model);
        }
        public async Task<OrderViewModel> GetOrderByUserId(int userId)
        {
            var order = await _orderRepository.GetOrderByUserId(userId);
            OrderViewModel model = new OrderViewModel();
            model.OrderCode = order.OrderCode;
            model.OrderId = order.OrderId;
            model.OrderPrice = _orderRepository.OrderPrice(order.OrderId);
            model.IsFinally = order.IsFinally;
            return model;
        }
        public async Task<int> DetailsCountByOrderId(int orderId)
        {
            return await _orderRepository.DetailsCountByOrderId(orderId);
        }
        public async Task<OrderViewModel> GetOrderById(int orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            OrderViewModel model = new OrderViewModel();
            model.OrderCode = order.OrderCode;
            model.OrderId = order.OrderId;
            model.OrderPrice = _orderRepository.OrderPrice(order.OrderId);
            model.IsFinally = order.IsFinally;
            return model;
        }
        public void UpdateOrder(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId).Result;
            order.IsFinally = true;
            _orderRepository.UpdateOrder(order);
        }
    }
}