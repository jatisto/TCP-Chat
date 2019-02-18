using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TCP_Chat.Date;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

namespace TCP_Chat.Controllers {

    public class HomeController : Controller {

        #region Dependency Injection

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public HomeController (
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            AppDbContext context) {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        #endregion

        //Метод для редиректа пользователя на страницу чата, если он залогинен
        public IActionResult Index () {
            if (_signInManager.IsSignedIn (User)) {
                return RedirectToAction ("Chat2", "Home");
            }
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        //Метод который возвращает View чата
        public IActionResult Chat2 () {

            return View ();
        }

        [Authorize]
        //Метод который возвращает View групового чата
        public IActionResult ChatGroup () {

            return View ();
        }
    }
}