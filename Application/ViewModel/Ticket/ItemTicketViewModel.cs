using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Ticket
{
    public class ItemTicketViewModel
    {
        public int TicketId { set; get; }
        public string TicketTitle { set; get; }
        public string TicketDate { set; get; }
        public string TicketStatus { set; get; }
        public bool Close { set; get; }
    }
}
