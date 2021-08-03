using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Reserve;
using ReserveSport.Helper;
using ClaimsPrincipalExtensions = ReserveSport.Other.ClaimsPrincipalExtensions;

namespace ReserveSport.Areas.Collection.Controllers
{
    [Area("Collection")]
    [Access(2)]
    public class DashboardController : Controller
    {
        private readonly ICollectionService _collection;
        private readonly IReserveService _reserve;
        private readonly IOrderService _order;
        private readonly ICheckService _check;

        public DashboardController(ICollectionService collection, IReserveService reserve, IOrderService order, ICheckService check)
        {
            _collection = collection;
            _reserve = reserve;
            _order = order;
            _check = check;
        }

        [HttpGet]
        [Route("/Collection")]
        public IActionResult Index()
        {
            int userId = Convert.ToInt32(ClaimsPrincipalExtensions.GetUserId(User));
            var model = _collection.GetCollection(userId).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Collection/Financial/{id}")]
        public IActionResult Financial(int id)
        {
            var model = _collection.GetFinancial(id).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Collection/Reserve/{id}")]
        public IActionResult Reserve(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpGet]
        [Route("/Collection/Reserve/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _reserve.GetReserveById(id).Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Collection/Reserve/Edit/{id}")]
        public IActionResult Edit(EditReserveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _reserve.Exist(model.DayTime, model.StartTime, model.EndTime, model.Price).Result;
                if (check)
                {
                    ViewBag.Error = "سانسی با این مشخصات وجود دارد";
                    return View(model);
                }
                _reserve.Edit(model);
                return Redirect($"/Collection/Reserves/{@model.CollectionId}");

            }
            else
            {
                return View(model);
            }

        }
        [HttpPost]
        [Route("/Collection/Reserve/{id}")]
        public IActionResult Reserve(CreateReserveViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reserve.Create(model);
                return Redirect("/collection");
            }
            else
            {
                ViewBag.id = model.CollectionId;
                return View();
            }
        }

        [HttpGet]
        [Route("/Collection/Reserves/{id}")]
        public IActionResult Reserves(int id,int page = 1)
        {
          
            ViewBag.collection = id;
            var model = _reserve.GetReserve(id, page);
            return View(model);
        }
        [HttpGet][Route("/Collection/Orders/{search?}")]
        public IActionResult Orders(int collectionId,string search="", int page = 1)
        {
            ViewBag.Search = search;
            ViewBag.collectionId = collectionId;
            var model = _order.GetOrders(search??"", collectionId, page);
            return View(model);
        }
        public int UserId()
        {
            return Convert.ToInt32(ClaimsPrincipalExtensions.GetUserId(User));
        }

        [HttpGet]
        [Route("/Collection/CheckOut/{id}")]
        public IActionResult CheckOut(int id,string search="",int page=1)
        {
            var model = _check.GetCheckCollection(id, search ?? "", page);
            ViewBag.Search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Collection/SubmitCheck/{id}")]
        public int SubmitCheck(int id)
        {
            var result = _check.SubmitCheck(id).Result;
            return result;
        }
    }
}
