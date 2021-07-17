using Application.ViewModel.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class ItemReserveViewModel
    {
        public string StartTime { set; get; }
        public bool Reserve { set; get; }
        public bool Finish { set; get; }
        public string EndTime { set; get; }

        public string DayTime { set; get; }

        public int Price { set; get; }
        public int Id { set; get; }
        public List<SportViewModel> Sports { get; set; }
    }
}
