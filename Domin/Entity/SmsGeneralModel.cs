using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SmsGeneralModel
    {
        [Key]
        public int Id { set; get; }
        public string ActiveText { set; get; }
        public string TemporaryText { set; get; }
        public string ActiveCollection { set; get; }
        public string AnswerText { set; get; }
        
    }
}
