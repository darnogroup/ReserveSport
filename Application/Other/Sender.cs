using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Sms;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Other
{
    public static class SenderInfo
    {
        public static Sender GetSenderInfo()
        {
            var option = new DbContextOptionsBuilder<DataBaseContext>();
            option.UseSqlServer("Server=.;Database=Reservation;Trusted_Connection=True;");
            using (DataBaseContext _ctx = new DataBaseContext(option.Options))
            {
                var setting = _ctx.Setting.Find(1);
                Sender sender = new Sender();
                sender.Number = setting.SmsNumberSender;
                sender.Api = setting.SmsApiCode;
                return sender;
            }
        }
    }
}
