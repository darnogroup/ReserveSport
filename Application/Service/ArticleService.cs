using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Article;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class ArticleService:IArticleService
    {
        private readonly IArticleInterface _article;

        public ArticleService(IArticleInterface article)
        {
            _article = article;
        }
        public Tuple<List<ArticleViewModel>, int, int> GetArticles(string search = "", int page = 1)
        {
            var result = _article.GetArticles().Result;
            List<ArticleViewModel> models = new List<ArticleViewModel>();
            var article = result.Where(w => w.ArticleTitle.Contains(search))
                .OrderByDescending(o=>o.ArticleId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(article.Count, 10);
            int skip = (page - 1) * 10;
            var articleList = article.Skip(skip).Take(10).ToList();
            foreach (var item in articleList)
            {
                models.Add(new ArticleViewModel()
                {
                    ArticleTitle = item.ArticleTitle,
                    ArticleId = item.ArticleId,
                    ArticleImage = item.ArticleImage,
                    ArticleTime = item.CreateTime.ToShamsi()
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<ArticleViewModel>, int, int> GetTrashArticles(string search = "", int page = 1)
        {
            var result = _article.GetTrashArticles().Result;
            List<ArticleViewModel> models = new List<ArticleViewModel>();
            var article = result.Where(w => w.ArticleTitle.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(article.Count, 10);
            int skip = (page - 1) * 10;
            var articleList = article.Skip(skip).Take(10).ToList();
            foreach (var item in articleList)
            {
                models.Add(new ArticleViewModel()
                {
                    ArticleTitle = item.ArticleTitle,
                    ArticleId = item.ArticleId,
                    ArticleImage = item.ArticleImage,
                    ArticleTime = item.CreateTime.ToShamsi()
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditArticleViewModel> GetArticleById(int id)
        {
            var article = await _article.GetArticleById(id);
            EditArticleViewModel edit=new EditArticleViewModel();
            edit.ArticleTitle = article.ArticleTitle;
            edit.ImagePath = article.ArticleImage;
            edit.ArticleBody = article.ArticleBody;
            edit.ArticleSummary = article.ArticleSummary;
            edit.Id = article.ArticleId;
            return edit;
        }

        public void CreateArticle(CreateArticleViewModel model)
        {
            ArticleModel article=new ArticleModel();
            article.ArticleTitle = model.ArticleTitle;
            article.ArticleBody = model.ArticleBody;
            article.ArticleSummary = model.ArticleSummary;
            article.CreateTime=DateTime.Now;
            article.ArticleTags = model.ArticleTags;
            var check = model.ArticleImage.IsImage();
            if (check)
            {
                article.ArticleImage = Image.SaveImage(model.ArticleImage);
            }
            else
            {
                article.ArticleImage = "noImage.jpg";
            }
            _article.Create(article);
        }

        public void EditArticle(EditArticleViewModel model)
        {
            var article = _article.GetArticleById(model.Id).Result;
            article.ArticleTitle = model.ArticleTitle;
            article.ArticleTags = model.ArticleTags;
            article.ArticleBody = model.ArticleBody;
            article.ArticleSummary = model.ArticleSummary;
            if (model.ArticleImage != null)
            {
                var check = model.ArticleImage.IsImage();
                if (check)
                {
                    article.ArticleImage = Image.SaveImage(model.ArticleImage);
                    Image.RemoveImage(model.ImagePath);
                }
            }
            _article.Edit(article);
        }

        public void DeleteArticle(int id)
        {
            var model = _article.GetDeletedArticleById(id).Result;
            Image.RemoveImage(model.ArticleImage);
            _article.Delete(model);
        }

        public void RemoveArticle(int id)
        {
            var model = _article.GetArticleById(id).Result;
            model.IsDelete = true;
            _article.Edit(model);
        }

        public void BackArticle(int id)
        {
            var model = _article.GetDeletedArticleById(id).Result;
            model.IsDelete = false;
            _article.Edit(model);
        }
    }
}
