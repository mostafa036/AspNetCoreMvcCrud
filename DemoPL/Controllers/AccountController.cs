using DemoDAL.Entities;
using DemoPL.Helpers;
using DemoPL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace DemoPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree
                };

                var result = await _userManager.CreateAsync(user , model.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach(var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    bool flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user , model.Password, model.RememberMe,false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Password Is Not Existed");

                }
                ModelState.AddModelError(string.Empty, "Email Is Not Existed");
            }
            return View(model);
        }

        #endregion

        #region Sign Out

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion

        #region Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var reserPasswordLink = Url.Action("ResetPasswprd" , "Account" , new {Email = model.Email , Token = token} , Request.Scheme);

                    var email = new Email()
                    {
                        Subject = "Reset Your Password",
                        To = model.Email,
                        Body = reserPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourEmail));
                }
                ModelState.AddModelError(string.Empty, "Email Is Not Existed");
            }

            return View(model);
        }

        public IActionResult CheckYourEmail()
        {
            return View();
        }
        #endregion

        #region Reset Password
        
        public IActionResult ResetPaswword(string Email , string Token)
        {
            TempData["Email"] = Email;
            TempData["Token"] = Token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPaswword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string Email = TempData["Email"] as string;
                string Token = TempData["Token"] as string;

                var user = await _userManager.FindByEmailAsync(Email);

                var result = await _userManager.ResetPasswordAsync(user, Token, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        #endregion
    }
}
