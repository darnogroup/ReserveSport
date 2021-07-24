using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Comment;

namespace Application.Interface
{
    public interface ICommentService
    {
        Tuple<List<CommentViewModel>, int, int> GetComments(int page = 1);
        Task<List<ShowCommentViewModel>> GetCommentsById(int id);
        void Create(AddCommentViewModel model);
        void Update(int id);
    }
}
