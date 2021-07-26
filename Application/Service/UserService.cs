using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Enum;
using Application.ViewModel.State;
using Application.ViewModel.User;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserInterface _user;
        private readonly ICollectionInterface _collection;

        public UserService(IUserInterface user, ICollectionInterface collection)
        {
            _user = user;
            _collection = collection;
        }     
        public Tuple<List<UserViewModel>, int, int> GetUsers(string search = "", int page = 1)
        {
            var result = _user.GetUsers().Result;
            List<UserViewModel> models = new List<UserViewModel>();
            var users = result.Where(w => w.UserName.Contains(search) || w.PhoneNumber.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(users.Count, 10);
            int skip = (page - 1) * 10;
            var userList = users.Skip(skip).Take(10).ToList();
            foreach (var item in userList)
            {
                models.Add(new UserViewModel()
                {
                    IsActive = item.IsActive,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDate = item.RegisterDate.ToShamsi(),
                    UserId = item.UserId,
                    UserImage = item.UserImage,
                    UserName = item.UserName,
                    Role = ConvertRole(item.Role)
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<UserViewModel>, int, int> GetTrashUsers(string search = "", int page = 1)
        {
            var result = _user.GetTrashUsers().Result;
            List<UserViewModel> models = new List<UserViewModel>();
            var users = result.Where(w => w.UserName.Contains(search) || w.PhoneNumber.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(users.Count, 10);
            int skip = (page - 1) * 10;
            var userList = users.Skip(skip).Take(10).ToList();
            foreach (var item in userList)
            {
                models.Add(new UserViewModel()
                {
                    IsActive = item.IsActive,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDate = item.RegisterDate.ToShamsi(),
                    UserId = item.UserId,
                    UserImage = item.UserImage,
                    UserName = item.UserName,
                    Role = ConvertRole(item.Role)
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditUserViewModel> GetUserById(int id)
        {
            var user = await _user.GetUserById(id);
            EditUserViewModel edit = new EditUserViewModel();
            edit.PhoneNumber = user.PhoneNumber;
            edit.UserName = user.UserName;
            edit.UserImage = user.UserImage;
            edit.OldPhoneNumber = user.PhoneNumber;
            edit.IsActive = user.IsActive;
            edit.NationalCode = user.NationalCode;
            edit.UserId = user.UserId;
            RoleChange(user.Role, edit);
            return edit;
        }

        public async Task<bool> CheckNumber(string number)
        {
            var result = await _user.CheckPhoneNumber(number);
            return result;
        }

        public async Task<UserWalletViewModel> GetUserWallet(int id)
        {
            var userWallet = await _user.GetWalletUserById(id);
            UserWalletViewModel wallet=new UserWalletViewModel();
            wallet.UserId = userWallet.UserId;
            wallet.Price = Convert.ToInt32(userWallet.WalletInventory);
            return wallet;
        }

        public void AddToWallet(UserWalletViewModel model)
        {
            var result = _user.GetWalletUserById(model.UserId).Result;
            result.WalletInventory = model.Price.ToString();
            _user.UpdateWallet(result);
        }

        public void Add(AddUSerViewModel model)
        {
            UserModel user = new UserModel();
            user.PhoneNumber = model.PhoneNumber;
            user.IsActive = model.IsActive;
            user.NationalCode = model.NationalCode;
            user.RegisterDate = DateTime.Now;
            UserRole(model.Role, user);
            user.UserName = model.UserName;
            if (model.UserImage != null)
            {
                var check = model.UserImage.IsImage();
                if (check)
                {
                    user.UserImage = Image.SaveImage(model.UserImage);
                }

            }
            else
            {
                user.UserImage = "Avatar.jpg";
            }
            user.ActiveCode = CreateRandom.Number().ToString();
            user.Password = CreateRandom.Number().ToString();
            _user.Create(user);
            UserWalletModel wallet = new UserWalletModel();
            wallet.UserId = user.UserId;
            wallet.WalletInventory = "0";
            _user.CreateWallet(wallet);
        }

        public void Edit(EditUserViewModel model)
        {
            var user = _user.GetUserById(model.UserId).Result;
            user.PhoneNumber = model.PhoneNumber;
            user.IsActive = model.IsActive;
            user.NationalCode = model.NationalCode;
            UserRole(model.Role, user);
            user.UserName = model.UserName;
            if (model.UserImageFile != null)
            {
                var check = model.UserImageFile.IsImage();
                if (check)
                {

                    Image.RemoveImage(model.UserImage);

                    user.UserImage = Image.SaveImage(model.UserImageFile);

                }

            }
            _user.Update(user);
        }

        public void Remove(int id)
        {
            var user = _user.GetUserById(id).Result;
            user.IsDelete = true;
            _user.Update(user);
        }

        public void Back(int id)
        {
            var user = _user.GetDeletedUserById(id).Result;
            user.IsDelete = false;
            _user.Update(user);
        }

        public void Delete(int id)
        {
            var user = _user.GetDeletedUserById(id).Result;
            Image.RemoveImage(user.UserImage);
            _user.Delete(user);
        }

        public async Task<ProfileViewModel> GetProfile(int id)
        {
            var user =await _user.GetUserById(id);
            ProfileViewModel profile=new ProfileViewModel();
            profile.UserAvatar = user.UserImage;
            profile.UserCode = user.NationalCode;
            profile.UserName = user.UserName;
            profile.UserNumber = user.PhoneNumber;
            return profile;
        }

        public async Task<bool> GetCollectionId(int id)
        {
            var collection = await _collection.GetCollection(id);
            return collection;
        }

        public string ConvertRole(RoleEnum role)
        {
            var userRole = "";
            switch (role)
            {
                case RoleEnum.کاربر:
                    userRole = "کاربر";
                    break;
                case RoleEnum.مدیرسایت:
                    userRole = "مدیر سایت";
                    break;
                case RoleEnum.مدیرمجموعه:
                    userRole = "مدیر مجموعه";
                    break;
                case RoleEnum.مربی:
                    userRole = "مربی";
                    break;
            }

            return userRole;
        }
        public void UserRole(EnumRole role, UserModel user)
        {
            switch (role)
            {
                case EnumRole.کاربر:
                    user.Role = RoleEnum.کاربر;
                    break;
                case EnumRole.مدیرسایت:
                    user.Role = RoleEnum.مدیرسایت;
                    break;
                case EnumRole.مدیرمجموعه:
                    user.Role = RoleEnum.مدیرمجموعه;
                    break;
                case EnumRole.مربی:
                    user.Role = RoleEnum.مربی;
                    break;
            }
        }
        public void RoleChange(RoleEnum role, EditUserViewModel edit)
        {
            switch (role)
            {
                case RoleEnum.کاربر:
                    edit.Role = EnumRole.کاربر;
                    edit.OldRole = EnumRole.کاربر;
                    break;
                case RoleEnum.مربی:
                    edit.Role = EnumRole.مربی;
                    edit.OldRole = EnumRole.مربی;
                    break;
                case RoleEnum.مدیرسایت:
                    edit.Role = EnumRole.مدیرسایت;
                    edit.OldRole = EnumRole.مدیرسایت;
                    break;
                case RoleEnum.مدیرمجموعه:
                    edit.Role = EnumRole.مدیرمجموعه;
                    edit.OldRole = EnumRole.مدیرمجموعه;
                    break;
            }
        }
    }
}
