using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ReserveSport.Helper
{
    public class Access:Attribute,IAuthorizationFilter
    {
        private  IAccountService _account;
        private readonly int _access;
        public Access(int roleAccess)
        {
            _access = roleAccess;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _account = (IAccountService)context.HttpContext.RequestServices.GetService(typeof(IAccountService));
            if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = Convert.ToInt32(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = _account.GetAccess(user).Result;
                if (result.RoleId != _access)
                {
                    context.Result = new RedirectResult("/");
                }
            }
            else
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}
