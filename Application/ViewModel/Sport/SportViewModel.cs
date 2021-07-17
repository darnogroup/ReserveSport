using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Sport
{
    public class SportViewModel
    {
        public int SportId { get; set; }
        public string SportName { set; get; }
        public bool IsReserved { get; set; }
    }
}
