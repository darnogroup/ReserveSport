using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Interface
{
    public interface IWalletRepository
    {
        Task<UserWalletModel> GetWalletByUserId(int userId);
        void UpdateWallet(UserWalletModel model);
        void Save();
    }
}