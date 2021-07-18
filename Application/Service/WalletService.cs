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

namespace Application.Service
{
    public class WalletService:IWalletServcie
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IReserveSportRepository _reserveSportRepository;
        public WalletService(IWalletRepository walletRepository,IOrderRepository orderRepository,IReserveSportRepository reserveSportRepository)
        {
            _walletRepository = walletRepository;
            _orderRepository = orderRepository;
            _reserveSportRepository = reserveSportRepository;
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
