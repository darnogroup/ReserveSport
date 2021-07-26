using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ICommentInterface
    {
        Task<IEnumerable<CommentModel>> GetCommentsById(int id);
        Task<IEnumerable<CommentModel>> GetComments();
        Task<CommentModel> GetCommentById(int id);
        void Create(CommentModel model);
        void Update(CommentModel model);
        void Remove(CommentModel model);
    }
}
