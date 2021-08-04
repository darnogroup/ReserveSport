using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class BannerVC:ViewComponent
    {
        private readonly ISettingService _setting;

        public BannerVC(ISettingService setting)
        {
            _setting = setting;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Component/BannerView.cshtml", _setting.GetAds().Result);
        }
    }
}
