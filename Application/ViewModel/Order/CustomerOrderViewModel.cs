using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class CustomerOrderViewModel
    {
        public string CreateDate { get; set; }
        public bool IsFinally { get; set; }
        public string OrderCode { set; get; }
    }
}
