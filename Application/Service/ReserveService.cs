using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Collection;
using Application.ViewModel.Reserve;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class ReserveService : IReserveService
    {
        private readonly IReserveInterface _reserve;

        public ReserveService(IReserveInterface reserve)
        {
            _reserve = reserve;
        }
        public Tuple<List<ReserveViewModel>, int, int> GetReserve(int id, int page = 1)
        {
            var result = _reserve.GetReserves(id).Result;
            List<ReserveViewModel> models = new List<ReserveViewModel>();
            var collection = result.OrderBy(o=>o.DayTime).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(collection.Count, 10);
            int skip = (page - 1) * 10;
            var reserveList = collection.Skip(skip).Take(10).ToList();
            foreach (var item in reserveList)
            {
                models.Add(new ReserveViewModel()
                {
                    StartTime = item.StartTime,
                    DayTime = item.DayTime.ToShamsi(),
                    EndTime = item.EndTime,
                    Price = Convert.ToInt32(item.Price),
                    Id = item.ReserveId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditReserveViewModel> GetReserveById(int id)
        {
            var reserve = await _reserve.GetReserveById(id);
            EditReserveViewModel edit = new EditReserveViewModel();
            edit.CollectionId = reserve.CollectionId;
            edit.Price = reserve.Price;
            edit.EndTime = reserve.EndTime;
            edit.StartTime = reserve.StartTime;
            edit.DayTime = reserve.DayTime.ToShamsi();
            edit.Id = reserve.ReserveId;
            return edit;
            
        }

        public void Create(CreateReserveViewModel model)
        {
            var startTime = model.StartDayTime;
            var endTime = model.EndDayTime;
            var year = startTime.Year();
            var startDay = startTime.Day();
            var ednDay = endTime.Day();
            var startMonth = startTime.Month();
            var endMonth = endTime.Month();
            var countRun = endMonth - startMonth;
            var month = startMonth;
            for (int i = 0; i <= countRun; i++)
            {

                var monthFinish = 0;
                switch (Time.Season(month.ToString()))
                {
                    case 31:
                        monthFinish = 31;
                        break;
                    case 30:
                        monthFinish = 30;
                        break;
                    case 29:
                        monthFinish = 29;
                        break;
                }

                if (month == endMonth)
                {
                    monthFinish = ednDay;
                }
                for (int day = startDay; day <= monthFinish; day++)
                {
                    ReserveModel reserve=new ReserveModel();
                    reserve.CollectionId = model.CollectionId;
                    reserve.Price = model.Price;
                    reserve.StartTime = model.StartTime;
                    reserve.EndTime = model.EndTime;
                    var time = Time.JustYear(year, month, day);
                    reserve.DayTime = time.ToMiladiDateTime();
                    var check = _reserve.Exist(time.ToMiladiDateTime(), model.StartTime, model.EndTime).Result;
                    if (check == false)
                    {
                        _reserve.Create(reserve);
                    }

                }

                month += 1;
                startDay = 1;
            }
        }

        public void Edit(EditReserveViewModel model)
        {
            var reserve = _reserve.GetReserveById(model.Id).Result;
            reserve.Price = model.Price;
            reserve.DayTime = model.DayTime.ToMiladiDateTime();
            reserve.EndTime = model.EndTime;
            reserve.StartTime = model.StartTime;
            _reserve.Update(reserve);
        }

        public void Delete(int id)
        {
            var model = _reserve.GetReserveById(id).Result;
            _reserve.Remove(model);
        }

        public async Task<bool> Exist(string time, string start, string end, string price = "")
        {
            var result = await _reserve.Exist(time.ToMiladiDateTime(), start, end, price);
            return result;
        }

        public async Task<int> CollectionId(int userId)
        {
            var result =await _reserve.GetCollectionId(userId);
            return result;
        }
    }
}
