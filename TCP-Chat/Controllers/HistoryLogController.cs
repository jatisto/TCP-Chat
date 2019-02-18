using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

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
        public IActionResult Index (string date, string name, int page = 1) {

            int pageSize = 15;
            var userId = _context.Users.FirstOrDefault (u => u.UserName == name);

            if (name != null && date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                IQueryable<HistoryLog> sourceNameData = _context.HistoryLogs.Where (a => a.UserFromId == userId.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true || a.Status == false)
                    .Include (x => x.UserFrom)
                    .Include (x => x.UserTo);
                var countNameData = sourceNameData.Count ();
                var itemsNameData = sourceNameData.Skip ((page - 1) * pageSize).Take (pageSize).ToList ();

                PageViewModel pageViewModelNameData = new PageViewModel (countNameData, page, pageSize);
                HistoryLogVM viewModelNameData = new HistoryLogVM {
                    PageViewModel = pageViewModelNameData,
                    HistoryLogs = itemsNameData
                };

                return View (viewModelNameData);

            } else if (date != null) {
                DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                IQueryable<HistoryLog> sourceData = _context.HistoryLogs
                    .Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true || a.Status == false)
                    .Include (x => x.UserFrom)
                    .Include (x => x.UserTo);
                var countData = sourceData.Count ();
                var itemsData = sourceData.Skip ((page - 1) * pageSize).Take (pageSize).ToList ();

                PageViewModel pageViewModelData = new PageViewModel (countData, page, pageSize);
                HistoryLogVM viewModelData = new HistoryLogVM {
                    PageViewModel = pageViewModelData,
                    HistoryLogs = itemsData
                };
                return View (viewModelData);

            } else if (name != null) {
                IQueryable<HistoryLog> sourceName = _context.HistoryLogs
                    .Where (a => a.UserFromId == userId.Id && a.Status == true || a.Status == false)
                    .Include (x => x.UserFrom)
                    .Include (x => x.UserTo);
                var countName = sourceName.Count ();
                var itemsName = sourceName.Skip ((page - 1) * pageSize).Take (pageSize).ToList ();

                PageViewModel pageViewModelName = new PageViewModel (countName, page, pageSize);
                HistoryLogVM viewModelName = new HistoryLogVM {
                    PageViewModel = pageViewModelName,
                    HistoryLogs = itemsName
                };

                return View (viewModelName);
            }

            IQueryable<HistoryLog> source = _context.HistoryLogs.Where (a => a.Status == true || a.Status == false)
                .Include (x => x.UserFrom)
                .Include (x => x.UserTo);
            var count = source.Count ();
            var items = source.Skip ((page - 1) * pageSize).Take (pageSize).ToList ();

            PageViewModel pageViewModel = new PageViewModel (count, page, pageSize);
            HistoryLogVM viewModel = new HistoryLogVM {
                PageViewModel = pageViewModel,
                HistoryLogs = items
            };

            var HisLog = _context.HistoryLogs
                .Include (a => a.UserFrom)
                .Include (a => a.UserTo)
                .Where (a => a.Status == true || a.Status == false).ToList ();

            return View (viewModel);
        }

    }
}