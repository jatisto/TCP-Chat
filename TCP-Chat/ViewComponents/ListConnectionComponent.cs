using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Date;
using TCP_Chat.Hubs;
using TCP_Chat.Models;

namespace TCP_Chat.ViewComponents {
    public class ListConnectionComponent : ViewComponent {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;
        public ListConnectionComponent (AppDbContext context, UserManager<User> userManager, IHubContext<ChatHub> hubContext) {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        public IViewComponentResult Invoke () {
            List<string> listUserConnected = new List<string> ();
            var result = _context.Connections.Where (a => a.Connected == true);
            foreach (var item in result) {
                listUserConnected.Add (item.Name);
            }
            return View (result.ToList ());
        }

    }
}