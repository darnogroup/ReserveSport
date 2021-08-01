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
    public class DashboardController : Controller
    {
        private readonly IHomeService _home;

        public DashboardController(IHomeService home)
        {
            _home = home;
        }
        [HttpGet]
        [Route("/admin/Dashboard")]
        [Route("/admin")]
        public IActionResult Index()
        {
            var model = _home.GetInfoDashboard().Result;
            return View(model);
        }
    }
}
