using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSport.Components
{
    public class CommentVC: ViewComponent
    {
        private readonly ICommentService _comment;

        public CommentVC(ICommentService comment)
        {
            _comment = comment;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View("/Views/Shared/Component/CommentsView.cshtml",_comment.GetCommentsById(id).Result);
        }
    }
}
