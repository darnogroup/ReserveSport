using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class CheckoutModel
    {
        [Key]
        public int CheckoutId { set; get; }
        public bool CheckoutClose { set; get; }
        public string CheckoutPrice { set; get; }
        public DateTime DateTime { set; get; }
        public string CheckoutCode { set; get; }
        public int CollectionId { set; get; }
        [ForeignKey("CollectionId")]
        public CollectionModel Collection { set; get; }
    }
}
