using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.General;
using Application.ViewModel.Setting;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{[Area("Admin")]
    [Access(1)]
    public class GeneralController : Controller
    {
        private readonly ISettingService _setting;

        public GeneralController(ISettingService setting)
        {
            _setting = setting;
        }
        [HttpGet][Route("/Admin/Setting")]
        public IActionResult Setting()
        {
            var model = _setting.GetSetting(1).Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/Setting")]
        public IActionResult Setting(SettingViewModel model)
        {
            _setting.Setting(model);
            return RedirectToAction(nameof(Setting));
        }
        [HttpGet]
        [Route("/Admin/Complaint/{search?}")]
        public IActionResult Complaint(string search = "", int page = 1)
        {
            ViewBag.search = search;
            var model = _setting.GetComplaints(search, page);
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/About")]
        public IActionResult About()
        {
            var model = _setting.GetAbout().Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/About")]
        public IActionResult About(AboutViewModel model)
        {
            _setting.Insert(model);
            return RedirectToAction(nameof(About));
        }

        [HttpGet]
        [Route("/Admin/Contact/{search?}")]
        public IActionResult Contact(string search = "", int page = 1)
        {
            var model = _setting.GetContact(search, page);
            ViewBag.search = search;
            return View(model);
        }
    }
}
