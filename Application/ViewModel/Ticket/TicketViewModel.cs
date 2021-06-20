using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Ticket
{
    public class TicketViewModel
    {
        [Required(ErrorMessage = "عنوان تیکت الزامی است")]
        [MaxLength(200, ErrorMessage = "طول عنوان تیکت زیاد است")]
        public string TicketTitle { set; get; }
        public int UserId { set; get; }
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string SubText { set; get; }
        public IFormFile File { set; get; }
    }
}
