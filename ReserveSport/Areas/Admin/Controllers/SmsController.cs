using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Sms;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SmsController : Controller
    {
        private readonly ISmsService _sms;

        public SmsController(ISmsService sms)
        {
            _sms = sms;
        }
        [HttpGet][Route("/Admin/Sms/Collection")]
        public IActionResult Admin()
        {
            var model = _sms.GetSmsAdmin(1).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sms/Collection")]
        public IActionResult Admin(SmsAdminViewModel model)
        {
            _sms.SmsAdmin(model);
            return RedirectToAction(nameof(Admin));
        }
        [HttpGet]
        [Route("/Admin/Sms/Customer")]
        public IActionResult Customer()
        {
            var model = _sms.GetSmsCustomer(1).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sms/Customer")]
        public IActionResult Customer(SmsCustomerViewModel model)
        {
            _sms.SmsCustomer(model);
            return RedirectToAction(nameof(Customer));
        }
        [HttpGet]
        [Route("/Admin/Sms/General")]
        public IActionResult General()
        {
            var model = _sms.GetSmsGeneral(1).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sms/General")]
        public IActionResult General(SmsGeneralViewModel model)
        {
            _sms.SmsGeneral(model);
            return RedirectToAction(nameof(General));
        }
        [HttpGet]
        [Route("/Admin/Sms/Thank")]
        public IActionResult Thank()
        {
            var model = _sms.GetSmsThank(1).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sms/Thank")]
        public IActionResult Thank(SmsThankViewModel model)
        {
            _sms.SmsThank(model);
            return RedirectToAction(nameof(Thank));
        }
        [HttpGet]
        [Route("/Admin/Sms/Remember")]
        public IActionResult Remember()
        {
            var model = _sms.GetSmsRemember(1).Result;
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Sms/Remember")]
        public IActionResult Remember(SmsRememberViewModel model)
        {
            _sms.SmsRemember(model);
            return RedirectToAction(nameof(Remember));
        }
    }
}
