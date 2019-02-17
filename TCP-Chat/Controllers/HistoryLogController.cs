using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Models;

namespace TCP_Chat.Controllers {
    public class HistoryLogController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public HistoryLogController (UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context) {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index (string date, string name) {

            var userId = _context.Users.FirstOrDefault (u => u.UserName == name);

            if (name != null && date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true).ToList ();
                return View (HisLogName);
            }else if (date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var HisLogDate = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true).ToList ();
                return View (HisLogDate);
                
            }else if (name != null) {
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Status == true).ToList ();
                return View (HisLogName);
            }

            var HisLog = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Status == true).ToList ();

            return View (HisLog);
        }

        [HttpPost]
        public IActionResult FilterOnDate (string date) {

            DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var assetsNew = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true);

            return View (assetsNew.ToList ());
        }
    }
}