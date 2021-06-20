using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using ReserveSport.Other;

namespace ReserveSport.Areas.Customer.Controllers
{[Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUserService _user;

        public HomeController(IUserService user)
        {
            _user = user;
        }
        [HttpGet]
        [Route("/Profile")]
        public IActionResult Index()
        {
            var model = _user.GetProfile(UserId()).Result;
            return View(model);
        }

        public int UserId()
        {
            int user = Convert.ToInt32(User.GetUserId());
            return user;
        }
    }
}
