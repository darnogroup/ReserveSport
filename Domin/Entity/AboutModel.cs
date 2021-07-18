using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class AboutModel
    {
        [Key]
        public int AboutId { set; get; }

        public string AboutImage { set; get; }
        public string AboutBody { set; get; }
        public string AboutSlogan { set; get; }
    }
}
