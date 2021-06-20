using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SmsThankModel
    {
        [Key]
        public int Id { set; get; }
        public string NameText { set; get; }
        public string ThankText { set; get; }
        public string DescriptionText { set; get; }
        public string SiteLink { set; get; }
    }
}
