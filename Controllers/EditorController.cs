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
    [Authorize(Roles = "Editor,Admin")]
    public class EditorController : Controller {
        private readonly NewsDbContext newsDbContext;
        private readonly IWebHostEnvironment hostingEnvironment;

        public EditorController(NewsDbContext newsDbContext, IWebHostEnvironment hostingEnvironment) {
            this.newsDbContext = newsDbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ViewResult AddNews() {
            return View();
        }

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
            await newsDbContext.AddAsync(articleNews);

            ViewBag.Message = "The article was successfully added";
            return RedirectToAction("News", "Home");
        }
    }
}
