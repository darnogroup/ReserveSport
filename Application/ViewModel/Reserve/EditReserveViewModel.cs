using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Reserve
{
    public class EditReserveViewModel
    {
        [Required(ErrorMessage = "ساعت شروع سانس را وارد کنید")]
        public string StartTime { set; get; }
        [Required(ErrorMessage = "ساعت اتمام سانس را وارد کنید")]
        public string EndTime { set; get; }
        public int Id { set; get; }
        public string DayTime { set; get; }
        [Required(ErrorMessage = "هزینه سانس را وارد کنید")]
        public string Price { set; get; }
        public int CollectionId { set; get; }


    }
}
