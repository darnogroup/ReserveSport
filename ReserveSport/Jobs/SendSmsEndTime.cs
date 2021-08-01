using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Other;
using Application.ViewModel.Sms;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace ReserveSport.Jobs
{
    public class SendSmsEndTime:IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<DataBaseContext>();
            option.UseSqlServer("Server=.;Database=Reservation;Trusted_Connection=True;");
            using (DataBaseContext _ctx = new DataBaseContext(option.Options))
            {
                var reserveItem = _ctx.OrderDetailModels
                    .Where(w => w.Close == true).Include(r => r.Order).ThenInclude(h => h.User)
                    .Include(i => i.ReserveModel).ThenInclude(t=>t.Collection)
                    .Where(w =>
                        w.ReserveModel.DayTime.Year + w.ReserveModel.DayTime.Month +
                        w.ReserveModel.DayTime.Day ==
                        DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day - 1).ToList();
                var package = _ctx.SmsThank.Find(1);
                var setting = _ctx.Setting.Find(1);
                Sender sender = new Sender();
                sender.Number = setting.SmsNumberSender;
                sender.Api = setting.SmsApiCode;
                foreach (var item in reserveItem)
                {
                    YesterdaySmsViewModel yesterday = new YesterdaySmsViewModel();
                    yesterday.UserNumber = item.Order.User.PhoneNumber;
                    yesterday.Name = item.Order.User.UserName;
                    yesterday.Place = item.ReserveModel.Collection.CollectionName;
                    var check = SmsSender.YesterdaySms(yesterday,sender,package);
                }
            }
            return Task.CompletedTask;
        }
    }
}
