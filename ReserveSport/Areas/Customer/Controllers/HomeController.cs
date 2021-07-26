using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using ReserveSport.Helper;
using ClaimsPrincipalExtensions = ReserveSport.Other.ClaimsPrincipalExtensions;
using Application.ViewModel.User;
using Microsoft.AspNetCore.Authorization;

namespace ReserveSport.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _user;
        private readonly IWalletServcie _wallet;
        
        public HomeController(IUserService user,IWalletServcie wallet)
        {
            _user = user;
            _wallet = wallet;
        }
        [HttpGet]
        [Route("/Profile")]
        public IActionResult Index()
        {
            ViewBag.Collection = _user.GetCollectionId(UserId()).Result;
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
        [HttpPost]
        [Route("/Profile/ChargeWallet")]
        public IActionResult ChargeWallet(UserWalletViewModel model)
        {
            _wallet.UpdateWallet(model);
            return Redirect($"/ChargeWallet/{model.Price}");
        }

        public int UserId()
        {
            int user = Convert.ToInt32(ClaimsPrincipalExtensions.GetUserId(User));
            return user;
        }
    }
}
