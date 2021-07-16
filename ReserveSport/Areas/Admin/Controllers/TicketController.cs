using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Ticket;
using Data.Migrations;
using ReserveSport.Helper;
using ClaimsPrincipalExtensions = ReserveSport.Other.ClaimsPrincipalExtensions;

namespace ReserveSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Access(1)]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticket;

        public TicketController(ITicketService ticket)
        {
            _ticket = ticket;
        }
        [HttpGet]
        [Route("/Admin/Ticket/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
            var model = _ticket.GetAllTickets(search, page);
            ViewBag.Search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Ticket/Show/{id}")]
        public IActionResult Show(int id ,bool close)
        {
            ViewBag.Id = id;
            ViewBag.Close = close;
            ViewBag.User = UserName();
            var model = _ticket.GetSubTicket(id).Result;
            return View(model);
        }
        [HttpGet]
        [Route("/Admin/Ticket/Answer/{id}")]
        public IActionResult AnswerTicket(int id)
        {
            ViewBag.Id = id;
            ViewBag.UserId = Convert.ToInt32(ClaimsPrincipalExtensions.GetUserId(User));
            return View();
        }
        [HttpPost]
        [Route("/Admin/Ticket/Answer/{id}")]
        public IActionResult AnswerTicket(SubTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticket.CreateSub(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Id = model.TicketId;
                ViewBag.UserId = model.UserId;
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/Ticket/FileTicket/{id}")]
        public IActionResult FileTicket(int id)
        {
            var model = _ticket.GetFiles(id).Result;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Ticket/Close/{id}")]
        public void Close(int id)
        {
            _ticket.Close(id);
        }
        public string UserName()
        {
            return ClaimsPrincipalExtensions.GetUserName(User);
        }
    }
}
