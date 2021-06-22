using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class ReserveVC:ViewComponent
    {
        private readonly IHomeService _home;

        public ReserveVC(IHomeService home)
        {
            _home = home;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View("/Views/Shared/Component/ItemReserveView.cshtml",await _home.GetReserveById(id));
        }
    }
}
