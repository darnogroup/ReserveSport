using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ReserveModel
    {
        [Key]
        public int ReserveId { set; get; }
        [Required(ErrorMessage = "ساعت شروع سانس را وارد کنید")]
        public string StartTime { set; get; }
        [Required(ErrorMessage = "ساعت اتمام سانس را وارد کنید")]
        public string EndTime { set; get; }
        [Required(ErrorMessage = "تاریخ روز سانس را وارد کنید")]
        public DateTime DayTime { set; get; }
        [Required(ErrorMessage = "هزینه سانس را وارد کنید")]
        public string Price { set; get; }
        public int CollectionId { set; get; }
        [ForeignKey("CollectionId")]
        public CollectionModel Collection { set; get; }
        public bool Reserved { set; get; }
        public string Code { set; get; }
        public bool Finish { set; get; }
        public IEnumerable<OrderDetailModel> OrderDetailModels { get; set; }

    }
}
