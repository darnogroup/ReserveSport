using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Request
{
    public class InfoRequestViewModel
    {
        public string CollectionName { set; get; }
        public string CollectionPhoneNumber { set; get; }
        public string CollectionAddress { set; get; }
        public string State { set; get; }
        public string City { set; get; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
    }
}
