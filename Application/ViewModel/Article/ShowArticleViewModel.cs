using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Article
{
    public class ShowArticleViewModel
    {
        public string ArticleTitle { set; get; }
        public string ArticleTags { set; get; }
        public string ArticleImage { set; get; }
        public string ArticleBody { set; get; }
        public string CreateTime { set; get; }
    }
}
