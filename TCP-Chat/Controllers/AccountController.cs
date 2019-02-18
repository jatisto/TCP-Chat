using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

namespace TCP_Chat.Controllers {

    public class AccountController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController (UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
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

                if (result.Succeeded) {
                    if (string.IsNullOrEmpty (loginVM.ReturnUrl))
                        return RedirectToAction ("Index", "Home");
                    return Redirect (loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError ("", "Логин или Пароль введены не верно");
            return View (loginVM);
        }

        public IActionResult Register () {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (LoginVM loginVM) {

            if (ModelState.IsValid) {
                var user = new User () { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync (user, loginVM.Password);

                if (result.Succeeded) {
                    return RedirectToAction ("Index", "Home");
                }
            }
            return View (loginVM);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout () {
            await _signInManager.SignOutAsync ();
            return RedirectToAction ("Index", "Home");
        }

<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
    }
}