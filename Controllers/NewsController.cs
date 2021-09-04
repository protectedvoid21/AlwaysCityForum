using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    public class NewsController : Controller {
        private readonly NewsDbContext newsDbContext;
        private readonly IWebHostEnvironment hostingEnvironment;

        public NewsController(NewsDbContext newsDbContext, IWebHostEnvironment hostingEnvironment) {
            this.newsDbContext = newsDbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult News() {
            IEnumerable<ArticleNews> newsArticles = newsDbContext.NewsArticles;
            return View(newsArticles);
        }

        [Authorize(Roles = "Editor,Admin")]
        [HttpGet]
        public ViewResult AddNews() {
            return View();
        }

        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNews(ArticleNewsViewModel articleModel) {
            if(!ModelState.IsValid) {
                return View();
            }

            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + articleModel.Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await articleModel.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));

            ArticleNews articleNews = new ArticleNews {
                Title = articleModel.Title,
                Author = User.Identity.Name,
                ContentText = articleModel.ContentText,
                PublicationDate = DateTime.Now,
                ImagePath = uniqueFileName,
            };
            await newsDbContext.NewsArticles.AddAsync(articleNews);
            await newsDbContext.SaveChangesAsync();

            ViewBag.Message = "The article was successfully added";
            return RedirectToAction("News");
        }

        public ViewResult Article(string id) {
            ArticleNews article = newsDbContext.NewsArticles.First(n => n.Id.ToString() == id);
            return View(article);
        }
    }
}
