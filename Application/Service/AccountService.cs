using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Account;
using Application.ViewModel.Sms;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;

namespace Application.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserInterface _user;
        private readonly ISmsInterface _sms;
        private readonly ISettingInterface _setting;
        private readonly ICollectionInterface _collection;

        public AccountService(IUserInterface user, ISmsInterface sms, ISettingInterface setting, ICollectionInterface collection)
        {
            _user = user;
            _sms = sms;
            _setting = setting;
            _collection = collection;
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

        public void RegisterCollection(RegisterCollectionViewModel model)
        {
            UserModel user = new UserModel();
            user.PhoneNumber = model.PhoneNumber;
            user.IsActive = false;
            user.NationalCode = model.NationalCode;
            user.RegisterDate = DateTime.Now;
            user.Role = RoleEnum.مدیرمجموعه;
            user.UserName = model.UserName;
            user.UserImage = "Avatar.jpg";
            user.ActiveCode = CreateRandom.Number().ToString();
            user.Password = CreateRandom.Number().ToString();
            _user.Create(user);
            UserWalletModel wallet = new UserWalletModel();
            wallet.UserId = user.UserId;
            wallet.WalletInventory = "0";
            _user.CreateWallet(wallet);
            /************************/
            CollectionModel collection = new CollectionModel();
            collection.CollectionName = model.CollectionName;
            collection.CityId = Convert.ToInt32(model.CityId);
            collection.CollectionPhoneNumber = model.CollectionPhoneNumber;
            collection.CollectionAddress = model.CollectionAddress;
            collection.UserId = user.UserId;
            collection.Active = false;
            collection.StateId = Convert.ToInt32(model.StateId);
            collection.Image = "noImage.jpg";
            collection.LicensePath= "noImage.jpg";
            _collection.Create(collection);
            
            FinancialModel financial = new FinancialModel()
            {
                CollectionId = collection.CollectionId,
                FinancialCard = "",
                FinancialNumber = "",
                FinancialPrice = "0",
                FinancialSheba = ""

            };
            _collection.CreateFinancial(financial);
        }

        public async Task<bool> ExistNumber(string number)
        {
            var result = await _user.CheckPhoneNumber(number);
            return result;
        }

        public void Send(string number)
        {
            var user = _user.GetPassword(number).Result;
            if (user != null)
            {
                var change = CreateRandom.Number().ToString();
                var info = SenderInfo.GetSenderInfo();
                var text = _sms.GetGeneralSms(1).Result;
                var message = text.TemporaryText + change;
                SmsSender.SendSms(user.PhoneNumber, message, info);
                user.Password = change;
                _user.Update(user);
            }
            //SendSMS
        }
        //public Sender GetSenderInfo()
        //{
        //    var setting = _setting.GetSetting(1).Result;
        //    Sender sender = new Sender();
        //    sender.Number = setting.SmsNumberSender;
        //    sender.Api = setting.SmsApiCode;
        //    return sender;
        //}
        public async Task<ClaimViewModel> GetClaim(LoginViewModel model)
        {
            var info = await _user.GetUserLoginInfo(model.Number, model.Password);
            ClaimViewModel claim = new ClaimViewModel();
            claim.PhoneNumber = info.PhoneNumber;
            claim.UserImage = info.UserImage;
            claim.UserName = info.UserName;
            claim.NationalCode = info.NationalCode;
            claim.UserId = info.UserId;
            info.Password = CreateRandom.Number().ToString();
            _user.Update(info);

            return claim;


        }

        public async Task<AccessViewModel> GetAccess(int id)
        {
            var user = await _user.GetUserById(id);
            AccessViewModel access = new AccessViewModel();
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
