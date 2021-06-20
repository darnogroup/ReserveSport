using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Ticket
{
    public class SubTicketViewModel
    {
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string SubText { set; get; }
        public IFormFile File { set; get; }
        public int TicketId { set; get; }
        public int UserId { set; get; }
    }
}
