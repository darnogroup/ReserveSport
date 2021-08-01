using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Account;
using Application.ViewModel.General;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSport.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _user;
        private readonly IAccountService _account;
        private readonly ICollectionService _collection;

        public AccountController(IUserService user, IAccountService account, ICollectionService collection)
        {
            _user = user;
            _account = account;
            _collection = collection;
        }
        [HttpGet]
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _account.ExistNumber(model.PhoneNumber).Result;
                if (check)
                {
                    ViewBag.Error = "این شماره تلفن مجاز به ثبت نام نیست";
                    return View(model);
                }
                _account.Register(model);
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _account.ExistNumber(model.Number).Result;
                if (result)
                {
                    var active = _account.GetClaim(model).Result;
                    if (active!=null)
                    {
                        var claims = new List<Claim>(){
                            new Claim(ClaimTypes.NameIdentifier,active.UserId.ToString()),
                            new Claim(ClaimTypes.Name,active.UserName),
                            new Claim("UserImage",active.UserImage),
                            new Claim("PhoneNumber",active.PhoneNumber),
                            new Claim("NationalCode",active.NationalCode)
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var property = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync(principal, property);
                        return Redirect("/");
                    }
                    else
                    {
                        ViewBag.Error = "حساب کاربری یافت نشد";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Error = "حساب کاربری یافت نشد";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/sms/{number}")]
        public void Sms(string number)
        {
            _account.Send(number);
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/login");
        }
        public void States()
        {
            var list = _collection.GetStateItems().Result;
            ViewBag.State = new SelectList(list, "StateId", "StateName");
        }
        public void City(int id,int option=0)
        {
            var list = _collection.GetCityItems(id).Result;
            ViewBag.city = new SelectList(list, "CityId", "CityName",option);
        }

        [HttpGet]
        [Route("/RegisterCollection")]
        public IActionResult RegisterCollection()
        {
            States();
            return View();
        }
        [HttpPost]
        [Route("/RegisterCollection")]
        public IActionResult RegisterCollection(RegisterCollectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var state = Convert.ToInt32(model.StateId);
                var city = Convert.ToInt32(model.CityId); 
                var checkUser = _user.CheckNumber(model.PhoneNumber).Result;
                var check = _collection.CheckCollection(model.CollectionName, state, city).Result;
                if (check || checkUser)
                {
                    States();
                    ViewBag.Error = "اطلاعات مجموعه یا کاربر تکرار است";
                    var id = Convert.ToInt32(model.StateId);
                    var select = Convert.ToInt32(model.CityId);
                    City(id, select);
                    return View(model);
                }
                else
                {
                    _account.RegisterCollection(model);
                    ViewBag.Error = "ثبت با موفقیت انجام شد،بعد از تائید مدیر مجموعه شما می گردد";
                    return View();
                }
            }
            {
                States();
                var id = Convert.ToInt32(model.StateId);
                var select= Convert.ToInt32(model.CityId);
                City(id,select);
                return View(model);
            }
        }
        [HttpGet]
        [Route("/CityList/{id}")]
        public JsonResult GetCity(int id)
        {
            var list = _collection.GetCityItems(id).Result;
            list.Add(new ItemCityViewModel()
            {
                CityName = "یک گزینه انتخاب کنید",
                CityId = 0
            });
            var result = new SelectList(list.OrderBy(o => o.CityId), "CityId", "CityName");

            return Json(result);
        }
    }
}
