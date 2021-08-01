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
using Application.ViewModel.Sms;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReserveInterface _reserveInterface;
        private readonly IReserveSportRepository _reserveSportRepository;
        private readonly ISportInterface _sportInterface;
        private readonly IWalletRepository _walletRepository;
        private readonly ICollectionInterface _collection;

        private readonly ISmsInterface _sms;

        public OrderService(IOrderRepository orderRepository, IReserveInterface reserveInterface, IReserveSportRepository reserveSportRepository, ISportInterface sportInterface, IWalletRepository walletRepository, ICollectionInterface collection, ISmsInterface sms)
        {
            _orderRepository = orderRepository;
            _reserveInterface = reserveInterface;
            _reserveSportRepository = reserveSportRepository;
            _sportInterface = sportInterface;
            _walletRepository = walletRepository;
            _collection = collection;
            _sms = sms;
        }
        public async Task<bool> IsExistDetail(int reserveId, int sportId)
        {
            return await _orderRepository.IsExistDetail(reserveId, sportId);
        }
        public async Task<bool> IsExistDetail(string date, string collectionId, string sportId)
        {
            date = date.ToMiladiDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            DateTime time = DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", CultureInfo.InvariantCulture);
            return await _orderRepository.IsExistDetail(time, int.Parse(collectionId), int.Parse(sportId));
        }
        public void AddToCart(int itemId, int sportId, int userId)
        {
            var items = _reserveSportRepository.GetReserveSportByIds(itemId).Result;
            foreach (var item in items)
            {
                item.IsReserved = true; _reserveSportRepository.UpdateReserveSport(item);
            }

            var result = _reserveSportRepository.GetItemReserveSportById(itemId, sportId).Result;

            var order = _orderRepository.GetUserId(userId).Result;
            OrderDetailModel orderDetail = new OrderDetailModel();
            orderDetail.ReserveId = result.ReserveId;
            orderDetail.CollectionId = result.Reserve.CollectionId;
            orderDetail.SportId = result.SportId;
            orderDetail.Price = Convert.ToInt32(result.Reserve.Price);
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

            DateTime time = date.ToMiladiDateTime();

            var item = _reserveSportRepository.GetReserveSportByIds(time, collection, sport).Result;
            item.IsReserved = true;
            _reserveSportRepository.UpdateReserveSport(item);
            var order = _orderRepository.GetUserId(userId).Result;
            OrderDetailModel orderDetail = new OrderDetailModel();
            orderDetail.ReserveId = itemReserve.ReserveId;
            orderDetail.CollectionId = itemReserve.Reserve.CollectionId;
            orderDetail.SportId = itemReserve.SportId;
            orderDetail.Price = Convert.ToInt32(itemReserve.Reserve.Price);
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
            var order = _orderRepository.GetNotFinalyOrderByUserId(userId).Result;
            var wallet = _walletRepository.GetWalletByUserId(userId).Result;
            int detailsCount;
            if (order != null)
            {
                detailsCount = _orderRepository.GetDetailsCount(order.OrderId).Result;
            }
            else
            {
                detailsCount = 0;
            }
            OrderViewModel orderView = new OrderViewModel();
            List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
            if (order != null)
            {
                orderView.OrderCode = order.OrderCode;
                orderView.OrderId = order.OrderId;
                orderView.OrderPrice = _orderRepository.OrderPrice(order.OrderId);
                orderView.IsFinally = order.IsFinally;
                orderView.WalletMoney = wallet.WalletInventory;
                orderView.DetailsCount = detailsCount;
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
        public void RemoveItemCart(int id, int sportId)
        {
            var model = _orderRepository.GetDetailById(id).Result;
            var item = _reserveSportRepository.GetItemReserveSportById(model.ReserveId, sportId).Result;
            item.IsReserved = false;
            _reserveSportRepository.UpdateReserveSport(item);
            var result = _reserveSportRepository.GetReserveSportByIds(model.ReserveId).Result;
            foreach (var value in result)
            {
                value.IsReserved = false;
                _reserveSportRepository.UpdateReserveSport(value);
            }
            _orderRepository.RemoveDetail(model);
        }
        public async Task<OrderViewModel> GetOrderByUserId(int userId)
        {
            var order = await _orderRepository.GetNotFinalyOrderByUserId(userId);
            OrderViewModel model = new OrderViewModel();
            model.OrderCode = order.OrderCode;
            model.OrderId = order.OrderId;
            model.OrderPrice = _orderRepository.OrderPrice(order.OrderId);
            model.IsFinally = order.IsFinally;
            model.UserId = order.UserId;
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
            var items = _orderRepository.GetOrdersItem(orderId).Result;
            var send = SenderInfo.GetSenderInfo();
            foreach (var item in items)
            {
                item.Close = true;
                _orderRepository.UpdateDetail(item);
                FinishOrderViewModel finish =new FinishOrderViewModel();
                finish.DayTime = item.ReserveModel.DayTime.ToShamsi();
                finish.StartTime = item.ReserveModel.StartTime;
                finish.EndTime = item.ReserveModel.EndTime;
                finish.Name = item.Order.User.UserName;
                finish.PlaceLocation = item.ReserveModel.Collection.CollectionAddress;
                finish.PlaceName = item.ReserveModel.Collection.CollectionName;
                finish.PriceItem = item.Price.ToString("#,0");
                finish.Receptor = item.Order.User.PhoneNumber;
                var sms = _sms.GetCustomerSms(1).Result;
                SmsSender.FinishOrder(finish, send, sms);
                var admin = _sms.GetAdminSms(1).Result;
                AdminCollectionViewModel collection=new AdminCollectionViewModel();
                collection.StartTime = item.ReserveModel.StartTime;
                collection.DayTime = item.ReserveModel.DayTime.ToShamsi();
                collection.EndTime = item.ReserveModel.EndTime;
                collection.Name = item.Order.User.UserName;
                collection.UserNumber = item.Order.User.PhoneNumber;
                collection.PriceItem = item.Price.ToString("#,0");
                collection.PlaceName = item.ReserveModel.Collection.CollectionName;
                collection.Receptor = item.ReserveModel.Collection.CollectionPhoneNumber;
                SmsSender.AdminFinishOrder(collection, send, admin);
            }
            var reserveSports = _reserveSportRepository.GetReserveSportsByOrderId(orderId).Result;
            foreach (var model in reserveSports)
            {
                model.IsFinished = true;
                model.IsReserved = true;
                _reserveSportRepository.UpdateReserveSport(model);
            }
        }

        public Tuple<List<OrdersViewModel>, int, int> GetFinishedOrders(string search = "", int page = 1)
        {
            var result = _orderRepository.GetAllOrders().Result;
            List<OrdersViewModel> models = new List<OrdersViewModel>();
            var order = result.Where(w => w.OrderCode.Contains(search))
                .OrderByDescending(o => o.OrderId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(order.Count, 10);
            int skip = (page - 1) * 10;
            var orderList = order.Skip(skip).Take(10).ToList();
            foreach (var item in orderList)
            {
                models.Add(new OrdersViewModel()
                {
                    UserName = item.User.UserName,
                    CreateDate = item.CreateDate.ToShamsi(),
                    OrderCode = item.OrderCode,
                    OrderId = item.OrderId,
                    IsFinish = item.IsFinally
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<IEnumerable<ItemOrdersViewModel>> GetItemOrder(int id)
        {
            var list = await _orderRepository.GetOrdersItem(id);
            List<ItemOrdersViewModel> models = new List<ItemOrdersViewModel>();
            foreach (var item in list)
            {
                models.Add(new ItemOrdersViewModel()
                {
                    Collection = item.ReserveModel.Collection.CollectionName,
                    DayTime = item.ReserveModel.DayTime.ToShamsi(),
                    DetailId = item.DetailId,
                    Price = item.Price,
                    Sport = _sportInterface.GetSportById(item.SportId).Result.SportName
                });
            }

            return models;
        }

        public void RemoveOrder(int id)
        {
            var list = _orderRepository.GetOrdersItem(id).Result;
            foreach (var item in list)
            {
                _orderRepository.RemoveDetail(item);
            }

            var model = _orderRepository.GetOrderById(id).Result;
            _orderRepository.RemoveOrder(model);
        }

        public void RemoveOrderItem(int id)
        {
            var model = _orderRepository.GetDetailById(id).Result;
            _orderRepository.RemoveDetail(model);
        }

        public Tuple<List<FinishOrdersViewModel>, int, int> GetFinishOrders(string search, int page = 1)
        {
            var result = _orderRepository.GetOrderDetails().Result;
            List<FinishOrdersViewModel> models = new List<FinishOrdersViewModel>();
            var orders = result.Where(w => w.Order.OrderCode.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(orders.Count, 10);
            int skip = (page - 1) * 10;
            var orderList = orders.Skip(skip).Take(10).ToList();
            foreach (var item in orderList)
            {
                models.Add(new FinishOrdersViewModel()
                {
                    DayTime = item.ReserveModel.DayTime.ToShamsi(),
                    Code = item.ReserveModel.Code,
                    CollectionName = item.ReserveModel.Collection.CollectionName,
                    OrderCode = item.Order.OrderCode,
                    EndTime = item.ReserveModel.EndTime,
                    OrderDate = item.Order.OrderCode,
                    PhoneNumber = item.Order.User.PhoneNumber,
                    Id = item.DetailId,
                    Price = item.Price.ToString("#,0"),
                    StartTime = item.ReserveModel.StartTime,
                    UserName = item.Order.User.UserName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<IEnumerable<FinishOrdersViewModel>> GetExports(int count = 0)
        {
            var result = await _orderRepository.GetOrderDetails();
            var list = result.OrderByDescending(o => o.DetailId).ToList();
            var countList = list.Count();
            List<OrderDetailModel> orderList = new List<OrderDetailModel>();
            List<FinishOrdersViewModel> models = new List<FinishOrdersViewModel>();
            if (count != 0)
            {
                if (count > countList)
                {
                    orderList = list.ToList();
                }
                else if (count < countList)
                {
                    orderList = list.Take(count).ToList();
                }

            }
            else
            {
                orderList = list.ToList();
            }
            var i = 0;
            foreach (var item in orderList)
            {
                models.Add(new FinishOrdersViewModel()
                {
                    DayTime = item.ReserveModel.DayTime.ToShamsi(),
                    Code = item.ReserveModel.Code,
                    CollectionName = item.ReserveModel.Collection.CollectionName,
                    OrderCode = item.Order.OrderCode,
                    EndTime = item.ReserveModel.EndTime,
                    OrderDate = item.Order.OrderCode,
                    PhoneNumber = item.Order.User.PhoneNumber,

                    Price = item.Price.ToString("#,0"),
                    StartTime = item.ReserveModel.StartTime,
                    UserName = item.Order.User.UserName,
                    Id = i + 1,
                }); i += 1;
            }

            return models;
        }

        public async Task<IEnumerable<CustomerOrderViewModel>> GetOrders(int id)
        {
            var result = await _orderRepository.GetByUserId(id);
            List<CustomerOrderViewModel> customer = new List<CustomerOrderViewModel>();
            var list = result.OrderByDescending(o => o.CreateDate).Take(4).ToList();
            foreach (var item in list)
            {
                customer.Add(new CustomerOrderViewModel()
                {
                    OrderCode = item.OrderCode,
                    CreateDate = item.CreateDate.ToShamsi(),
                    IsFinally = item.IsFinally
                });
            }

            return customer;
        }

        public Tuple<List<CustomerOrderViewModel>, int, int> GetUserOrderList(int id, int page = 1)
        {
            var result = _orderRepository.GetByUserId(id).Result;
            List<CustomerOrderViewModel> models = new List<CustomerOrderViewModel>();
            var orders = result.ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(orders.Count, 10);
            int skip = (page - 1) * 10;
            var orderList = orders.Skip(skip).Take(10).ToList();
            foreach (var item in orderList)
            {
                models.Add(new CustomerOrderViewModel()
                {
                    OrderCode = item.OrderCode,
                    CreateDate = item.CreateDate.ToShamsi(),
                    IsFinally = item.IsFinally
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<OrderCollectionViewModel>, int, int> GetOrders(string search, int collectionId, int page = 1)
        {

            var result = _orderRepository.GetCollectionOrdersItem(collectionId).Result;
            List<OrderCollectionViewModel> models = new List<OrderCollectionViewModel>();
            var orders = result.Where(w => w.Order.OrderCode.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(orders.Count, 10);
            int skip = (page - 1) * 10;
            var orderList = orders.Skip(skip).Take(10).ToList();
            foreach (var item in orderList)
            {
                models.Add(new OrderCollectionViewModel()
                {
                    Code = item.Order.OrderCode,
                    DayTime = item.ReserveModel.DayTime.ToShamsi(),
                    EndTime = item.ReserveModel.EndTime,
                    Id = item.DetailId,
                    OrderDate = item.Order.CreateDate.ToShamsi(),
                    OrderCode = item.Order.OrderCode,
                    PhoneNumber = item.Order.User.PhoneNumber,
                    Price = item.Price.ToString("#,0")
                   ,
                    StartTime = item.ReserveModel.StartTime,
                    UserName = item.Order.User.UserName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }
    }

}