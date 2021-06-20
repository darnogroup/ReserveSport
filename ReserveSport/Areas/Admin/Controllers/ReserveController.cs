using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Reserve;

namespace ReserveSport.Areas.Admin.Controllers
{[Area("Admin")]
    public class ReserveController : Controller
    {
        private readonly IReserveService _reserve;

        public ReserveController(IReserveService reserve)
        {
            _reserve = reserve;
        }
        [HttpGet]
        [Route("/Admin/Reserve/{id}")]
        public IActionResult Index(int id,int page=1)
        {
            ViewBag.id = id;
            var model = _reserve.GetReserve(id, page);
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Reserve/Create/{id}")]
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [Route("/Admin/Reserve/Create/{id}")]
        public IActionResult Create(CreateReserveViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reserve.Create(model);
                return Redirect($"/Admin/Reserve/{@model.CollectionId}");
            }
            else
            {
                ViewBag.id = model.CollectionId;
                return View();
            }
        }

        [HttpGet]
        [Route("/Admin/Reserve/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _reserve.GetReserveById(id).Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/Reserve/Edit/{id}")]
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
                return Redirect($"/Admin/Reserve/{@model.CollectionId}");

            }
            else
            {
                return View(model);
            }
          
        }

        [HttpGet]
        [Route("/Admin/Reserve/Delete/{id}")]
        public void Delete(int id)
        {
            _reserve.Delete(id);
        }
    }
}
