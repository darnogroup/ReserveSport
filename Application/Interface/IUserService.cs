using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.User;

namespace Application.Interface
{
    public interface IUserService
    {
        Tuple<List<UserViewModel>, int, int> GetUsers(string search = "", int page = 1);
        Tuple<List<UserViewModel>, int, int> GetTrashUsers(string search = "", int page = 1);
        Task<EditUserViewModel> GetUserById(int id);
        Task<bool> CheckNumber(string number);
        Task<UserWalletViewModel> GetUserWallet(int id);
        void AddToWallet(UserWalletViewModel model);
        void Add(AddUSerViewModel model);
        void Edit(EditUserViewModel model);
        void Remove(int id);
        void Back(int id);
        void Delete(int id);
        Task<ProfileViewModel> GetProfile(int id);
        Task<bool> GetCollectionId(int id);
        Task<IEnumerable<UserViewModel>> GetLastUsers();
    }
}
