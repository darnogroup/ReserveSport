using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Request
{
    public class RequestViewModel
    {
        public int CollectionId { set; get; }
        public string CollectionName { set; get; }
        public string CollectionPhoneNumber { set; get; }
        public string State { set; get; }
        public string City { set; get; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
    }
}
