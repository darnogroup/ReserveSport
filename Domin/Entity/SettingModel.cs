using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SettingModel
    {
        [Key]
        public int Id { set; get; }
        public string WhatsApp { set; get; }
        public string YouTube { set; get; }
        public string Telegram { set; get; }
        public string Instagram { set; get; }
        public string About { set; get; }
        public string ZarinPal { set; get; }
        public string Salary { set; get; }
        public string SmsNumberSender { set; get; }
        public string SmsApiCode { set; get; }
        public string Namad { set; get; }
    }
}
