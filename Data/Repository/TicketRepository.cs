using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TicketRepository:ITicketInterface
    {
        private readonly DataBaseContext _context;

        public TicketRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TicketModel>> GetAllTicket()
        {
            return await _context.Ticket.Include(i=>i.User).ToListAsync();
        }

        public async Task<IEnumerable<TicketModel>> GetUserTickets(int id)
        {
            return await _context.Ticket.Where(w=>w.UserId==id).ToListAsync();
        }

        public async Task<IEnumerable<SubTicketModel>> GetSubTicket(int id)
        {
            return await _context.SubTicket.Where(w => w.TicketId == id).Include(i=>i.User).ToListAsync();
        }

        public void Create(TicketModel model)
        {
            _context.Ticket.Add(model);Save();
        }

        public void CreateSub(SubTicketModel model)
        {
            _context.SubTicket.Add(model);Save();
        }

        public void Update(TicketModel model)
        {
            _context.Update(model);Save();
        }

        public async Task<TicketModel> GetById(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
