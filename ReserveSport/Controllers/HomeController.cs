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
using RestSharp;

namespace ReserveSport.Controllers
{
    public class HomeController : Controller
    {
        private string authority;
        private readonly IHomeService _home;
        private readonly ICollectionService _collection;
        private readonly IOrderService _orderService;

        public HomeController(IHomeService home, ICollectionService collection,IOrderService orderService)
        {
            _home = home;
            _collection = collection;
            _orderService = orderService;
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
        [HttpPost]
        [Route("/QuickReserve")]
        public IActionResult Quick(QuickViewModel model)
        {
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
        [HttpGet]
        [Route("/Home/Verify/{orderId}")]
        public IActionResult Verify(int orderId)
        {
            var order = _orderService.GetOrderById(orderId).Result;
            var amount = order.OrderPrice * 10;
            string merchant = "27e232d6-b9e3-11e9-96ac-000c295eb8fc";
            try
            {
                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }
                string url = "https://api.zarinpal.com/pg/v4/payment/verify.json?merchant_id=" +
                             merchant + "&amount="
                             + amount + "&authority="
                             + authority;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                IRestResponse response = client.Execute(request);
                Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                string data = jodata["data"].ToString();
                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                string errors = jo["errors"].ToString();
                if (data != "[]")
                {
                    string refid = jodata["data"]["ref_id"].ToString();
                    ViewBag.code = refid;
                    ViewBag.Price = order.OrderPrice;
                    ViewBag.OrderCode = order.OrderCode;
                    _orderService.UpdateOrder(order.OrderId);
                    return View();
                }
                else if (errors != "[]")
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotFound();
        }
    }
}
