using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Demo1.Controllers
{
    public class NewsController : Controller
    {
        INewsFacade newsFacade;
        ICategoryFacade categoryFacade;
        public NewsController(INewsFacade newsFacade, ICategoryFacade categoryFacade)
        {
            this.newsFacade = newsFacade;
            this.categoryFacade = categoryFacade;
        }
        public IActionResult Index()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                ViewBag.Data = newsFacade.GetAll();
                return View();
            }
        }
        public IActionResult CreateNews()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNews(News model)
        {
            if (ModelState.IsValid)
            {
                News news = new News
                {
                    Title = model.Title,
                    CategoryId = model.CategoryId,
                    Text = model.Text,
                    Summery = model.Summery,
                    PubDate = model.PubDate,
                };
                newsFacade.CreateNews(news);
            }
            return RedirectToAction("Index", "News");
        }
        //private string UploadedFile(News news)
        //{
        //    string uniqueFileName = null;

        //    if (news.Images != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + news.Images.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            news.Images.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
        public IActionResult CreateCategory()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            categoryFacade.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                newsFacade.Delete(id);
                return RedirectToAction("index");
            }
        }
    }
}
