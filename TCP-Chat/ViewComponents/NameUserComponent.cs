using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;

namespace TCP_Chat.ViewComponents {
    public class NameUserComponent : ViewComponent {
        #region Dependency Injection

        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public NameUserComponent (AppDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        #endregion

        public string Invoke () {

            var userIdUser = _userManager.GetUserId (Request.HttpContext.User);
            var userName = _userManager.GetUserName (Request.HttpContext.User);

            ViewData["UserId"] = userName;

            return userName.ToString();

        }

    }
}