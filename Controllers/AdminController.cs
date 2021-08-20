using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public ViewResult Panel() {
            ViewBag.userCount = userManager.Users.Count();
            ViewBag.roleCount = roleManager.Roles.Count();
            return View();
        }

        public ViewResult UserList() {
            IEnumerable<AppUser> userList = userManager.Users;
            return View(userList);
        }

        public ViewResult RoleList() {
            IEnumerable<AppRole> roleList = roleManager.Roles;
            return View(roleList);
        }

        [HttpGet]
        public async Task<ViewResult> EditUser(string id) {
            AppUser user = await userManager.FindByIdAsync(id);

            EditUserViewModel userViewModel = new EditUserViewModel {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
                RoleList = new List<EditUserViewModel.RoleListViewModel>(),
            };

            AppRole[] roleList = roleManager.Roles.ToArray();
            foreach(var role in roleList) {
                var roleListModel = new EditUserViewModel.RoleListViewModel {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    IsSelected = await userManager.IsInRoleAsync(user, role.Name),
                };
                userViewModel.RoleList.Add(roleListModel);
            }

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel userViewModel) {
            if(!ModelState.IsValid) {
                return View();
            }
            AppUser user = await userManager.FindByIdAsync(userViewModel.Id);
            if(user == null) {
                return View();
            }

            user.UserName = userViewModel.UserName;
            user.Email = userViewModel.Email;

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if(!result.Succeeded) {
                ModelState.AddModelError("", "Can't remove existing roles");
                return View();
            }

            result = await userManager.AddToRolesAsync(user, userViewModel.RoleList.Where(r => r.IsSelected == true).Select(r => r.Name));
            if(!result.Succeeded) {
                ModelState.AddModelError("", "Can't add user to role");
                return View();
            }

            return RedirectToAction("UserList");
        }
    }
}
