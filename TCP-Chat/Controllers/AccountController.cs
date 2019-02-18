using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Newtonsoft.Json;
using TCP_Chat.Date;
using TCP_Chat.Hubs;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace TCP_Chat.Controllers {

    public class AccountController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public AccountController (UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context) {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login (string returnUrl) {
            return View (new LoginVM () {
                ReturnUrl = returnUrl
            });
        }

        // Метод для проверки Логина пользователя
        [HttpPost]
        public async Task<IActionResult> Login (LoginVM loginVM) {

            if (!ModelState.IsValid) {
                return View (loginVM);
            }

            var user = await _userManager.FindByNameAsync (loginVM.UserName);

            if (user != null) {
                var result = await _signInManager.PasswordSignInAsync (user, loginVM.Password, false, false);

                if (result.Succeeded) {
                    TokenUser(loginVM, loginVM.UserName, loginVM.Password);
                    if (string.IsNullOrEmpty (loginVM.ReturnUrl))
                        return RedirectToAction ("Index", "Home");
                    return Redirect (loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError ("", "Логин или Пароль введены не верно");
            return View (loginVM);
        }

        // Метод для Регистрации пользователя
        public IActionResult Register () {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (LoginVM loginVM, string role) {

            if (ModelState.IsValid) {
                var user = new User () { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync (user, loginVM.Password);

                if (result.Succeeded) {

                    if (role == null) {
                        role = "User";
                    }

                    await _userManager.AddToRoleAsync (user, role.ToUpper ());

                    return RedirectToAction ("Index", "Home");
                }
            }

            return View (loginVM);
        }

        // Метод для Выхода пользователя 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout () {
            await _signInManager.SignOutAsync ();
            return RedirectToAction ("Index", "Home");
        }

        // Метод для создания ролей
        public async Task<IActionResult> CreateRole (string role, string id) {
            var user = await _userManager.FindByIdAsync (id);

            List<string> allRoles = new List<string> () {
                "Admin",
                "Manager",
                "User"
            };
            await _userManager.RemoveFromRolesAsync (user, allRoles);
            await _userManager.AddToRoleAsync (user, role);
            await _context.SaveChangesAsync ();
            return RedirectToAction ("Index", "Home");
        }
        // Метод для создания Токена
        [HttpPost ("/token")]
        public async Task Token () {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            LoginVM loginVM = new LoginVM ();
            var identity = GetIdentity (loginVM, username, password);
            if (identity == null) {
                Response.StatusCode = 400;
                await Response.WriteAsync ("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken (
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add (TimeSpan.FromMinutes (AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials (AuthOptions.GetSymmetricSecurityKey (), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler ().WriteToken (jwt);

            var response = new {
                access_token = encodedJwt,
                username = identity.Name
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync (JsonConvert.SerializeObject (response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        // Метод для проверки пользьзователя для входа в личный чат
        private ClaimsIdentity GetIdentity (LoginVM loginVM, string username, string password) {

            User user = _context.Users.FirstOrDefault (x => x.UserName == username);

            if (_userManager.PasswordHasher.VerifyHashedPassword (user, user.PasswordHash, password) != PasswordVerificationResult.Failed) {

                var claims = new List<Claim> {
                new Claim (ClaimsIdentity.DefaultNameClaimType, user.UserName),
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity (claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        public ClaimsIdentity TokenUser (LoginVM loginVM, string user, string password) {

            User userLogin = _context.Users.FirstOrDefault (x => x.UserName == user);

            if (_userManager.PasswordHasher.VerifyHashedPassword (userLogin, userLogin.PasswordHash, password) != PasswordVerificationResult.Failed) {

                var claims = new List<Claim> {
                new Claim (ClaimsIdentity.DefaultNameClaimType, userLogin.UserName),
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity (claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

    }
}