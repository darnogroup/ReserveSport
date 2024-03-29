﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Collection;
using Application.ViewModel.General;
using Application.ViewModel.Request;
using Application.ViewModel.Sms;
using Application.ViewModel.State;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;

namespace Application.Service
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionInterface _collection;
        private readonly ICityInterface _city;
        private readonly IStateInterface _state;
        private readonly IUserInterface _user;
        private readonly ISportInterface _sport;
        private readonly IReserveSportRepository _reserveSport;
        private readonly IReserveInterface _reserve;
        private readonly ISettingInterface _setting;
        private readonly ISmsInterface _sms;

        public CollectionService(ICollectionInterface collection, ICityInterface city, IStateInterface state, IUserInterface user, ISportInterface sport, IReserveSportRepository reserveSport, IReserveInterface reserve, ISettingInterface setting, ISmsInterface sms)
        {
            _collection = collection;
            _city = city;
            _state = state;
            _user = user;
            _sport = sport;
            _reserveSport = reserveSport;
            _reserve = reserve;
            _setting = setting;
            _sms = sms;
        }
        public Tuple<List<CollectionViewModel>, int, int> GetCollections(string search = "", int page = 1)
        {
            var result = _collection.GetCollections().Result;
            List<CollectionViewModel> models = new List<CollectionViewModel>();
            var collection = result.Where(w => w.CollectionName.Contains(search))
                .OrderByDescending(o => o.CollectionId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(collection.Count, 10);
            int skip = (page - 1) * 10;
            var collectionList = collection.Skip(skip).Take(10).ToList();
            foreach (var item in collectionList)
            {
                models.Add(new CollectionViewModel()
                {
                    CollectionName = item.CollectionName,
                    City = item.City.CityName,
                    CollectionId = item.CollectionId,
                    CollectionPhoneNumber = item.CollectionPhoneNumber,
                    State = item.State.StateName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<CollectionViewModel>, int, int> GetTrashCollections(string search = "", int page = 1)
        {
            var result = _collection.GetTrashCollections().Result;
            List<CollectionViewModel> models = new List<CollectionViewModel>();
            var collection = result.Where(w => w.CollectionName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(collection.Count, 10);
            int skip = (page - 1) * 10;
            var collectionList = collection.Skip(skip).Take(10).ToList();
            foreach (var item in collectionList)
            {
                models.Add(new CollectionViewModel()
                {
                    CollectionName = item.CollectionName,
                    City = item.City.CityName,
                    CollectionId = item.CollectionId,
                    CollectionPhoneNumber = item.CollectionPhoneNumber,
                    State = item.State.StateName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public void Create(CreateCollectionViewModel model)
        {
            CollectionModel collection = new CollectionModel();
            collection.CollectionName = model.CollectionName;
            collection.CityId = Convert.ToInt32(model.CityId);
            collection.CollectionPhoneNumber = model.CollectionPhoneNumber;
            collection.CollectionAddress = model.CollectionAddress;
            collection.UserId = Convert.ToInt32(model.UserId);
            collection.Active = model.Active;
            collection.StateId = Convert.ToInt32(model.StateId);
            if (model.LicensePath != null)
            {
                var check = model.LicensePath.IsImage();
                if (check)
                {
                    collection.LicensePath = Image.SaveImage(model.LicensePath);
                }
                else
                {
                    collection.LicensePath = "noImage.jpg";
                }
            }
            else
            {
                collection.LicensePath = "noImage.jpg";
            }
            if (model.Image != null)
            {
                var check = model.Image.IsImage();
                if (check)
                {
                    collection.Image = Image.SaveImage(model.Image);
                }
                else
                {
                    collection.Image = "noImage.jpg";
                }
            }
            else
            {
                collection.Image = "noImage.jpg";
            }
            _collection.Create(collection);
            if (model.Sports.Count != 0)
            {
                foreach (var id in model.Sports)
                {
                    SportCollectionModel sport = new SportCollectionModel();
                    sport.CollectionId = collection.CollectionId;
                    sport.SportId = id;
                    _collection.AddSport(sport);
                }
            }

            var user = _user.GetUserById(Convert.ToInt32(model.UserId)).Result;
            user.Role = RoleEnum.مدیرمجموعه;
            _user.Update(user);
            FinancialModel financial = new FinancialModel()
            {
                CollectionId = collection.CollectionId,
                FinancialCard = "",
                FinancialNumber = "",
                FinancialPrice = "0",
                FinancialSheba = "",
                Debtor = "0"

            };
            _collection.CreateFinancial(financial);
        }

        public async Task<List<ItemStateViewModel>> GetStateItems()
        {
            var state = await _state.GetStates();
            List<ItemStateViewModel> model = new List<ItemStateViewModel>();
            foreach (var item in state)
            {
                model.Add(new ItemStateViewModel()
                {
                    StateName = item.StateName,
                    StateId = item.StateId
                });
            }

            return model;
        }

        public async Task<List<ItemCityViewModel>> GetCityItems(int id)
        {
            var city = await _city.GetCities(id);
            List<ItemCityViewModel> model = new List<ItemCityViewModel>();
            foreach (var item in city)
            {
                model.Add(new ItemCityViewModel()
                {
                    CityName = item.CityName,
                    CityId = item.CityId
                });
            }

            return model;
        }

        public async Task<List<ItemUserViewModel>> GetUserItems()
        {
            var user = await _user.GetUsers();
            var admin = user.Where(w => w.Role == RoleEnum.مدیرمجموعه || w.Role == RoleEnum.مربی || w.Role == RoleEnum.کاربر).ToList();
            List<ItemUserViewModel> model = new List<ItemUserViewModel>();
            foreach (var item in admin)
            {
                model.Add(new ItemUserViewModel()
                {
                    UserName = item.UserName,
                    UserId = item.UserId
                });
            }

            return model;
        }

        public async Task<List<ItemSportViewModel>> GetSportItem()
        {
            var sport = await _sport.GetSports();
            List<ItemSportViewModel> model = new List<ItemSportViewModel>();
            foreach (var item in sport)
            {
                model.Add(new ItemSportViewModel()
                {
                    SportName = item.SportName,
                    SportId = item.SportId
                });
            }

            return model;
        }

        public async Task<AreaCollectionViewModel> GetCollection(int userId)
        {
            var model = await _collection.GetProfile(userId);
            AreaCollectionViewModel collection = new AreaCollectionViewModel();
            collection.CollectionId = model.CollectionId;
            collection.CollectionName = model.CollectionName;
            collection.State = model.State.StateName;
            collection.Number = model.CollectionPhoneNumber;
            collection.City = model.City.CityName;
            collection.UserAvatar = model.User.UserImage;
            collection.UserName = model.User.UserName;
            collection.Address = model.CollectionAddress;
            return collection;
        }

        public async Task<bool> CheckCollection(string name, int state, int city)
        {
            return await _collection.CheckCollection(name, state, city);
        }

        public async Task<EditCollectionViewModel> GetCollectionById(int id)
        {
            var collection = await _collection.GetById(id);
            EditCollectionViewModel model = new EditCollectionViewModel();
            model.StateId = collection.StateId.ToString();
            model.CityId = collection.CityId.ToString();
            model.LicensePath = collection.LicensePath;
            model.UserId = collection.UserId.ToString();
            model.CollectionId = collection.CollectionId;
            model.CollectionAddress = collection.CollectionAddress;
            model.CollectionName = collection.CollectionName;
            model.CollectionPhoneNumber = collection.CollectionPhoneNumber;
            model.UserOld = collection.UserId;
            model.ImagePath = collection.Image;
            model.Active = collection.Active;
            return model;
        }

        public async Task<List<int>> SelectedSport(int id)
        {
            var sports = await _collection.GetByCollectionId(id);
            List<int> selected = new List<int>();
            foreach (var item in sports)
            {
                selected.Add(item.SportId);
            }

            return selected;
        }

        public void Edit(EditCollectionViewModel model)
        {
            var sports = _collection.GetByCollectionId(model.CollectionId).Result;
            if (sports.Count != 0)
            {
                foreach (var item in sports)
                {
                    _collection.RemoveSport(item);
                }

            }
            var collection = _collection.GetById(model.CollectionId).Result;
            collection.StateId = Convert.ToInt32(model.StateId);
            collection.CityId = Convert.ToInt32(model.CityId);
            collection.UserId = Convert.ToInt32(model.UserId);
            collection.CollectionAddress = model.CollectionAddress;
            collection.Active = model.Active;
            collection.CollectionName = model.CollectionName;
            collection.CollectionPhoneNumber = model.CollectionPhoneNumber;
            if (model.License != null)
            {
                var check = model.License.IsImage();
                if (check)
                {
                    Image.RemoveImage(model.LicensePath);
                    collection.LicensePath = Image.SaveImage(model.License);
                }
            }
            if (model.Image != null)
            {
                var check = model.Image.IsImage();
                if (check)
                {
                    Image.RemoveImage(model.ImagePath);
                    collection.LicensePath = Image.SaveImage(model.Image);
                }
            }
            _collection.Update(collection);
            var user = _user.GetUserById(Convert.ToInt32(model.UserId)).Result;
            user.Role = RoleEnum.مدیرمجموعه;
            _user.Update(user);
            if (model.Sports != null)
            {
                var reserveSports = _reserveSport.GetAllReserveSports().Result;
                List<int> reserveIds = new List<int>();
                int reserveId = 0;
                foreach (var sport in reserveSports)
                {
                    if (reserveId != sport.ReserveId)
                    {
                        reserveIds.Add(sport.ReserveId);
                    }
                    reserveId = sport.ReserveId;
                    _reserveSport.RemoveReserveSport(sport);
                }
                foreach (var item in model.Sports)
                {
                    _collection.AddSport(new SportCollectionModel()
                    {
                        CollectionId = model.CollectionId,
                        SportId = item
                    });
                }
                foreach (var id in reserveIds)
                {
                    var sportCollections = _collection.GetSportCollections(model.CollectionId).Result;
                    foreach (var item in sportCollections)
                    {
                        ReserveSportsModel rsModel = new ReserveSportsModel();
                        rsModel.ReserveId = id;
                        rsModel.SportId = item.SportId;
                        rsModel.SportName = item.Sport.SportName;
                        _reserveSport.AddReserveSport(rsModel);
                    }
                }
            }

        }

        public async Task<bool> AdminCollection(int id)
        {
            var result = await _collection.AdminCollection(id);
            return result;
        }

        public void Remove(int id)
        {
            var model = _collection.GetById(id).Result;
            model.IsDelete = true;
            _collection.Update(model);
        }

        public void Back(int id)
        {
            var model = _collection.GetTrashById(id).Result;
            model.IsDelete = false;
            _collection.Update(model);
        }

        public bool Delete(int id)
        {
            var model = _collection.GetTrashById(id).Result;
            try
            {
                _collection.Delete(model);
                Image.RemoveImage(model.Image);
                Image.RemoveImage(model.LicensePath);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void EditFinancial(FinancialViewModel model)
        {
            var result = _collection.GetFinancial(model.CollectionId).Result;
            result.FinancialSheba = model.FinancialSheba;
            result.FinancialCard = model.FinancialCard;
            result.FinancialNumber = model.FinancialNumber;
            result.Debtor = model.Debtor;
            result.FinancialPrice = model.FinancialPrice;
            _collection.EditFinancial(result);
        }

        public async Task<FinancialViewModel> GetFinancial(int id)
        {
            FinancialViewModel financial = new FinancialViewModel();
            var model = await _collection.GetFinancial(id);
            financial.FinancialCard = model.FinancialCard;
            financial.FinancialNumber = model.FinancialNumber;
            financial.FinancialId = model.FinancialId;
            financial.Debtor = model.Debtor;
            financial.FinancialSheba = model.FinancialSheba;
            financial.CollectionId = model.CollectionId;
            var setting = _setting.GetSetting(1).Result;
            var percent = Convert.ToInt32(setting.Salary);
            var price = Convert.ToInt32(model.FinancialPrice);
            var salary = (price * percent) / 100;
            var mainPrice = price - salary;
            financial.FinancialPrice = mainPrice.ToString();
            return financial;
        }

        public async Task<List<ImageViewModel>> GetImages(int id)
        {
            var list = await _collection.GetBanner(id);
            List<ImageViewModel> images = new List<ImageViewModel>();
            foreach (var item in list)
            {
                images.Add(new ImageViewModel()
                {
                    Id = item.Id,
                    ImagePath = item.Image
                });
            }

            return images;
        }

        public void AddImage(AddImageViewModel model)
        {
            BannerModel banner = new BannerModel();
            banner.CollectionId = model.CollectionId;
            var check = model.Image.IsImage();
            if (check)
            {
                banner.Image = Image.SaveImage(model.Image);
            }
            else
            {
                banner.Image = "noImage.jpg";
            }
            _collection.CreateBanner(banner);
        }

        public void RemoveImage(int id)
        {
            var model = _collection.GetBannerById(id).Result;
            _collection.RemoveBanner(model);
        }

        public Tuple<List<RequestViewModel>, int, int> GetRequestList(string search = "", int page = 1)
        {
            var list = _collection.GetRequests().Result;
            List<RequestViewModel> models = new List<RequestViewModel>();
            var request = list.Where(w => w.CollectionName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(request.Count, 10);
            int skip = (page - 1) * 10;
            var requestList = request.Skip(skip).Take(10).ToList();
            foreach (var item in requestList)
            {
                models.Add(new RequestViewModel()
                {

                    CollectionName = item.CollectionName,
                    City = item.City.CityName,
                    CollectionId = item.CollectionId,
                    CollectionPhoneNumber = item.CollectionPhoneNumber,
                    UserCode = item.User.NationalCode,
                    State = item.State.StateName,
                    UserName = item.User.UserName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<InfoRequestViewModel> GetInfoRequest(int id)
        {
            var model = await _collection.GetById(id);
            InfoRequestViewModel info = new InfoRequestViewModel();
            info.City = model.City.CityName;
            info.State = model.State.StateName;
            info.UserName = model.User.UserName;
            info.CollectionPhoneNumber = model.CollectionPhoneNumber;
            info.CollectionAddress = model.CollectionAddress;
            info.NationalCode = model.User.NationalCode;
            info.PhoneNumber = model.User.PhoneNumber;
            info.CollectionName = model.CollectionName;
            return info;
        }

        public void Active(int id)
        {
            var model = _collection.GetById(id).Result;
            model.Active = true;
            _collection.Update(model);
            var user = _user.GetUserById(model.UserId).Result;
            user.IsActive = true;
            _user.Update(user);
            //*****************************//
            var change = CreateRandom.Number().ToString();
            var info = GetSenderInfo();
            var text = _sms.GetGeneralSms(1).Result;
            var message = text.ActiveCollection;
            SmsSender.ActiveCollection(user.PhoneNumber, info, message);
            user.Password = change;
            _user.Update(user);
        }

        public Sender GetSenderInfo()
        {
            var setting = _setting.GetSetting(1).Result;
            Sender sender = new Sender();
            sender.Number = setting.SmsNumberSender;
            sender.Api = setting.SmsApiCode;
            return sender;
        }
        public async Task<bool> IsExistCollectionByStateId(int stateId)
        {
            return await _collection.IsExistCollectionByStateId(stateId);
        }
        public async Task<bool> IsExistCollectionByUserId(int userId)
        {
            return await _collection.IsExistCollectionByUserId(userId);
        }
        public async Task<bool> IsExistCollectionByCityId(int cityId)
        {
            return await _collection.IsExistCollectionByCityId(cityId);
        }
    }
}
