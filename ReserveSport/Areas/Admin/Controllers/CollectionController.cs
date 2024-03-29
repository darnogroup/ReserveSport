﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Collection;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collection;

        public CollectionController(ICollectionService collection)
        {
            _collection = collection;
        }

      

        [HttpGet]
        [Route("/Admin/Collection/{search?}")]
        public IActionResult Index(string search = "", int page = 1)
        {
            var model = _collection.GetCollections(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Collection/Create")]
        public IActionResult Create()
        {
            States();
            Users();
            Sports();
            return View();
        }

        [HttpPost]
        [Route("/Admin/Collection/Create")]
        public IActionResult Create(CreateCollectionViewModel model)
        {
            var sportList = model.Sports;
          
            if (ModelState.IsValid&& sportList!=null)
            {

              
                var admin = _collection.AdminCollection(Convert.ToInt32(model.UserId)).Result;
                if (admin)
                {
                    ModelState.AddModelError("StateId", "استان را انتخاب کنید");
                    City(Convert.ToInt32(model.StateId));
                    States();
                    Users();
                    Sports();
                    ViewBag.Error = "این کاربر را نمیتوان به عنوان مدیر مجموعه انتخاب کرد";
                    return View(model);
                }

                var state = Convert.ToInt32(model.StateId);
                var city = Convert.ToInt32(model.CityId);
                var check = _collection.CheckCollection(model.CollectionName, state, city).Result;
                if (check)
                {
                    ModelState.AddModelError("StateId", "استان را انتخاب کنید");
                    City(Convert.ToInt32(model.StateId));
                    States();
                    Users();
                    Sports();
                    ViewBag.Error = "این مجموعه قبلا ثبت شده";
                    return View(model);
                }
                else
                {
                    _collection.Create(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                if (model.StateId != "0")
                {
                    City(Convert.ToInt32(model.StateId));
                }
                ViewBag.Error = "رشته ورزشی انتخاب کنید";
                ModelState.AddModelError("StateId", "استان را انتخاب کنید");
                States();
                Users();
                Sports();
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Collection/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            States();
            Users();
            Sports();
            Selected(id);
            var model = _collection.GetCollectionById(id).Result;
            City(Convert.ToInt32(model.StateId));
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Collection/Edit/{id}")]
        public IActionResult Edit(EditCollectionViewModel model)
        {
            var sportList = model.Sports;
            if (ModelState.IsValid&&sportList!=null)
            {
                if (model.UserOld != Convert.ToInt32(model.UserId))
                {
                    var admin = _collection.AdminCollection(Convert.ToInt32(model.UserId)).Result;
                    if (admin)
                    {
                        ModelState.AddModelError("StateId", "استان را انتخاب کنید");
                        City(Convert.ToInt32(model.StateId));
                        States();
                        Users();
                        Sports();
                        ViewBag.Error = "این کاربر را نمیتوان به عنوان مدیر مجموعه انتخاب کرد";
                        return View(model);
                    }
                }

                _collection.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                States();
                Users();
                Sports();
                Selected(model.CollectionId);
                City(Convert.ToInt32(model.StateId));
                return View(model);
            }
        }

        public void States()
        {
            var list = _collection.GetStateItems().Result;
            ViewBag.State = new SelectList(list, "StateId", "StateName");
        }

        public void Sports()
        {
            ViewBag.Sports = _collection.GetSportItem().Result;
        }

        public void City(int id)
        {
            var list = _collection.GetCityItems(id).Result;

            ViewBag.city = new SelectList(list, "CityId", "CityName");
        }

        public void Users()
        {
            var list = _collection.GetUserItems().Result;
            ViewBag.User = new SelectList(list, "UserId", "UserName");
        }

        public void Selected(int id)
        {
            ViewBag.select = _collection.SelectedSport(id).Result;
        }

        [HttpGet]
        [Route("/Admin/collection/CityList/{id}")]
        public JsonResult GetCity(int id)
        {
            var list = _collection.GetCityItems(id).Result;
            var result = new SelectList(list, "CityId", "CityName");
            return Json(result);
        }

        [HttpGet]
        [Route("/Admin/Collection/Trash/{search?}")]
        public IActionResult Trash(string search = "", int page = 1)
        {
            var model = _collection.GetTrashCollections(search??"", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Collection/Remove/{id}")]
        public void Remove(int id)
        {
            _collection.Remove(id);
        }

        [HttpGet]
        [Route("/Admin/Collection/Back/{id}")]
        public void Back(int id)
        {
            _collection.Back(id);
        }

        [HttpGet]
        [Route("/Admin/Collection/Delete/{id}")]
        public bool Delete(int id)
        {
            var model=_collection.Delete(id);
            if (model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        [HttpGet]
        [Route("/Admin/Collection/Financial/{id}")]
        public IActionResult Financial(int id)
        {
            var model = _collection.GetFinancial(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Collection/Financial/{id}")]
        public IActionResult Financial(FinancialViewModel model)
        {
            _collection.EditFinancial(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/Admin/Collection/Banner/{id}")]
        public IActionResult Banner(int id)
        {
            var model = _collection.GetImages(id).Result;
            ViewBag.id = id;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Collection/AddBanner/{id}")]
        public IActionResult AddBanner(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        [Route("/Admin/Collection/AddBanner/{id}")]
        public IActionResult AddBanner(AddImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _collection.AddImage(model);
                return Redirect($"/Admin/Collection/Banner/{@model.CollectionId}");
            }
            else
            {
                ViewBag.id = model.CollectionId;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Collection/RemoveImage/{id}")]
        public void RemoveImage(int id)
        {
            _collection.RemoveImage(id);
        }
    }


}
