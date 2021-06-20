using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReserveSport.Other
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }
        public static string GetUserImage(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("UserImage");
        }
        public static string GetPhoneNumber(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("PhoneNumber");
        }
        public static string GetNationalCode(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("NationalCode");
        }
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("Email");
        }
        public static string GetRoleId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Role);
        }
    }
}
