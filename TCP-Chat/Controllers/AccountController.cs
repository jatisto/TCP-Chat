using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

namespace TCP_Chat.Controllers {
    public class AccountController : Controller {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login (string returnUrl) {
            return View (new LoginVM () {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginVM loginVM) {
            if (!ModelState.IsValid) {
                return View (loginVM);
            }

            var user = await _userManager.FindByNameAsync (loginVM.UserName);

            if (user != null) {
                var result = await _signInManager.PasswordSignInAsync (user, loginVM.Password, false, false);

                if (result.Succeeded) 
                {
                    if (string.IsNullOrEmpty (loginVM.ReturnUrl))
                        return RedirectToAction ("Index", "Home");                    
                    return Redirect (loginVM.ReturnUrl);
                }                
            }
            ModelState.AddModelError("", "Логин или Пароль введены не верно");
            return View(loginVM);
        }

    }
}