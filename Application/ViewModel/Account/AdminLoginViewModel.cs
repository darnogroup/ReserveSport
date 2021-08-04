using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Account
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "کد ملی خود را وارد کنید")]
        public string Code { set; get; }
        [Required(ErrorMessage = "شماره موبایل خود را وارد کنید")]
        public string Number { set; get; }
    }
}
