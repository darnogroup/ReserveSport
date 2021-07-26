using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class OrderController : Controller
    {
        private readonly IOrderService _order;

        public OrderController(IOrderService order)
        {
            _order = order;
        }
        [HttpGet][Route("/Admin/Orders/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
            ViewBag.Search = search;
            var model = _order.GetFinishedOrders(search??"",page);
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Order/{id}")]
        public IActionResult Order(int id)
        {
            var model = _order.GetItemOrder(id).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/RemoveOrder/{id}")]
        public void RemoveOrder(int id)
        {
            _order.RemoveOrder(id);
        }
        [HttpGet]
        [Route("/Admin/RemoveOrderItem/{id}")]
        public void RemoveOrderItem(int id)
        {
            _order.RemoveOrderItem(id);
        }
    }
}
