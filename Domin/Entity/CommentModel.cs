using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class CommentModel
    {
        [Key]
        public int CommentId { set; get; }
        [Required]
        public DateTime CreateTime { set; get; }
        [Required(ErrorMessage = "متن دیدگاه را وارد کنید")]
        public string CommentBody { set; get; }
        public int ArticleId { set; get; }
        [ForeignKey("ArticleId")]
        public ArticleModel Article { set; get; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel User { set; get; }
        public bool IsShow { set; get; }
    }
}
