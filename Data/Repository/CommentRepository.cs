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
   public class CommentRepository:ICommentInterface
   {
       private readonly DataBaseContext _context;

       public CommentRepository(DataBaseContext context)
       {
           _context = context;
       }

       public async Task<IEnumerable<CommentModel>> GetCommentsById(int id)
       {
           return await _context.Comment.
               Where(w=>w.IsShow==true&&w.ArticleId==id).Include(i => i.User).Include(i => i.Article).ToListAsync();
       }

        public async Task<IEnumerable<CommentModel>> GetComments()
        {
            return await _context.Comment.Include(i=>i.User).Include(i=>i.Article).ToListAsync();
        }

        public async Task<CommentModel> GetCommentById(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public void Create(CommentModel model)
        {
            _context.Comment.Add(model);Save();
        }

        public void Update(CommentModel model)
        {
            _context.Update(model);Save();
        }

        public void Remove(CommentModel model)
        {
            _context.Comment.Remove(model); Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
