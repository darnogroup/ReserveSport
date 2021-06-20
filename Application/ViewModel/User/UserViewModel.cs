using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Application.ViewModel.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string RegisterDate { get; set; }
        public string UserImage { get; set; }
        public bool IsActive { get; set; }
    }
}
