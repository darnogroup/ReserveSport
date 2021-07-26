using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ReserveSport.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;

        public AccountController(IAccountService account)
        {
            _account = account;

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

        [HttpGet]
        [Route("/RegisterCollection")]
        public IActionResult RegisterCollection()
        {
            return View();
        }
    }
}
