using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Article
{
    public class CreateArticleViewModel
    {

        [Required(ErrorMessage = "عنوان مقاله الزامی است")]
        [MaxLength(100, ErrorMessage = "عنوان مطلب از حد مجاز بیشتر است")]
        public string ArticleTitle { set; get; }
        public string ArticleTags { set; get; }
        [Required(ErrorMessage = "خلاصه مقاله الزامی است")]
        [MaxLength(300, ErrorMessage = "طول خلاصه مطلب از حد مجاز بیشتر است")]
        public string ArticleSummary { set; get; }
        [Required(ErrorMessage = "تصویر مقاله الزامی است")]
        public IFormFile ArticleImage { set; get; }
        [Required(ErrorMessage = "متن مقاله الزامی است")]
        public string ArticleBody { set; get; }
     
    }
}
