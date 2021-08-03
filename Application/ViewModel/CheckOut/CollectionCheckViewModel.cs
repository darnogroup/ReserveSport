using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.CheckOut
{
    public class CollectionCheckViewModel
    {
        public int CheckoutId { set; get; }
        public bool CheckoutClose { set; get; }
        public string CheckoutPrice { set; get; }
        public string DateTime { set; get; }
        public string CheckoutCode { set; get; }
    }
}
