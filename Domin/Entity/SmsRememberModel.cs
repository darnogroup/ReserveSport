using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SmsRememberModel
    {
        [Key]
        public int Id { set; get; }
        public string NameText { set; get; }
        public string CollectionText { set; get; }
        public string DayText { set; get; }
        public string SiteText { set; get; }
        public string SiteLink { set; get; }
        public string Description { set; get; }
        public string StartText { set; get; }
    }
}
