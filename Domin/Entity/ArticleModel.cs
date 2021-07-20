using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ArticleModel
    {
        [Key]
        public int ArticleId { set; get; }

        [Required(ErrorMessage = "عنوان مقاله الزامی است")]
        [MaxLength(100, ErrorMessage = "عنوان مطلب از حد مجاز بیشتر است")]
        public string ArticleTitle { set; get; }

        [Required(ErrorMessage = "خلاصه مقاله الزامی است")]
        [MaxLength(300,ErrorMessage = "طول خلاصه مطلب از حد مجاز بیشتر است")]
        public string ArticleSummary { set; get; }
        [Required]
        public string ArticleImage { set; get; }
        [Required(ErrorMessage = "متن مقاله الزامی است")]
        public string ArticleBody { set; get; }
        public string ArticleTags { set; get; }
        [Required]
        public DateTime CreateTime { set; get; }

        public bool IsDelete { set; get; } = false;
        public IEnumerable<CommentModel>Comments { set; get; }
    }
}
