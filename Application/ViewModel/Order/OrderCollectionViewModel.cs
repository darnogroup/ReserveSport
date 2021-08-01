using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class OrderCollectionViewModel
    {
        public int Id { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public string DayTime { set; get; }
        public string Price { set; get; }
        public string Code { set; get; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderCode { set; get; }
        public string OrderDate { get; set; }
    }
}
