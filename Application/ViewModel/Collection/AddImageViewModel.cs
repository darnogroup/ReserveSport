using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Collection
{
   public class AddImageViewModel
    {
        [Required(ErrorMessage = "تصویر را انتخاب کنید")]
        public IFormFile Image { set; get; }

        public int CollectionId
        {
            set; get;

        }
    }
}
