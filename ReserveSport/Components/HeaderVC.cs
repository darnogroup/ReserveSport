using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class HeaderVC:ViewComponent
    {
        private readonly ISettingService _setting;

        public HeaderVC(ISettingService setting)
        {
            _setting = setting;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Component/HeaderVC.cshtml", _setting.GetHeader().Result);
        }
    }
}
