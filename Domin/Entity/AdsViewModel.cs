using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class AdsViewModel
    {
        [Key] public int BannerId { get; set; }

        [Display(Name = "نام بنر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = ("{0} نمیتواند بیشتر از {1} باشد"))]
        public string BannerName { get; set; }

        [Display(Name = "تصویر بنر")] public string BannerImage { get; set; }
        public string BannerLink { set; get; }
    }
}