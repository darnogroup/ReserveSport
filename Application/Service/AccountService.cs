using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Account;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;

namespace Application.Service
{
    public class AccountService:IAccountService
    {
        private readonly IUserInterface _user;

        public AccountService(IUserInterface user)
        {
            _user = user;
        }
        public void Register(RegisterViewModel model)
        {
            UserModel user = new UserModel();
            user.PhoneNumber = model.PhoneNumber;
            user.IsActive = true;
            user.NationalCode = model.NationalCode;
            user.RegisterDate = DateTime.Now;
            user.Role = RoleEnum.کاربر;
            user.UserName = model.UserName;
            user.UserImage = "Avatar.jpg";
            user.ActiveCode = CreateRandom.Number().ToString();
            user.Password = CreateRandom.Number().ToString();
            _user.Create(user);
            UserWalletModel wallet = new UserWalletModel();
            wallet.UserId = user.UserId;
            wallet.WalletInventory = "0";
            _user.CreateWallet(wallet);
           
        }

        public async Task<bool> ExistNumber(string number)
        {
            var result= await _user.CheckPhoneNumber(number);
            return result;
        }

        public void Send(string number)
        {
            var user = _user.GetPassword(number).Result;
            //SendSMS
        }

        public async Task<ClaimViewModel> GetClaim(LoginViewModel model)
        {
            var info =await _user.GetUserLoginInfo(model.Number,model.Password);
            ClaimViewModel claim=new ClaimViewModel();
            claim.PhoneNumber = info.PhoneNumber;
            claim.UserImage = info.UserImage;
            claim.UserName = info.UserName;
            claim.NationalCode = info.NationalCode;
            claim.UserId = info.UserId;
            return claim;
        }

        public async Task<AccessViewModel> GetAccess(int id)
        {
            var user = await _user.GetUserById(id);
            AccessViewModel access=new AccessViewModel();
            access.RoleId = RoleAccess(user.Role);
            return access;
        }

        public int RoleAccess(RoleEnum eEnum)
        {
            int id = 0;
            switch (eEnum)
            {
                case RoleEnum.مدیرسایت:
                    id = 1;
                    break;
                case RoleEnum.مدیرمجموعه:
                    id = 2;
                    break;
                case RoleEnum.مربی:
                    id = 3;
                    break;
                case RoleEnum.کاربر:
                    id = 4;
                    break;
            }

            return id;
        }
    }
}
