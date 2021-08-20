using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public ViewResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel) {
            if(!ModelState.IsValid) {
                return View();
            }

            AppUser userByEmail = await userManager.FindByEmailAsync(loginModel.Email);
            if(userByEmail == null) {
                ViewBag.Message = "Incorrect email or password";
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(userByEmail, loginModel.Password, false, false);
            if(!result.Succeeded) {
                ViewBag.Message = "Incorrect email or password";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel) {
            if(!ModelState.IsValid) {
                return View();
            }
            if(await userManager.FindByEmailAsync(registerModel.Email) != null) {
                ViewBag.Message = "User with this email already exists";
                return View();
            }

            AppUser user = new AppUser {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                PasswordHash = registerModel.Password
            };

            IdentityResult result = await userManager.CreateAsync(user, registerModel.Password);
            if(!result.Succeeded) {
                foreach(var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
