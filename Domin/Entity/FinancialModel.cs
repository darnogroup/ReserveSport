using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class FinancialModel
    {
        [Key]
        public int FinancialId { set; get; }
        public string FinancialPrice { set; get; }
        public string FinancialSheba { set; get; }
        public string FinancialNumber { set; get; }
        public string FinancialCard { set; get; }
        public int CollectionId { set; get; }
        [ForeignKey("CollectionId")]
        public CollectionModel Collection { set; get; }
    }
}
