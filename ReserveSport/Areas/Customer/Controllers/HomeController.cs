using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using ReserveSport.Helper;
using ClaimsPrincipalExtensions = ReserveSport.Other.ClaimsPrincipalExtensions;

namespace ReserveSport.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Access(4)]
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

        [HttpGet]
        [Route("/Profile/Wallet")]
        public IActionResult Wallet()
        {
            var model = _user.GetUserWallet(UserId()).Result;
            return View(model);
        }
        

        public int UserId()
        {
            int user = Convert.ToInt32(ClaimsPrincipalExtensions.GetUserId(User));
            return user;
        }
    }
}
