using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TicketModel
    {
        [Key]
        public int TicketId { set; get; }
        [Required(ErrorMessage = "عنوان تیکت الزامی است")]
        [MaxLength(200,ErrorMessage = "طول عنوان تیکت زیاد است")]
        public string TicketTitle { set; get; }
        [Required]
        public DateTime TicketDate { set; get; }
        public int UserId { set; get; }
        [ForeignKey("UserId")]
        public UserModel User { set; get; }
        [Required]
        public string TicketStatus { set; get; }
        public bool Close { set; get; }
        public IEnumerable<SubTicketModel>SubTicket { set; get; }
    }
}
