using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class OrderViewModel
    {
        public int OrderId { set; get; }
        public string OrderCode { set; get; }
        public int OrderPrice { get; set; }
        public bool IsFinally { get; set; }
        public string WalletMoney { get; set; }
        public int UserId { get; set; }
        public int DetailsCount { get; set; }
    }
}