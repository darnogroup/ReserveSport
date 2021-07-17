using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class OrderItemViewModel
    {
        public int ReserveId { set; get; }
        public string TimeDay { set; get; }
        public string Start { set; get; }
        public string End { set; get; }
        public int Price { set; get; }
        public int Id { set; get; }
        public string ReserveName { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }

    }
}
