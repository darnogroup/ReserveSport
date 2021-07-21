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
using ReserveSport.Helper;

namespace ReserveSport.Controllers
{
    public class HomeController : Controller
    {
        //zarinPal
        private string authority;
        private readonly IHomeService _home;
        private readonly ICollectionService _collection;
        private readonly IOrderService _orderService;
        private readonly ISettingService _setting;

        public HomeController(IHomeService home, ISettingService setting, ICollectionService collection,
            IOrderService orderService)
        {
            _home = home;
            _setting = setting;
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
            States();
            Time();
            return View();
        }

        [HttpGet]
        [Route("/About")]
        public IActionResult About()
        {
            var model = _setting.GetAbout().Result;
            return View(model);
        }

        [HttpPost]
        [Route("/QuickReserve")]
        public IActionResult Quick(QuickViewModel model)
        {
            if (!ModelState.IsValid)
            {
                States();
                Time();
                return View(model);
            }

            if (_orderService.IsExistDetail(model.Reserve, model.Collection, model.Sport).Result)
            {
                States();
                Time();
                ViewBag.Warning = "این تایم قبلا رزرو شده است";
                return View(model);
            }

            if (User.Identity.IsAuthenticated)
            {
                int userId = int.Parse(User.GetUserId());
                _orderService.AddToCart(model.Reserve, model.Collection, model.Sport, userId);
                return Redirect("/ShowCart");
            }
            States();
            Time();
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
        public JsonResult GetReserve(string y, string m, string d, string collection)
        {
            var time = y + "/" + m + "/" + d;
            var list = _home.GetReserveItem(time, collection).Result;
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
            var setting = _setting.GetFirstSetting().Result;
            string merchant = setting.ZarinPal;
            try
            {
                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }

                var payment = Payments.DoVerify(amount, merchant, authority);
                if (payment.Item2 != "[]")
                {
                    string refid = payment.Item1["data"]["ref_id"].ToString();
                    ViewBag.code = refid;
                    ViewBag.Price = order.OrderPrice;
                    ViewBag.OrderCode = order.OrderCode;
                    _orderService.UpdateOrder(order.OrderId);
                    return View();
                }
                else if (payment.Item3 != "[]")
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
        [HttpGet]
        [Route("/Home/VerifyCharge/{money}")]
        public IActionResult VerifyCharge(int money)
        {
            var amount = money * 10;
            var setting = _setting.GetFirstSetting().Result;
            string merchant = setting.ZarinPal;
            try
            {
                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }
                var payment = Payments.DoVerify(amount,merchant,authority);
                if (payment.Item2 != "[]")
                {
                    string refid = payment.Item1["data"]["ref_id"].ToString();
                    ViewBag.code = refid;
                    ViewBag.Price = money;
                    return View();
                }
                else if (payment.Item3 != "[]")
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
        [HttpGet]
        [Route("/complaint")]
        public IActionResult Complaint()
        {
            return View();
        }

        [HttpPost]
        [Route("/complaint")]

        public IActionResult Complaint(AddComplaintViewModel model)
        {
            if (ModelState.IsValid)
            {
                _setting.Add(model);
                ViewBag.error = "با تشکر در اسرع وقت کارشناسان ما با شما ارتباط برقرار میکنند";
                return View();
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _setting.InsertContact(model);
                ViewBag.error = "با تشکر از پیام شما دریافت شد کارشناسان ما با شما ارتباط برقرار میکنند";
                return View();
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        [Route("/Collections/{search?}")]
        public IActionResult Collections(int city,int state, string search = "",int page = 1)
        {
            ViewBag.Search = search;
            ViewBag.StateId = state;
            ViewBag.City = city;
            States();
            var model = _home.GetAllCollection(state,city,search, page);
            return View(model);
        }

        [HttpGet]
        [Route("/Article/{id}")]
        public IActionResult Article(int id, string title)
        {
            var model = _home.GetById(id).Result;
            string[] tags = model.ArticleTags.Split("-");
            ViewBag.tags = tags;
            return View(model);
        }
    }


}
