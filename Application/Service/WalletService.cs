using Application.Interface;
using Application.ViewModel.Order;
using Application.ViewModel.User;
using Domin.Entity;
using Domin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.ViewModel.Sms;

namespace Application.Service
{
    public class WalletService:IWalletServcie
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IReserveSportRepository _reserveSportRepository;
        private readonly ISmsInterface _sms;
        private readonly ISettingInterface _setting;
        private readonly ICollectionInterface _collection;

        public WalletService(IWalletRepository walletRepository, IOrderRepository orderRepository, IReserveSportRepository reserveSportRepository, ISmsInterface sms, ISettingInterface setting, ICollectionInterface collection)
        {
            _walletRepository = walletRepository;
            _orderRepository = orderRepository;
            _reserveSportRepository = reserveSportRepository;
            _sms = sms;
            _setting = setting;
            _collection = collection;
        }
        public void UpdateWallet(UserWalletViewModel vModel)
        {
            var wallet = _walletRepository.GetWalletByUserId(vModel.UserId).Result;
            int walletMoney = int.Parse(wallet.WalletInventory);
            walletMoney += vModel.Price;
            wallet.WalletInventory = walletMoney.ToString();
            _walletRepository.UpdateWallet(wallet);
        }
        public async Task<UserWalletViewModel> GetUserWalletById(int userId)
        {
            var wallet = await _walletRepository.GetWalletByUserId(userId);
            UserWalletViewModel model = new UserWalletViewModel();
            model.UserId = userId;
            model.Price = int.Parse(wallet.WalletInventory);
            return model;
        }
        public async Task<bool> PayByWallet(OrderViewModel order)
        {
            
            var wallet = await _walletRepository.GetWalletByUserId(order.UserId);
            var orderModel = await _orderRepository.GetOrderById(order.OrderId);
            int money = int.Parse(wallet.WalletInventory);
            if (money > order.OrderPrice)
            {
                money = money - order.OrderPrice;
                wallet.WalletInventory = money.ToString();
                _walletRepository.UpdateWallet(wallet);
                orderModel.IsFinally = true;
                _orderRepository.UpdateOrder(orderModel);
                var reserveSports = await _reserveSportRepository.GetReserveSportsByOrderId(order.OrderId);
                foreach (var model in reserveSports)
                {
                    model.IsFinished = true;
                    _reserveSportRepository.UpdateReserveSport(model);
                }
                var items = _orderRepository.GetOrdersItem(order.OrderId).Result;
                var setting = _setting.GetSetting(1).Result;
                Sender sender = new Sender();
                sender.Number = setting.SmsNumberSender;
                sender.Api = setting.SmsApiCode;
    
                foreach (var item in items)
                {
                    item.Close = true;
                    _orderRepository.UpdateDetail(item);
                    var collectionId = item.ReserveModel.CollectionId;
                    var financial = _collection.GetFinancial(collectionId).Result;
                    var total = Convert.ToInt32(financial.FinancialPrice);
                    var newTotal = total + item.Price;
                    financial.FinancialPrice = newTotal.ToString();
                    _collection.EditFinancial(financial);
                    FinishOrderViewModel finish = new FinishOrderViewModel();
                    finish.DayTime = item.ReserveModel.DayTime.ToShamsi();
                    finish.StartTime = item.ReserveModel.StartTime;
                    finish.EndTime = item.ReserveModel.EndTime;
                    finish.Name = item.Order.User.UserName;
                    finish.PlaceLocation = item.ReserveModel.Collection.CollectionAddress;
                    finish.PlaceName = item.ReserveModel.Collection.CollectionName;
                    finish.PriceItem = item.Price.ToString("#,0");
                    finish.Receptor = item.Order.User.PhoneNumber;
                    var sms = _sms.GetCustomerSms(1).Result;
                    SmsSender.FinishOrder(finish, sender, sms);
                    var admin = _sms.GetAdminSms(1).Result;
                    AdminCollectionViewModel collection = new AdminCollectionViewModel();
                    collection.StartTime = item.ReserveModel.StartTime;
                    collection.DayTime = item.ReserveModel.DayTime.ToShamsi();
                    collection.EndTime = item.ReserveModel.EndTime;
                    collection.Name = item.Order.User.UserName;
                    collection.UserNumber = item.Order.User.PhoneNumber;
                    collection.PriceItem = item.Price.ToString("#,0");
                    collection.PlaceName = item.ReserveModel.Collection.CollectionName;
                    collection.Receptor = item.ReserveModel.Collection.CollectionPhoneNumber;
                    SmsSender.AdminFinishOrder(collection, sender, admin);
                }
                var reserves = _reserveSportRepository.GetReserveSportsByOrderId(order.OrderId).Result;
                foreach (var model in reserves)
                {
                    model.IsFinished = true;
                    model.IsReserved = true;
                    _reserveSportRepository.UpdateReserveSport(model);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
