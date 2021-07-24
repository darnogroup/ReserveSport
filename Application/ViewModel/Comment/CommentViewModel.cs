using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Comment
{
    public class CommentViewModel
    {
        public int CommentId { set; get; }
        public string ArticleTitle { set; get; }
        public string UserName { set; get; }
        public string CommentBody { set; get; }
        public bool IsShow { set; get; }
    }
}
