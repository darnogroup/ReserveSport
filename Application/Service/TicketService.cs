using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Ticket;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;

namespace Application.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketInterface _ticket;
        private readonly IUserInterface _user;

        public TicketService(ITicketInterface ticket, IUserInterface user)
        {
            _ticket = ticket;
            _user = user;
        }
        public async Task<List<ItemTicketViewModel>> GetTickets(int id)
        {
            var ticket = await _ticket.GetUserTickets(id);
            List<ItemTicketViewModel> items = new List<ItemTicketViewModel>();
            foreach (var item in ticket)
            {
                items.Add(new ItemTicketViewModel()
                {
                    Close = item.Close,
                    TicketDate = item.TicketDate.ToShamsi(),
                    TicketId = item.TicketId,
                    TicketStatus = item.TicketStatus,
                    TicketTitle = item.TicketTitle
                });
            }

            return items;
        }

        public Tuple<List<ItemNavbarTicketViewModel>, int> GetNavbarItem()
        {
            var resultAction = _ticket.GetAllTicket().Result;
            var list = resultAction.ToList();
            List<ItemNavbarTicketViewModel>items=new List<ItemNavbarTicketViewModel>();
            int count = list.Count(w => w.TicketDate.Date == DateTime.Now.Date);
            var result = list.Where(w => w.TicketDate.Date == DateTime.Now.Date).Take(8).ToList();
            foreach (var item in result)
            {
                items.Add(new ItemNavbarTicketViewModel()
                {
                    ImageProfile = item.User.UserImage,
                    Title = item.TicketTitle,
                    Time = item.TicketDate.ToShamsi(),
                    UserName = item.User.UserName,Id = item.TicketId
                });
            }

            return Tuple.Create(items, count);
        }

        public  Tuple<List<TicketItemViewModel>, int, int> GetAllTickets(string search = "", int page = 1)
        {
            var ticket =  _ticket.GetAllTicket().Result;
            List<TicketItemViewModel> items = new List<TicketItemViewModel>();
            var ticketList = ticket.Where(w => w.TicketTitle.Contains(search)).OrderByDescending(o => o.TicketId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(ticketList.Count, 10);
            int skip = (page - 1) * 10;
            var result = ticketList.Skip(skip).Take(10).ToList();
            foreach (var item in result)
            {
                items.Add(new TicketItemViewModel()
                {
                    Close = item.Close,
                    TicketDate = item.TicketDate.ToShamsi(),
                    TicketId = item.TicketId,
                    User = item.User.UserName,
                    TicketTitle = item.TicketTitle
                });
            }
            return Tuple.Create(items, pageCount, pageNumber);
       
        }

        public async Task<List<ItemSubTicketViewModel>> GetSubTicket(int id)
        {
            var ticket = await _ticket.GetSubTicket(id);
            var tickets = ticket.OrderByDescending(o=>o.Time).ToList();
            List<ItemSubTicketViewModel> items = new List<ItemSubTicketViewModel>();
            foreach (var item in tickets)
            {
                items.Add(new ItemSubTicketViewModel()
                {
                    SubText = item.SubText,
                    UserName = item.User.UserName,Time = item.Time.ToShamsi()
                });
            }

            return items;
        }

        public async Task<List<FileTicketViewModel>> GetFiles(int id)
        {
            var model = await _ticket.GetSubTicket(id);
            List<FileTicketViewModel> file = new List<FileTicketViewModel>();
            foreach (var item in model)
            {
                file.Add(new FileTicketViewModel()
                {
                    File = item.SubFilePath
                });
            }

            return file;
        }

        public void Create(TicketViewModel model)
        {
            TicketModel ticket = new TicketModel();
            ticket.UserId = model.UserId;
            ticket.Close = false;
            ticket.TicketDate = DateTime.Now;
            ticket.TicketTitle = model.TicketTitle;
            var role = _user.GetRole(model.UserId).Result;
            ticket.TicketStatus = "در انتظار پاسخ";
            _ticket.Create(ticket);
            SubTicketModel sub = new SubTicketModel();
            sub.UserId = model.UserId;
            sub.Time = DateTime.Now;
            sub.TicketId = ticket.TicketId;
            sub.SubText = model.SubText;
            if (model.File != null)
            {
                var check = model.File.IsImage();
                if (check)
                {
                    sub.SubFilePath = Image.SaveImage(model.File);
                }
            }
            _ticket.CreateSub(sub);
        }

        public void CreateSub(SubTicketViewModel model)
        {
            SubTicketModel sub = new SubTicketModel();
            sub.UserId = model.UserId;
            sub.Time = DateTime.Now;
            sub.TicketId = model.TicketId;
            sub.SubText = model.SubText;
            if (model.File != null)
            {
                var check = model.File.IsImage();
                if (check)
                {
                    sub.SubFilePath = Image.SaveImage(model.File);
                }
            }
            else
            {
                sub.SubFilePath = "noImage.jpg";
            }
            _ticket.CreateSub(sub);
            var ticket = _ticket.GetById(model.TicketId).Result;
            var role = _user.GetRole(model.UserId).Result;
            if (role == RoleEnum.مدیرمجموعه)
            {
                ticket.TicketStatus = "پاسخ پشتیبان";
            }
            else
            {
                ticket.TicketStatus = "در انتظار پاسخ";
            }
            _ticket.Update(ticket);
        }

        public void Close(int id)
        {
            var ticket = _ticket.GetById(id).Result;
            ticket.Close = true;
            _ticket.Update(ticket);
        }
    }
}
