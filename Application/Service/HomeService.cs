using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Home;
using Application.ViewModel.Sport;
using Domin.Interface;

namespace Application.Service
{
    public class HomeService : IHomeService
    {
        private readonly ICollectionInterface _collection;
        private readonly IArticleInterface _article;
        private readonly IReserveInterface _reserve;
        private readonly ISportInterface _sport;
        private readonly IReserveSportRepository _reserveSport;

        public HomeService(ICollectionInterface collection, IArticleInterface article, IReserveInterface reserve, ISportInterface sport
            ,IReserveSportRepository reserveSport)
        {
            _collection = collection;
            _article = article;
            _reserve = reserve;
            _sport = sport;
            _reserveSport = reserveSport;
        }
        public async Task<List<ItemCollectionViewModel>> GetCollections()
        {
            var list = await _collection.GetCollections();
            List<ItemCollectionViewModel> collections = new List<ItemCollectionViewModel>();
            var result = list.OrderByDescending(o => o.CollectionId).Take(6).ToList();
            foreach (var item in result)
            {
                collections.Add(new ItemCollectionViewModel()
                {
                    CollectionCity = item.City.CityName,
                    CollectionId = item.CollectionId,
                    CollectionNumber = item.CollectionPhoneNumber,
                    CollectionState = item.State.StateName,
                    CollectionName = item.CollectionName,
                    Image = item.Image
                });
            }

            return collections;
        }

        public async Task<List<ItemArticleViewModel>> GetArticles()
        {
            var list = await _article.GetArticles();
            var result = list.OrderByDescending(o => o.CreateTime).Take(3).ToList();
            List<ItemArticleViewModel> articles = new List<ItemArticleViewModel>();
            foreach (var item in result)
            {
                articles.Add(new ItemArticleViewModel()
                {
                    Image = item.ArticleImage,
                    Id = item.ArticleId,
                    Summary = item.ArticleSummary,
                    Title = item.ArticleTitle
                });
            }

            return articles;
        }

        public Tuple<ShowCollectionViewModel, List<SportsCollectionViewModel>> GetCollection(int id)
        {
            var collection = _collection.GetById(id).Result;
            ShowCollectionViewModel show = new ShowCollectionViewModel();
            show.Image = collection.Image;
            show.CollectionName = collection.CollectionName;
            show.CollectionPhoneNumber = collection.CollectionPhoneNumber;
            show.State = collection.State.StateName;
            show.City = collection.City.CityName;
            show.LicensePath = collection.LicensePath;
            show.CollectionId = collection.CollectionId;
            show.CollectionAddress = collection.CollectionAddress;
            //*******************************************
            var sports = _collection.GetByCollectionId(id).Result;
            List<SportsCollectionViewModel> sportsCollection = new List<SportsCollectionViewModel>();
            foreach (var item in sports)
            {
                var model = _sport.GetSportById(item.SportId).Result;
                sportsCollection.Add(new SportsCollectionViewModel()
                {
                    Name = model.SportName
                });
            }

            return Tuple.Create(show, sportsCollection);
        }

        public async Task<List<ItemReserveViewModel>> GetReserveById(int id)
        {
            var y = DateTime.Now.Year;
            var n = DateTime.Now.Month + 1;
            var m = 0;
            m = n == 13 ? 1 : n;
            var d = DateTime.Now.Day;
            var nextTimeString = y + "/" + m + "/" + d;
            var nextTime = nextTimeString.MiladiTime();
            var list = await _reserve.GetReserveCollection(id, nextTime);
            var result = list.OrderBy(o => o.DayTime).ToList();
            List<ItemReserveViewModel> reserves = new List<ItemReserveViewModel>();
            foreach (var item in result)
            {
                List<SportViewModel> models = new List<SportViewModel>();
                reserves.Add(new ItemReserveViewModel()
                {
                    DayTime = item.DayTime.ToShamsi(),
                    EndTime = item.EndTime,
                    StartTime = item.StartTime,
                    Id = item.ReserveId,
                    Price = Convert.ToInt32(item.Price),
                    Sports = models
                });
                var sports = _reserveSport.GetAllReserveSports(item.ReserveId).Result;
                foreach (var sport in sports)
                {
                    models.Add(new SportViewModel()
                    {
                        SportId = sport.SportId,
                        SportName = sport.SportName,
                        IsReserved = sport.IsReserved,
                        IsFinished = sport.IsFinished
                    });
                }
            }
            return reserves;
        }

        public async Task<List<SelectCollectionViewModel>> GetCollectionSelection(int state, int city)
        {
            var list = await _collection.GetByQuick(state, city);
            List<SelectCollectionViewModel> selects = new List<SelectCollectionViewModel>();
            foreach (var item in list)
            {
                selects.Add(new SelectCollectionViewModel()
                {
                    Id = item.CollectionId,
                    Name = item.CollectionName
                });
            }

            return selects;
        }

        public async Task<List<SelectSportViewModel>> GetSports(int id)
        {
            var list = await _collection.GetByCollectionId(id);
            List<SelectSportViewModel> sports = new List<SelectSportViewModel>();
            foreach (var item in list)
            {
                var model = _sport.GetSportById(item.SportId).Result;
                sports.Add(new SelectSportViewModel()
                {
                    Id = model.SportId,
                    Title = model.SportName
                });
            }

            return sports;
        }

        public List<ItemTimeViewModel> GetTime()
        {
            List<ItemTimeViewModel> itemTime = new List<ItemTimeViewModel>();
            var y = DateTime.Now.Year;
            var n = DateTime.Now.Month + 1;
            var m = 0;
            m = n == 13 ? 1 : n;
            var d = DateTime.Now.Day;
            var nextTimeString = y + "/" + m + "/" + d;
            var nextTime = nextTimeString.MiladiTime();
            //*********************//
            var startTime = DateTime.Now.ToShamsi();
            var endTime = nextTime.ToShamsi();
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
                    itemTime.Add(new ItemTimeViewModel()
                    {
                        Time = Time.JustYear(year, month, day)
                    });
                }

                month += 1;
                startDay = 1;
            }

            return itemTime;
        }

        public async Task<List<SelectReserveViewModel>> GetReserveItem(string time,string collection)
        {
            int id = Convert.ToInt32(collection);
            var list = await _reserve.GetTimeItem(time.ToMiladiDateTime(),id);
            List<SelectReserveViewModel>reserves=new List<SelectReserveViewModel>();
            foreach (var item in list)
            {
                reserves.Add(new SelectReserveViewModel()
                {
                    Id = item.ReserveId,
                    Reserve = item.EndTime+"تا"+item.StartTime
                });
            }

            return reserves;
        }
    }
}
