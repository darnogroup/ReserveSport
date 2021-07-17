using Application.Interface;
using Application.Other;
using Application.ViewModel.Home;
using Application.ViewModel.Order;
using Domin.Entity;
using Domin.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReserveInterface _reserveInterface;
        private readonly IReserveSportRepository _reserveSportRepository;
        private readonly ISportInterface _sportInterface;
        public OrderService(IOrderRepository orderRepository,IReserveInterface reserveInterface
            ,IReserveSportRepository reserveSportRepository,ISportInterface sportInterface)
        {
            _orderRepository = orderRepository;
            _reserveInterface = reserveInterface;
            _reserveSportRepository = reserveSportRepository;
            _sportInterface = sportInterface;
        }
        public async Task<bool> IsExistDetail(int reserveId, int sportId)
        {
            return await _orderRepository.IsExistDetail(reserveId, sportId);
        }
        public async Task<bool> IsExistDetail(string date, string collectionId, string sportId)
        {
            DateTime time = Convert.ToDateTime(date);
            return await _orderRepository.IsExistDetail(time, int.Parse(collectionId),int.Parse(sportId));
        }
        public void AddToCart(int itemId,int sportId, int userId)
        {
            var item = _reserveSportRepository.GetReserveSportByIds(itemId,sportId).Result;
            item.IsReserved = true;
            _reserveSportRepository.UpdateReserveSport(item);
            var order = _orderRepository.GetUserId(userId).Result;
            OrderDetailModel orderDetail = new OrderDetailModel();
            orderDetail.ReserveId = item.ReserveId;
            orderDetail.CollectionId = item.Reserve.CollectionId;
            orderDetail.SportId = item.SportId;
            orderDetail.Price = Convert.ToInt32(item.Reserve.Price);
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
        public void AddToCart(string date, string collectionId, string sportId, int userId)
        {
            int sport = int.Parse(sportId);
            int collection = int.Parse(collectionId);
            date = date.ToMiladiDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            DateTime time = DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", CultureInfo.InvariantCulture);
            var item = _reserveSportRepository.GetReserveSportByIds(time, collection, sport).Result;
            item.IsReserved = true;
            _reserveSportRepository.UpdateReserveSport(item);
            var order = _orderRepository.GetUserId(userId).Result;
            OrderDetailModel orderDetail = new OrderDetailModel();
            orderDetail.ReserveId = item.ReserveId;
            orderDetail.CollectionId = item.Reserve.CollectionId;
            orderDetail.SportId = item.SportId;
            orderDetail.Price = Convert.ToInt32(item.Reserve.Price);
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
                    var sport = _sportInterface.GetSportById(item.SportId).Result;
                    orderItems.Add(new OrderItemViewModel()
                    {
                        Start = item.ReserveModel.StartTime,
                        End = item.ReserveModel.EndTime,
                        ReserveId = item.ReserveId,
                        TimeDay = item.ReserveModel.DayTime.ToShamsi(),
                        Price = item.Price,
                        Id = item.DetailId,
                        ReserveName = item.ReserveModel.Collection.CollectionName,
                        SportId = item.SportId,
                        SportName = sport.SportName
                    });
                }

            }
            return Tuple.Create(orderItems, orderView);
        }
        public void RemoveItemCart(int id,int sportId)
        {
            var model = _orderRepository.GetDetailById(id).Result;
            var item = _reserveSportRepository.GetReserveSportByIds(model.ReserveId,sportId).Result;
            item.IsReserved = false;
            _reserveSportRepository.UpdateReserveSport(item);
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
            var reserveSports = _reserveSportRepository.GetReserveSportsByOrderId(orderId).Result;
            foreach (var model in reserveSports)
            {
                model.IsFinished = true;
                _reserveSportRepository.UpdateReserveSport(model);
            }
        }
    }
}