using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
        public string Number { set; get; }
        [Required(ErrorMessage = "رمز موقت را وارد کنید")]
        public string Password { set; get; }
    }
}
