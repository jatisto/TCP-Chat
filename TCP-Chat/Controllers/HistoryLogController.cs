using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Models;
using TCP_Chat.ViewModels;

namespace TCP_Chat.Controllers {
    [Authorize]
    public class HistoryLogController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public HistoryLogController (UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context) {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index (string date, string namefrom, string nameto, int? history, int page = 1, SortState sortOrder = SortState.NameAsc) {

            int pageSize = 13;
            var userIdFrom = _context.Users.FirstOrDefault (u => u.UserName == namefrom);
            var userIdTo = _context.Users.FirstOrDefault (u => u.UserName == nameto);
            IQueryable<HistoryLog> source = _context.HistoryLogs.Where (a => a.Status == true || a.Status == false)
                .Include (x => x.UserFrom)
                .Include (x => x.UserTo);

            if (userIdFrom != null || userIdTo != null) { //Log Поиск если заданы  и имя и дата

                if (namefrom != null && date != null) {
                    DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    source = source.Where (a => a.UserFromId == userIdFrom.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true || a.Status == false);

                } else if (!String.IsNullOrEmpty (date)) {
                    DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    source = source.Where (a => a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true || a.Status == false);

                } else if (!String.IsNullOrEmpty (namefrom)) {

                    source = source.Where (a => a.UserFromId == userIdFrom.Id && a.Status == true || a.Status == false);
                } else if (!String.IsNullOrEmpty (nameto)) {

                    source = source.Where (a => a.UserToId == userIdTo.Id && a.Status == true || a.Status == false);
                } else if (nameto != null && date != null) {

                    DateTimeOffset dtFrom = DateTime.ParseExact (date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    source = source.Where (a => a.UserToId == userIdTo.Id && a.Date.Year == dtFrom.Year && a.Date.Day == dtFrom.Day && a.Date.Month == dtFrom.Month && a.Status == true || a.Status == false);
                } else
                    source = source.Where (a => a.Status == true || a.Status == false);

                // сортировка
                switch (sortOrder) {
                    case SortState.NameDesc:
                        source = source.OrderByDescending (s => s.UserFromId);
                        break;
                    case SortState.DateAsc:
                        source = source.OrderBy (s => s.Date.Date);
                        break;
                    case SortState.DateDesc:
                        source = source.OrderByDescending (s => s.Status);
                        break;
                    default:
                        source = source.OrderBy (s => s.UserFromId);
                        break;
                }

                // пагинация
                var count = await source.CountAsync ();
                var items = await source.Skip ((page - 1) * pageSize).Take (pageSize).ToListAsync ();

                PageViewModel pageViewModel = new PageViewModel (count, page, pageSize);
                HistoryLogVM viewModel = new HistoryLogVM {
                    PageViewModel = pageViewModel,
                    SortViewModel = new SortViewModel (sortOrder),
                    FilterViewModel = new FilterViewModel (_context.HistoryLogs.ToList (), date, namefrom, nameto),
                    HistoryLogs = items
                };

            }

            // сортировка
            switch (sortOrder) {
                case SortState.NameDesc:
                    source = source.OrderByDescending (s => s.UserFromId);
                    break;
                case SortState.DateAsc:
                    source = source.OrderBy (s => s.Date.Date);
                    break;
                case SortState.DateDesc:
                    source = source.OrderByDescending (s => s.Status);
                    break;
                default:
                    source = source.OrderBy (s => s.UserFromId);
                    break;
            }

            source = source.Where (a => a.Status == true || a.Status == false);

            var countAll = await source.CountAsync ();
            var itemsAll = await source.Skip ((page - 1) * pageSize).Take (pageSize).ToListAsync ();

            PageViewModel pageViewModelAll = new PageViewModel (countAll, page, pageSize);
            HistoryLogVM viewModelAll = new HistoryLogVM {
                PageViewModel = pageViewModelAll,
                SortViewModel = new SortViewModel (sortOrder),
                FilterViewModel = new FilterViewModel (_context.HistoryLogs.ToList (), date, namefrom, nameto),
                HistoryLogs = itemsAll
            };

            return View (viewModelAll);

        }
    }
}