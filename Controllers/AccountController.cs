using Microsoft.AspNetCore.Authorization;
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
            if(await userManager.IsEmailConfirmedAsync(userByEmail) == false) {
                return RedirectToAction("SendToken", "Account", new { userByEmail.Email });
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

            if(await SendConfirmationLink(user)) {
                return RedirectToAction("SendToken", "Account", new { user.Email });
            }
            else {
                ViewBag.Message = "Email confirmation failed";
                return View("Error");
            }
        }

        public async Task<bool> SendConfirmationLink(AppUser user) {
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmationLink = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);
            bool emailResponse = await TokenHelper.SendEmail(user.Email, confirmationLink);
            return emailResponse;
        }

        public async Task<IActionResult> SendToken(string email) {
            Console.WriteLine($"Email passed to SendToken : {email}");
            if(email == null) {
                ViewBag.Message = "Couldn't send new token.";
                return View("Error");
            }

            AppUser userByEmail = await userManager.FindByEmailAsync(email);
            if(await SendConfirmationLink(userByEmail)) {
                ViewBag.Message = "Email has been sent. Check your email to confirm your account. If you can't find the message check spam folder or click resend button";
                return View("SendToken", email);
            }
            else {
                ViewBag.Message = "Email confirmation failed";
                return View("Error");
            }
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email) {
            AppUser user = await userManager.FindByEmailAsync(email);
            if(user == null) {
                ViewBag.Message = "User with this email was not found";
                return View("Error");
            }
            IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
            if(!result.Succeeded) {
                ViewBag.Message = "Email confirmation failed";
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> UserPanel() {
            AppUser user = await userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpGet, Authorize]
        public ViewResult ChangeEmail() {
            return View();
        }

        [HttpPost, Authorize] // TO BE CONTINUED
        public async Task<IActionResult> ChangeEmail(string email) {
            AppUser user = await userManager.GetUserAsync(User);
            return RedirectToAction("UserPanel");
        }

        [HttpGet, Authorize]
        public ViewResult ChangePassword() {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> ChangePassword(EditPasswordViewModel passwordModel) {
            if(!ModelState.IsValid) {
                return View();
            }

            AppUser user = await userManager.GetUserAsync(User);
            if(user == null) {
                ViewBag.Message = "User has logged off";
                return RedirectToAction("Error");
            }

            IdentityResult result = await userManager.ChangePasswordAsync(user, passwordModel.CurrentPassword, passwordModel.NewPassword);
            if(!result.Succeeded) {
                foreach(var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }

            ViewBag.Message = "Password has been correctly changed";
            return RedirectToAction("UserPanel");
        }
    }    
}
