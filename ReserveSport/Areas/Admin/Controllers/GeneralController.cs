using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
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
    }
}
