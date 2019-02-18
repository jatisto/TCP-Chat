using System;
using System.Collections.Generic;
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

        public IActionResult Index (string date, string name, string status) {
            string st = status;
            if (st == "Chat") {
                return View (Chat (date, name));
            } else if (st == "GroupChat") {
                return View (GroupChat (date, name));
            }
            return View (ChatAll ());
        }

        public List<HistoryLog> Chat (string date, string name) {

            var userId = _context.Users.FirstOrDefault (u => u.UserName == name);

            //Log Поиск если заданы  и имя и дата

            if (name != null && date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true).ToList ();
                return HisLogName;
            } else if (date != null) { //Log Поиск если задано только имя
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var HisLogDate = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true).ToList ();
                return HisLogDate;

            } else if (name != null) { //Log Поиск если задано только дата
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Status == true).ToList ();
                return HisLogName;
            }
            //Log Вывод сообщений от всех пользователей

            var HisLog = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Status == true).ToList ();

            return HisLog;
        }

        public List<HistoryLog> GroupChat (string date, string name) {

            var userId = _context.Users.FirstOrDefault (u => u.UserName == name);

            //Log Поиск если заданы  и имя и дата

            if (name != null && date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == false).ToList ();
                return HisLogName;
            } else if (date != null) { //Log Поиск если задано только имя
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var HisLogDate = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == false).ToList ();
                return HisLogDate;

            } else if (name != null) { //Log Поиск если задано только дата
                var HisLogName = _context.HistoryLogs
                    .Include (a => a.UserFrom)
                    .Include (a => a.UserTo)
                    .Where (a => a.UserFromId == userId.Id && a.Status == false).ToList ();
                return HisLogName;
            }
            //Log Вывод сообщений от всех пользователей

            var HisLog = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Status == false).ToList ();

            return HisLog;
        }

        public List<HistoryLog> ChatAll () {

            var HisLog = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Status == true || a.Status == false).ToList ();

            return HisLog;
        }

    }
}