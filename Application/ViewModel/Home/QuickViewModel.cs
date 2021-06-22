using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class QuickViewModel
    {
        [Required(ErrorMessage = "لطفا یک گزینه انتخاب کنید")]
        public string State { set; get; }
        [Required(ErrorMessage = "لطفا یک گزینه انتخاب کنید")]
        public string City { set; get; }
        [Required(ErrorMessage = "لطفا یک گزینه انتخاب کنید")]
        public string Collection { set; get; }
        [Required(ErrorMessage = "لطفا یک گزینه انتخاب کنید")]
        public string Sport { set; get; }
        [Required(ErrorMessage = "لطفا یک گزینه انتخاب کنید")]
        public string Reserve { set; get; }
    }
}
