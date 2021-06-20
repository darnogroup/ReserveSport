using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface IArticleInterface
    {
        Task<IEnumerable<ArticleModel>> GetTrashArticles();
        Task<ArticleModel> GetDeletedArticleById(int id);
        Task<IEnumerable<ArticleModel>> GetArticles();
        Task<ArticleModel> GetArticleById(int id);
        void Create(ArticleModel model);
        void Edit(ArticleModel model);
        void Delete(ArticleModel model);
    }
}
