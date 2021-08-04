using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Setting
{
    public class SettingViewModel
    {
        public string Salary { set; get; }
        public string WhatsApp { set; get; }
        public string YouTube { set; get; }
        public string Telegram { set; get; }
        public string Instagram { set; get; }
        public string About { set; get; }
        public string ZarinPal { set; get; }
        public string SmsNumberSender { set; get; }
        public string SmsApiCode { set; get; }
        public string Namad { set; get; }
        public IFormFile FileOne { set; get; }
        public IFormFile FileTwo { set; get; }
        public IFormFile FileThree { set; get; }
        public string ImageOne { set; get; }
        public string ImageTwo { set; get; }
        public string ImageThree { set; get; }
    }
}
