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
    public class RequestController : Controller
    {
        private readonly ICollectionService _collection;

        public RequestController(ICollectionService collection)
        {
            _collection = collection;
        }
        [HttpGet][Route("/Admin/Request/{search?}")]
        public IActionResult Index(string search,int page=1)
        {
            var model = _collection.GetRequestList(search ?? "", page);
            ViewBag.Search = search;
            return View(model);
        }
        [HttpGet][Route("/Admin/Info/{id}")]
        public IActionResult Info(int id)
        {
            var item = _collection.GetInfoRequest(id).Result;
            return View(item);
        }

        [HttpGet]
        [Route("/Admin/ActiveCollection/{id}")]
        public void Active(int id)
        {
           _collection.Active(id);//SMS
        }
    }
}
