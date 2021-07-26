using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Article
{
    public class ArticleViewModel
    {
        public int ArticleId { set; get; }
    
        public string ArticleTitle { set; get; }
        public string ArticleImage { set; get; }
        public string ArticleTime { set; get; }
    }
}
