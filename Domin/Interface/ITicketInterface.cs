using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ITicketInterface
    {
        Task<IEnumerable<TicketModel>> GetAllTicket();
        Task<IEnumerable<TicketModel>> GetUserTickets(int id);
        Task<IEnumerable<SubTicketModel>> GetSubTicket(int id);
        void Create(TicketModel model);
        void CreateSub(SubTicketModel model);
        void Update(TicketModel model);
        Task<TicketModel> GetById(int id);
    }
}
