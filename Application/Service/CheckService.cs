using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Article;
using Application.ViewModel.CheckOut;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class CheckService:ICheckService
    {
        private readonly ICheckInterface _check;
        private readonly ICollectionInterface _collection;
        private readonly ISettingInterface _setting;

        public CheckService(ICheckInterface check, ICollectionInterface collection, ISettingInterface setting)
        {
            _check = check;
            _collection = collection;
            _setting = setting;
        }
      
        public Tuple<List<CollectionCheckViewModel>, int, int> GetCheckCollection(int id,string search = "", int page = 1)
        {
           List<CollectionCheckViewModel>checks=new List<CollectionCheckViewModel>();
           var result = _check.GetCollectionCheckOuts(id).Result;
           var checkList = result.Where(w => w.CheckoutCode.Contains(search))
               .OrderByDescending(o => o.DateTime).ToList();
           int pageNumber = page;
           int pageCount = Page.PageCount(checkList.Count, 10);
           int skip = (page - 1) * 10;
           var list = checkList.Skip(skip).Take(10).ToList();
           foreach (var item in list)
           {
               checks.Add(new CollectionCheckViewModel()
               {
                   CheckoutCode = item.CheckoutCode,
                   CheckoutClose = item.CheckoutClose,
                   CheckoutId = item.CheckoutId,
                   CheckoutPrice = item.CheckoutPrice,
                   DateTime = item.DateTime.ToShamsi()
               });
           }
           return Tuple.Create(checks, pageCount, pageNumber);
        }

        public Tuple<List<CheckOutViewModel>, int, int> GetChecks(string search = "", int page = 1)
        {
            List<CheckOutViewModel> checks = new List<CheckOutViewModel>();
            var result = _check.GetCheckOuts().Result;
            var checkList = result.Where(w => w.CheckoutCode.Contains(search))
                .OrderByDescending(o => o.DateTime).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(checkList.Count, 10);
            int skip = (page - 1) * 10;
            var list = checkList.Skip(skip).Take(10).ToList();
            foreach (var item in list)
            {
                checks.Add(new CheckOutViewModel()
                {
                    CheckoutCode = item.CheckoutCode,
                    CheckoutClose = item.CheckoutClose,
                    CheckoutId = item.CheckoutId,
                    CheckoutPrice = item.CheckoutPrice,
                    DateTime = item.DateTime.ToShamsi(),
                    Collection = item.Collection.CollectionName,
                    CollectionId = item.CollectionId
                });
            }
            return Tuple.Create(checks, pageCount, pageNumber);
        }

        public async Task<int> SubmitCheck(int id)
        {
            var result =await _check.GetFinancial(id);
            CheckoutModel checkout=new CheckoutModel();
            checkout.CheckoutClose = false;
            checkout.CheckoutCode = CreateRandom.Number().ToString();
            checkout.DateTime=DateTime.Now;
            checkout.CollectionId = result.Collection.CollectionId;
            var debtor = Convert.ToInt32(result.Debtor);
            var creditor = Convert.ToInt32(result.FinancialPrice);
            if (creditor != 0)
            {
                var setting = _setting.GetSetting(1).Result;
                var percent = Convert.ToInt32(setting.Salary);
                var priceCreditor = Convert.ToInt32(result.FinancialPrice);
                var salary = (priceCreditor * percent) / 100;
                var mainPrice = priceCreditor - salary;
                if (debtor != 0)
                {
                    if (mainPrice >= debtor)
                    {
                        var priceRequest = mainPrice - debtor;
                        checkout.CheckoutPrice = priceRequest.ToString();
                        result.Debtor = "0";
                        result.FinancialPrice = "0";
                        _check.Create(checkout);
                        _collection.EditFinancial(result);
                        return 1;
                        //بدهی تسویه مابقی ثبت
                    }
                    else
                    {
                        var price = debtor - mainPrice;
                        result.Debtor = price.ToString();
                        result.FinancialPrice = "0";
                        _collection.EditFinancial(result);
                        return 2;
                        //طلب شما پرداخت شد
                    }
                }
                else
                {
                    checkout.CheckoutPrice = mainPrice.ToString(); 
                    result.FinancialPrice = "0";
                    _check.Create(checkout);
                    _collection.EditFinancial(result);
                    return 4;//ثبت شد
                }
            }
            else
            {
                return 3;//موجودی کافی نیست
            }

        }

        public void Close(int id)
        {
            var result = _check.GetCheck(id).Result;
            result.CheckoutClose = true;
            _check.Update(result);
        }
    }
}
