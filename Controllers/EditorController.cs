using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Controllers {
    [Authorize(Roles = "Editor,Admin")]
    public class EditorController : Controller {
        public ViewResult AddArticle() {
            return View();
        }
    }
}
