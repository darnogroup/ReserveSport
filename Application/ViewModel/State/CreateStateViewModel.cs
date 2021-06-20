using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.State
{
    public class CreateStateViewModel
    {
       
        [Required(ErrorMessage = "نام استان الزامی است")]
        [MaxLength(100, ErrorMessage = "طول نام استان از حد مجاز بیشتر است")]
        public string StateName { set; get; }
      
    }
}
