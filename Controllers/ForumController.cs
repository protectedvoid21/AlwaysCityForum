using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    public class ForumController : Controller {
        private readonly ForumDbContext forumDbContext;

        public ForumController(ForumDbContext forumDbContext) {
            this.forumDbContext = forumDbContext;
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
    }
}
