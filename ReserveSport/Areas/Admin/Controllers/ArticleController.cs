using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Article;
using ReserveSport.Helper;

namespace ReserveSport.Areas.Admin.Controllers
{[Area("Admin")]
    [Access(1)]
    public class ArticleController : Controller
    {
        private readonly IArticleService _article;
        private readonly ICommentService _comment;

        public ArticleController(IArticleService article, ICommentService comment)
        {
            _article = article;
            _comment = comment;
        }
      
        [HttpGet]
        [Route("/Admin/Article/{search?}")]
        public IActionResult Index(string search="",int page=1)
        {
            var model = _article.GetArticles(search, page);
            ViewBag.Search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Article/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/Article/Create")]
        public IActionResult Create(CreateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {

                _article.CreateArticle(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Article/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _article.GetArticleById(id).Result;
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/Article/Edit/{id}")]
        public IActionResult Edit(EditArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _article.EditArticle(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Article/Delete/{id}")]
        public void Delete(int id)
        {
            _article.DeleteArticle(id);
        }
        [HttpGet]
        [Route("/Admin/Article/Remove/{id}")]
        public void Remove(int id)
        {
            _article.RemoveArticle(id);
        }
        [HttpGet]
        [Route("/Admin/Article/Back/{id}")]
        public void Back(int id)
        {
            _article.BackArticle(id);
        }
        [HttpGet]
        [Route("/Admin/Article/Trash/{search?}")]
        public IActionResult Trash(string search = "", int page = 1)
        {
            var model = _article.GetTrashArticles(search, page);
            ViewBag.Search = search;
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Comments")]
        public IActionResult Comments(int id)
        {
            var model = _comment.GetComments(id);
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/ChangeComment/{id}")]
        public void Change(int id)
        {
            _comment.Update(id);
        }
    }
}
