﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Enum;
using Application.ViewModel.User;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class UserController : Controller
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("/Admin/User/{search?}")]
        public IActionResult Index(string search = "", int page = 1)
        {
            var model = _user.GetUsers(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/User/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/User/Create")]
        public IActionResult Create(AddUSerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _user.CheckNumber(model.PhoneNumber).Result;
                if (check)
                {
                    ViewBag.Error = "این شماره تلفن در سیستم موجود است";
                    return View(model);
                }
                else
                {
                    _user.Add(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        [Route("/Admin/User/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _user.GetUserById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/User/Edit/{id}")]
        public IActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.OldRole != model.Role)
                {
                    if (model.OldRole == EnumRole.مدیرمجموعه)
                    {
                        var checkResult = _user.ExistCollection(model.UserId).Result;
                        if (checkResult)
                        {
                            ViewBag.Error = "این کاربر مدیر مجموعه است -برای تغیر ابتدا مدیریت مجموعه را واگذار کنید";
                            return View(model);
                        }
                      
                    }
                }
                if (model.OldPhoneNumber != model.PhoneNumber)
                {
                    var check = _user.CheckNumber(model.PhoneNumber).Result;
                    if (check)
                    {
                        ViewBag.Error = "این شماره تلفن در سیستم موجود است";
                        return View(model);
                    }
                }

                _user.Edit(model);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/User/Remove/{id}")]
        public void Remove(int id)
        {
            _user.Remove(id);
        }
        [HttpGet]
        [Route("/Admin/User/Trash/{search?}")]
        public IActionResult Trash(string search = "", int page = 1)
        {
            var model = _user.GetTrashUsers(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }
        [HttpGet]
        [Route("/Admin/User/Back/{id}")]
        public void Back(int id)
        {
            _user.Back(id);
        }
        [HttpGet]
        [Route("/Admin/User/Delete/{id}")]
        public bool Delete(int id)
        {
           var result= _user.Delete(id);
           return result;
        }

        [HttpGet]
        [Route("/Admin/User/Wallet/{id}")]
        public IActionResult Wallet(int id)
        {
            var model = _user.GetUserWallet(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/User/Wallet/{id}")]
        public IActionResult Wallet(UserWalletViewModel model)
        {
            if (model.Price < 0)
            {
                ViewBag.Error = "موجودی نمیتواند کمتر از صفر باشد";
                return View(model);
            }
            else
            {
                _user.AddToWallet(model);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}