using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveSport.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSport.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWalletServcie _walletService;
        private readonly ISettingService _settingService;
        string authority; 
        public OrderController(IOrderService orderService,IWalletServcie walletServcie,ISettingService settingService)
        {
            _orderService = orderService;
            _walletService = walletServcie;
            _settingService = settingService;
        }
        [HttpGet][Route("/ShowCart")]
        public IActionResult ShowCart(string success = "",string warning = "")
        {
            var model = _orderService.GetCardItem(UserId());
            int orderCount = _orderService.DetailsCountByOrderId(model.Item2.OrderId).Result;
            ViewBag.OrderCount = orderCount;
            ViewBag.Success = success;
            ViewBag.Warning = warning;
            return View(model);
        }
        [HttpGet]
        [Route("/AddToCart")]
        public JsonResult AddToCart(int id,int sportId)
        {
            if (_orderService.IsExistDetail(id,sportId).Result)
            {
                return Json("3");
            }
            if (User.Identity.IsAuthenticated)
            {
                _orderService.AddToCart(id,sportId, UserId());
              return Json("1");
            }
            //3=Please Login To Site
          return Json("2");
        }
        private int UserId()
        {
            int userId = int.Parse(User.GetUserId());
            return userId;
        }
        [HttpGet]
        [Route("/UserCart/Remove/{id}/{sportId}")]
        public void Remove(int id,int sportId)
        {
            _orderService.RemoveItemCart(id,sportId);
        }
        [Authorize]
        public IActionResult Payment(int? wallet)
        {
            var order = _orderService.GetOrderByUserId(UserId()).Result;
            string mobile = User.GetPhoneNumber();
            var setting = _settingService.GetFirstSetting().Result;
            var amount = order.OrderPrice * 10;
            if (wallet != null)
            {
                bool pay = _walletService.PayByWallet(order).Result;
                if (pay)
                {
                    string success = "پرداخت با موفقیت انجام شد";
                    return RedirectToAction("ShowCart","Order",new { success = success });
                }
                else
                {
                    string warning = "موجودی کیف پول شما کافی نمی باشد";
                    return RedirectToAction("ShowCart", "Order", new { warning = warning });
                }
            }
            string merchant = setting.ZarinPal;
            string callbackurl = $"https://reservsport.ir/Home/Verify/{order.OrderId}";
            string description = "پرداخت نهایی سانس";
            try
            {
                var jodata = Payments.DoPayment(mobile,merchant,amount,callbackurl,description);
                if (_orderService.DetailsCountByOrderId(order.OrderId).Result == 0)
                {
                    return Redirect("/UserCart");
                }
                if (authority != "[]")
                {
                    authority = jodata["data"]["authority"].ToString();
                    string gatewayUrl = "https://www.zarinpal.com/pg/StartPay/" + authority;
                    return Redirect(gatewayUrl);
                }
                else
                {
                    //return BadRequest();
                    return BadRequest("error ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        [Authorize]
        [Route("/ChargeWallet/{money}")]
        public IActionResult ChargeWallet(int money)
        {
            var setting = _settingService.GetFirstSetting().Result;
            string mobile = User.GetPhoneNumber();
            var amount = money * 10;
            string merchant = setting.ZarinPal;
            string callbackurl = $"https://reservsport.ir/Home/VerifyCharge/{money}";
            string description = "شارز کیف پول";
            try
            {
                var jodata = Payments.DoPayment(mobile, merchant, amount, callbackurl, description);
                if (authority != "[]")
                {
                    authority = jodata["data"]["authority"].ToString();
                    string gatewayUrl = "https://www.zarinpal.com/pg/StartPay/" + authority;
                    return Redirect(gatewayUrl);
                }
                else
                {
                    //return BadRequest();
                    return BadRequest("error ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}