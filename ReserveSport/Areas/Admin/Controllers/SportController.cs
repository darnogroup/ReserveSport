using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Sport;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SportController : Controller
    {
        private readonly ISportService _sport;

        public SportController(ISportService sport)
        {
            _sport = sport;
        }
        [HttpGet]
        [Route("/Admin/Sport/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
            var model = _sport.GetSports(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Sport/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Sport/Create")]
        public IActionResult Create(CreateSportViewModel model)
        {
            if (ModelState.IsValid)
            {
                _sport.Add(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
           
        }

        [HttpGet]
        [Route("/Admin/Sport/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _sport.GetSportById(id).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sport/Edit/{id}")]
        public IActionResult Edit(EditSportViewModel model)
        {
            if (ModelState.IsValid)
            {
                _sport.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Sport/Remove/{id}")]
        public void Remove(int id)
        {
            _sport.Remove(id);
        }

        [HttpGet]
        [Route("/Admin/Sport/trash/{search?}")]
        public IActionResult TrashSport(string search = "", int page = 1)
        {
            var model = _sport.GetTrashSports(search ?? "", page);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Sport/Back/{id}")]
        public void Back(int id)
        {
            _sport.Back(id);
        }
        [HttpGet]
        [Route("/Admin/Sport/Delete/{id}")]
        public void Delete(int id)
        {
            _sport.Delete(id);
        }
    }
}
