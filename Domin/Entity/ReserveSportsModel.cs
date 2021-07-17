using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ReserveSportsModel
    {
        [Key]
        public int ReserveSportsId { get; set; }
        public int ReserveId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public bool IsReserved { get; set; }
        public bool IsFinished { get; set; } 
        [ForeignKey("ReserveId")]
        public ReserveModel Reserve { get; set; }
    }
}