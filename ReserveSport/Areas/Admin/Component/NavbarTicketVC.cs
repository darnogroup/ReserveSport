using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Areas.Admin.Component
{
    public class NavbarTicketVC:ViewComponent
    {
        private readonly ITicketService _ticket;

        public NavbarTicketVC(ITicketService ticket)
        {
            _ticket = ticket;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Areas/Admin/Views/Shared/Component/TicketNavbar.cshtml",_ticket.GetNavbarItem());
        }
    }
}
