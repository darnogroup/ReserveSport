using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Areas.Admin.Component
{
    public class UserVC:ViewComponent
    {
        private readonly IUserService _user;

        public UserVC(IUserService user)
        {
            _user = user;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = _user.GetLastUsers().Result;
            return View("/Areas/Admin/Views/Shared/Component/User.cshtml", users);
        }
        
    }
}
