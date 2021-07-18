using Application.ViewModel.Order;
using Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IWalletServcie
    {
        Task<UserWalletViewModel> GetUserWalletById(int userId);
        void UpdateWallet(UserWalletViewModel vModel);
        Task<bool> PayByWallet(OrderViewModel order);
    }
}