using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Account
{
    public class ClaimViewModel
    {
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string UserImage { set; get; }
        public string PhoneNumber { set; get; }
        public string NationalCode { set; get; }
    }
}
