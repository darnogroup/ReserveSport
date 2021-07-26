using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.Article;
using Application.ViewModel.Comment;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class CommentService:ICommentService
    {
        private readonly ICommentInterface _comment;

        public CommentService(ICommentInterface comment)
        {
            _comment = comment;
        }
        public Tuple<List<CommentViewModel>, int, int> GetComments(int page = 1)
        {
            var result = _comment.GetComments()
                .Result;            List<CommentViewModel> models = new List<CommentViewModel>();
            var commentList = result.ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(commentList.Count, 10);
            int skip = (page - 1) * 10;
            var comment = commentList.Skip(skip).Take(10).ToList();
            foreach (var item in comment)
            {
               models.Add(new CommentViewModel()
               {
                   ArticleTitle = item.Article.ArticleTitle,
                   CommentId = item.CommentId,
                   IsShow = item.IsShow,
                   UserName = item.User.UserName
               });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<List<ShowCommentViewModel>> GetCommentsById(int id)
        {
            var list = await _comment.GetCommentsById(id);
            List<ShowCommentViewModel>show=new List<ShowCommentViewModel>();
            var result = list.OrderByDescending(s => s.CreateTime).Take(8).ToList();
            foreach (var item in result)
            {
                show.Add(new ShowCommentViewModel()
                {
                    CommentText = item.CommentBody,
                    UserImage = item.User.UserImage,
                    UserName = item.User.UserName
                });
            }

            return show;
        }

        public void Create(AddCommentViewModel model)
        {
           CommentModel comment=new CommentModel();
           comment.CreateTime=DateTime.Now;
           comment.UserId = model.UserId;
           comment.ArticleId = model.ArticleId;
           comment.IsShow = false;
           comment.CommentBody = model.CommentBody;
           _comment.Create(comment);
        }

        public void Update(int id)
        {
            var model = _comment.GetCommentById(id).Result;
            model.IsShow = !model.IsShow;
            _comment.Update(model);
        }
    }
}
