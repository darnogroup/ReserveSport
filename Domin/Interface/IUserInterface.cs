using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;
using Domin.Enum;

namespace Domin.Interface
{
    public interface IUserInterface
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserWalletModel> GetWalletUserById(int id);
        Task<IEnumerable<UserModel>> GetTrashUsers();
        Task<UserModel> GetDeletedUserById(int id);
        Task<UserModel> GetPassword(string number);
        void Create(UserModel model);
        void Update(UserModel model);
        void Delete(UserModel model);
        void CreateWallet(UserWalletModel model);
        void UpdateWallet(UserWalletModel model);
        void DeleteWallet(UserWalletModel model);
        Task<bool> CheckPhoneNumber(string number);
        Task<UserModel> GetUserLoginInfo(string number,string password);
        Task<bool> IsExistUserForCollection();
        Task<RoleEnum> GetRole(int id);
    }
}