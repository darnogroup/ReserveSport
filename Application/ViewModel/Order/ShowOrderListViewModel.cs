using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Order
{
    public class ShowOrderListViewModel
    {
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public string DayTime { set; get; }
        public string Price { set; get; }
        public string Code { set; get; }
        public string CollectionName { set; get; }
        public string CollectionNumber { set; get; }
        public string CollectionAddress { set; get; }
    }
}
