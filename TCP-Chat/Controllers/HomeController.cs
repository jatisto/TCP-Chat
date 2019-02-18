﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index () {
            if (_signInManager.IsSignedIn (User)) {
                return RedirectToAction ("Chat2", "Home");
            }
            return View ();
        }

        public IActionResult Privacy () {

            return View ();
        }

        public IActionResult Chat () {
            var user = _userManager.GetUserName (User);
            var userId = _userManager.GetUserId (User);
            if (user != null) {

                ViewData["User"] = user.ToString ();
                ViewData["UserId"] = userId.ToString ();
            }
            ViewData["UserAll"] = new SelectList (_context.Users.Where (a => a.Id != userId), "Id", "UserName");

            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Chat2 () {

            return View ();
        }

        public IActionResult ChatGroup () {

            return View ();
        }

        [HttpGet]
        public string ListUsersConnection () {

            List<string> listUserConnected = new List<string> ();
            var result = _context.Connections.Where (a => a.Connected == true);
            foreach (var item in result) {
                listUserConnected.Add (item.Name);
            }
            return JsonConvert.SerializeObject (listUserConnected);
        }

    }
}