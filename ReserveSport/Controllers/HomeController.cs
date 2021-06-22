using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReserveSport.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.General;
using Application.ViewModel.Home;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSport.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _home;
        private readonly ICollectionService _collection;

        public HomeController(IHomeService home, ICollectionService collection)
        {
            _home = home;
            _collection = collection;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/Collection/{id}")]
        public IActionResult ShowCollection(int id, string title)
        {
            ViewBag.title = title;
            var model = _home.GetCollection(id);
            return View(model);
        }

        [HttpGet]
        [Route("/QuickReserve")]
        public IActionResult Quick()
        {
            States(); Time();
            return View();
        }
        public void States()
        {
            var list = _collection.GetStateItems().Result;
            ViewBag.State = new SelectList(list, "StateId", "StateName");
        }

        public void Sports()
        {
            ViewBag.Sports = _collection.GetSportItem().Result;
        }

        public void City(int id)
        {
            var list = _collection.GetCityItems(id).Result;

            ViewBag.city = new SelectList(list, "CityId", "CityName");
        }

        public void Users()
        {
            var list = _collection.GetUserItems().Result;
            ViewBag.User = new SelectList(list, "UserId", "UserName");
        }

        public void Selected(int id)
        {
            ViewBag.select = _collection.SelectedSport(id).Result;
        }

        [HttpGet]
        [Route("/QuickReserve/CityList/{id}")]
        public JsonResult GetCity(int id)
        {
            var list = _collection.GetCityItems(id).Result;
            list.Add(new ItemCityViewModel()
            {
                CityName = "یک شهر انتخاب کنید",
                CityId = 0
            });
            var result = new SelectList(list.OrderBy(o => o.CityId), "CityId", "CityName");

            return Json(result);
        }
        [HttpGet]
        [Route("/QuickReserve/CollectionList/{state}/{city}")]
        public JsonResult GetCollection(int state, int city)
        {
            var list = _home.GetCollectionSelection(state, city).Result;
            list.Add(new SelectCollectionViewModel()
            {
                Id = 0,
                Name = "یک مجموعه انتخاب کنید"
            });
            var result = new SelectList(list.OrderBy(o => o.Id), "Id", "Name");
            return Json(result);
        }

        [HttpGet]
        [Route("/QuickReserve/SportList/{collection}")]
        public JsonResult GetSport(int collection)
        {
            var list = _home.GetSports(collection).Result;
            list.Add(new SelectSportViewModel()
            {
                Id = 0,
                Title = "یک رشته ورزشی انتخاب کنید"
            });
            var result = new SelectList(list.OrderBy(o => o.Id), "Id", "Title");
            return Json(result);
        }

        public void Time()
        {
            var list = _home.GetTime();
            ViewBag.Time = new SelectList(list, "Time", "Time");
        }

        [HttpGet]
        [Route("/QuickReserve/ReserveList/{y}/{m}/{d}/{collection}")]
        public JsonResult GetReserve(string y,string m,string d, string collection)
        {
            var time = y + "/" + m + "/" + d;
            var list = _home.GetReserveItem(time,collection).Result;
            list.Add(new SelectReserveViewModel()
            {
                Id = 0,
                Reserve = "یک سانس انتخاب کنید"
            });
            var result = new SelectList(list.OrderBy(o => o.Id), "Id", "Reserve");
            return Json(result);
        }

























        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
