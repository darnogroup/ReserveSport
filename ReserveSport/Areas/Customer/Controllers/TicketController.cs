using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Ticket;
using ReserveSport.Other;

namespace ReserveSport.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticket;

        public TicketController(ITicketService ticket)
        {
            _ticket = ticket;
        }
        [HttpGet]
        [Route("/Profile/Ticket")]
        public IActionResult Ticket()
        {
            var model = _ticket.GetTickets(UserId()).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Profile/AddTicket")]
        public IActionResult AddTicket()
        {
            ViewBag.Id = UserId();
            return View();
        }
        [HttpPost]
        [Route("/Profile/AddTicket")]
        public IActionResult AddTicket(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticket.Create(model);
                return RedirectToAction(nameof(Ticket));
            }
            else
            {
                ViewBag.Id =model.UserId;
                return View(model);
            }
           
        }

        [HttpGet]
        [Route("/Profile/Tickets/{id}")]
        public IActionResult Tickets(int id,bool close)
        {
            ViewBag.close = close;
            var model = _ticket.GetSubTicket(id).Result;
            ViewBag.Name = User.GetUserName();
            ViewBag.Id = id;
            return View(model);
        }

        [HttpGet]
        [Route("/Profile/Answer/{id}")]
        public IActionResult Answer(int id)
        {
            ViewBag.Id = id;
            ViewBag.UserId = UserId();
            return View();
        }

        [HttpPost]
        [Route("/Profile/Answer/{id}")]
        public IActionResult Answer(SubTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticket.CreateSub(model);
                return RedirectToAction(nameof(Ticket));
            }
            else
            {
                ViewBag.Id = model.TicketId;
                ViewBag.UserId = UserId();
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Profile/File/{id}")]
        public IActionResult File(int id)
        {
            var model = _ticket.GetFiles(id).Result;
            return View(model);
        }
        public int UserId()
        {
            int user = Convert.ToInt32(User.GetUserId());
            return user;
        }
    }
}
