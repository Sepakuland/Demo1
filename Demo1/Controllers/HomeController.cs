using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        INewsFacade newsFacade;
        ICategoryFacade categoryFacade;
        ICommentFacade commentFacade;
        public HomeController(INewsFacade newsFacade, ICategoryFacade categoryFacade, ICommentFacade commentFacade)
        {
            this.newsFacade = newsFacade;
            this.categoryFacade = categoryFacade;
            this.commentFacade = commentFacade;
        }
        public IActionResult Index(int categoryId, string search)
        {
            IEnumerable<News> news = new List<News>();

            if (!string.IsNullOrEmpty(search))
            {
                news = newsFacade.HomeSearch(search);
            }
            else if (categoryId != 0)
            {
                news = newsFacade.FindByCategory(categoryId);
            }
            else
            {
                news = newsFacade.GetHotteseNews(5);
            }

            IEnumerable<Category> categories = categoryFacade.GetAll();

            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                CategoryViewModel vm = new CategoryViewModel();
                vm.CategoryId = item.CategoryId;
                vm.Title = item.Title;
                vm.NewsCount = item.News.Count;
                categoryViewModels.Add(vm);
            }

            NewsViewModel model = new NewsViewModel()
            {
                News = news,
                Categories = categoryViewModels

            };
            ViewBag.Data = categoryFacade.GetAll();
            return View(model);
        }
        public IActionResult Text(int id)
        {
            ViewBag.CommentData = commentFacade.GetComments().Where(c => c.NewsId == id);
            ViewBag.item = newsFacade.Text(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Text(Comment comment, News news, int id)
        {
            ViewBag.CommentData = commentFacade.GetComments().Where(c => c.NewsId == news.NewsId);
            ViewBag.item = newsFacade.Text(id);
            Comment newscomment = new Comment()
            {
                Name = comment.Name,
                Email = comment.Email,
                CommentText = comment.CommentText,
                NewsId = news.NewsId,
                PubTime = DateTime.Now,
            };
            commentFacade.AddComment(newscomment);
            return RedirectToAction("index");
        }
        public IActionResult DeleteComment(int id)
        {
            commentFacade.DeleteComment(id);
            return RedirectToAction("index");
        }
    }
}
