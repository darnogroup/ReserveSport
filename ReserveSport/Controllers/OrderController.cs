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
        private string authority;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet][Route("/ShowCart")]
        public IActionResult ShowCart()
        {
            var model = _orderService.GetCardItem(UserId());
            int orderCount = _orderService.DetailsCountByOrderId(model.Item2.OrderId).Result;
            ViewBag.OrderCount = orderCount;
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
        public IActionResult Payment()
        {
            var order = _orderService.GetOrderByUserId(UserId()).Result;
            string mobile = User.GetPhoneNumber();
            var amount = order.OrderPrice * 10;
            string merchant = "";
            string callbackurl = $"https://localhost:44374/Home/Verify/{order.OrderId}";
            string description = "پرداخت نهایی سانس";
            try
            {
                string[] metadata = new string[1];
                metadata[0] = $"[mobile: {mobile}]";

                //be dalil in ke metadata be sorate araye ast va do meghdare mobile va email dar metadata gharar mmigirad
                //shoma mitavanid in maghadir ra az kharidar begirid va set konid dar gheir in sorat khali ersal konid

                string requesturl;
                requesturl = "https://api.zarinpal.com/pg/v4/payment/request.json?merchant_id=" +
                    merchant + "&amount=" + amount +
                    "&callback_url=" + callbackurl +
                    "&description=" + description +
                    "&metadata[0]=" + metadata[0];
                ;
                var client = new RestClient(requesturl);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                IRestResponse requestresponse = client.Execute(request);
                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
                string errorscode = jo["errors"].ToString();
                Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
                string dataauth = jodata["data"].ToString();
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
    }
}
