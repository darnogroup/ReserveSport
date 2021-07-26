using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class OrdersViewModel
    {
        public int OrderId { get; set; }
        public bool IsFinish { set; get; }
            public string CreateDate { get; set; }
        public string OrderCode { set; get; }
        public string UserName { get; set; }
    }
}
