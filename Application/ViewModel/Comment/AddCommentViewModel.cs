using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Comment
{
    public class AddCommentViewModel
    {
        public int UserId { set; get; }
        public string CommentBody { set; get; }
        public int ArticleId { set; get; }
    }
}
