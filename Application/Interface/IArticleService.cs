using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Article;

namespace Application.Interface
{
    public interface IArticleService
    {
        Tuple<List<ArticleViewModel>, int, int> GetArticles(string search = "", int page = 1);
        Tuple<List<ArticleViewModel>, int, int> GetTrashArticles(string search = "", int page = 1);
        Task<EditArticleViewModel> GetArticleById(int id);
        void CreateArticle(CreateArticleViewModel model);
        void EditArticle(EditArticleViewModel model);
        void DeleteArticle(int id);
        void RemoveArticle(int id);
        void BackArticle(int id);
    }
}
