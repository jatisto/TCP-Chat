using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TCP_Chat.Models;

namespace TCP_Chat.Controllers {
    public class HomeController : Controller {

        #region Dependency Injection

        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController (SignInManager<IdentityUser> signInManager) {
            _signInManager = signInManager;
        }

        #endregion
        public IActionResult Index () {

            if (_signInManager.IsSignedIn (User)) {
                return RedirectToAction ("Chat", "Home");
            }
            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        public IActionResult Chat () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}