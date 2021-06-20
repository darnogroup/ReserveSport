using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SmsAdminModel
    {
        [Key]
        public int Id { set; get; }
        public string NameText { set; get; }
        public string SportText { set; get; }
        public string StartText { set; get; }
        public string EndText { set; get; }
        public string DayText { set; get; }
        public string PriceText { set; get; }
        public string CodeText { set; get; }
        public string SiteText { set; get; }
        public string SiteLink { set; get; }
    }
}
