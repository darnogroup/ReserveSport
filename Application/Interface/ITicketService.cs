using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Ticket;

namespace Application.Interface
{
    public interface ITicketService
    {
        Task<List<ItemTicketViewModel>> GetTickets(int id);

        Tuple<List<TicketItemViewModel>, int, int> GetAllTickets(string search = "", int page = 1);
        Task<List<ItemSubTicketViewModel>> GetSubTicket(int id);
        Task<List<FileTicketViewModel>> GetFiles(int id);
        void Create(TicketViewModel model);
        void CreateSub(SubTicketViewModel model);
        void Close(int id);
    }
}
