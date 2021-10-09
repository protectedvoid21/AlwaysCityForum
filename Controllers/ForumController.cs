using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    public class ForumController : Controller {
        private readonly ForumDbContext forumDbContext;
        private readonly UserManager<AppUser> userManager;

        public ForumController(ForumDbContext forumDbContext, UserManager<AppUser> userManager) {
            this.forumDbContext = forumDbContext;
            this.userManager = userManager;
        }

        public IActionResult Index() {
            IEnumerable<ForumSection> sections = forumDbContext.Sections;
            return View(sections);
        }

        [Authorize(Roles = "Admin, Editor")]
        [HttpGet]
        public ViewResult AddSection() {
            return View();
        }

        [Authorize(Roles ="Admin, Editor")]
        [HttpPost]
        public async Task<IActionResult> AddSection(ForumSection section) {
            if(!ModelState.IsValid) {
                return View();
            }

            await forumDbContext.Sections.AddAsync(section);
            await forumDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Forum");
        }

        [Route("{controller}/{action=Section}/{name:slugify}")]
        public IActionResult Section(int id) {
            IEnumerable<ForumPost> posts = forumDbContext.Posts.Where(t => t.ForumSectionId == id);
            ViewBag.sectionId = id;
            return View(posts);
        }

        [HttpGet]
        public ViewResult AddPost(int id) {
            ViewBag.CurrentSection = id;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddPost(ForumPost post) {
            if(!ModelState.IsValid) {
                return View();
            }
            post.Id = 0;

            post.PublicationDate = DateTime.Now;

            await forumDbContext.Posts.AddAsync(post);
            await forumDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Forum");
        }

        [Route("{controller}/{action=Section}/{name:slugify}")]
        public async Task<IActionResult> Post(int id) {

        }
    }
}
