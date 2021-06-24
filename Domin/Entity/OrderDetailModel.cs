using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class OrderDetailModel
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public int Price { get; set; }
        public bool Close { set; get; } = false;
        public int CollectionId { set; get; }
        // Relations
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderModel Order { get; set; }
        public int ReserveId { get; set; }
        [ForeignKey("ReserveId")]
        public ReserveModel ReserveModel { get; set; }
    }
}