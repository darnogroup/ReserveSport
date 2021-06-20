using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SubTicketModel
    {
        [Key]
        public int SubId { set; get; }
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string SubText { set; get; }
        public string SubFilePath { set; get; }
      public DateTime Time { set; get; }
      public int UserId { set; get; }
      [ForeignKey("UserId")]
      public UserModel User { set; get; }
        public int TicketId { set; get; }
        [ForeignKey("TicketId")]
        public TicketModel Ticket { set; get; }
    }
}
