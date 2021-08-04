using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class SettingVC:ViewComponent
    {
        private readonly ISettingService _setting;

        public SettingVC(ISettingService setting)
        {
            _setting = setting;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Component/SettingView.cshtml",_setting.GetFooter().Result);
        }
    }
}
