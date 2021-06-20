using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ArticleRepository: IArticleInterface
    {
        private readonly DataBaseContext _context;

        public ArticleRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleModel>> GetTrashArticles()
        {
            return await _context.Article.Where(w => w.IsDelete == true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<ArticleModel> GetDeletedArticleById(int id)
        {
            return await _context.Article.Where(w => w.IsDelete == true).IgnoreQueryFilters().SingleOrDefaultAsync(s=>s.ArticleId==id);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticles()
        {
            return await _context.Article.ToListAsync();
        }

        public async Task<ArticleModel> GetArticleById(int id)
        {
            return await _context.Article.FindAsync(id);
        }

        public void Create(ArticleModel model)
        {
            _context.Article.Add(model);Save();
        }

        public void Edit(ArticleModel model)
        {
            _context.Update(model);Save();
        }

        public void Delete(ArticleModel model)
        {
            _context.Article.Remove(model);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
