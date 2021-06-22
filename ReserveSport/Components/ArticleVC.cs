using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class ArticleVC:ViewComponent
    {
        private readonly IHomeService _home;

        public ArticleVC(IHomeService home)
        {
            _home = home;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Component/ItemArticleView.cshtml", _home.GetArticles().Result);
        }
    }
}
