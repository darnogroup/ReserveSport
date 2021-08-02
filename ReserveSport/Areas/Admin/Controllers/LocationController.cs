using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.City;
using Application.ViewModel.State;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class LocationController : Controller
    {
        private readonly IStateService _state;
        private readonly ICityService _city;

        public LocationController(IStateService state, ICityService city)
        {
            _state = state;
            _city = city;
        }
     
        #region State


        [HttpGet][Route("/Admin/State/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
         
            
            var  model = _state.GetStateList(search??"", page);
            
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/State/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/State/Create")]
        public IActionResult Create(CreateStateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _state.Create(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/State/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _state.GetStateById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/State/Edit/{id}")]
        public IActionResult Edit(EditStateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _state.Update(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/State/Delete/{id}")]
        public void Delete(int id)
        {
            _state.Delete(id);
        }
        [HttpGet]
        [Route("/Admin/Trash/State/{search?}")]
        public IActionResult Trash(string search = "", int page = 1)
        {
            var model = _state.GetStateTrashList(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/State/Back/{id}")]
        public void Back(int id)
        {
            _state.Back(id);
        }
        [HttpGet]
        [Route("/Admin/State/Remove/{id}")]
        public bool Remove(int id)
        {
             var item=_state.Remove(id);
             if (item)
             {
                 return true;
             }
             else
             {
                 return false;
             }
        }

        #endregion

        #region City

        [HttpGet]
        [Route("/Admin/City/{stateId}/{search?}")]
        public IActionResult Cities(string search , int stateId , int page = 1)
        {
            var model = _city.GetCityList(search ?? "", stateId, page);
            ViewBag.search = search;
            ViewBag.Id = stateId;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/City/Create/{id}")]
        public IActionResult CreateCity(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        [Route("/Admin/City/Create/{id}")]
        public IActionResult CreateCity(CreateCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                _city.Create(model);
                return Redirect($"/Admin/city/{model.StateId}");
            }
            else
            {
                ViewBag.Id = model.StateId;
                return View(model);
            }
           
        }

        [HttpGet]
        [Route("/Admin/City/Edit/{id}")]
        public IActionResult EditCity(int id)
        {
            var model = _city.GetCityById(id).Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/City/Edit/{id}")]
        public IActionResult EditCity(EditCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                _city.Update(model);
                return Redirect($"/Admin/city/{model.StateId}");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/City/Delete/{id}")]
        public void DeleteCity(int id)
        {
            _city.Delete(id);
        }

        [HttpGet]
        [Route("/Admin/City/Trash/{stateId}/{search?}")]
        public IActionResult TrashCity(string search, int stateId, int page = 1)
        {
            var model = _city.GetCityTrashList(search ?? "", stateId, page);
            ViewBag.search = search;
            ViewBag.Id = stateId;
            return View(model);
        }
        [HttpGet]
        [Route("/Admin/City/Back/{id}")]
        public void BackCity(int id)
        {
            _city.Back(id);
        }
        [HttpGet]
        [Route("/Admin/City/Remove/{id}")]
        public bool RemoveCity(int id)
        {
           var result= _city.Remove(id);
           if (result)
           {
               return true;
           }
           else
           {
               return false;
           }
        }

        #endregion
    }
}
