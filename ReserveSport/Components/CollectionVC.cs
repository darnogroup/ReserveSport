using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class CollectionVC:ViewComponent
    {
        private readonly IHomeService _home;

        public CollectionVC(IHomeService home)
        {
            _home = home;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Component/ItemCollectionView.cshtml", _home.GetCollections().Result);
        }
    }
}
