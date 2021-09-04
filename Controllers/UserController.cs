using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    public class UserController : Controller {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager) {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> UserProfile() {
            return View();
        }
    }
}
